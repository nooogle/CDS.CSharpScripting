using System;
using System.IO;
using System.Text;


namespace CDS.RoslynPadScripting
{
    /// <summary>
    /// Set an instance of this as the Console output (Console.SetOut) to hook
    /// Console.Write/WriteLine calls. Use the events to capture the written text.
    /// </summary>
    class ConsoleOutputHooker : TextWriter
    {
        public event Action<string> OnWriteLine;
        public event Action<string> OnWrite;


        public override void WriteLine(string value)
        {
            OnWriteLine?.Invoke(value);
            base.WriteLine(value);
        }


        public override void Write(string value)
        {
            OnWrite?.Invoke(value);
            base.Write(value);
        }


        public override Encoding Encoding
        {
            get { return Encoding.Unicode; }
        }
    }
}
