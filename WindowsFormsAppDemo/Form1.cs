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
            Type[] types;

            if (checkUseCommonNamespaces.Checked)
            {
                types = new[]
                {
                    typeof(System.Console),
                };
            }
            else
            {
                types = new Type[0];
            }

            return types;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            csharpEditorWindow.Initialize(
                referenceTypes: GetReferenceTypes(),
                globalsType: typeof(Globals));
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            outputWindow1.Clear();
            CompileScript();
        }

        private CDS.RoslynPadScripting.CompiledScript CompileScript()
        {
            outputWindow1.WriteLine("Compiling...");

            CompiledScript compiledScript;

            if (checkRequireStringListResultType.Checked)
            {
                compiledScript = ScriptingUtils.CompileCSharpScript<List<string>>(
                    script: csharpEditorWindow.Text,
                    scriptReferences: GetReferenceTypes(),
                    assemblyReferences: GetReferenceTypes(),
                    typeOfGlobals: typeof(Globals),
                    displayDiagnosticsLine: (msg) => outputWindow1.WriteLine(msg));
            }
            else
            {
                compiledScript = ScriptingUtils.CompileCSharpScript<object>(
                    script: csharpEditorWindow.Text,
                    scriptReferences: GetReferenceTypes(),
                    assemblyReferences: GetReferenceTypes(),
                    typeOfGlobals: typeof(Globals),
                    displayDiagnosticsLine: (msg) => outputWindow1.WriteLine(msg));
            }

            outputWindow1.WriteLine("... compiled");

            return compiledScript;
        }


        private void btnRun_Click(object sender, EventArgs e)
        {
            RunScript();
        }


        private void RunScript()
        {
            try
            {
                outputWindow1.Clear();
                var compiledScript = CompileScript();

                outputWindow1.WriteLine("Running...");

                if (checkRequireStringListResultType.Checked)
                {
                    var result = ScriptingUtils.RunCompiledScript<List<string>>(
                        compiledScript: compiledScript,
                        globals: globals,
                        onTextOutput: (text) => outputWindow1.Write(text));

                    if (result == null)
                    {
                        outputWindow1.WriteLine($"Result (List<string> type) = null");
                    }
                    else
                    {
                        outputWindow1.WriteLine($"Result (List<string> type) contains {result.Count} items");
                        foreach (var item in result)
                        {
                            outputWindow1.WriteLine($"Item: {item}");
                        }
                    }
                }
                else
                {
                    var result = ScriptingUtils.RunCompiledScript<object>(
                        compiledScript: compiledScript,
                        globals: globals,
                        onTextOutput: (text) => outputWindow1.Write(text));

                    outputWindow1.WriteLine($"Result (object type) = [{result}]");
                }

                outputWindow1.WriteLine("... run complete");
            }
            catch (Exception exception)
            {
                outputWindow1.WriteLine("Exception caught while running the script");
                outputWindow1.WriteLine("");
                outputWindow1.WriteLine(exception.Message);
            }
        }

        private void btnDemo1_Click(object sender, EventArgs e)
        {
            var script = string.Join(
                Environment.NewLine,
                "using System;",
                "Console.WriteLine(\"Hello world\");");

            RunDemo(
                requireStringListResultType: false,
                useCommonNamespaces: false,
                script: script);
        }


        private void btnDemo2_Click(object sender, EventArgs e)
        {
            var script = string.Join(
                Environment.NewLine,
                "Console.WriteLine(\"Hello world\");");

            RunDemo(
                requireStringListResultType: false,
                useCommonNamespaces: true,
                script: script);
        }


        private void RunDemo(bool requireStringListResultType, bool useCommonNamespaces, string script)
        {
            checkRequireStringListResultType.Checked = requireStringListResultType;
            checkUseCommonNamespaces.Checked = useCommonNamespaces;
            csharpEditorWindow.Text = script;            
            RunScript();
        }
    }
}
