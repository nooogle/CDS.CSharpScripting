using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TempConsoleTest
{
    class Program
    {
        static void Main()
        {
            f().Wait();
        }

        private static async Task f()
        {
            var script = "double.Ma";

            CDS.CSharpScripting.EditorServices.CodeCompletion c = new CDS.CSharpScripting.EditorServices.CodeCompletion();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var completions = await c.GetCompletions(
                script: script,
                caretPosition: script.Length,
                cancellationToken: cancellationTokenSource.Token);
        }
    }
}
