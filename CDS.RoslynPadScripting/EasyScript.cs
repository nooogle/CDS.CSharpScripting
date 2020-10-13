using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.RoslynPadScripting
{
    public class EasyScript<ReturnType>
    {
        static Type[] defaultNamespaceTypes = new Type[]
        {
            typeof(int), // using System;
        };


        static Type[] defaultReferenceTypes = new Type[]
        {
            typeof(int), // mscorlib
        };


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


        public static EasyScript<ReturnType> Go(string script)
        {
            return Go(
                script: script,
                globals: null);
        }


        public static EasyScript<ReturnType> Go(string script, object globals)
        {
            var globalsType =
                (globals == null) ?
                null :
                globals.GetType();


            var compiledScript = ScriptCompiler.Compile<ReturnType>(
                script: script,
                namespaceTypes: defaultNamespaceTypes,
                referenceTypes: defaultReferenceTypes,
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
