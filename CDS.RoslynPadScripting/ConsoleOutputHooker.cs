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
        public event Action<string> OnWrite;


        public override void Write(char value)
        {
            OnWrite?.Invoke(value.ToString());
        }

        public override void Write(string value)
        {
            OnWrite?.Invoke(value);
        }


        public override void Write(char[] buffer, int index, int count)
        {
            OnWrite?.Invoke(new string(buffer, index, count));
        }


        /// <summary>
        /// TBD why do this???
        /// </summary>
        public override Encoding Encoding
        {
            get { return Encoding.Unicode; }
        }
    }
}
