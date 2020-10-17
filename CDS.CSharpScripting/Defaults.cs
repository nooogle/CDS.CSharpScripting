using System;

namespace CDS.CSharpScripting
{
    /// <summary>
    /// Default settings and data for the project
    /// </summary>
    public static class Defaults
    {
        /// <summary>
        /// The default types used for namespaces and assembly references.
        /// </summary>
        public static readonly Type[] TypesForNamespacesAndAssemblies = new[]
        {
                typeof(int),
                typeof(System.Threading.Thread),
                typeof(System.Threading.Tasks.Task),
                typeof(System.Collections.ArrayList),
                typeof(System.Collections.Generic.Comparer<object>),
                typeof(System.Text.ASCIIEncoding),
                typeof(System.Text.RegularExpressions.Capture),
                typeof(System.Linq.Enumerable),
                typeof(System.IO.BinaryReader),
                typeof(System.Reflection.Assembly),
            };
    }
}
