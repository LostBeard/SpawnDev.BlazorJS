namespace SpawnDev.BlazorJS.Toolbox
{
    public static class Async 
    {
        /// <summary>
        /// Shorthand wrapper for running async lambda functions on the same thread<br />
        /// </summary>
        /// <param name="func"></param>
        public static void Run(Func<Task> func) => _ = func();
    }
}
