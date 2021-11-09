using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo.Prototyping
{
    class CodeCompletion
    {
        public void Run()
        {
            Test();
        }


        private async void Test()
        {
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

            var scriptCode = "double.";

            var sourceTextAndVersion = 
                Microsoft
                .CodeAnalysis
                .TextAndVersion
                .Create(
                    text: SourceText.From(scriptCode),
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

            // cursor position is at the end
            var position = scriptCode.Length;

            var completionService = 
                Microsoft
                .CodeAnalysis
                .Completion
                .CompletionService
                .GetService(scriptDocument);

            var results = 
                await completionService
                .GetCompletionsAsync(scriptDocument, position)
                .ConfigureAwait(false);

            //double.
            foreach(var result in results.Items)
            {
                System.Diagnostics.Debug.WriteLine(result);
            }

            System.Diagnostics.Debug.WriteLine("\n\n\n");
            scriptCode = "int.";

            scriptDocument = scriptDocument.WithText(SourceText.From(scriptCode));
            
            results = 
                await completionService
                .GetCompletionsAsync(scriptDocument, scriptCode.Length)
                .ConfigureAwait(false);

            foreach (var result in results.Items)
            {
                System.Diagnostics.Debug.WriteLine(result);
            }

        }
    }
}
