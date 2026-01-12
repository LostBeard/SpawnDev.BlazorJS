using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    /// <summary>
    /// The IDBOpenDBRequest interface of the IndexedDB API provides access to the results of requests to open or delete databases (performed using IDBFactory.open and IDBFactory.deleteDatabase), using specific event handler attributes.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBOpenDBRequest
    /// </summary>
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class IDBOpenDBRequestAsync : IDBRequestAsync<IDBDatabaseAsync>
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="jsRef"></param>
        public IDBOpenDBRequestAsync(IJSObjectReference jsRef) : base(jsRef) { }

    }
    /// <summary>
    /// The DOMException interface represents an abnormal event (called an exception) which occurs as a result of calling a method or accessing a property of a web API.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/DOMException
    /// </summary>
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class DOMExceptionAsync : JSObjectAsync
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="jsRef"></param>
        public DOMExceptionAsync(IJSObjectReference jsRef) : base(jsRef) { }
    }
    /// <summary>
    /// The IDBTransaction interface of the IndexedDB API provides a static, asynchronous transaction on a database using event handler attributes. All reading and writing of data is done within transactions. You use IDBDatabase to start transactions, IDBTransaction to set the mode on the transaction (e.g. is it readonly or readwrite), and you access an IDBObjectStore to make a request. You can also use an IDBTransaction object to abort transactions.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBTransaction
    /// </summary>
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class IDBTransactionAsync : JSObjectAsync
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="jsRef"></param>
        public IDBTransactionAsync(IJSObjectReference jsRef) : base(jsRef) { }
    }
    /// <summary>
    /// The IDBRequest interface of the IndexedDB API provides access to results of asynchronous requests to databases and database objects using event handler attributes. Each reading and writing operation on a database is done using a request.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBRequest
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class IDBRequestAsync<TResult> : IDBRequestAsync
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="jsRef"></param>
        public IDBRequestAsync(IJSObjectReference jsRef) : base(jsRef) { }
        /// <summary>
        /// Returns the result of the request. If the request is not completed, the result is not available and an InvalidStateError exception is thrown.
        /// </summary>
        public Task<TResult> Get_Result() => JSRef!.GetAsync<TResult>("result");
    }
    /// <summary>
    /// The IDBRequest interface of the IndexedDB API provides access to results of asynchronous requests to databases and database objects using event handler attributes. Each reading and writing operation on a database is done using a request.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBRequest
    /// </summary>
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
    /// <summary>
    /// The IDBFactory interface of the IndexedDB API lets applications asynchronously access the indexed databases.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBFactory
    /// </summary>
    public class IDBFactoryAsync
    {
        IJSRuntime JSR;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="jsr"></param>
        public IDBFactoryAsync(IJSRuntime jsr)
        {
            JSR = jsr;
        }
        /// <summary>
        /// The open() method of the IDBFactory interface requests opening a connection to a database.
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbVersion"></param>
        /// <returns></returns>
        public async Task<IDBOpenDBRequestAsync> Open(string dbName, long dbVersion)
        {
            var ret = await JSR!.CallAsync<IDBOpenDBRequestAsync>("indexedDB.open", dbName, dbVersion);
            return ret;
        }
        /// <summary>
        /// The open() method of the IDBFactory interface requests opening a connection to a database.
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbVersion"></param>
        /// <param name="onUpgradeNeeded"></param>
        /// <returns></returns>
        public async Task<IDBDatabaseAsync> OpenAsync(string dbName, long dbVersion, Func<IDBVersionChangeEventAsync, Task>? onUpgradeNeeded)
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

