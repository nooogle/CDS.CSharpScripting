using CDS.CSharpScripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppDemo
{
    static class Common
    {
        public static void SendExceptionToOutput(OutputPanel output, string msg, Exception exception)
        {
            output.CDSWriteLine(msg);
            RecursiveSendExceptionMessageToOutput(output: output, level: 1, exception: exception);
        }



        private static void RecursiveSendExceptionMessageToOutput(OutputPanel output, int level, Exception exception)
        {
            output.CDSWriteLine($"{level} msg: {exception.Message}");

            if (exception.InnerException != null)
            {
                RecursiveSendExceptionMessageToOutput(output, level + 1, exception.InnerException);
            }
        }


        public static void DisplayCompilationOutput(OutputPanel output, CompiledScript compiledScript)
        {
            output.CDSWriteLine(
                $"{compiledScript.CompilationOutput.ErrorCount} error(s), " +
                $"{compiledScript.CompilationOutput.WarningCount} warning(s)");

            foreach (var message in compiledScript.CompilationOutput.Messages)
            {
                output.CDSWriteLine(message);
            }
        }
    }
}
