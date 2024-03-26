namespace SpawnDev.BlazorJS
{
    public static class IEnumerableExtensions
    {
        public static void DisposeAll(this IDisposable[] target)
        {
            foreach (var item in target) item?.Dispose();
        }
    }
}
