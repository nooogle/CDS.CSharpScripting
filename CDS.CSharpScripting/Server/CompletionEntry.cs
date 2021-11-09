using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.CSharpScripting.Server
{
    public class CompletionEntry
    {
        public string Item { get; }
        public string Description { get; }

        public CompletionEntry(string item, string description)
        {
            Item = item;
            Description = description;
        }
    }
}
