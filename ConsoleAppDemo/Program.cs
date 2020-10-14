using CDS.RoslynPadScripting;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo
{
    class Program
    {
        static void Main()
        {
            var menu = new (string text, Action action)[]
                {
                    ("EasyScript: one line demo", EasyScriptDemos.OneLineDemo),
                    ("EasyScript: hello world", EasyScriptDemos.HelloWorld),
                    ("EasyScript: compile error", EasyScriptDemos.CompileError),
                    ("EasyScript: return type", EasyScriptDemos.ReturnType),
                    ("EasyScript: enter your own!", EasyScriptDemos.EnterYourOwn),
                    ("EasyScript: access host data from script", EasyScriptDemos.HostData),
                }.ToImmutableArray();

            TextMenu.Run("Main", menu);
        }


        static void xMain()
        {
            // TODO single-function method for quick scripting

            var scriptText = "Console.WriteLine(\"Hello console world!\");";
            var compiledScript = default(CompiledScript);

            compiledScript = ScriptCompiler.Compile<object>(
                script: scriptText,
                namespaceTypes: new[] { typeof(int), typeof(List<string>) },
                referenceTypes: new[] { typeof(int) },
                typeOfGlobals: null);

            //                 displayDiagnosticsLine: (msg) => Console.WriteLine($"Compiler output: [{msg}]"));


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
