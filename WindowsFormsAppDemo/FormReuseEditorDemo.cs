using CDS.CSharpScripting;
using System;
using System.Windows.Forms;

namespace WindowsFormsAppDemo
{
    /// <summary>
    /// This demonstrates how to 'park' an unused script editor on a spare form;
    /// a workaround example for apps that need to create/drop/create/drop/...
    /// a script editor several times, each of which will leak quite a lot of
    /// memory (in this release at least!)
    /// </summary>
    public partial class FormReuseEditorDemo : Form
    {
        /// <summary>
        /// A static code editor; created the first time the form is loaded, 
        /// then cached when the form closes, ready to be reused if the form
        /// is loaded again.
        /// </summary>
        private static CodeEditor csharpEditor;


        /// <summary>
        /// A form used only to 'park' (or store) a code editor once this form
        /// has been closed.
        /// </summary>
        private static Form parkingForm = new Form();

 
        /// <summary>
        /// Initialise
        /// </summary>
        public FormReuseEditorDemo()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Initialise at load-time
        /// </summary>
        private void FormReuseEditorDemo_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            bool isFirstUse = CreateCodeEditorFirstTimeOnly();
            this.tableLayoutPanel1.Controls.Add(csharpEditor, 0, 1);
            InitialiseCodeEditorFirstTimeOnly(isFirstUse);
            SetDefaultScript();

            Cursor = Cursors.Default;
        }


        /// <summary>
        /// Sets the default script on the editor
        /// </summary>
        private static void SetDefaultScript()
        {
            csharpEditor.CDSScript = "Console.WriteLine(\"Hello world!\");";
        }


        /// <summary>
        /// Initialise the code editor once only
        /// </summary>
        private static void InitialiseCodeEditorFirstTimeOnly(bool isFirstUse)
        {
            if (!isFirstUse) { return; }

            csharpEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            csharpEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            csharpEditor.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            csharpEditor.Location = new System.Drawing.Point(6, 26);
            csharpEditor.Margin = new System.Windows.Forms.Padding(6);
            csharpEditor.Name = "csharpEditor";
            csharpEditor.Size = new System.Drawing.Size(764, 156);
            csharpEditor.TabIndex = 3;
            csharpEditor.CDSInitialize();
        }


        /// <summary>
        /// Creates the code editor if it hasn't previously been created and 
        /// parked in our parking form
        /// </summary>
        private static bool CreateCodeEditorFirstTimeOnly()
        {
            var isFirstUse = false;

            if (csharpEditor == null)
            {
                isFirstUse = true;
                csharpEditor = new CodeEditor();
            }

            return isFirstUse;
        }


        /// <summary>
        /// Form is closing; 'park' the code editor
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(csharpEditor);
            csharpEditor.Parent = parkingForm;
            base.OnFormClosing(e);
        }


        /// <summary>
        /// Run the script
        /// </summary>
        private void btnRun_Click(object sender, EventArgs e)
        {
            ClearOutput();
            var compiledScript = CompileScript();
            RunScript(compiledScript);
        }


        /// <summary>
        /// Clear the output
        /// </summary>
        private void ClearOutput()
        {
            compilationOutput.CDSClear();
            runtimeOutput.CDSClear();
        }


        /// <summary>
        /// Compile the script
        /// </summary>
        private CompiledScript CompileScript()
        {
            compilationOutput.CDSWriteLine("* Compiling *");
            var compiledScript = ScriptCompiler.Compile(script: csharpEditor.CDSScript);
            Common.DisplayCompilationOutput(compilationOutput, compiledScript);
            compilationOutput.CDSWriteLine("* Compilation done *");
            return compiledScript;
        }


        /// <summary>
        /// Run the script
        /// </summary>
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
    }
}
