using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDS.CSharpScripting
{
    /// <summary>
    /// Simple Scintilla-based window for displayed read-only output text.
    /// </summary>
    public partial class OutputPanel : UserControl
    {
        /// <summary>
        /// Initialise
        /// </summary>
        public OutputPanel()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Clear the text
        /// </summary>
        public void CDSClear()
        {
            textBox.Clear();
        }


        /// <summary>
        /// Clear the text
        /// </summary>
        public void CDSWrite(string text)
        {
            textBox.AppendText(text);
        }


        /// <summary>
        /// Write text and append a carriage return
        /// </summary>
        public void CDSWriteLine(string text)
        {
            textBox.AppendText(text);
            textBox.AppendText(Environment.NewLine);
        }
    }
}
