using CDS.CSharpScripting;

namespace ConsoleAppDemo.EasyScriptDemos
{
    public static class HelloWorld
    {
        public static void Run()
        {
            EasyScript<object>.Go("Console.WriteLine(\"Hello world, from the script!\");");
        }
    }
}
