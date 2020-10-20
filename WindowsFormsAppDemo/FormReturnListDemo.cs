using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsAppDemo
{
    public partial class FormReturnListDemo : Form
    {
        public FormReturnListDemo()
        {
            InitializeComponent();
        }


        private void FormReturnListDemo_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            csharpEditor.CDSInitialize();
            Cursor = Cursors.Default;
        }


        private void btnRun_Click(object sender, EventArgs e)
        {
            PrepareToCompileAndRun();
            var compiledScript = CompileScript();
            var result = RunScript(compiledScript);
            DisplayResult(result);
        }


        private void DisplayResult(List<string> result)
        {
            var msg = new StringBuilder();

            if (result == null)
            {
                msg.Append("Expected to get a list of strings but got a null object instead :-(");
            }
            else
            {
                msg.Append($"Got a list of strings back from the script...{Environment.NewLine}");
                for(int index = 0; index < result.Count; index++)
                {
                    msg.Append($"{index}: {result[index]}{Environment.NewLine}");
                }
            }

            MessageBox.Show(
                owner: this,
                text: msg.ToString(),
                caption: Application.ProductName,
                buttons: MessageBoxButtons.OK,
                icon: MessageBoxIcon.Information);
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
                script: csharpEditor.CDSScript,
                typeOfGlobals: null);


            Common.DisplayCompilationOutput(compilationOutput, compiledScript);

            compilationOutput.CDSWriteLine("* Compilation done *");

            return compiledScript;
        }


        private List<string> RunScript(CDS.CSharpScripting.CompiledScript compiledScript)
        {
            List<string> result = null;
            runtimeOutput.CDSWriteLine("* Running script *");

            using (var console = new CDS.CSharpScripting.ConsoleOutputHook(msg => runtimeOutput.CDSWrite(msg)))
            {

                try
                {
                    result = CDS.CSharpScripting.ScriptRunner.Run<List<string>>(
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

            return result;
        }
    }
}
