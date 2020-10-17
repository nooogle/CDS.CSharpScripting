using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsAppDemo
{
    public partial class FormRunManyDemo : Form
    {
        CDS.CSharpScripting.CompiledScript compiledScript;


        public FormRunManyDemo()
        {
            InitializeComponent();
        }


        private void FormCustomDemo_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            csharpEditor.CDSInitialize();
            Cursor = Cursors.Default;
        }


        private void btnCompile_Click(object sender, EventArgs e)
        {
            output.CDSClear();
            CompileScript();
        }


        private void btnRun_Click(object sender, EventArgs e)
        {
            output.CDSClear();

            if(compiledScript == null)
            {
                CompileScript();
            }

            RunScript();
        }


        private void CompileScript()
        {
            output.CDSWriteLine("* Compiling *");

            compiledScript = CDS.CSharpScripting.ScriptCompiler.Compile<List<string>>(
                script: csharpEditor.CDSScript);

            DisplayCompilationOutput();

            output.CDSWriteLine("* Compilation done *");
        }


        private void RunScript()
        {
            output.CDSWriteLine("* Running script *");

            using (var console = new CDS.CSharpScripting.ConsoleOutputHook(msg => output.CDSWrite(msg)))
            {

                try
                {
                    CDS.CSharpScripting.ScriptRunner.Run(compiledScript: compiledScript);

                    output.CDSWriteLine($"* Script run is complete *");
                }
                catch (Exception exception)
                {
                    output.CDSWriteLine("");
                    output.CDSWriteLine("Exception caught while running the script");
                    output.CDSWriteLine("");
                    output.CDSWriteLine(exception.Message);
                }
            }
        }


        private void DisplayCompilationOutput()
        {
            output.CDSWriteLine(
                $"{compiledScript.CompilationOutput.ErrorCount} error(s), " +
                $"{compiledScript.CompilationOutput.WarningCount} warning(s)");

            foreach (var message in compiledScript.CompilationOutput.Messages)
            {
                output.CDSWriteLine(message);
            }
        }


        private void csharpEditor_CDSScriptChanged(object sender, EventArgs e)
        {
            compiledScript = null;
        }
    }
}
