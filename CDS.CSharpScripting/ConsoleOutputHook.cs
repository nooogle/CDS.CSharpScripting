using System;
using System.IO;
using System.Text;


namespace CDS.CSharpScripting
{
    /// <summary>
    /// Hooks the console output and redirects strings to a client-supplied
    /// handler.
    /// </summary>
    public class ConsoleOutputHook : TextWriter, IDisposable
    {
        private Action<string> writeString;
        private TextWriter defaultConsoleOut;


        /// <summary>
        /// Initialise
        /// </summary>
        /// <param name="writeString">Callback to handle a new string</param>
        public ConsoleOutputHook(Action<string> writeString)
        {
            this.writeString = writeString;
            defaultConsoleOut = Console.Out;
            Console.SetOut(this);
        }


        ///<inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Console.SetOut(defaultConsoleOut);
            }

            base.Dispose(disposing);
        }


        ///<inheritdoc/>
        public override void Write(char value)
        {
            writeString(value.ToString());
        }


        ///<inheritdoc/>
        public override void Write(string value)
        {
            writeString(value);
        }


        ///<inheritdoc/>
        public override void Write(char[] buffer, int index, int count)
        {
            writeString(new string(buffer, index, count));
        }


        /// <inheritdoc/>
        public override Encoding Encoding
        {
            // Required overload but not obviously used in this project
            get { return Encoding.Unicode; }
        }
    }
}
