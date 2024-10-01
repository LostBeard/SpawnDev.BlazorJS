using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The IDBDatabase interface of the IndexedDB API provides a connection to a database; you can use an IDBDatabase object to open a transaction on your database then create, manipulate, and delete objects (data) in that database. The interface provides the only way to get and manage versions of the database.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBDatabase<br/>
    /// W3C spec:<br/>
    /// https://w3c.github.io/IndexedDB/#introduction
    /// </summary>
    public class IDBDatabase : EventTarget
    {
        #region Static helper methods (non-spec)
        private static Lazy<bool> _IsSupported = new Lazy<bool>(() => !JS.IsUndefined("indexedDB"));
        /// <summary>
        /// True is indexedDB global object is found
        /// </summary>
        public static bool IsSupported => _IsSupported.Value;
        public static IDBOpenDBRequest Open(string dbName)
        {
            using var dbFactory = new IDBFactory();
            return dbFactory.Open(dbName);
        }
        public static IDBOpenDBRequest Open(string dbName, long dbVersion)
        {
            using var dbFactory = new IDBFactory();
            return dbFactory.Open(dbName, dbVersion);
        }
        public static Task<IDBDatabase> OpenAsync(string dbName, Action<IDBVersionChangeEvent>? onUpgradeNeeded = null)
        {
            using var dbFactory = new IDBFactory();
            return dbFactory.OpenAsync(dbName, onUpgradeNeeded);
        }
        public static Task<IDBDatabase> OpenAsync(string dbName, long dbVersion, Action<IDBVersionChangeEvent>? onUpgradeNeeded = null)
        {
            using var dbFactory = new IDBFactory();
            return dbFactory.OpenAsync(dbName, dbVersion, onUpgradeNeeded);
        }
        #endregion
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBDatabase(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string that contains the name of the connected database.
        /// </summary>
        public string Name => JSRef!.Get<string>("name");
        /// <summary>
        /// A 64-bit integer that contains the version of the connected database. When a database is first created, this attribute is an empty string.
        /// </summary>
        public long Version => JSRef!.Get<long>("version");
        /// <summary>
        /// A DOMStringList that contains a list of the names of the object stores currently in the connected database.
        /// </summary>
        public string[] ObjectStoreNames => JSRef!.Get<DOMStringList>("objectStoreNames")!;
        /// <summary>
        /// Returns immediately and closes the connection to a database in a separate thread.
        /// </summary>
        public void Close() => JSRef!.CallVoid("close");
        /// <summary>
        /// Creates and returns a new object store or index.
        /// </summary>
        /// <typeparam name="TKey">The type of the value found at TValue[options.KeyPath]</typeparam>
        /// <typeparam name="TValue">The value of the type that is stored</typeparam>
        /// <param name="storeName">The name of the new object store to be created. Note that it is possible to create an object store with an empty name.</param>
        /// <param name="options">An options object whose attributes are optional parameters to the method</param>
        /// <returns>A new IDBObjectStore.</returns>
        public IDBObjectStore<TKey, TValue> CreateObjectStore<TKey, TValue>(string storeName, IDBObjectStoreCreateOptions? options = null) => JSRef!.Call<IDBObjectStore<TKey, TValue>>("createObjectStore", storeName, options);
        /// <summary>
        /// Destroys the object store with the given name in the connected database, along with any indexes that reference it.
        /// </summary>
        /// <param name="storeName">The name of the object store you want to delete. Names are case sensitive.</param>
        public void DeleteObjectStore(string storeName) => JSRef!.CallVoid("deleteObjectStore", storeName);
        /// <summary>
        /// Immediately returns a transaction object (IDBTransaction) containing the IDBTransaction.objectStore method, which you can use to access your object store. Runs in a separate thread.
        /// </summary>
        /// <param name="storeNames">The names of object stores that are in the scope of the new transaction, declared as an array of strings. Specify only the object stores that you need to access. If you need to access only one object store, you can specify its name as a string. Therefore the following lines are equivalent:</param>
        /// <returns>IDBTransaction</returns>
        public IDBTransaction Transaction(Union<string, IEnumerable<string>> storeNames) => JSRef!.Call<IDBTransaction>("transaction", storeNames);
        /// <summary>
        /// Immediately returns a transaction object (IDBTransaction) containing the IDBTransaction.objectStore method, which you can use to access your object store. Runs in a separate thread.
        /// </summary>
        /// <param name="storeNames">The names of object stores that are in the scope of the new transaction, declared as an array of strings. Specify only the object stores that you need to access. If you need to access only one object store, you can specify its name as a string. Therefore the following lines are equivalent:</param>
        /// <param name="mode">The types of access that can be performed in the transaction. Transactions are opened in one of three modes: <br/>
        /// - readonly (default)<br/> 
        /// - readwrite<br/>
        /// - readwriteflush (non-standard, Firefox-only.)<br/>
        /// If you don't provide the parameter, the default access mode is readonly. To avoid slowing things down, don't open a readwrite transaction unless you actually need to write into the database.
        /// </param>
        /// <returns>IDBTransaction</returns>
        public IDBTransaction Transaction(Union<string, IEnumerable<string>> storeNames, string mode) => JSRef!.Call<IDBTransaction>("transaction", storeNames, mode);
        /// <summary>
        /// Immediately returns a transaction object (IDBTransaction) containing the IDBTransaction.objectStore method, which you can use to access your object store. Runs in a separate thread.
        /// </summary>
        /// <param name="storeNames">The names of object stores that are in the scope of the new transaction, declared as an array of strings. Specify only the object stores that you need to access. If you need to access only one object store, you can specify its name as a string. Therefore the following lines are equivalent:</param>
        /// <param name="readWrite">If true, "readwrite" mode will be used. Otherwise "readonly mode will be used."</param>
        /// <returns>IDBTransaction</returns>
        public IDBTransaction Transaction(Union<string, IEnumerable<string>> storeNames, bool readWrite) => JSRef!.Call<IDBTransaction>("transaction", storeNames, readWrite ? "readwrite" : "readonly");
        /// <summary>
        /// Immediately returns a transaction object (IDBTransaction) containing the IDBTransaction.objectStore method, which you can use to access your object store. Runs in a separate thread.
        /// </summary>
        /// <param name="storeNames">The names of object stores that are in the scope of the new transaction, declared as an array of strings. Specify only the object stores that you need to access. If you need to access only one object store, you can specify its name as a string. Therefore the following lines are equivalent:</param>
        /// <param name="mode">The types of access that can be performed in the transaction. Transactions are opened in one of three modes: <br/>
        /// - readonly (default)<br/> 
        /// - readwrite<br/>
        /// - readwriteflush (non-standard, Firefox-only.)<br/>
        /// If you don't provide the parameter, the default access mode is readonly. To avoid slowing things down, don't open a readwrite transaction unless you actually need to write into the database.
        /// </param>
        /// <param name="options">Additional options</param>
        /// <returns>IDBTransaction</returns>
        public IDBTransaction Transaction(Union<string, IEnumerable<string>> storeNames, string mode, IDBDatabaseTransactionOptions options) => JSRef!.Call<IDBTransaction>("transaction", storeNames, mode, options);
        /// <summary>
        /// Immediately returns a transaction object (IDBTransaction) containing the IDBTransaction.objectStore method, which you can use to access your object store. Runs in a separate thread.
        /// </summary>
        /// <param name="storeNames">The names of object stores that are in the scope of the new transaction, declared as an array of strings. Specify only the object stores that you need to access. If you need to access only one object store, you can specify its name as a string. Therefore the following lines are equivalent:</param>
        /// <param name="readWrite">If true, "readwrite" mode will be used. Otherwise "readonly mode will be used."</param>
        /// <param name="options">Additional options</param>
        /// <returns>IDBTransaction</returns>
        public IDBTransaction Transaction(Union<string, IEnumerable<string>> storeNames, bool readWrite, IDBDatabaseTransactionOptions options) => JSRef!.Call<IDBTransaction>("transaction", storeNames, readWrite ? "readwrite" : "readonly", options);
    }
}
