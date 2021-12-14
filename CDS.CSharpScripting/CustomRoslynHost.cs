using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using RoslynPad.Roslyn;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CDS.CSharpScripting
{
    class CustomRoslynHost : RoslynHost
    {
        private Type globalsType;

        public CustomRoslynHost(
            Type globalsType,
            IEnumerable<Assembly> additionalAssemblies,
            RoslynHostReferences references) : 
            base(additionalAssemblies: additionalAssemblies, 
                references: references,
                disabledDiagnostics: null)
        {
            this.globalsType = globalsType;
        }


        protected override Project CreateProject(
            Solution solution, 
            DocumentCreationArgs args, 
            CompilationOptions compilationOptions, 
            Project previousProject)
        {
            var name = args.Name ?? "Program";
            var id = ProjectId.CreateNewId(name);

            var parseOptions = new CSharpParseOptions(kind: SourceCodeKind.Script, languageVersion: LanguageVersion.CSharp7_1);

            compilationOptions = compilationOptions.WithScriptClassName(name);

            solution = solution.AddProject(ProjectInfo.Create(
                id,
                VersionStamp.Create(),
                name,
                name,
                LanguageNames.CSharp,
                isSubmission: true,
                parseOptions: parseOptions,
                hostObjectType: globalsType,
                compilationOptions: compilationOptions,
                metadataReferences: previousProject != null ? ImmutableArray<MetadataReference>.Empty : DefaultReferences,
                projectReferences: previousProject != null ? new[] { new ProjectReference(previousProject.Id) } : null));

            var project = solution.GetProject(id);

            return project;
        }
    }
}
