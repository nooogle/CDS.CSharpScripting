using CDS.CSharpScripting;
using System;
using System.Windows.Forms;

namespace WindowsFormsAppDemo
{
    public partial class FormBasicDemo : Form
    {
        public FormBasicDemo()
        {
            InitializeComponent();
        }


        private void FormBasicDemo_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            csharpEditorWindow.CDSInitialize();
            csharpEditorWindow.Text = "Console.WriteLine(\"Hello world!\");";

            Cursor = Cursors.Default;
        }


        private void btnRun_Click(object sender, EventArgs e)
        {
            ClearOutput();
            var compiledScript = CompileScript();
            RunScript(compiledScript);
        }


        private void ClearOutput()
        {
            compilationOutput.CDSClear();
            runtimeOutput.CDSClear();
        }


        private CompiledScript CompileScript()
        {
            compilationOutput.CDSWriteLine("* Compiling *");
            var compiledScript = ScriptCompiler.Compile(script: csharpEditorWindow.Text);
            DisplayCompilationOutput(compiledScript);
            compilationOutput.CDSWriteLine("* Compilation done *");
            return compiledScript;
        }


        private void DisplayCompilationOutput(CompiledScript compiledScript)
        {
            compilationOutput.CDSWriteLine(
                $"{compiledScript.CompilationOutput.ErrorCount} error(s), " +
                $"{compiledScript.CompilationOutput.WarningCount} warning(s)");

            foreach (var message in compiledScript.CompilationOutput.Messages)
            {
                compilationOutput.CDSWriteLine(message);
            }
        }


        private void RunScript(CompiledScript compiledScript)
        {
            runtimeOutput.CDSWriteLine("* Running script *");

            using (var console = new ConsoleOutputHook(msg => runtimeOutput.CDSWrite(msg)))
            {
                try
                {
                    ScriptRunner.Run(
                        compiledScript: compiledScript,
                        globals: null);
                }
                catch (Exception exception)
                {
                    runtimeOutput.CDSWriteLine("");
                    runtimeOutput.CDSWriteLine("Exception caught while running the script");
                    runtimeOutput.CDSWriteLine("");
                    runtimeOutput.CDSWriteLine(exception.Message);
                }
            }

            runtimeOutput.CDSWriteLine("* Script run complete *");
        }
    }
}
