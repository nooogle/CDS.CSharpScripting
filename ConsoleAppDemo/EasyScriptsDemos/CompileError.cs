using CDS.CSharpScripting;
using System;

namespace ConsoleAppDemo
{
    public class CompileError
    {
        public static void Run()
        {
            var easyScript = EasyScript<object>.Go("var x = y");
            Console.WriteLine(easyScript.Summary);
            foreach(var message in easyScript.CompilationOutput.Messages)
            {
                Console.WriteLine($"Message: {message}");
            }
        }
    }
}