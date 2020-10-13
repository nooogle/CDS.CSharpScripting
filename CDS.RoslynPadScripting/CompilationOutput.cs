namespace CDS.RoslynPadScripting
{
    /// <summary>
    /// Basic compilation results
    /// </summary>
    public class CompilationOutput
    {
        /// <summary>
        /// Compilation diagnostics
        /// </summary>
        public string[] Messages { get; }


        /// <summary>Number of compilation warnings</summary>
        public int WarningCount { get; }


        /// <summary>Number of compilation errors</summary>
        public int ErrorCount { get; }


        /// <summary>
        /// Initialise
        /// </summary>
        internal CompilationOutput(
            int warningCount, 
            int errorCount, 
            string[] messages)
        {
            WarningCount = warningCount;
            ErrorCount = errorCount;
            Messages = messages;
        }
    }
}
