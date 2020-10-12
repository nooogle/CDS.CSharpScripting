using System;
using System.IO;
using System.Text;


namespace CDS.RoslynPadScripting
{
    /// <summary>
    /// Hooks the console output and redirects strings to a client-supplied
    /// handler.
    /// </summary>
    public class ConsoleOutputHook : TextWriter, IDisposable
    {
        private Action<string> writeString;
        private TextWriter defaultConsoleOut;


        public ConsoleOutputHook(Action<string> writeString)
        {
            this.writeString = writeString;
            defaultConsoleOut = Console.Out;
            Console.SetOut(this);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Console.SetOut(defaultConsoleOut);
            }

            base.Dispose(disposing);
        }


        public override void Write(char value)
        {
            writeString(value.ToString());
        }

        public override void Write(string value)
        {
            writeString(value);
        }


        public override void Write(char[] buffer, int index, int count)
        {
            writeString(new string(buffer, index, count));
        }


        /// <inheritdoc/>
        public override Encoding Encoding
        {
            get { return Encoding.Unicode; }
        }
    }
}
