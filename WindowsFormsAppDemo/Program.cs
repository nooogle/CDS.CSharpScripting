using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
            static void Main()
            {
                HookThreadExceptions();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }



        /// <summary>
        /// At the time of writing, using RoslynPad 3.6.0, there are occasional WinForms 
        /// thread exceptions - these are (probably) thrown when an activity is attempted
        /// on the wrong thread. For now, all we can do is send the exception to the 
        /// debug output.
        /// </summary>
        private static void HookThreadExceptions()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, true);
            Application.ThreadException += Application_ThreadException;
        }


        /// <summary>
        /// Send otherwise-unhandled thread exceptions details to the debug output.
        /// 
        /// (See <see cref="HookThreadExceptions"/> for details of why we do this.)
        /// </summary>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (new[] { "RoslynPad", "AvalonEdit" }.Any(lib => e.Exception.StackTrace.Contains(lib)))
            {
                System.Diagnostics.Debug.WriteLine(
                    $"Caught a WinForms thread exception, possibly due to a " +
                    $"problem in RoslynPad or dependent library.");

                System.Diagnostics.Debug.WriteLine($"Exception message: {e.Exception.Message}");
                System.Diagnostics.Debug.WriteLine($"Exception stack trace: {e.Exception.StackTrace}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"Caught a WinForms thread exception, unknown reason.");
            }
        }
    }
}


 