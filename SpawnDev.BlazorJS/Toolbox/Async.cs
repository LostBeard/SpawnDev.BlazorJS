namespace SpawnDev.BlazorJS.Toolbox
{
    public static class Async 
    {
        /// <summary>
        /// Shorthand wrapper for running async lambda functions
        /// </summary>
        /// <param name="func"></param>
        public static void Run(Func<Task> func) => _ = func();
        /// <summary>
        /// Shorthand wrapper for running async lambda functions
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Task RunAsync(Func<Task> func) => func();
    }
}
