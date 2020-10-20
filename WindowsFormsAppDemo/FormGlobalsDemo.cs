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
            csharpEditor.CDSInitialize(globalsType: typeof(Globals));
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
                script: csharpEditor.CDSScript,
                typeOfGlobals: typeof(Globals));

            Common.DisplayCompilationOutput(compilationOutput, compiledScript);

            compilationOutput.CDSWriteLine("* Compilation done *");

            return compiledScript;
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
                    Common.SendExceptionToOutput(
                        runtimeOutput, 
                        "Exception caught while running the script", 
                        exception);
                }
            }
        }
    }
}
