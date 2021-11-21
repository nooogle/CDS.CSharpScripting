using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace CDS.CSharpScripting.EditorServices
{
    public class ScriptEnv
    {
        Microsoft.CodeAnalysis.Document scriptDocument;
        //Microsoft.CodeAnalysis.Completion.CompletionService completionService;
        Microsoft.CodeAnalysis.Completion.CompletionList completionList;
        string lastScript = "";
        Microsoft.CodeAnalysis.Completion.CompletionList lastCompletionList;

        static void ForceAssembliesToBeExplicitlyDependent(IEnumerable<Type> types)
        {
            foreach(var type in types)
            {
                if(type== null)
                {
                    throw new NullReferenceException();
                }
            }
        }

        public ScriptEnv()
        {
            ForceAssembliesToBeExplicitlyDependent(new[]
            {
                typeof(System.Composition.CompositionContextExtensions),
                typeof(System.Reflection.Metadata.ArrayShape),
                typeof(Microsoft.CSharp.CSharpCodeProvider),
                typeof(Microsoft.CodeAnalysis.CSharp.Formatting.CSharpFormattingOptions),
            });



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

            var projectReference = new ProjectReference(projectId);

            var projectInfo =
                Microsoft
                .CodeAnalysis
                .ProjectInfo
                .Create(
                    id: projectId,
                    version: projectVersion,
                    name: "Script123",
                    assemblyName: "Script456",
                    language: Microsoft.CodeAnalysis.LanguageNames.CSharp,
                    isSubmission: true)
                .WithMetadataReferences(metadataReferences)
                //.WithProjectReferences( new[] { projectReference })
                .WithCompilationOptions(compilationOptions);

            var solution = workspace.CurrentSolution.AddProject(projectInfo);

            var sourceVersion = Microsoft.CodeAnalysis.VersionStamp.Create();

            var dummyScriptCode = "";

            var sourceTextAndVersion =
                Microsoft
                .CodeAnalysis
                .TextAndVersion
                .Create(
                    text: Microsoft.CodeAnalysis.Text.SourceText.From(dummyScriptCode),
                    version: sourceVersion);

            var textLoader =
                Microsoft
                .CodeAnalysis
                .TextLoader
                .From(sourceTextAndVersion);

            var documentId =
                Microsoft
                .CodeAnalysis
                .DocumentId
                .CreateNewId(projectInfo.Id);

            var scriptDocumentInfo = Microsoft.CodeAnalysis.DocumentInfo.Create(
                id: documentId,
                name: "Script",
                sourceCodeKind: Microsoft.CodeAnalysis.SourceCodeKind.Script,
                loader: textLoader);

            solution = solution.AddDocument(scriptDocumentInfo);
            bool ok = workspace.TryApplyChanges(solution);
            System.Diagnostics.Debug.Assert(ok);
            this.scriptDocument = solution.GetDocument(documentId);


            //CancellationTokenSource c = new CancellationTokenSource();
            //RefreshCompletions("", 0, c.Token).Wait();
            //RefreshCompletions("int.", 4, c.Token).Wait();

            //completionService =
            //    Microsoft
            //    .CodeAnalysis
            //    .Completion
            //    .CompletionService
            //    .GetService(scriptDocument);
        }


        //public async Task<CompletionEntry[]> Test(string script, int caretPosition, CancellationToken cancellationToken)
        //{
        //    string currentWord = GetCurrentEditingWord(script);
        //    bool isOneCharAppendedToPreviousScript = IsOneCharAppendedToPreviousScript(script);

        //    System.Diagnostics.Debug.WriteLine(
        //        $"\nTest: pos [{caretPosition}], CW [{currentWord}], APP [{isOneCharAppendedToPreviousScript}], script [{script}]");


        //    lastScript = script;
        //    //var completionList = lastCompletionList;
        //    string[] completionList = new string[0];

        //    bool alwaysRefreshBecuaseReuseDoesntWork = true;

        //    if (alwaysRefreshBecuaseReuseDoesntWork ||
        //        !isOneCharAppendedToPreviousScript || 
        //        (completionList == null) ||
        //        string.IsNullOrEmpty(currentWord))
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Refreshing completion list");

        //        completionList = await RefreshCompletions(
        //            script, 
        //            caretPosition,
        //            cancellationToken).ConfigureAwait(false);

        //        //lastCompletionList = completionList;
        //    }
        //    else
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Reusing completion list");
        //    }

        //    CompletionEntry[] completionInfo = 
        //        ExtractCompletionInfo(
        //            currentWord, 
        //            completionList);

        //    return completionInfo;
        //}



        private CompletionEntry[] ExtractCompletionInfo(
            string currentWord,
            string[] completionList)
        {
            return completionList.Select(n => new CompletionEntry(n, n)).ToArray();

            //var noFilter = string.IsNullOrEmpty(currentWord);

            //CompletionEntry[] entries =
            //    completionList?
            //    .Items
            //    .Where(item => (noFilter || item.DisplayText.StartsWith(currentWord, StringComparison.OrdinalIgnoreCase)))
            //    .Select(item => new CompletionEntry(
            //        item: item.DisplayText, 
            //        description: GetDescription(item)))
            //    .ToArray()
            //    ?? 
            //    Array.Empty<CompletionEntry>();

            //return entries;
        }

        private string GetDescription(Microsoft.CodeAnalysis.Completion.CompletionItem item)
        {
            //var d = Microsoft.CodeAnalysis.Completion.CompletionService.GetService(document).GetDescriptionAsync(
            //    document: scriptDocument,
            //    item: item);

            //d.Wait();

            return "?";
        }

        public async Task<IEnumerable<CompletionEntry>> GetCompletions(
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
                this.scriptDocument
                .WithText(sourceText);

            var completionService =
                Microsoft
                .CodeAnalysis
                .Completion
                .CompletionService
                .GetService(document);

            completionList = await
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

                string info = "";
                foreach (var tag in item.Tags) { info += $"[{tag}], "; }
                info += $"[{ item.DisplayText}], span [{item.Span}] QI [{quickInfoText}]";

                var completionEntry = new CompletionEntry(
                    item: item.DisplayText,
                    description: info);

                completionList.Add(completionEntry);

                if (completionList.Count == 10)
                {
                    break;
                }
            }

            return completionList.ToArray();
        }


        private bool IsOneCharAppendedToPreviousScript(string script)
        {
            var isOneCharAppendedToPreviousScript = false;
            var isNewScriptOneCharLongerThanPrevious = ((script.Length - 1) == lastScript.Length);
            if (isNewScriptOneCharLongerThanPrevious)
            {
                isOneCharAppendedToPreviousScript =
                    (string
                    .Compare(
                        strA: lastScript,
                        indexA: 0,
                        strB: script,
                        indexB: 0,
                        length: lastScript.Length) == 0);
            }

            return isOneCharAppendedToPreviousScript;
        }


        private static string GetCurrentEditingWord(string script)
        {
            var delims = new char[] { ' ', '.', '\n' };
            var index = script.LastIndexOfAny(delims);

            string currentWord;

            var didFindDelim = (index >= 0);

            if(!didFindDelim)
            {
                currentWord = script;
            }
            else
            {
                currentWord = script.Substring(index + 1);
            }

            if(currentWord.Length > 0)
            {
                if(!char.IsLetter(currentWord[0]))
                {
                    currentWord = string.Empty;
                }
            }

            return currentWord.Trim();
        }
    }
}
