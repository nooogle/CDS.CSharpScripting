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
    public partial class FormScin2 : Form
    {
        CDS.CSharpScripting.Server.CodeCompletion codeCompletion;

        public FormScin2()
        {
            InitializeComponent();
        }

        private async void editor_TextChanged(object sender, EventArgs e)
        {
            var text = editor.CDSScript;
            var caretPosition = editor.CDSSelectionStart;
            editor.X();
            textInfo.Clear();
            textInfo.Text = "Thinking...";

            try
            {
                var bad_bad_bad = new CancellationTokenSource();
                var completions = await codeCompletion.Test(text, caretPosition, bad_bad_bad.Token);

                textInfo.Text =
                    DateTime.Now.ToLongTimeString() +
                    Environment.NewLine +
                    string.Join(Environment.NewLine, completions.Select(c => c.Item));
            }
            catch (Exception exception)
            {
                textInfo.Text = exception.ToString();
            }


            editor.X();
        }


        private void FormScin2_Load(object sender, EventArgs e)
        {
            codeCompletion = new CDS.CSharpScripting.Server.CodeCompletion();
        }
    }
}

// bring in item description and type (e.g. filter away auto-completes???)
