using System;
using System.Collections.Immutable;
using System.Diagnostics;

namespace ConsoleAppDemo
{
    class Program
    {
        static void Main()
        {
            new Prototyping.CodeCompletion().Run();
            return;

            var menu = new (string text, Action action)[]
                {
                    ("EasyScript", EasyScriptDemos.Menu.Run),
                }.ToImmutableArray();

            DisplayAppNameAndVersion();
            TextMenu.Run("Main", menu);
        }


        private static void DisplayAppNameAndVersion()
        {
            var thisAppFile = typeof(Program).Assembly.Location;
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(thisAppFile);
            Console.WriteLine($"{fileVersionInfo.ProductName} [{fileVersionInfo.ProductVersion}]");
        }
    }
}
