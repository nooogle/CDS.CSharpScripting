# CDS.CSharpScripting
1. C# code editor
2. Script compilation and execution

The code editor is a simplified wrapper around the amazing [RoslynPad C# WPF](https://github.com/aelij/RoslynPad) code editor, via the RoslynPad.Roslyn.Windows NuGet pacakge.

Compilation and execution is built around Microsoft's open-source .Net compiler platform
known as [Roslyn](https://en.wikipedia.org/wiki/Roslyn_(compiler)), available from 
the Microsoft.CSharp package on NuGet.

**Note** there seem to be some bugs in Roslypad and/or AvalonEdit (the underlying text 
editor) that cause result in thread exceptions being thrown. See the notes below on how
to add a hook to your app to catch these. 

## Overview

* Create a .Net application with an embedded C# code editor providing live intellisense
* Compile and execute scripts
* Interact with scripts by sharing data (as global variables) and returning data back to the host


<img src="./Wiki/Wiki_diagrams.jpg">



## Demo

Code:
`EasyScript<object>.Go("Console.WriteLine(\"This is a one line script demo!\");");`

Output:
`This is a one line script demo!`


## Catching ThreadExceptions

At the time of writing, using RoslynPad 3.6.0, there are occasional WinForms 
thread exceptions - these are (probably) thrown when some activity is attempted
on the wrong thread. For now, all we can do is send the exception to the 
debug output. Unfortunately this must be done from the host application to
ensure it's applied before any UI controls are created.

In the WinForms test application, program.cs, we use this:


```static void Main()
{
    HookThreadExceptions();
    <snip/>
}

private static void HookThreadExceptions()
{
    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, true);
    Application.ThreadException += Application_ThreadException;
}


private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
{
    if (new[] { "RoslynPad", "AvalonEdit" }.Any(lib => e.Exception.StackTrace.Contains(lib)))
    {
        System.Diagnostics.Debug.WriteLine(
            $"Caught a WinForms thread exception, possibly due to a " +
            $"problem in RoslynPad or dependent library.");

        System.Diagnostics.Debug.WriteLine($"Exception message: {e.Exception.Message}");
        System.Diagnostics.Debug.WriteLine($"Exception stack trace: {e.Exception.StackTrace}");
    }
    else
    {
        System.Diagnostics.Debug.WriteLine($"Caught a WinForms thread exception, unknown reason.");
    }
}


```
