using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDemo.Prototyping
{
    public partial class FormScin1 : Form
    {
        CDS.CSharpScripting.Server.CodeCompletion codeCompletion;

        public FormScin1()
        {
            InitializeComponent();
        }

        private async void editor_TextChanged(object sender, EventArgs e)
        {
            var text = editor.Text;
            var caretPosition = editor.SelectionStart;
            textInfo.Clear();
            textInfo.Text = "Thinking...";

            var bad_bad_bad = new CancellationTokenSource();
            var completions = await codeCompletion.GetCompletions(text, caretPosition, bad_bad_bad.Token);

            textInfo.Text =
                DateTime.Now.ToLongTimeString() +
                Environment.NewLine +
                string.Join(Environment.NewLine, completions.Select(c => c.Item));
        }


        private void FormScin1_Load(object sender, EventArgs e)
        {
            codeCompletion = new CDS.CSharpScripting.Server.CodeCompletion();
        }
    }
}

// bring in item description and type (e.g. filter away auto-completes???)
