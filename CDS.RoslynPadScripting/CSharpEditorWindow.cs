using ICSharpCode.AvalonEdit.Highlighting;
using RoslynPad.Editor;
using RoslynPad.Roslyn;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CDS.RoslynPadScripting
{
    /// <summary>
    /// Editor control for C#, pre-configured with keywords, dark theme, etc.
    /// </summary>
    public partial class CSharpEditorWindow: UserControl
    {
        RoslynCodeEditor editor;
        bool isInitialised;


        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get => isInitialised ? editor.Document.Text : "";

            set
            {
                if (isInitialised)
                {
                    editor.Document.Text = value;
                }
            }
        }


        /// <summary>
        /// Fired when the text changes
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public new event EventHandler TextChanged;


        /// <summary>
        /// Basic initialisation
        /// </summary>
        public CSharpEditorWindow()
        {
            InitializeComponent();
        }


        public void CDSInitialize(Type[] referenceTypes)
        {
            CDSInitialize(referenceTypes: referenceTypes, globalsType: null);
        }


        /// <summary>
        /// Initialise: hides the 'not initialised' message then creates, configures
        /// and shows a Roslyn code editor.
        /// </summary>
        /// <param name="referenceTypes">
        /// A reference is auto-created for each data type in this list
        /// </param>
        /// <param name="globalsType"></param>
        public void CDSInitialize(Type[] referenceTypes, Type globalsType)
        {
            if(isInitialised)
            {
                CDSUninitialise();
            }

            editor = new RoslynCodeEditor();
            var workingDirectory = Directory.GetCurrentDirectory();

            var referenceTypesIncludingGlobalsType = referenceTypes;
            if (globalsType != null)
            {
                var temp = referenceTypes.ToList();
                temp.Add(globalsType);
                referenceTypesIncludingGlobalsType = temp.ToArray();
            }

            var namespaceImports =
                RoslynHostReferences
                .Empty
                .With(assemblyReferences: new[] { typeof(int).Assembly })
                .With(typeNamespaceImports: referenceTypesIncludingGlobalsType);

            var roslynHost = new CustomRoslynHost(
                globalsType: globalsType,
                additionalAssemblies: new[]
                {
                    Assembly.Load("RoslynPad.Roslyn.Windows"),
                    Assembly.Load("RoslynPad.Editor.Windows"),
                },
                references: namespaceImports);

            
            editor.Initialize(
                roslynHost: roslynHost, 
                highlightColors: new ClassificationHighlightColors(), 
                workingDirectory: workingDirectory, 
                documentText: "");

            editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");
            
            editor.FontFamily = new System.Windows.Media.FontFamily(this.Font.FontFamily.Name);
            editor.FontSize = this.Font.Size;

            wpfEditorHost.Child = editor;

            editor.TextChanged += Editor_TextChanged;
            wpfEditorHost.Dock = DockStyle.Fill;
            wpfEditorHost.Visible = true;
            labelNotInitialisedMsg.Visible = false;

            isInitialised = true;
        }


        /// <summary>
        /// Uninitialise: shows the 'not initialised' message and closes down the
        /// Roslyn code editor.
        /// </summary>
        /// <remarks>
        /// Does nothing if not already initialised.
        /// </remarks>
        public void CDSUninitialise()
        {
            if(!isInitialised) { return; }

            labelNotInitialisedMsg.Visible = true;
            wpfEditorHost.Visible = false;

            editor.TextChanged -= Editor_TextChanged;
            wpfEditorHost.Child = null;
            editor = null;

            isInitialised = false;
        }


        /// <summary>
        /// The text has changed - fire up to the owner
        /// </summary>
        private void Editor_TextChanged(object sender, EventArgs e)
        {
            TextChanged?.Invoke(sender, e);
        }
    }
}
