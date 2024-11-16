using Microsoft.JSInterop;
using SpawnDev.BlazorJS.Internal;

namespace SpawnDev.BlazorJS.RemoteJSRuntime
{
    /// <summary>
    /// An alternative to IJSRuntime
    /// </summary>
    public class BlazorJSRuntimeAsync
    {
        BlazorJSInteropAsync jsInterop;
        /// <summary>
        /// Create new instance
        /// </summary>
        /// <param name="jsRuntime"></param>
        public BlazorJSRuntimeAsync(IJSRuntime jsRuntime)
        {
            jsInterop = new BlazorJSInteropAsync(jsRuntime);
        }
        /// <summary>
        /// Creates a new object
        /// </summary>
        /// <returns></returns>
        public Task<T> NewAsync<T>() => jsInterop.GlobalPropertyNew<T>("Object", null);
        /// <summary>
        /// Creates a new object
        /// </summary>
        /// <returns></returns>
        public Task<IJSObjectReference> NewAsync() => jsInterop.GlobalPropertyNew<IJSObjectReference>("Object", null);
        /// <summary>
        /// Get a global property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<T> GetAsync<T>(string key) => jsInterop.GlobalPropertyGet<T>(key);
        /// <summary>
        /// Get a global property
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<IJSObjectReference> GetAsync(string key) => jsInterop.GlobalPropertyGet<IJSObjectReference>(key);
        /// <summary>
        /// Set a global property
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task SetAsync(string key, object value) => jsInterop.GlobalPropertySet(key, value);
        /// <summary>
        /// Creates a new instance the global property type
        /// </summary>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<T> NewAsync<T>(string key, params object?[]? args) => jsInterop.GlobalPropertyNew<T>(key, args);
        /// <summary>
        /// Creates a new instance the global property type
        /// </summary>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<IJSObjectReference> NewAsync(string key, params object?[]? args) => jsInterop.GlobalPropertyNew<IJSObjectReference>(key, args);
        /// <summary>
        /// Call a global method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<T> CallAsync<T>(string key, params object?[]? args) => jsInterop.GlobalPropertyCall<T>(key, args);
        /// <summary>
        /// Call a global method
        /// </summary>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task<IJSObjectReference> CallAsync(string key, params object?[]? args) => jsInterop.GlobalPropertyCall<IJSObjectReference>(key, args);
        /// <summary>
        /// Call a global method
        /// </summary>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public Task CallVoidAsync(string key, params object?[]? args) => jsInterop.GlobalPropertyCallVoid(key, args);
        /// <summary>
        /// Returns a list of the global property's keys
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hasOwnProperty"></param>
        /// <returns></returns>
        public Task<List<string>> KeysAsync(string key, bool hasOwnProperty = false) => jsInterop.GlobalPropertyKeys(key, hasOwnProperty);
        /// <summary>
        /// Returns the global property's 'constructor.name' value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<string?> ConstructorNameAsync(string key) => jsInterop.GlobalPropertyConstructorName(key);
        /// <summary>
        /// Returns the global property's 'typeof' value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<string> TypeOfAsync(string key) => jsInterop.GlobalPropertyTypeOf(key);
        /// <summary>
        /// Deletes a global property
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(string key) => jsInterop.GlobalPropertyDelete(key);
        /// <summary>
        /// Tests if a property exists using the 'in' operator
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<bool> InAsync(string key) => jsInterop.GlobalPropertyIn(key);
        /// <summary>
        /// Returns true if 'typeof' global property == "undefined"
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<bool> IsUndefinedAsync(string key) => await TypeOfAsync(key) == "undefined";
        /// <summary>
        /// Returns the specified object as type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Task<T> ReturnAs<T>(object? obj) => jsInterop.ObjectGet<T>(obj);
    }
}
