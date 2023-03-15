namespace SpawnDev.BlazorJS {
    public static class IEnumerableExtensions {
        public static void DisposeAll(this IEnumerable<IDisposable> target) {
            foreach (var item in target) item?.Dispose();
        }
    }
}
