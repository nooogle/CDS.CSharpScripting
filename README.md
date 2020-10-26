# CDS.CSharpScripting

Super-simple .Net Framework tools for C# scripting, including:

1. C# code editor
2. Script compilation and execution

YouTube demo: https://youtu.be/YQy_tLJY_Mw

The code editor is a simplified wrapper around the amazing [RoslynPad C# WPF](https://github.com/aelij/RoslynPad) code editor, via the RoslynPad.Roslyn.Windows NuGet pacakge.

Compilation and execution is built around Microsoft's open-source .Net compiler platform
known as [Roslyn](https://en.wikipedia.org/wiki/Roslyn_(compiler)), available from 
the Microsoft.CSharp package on NuGet.

**Note** there seem to be some bugs in Roslypad and/or AvalonEdit (the underlying text 
editor) that cause result in thread exceptions being thrown. See the notes below,
[ThreadException](#ThreadException), on how to add a hook in your app to catch these. 


## Getting started

Use NuGet to bring in CDS.CSharpScripting to your project. This project is 
(currently) only written and tested around .Net Framework V4.8 WinForms 
development.


## WinForms code editor

For the code editor, using a collection of commonly used namespaces:

1. Use the ToolBar to find the CodeEditor control and drag it onto your form.
2. In the Form's Load event handler initialise the editor by calling CDSInitialise.
3. That's it!

CDSInitialise has overloads that allow different namespaces and assembly references
to be specified. See the demos for more information. It also allows the type of 
a global variables class to be specified - this allows for data sharing between
the script and the host.

At any point the script can be read/written via the CDSScript property on the 
code editor.

To run the script:
1. Use EasyScript for simple compilation and execution.
2. Use the ScriptCompiler and ScriptRunning classes. These allow a compiled script to be run many times without needing to recompile. It also allows static data in the script to be retained between executions.


## Capturing console output

A utility class, ConsoleOutputHook, allows any scripted Console.Write or 
Console.WriteLine output to be redirected programmatically. In the WinForms demo
project we send this output to an OutputPanel.

```
using (var consoleHook = new ConsoleOutputHook(msg => outputPanel.CDSWrite(msg)))
{
    <snip/>
}
```


 
## Walkthoughs

### EasyScript

This requires the least infrastructure. Just call the Go method, pass in a script,
and capture any returned data.

Example 1:

`EasyScript<object>.Go("Console.WriteLine(\"Hello world, from the script!\");");`

Output:

`Hello world, from the script!`


Example 2: 

```
var easyScript = EasyScript<object>.Go("var x = y");
Console.WriteLine(easyScript.Summary);
foreach(var message in easyScript.CompilationOutput.Messages)
{
    Console.WriteLine($"Message: {message}");
}
```


Output:

```
Detected 0 warning(s), 2 error(s), runtime exception
Message: (1,10): error CS1002: ; expected
Message: (1,9): error CS0103: The name 'y' does not exist in the current context
```


Example 3:

```
var easyScript = EasyScript<string>.Go("return \"I am a message from the script!\";");
Console.WriteLine(easyScript.ScriptResults);
```

Output:

`I am a message from the script!`




## ThreadException

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
