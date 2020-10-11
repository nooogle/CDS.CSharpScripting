using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDemo
{
    public partial class FormBasicDemo : Form
    {
        Type[] defaultReferenceTypes = new[] { typeof(int) };
        Type[] defaultNamespaceTypes = new[] { typeof(int) };


        public FormBasicDemo()
        {
            InitializeComponent();
        }


        private void FormBasicDemo_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            csharpEditorWindow.CDSInitialize(
                namespaceTypes: defaultNamespaceTypes,
                referenceTypes: defaultReferenceTypes,
                globalsType: null);

            csharpEditorWindow.Text = "Console.WriteLine(\"Hello world!\");";
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


        private CDS.RoslynPadScripting.CompiledScript CompileScript()
        {
            compilationOutput.CDSWriteLine("* Compiling *");

            var compiledScript = CDS.RoslynPadScripting.ScriptingUtils.CompileCSharpScript<object>(
                script: csharpEditorWindow.Text,
                namespaceTypes: defaultNamespaceTypes,
                referenceTypes: defaultReferenceTypes,
                typeOfGlobals: null,
                displayDiagnosticsLine: (msg) => compilationOutput.CDSWriteLine(msg));

            compilationOutput.CDSWriteLine("* Compilation done *");

            return compiledScript;
        }


        private void RunScript(CDS.RoslynPadScripting.CompiledScript compiledScript)
        {
            runtimeOutput.CDSWriteLine("* Running script *");

            try
            {
                CDS.RoslynPadScripting.ScriptingUtils.RunCompiledScript(
                    compiledScript: compiledScript,
                    globals: null,
                    onTextOutput: (msg) => runtimeOutput.CDSWrite(msg));
            }
            catch (Exception exception)
            {
                runtimeOutput.CDSWriteLine("");
                runtimeOutput.CDSWriteLine("Exception caught while running the script");
                runtimeOutput.CDSWriteLine("");
                runtimeOutput.CDSWriteLine(exception.Message);
            }

            runtimeOutput.CDSWriteLine("* Script run complete *");
        }
    }
}
