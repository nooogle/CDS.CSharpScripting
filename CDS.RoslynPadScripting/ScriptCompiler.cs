using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CDS.RoslynPadScripting
{
    /// <summary>
    /// Script compilationn support
    /// </summary>
    public static class ScriptCompiler
    {

        /// <summary>
        /// Compile a C# script that returns a specific type. 
        /// </summary>
        /// <param name="script">Script text to compile</param>
        /// <param name="namespaceTypes">An array of references. E.g. "System.Math"</param>
        /// <param name="referenceTypes">An array assemblies to reference; the assembly for each type in this array is loaded and made available to the script</param>
        /// <param name="typeOfGlobals">Type of the Globals class used to provide global params to the script; null if not required.</param>
        /// <param name="displayDiagnosticsLine">Optional callback to let caller display (or save etc.) compilation diagnostics</param>
        /// <typeparam name="ReturnType">The type of object that is returned from the script</typeparam>
        /// <returns>A compiled script</returns>
        public static CompiledScript Compile<ReturnType>(
            string script,
            Type[] namespaceTypes,
            Type[] referenceTypes,
            Type typeOfGlobals)
        {
            GC.Collect();

            var scriptOptions = ScriptOptions.Default.WithImports(namespaceTypes.Select(r => r.Namespace));
            scriptOptions = scriptOptions.AddReferences(referenceTypes.Select(a => a.Assembly));

            var compiledScript = CSharpScript.Create<ReturnType>(
                 script,
                 globalsType: typeOfGlobals,
                 options: scriptOptions);

            compiledScript.Compile();
            var diagnostics = compiledScript.GetCompilation().GetDiagnostics();

            var compilationWrapper = new CompiledScript(
                compiledScript,
                diagnostics);

            return compilationWrapper;
        }
    }
}
