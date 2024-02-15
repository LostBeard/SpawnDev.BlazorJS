namespace SpawnDev.Blazor.UnitTesting
{
    public static class Async
    {
        /// <summary>
        /// Shorthand wrapper for running async lambda functions
        /// </summary>
        /// <param name="func"></param>
        public static void Run(Func<Task> func) => _ = func();
    }
}
