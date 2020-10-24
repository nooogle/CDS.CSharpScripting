using System;
using System.Collections.Immutable;

namespace ConsoleAppDemo.EasyScriptDemos
{
    class Menu
    {
        public static void Run()
        {
            var menu = new (string text, Action action)[]
                {
                    ("Hello world", HelloWorld.Run),
                    ("Compile error", CompileError.Run),
                    ("Return type", ReturnData.Run),
                    ("Enter your own!", EnterYourOwn.Run),
                    ("Access host data from script", HostData.Run),
                    ("Async with cancellation", Async.Run),
                }.ToImmutableArray();

            TextMenu.Run("EasyScript", menu);
        }
    }
}
