using Microsoft.JSInterop;
using System.Dynamic;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class IDBDatabase : EventTarget
    {
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

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBDatabase(IJSInProcessObjectReference _ref) : base(_ref) { }

        public DOMStringList ObjectStoreNames => JSRef.Get<DOMStringList>("objectStoreNames");

        public void Close() => JSRef.CallVoid("close");

        public IDBObjectStore CreateObjectStore(string storeName, IDBObjectStoreCreateOptions? options = null) => options == null ?
            JSRef.Call<IDBObjectStore>("createObjectStore", storeName) :
            JSRef.Call<IDBObjectStore>("createObjectStore", storeName, options);

        public IDBObjectStore<TKey, TValue> CreateObjectStore<TKey, TValue>(string storeName, IDBObjectStoreCreateOptions? options = null) => options == null ?
            JSRef.Call<IDBObjectStore<TKey, TValue>>("createObjectStore", storeName) :
            JSRef.Call<IDBObjectStore<TKey, TValue>>("createObjectStore", storeName, options);

        public void DeleteObjectStore(string storeName) => JSRef.CallVoid("deleteObjectStore", storeName);

        public IDBTransaction Transaction(Union<string, IEnumerable<string>> storeNames, bool readWrite = true) => JSRef.Call<IDBTransaction>("transaction", storeNames, readWrite ? "readwrite" : "readonly");

        public IDBTransaction Transaction(Union<string, IEnumerable<string>> storeNames, string mode) => JSRef.Call<IDBTransaction>("transaction", storeNames, mode);
    }
}
