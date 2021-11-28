using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace CDS.CSharpScript.Core
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
            foreach (var type in types)
            {
                if (type == null)
                {
                    throw new NullReferenceException();
                }
            }
        }

        public ScriptEnv()
            : this(
                  namespaceTypes: new Type[] { },
                  additionalAssemblies: new Assembly[] { },
                  typeOfGlobals: null)
        {
        }


        public ScriptEnv(
            IEnumerable<Type> namespaceTypes,
            IEnumerable<Assembly> additionalAssemblies,
            Type typeOfGlobals)
        {
            var compilationOptions = new
                Microsoft
                .CodeAnalysis
                .CSharp
                .CSharpCompilationOptions(
                    outputKind: Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary,
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

            //var assemblies =
            //    Microsoft
            //    .CodeAnalysis
            //    .Host
            //    .Mef
            //    .MefHostServices
            //    .DefaultAssemblies;

            var assemblies = new List<Assembly>();
            assemblies.Add(Assembly.Load("Microsoft.CodeAnalysis"));
            assemblies.Add(Assembly.Load("Microsoft.CodeAnalysis.Workspaces"));
            assemblies.Add(Assembly.Load("Microsoft.CodeAnalysis.CSharp"));
            assemblies.Add(Assembly.Load("Microsoft.CodeAnalysis.CSharp.Workspaces"));
            assemblies.Add(Assembly.Load("Microsoft.CodeAnalysis.Features"));
            assemblies.Add(Assembly.Load("Microsoft.CodeAnalysis.CSharp.Features"));
            assemblies.AddRange(additionalAssemblies);

            //var partTypes = Microsoft
            //    .CodeAnalysis
            //    .Host
            //    .Mef
            //    .MefHostServices
            //    .DefaultAssemblies
            //    .Concat(assemblies)
            //        .Distinct()
            //        .SelectMany(x => x.GetTypes())
            //        .ToArray();

            //var compositionContext = new System
            //    .Composition
            //    .Hosting
            //    .ContainerConfiguration()
            //    .WithParts(partTypes)
            //    .CreateContainer();

            var mefHostServices = Microsoft
                .CodeAnalysis
                .Host
                .Mef
                .MefHostServices
                .Create(assemblies);

            var workspace = new
                Microsoft
                .CodeAnalysis
                //.AdhocWorkspace();
                .AdhocWorkspace(mefHostServices);

            var projectReference = new Microsoft.CodeAnalysis.ProjectReference(projectId);

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
            int caretPosition)
        {
            return await GetCompletions(
                script: script, 
                caretPosition: caretPosition, 
                cancellationToken: default);
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
