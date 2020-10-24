using CDS.CSharpScripting;
using System;

namespace ConsoleAppDemo
{
    public class HostData
    {
        public class Globals
        {
            public int Counter { get; set; }
        }


        static Globals globals = new Globals();


        public static void Run()
        {
            var script = string.Join(
                separator: Environment.NewLine,
                "Console.WriteLine($\"Script: Global variable Counter = {Counter}\");",
                "Counter *= 2;",
                "Console.WriteLine($\"Script: Global variable Counter = {Counter}\");");

            globals.Counter = 999;

            EasyScript<object>.Go(script, globals);
            Console.WriteLine($"Host: Counter = {globals.Counter}");
        }
    }
}
