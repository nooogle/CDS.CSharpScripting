using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CDS.CSharpScripting
{
    /// <summary>
    /// Script compilationn support
    /// </summary>
    public static class ScriptCompiler
    {
        /// <summary>
        /// Compile a C# script that doesn't return any data.
        /// Default namespaces and assembly references are used (see <see cref="Defaults.TypesForNamespacesAndAssemblies"/>).
        /// Global variables are not used.
        /// </summary>
        /// <param name="script">Script text to compile</param>
        /// <returns>A compiled script</returns>
        public static CompiledScript Compile(string script)
        {
            return Compile<object>(
                script: script,
                typeOfGlobals: null);
        }


        /// <summary>
        /// Compile a C# script that returns a specific type. 
        /// Default namespaces and assembly references are used (see <see cref="Defaults.TypesForNamespacesAndAssemblies"/>).
        /// Global variables are not used.
        /// </summary>
        /// <param name="script">Script text to compile</param>
        /// <typeparam name="ReturnType">The type of object that is returned from the script</typeparam>
        /// <returns>A compiled script</returns>
        public static CompiledScript Compile<ReturnType>(string script)
        {
            return Compile<ReturnType>(
                script: script,
                typeOfGlobals: null);
        }


        /// <summary>
        /// Compile a C# script that returns a specific type. 
        /// Default namespaces and assembly references are used (see <see cref="Defaults.TypesForNamespacesAndAssemblies"/>).
        /// </summary>
        /// <param name="script">Script text to compile</param>
        /// <param name="typeOfGlobals">Type of the Globals class used to provide global params to the script; null if not required.</param>
        /// <typeparam name="ReturnType">The type of object that is returned from the script</typeparam>
        /// <returns>A compiled script</returns>
        public static CompiledScript Compile<ReturnType>(
            string script,
            Type typeOfGlobals)
        {
            return Compile<ReturnType>(
                script: script,
                namespaceTypes: Defaults.TypesForNamespacesAndAssemblies,
                referenceTypes: Defaults.TypesForNamespacesAndAssemblies,
                typeOfGlobals: typeOfGlobals);
        }


        /// <summary>
        /// Compile a C# script that returns a specific type. 
        /// </summary>
        /// <param name="script">Script text to compile</param>
        /// <param name="namespaceTypes">An array of references. E.g. "System.Math"</param>
        /// <param name="referenceTypes">An array assemblies to reference; the assembly for each type in this array is loaded and made available to the script</param>
        /// <param name="typeOfGlobals">Type of the Globals class used to provide global params to the script; null if not required.</param>
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
