using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsAppDemo
{
    public partial class FormGlobalsDemo : Form
    {
        public class Globals
        {
            /// <summary>
            /// An animal - this is XML documentation for the script !!!
            /// </summary>
            public string Animal { get; set; } = "Tiger";
        }


        private Globals globals = new Globals();


        public FormGlobalsDemo()
        {
            InitializeComponent();
        }


        private void FormGlobalsDemo_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            csharpEditorWindow.CDSInitialize(globalsType: typeof(Globals));

            csharpEditorWindow.Text = string.Join(
                Environment.NewLine,
                "// The public methods and properties of the Global class instance are",
                "// directly available in this script",
                "Console.WriteLine(Animal);",
                "Animal = \"Shark\";",
                "Console.WriteLine(Animal);");

            Cursor = Cursors.Default;
        }


        private void btnRun_Click(object sender, EventArgs e)
        {
            PrepareToCompileAndRun();
            var compiledScript = CompileScript();
            RunScript(compiledScript);
        }


        private void PrepareToCompileAndRun()
        {
            compilationOutput.CDSClear();
            runtimeOutput.CDSClear();
        }


        private CDS.CSharpScripting.CompiledScript CompileScript()
        {
            compilationOutput.CDSWriteLine("* Compiling *");

            var compiledScript = CDS.CSharpScripting.ScriptCompiler.Compile<List<string>>(
                script: csharpEditorWindow.Text,
                typeOfGlobals: typeof(Globals));

            DisplayCompilationOutput(compiledScript);

            compilationOutput.CDSWriteLine("* Compilation done *");

            return compiledScript;
        }


        private void DisplayCompilationOutput(CDS.CSharpScripting.CompiledScript compiledScript)
        {
            compilationOutput.CDSWriteLine(
                $"{compiledScript.CompilationOutput.ErrorCount} error(s), " +
                $"{compiledScript.CompilationOutput.WarningCount} warning(s)");

            foreach (var message in compiledScript.CompilationOutput.Messages)
            {
                compilationOutput.CDSWriteLine(message);
            }
        }


        private void RunScript(CDS.CSharpScripting.CompiledScript compiledScript)
        {
            runtimeOutput.CDSWriteLine("* Running script *");

            using (var console = new CDS.CSharpScripting.ConsoleOutputHook(msg => runtimeOutput.CDSWrite(msg)))
            {

                try
                {
                    CDS.CSharpScripting.ScriptRunner.Run(
                        compiledScript: compiledScript,
                        globals: globals);

                    runtimeOutput.CDSWriteLine($"* Script run is complete: the new value of Animal is [{globals.Animal}] *");
                }
                catch (Exception exception)
                {
                    runtimeOutput.CDSWriteLine("");
                    runtimeOutput.CDSWriteLine("Exception caught while running the script");
                    runtimeOutput.CDSWriteLine("");
                    runtimeOutput.CDSWriteLine(exception.Message);
                }
            }
        }
    }
}
