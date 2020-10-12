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

            InitBasics();
            InitColors();
            InitOutputWindowSyntaxColoring();
            scintilla.ReadOnly = true;
        }


        private void InitBasics()
        {
            scintilla.WrapMode = ScintillaNET.WrapMode.None;
            scintilla.IndentationGuides = ScintillaNET.IndentView.LookBoth;
        }


        private void InitColors()
        {
            scintilla.SetSelectionBackColor(true, IntToColor(0x114D9C));
            scintilla.CaretForeColor = System.Drawing.Color.White;

        }


        private void InitOutputWindowSyntaxColoring()
        {
            scintilla.StyleResetDefault();
            scintilla.Styles[ScintillaNET.Style.Default].Font = "Consolas";
            scintilla.Styles[ScintillaNET.Style.Default].Size = 10;
            scintilla.StyleClearAll();
        }


        private static Color IntToColor(int rgb)
        {
            return System.Drawing.Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
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
