using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsAppDemo
{
    public partial class FormReturnListDemo : Form
    {
        Type[] defaultReferenceTypes = new[] 
        { 
            typeof(int), // mscorlib
            typeof(System.Linq.Enumerable), // System.Core
        };
        

        Type[] defaultNamespaceTypes = new[] 
        { 
            typeof(int), // using System
            typeof(System.Collections.Generic.List<int>), // using System.Collections.Generic
            typeof(System.Linq.Enumerable), // using System.Linq
        };


        public FormReturnListDemo()
        {
            InitializeComponent();
        }


        private void FormReturnListDemo_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            csharpEditorWindow.CDSInitialize(
                namespaceTypes: defaultNamespaceTypes,
                referenceTypes: defaultReferenceTypes,
                globalsType: null);

            csharpEditorWindow.Text = string.Join(
                Environment.NewLine,
                "// using clauses and references are not required; this demo programatically",
                "// configured both the editor and script compiler with the appropriate types",
                "var myList = new[] { \"A\", \"B\" }.ToList();",
                "return myList;");

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


        private CDS.RoslynPadScripting.CompiledScript CompileScript()
        {
            compilationOutput.CDSWriteLine("* Compiling *");

            var compiledScript = CDS.RoslynPadScripting.ScriptCompiler.Compile<List<string>>(
                script: csharpEditorWindow.Text,
                namespaceTypes: defaultNamespaceTypes,
                referenceTypes: defaultReferenceTypes,
                typeOfGlobals: null,
                displayDiagnosticsLine: (msg) => compilationOutput.CDSWriteLine(msg));

            compilationOutput.CDSWriteLine("* Compilation done *");

            return compiledScript;
        }


        private List<string> RunScript(CDS.RoslynPadScripting.CompiledScript compiledScript)
        {
            List<string> result = null;
            runtimeOutput.CDSWriteLine("* Running script *");

            using (var console = new CDS.RoslynPadScripting.ConsoleOutputHook(msg => runtimeOutput.CDSWrite(msg)))
            {

                try
                {
                    result = CDS.RoslynPadScripting.ScriptRunner.Run<List<string>>(
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

            return result;
        }
    }
}
