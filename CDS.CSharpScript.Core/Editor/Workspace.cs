using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Immutable;

namespace CDS.CSharpScript.Core.Editor
{
    public class Workspace
    {
        Microsoft.CodeAnalysis.AdhocWorkspace adhocWorkspace;

        public Microsoft.CodeAnalysis.Document Document { get; private set; }


        public Workspace()
            : this(
                  namespaceTypes: new Type[] { },
                  additionalAssemblies: new Assembly[] { },
                  typeOfGlobals: null)
        {
        }


        public Workspace(
            IEnumerable<Type> namespaceTypes,
            IEnumerable<Assembly> additionalAssemblies,
            Type typeOfGlobals)
        {
            ImmutableArray<string> usings = ImmutableArray<string>.Empty;
            usings = usings.Add("System");
            foreach (var type in namespaceTypes)
            {
                usings = usings.Add(type.Namespace);
            }

            var compilationOptions = new
                Microsoft
                .CodeAnalysis
                .CSharp
                .CSharpCompilationOptions(
                    outputKind: Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary,
                    usings: usings);

            var metadataReferences = new List<Microsoft.CodeAnalysis.PortableExecutableReference>
            {
                Microsoft
                    .CodeAnalysis
                    .MetadataReference
                    .CreateFromFile(typeof(object).Assembly.Location)
            };

            foreach (var additionalAssembly in additionalAssemblies)
            {
                metadataReferences.Add(
                    Microsoft
                        .CodeAnalysis
                        .MetadataReference
                        .CreateFromFile(typeof(System.IO.Path).Assembly.Location));
            }

            var projectId = Microsoft.CodeAnalysis.ProjectId.CreateNewId();
            var projectVersion = Microsoft.CodeAnalysis.VersionStamp.Create();

            var assemblies =
                Microsoft
                .CodeAnalysis
                .Host
                .Mef
                .MefHostServices
                .DefaultAssemblies
                .AddRange(additionalAssemblies);

            var partTypes = Microsoft
                .CodeAnalysis
                .Host
                .Mef
                .MefHostServices
                .DefaultAssemblies
                .Concat(assemblies)
                .Distinct()
                .SelectMany(x => x.GetTypes())
                .ToArray();

            var compositionContext = new System
                .Composition
                .Hosting
                .ContainerConfiguration()
                .WithParts(partTypes)
                .CreateContainer();

            var mefHostServices = Microsoft
                .CodeAnalysis
                .Host
                .Mef
                .MefHostServices
                .Create(compositionContext);

            adhocWorkspace = new
                Microsoft
                .CodeAnalysis
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
                .WithCompilationOptions(compilationOptions)
                .WithDefaultNamespace("using System.IO");

            var parseOptions = new 
                Microsoft
                .CodeAnalysis
                .CSharp
                .CSharpParseOptions(Microsoft.CodeAnalysis.CSharp.LanguageVersion.CSharp7_1);

            var solution =
                adhocWorkspace
                .CurrentSolution
                .AddProject(projectInfo)
                .WithProjectParseOptions(
                    projectId: projectId,
                    options: parseOptions);

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
            bool ok = adhocWorkspace.TryApplyChanges(solution);
            System.Diagnostics.Debug.Assert(ok);
            this.Document = solution.GetDocument(documentId);
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
                this.Document
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
