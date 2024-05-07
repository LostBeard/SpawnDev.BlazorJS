using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The LockManager interface of the Web Locks API provides methods for requesting a new Lock object and querying for an existing Lock object. To get an instance of LockManager, call navigator.locks.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/LockManager
    /// </summary>
    public class LockManager : JSObject
    {
        /// <summary>
        /// Returns true if navigator.locks is defined
        /// </summary>
        public static bool IsSupported => !JS.IsUndefined("navigator") && !JS.IsUndefined("navigator.locks");
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public LockManager(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task Request(string lockName, Func<Lock, Task> callback)
        {
            using var funcCallback = new AsyncActionCallback<Lock>(callback));
            await JSRef!.CallVoidAsync("request", lockName, callback);
        }
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="options"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task Request(string lockName, LockRequestOptions options, Func<Lock, Task> callback)
        {
            using var funcCallback = new AsyncActionCallback<Lock>(callback));
            await JSRef!.CallVoidAsync("request", lockName, options, callback);
        }
        /// <summary>
        /// The query() method of the LockManager interface returns a Promise that resolves with an object containing information about held and pending locks.
        /// </summary>
        /// <returns></returns>
        public Task<LockManagerState> Query() => JSRef!.CallAsync<LockManagerState>("query");

    }
}
