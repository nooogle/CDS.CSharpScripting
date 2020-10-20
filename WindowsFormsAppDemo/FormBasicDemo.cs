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
            csharpEditor.CDSInitialize();
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
            var compiledScript = ScriptCompiler.Compile(script: csharpEditor.CDSScript);
            Common.DisplayCompilationOutput(compilationOutput, compiledScript);
            compilationOutput.CDSWriteLine("* Compilation done *");
            return compiledScript;
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
                    Common.SendExceptionToOutput(
                        runtimeOutput,
                        "Exception caught while running the script",
                        exception);
                }
            }

            runtimeOutput.CDSWriteLine("* Script run complete *");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
