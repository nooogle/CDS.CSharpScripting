using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDemo
{
    public partial class FormAysncWithCancelScriptDemo : Form
    {
        public class ScriptGlobals
        {
            public bool shouldQuit { get; set; }
        }


        bool isScriptRunning;
        ScriptGlobals scriptGlobals = new ScriptGlobals();
        CDS.CSharpScripting.CompiledScript compiledScript;


        public FormAysncWithCancelScriptDemo()
        {
            InitializeComponent();
        }


        private void FormAysncWithCancelScriptDemo_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            csharpEditor.CDSInitialize(globalsType: typeof(ScriptGlobals));
            Cursor = Cursors.Default;
        }


        private void btnCompile_Click(object sender, EventArgs e)
        {
            if (isScriptRunning)
            {
                output.CDSWriteLine("*** Script is running! ***");
            }
            else
            {
                output.CDSClear();
                CompileScript();
            }
        }


        private async void btnRunAsync_Click(object sender, EventArgs e)
        {
            if (isScriptRunning)
            {
                output.CDSWriteLine("*** Script is already running! ***");
            }
            else
            {
                output.CDSClear();

                if (compiledScript == null)
                {
                    CompileScript();
                }

                await RunScript();
            }
        }


        private void CompileScript()
        {
            output.CDSWriteLine("* Compiling *");

            compiledScript = CDS.CSharpScripting.ScriptCompiler.Compile<List<string>>(
                script: csharpEditor.CDSScript,
                typeOfGlobals: typeof(ScriptGlobals));

            Common.DisplayCompilationOutput(output, compiledScript);

            output.CDSWriteLine("* Compilation done *");
        }


        private async Task<object> RunScript()
        {
            object result = null;

            output.CDSWriteLine("* Running script *");

            using (var console = new CDS.CSharpScripting.ConsoleOutputHook(msg => output.CDSWrite(msg)))
            {

                try
                {
                    isScriptRunning = true;
                    scriptGlobals.shouldQuit = false;
                    csharpEditor.Cursor = Cursors.WaitCursor;
                    csharpEditor.Enabled = false;

                    result = await CDS.CSharpScripting.ScriptRunner.AsyncRun<object>(compiledScript: compiledScript, scriptGlobals);

                    csharpEditor.Enabled = true;
                    csharpEditor.Cursor = Cursors.Default;
                    isScriptRunning = false;

                    output.CDSWriteLine($"* Script run is complete *");
                }
                catch (Exception exception)
                {
                    Common.SendExceptionToOutput(
                        output,
                        "Exception caught while running the script",
                        exception);
                }
            }

            return result;
        }


        private void csharpEditor_CDSScriptChanged(object sender, EventArgs e)
        {
            compiledScript = null;
        }

        private void btnStopScript_Click(object sender, EventArgs e)
        {
            if (!isScriptRunning)
            {
                output.CDSWriteLine("*** Script isn't runing! ***");
            }
            else
            {
                output.CDSWriteLine("*** Signalling script to stop asap ***");
                scriptGlobals.shouldQuit = true;
            }
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isScriptRunning)
            {
                output.CDSWriteLine("*** Cannot close form, script running ***");
                e.Cancel = true;
            }

            base.OnFormClosing(e);
        }
    }
}
