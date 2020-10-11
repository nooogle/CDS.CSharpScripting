using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CDS.RoslynPadScripting
{
    /// <summary>
    /// Basic scripting utilities.
    /// </summary>
    /// <remarks>
    /// The Scintilla initialisation code is all lifted from: https://github.com/robinrodricks/ScintillaNET.Demo
    /// </remarks>
    public static class ScriptingUtils
    {
        /// <summary>
        /// Configure a Scintilla editor for use as a basic output window
        /// </summary>
        public static void ConfigureScintillaEditorAsOutputWindow(Scintilla editor)
        {
            InitBasics(editor);
            InitColors(editor);
            InitOutputWindowSyntaxColoring(editor);
            editor.ReadOnly = true;
        }


        /// <summary>
        /// Compile a C# script that returns a specific type. If object is specified then the script can 
        /// return anything or nothing (a special case).
        /// </summary>
        /// <param name="script">Script text to compile</param>
        /// <param name="scriptReferences">An array of references. E.g. "System.Math"</param>
        /// <param name="assemblyReferences">An array assemblies to reference; the assembly for each type in this array is loaded and made available to the script</param>
        /// <param name="typeOfGlobals">Type of the Globals class used to provide global params to the script; null if not required.</param>
        /// <param name="displayDiagnosticsLine">Optional callback to let caller display (or save etc.) compilation diagnostics</param>
        /// <typeparam name="ReturnType">The type of object that is returned from the script</typeparam>
        /// <returns>A compiled script</returns>
        public static CompiledScript CompileCSharpScript<ReturnType>(
            string script,
            Type[] scriptReferences,
            Type[] assemblyReferences,
            Type typeOfGlobals,
            Action<string> displayDiagnosticsLine)
        {
            GC.Collect();

            var scriptOptions = ScriptOptions.Default.WithImports(scriptReferences.Select(r => r.Namespace));
            scriptOptions = scriptOptions.AddReferences(assemblyReferences.Select(a => a.Assembly));

            var compiledScript = CSharpScript.Create<ReturnType>(
                 script,
                 globalsType: typeOfGlobals,
                 options: scriptOptions);

            compiledScript.Compile();

            if (displayDiagnosticsLine != null)
            {
                var diagnostics = compiledScript.GetCompilation().GetDiagnostics();
                if (diagnostics.Any())
                {
                    foreach (var diagnostic in diagnostics)
                    {
                        displayDiagnosticsLine($"{diagnostic}");
                    }
                }
            }

            return new CompiledScript()
            {
                ActualScript = compiledScript,
            };
        }


        /// <summary>
        /// Run the compiled script
        /// </summary>
        /// <param name="compiledScript">Script to run</param>
        /// <param name="globals">Instance of the Globals type passed into <see cref="CompileCSharpScript"/>, or null if not required.</param>
        /// <param name="onTextOutput">Optional callback to received any text emitted from the script by calling Console.Write or Console.WriteLine.</param>
        public static void RunCompiledScript(CompiledScript compiledScript, object globals, Action<string> onTextOutput)
        {
            RunCompiledScript<object>(compiledScript, globals, onTextOutput);
        }


        /// <summary>
        /// Run the compiled script
        /// </summary>
        /// <param name="compiledScript">Script to run</param>
        /// <param name="globals">Instance of the Globals type passed into <see cref="CompileCSharpScript"/>, or null if not required.</param>
        /// <param name="onTextOutput">Optional callback to received any text emitted from the script by calling Console.Write or Console.WriteLine.</param>
        public static ReturnType RunCompiledScript<ReturnType>(CompiledScript compiledScript, object globals, Action<string> onTextOutput)
        {
            var originalConsoleOut = Console.Out;
            var consoleHooker = new ConsoleOutputHooker();
            consoleHooker.OnWrite += (value) => { onTextOutput?.Invoke(value); };
            
            Console.SetOut(consoleHooker);

            var runTask = compiledScript.ActualScript.RunAsync(globals);
            runTask.Wait();
            var returnValue = (ReturnType)runTask.Result.ReturnValue;

            Console.SetOut(originalConsoleOut);

            return returnValue;
        }

        private static void InitBasics(Scintilla editor)
        {
            editor.WrapMode = WrapMode.None;
            editor.IndentationGuides = IndentView.LookBoth;
        }


        private static void InitColors(Scintilla editor)
        {

            editor.SetSelectionBackColor(true, IntToColor(0x114D9C));
            editor.CaretForeColor = System.Drawing.Color.White;

        }


        private static void InitOutputWindowSyntaxColoring(Scintilla editor)
        {
            editor.StyleResetDefault();
            editor.Styles[Style.Default].Font = "Consolas";
            editor.Styles[Style.Default].Size = 10;
            editor.StyleClearAll();
        }


        private static System.Drawing.Color IntToColor(int rgb)
        {
            return System.Drawing.Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }
    }
}
