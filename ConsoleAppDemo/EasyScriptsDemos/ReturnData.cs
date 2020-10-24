using CDS.CSharpScripting;
using System;

namespace ConsoleAppDemo
{
    public class ReturnData
    {

        public static void Run()
        {
            var easyScript = EasyScript<string>.Go("return \"I am a message from the script!\";");
            Console.WriteLine(easyScript.ScriptResults);
        }
    }
}
