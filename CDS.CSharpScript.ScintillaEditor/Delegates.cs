using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CDS.CSharpScript.ScintillaEditor
{
    public delegate Task<IEnumerable<string>> GetAutoCompleteListDelegate(CancellationToken cancellationToken);
}
