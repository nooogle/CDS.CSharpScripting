using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScratchPad
{
    /// <summary>
    /// Figure pattern for basic code completion
    /// </summary>
    class Completions1
    {
        public static async void Run()
        {
            Microsoft.CodeAnalysis.Document scriptDocument;
            scriptDocument = CreateScriptDocument(initialScript: "");

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            string[] items = new string[0];

            var task = TestScript(
                scriptDocument, 
                "int", 
                cancellationTokenSource.Token).ConfigureAwait(false);

            //cancellationTokenSource.Cancel();
            
            items = await task;
            

            items = await TestScript(
                scriptDocument, 
                "int x", 
                cancellationTokenSource.Token).ConfigureAwait(false);
            
            items = await TestScript(
                scriptDocument, 
                "int.Ma", 
                cancellationTokenSource.Token).ConfigureAwait(false);

            Console.ReadKey();
        }

        private static async Task<string[]> TestScript(
            Microsoft.CodeAnalysis.Document scriptDocument, 
            string script,
            CancellationToken cancellationToken)
        {
            Console.WriteLine("");
            Console.WriteLine(script);

            var scriptSourceText = 
                Microsoft
                .CodeAnalysis
                .Text
                .SourceText
                .From(script);

            scriptDocument = 
                scriptDocument.
                WithText(scriptSourceText);

            var completionService =
                Microsoft
                .CodeAnalysis
                .Completion
                .CompletionService
                .GetService(scriptDocument);

            var currentText = await 
                scriptDocument
                .GetTextAsync(cancellationToken)
                .ConfigureAwait(false);

            //bool shouldTriggerCompletion =
            //    completionService
            //    .ShouldTriggerCompletion(
            //        text: currentText,
            //        caretPosition: script.Length,
            //        trigger: Microsoft.CodeAnalysis.Completion.CompletionTrigger.CreateInsertionTrigger('q'));

            var textSpan = 
                completionService
                .GetDefaultCompletionListSpan(
                    text: currentText,
                    caretPosition: script.Length);

            var defaultCompletionListText = 
                currentText
                .GetSubText(textSpan);

            var completionList = await 
                completionService
                .GetCompletionsAsync(
                    scriptDocument, 
                    script.Length,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            //DisplayCompleationList(
            //    currentDocument: scriptDocument,
            //    completionItems: completionList.Items);

            var filteredCompletionItems = 
                completionService
                .FilterItems(
                    document: scriptDocument,
                    items: completionList.Items,
                    filterText: defaultCompletionListText.ToString());

            var completionInfo = await GetCompleationList(
                currentDocument: scriptDocument,
                completionItems: filteredCompletionItems);

            foreach (var item in filteredCompletionItems) { Console.WriteLine(item); }

            return completionInfo;
        }

        private static async Task<string[]> GetCompleationList(
            Microsoft.CodeAnalysis.Document currentDocument,
            IEnumerable<Microsoft.CodeAnalysis.Completion.CompletionItem> completionItems)
        {
            List<string> completionList = new List<string>();

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

                string info = "";
                foreach (var tag in item.Tags) { info += $"[{tag}], "; }
                info += $"[{ item.DisplayText}], span [{item.Span}] QI [{quickInfoText}]";
                completionList.Add(info);

                if(completionList.Count == 10)
                {
                    break;
                }
            }

            return completionList.ToArray();
        }

        private static Microsoft.CodeAnalysis.Document CreateScriptDocument(string initialScript)
        {
            if (initialScript is null)
            {
                throw new ArgumentNullException(nameof(initialScript));
            }

            var compilationOptions = new
                Microsoft
                .CodeAnalysis
                .CSharp
                .CSharpCompilationOptions(
                    Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary,
                    usings: new[] { "System" });

            var metadataReferences = new[]
            {
                Microsoft
                    .CodeAnalysis
                    .MetadataReference
                    .CreateFromFile(typeof(object).Assembly.Location),
            };

            var projectId = Microsoft.CodeAnalysis.ProjectId.CreateNewId();
            var projectVersion = Microsoft.CodeAnalysis.VersionStamp.Create();

            var scriptProjectInfo = Microsoft.CodeAnalysis.ProjectInfo.Create(
                id: projectId,
                version: projectVersion,
                name: "Script",
                assemblyName: "Script",
                language: Microsoft.CodeAnalysis.LanguageNames.CSharp,
                isSubmission: true,
                metadataReferences: metadataReferences,
                compilationOptions: compilationOptions);

            var defaultAssemblies =
                Microsoft
                .CodeAnalysis
                .Host
                .Mef
                .MefHostServices
                .DefaultAssemblies;

            var mefHostServices =
                Microsoft
                .CodeAnalysis
                .Host
                .Mef
                .MefHostServices
                .Create(defaultAssemblies);

            var workspace = new
                Microsoft
                .CodeAnalysis
                .AdhocWorkspace(mefHostServices);

            var scriptProject = workspace.AddProject(scriptProjectInfo);

            var documentId =
                Microsoft
                .CodeAnalysis
                .DocumentId
                .CreateNewId(scriptProject.Id);

            var sourceVersion = Microsoft.CodeAnalysis.VersionStamp.Create();

            var sourceTextAndVersion =
                Microsoft
                .CodeAnalysis
                .TextAndVersion
                .Create(
                    text: Microsoft.CodeAnalysis.Text.SourceText.From(initialScript),
                    version: sourceVersion);

            var textLoader =
                Microsoft
                .CodeAnalysis
                .TextLoader
                .From(sourceTextAndVersion);

            var scriptDocumentInfo = Microsoft.CodeAnalysis.DocumentInfo.Create(
                id: documentId,
                name: "Script",
                sourceCodeKind: Microsoft.CodeAnalysis.SourceCodeKind.Script,
                loader: textLoader);

            var scriptDocument = workspace.AddDocument(scriptDocumentInfo);

            return scriptDocument;
        }
    }
}
