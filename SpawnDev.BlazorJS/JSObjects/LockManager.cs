using Microsoft.JSInterop;

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
        #region Requests with Async callbacks
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task Request(string lockName, Func<Lock, Task> callback)
        {
            using var funcCallback = new AsyncActionCallback<Lock>(callback);
            await JSRef!.CallVoidAsync("request", lockName, funcCallback);
        }
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="lockName"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task<TResult> Request<TResult>(string lockName, Func<Lock, Task<TResult>> callback)
        {
            using var funcCallback = new AsyncFuncCallback<Lock, TResult>(callback);
            return await JSRef!.CallAsync<TResult>("request", lockName, funcCallback);
        }
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task Request(string lockName, Func<Task> callback)
        {
            using var funcCallback = new AsyncActionCallback(callback);
            await JSRef!.CallVoidAsync("request", lockName, funcCallback);
        }
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task<TResult> Request<TResult>(string lockName, Func<Task<TResult>> callback)
        {
            using var funcCallback = new AsyncFuncCallback<TResult>(callback);
            return await JSRef!.CallAsync<TResult>("request", lockName, funcCallback);
        }
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="options"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task Request(string lockName, LockRequestOptions options, Func<Lock?, Task> callback)
        {
            using var funcCallback = new AsyncActionCallback<Lock>(callback);
            await JSRef!.CallVoidAsync("request", lockName, options, funcCallback);
        }
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="options"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task<TResult> Request<TResult>(string lockName, LockRequestOptions options, Func<Lock?, Task<TResult>> callback)
        {
            using var funcCallback = new AsyncFuncCallback<Lock, TResult>(callback);
            return await JSRef!.CallAsync<TResult>("request", lockName, options, funcCallback);
        }
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="options"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task Request(string lockName, LockRequestOptions options, Func<Task> callback)
        {
            using var funcCallback = new AsyncActionCallback(callback);
            await JSRef!.CallVoidAsync("request", lockName, options, funcCallback);
        }
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="options"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task<TResult> Request<TResult>(string lockName, LockRequestOptions options, Func<Task<TResult>> callback)
        {
            using var funcCallback = new AsyncFuncCallback<TResult>(callback);
            return await JSRef!.CallAsync<TResult>("request", lockName, options, funcCallback);
        }
        #endregion
        #region Requests with Sync callbacks
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task Request(string lockName, Action<Lock> callback)
        {
            using var funcCallback = new ActionCallback<Lock>(callback);
            await JSRef!.CallVoidAsync("request", lockName, funcCallback);
        }
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="lockName"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task<TResult> Request<TResult>(string lockName, Func<Lock, TResult> callback)
        {
            using var funcCallback = new FuncCallback<Lock, TResult>(callback);
            return await JSRef!.CallAsync<TResult>("request", lockName, funcCallback);
        }
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task Request(string lockName, Action callback)
        {
            using var funcCallback = new ActionCallback(callback);
            await JSRef!.CallVoidAsync("request", lockName, funcCallback);
        }
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task<TResult> Request<TResult>(string lockName, Func<TResult> callback)
        {
            using var funcCallback = new FuncCallback<TResult>(callback);
            return await JSRef!.CallAsync<TResult>("request", lockName, funcCallback);
        }
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="options"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task Request(string lockName, LockRequestOptions options, Action<Lock?> callback)
        {
            using var funcCallback = new ActionCallback<Lock>(callback);
            await JSRef!.CallVoidAsync("request", lockName, options, funcCallback);
        }
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="options"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task<TResult> Request<TResult>(string lockName, LockRequestOptions options, Func<Lock?, TResult> callback)
        {
            using var funcCallback = new FuncCallback<Lock, TResult>(callback);
            return await JSRef!.CallAsync<TResult>("request", lockName, options, funcCallback);
        }
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="options"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task Request(string lockName, LockRequestOptions options, Action callback)
        {
            using var funcCallback = new ActionCallback(callback);
            await JSRef!.CallVoidAsync("request", lockName, options, funcCallback);
        }
        /// <summary>
        /// The request() method of the LockManager interface requests a Lock object with parameters specifying its name and characteristics. The requested Lock is passed to a callback, while the function itself returns a Promise that resolves (or rejects) with the result of the callback after the lock is released, or rejects if the request is aborted.
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="options"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task<TResult> Request<TResult>(string lockName, LockRequestOptions options, Func<TResult> callback)
        {
            using var funcCallback = new FuncCallback<TResult>(callback);
            return await JSRef!.CallAsync<TResult>("request", lockName, options, funcCallback);
        }
        #endregion
        /// <summary>
        /// Returns an array of client ids that are holding or waiting for locks
        /// </summary>
        /// <returns></returns>
        public async Task<string[]> QueryClientIds()
        {
            var state = await Query();
            return state.Held.Select(o => o.ClientId).Concat(state.Pending.Select(o => o.ClientId)).Distinct().ToArray();
        }
        /// <summary>
        /// The query() method of the LockManager interface returns a Promise that resolves with an object containing information about held and pending locks.
        /// </summary>
        /// <returns></returns>
        public Task<LockManagerState> Query() => JSRef!.CallAsync<LockManagerState>("query");
        /// <summary>
        /// This client id
        /// </summary>
        public Task<string> ClientId => _clientId.Value;
        static Lazy<Task<string>> _clientId = new Lazy<Task<string>>(async () =>
        {
            var clientId = "";
            using var navigator = BlazorJSRuntime.JS.Get<Navigator>("navigator");
            using var locks = navigator.Locks;
            var randId = Guid.NewGuid().ToString();
            await locks.Request(randId, async () =>
            {
                var lockState = await locks.Query();
                clientId = lockState.Held.First(o => o.Name == randId).ClientId;
            });
            return clientId;
        });
    }
}
