using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CDS.CSharpScripting.ScintillaNETEditor
{
    public delegate Task<IEnumerable<string>> GetAutoCompleteListDelegate(CancellationToken cancellationToken);
}
