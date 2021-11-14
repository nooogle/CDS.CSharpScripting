using CDS.CSharpScripting;
using System;
using System.Threading;
using Xunit;
using FluentAssertions;

namespace XUnitTests.EditorServicesTests
{
    public class CodeCompletionTests
    {
        [Fact]
        public async void T()
        {
            try
            {
                var script = "double.Ma";

                CDS.CSharpScripting.EditorServices.CodeCompletion c = new CDS.CSharpScripting.EditorServices.CodeCompletion();
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                var completions = await c.GetCompletions(
                    script: script,
                    caretPosition: script.Length,
                    cancellationToken: cancellationTokenSource.Token);

                completions.Should().HaveCount(1);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
