using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The IDBTransaction interface of the IndexedDB API provides a static, asynchronous transaction on a database using event handler attributes. All reading and writing of data is done within transactions. You use IDBDatabase to start transactions, IDBTransaction to set the mode of the transaction (e.g. is it readonly or readwrite), and you access an IDBObjectStore to make a request. You can also use an IDBTransaction object to abort transactions.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBTransaction
    /// </summary>
    public class IDBTransaction : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBTransaction(IJSInProcessObjectReference _ref) : base(_ref) { }
        #region Properties
        /// <summary>
        /// The database connection with which this transaction is associated.
        /// </summary>
        public IDBDatabase Db => JSRef!.Get<IDBDatabase>("db");
        /// <summary>
        /// Returns the durability hint the transaction was created with.<br/>
        /// Any of the following literal strings:<br/>
        /// "strict"<br/>
        /// "relaxed"<br/>
        /// "default"<br/>
        /// </summary>
        public string Durability => JSRef!.Get<string>("durability");
        /// <summary>
        /// Returns a DOMException indicating the type of error that occurred when there is an unsuccessful transaction. This property is null if the transaction is not finished, is finished and successfully committed, or was aborted with the IDBTransaction.abort() function.
        /// </summary>
        public DOMException? Error => JSRef!.Get<DOMException?>("error");
        /// <summary>
        /// An string defining the mode for isolating access to data in the current object stores: A string defining the mode for isolating access to data in the current object stores.<br/>
        /// The following values are available:<br/>
        /// "readonly" - Allows data to be read but not changed.<br/>
        /// "readwrite" - Allows reading and writing of data in existing data stores to be changed.<br/>
        /// "versionchange" - Allows any operation, including ones that delete and create object stores and indexes. This mode is for updating the version number of transactions if the need is detected when calling IDBFactory.open(). Transactions of this mode cannot run concurrently with other transactions. Transactions in this mode are known as upgrade transactions.<br/>
        /// </summary>
        public string Mode => JSRef!.Get<string>("mode");
        /// <summary>
        /// Returns a string[] of the names of IDBObjectStore objects associated with the transaction.
        /// </summary>
        public string[] ObjectStoreNames => JSRef!.Get<DOMStringList>("objectStoreNames")!;
        #endregion
        #region Methods
        /// <summary>
        /// Returns an IDBObjectStore object representing an object store that is part of the scope of this transaction.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="storeName">The name of the requested object store.</param>
        /// <returns>An IDBObjectStore object for accessing an object store.</returns>
        public IDBObjectStore<TKey, TValue> ObjectStore<TKey, TValue>(string storeName) => JSRef!.Call<IDBObjectStore<TKey, TValue>>("objectStore", storeName);
        /// <summary>
        /// Rolls back all the changes to objects in the database associated with this transaction. If this transaction has been aborted or completed, this method fires an error event.
        /// </summary>
        public void Abort() => JSRef!.CallVoid("abort");
        /// <summary>
        /// For an active transaction, commits the transaction. Note that this doesn't normally have to be called — a transaction will automatically commit when all outstanding requests have been satisfied and no new requests have been made. commit() can be used to start the commit process without waiting for events from outstanding requests to be dispatched.
        /// </summary>
        public void Commit() => JSRef!.CallVoid("commit");
        #endregion
        #region Events
        /// <summary>
        /// An event fired when the IndexedDB transaction is aborted. Also available via the onabort property; this event bubbles to IDBDatabase.
        /// </summary>
        public ActionEvent<Event> OnAbort { get => new ActionEvent<Event>("abort", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// An event fired when the transaction successfully completes. Also available via the oncomplete property.
        /// </summary>
        public ActionEvent<Event> OnComplete { get => new ActionEvent<Event>("complete", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// An event fired when a request returns an error and the event bubbles up to the connection object (IDBDatabase). Also available via the onerror property.
        /// </summary>
        public ActionEvent<Event> OnError { get => new ActionEvent<Event>("error", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}
