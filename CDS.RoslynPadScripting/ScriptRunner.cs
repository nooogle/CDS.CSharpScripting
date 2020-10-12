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
    /// Run compiled scripts
    /// </summary>
    public static class ScriptRunner
    {
        /// <summary>
        /// Run the compiled script
        /// </summary>
        /// <param name="compiledScript">Script to run</param>
        /// <param name="globals">Instance of the Globals type passed into <see cref="CompileCSharpScript"/>, or null if not required.</param>
        /// <param name="onTextOutput">Optional callback to received any text emitted from the script by calling Console.Write or Console.WriteLine.</param>
        public static void Run(CompiledScript compiledScript, object globals)
        {
            Run<object>(compiledScript, globals);
        }


        /// <summary>
        /// Run the compiled script
        /// </summary>
        /// <param name="compiledScript">Script to run</param>
        /// <param name="globals">Instance of the Globals type passed into <see cref="CompileCSharpScript"/>, or null if not required.</param>
        /// <param name="onTextOutput">Optional callback to received any text emitted from the script by calling Console.Write or Console.WriteLine.</param>
        public static ReturnType Run<ReturnType>(CompiledScript compiledScript, object globals)
        {

            var runTask = compiledScript.ActualScript.RunAsync(globals);
            runTask.Wait();
            var returnValue = (ReturnType)runTask.Result.ReturnValue;
            return returnValue;
        }
    }
}
