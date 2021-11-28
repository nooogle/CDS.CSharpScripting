using System.Collections.Immutable;

namespace CDS.CSharpScript.Core
{
    public class CompletionEntry
    {
        public string Item { get; }
        public ImmutableArray<string> Tags { get; }
        public string QuickInfo { get; } 

        public CompletionEntry(string item, ImmutableArray<string> tags, string quickInfo)
        {
            Item = item;
            Tags = tags;
            QuickInfo = quickInfo;
        }
    }
}
