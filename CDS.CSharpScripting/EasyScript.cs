using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.CSharpScripting
{
    /// <summary>
    /// TBD
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

                if(AllOk)
                {
                    summary = "All ok!";
                }
                else
                {
                    summary =
                        $"Detected {CompilationOutput.WarningCount} warning(s), " +
                        $"{CompilationOutput.ErrorCount} error(s), ";

                    if(RuntimeException == null)
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
        /// TBD
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static EasyScript<ReturnType> Go(string script)
        {
            return Go(
                script: script,
                globals: null);
        }


        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="script"></param>
        /// <param name="globals"></param>
        /// <returns></returns>
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
            catch(Exception exception)
            {
                runtimeException = exception;
            }


            return new EasyScript<ReturnType>(
                compiledScript.CompilationOutput, 
                scriptResult,
                runtimeException);
        }
    }
}
