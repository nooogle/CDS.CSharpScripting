using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Scripting;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace CDS.CSharpScripting
{
    /// <summary>
    /// Utility to wrap a compiled script. 
    /// </summary>
    /// <remarks>
    /// To reduce the need for client applications to have to reference the Microsoft
    /// scripting libraries we hide the compiled script in this wrapper. Only the
    /// core library can (and needs) access to this data.
    /// </remarks>
    public class CompiledScript
    {
        /// <summary>
        /// A compiled script.
        /// </summary>
        internal Script ActualScript { get; }


        /// <summary>Compilation results</summary>
        public CompilationOutput CompilationOutput { get; } 


        /// <summary>
        /// Initialise
        /// </summary>
        /// <param name="script">A compiled script</param>
        /// <param name="diagnostics">Compilation diagnostics</param>
        internal CompiledScript(
            Script script,
            ImmutableArray<Diagnostic> diagnostics)
        {
            ActualScript = script;
            CompilationOutput = AnalyseDiagnostics(diagnostics);
        }


        /// <summary>
        /// Find useful information from the compilation diagnotics
        /// </summary>
        private CompilationOutput AnalyseDiagnostics(ImmutableArray<Diagnostic> diagnostics)
        {
            List<string> output = new List<string>();
            int warningCount = 0;
            int errorCount = 0;


            foreach (var diagnostic in diagnostics)
            {
                output.Add(diagnostic.ToString());

                if (diagnostic.Severity == DiagnosticSeverity.Warning)
                {
                    warningCount++;
                }
                else if (diagnostic.Severity == DiagnosticSeverity.Error)
                {
                    errorCount++;
                }
            }


            var compilationResults = new CompilationOutput(
                warningCount: warningCount, 
                errorCount: errorCount, 
                messages: output.ToArray());


            return compilationResults;
        }
    }
}
