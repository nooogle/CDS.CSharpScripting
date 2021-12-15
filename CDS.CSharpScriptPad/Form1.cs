using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDS.CSharpScriptPad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            codeEditor.CDSInitialize();
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

        }

        private void menuScriptCompile_Click(object sender, EventArgs e)
        {

        }

        private void menuScriptRun_Click(object sender, EventArgs e)
        {

        }
    }
}
