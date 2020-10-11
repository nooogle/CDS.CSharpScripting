using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDS.RoslynPadScripting
{
    /// <summary>
    /// Simple Scintilla-based window for displayed read-only output text.
    /// </summary>
    public partial class OutputWindow : UserControl
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public OutputWindow()
        {
            InitializeComponent();
        }


        private void OutputWindow_Load(object sender, EventArgs e)
        {
            if(DesignMode) { return; }

            ScriptingUtils.ConfigureScintillaEditorAsOutputWindow(scintilla);
        }


        /// <summary>
        /// Clear the text
        /// </summary>
        public void CDSClear()
        {
            PerformTextOperation(() => scintilla.Text = "");            
        }


        /// <summary>
        /// Clear the text
        /// </summary>
        public void CDSWrite(string text)
        {
            PerformTextOperation(() => scintilla.AppendText(text));
        }


        /// <summary>
        /// Write text and append a carriage return
        /// </summary>
        public void CDSWriteLine(string text)
        {
            PerformTextOperation(() => scintilla.AppendText(text + "\n"));
        }


        private void PerformTextOperation(Action action)
        {
            scintilla.ReadOnly = false;
            action();
            scintilla.ReadOnly = true;
            Refresh();
        }
    }
}
