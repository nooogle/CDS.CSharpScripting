using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Media;

// This line is criticial for correct scaling and rendering of the combined
// WinForms and WPF controls that make up the CodeEditor. Without this line
// only screens running at 100% scaling will work all of the time!
[assembly: DisableDpiAwareness]

[assembly: AssemblyTitle("CDS.CSharpScriptPad")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyProduct("CDS.CSharpScriptPad")]
[assembly: ComVisible(false)]
[assembly: Guid("f8fe6e79-8d8e-41bb-97d2-3490c40fd0d6")]
