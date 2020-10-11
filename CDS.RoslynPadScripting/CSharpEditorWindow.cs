using ICSharpCode.AvalonEdit.Highlighting;
using RoslynPad.Editor;
using RoslynPad.Roslyn;
using System;
using System.Collections.Generic;
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


        /// <summary>
        /// Initialise: hides the 'not initialised' message then creates, configures
        /// and shows a Roslyn code editor.
        /// </summary>
        /// <param name="referenceTypes">
        /// The assembly for each type in this list is referenced by the editor session.
        /// Added, for example, typeof(int), will result in the core framework library 
        /// (mscorlib) being loaded.
        /// </param>
        /// <param name="namespaceTypes">
        /// The namespace for each type is made automatically available for each type in
        /// this list. E.g. sending typeof(int) will make the System namespace available; 
        /// it's the equivalet of adding 'using System' to the top of the script.
        /// </param>
        /// <param name="globalsType">
        /// Optional (can be null): the type of a global variable made available to the
        /// script without any other namespace resolution. 
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if either of <paramref name="referenceTypes"/> or <paramref name="namespaceTypes"/>
        /// is null.
        /// </exception>
        public void CDSInitialize(
            IEnumerable<Type> namespaceTypes,
            IEnumerable<Type> referenceTypes,
            Type globalsType)
        {
            CDSUninitialise();

            if (namespaceTypes == null) { throw new ArgumentNullException(nameof(namespaceTypes)); }
            if (referenceTypes == null) { throw new ArgumentNullException(nameof(referenceTypes)); }


            var referenceTypesIncludingGlobalsType = GenerateAllReferenceTypes(referenceTypes, globalsType);
            var namespaceTypesIncludingGlobalsType = GenerateAllNamespaceTypes(namespaceTypes, globalsType);

            var roslynHost = CreateRosylnHost(
                globalsType,
                referenceTypesIncludingGlobalsType,
                namespaceTypesIncludingGlobalsType);

            CreateNewEditor(roslynHost);

            isInitialised = true;
        }


        private void CreateNewEditor(CustomRoslynHost roslynHost)
        {
            editor = new RoslynCodeEditor();
            var workingDirectory = Directory.GetCurrentDirectory();

            editor.Initialize(
                roslynHost: roslynHost,
                highlightColors: new ClassificationHighlightColors(),
                workingDirectory: workingDirectory,
                documentText: "");

            editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");
            editor.FontFamily = new System.Windows.Media.FontFamily(this.Font.FontFamily.Name);
            editor.FontSize = this.Font.Size;
            editor.TextChanged += Editor_TextChanged;
            wpfEditorHost.Dock = DockStyle.Fill;
            wpfEditorHost.Visible = true;
            labelNotInitialisedMsg.Visible = false;
            wpfEditorHost.Child = editor;
        }


        private static CustomRoslynHost CreateRosylnHost(Type globalsType, List<Assembly> referenceTypesIncludingGlobalsType, List<Type> namespaceTypesIncludingGlobalsType)
        {
            var namespaceImports =
                RoslynHostReferences
                .Empty
                .With(assemblyReferences: referenceTypesIncludingGlobalsType)
                .With(typeNamespaceImports: namespaceTypesIncludingGlobalsType);


            var roslynHost = new CustomRoslynHost(
                globalsType: globalsType,
                additionalAssemblies: new[]
                {
                    Assembly.Load("RoslynPad.Roslyn.Windows"),
                    Assembly.Load("RoslynPad.Editor.Windows"),
                },
                references: namespaceImports);
            return roslynHost;
        }


        private static List<Type> GenerateAllNamespaceTypes(IEnumerable<Type> namespaceTypes, Type globalsType)
        {
            List<Type> namespaceTypesIncludingGlobalsType = new List<Type>(namespaceTypes);

            if (globalsType != null)
            {
                namespaceTypesIncludingGlobalsType.Append(globalsType);
            }

            return namespaceTypesIncludingGlobalsType;
        }


        private static List<Assembly> GenerateAllReferenceTypes(IEnumerable<Type> referenceTypes, Type globalsType)
        {
            List<Assembly> referenceTypesIncludingGlobalsType = referenceTypes.Select(rt => rt.Assembly).ToList();

            if (globalsType != null)
            {
                referenceTypesIncludingGlobalsType.Append(globalsType.Assembly);
            }

            return referenceTypesIncludingGlobalsType;
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
