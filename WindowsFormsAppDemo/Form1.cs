using CDS.RoslynPadScripting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDemo
{
    public partial class Form1 : Form
    {
        public class Globals
        {
            public string Animal { get; set; } = "Dog";
        }


        Globals globals = new Globals();


        public Form1()
        {
            InitializeComponent();
        }


        Type[] GetReferenceTypes()
        {
            List<Type> types = new List<Type>();

            if (checkNamespaceSystem.Checked)
            {
                types.Add(typeof(System.Console));
            }

            if(checkNamespaceLinq.Checked)
            {
                types.Add(typeof(System.Linq.Enumerable));
            }

            return types.ToArray();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            outputWindow.Clear();
            CompileScript();
        }

        private CDS.RoslynPadScripting.CompiledScript CompileScript()
        {
            outputWindow.WriteLine("Compiling...");

            CompiledScript compiledScript;

            if (checkRequireStringListResultType.Checked)
            {
                compiledScript = ScriptingUtils.CompileCSharpScript<List<string>>(
                    script: csharpEditorWindow.Text,
                    scriptReferences: GetReferenceTypes(),
                    assemblyReferences: GetReferenceTypes(),
                    typeOfGlobals: typeof(Globals),
                    displayDiagnosticsLine: (msg) => outputWindow.WriteLine(msg));
            }
            else
            {
                compiledScript = ScriptingUtils.CompileCSharpScript<object>(
                    script: csharpEditorWindow.Text,
                    scriptReferences: GetReferenceTypes(),
                    assemblyReferences: GetReferenceTypes(),
                    typeOfGlobals: typeof(Globals),
                    displayDiagnosticsLine: (msg) => outputWindow.WriteLine(msg));
            }

            outputWindow.WriteLine("... compiled");

            return compiledScript;
        }


        private void btnRun_Click(object sender, EventArgs e)
        {
            RunScript();
        }


        private object RunScript()
        {
            object resultAsObject = null;

            try
            {
                outputWindow.Clear();
                var compiledScript = CompileScript();

                outputWindow.WriteLine("Running...");

                if (checkRequireStringListResultType.Checked)
                {
                    var result = ScriptingUtils.RunCompiledScript<List<string>>(
                        compiledScript: compiledScript,
                        globals: globals,
                        onTextOutput: (text) => outputWindow.Write(text));

                    resultAsObject = result;

                    if (result == null)
                    {
                        outputWindow.WriteLine($"Result (List<string> type) = null");
                    }
                    else
                    {
                        outputWindow.WriteLine($"Result (List<string> type) contains {result.Count} items");
                        foreach (var item in result)
                        {
                            outputWindow.WriteLine($"Item: {item}");
                        }
                    }
                }
                else
                {
                    resultAsObject = ScriptingUtils.RunCompiledScript<object>(
                        compiledScript: compiledScript,
                        globals: globals,
                        onTextOutput: (text) => outputWindow.Write(text));

                    outputWindow.WriteLine($"Result (object type) = [{resultAsObject}]");
                }

                outputWindow.WriteLine("... run complete");
            }
            catch (Exception exception)
            {
                outputWindow.WriteLine("Exception caught while running the script");
                outputWindow.WriteLine("");
                outputWindow.WriteLine(exception.Message);
            }

            return resultAsObject;
        }

        private void btnDemo1_Click(object sender, EventArgs e)
        {
            var script = string.Join(
                Environment.NewLine,
                "using System;",
                "Console.WriteLine(\"Hello world\");");

            RunDemo(script);
        }


        private void btnDemo2_Click(object sender, EventArgs e)
        {
            var script = string.Join(
                Environment.NewLine,
                "Console.WriteLine(\"Hello world\");");

            RunDemo(script);
        }


        private object RunDemo(string script)
        {
            csharpEditorWindow.Text = script;            
            var result = RunScript();
            return result;
        }


        private void btnInitialise_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            csharpEditorWindow.CDSInitialize(
                referenceTypes: GetReferenceTypes(),
                globalsType: typeof(Globals));

            panelSetupControls.Enabled = false;
            panelLiveControls.Enabled = true;

            this.Cursor = Cursors.Default;
        }

        private void btnUninitialise_Click(object sender, EventArgs e)
        {
            csharpEditorWindow.CDSUninitialise();

            panelLiveControls.Enabled = false;
            panelSetupControls.Enabled = true;
        }

        private void btnDemo3_Click(object sender, EventArgs e)
        {
            var script = string.Join(
                Environment.NewLine,
                "var info = new[] { \"A\", \"B\", \"C\" };",
                "return info.ToList();");

            var result = RunDemo(script) as List<string>;

            if(result == null)
            {
                MessageBox.Show("The test did NOT return a list of strings");
            }
            else
            {
                MessageBox.Show($"The test returned a list of [{result.Count}] strings :-)");
            }

            
        }
    }
}
