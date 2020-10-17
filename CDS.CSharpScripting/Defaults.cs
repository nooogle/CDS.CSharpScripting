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
        /// <remarks>
        /// For each the namespace will be automatically made available. For example,
        /// this means that Thread can be Rectangle can be declared without requiring
        /// 'using System.Drawing;', and the System.Drawing.dll is automatically
        /// referenced.
        /// </remarks>
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
            typeof(System.Drawing.Point),
            typeof(System.Windows.Forms.Form),
        };
    }
}
