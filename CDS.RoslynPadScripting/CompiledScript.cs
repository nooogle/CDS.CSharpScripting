using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.RoslynPadScripting
{
    /// <summary>
    /// Utility to wrap a compiled script. 
    /// </summary>
    public class CompiledScript
    {
        internal Script ActualScript { get; set; } 
    }
}
