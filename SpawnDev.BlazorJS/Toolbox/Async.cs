namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Helper methods for running async lambda methods
    /// </summary>
    public static class Async
    {
        /// <summary>
        /// Shorthand wrapper for running async lambda functions
        /// </summary>
        public static void Run(Func<Task> func) => _ = func();
        /// <summary>
        /// Shorthand wrapper for running async lambda functions
        /// </summary>
        public static Task RunAsync(Func<Task> func) => func();
        /// <summary>
        /// Shorthand wrapper for running async lambda functions
        /// </summary>
        public static Task<T> RunAsync<T>(Func<Task<T>> func) => func();
    }
}
