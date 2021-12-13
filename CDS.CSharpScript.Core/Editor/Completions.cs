using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace CDS.CSharpScript.Core.Editor
{
    public static class Completions
    {
        private static string GetDescription(Microsoft.CodeAnalysis.Completion.CompletionItem item)
        {
            //var d = Microsoft.CodeAnalysis.Completion.CompletionService.GetService(document).GetDescriptionAsync(
            //    document: scriptDocument,
            //    item: item);

            //d.Wait();

            return "?";
        }

        public static async Task<IEnumerable<CompletionEntry>> GetCompletions(
            Workspace workspace,
            string script,
            int caretPosition)
        {
            return await GetCompletions(
                workspace: workspace,
                script: script, 
                caretPosition: caretPosition, 
                cancellationToken: default);
        }

        public static async Task<IEnumerable<CompletionEntry>> GetCompletions(
            Workspace workspace,
            string script,
            int caretPosition,
            CancellationToken cancellationToken)
        {
            var sourceText =
                Microsoft
                .CodeAnalysis
                .Text
                .SourceText
                .From(script);

            var document =
                workspace.Document
                .WithText(sourceText);

            var completionService =
                Microsoft
                .CodeAnalysis
                .Completion
                .CompletionService
                .GetService(document);

            var completionList = await
                completionService
                .GetCompletionsAsync(
                    document,
                    caretPosition: caretPosition,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            IEnumerable<CompletionEntry> completionInfo = new CompletionEntry[0];

            if (completionList != null)
            {
                var currentText = await
                    document
                    .GetTextAsync(cancellationToken)
                    .ConfigureAwait(false);

                var textSpan =
                    completionService
                    .GetDefaultCompletionListSpan(
                        text: currentText,
                        caretPosition: script.Length);

                var defaultCompletionListText =
                    currentText
                    .GetSubText(textSpan);

                var filteredCompletionItems =
                    completionService
                    .FilterItems(
                        document: document,
                        items: completionList.Items,
                        filterText: defaultCompletionListText.ToString());

                completionInfo = await GetCompletionList(
                    currentDocument: document,
                    completionItems: filteredCompletionItems);
            }

            return completionInfo;
        }

        private static async Task<IEnumerable<CompletionEntry>> GetCompletionList(
            Microsoft.CodeAnalysis.Document currentDocument,
            IEnumerable<Microsoft.CodeAnalysis.Completion.CompletionItem> completionItems)
        {
            var completionList = new List<CompletionEntry>();

            foreach (var item in completionItems)
            {
                var currentText = await currentDocument.GetTextAsync().ConfigureAwait(false);
                var completedText = currentText.Replace(item.Span, item.DisplayText);
                var completedDocument = currentDocument.WithText(completedText);

                var quickInfoService =
                    Microsoft
                    .CodeAnalysis
                    .QuickInfo
                    .QuickInfoService
                    .GetService(completedDocument);

                var quickInfo = await quickInfoService.GetQuickInfoAsync(
                    completedDocument,
                    item.Span.End).ConfigureAwait(false);

                var quickInfoText =
                    quickInfo is null ?
                    "" :
                    string.Join("; ", quickInfo.Sections.Select(s => s.Text));


                var completionEntry = new CompletionEntry(
                    item: item.DisplayText,
                    tags: item.Tags,
                    quickInfo: quickInfoText);

                completionList.Add(completionEntry);

                if (completionList.Count == 10)
                {
                    break;
                }
            }


            return completionList.ToArray();
        }
    }
}
