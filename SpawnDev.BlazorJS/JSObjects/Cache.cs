using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://web.dev/cache-api-quick-guide/
    // https://developer.mozilla.org/en-US/docs/Web/API/Cache
    public class Cache : JSObject
    {
        public Cache(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Non-standard shortcut method to open a cache using the global caches object
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Task<Cache> OpenCache(string name) => JS.CallAsync<Cache>("caches.open", name);
        /// <summary>
        /// Non-standard method to get a list of the existing cache names using the global caches object
        /// </summary>
        /// <returns></returns>
        public static Task<List<string>> CacheNames() => JS.CallAsync<List<string>>("caches.keys");
        /// <summary>
        /// Returns a Promise that resolves to the response associated with the first matching request in the Cache object.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response?> Match(Request request) => JSRef.CallAsync<Response?>("match", request);
        /// <summary>
        /// Returns a Promise that resolves to the response associated with the first matching request in the Cache object.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<Response?> Match(Request request, CacheMatchOptions options) => JSRef.CallAsync<Response?>("match", request, options);
        /// <summary>
        /// Returns a Promise that resolves to the response associated with the first matching request in the Cache object.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response?> Match(string request) => JSRef.CallAsync<Response?>("match", request);
        /// <summary>
        /// Returns a Promise that resolves to the response associated with the first matching request in the Cache object.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<Response?> Match(string request, CacheMatchOptions options) => JSRef.CallAsync<Response?>("match", request, options);
        /// <summary>
        /// Returns a Promise that resolves to an array of all matching responses in the Cache object.
        /// </summary>
        /// <returns></returns>
        public Task<Response[]> MatchAll() => JSRef.CallAsync<Response[]>("matchAll");
        /// <summary>
        /// Returns a Promise that resolves to an array of all matching responses in the Cache object.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response[]> MatchAll(string request) => JSRef.CallAsync<Response[]>("matchAll", request);
        /// <summary>
        /// Returns a Promise that resolves to an array of all matching responses in the Cache object.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<Response[]> MatchAll(string request, CacheMatchOptions options) => JSRef.CallAsync<Response[]>("matchAll", request, options);

        /// <summary>
        /// Takes a URL, retrieves it and adds the resulting response object to the given cache. This is functionally equivalent to calling fetch(), then using put() to add the results to the cache.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task Add(string request) => JSRef.CallVoidAsync("add", request);
        /// <summary>
        /// Takes an array of URLs, retrieves them, and adds the resulting response objects to the given cache.
        /// </summary>
        /// <param name="requests"></param>
        /// <returns></returns>
        public Task AddAll(List<string> requests) => JSRef.CallVoidAsync("addAll", requests);
        /// <summary>
        /// Takes both a request and its response and adds it to the given cache.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        public Task Put(string request, Response response) => JSRef.CallVoidAsync("put", request, response);
        /// <summary>
        /// Finds the Cache entry whose key is the request, returning a Promise that resolves to true if a matching Cache entry is found and deleted. If no Cache entry is found, the promise resolves to false.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<bool> Delete(string request) => JSRef.CallAsync<bool>("delete", request);
        /// <summary>
        /// Finds the Cache entry whose key is the request, returning a Promise that resolves to true if a matching Cache entry is found and deleted. If no Cache entry is found, the promise resolves to false.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<bool> Delete(string request, CacheMatchOptions options) => JSRef.CallAsync<bool>("delete", request, options);
        /// <summary>
        /// Returns a Promise that resolves to an array of Cache keys which are Request objects
        /// </summary>
        /// <returns></returns>
        public Task<Request[]> Keys() => JSRef.CallAsync<Request[]>("keys");
        /// <summary>
        /// Returns a Promise that resolves to an array of Cache keys which are Request objects
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Request[]> Keys(string request) => JSRef.CallAsync<Request[]>("keys", request);
        /// <summary>
        /// Returns a Promise that resolves to an array of Cache keys which are Request objects
        /// </summary>
        /// <param name="request"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<Request[]> Keys(string request, CacheMatchOptions options) => JSRef.CallAsync<Request[]>("keys", request, options);
        /// <summary>
        /// Non-standard shortcut method to get the cache keys as an array of the Request.url strings instead of Request objects
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> KeyUrls()
        {
            var tmp = await Keys();
            var ret = tmp.Select(o => o.Url).ToList();
            tmp.DisposeAll();
            return ret;
        }
    }
}
