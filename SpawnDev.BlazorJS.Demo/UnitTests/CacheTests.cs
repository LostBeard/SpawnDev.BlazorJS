using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.Demo.UnitTests
{
    public class CacheTests
    {
        BlazorJSRuntime JS;
        public CacheTests(BlazorJSRuntime js)
        {
            JS = js;
        }

        [TestMethod]
        public async Task CacheStorageTest()
        {
            using var caches = JS.Get<CacheStorage>("caches");
            if (caches == null) return; // Not supported or invalid context

            var cacheName = "test-cache-" + Guid.NewGuid();
            
            // Open (create) cache
            using var cache = await caches.Open(cacheName);
            
            // Add request
            var requestUrl = "https://jsonplaceholder.typicode.com/todos/1";
            await cache.Add(requestUrl);

            // Match request
            using var response = await cache.Match(requestUrl);
            if (response == null) throw new Exception("Cache match failed");
            
            var text = await response.Text();
            if (string.IsNullOrEmpty(text)) throw new Exception("Response body empty");

            // Key check (optional, seeing if the cache key exists)
            var keys = await cache.Keys();
            if (keys.Length == 0) throw new Exception("Cache keys empty");

            // Delete request from cache
            var deleted = await cache.Delete(requestUrl);
            if (!deleted) throw new Exception("Failed to delete from cache");

            // Delete cache
            var cacheDeleted = await caches.Delete(cacheName);
            if (!cacheDeleted) throw new Exception("Failed to delete cache");
        }
    }
}
