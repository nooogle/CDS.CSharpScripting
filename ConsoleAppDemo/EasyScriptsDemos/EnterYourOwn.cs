using CDS.CSharpScripting;
using System;

namespace ConsoleAppDemo
{
    public class EnterYourOwn
    {

        public static void Run()
        {
            Console.WriteLine("Enter your own script");
            var script = Console.ReadLine();
            var easyScript = EasyScript<object>.Go(script);
            Console.WriteLine($"Summary: {easyScript.Summary}");
            Console.WriteLine($"Runtime exception: {easyScript.RuntimeException}");
            Console.WriteLine($"Return data: {easyScript.ScriptResults}");
        }
    }
}
