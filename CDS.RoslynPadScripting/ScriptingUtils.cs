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
        /// Configure a Scintilla editor for use as a C# editor
        /// </summary>
        public static void ConfigureScintillaEditorAsCSharpEditor(Scintilla editor)
        {
            InitBasics(editor);
            InitColors(editor);
            InitCSSyntaxColoring(editor);
            InitNumberMargin(editor);
            InitBookmarkMargin(editor);
            InitCodeFolding(editor);
        }


        /// <summary>
        /// Compile a C# script
        /// </summary>
        /// <param name="script">Script text to compile</param>
        /// <param name="scriptReferences">An array of references. E.g. "System.Math"</param>
        /// <param name="assemblyReferences">An array assemblies to reference; the assembly for each type in this array is loaded and made available to the script</param>
        /// <param name="typeOfGlobals">Type of the Globals class used to provide global params to the script; null if not required.</param>
        /// <param name="displayDiagnosticsLine">Optional callback to let caller display (or save etc.) compilation diagnostics</param>
        /// <returns>A compiled script</returns>
        public static CompiledScript CompileCSharpScript(string script, string[] scriptReferences, Type[] assemblyReferences, Type typeOfGlobals, Action<string> displayDiagnosticsLine)
        {
            return CompileCSharpScript<object>(
                script,
                scriptReferences,
                assemblyReferences,
                typeOfGlobals,
                displayDiagnosticsLine);
        }


        /// <summary>
        /// Compile a C# script
        /// </summary>
        /// <param name="script">Script text to compile</param>
        /// <param name="scriptReferences">An array of references. E.g. "System.Math"</param>
        /// <param name="assemblyReferences">An array assemblies to reference; the assembly for each type in this array is loaded and made available to the script</param>
        /// <param name="typeOfGlobals">Type of the Globals class used to provide global params to the script; null if not required.</param>
        /// <param name="displayDiagnosticsLine">Optional callback to let caller display (or save etc.) compilation diagnostics</param>
        /// <returns>A compiled script</returns>
        public static CompiledScript CompileCSharpScript<ReturnType>(
            string script, 
            string[] scriptReferences, 
            Type[] assemblyReferences, 
            Type typeOfGlobals,
            Action<string> displayDiagnosticsLine)
        {
            GC.Collect();

            var scriptOptions = ScriptOptions.Default.WithImports(scriptReferences);

            var assemblies = new List<Assembly>();
            foreach (var assemblyReference in assemblyReferences)
            {
                assemblies.Add(Assembly.GetAssembly(assemblyReference));
            }

            scriptOptions = scriptOptions.AddReferences(assemblies.ToArray());

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
            consoleHooker.OnWriteLine += (value) => { onTextOutput?.Invoke(value + "\n"); };

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

        private static void InitCSSyntaxColoring(Scintilla editor)
        {
            // Configure the default style
            editor.StyleResetDefault();
            editor.Styles[Style.Default].Font = "Consolas";
            editor.Styles[Style.Default].Size = 10;
            editor.Styles[Style.Default].BackColor = IntToColor(0x212121);
            editor.Styles[Style.Default].ForeColor = IntToColor(0xFFFFFF);
            editor.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            editor.Styles[Style.Cpp.Identifier].ForeColor = IntToColor(0xD0DAE2);
            editor.Styles[Style.Cpp.Comment].ForeColor = IntToColor(0xBD758B);
            editor.Styles[Style.Cpp.CommentLine].ForeColor = IntToColor(0x40BF57);
            editor.Styles[Style.Cpp.CommentDoc].ForeColor = IntToColor(0x2FAE35);
            editor.Styles[Style.Cpp.Number].ForeColor = IntToColor(0xFFFF00);
            editor.Styles[Style.Cpp.String].ForeColor = IntToColor(0xFFFF00);
            editor.Styles[Style.Cpp.Character].ForeColor = IntToColor(0xE95454);
            editor.Styles[Style.Cpp.Preprocessor].ForeColor = IntToColor(0x8AAFEE);
            editor.Styles[Style.Cpp.Operator].ForeColor = IntToColor(0xE0E0E0);
            editor.Styles[Style.Cpp.Regex].ForeColor = IntToColor(0xff00ff);
            editor.Styles[Style.Cpp.CommentLineDoc].ForeColor = IntToColor(0x77A7DB);
            editor.Styles[Style.Cpp.Word].ForeColor = IntToColor(0x48A8EE);
            editor.Styles[Style.Cpp.Word2].ForeColor = IntToColor(0xF98906);
            editor.Styles[Style.Cpp.CommentDocKeyword].ForeColor = IntToColor(0xB3D991);
            editor.Styles[Style.Cpp.CommentDocKeywordError].ForeColor = IntToColor(0xFF0000);
            editor.Styles[Style.Cpp.GlobalClass].ForeColor = IntToColor(0x48A8EE);

            editor.Lexer = Lexer.Cpp;

            editor.SetKeywords(0, "class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            editor.SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");
        }


        private static void InitOutputWindowSyntaxColoring(Scintilla editor)
        {
            // Configure the default style
            editor.StyleResetDefault();
            editor.Styles[Style.Default].Font = "Consolas";
            editor.Styles[Style.Default].Size = 10;
            //editor.Styles[Style.Default].BackColor = IntToColor(0x212121);
            //editor.Styles[Style.Default].ForeColor = IntToColor(0xFFFFFF);
            editor.StyleClearAll();
        }


        private static System.Drawing.Color IntToColor(int rgb)
        {
            return System.Drawing.Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }


        /// <summary>
        /// the background color of the text area
        /// </summary>
        private const int BACK_COLOR = 0x2A211C;

        /// <summary>
        /// default text color of the text area
        /// </summary>
        private const int FORE_COLOR = 0xB7B7B7;

        /// <summary>
        /// change this to whatever margin you want the line numbers to show in
        /// </summary>
        private const int NUMBER_MARGIN = 1;

        /// <summary>
        /// change this to whatever margin you want the bookmarks/breakpoints to show in
        /// </summary>
        private const int BOOKMARK_MARGIN = 2;
        private const int BOOKMARK_MARKER = 2;

        /// <summary>
        /// change this to whatever margin you want the code folding tree (+/-) to show in
        /// </summary>
        private const int FOLDING_MARGIN = 3;

        /// <summary>
        /// set this true to show circular buttons for code folding (the [+] and [-] buttons on the margin)
        /// </summary>
        private const bool CODEFOLDING_CIRCULAR = true;

        private static void InitNumberMargin(Scintilla editor)
        {

            editor.Styles[Style.LineNumber].BackColor = IntToColor(BACK_COLOR);
            editor.Styles[Style.LineNumber].ForeColor = IntToColor(FORE_COLOR);
            editor.Styles[Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            editor.Styles[Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);

            var nums = editor.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

//            editor.MarginClick += TextArea_MarginClick;
        }

        private static void InitBookmarkMargin(Scintilla editor)
        {

            //TextArea.SetFoldMarginColor(true, IntToColor(BACK_COLOR));

            var margin = editor.Margins[BOOKMARK_MARGIN];
            margin.Width = 20;
            margin.Sensitive = true;
            margin.Type = MarginType.Symbol;
            margin.Mask = (1 << BOOKMARK_MARKER);
            //margin.Cursor = MarginCursor.Arrow;

            var marker = editor.Markers[BOOKMARK_MARKER];
            marker.Symbol = MarkerSymbol.Circle;
            marker.SetBackColor(IntToColor(0xFF003B));
            marker.SetForeColor(IntToColor(0x000000));
            marker.SetAlpha(100);

        }

        private static void InitCodeFolding(Scintilla editor)
        {

            editor.SetFoldMarginColor(true, IntToColor(BACK_COLOR));
            editor.SetFoldMarginHighlightColor(true, IntToColor(BACK_COLOR));

            // Enable code folding
            editor.SetProperty("fold", "1");
            editor.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            editor.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            editor.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;
            editor.Margins[FOLDING_MARGIN].Sensitive = true;
            editor.Margins[FOLDING_MARGIN].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                editor.Markers[i].SetForeColor(IntToColor(BACK_COLOR)); // styles for [+] and [-]
                editor.Markers[i].SetBackColor(IntToColor(FORE_COLOR)); // styles for [+] and [-]
            }

            // Configure folding markers with respective symbols
            editor.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            editor.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            editor.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            editor.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            editor.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
            editor.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            editor.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            editor.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

        }
    }
}
