using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScratchPad
{
    class Program
    {
        static async Task Main()
        {
            for (int i = 0; i < 1000; i++)
            {
                CDS.CSharpScripting.EditorServices.ScriptEnv scriptEnv = new CDS.CSharpScripting.EditorServices.ScriptEnv(
                    namespaceTypes: new Type[] { },
                    additionalAssemblies: new Assembly[] { },
                    typeOfGlobals: null);

                var cancellationTokenSource = new CancellationTokenSource();

                var completions = await scriptEnv.GetCompletions(
                    script: "int.",
                    caretPosition: 4,
                    cancellationToken: cancellationTokenSource.Token);
            }

            Console.ReadKey();
        }
    }
}
