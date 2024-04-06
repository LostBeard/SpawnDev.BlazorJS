using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The IDBTransaction interface of the IndexedDB API provides a static, asynchronous transaction on a database using event handler attributes. All reading and writing of data is done within transactions. You use IDBDatabase to start transactions, IDBTransaction to set the mode of the transaction (e.g. is it readonly or readwrite), and you access an IDBObjectStore to make a request. You can also use an IDBTransaction object to abort transactions.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBTransaction
    /// </summary>
    public class IDBTransaction : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBTransaction(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns an IDBObjectStore object representing an object store that is part of the scope of this transaction.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="storeName">The name of the requested object store.</param>
        /// <returns>An IDBObjectStore object for accessing an object store.</returns>
        public IDBObjectStore<TValue> ObjectStore<TValue>(string storeName) => JSRef.Call<IDBObjectStore<TValue>>("objectStore", storeName);
        /// <summary>
        /// Returns an IDBObjectStore object representing an object store that is part of the scope of this transaction.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="storeName">The name of the requested object store.</param>
        /// <returns>An IDBObjectStore object for accessing an object store.</returns>
        public IDBObjectStore<TKey, TValue> ObjectStore<TKey, TValue>(string storeName) => JSRef.Call<IDBObjectStore<TKey, TValue>>("objectStore", storeName);
        /// <summary>
        /// Rolls back all the changes to objects in the database associated with this transaction. If this transaction has been aborted or completed, this method fires an error event.
        /// </summary>
        public void Abort() => JSRef.CallVoid("abort");
        /// <summary>
        /// For an active transaction, commits the transaction. Note that this doesn't normally have to be called — a transaction will automatically commit when all outstanding requests have been satisfied and no new requests have been made. commit() can be used to start the commit process without waiting for events from outstanding requests to be dispatched.
        /// </summary>
        public void Commit() => JSRef.CallVoid("commit");
        /// <summary>
        /// An event fired when the IndexedDB transaction is aborted. Also available via the onabort property; this event bubbles to IDBDatabase.
        /// </summary>
        public JSEventCallback<Event> OnAbort { get => new JSEventCallback<Event>("abort", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// An event fired when the transaction successfully completes. Also available via the oncomplete property.
        /// </summary>
        public JSEventCallback<Event> OnComplete { get => new JSEventCallback<Event>("complete", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// An event fired when a request returns an error and the event bubbles up to the connection object (IDBDatabase). Also available via the onerror property.
        /// </summary>
        public JSEventCallback<Event> OnError { get => new JSEventCallback<Event>("error", AddEventListener, RemoveEventListener); set { } }
    }
}
