using CDS.RoslynPadScripting;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO the runtime output does't work - the scriptung utils class hooks it for itself 
            // and we get all sorts of problems !

            // TODO single-function method for quick scripting

            var scriptText = "Console.WriteLine(\"Hello console world!\");";
            var compiledScript = default(CompiledScript);

            compiledScript = ScriptCompiler.Compile<object>(
                script: scriptText,
                namespaceTypes: new[] { typeof(int), typeof(List<string>) },
                referenceTypes: new[] { typeof(int) },
                typeOfGlobals: null,
                displayDiagnosticsLine: (msg) => Console.WriteLine($"Compiler output: [{msg}]"));


            try
            {
                ScriptRunner.Run(
                    compiledScript: compiledScript,
                    globals: null);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Caught an exception: [{exception.Message}]");
            }

            Console.ReadLine();
        }
    }
}
