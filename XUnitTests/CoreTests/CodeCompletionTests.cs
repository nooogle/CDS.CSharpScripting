using CDS.CSharpScripting;
using System;
using System.Threading;
using Xunit;
using FluentAssertions;

namespace CDS.CSharpScript.XUnitTests
{
    public class CodeCompletionTests
    {
        [Fact]
        public async void T()
        {
            try
            {
                var script = "double.Ma";

                CDS.CSharpScript.Core.ScriptEnv scriptEnv = new Core.ScriptEnv();

                var completions = await scriptEnv.GetCompletions(
                    script: script,
                    caretPosition: script.Length);

                completions.Should().HaveCount(1);
            }
            catch (Exception exception)
            {
            }
        }
    }
}
