using CDS.CSharpScripting;
using System;

namespace ConsoleAppDemo.EasyScriptDemos
{
    public class Async
    {
        public class Globals
        {
            public bool ShouldQuit { get; set; }
        }



        public static void Run()
        {
            Globals globals = new Globals();

            var script = string.Join(
                Environment.NewLine,
                "while (ShouldQuit == false)",
                "{",
                    "Console.WriteLine($\"Script running - time is {DateTime.Now:HH:mm:ss.fff}\");",
                    "Thread.Sleep(500);",
                "}",
                "Console.WriteLine(\"Script complete\");");

            Console.WriteLine(script);

            Console.WriteLine("\nStarting... press any key to signal the script to stop");
            var easyScriptTask = EasyScript<object>.AsyncGo(script, globals);
            Console.ReadKey(intercept: true);

            Console.WriteLine("Signalling the script to stop asap and waiting for completion...");
            globals.ShouldQuit = true;
            easyScriptTask.Wait();

            var easyScript = easyScriptTask.Result;
            Console.WriteLine(easyScript.Summary);
        }
    }
}
