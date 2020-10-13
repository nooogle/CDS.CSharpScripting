using CDS.RoslynPadScripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo
{
    public class EasyScriptDemos
    {
        public static void HelloWorld()
        {
            var scriptText = "Console.WriteLine(\"Hello console world!\");";
            TestScript(scriptText);
        }


        public static void CompileError()
        {
            var scriptText = "var x = y";
            TestScript(scriptText);
        }


        public static void ReturnType()
        {
            var scriptText = "return \"I am a message from the script!\";";
            TestScript(scriptText);
        }

        public static void EnterYourOwn()
        {
            StartWriteBlock("Enter your own script");
            var scriptText = Console.ReadLine();
            EndWriteBlock("Enter your own script");

            TestScript(scriptText);
        }


        public class Globals
        {
            public int Counter { get; set; }
        }


        static Globals globals = new Globals();


        public static void HostData()
        {
            var scriptText = "Console.WriteLine($\"Global variable Counter = {Counter}\");";
            globals.Counter = 999;
            TestScript(scriptText, globals);
        }

        private static void TestScript(string scriptText)
        {
            TestScript(scriptText, globals: null);
        }

        private static void TestScript(string scriptText, object globals)
        {
            WriteBlock("Script", scriptText);
        
            StartWriteBlock("Compile and run");
            var easyScript = EasyScript<object>.Go(scriptText, globals);
            EndWriteBlock("Compile and run");

            WriteBlock("Script results", easyScript.ScriptResults?.ToString());
            WriteBlock("Summary", easyScript.Summary);
            WriteBlock("Compilation messages", easyScript.CompilationOutput.Messages);
            WriteBlock("Runtime exception", easyScript.RuntimeException?.Message);
        }


        private static void WriteBlock(string name, params string[] messages)
        {
            WriteBlock(name, messages as IEnumerable<string>);
        }


        private static void WriteBlock(string name, IEnumerable<string> messages)
        {
            StartWriteBlock(name);

            if (messages != null)
            {
                foreach (var message in messages)
                {
                    if (message != null)
                    {
                        Console.WriteLine(message);
                    }
                }
            }

            EndWriteBlock(name);
        }


        private static void StartWriteBlock(string name)
        {
            Console.WriteLine($"<{name}>");
        }


        private static void EndWriteBlock(string name)
        {
            Console.WriteLine($"<{name}/>");
            Console.Write(Environment.NewLine);
        }
    }
}
