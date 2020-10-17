namespace CDS.CSharpScripting
{
    /// <summary>
    /// Run compiled scripts
    /// </summary>
    public static class ScriptRunner
    {
        /// <summary>
        /// Run the compiled script
        /// </summary>
        /// <param name="compiledScript">Script to run</param>
        public static void Run(CompiledScript compiledScript)
        {
            Run<object>(
                compiledScript: compiledScript, 
                globals: null);
        }


        /// <summary>
        /// Run the compiled script
        /// </summary>
        /// <param name="compiledScript">Script to run</param>
        /// <param name="globals">Instance of the Globals type used during compilation <see cref="ScriptCompiler.Compile{ReturnType}(string, System.Type[], System.Type[], System.Type)"/>, or null if not required.</param>
        public static void Run(CompiledScript compiledScript, object globals)
        {
            Run<object>(
                compiledScript: compiledScript, 
                globals: globals);
        }


        /// <summary>
        /// Run the compiled script
        /// </summary>
        /// <param name="compiledScript">Script to run</param>
        /// <param name="globals">Instance of the Globals type passed into <see cref="ScriptCompiler.Compile{ReturnType}(string, System.Type[], System.Type[], System.Type)"/>, or null if not required.</param>
        public static ReturnType Run<ReturnType>(CompiledScript compiledScript, object globals)
        {

            var runTask = compiledScript.ActualScript.RunAsync(globals);
            runTask.Wait();
            var returnValue = (ReturnType)runTask.Result.ReturnValue;
            return returnValue;
        }
    }
}
