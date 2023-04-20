using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://web.dev/cache-api-quick-guide/
    // https://developer.mozilla.org/en-US/docs/Web/API/CacheStorage/match
    public class CacheStorage : JSObject
    {
        public CacheStorage(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Non-standard constructor shortcut to just get an instance of the global caches object
        /// </summary>
        public CacheStorage() : base(JS.Get<IJSInProcessObjectReference>("caches")) { }
        /// <summary>
        /// Finds the Cache object matching the cacheName, and if found, deletes the Cache object and returns a Promise that resolves to true. If no Cache object is found, it resolves to false.
        /// </summary>
        /// <param name="cacheName"></param>
        public void Delete(string cacheName) => JSRef.CallVoid("delete", cacheName);
        /// <summary>
        /// Returns a Promise that resolves to true if a Cache object matching the cacheName exists.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<bool> Has(string cacheName) => JSRef.CallAsync<bool>("has", cacheName);
        /// <summary>
        /// Returns a Promise that will resolve with an array containing strings corresponding to all of the named Cache objects tracked by the CacheStorage. Use this method to iterate over a list of all the Cache objects
        /// </summary>
        /// <returns></returns>
        public Task<List<string>> Keys() => JSRef.CallAsync<List<string>>("keys");
        /// <summary>
        /// Checks if a given Request is a key in any of the Cache objects that the CacheStorage object tracks, and returns a Promise that resolves to that match.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<Response?> Match(string request, CacheMatchOptions options) => JSRef.CallAsync<Response?>("match", request, options);
        /// <summary>
        /// Checks if a given Request is a key in any of the Cache objects that the CacheStorage object tracks, and returns a Promise that resolves to that match.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<Response?> Match(string request) => JSRef.CallAsync<Response?>("match", request);
        /// <summary>
        /// Returns a Promise that resolves to the Cache object matching the cacheName (a new cache is created if it doesn't already exist.)
        /// </summary>
        /// <param name="cacheName"></param>
        /// <returns></returns>
        public Task<Cache> Open(string cacheName) => JSRef.CallAsync<Cache>("open", cacheName);
    }
}
