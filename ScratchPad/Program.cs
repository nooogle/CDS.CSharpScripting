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
            var workspace = new CDS.CSharpScript.Core.Editor.Workspace();

            var completions = await CDS.CSharpScript.Core.Editor.Completions.GetCompletions(
                workspace: workspace,
                script: "int.",
                caretPosition: 4);

            Console.ReadKey();
        }
    }
}
