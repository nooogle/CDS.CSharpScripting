using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDemo.Prototyping
{
    public partial class FormScin2 : Form
    {
        CDS.CSharpScripting.EditorServices.ScriptEnv codeCompletion;


        async Task<IEnumerable<string>> TestGetAutoCompleteWords(CancellationToken cancellationToken)
        {
            return await Task<IEnumerable<string>>.Run(() =>
            {
                var items = new[] { "fish", "chips" };
                return items;
            });
        }


        public FormScin2()
        {
            InitializeComponent();
        }

        private async void editor_TextChanged(object sender, EventArgs e)
        {
            return;
            var text = editor.CDSScript;
            var caretPosition = editor.CDSSelectionStart;
            editor.X();
            textInfo.Clear();
            textInfo.Text = "Thinking...";

            try
            {
                var bad_bad_bad = new CancellationTokenSource();
                var completions = await codeCompletion.GetCompletions(text, caretPosition, bad_bad_bad.Token);

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

        async Task<IEnumerable<string>> GetAutoCompletions(CancellationToken cancellationToken)
        {
            var completions = await codeCompletion.GetCompletions(
                    script: editor.CDSScript,
                    caretPosition: editor.CDSSelectionStart,
                    cancellationToken: cancellationToken);

            return completions.Select(c => c.Item);
        }


        private void FormScin2_Load(object sender, EventArgs e)
        {
        Type[] namespaceTypes = new[]
        {
            typeof(int), // using System;
        };


        Type[] referenceTypes = new[]
        {
            typeof(int), // mscorlib.dll
            typeof(System.Drawing.Point), // System.Drawing.dll
        };

            codeCompletion = new CDS.CSharpScripting.EditorServices.ScriptEnv(
                namespaceTypes: namespaceTypes,
                additionalAssemblies: referenceTypes.Select(r => r.Assembly),
                typeOfGlobals: null);

            editor.GetAutoCompleteList = GetAutoCompletions;
        }
    }
}

// bring in item description and type (e.g. filter away auto-completes???)
