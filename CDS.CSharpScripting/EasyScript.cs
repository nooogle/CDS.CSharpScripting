using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.CSharpScripting
{
    /// <summary>
    /// The data type that the script is expected to return. Use object if
    /// a return value is not required.
    /// </summary>
    /// <typeparam name="ReturnType"></typeparam>
    public class EasyScript<ReturnType>
    {
        /// <summary>Compilation output</summary>
        public CompilationOutput CompilationOutput { get; }


        /// <summary>Script results</summary>
        public ReturnType ScriptResults { get; }


        /// <summary>
        /// An exception caught during script exception, or null if all went well.
        /// </summary>
        public Exception RuntimeException { get; }


        /// <summary>
        /// True if the script compiled without errors or warnings and the 
        /// execution completed without exceptions
        /// </summary>
        public bool AllOk =>
            (RuntimeException == null) &&
            (CompilationOutput.WarningCount == 0) &&
            (CompilationOutput.ErrorCount == 0);


        /// <summary>
        /// A simple summary of the compilation and execution results
        /// </summary>
        public string Summary
        {
            get
            {
                string summary;

                if (AllOk)
                {
                    summary = "All ok!";
                }
                else
                {
                    summary =
                        $"Detected {CompilationOutput.WarningCount} warning(s), " +
                        $"{CompilationOutput.ErrorCount} error(s), ";

                    if (RuntimeException == null)
                    {
                        summary += "no runtime exception";
                    }
                    else
                    {
                        summary += "runtime exception";
                    }
                }

                return summary;
            }
        }


        /// <summary>
        /// Initialise
        /// </summary>
        private EasyScript(
            CompilationOutput compilationOutput,
            ReturnType scriptResults,
            Exception runtimeException)
        {
            CompilationOutput = compilationOutput;
            ScriptResults = scriptResults;
            RuntimeException = runtimeException;
        }


        /// <summary>
        /// Compile and run the script.
        /// </summary>
        /// <param name="script">A C# script.</param>
        /// <returns>
        /// An <see cref="EasyScript{ReturnType}"/> instance, providing details of the
        /// compilation and [optional] script results.
        /// </returns>
        public static EasyScript<ReturnType> Go(string script)
        {
            return Go(
                script: script,
                globals: null);
        }


        /// <summary>
        /// Compile and run the script.
        /// </summary>
        /// <param name="script">A C# script.</param>
        /// <param name="globals">
        /// An instance of some global data object. The script will be able to access public 
        /// properties and methods in this class.
        /// </param>
        /// <returns>
        /// An <see cref="EasyScript{ReturnType}"/> instance, providing details of the
        /// compilation and [optional] script results.
        /// </returns>
        public static EasyScript<ReturnType> Go(string script, object globals)
        {
            var globalsType =
                (globals == null) ?
                null :
                globals.GetType();


            var compiledScript = ScriptCompiler.Compile<ReturnType>(
                script: script,
                namespaceTypes: Defaults.TypesForNamespacesAndAssemblies,
                referenceTypes: Defaults.TypesForNamespacesAndAssemblies,
                typeOfGlobals: globalsType);

            ReturnType scriptResult = default;
            Exception runtimeException = default;

            try
            {
                scriptResult = ScriptRunner.Run<ReturnType>(compiledScript, globals);
            }
            catch (Exception exception)
            {
                runtimeException = exception;
            }


            return new EasyScript<ReturnType>(
                compiledScript.CompilationOutput,
                scriptResult,
                runtimeException);
        }


        /// <summary>
        /// Compile and run the script.
        /// </summary>
        /// <param name="script">A C# script.</param>
        /// <param name="globals">
        /// An instance of some global data object. The script will be able to access public 
        /// properties and methods in this class.
        /// </param>
        /// <returns>
        /// An <see cref="EasyScript{ReturnType}"/> instance, providing details of the
        /// compilation and [optional] script results.
        /// </returns>
        public static Task<EasyScript<ReturnType>> AsyncGo(string script, object globals)
        {
            EasyScript<ReturnType> easyScript = null;

            Task<EasyScript<ReturnType>> task = Task<EasyScript<ReturnType>>.Run(() =>
            {
                easyScript = Go(
                    script: script,
                    globals: globals);

                return easyScript;
            });

            return task;
        }
    }
}
