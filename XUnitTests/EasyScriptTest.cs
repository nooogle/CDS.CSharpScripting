using CDS.CSharpScripting;
using System;
using Xunit;

namespace XUnitTests
{
    public class EasyScriptTest
    {
        [Fact]
        public void Go_BlankScript_NoCompilationWarnings()
        {
            var easyScript = EasyScript<object>.Go("");

            Assert.Equal(
                expected: 0,
                actual: easyScript.CompilationOutput.WarningCount);
        }


        [Fact]
        public void Go_BlankScript_NoCompilationErrors()
        {
            var easyScript = EasyScript<object>.Go("");

            Assert.Equal(
                expected: 0,
                actual: easyScript.CompilationOutput.ErrorCount);
        }


        [Fact]
        public void Go_BlankScript_NoCompilationMessages()
        {
            var easyScript = EasyScript<object>.Go("");

            Assert.Empty(easyScript.CompilationOutput.Messages);
        }


        [Fact]
        public void Go_BlankScript_AllOk()
        {
            var easyScript = EasyScript<object>.Go("");

            Assert.True(easyScript.AllOk);
        }


        [Fact]
        public void Go_BlankScript_NoRuntimeException()
        {
            var easyScript = EasyScript<object>.Go("");

            Assert.Null(easyScript.RuntimeException);
        }


        [Fact]
        public void Go_BlankScript_SummaryAllOk()
        {
            var easyScript = EasyScript<object>.Go("");

            Assert.Contains(
                expectedSubstring: "all ok",
                actualString: easyScript.Summary,
                comparisonType: System.StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Go_BadScript_OneCompilationError()
        {
            var easyScript = EasyScript<object>.Go("int x = unknown_variable;");

            Assert.Equal(
                expected: 1,
                actual: easyScript.CompilationOutput.ErrorCount);
        }


        [Fact]
        public void Go_BadScript_OneCompilationMessage()
        {
            var easyScript = EasyScript<object>.Go("int x = unknown_variable;");

            Assert.Single(easyScript.CompilationOutput.Messages);
        }


        [Fact]
        public void Go_PoorScript_OneCompilationWarning()
        {
            var script = string.Join(
                separator: Environment.NewLine,
                "int Double(int x)      ",
                "{                      ",
                "    return 0;          ",
                "    return x * 2;      ",
                "}                      ");

            var easyScript = EasyScript<object>.Go(script);

            Assert.Equal(
                expected: 1,
                actual: easyScript.CompilationOutput.WarningCount);
        }


        [Fact]
        public void Go_PoorScript_OneCompilationMessage()
        {
            var script = string.Join(
                separator: Environment.NewLine,
                "int Double(int x)      ",
                "{                      ",
                "    return 0;          ",
                "    return x * 2;      ",
                "}                      ");

            var easyScript = EasyScript<object>.Go(script);

            Assert.Single(easyScript.CompilationOutput.Messages);
        }


        [Fact]
        public void Go_ReturnValue_AsExpected()
        {
            var script = "1";
            var easyScript = EasyScript<int>.Go(script);

            Assert.Equal(
                expected: 1,
                actual: easyScript.ScriptResults);
        }
        

        [Fact]
        public void Go_InvalidReturnValue_FailsToCompile()
        {
            var script = "1.2";
            var easyScript = EasyScript<int>.Go(script);

            Assert.Equal(
                expected: 1,
                actual: easyScript.CompilationOutput.ErrorCount);
        }


        public class Globals { public int C { get; set; }  }


        [Fact]
        public void Go_Globals_CanReadGlobalProperty()
        {
            var globals = new Globals() { C = 1 };
            var script = "C + 1";
            var easyScript = EasyScript<int>.Go(script, globals);

            Assert.Equal(
                expected: globals.C + 1,
                actual: easyScript.ScriptResults);
        }


        [Fact]
        public void Go_Globals_CanWriteGlobalProperty()
        {
            var globals = new Globals() { C = 1 };
            var script = "C = 9";
            var easyScript = EasyScript<int>.Go(script, globals);

            Assert.Equal(
                expected: 9,
                actual: globals.C);
        }
    }
}
