using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Media;

// This line is criticial for correct scaling and rendering of the combined
// WinForms and WPF controls that make up the CodeEditor. Without this line
// only screens running at 100% scaling will work all of the time!
[assembly: DisableDpiAwareness]

[assembly: AssemblyTitle("WindowsFormsAppDemo")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyProduct("WindowsFormsAppDemo")]
[assembly: ComVisible(false)]
[assembly: Guid("92334fff-56ee-436d-be17-b97d978ed258")]
