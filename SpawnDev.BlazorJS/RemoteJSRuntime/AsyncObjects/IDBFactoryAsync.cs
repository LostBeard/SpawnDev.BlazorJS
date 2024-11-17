using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class IDBOpenDBRequestAsync : IDBRequestAsync<IDBDatabaseAsync>
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="jsRef"></param>
        public IDBOpenDBRequestAsync(IJSObjectReference jsRef) : base(jsRef) { }

    }
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class DOMExceptionAsync : JSObjectAsync
    {
        public DOMExceptionAsync(IJSObjectReference jsRef) : base(jsRef) { }
    }
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class IDBTransactionAsync : JSObjectAsync
    {
        public IDBTransactionAsync(IJSObjectReference jsRef) : base(jsRef) { }
    }
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class IDBRequestAsync<TResult> : IDBRequestAsync
    {
        public IDBRequestAsync(IJSObjectReference jsRef) : base(jsRef) { }
        public Task<TResult> Get_Result() => JSRef!.GetAsync<TResult>("result");
    }
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class IDBRequestAsync : EventTargetAsync
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="jsRef"></param>
        public IDBRequestAsync(IJSObjectReference jsRef) : base(jsRef) { }
        /// <summary>
        /// Returns a DOMException in the event of an unsuccessful request, indicating what went wrong.
        /// </summary>
        public Task<DOMExceptionAsync> Get_Error() => JSRef!.GetAsync<DOMExceptionAsync>("error");
        /// <summary>
        /// Returns the result of the request. If the request is not completed, the result is not available and an InvalidStateError exception is thrown.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Task<T> Get_ResultAs<T>() => JSRef!.GetAsync<T>("result");
        /// <summary>
        /// An object representing the source of the request, such as an IDBIndex, IDBObjectStore or IDBCursor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Task<T> Get_SourceAs<T>() => JSRef!.GetAsync<T>("source");
        /// <summary>
        /// The state of the request. Every request starts in the pending state. The state changes to done when the request completes successfully or when an error occurs.
        /// </summary>
        public Task<string> Get_ReadyState() => JSRef!.GetAsync<string>("readyState");
        /// <summary>
        /// The transaction for the request. This property can be null for certain requests, for example those returned from IDBFactory.open unless an upgrade is needed. (You're just connecting to a database, so there is no transaction to return).
        /// </summary>
        public Task<IDBTransactionAsync?> Get_Transaction() => JSRef!.GetAsync<IDBTransactionAsync?>("transaction");
    }
    /// <summary>
    /// The IDBVersionChangeEvent interface of the IndexedDB API indicates that the version of the database has changed, as the result of an onupgradeneeded event handler function.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBVersionChangeEvent
    /// </summary>
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class IDBVersionChangeEventAsync : EventAsync<IDBOpenDBRequestAsync>
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBVersionChangeEventAsync(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The oldVersion read-only property of the IDBVersionChangeEvent interface returns the old version number of the database.<br/>
        /// A number containing a 64-bit integer.
        /// </summary>
        public Task<long> Get_OldVersion() => JSRef!.GetAsync<long>("oldVersion");
        /// <summary>
        /// The newVersion read-only property of the IDBVersionChangeEvent interface returns the new version number of the database.<br/>
        /// A number that is a 64-bit integer or null if the database is being deleted.
        /// </summary>
        public Task<long?> Get_NewVersion() => JSRef!.GetAsync<long?>("newVersion");
    }
    public class IDBFactoryAsync
    {
        IJSRuntime JSR;
        public IDBFactoryAsync(IJSRuntime jsr)
        {
            JSR = jsr;
        }
        async Task<IDBOpenDBRequestAsync> Open(string dbName, long dbVersion)
        {
            var ret = await JSR!.CallAsync<IDBOpenDBRequestAsync>("indexedDB.open", dbName, dbVersion);
            return ret;
        }
        /// <summary>
        /// does not work. events cannot be attached asynchronously because they may have already fired
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbVersion"></param>
        /// <param name="onUpgradeNeeded"></param>
        /// <returns></returns>
        async Task<IDBDatabaseAsync> OpenAsync(string dbName, long dbVersion, Func<IDBVersionChangeEventAsync, Task>? onUpgradeNeeded)
        {
            var openRequest = await Open(dbName, dbVersion);
            var tcs = new TaskCompletionSource<IDBDatabaseAsync>();
            var onSuccessCBA = new ActionCallbackAsync(JSR, async () =>
            {
                var idb = await openRequest.Get_Result();
                tcs.TrySetResult(idb);
            });
            var onErrorCBA = new ActionCallbackAsync(JSR, async () =>
            {
                tcs.TrySetException(new Exception("Failed"));
            });
            CallbackAsync? onUpgradeNeededCBA = null;
            if (onUpgradeNeeded != null)
            {
                onUpgradeNeededCBA = new ActionCallbackAsync<IDBVersionChangeEventAsync>(JSR, onUpgradeNeeded);
                await openRequest.AddEventListener("upgradeneeded", onUpgradeNeededCBA);
            }
            // 
            await openRequest.AddEventListener("success", onSuccessCBA);
            await openRequest.AddEventListener("error", onErrorCBA);
            var ret = await tcs.Task;
            if (onUpgradeNeededCBA != null)
            {
                await onUpgradeNeededCBA.DisposeAsync();
            }
            return ret;
        }
    }
}

