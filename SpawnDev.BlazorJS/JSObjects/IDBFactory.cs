using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The IDBFactory interface of the IndexedDB API lets applications asynchronously access the indexed databases. The object that implements the interface is window.indexedDB. You open — that is, create and access — and delete a database with this object, and not directly with IDBFactory.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBFactory
    /// </summary>
    public class IDBFactory : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBFactory(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the global instance indexedDB
        /// </summary>
        public IDBFactory() : base(JS.Get<IJSInProcessObjectReference>("indexedDB")) { }
        /// <summary>
        /// The current method to request opening a connection to a database.
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbVersion"></param>
        /// <returns></returns>
        public IDBOpenDBRequest Open(string dbName, long dbVersion) => JSRef!.Call<IDBOpenDBRequest>("open", dbName, dbVersion);
        /// <summary>
        /// The current method to request opening a connection to a database.
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public IDBOpenDBRequest Open(string dbName) => JSRef!.Call<IDBOpenDBRequest>("open", dbName);
        /// <summary>
        /// The current async method to request opening a connection to a database.
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="onUpgradeNeeded"></param>
        /// <returns></returns>
        public Task<IDBDatabase> OpenAsync(string dbName, Action<IDBVersionChangeEvent>? onUpgradeNeeded = null)
        {
            var openRequest = Open(dbName);
            var tcs = new TaskCompletionSource<IDBDatabase>();
            if (onUpgradeNeeded != null) openRequest.OnUpgradeNeeded += onUpgradeNeeded;
            Action<string?, IDBDatabase?>? onComplete = null;
            var onSuccess = new Action(() =>
            {
                var result = openRequest.Result;
                onComplete?.Invoke(null, result);
            });
            var onError = new Action(() =>
            {
                onComplete?.Invoke("Open failed", null);
            });
            openRequest.OnSuccess += onSuccess;
            openRequest.OnError += onError;
            onComplete = new Action<string?, IDBDatabase?>((error, result) =>
            {
                onComplete = null;
                openRequest.OnSuccess -= onSuccess;
                openRequest.OnError -= onError;
                if (onUpgradeNeeded != null) openRequest.OnUpgradeNeeded -= onUpgradeNeeded;
                if (result == null && string.IsNullOrEmpty(error)) error = "Open failed";
                if (result == null)
                {
                    tcs.TrySetException(new Exception(error));
                }
                else
                {
                    tcs.TrySetResult(result);
                }
                openRequest.Dispose();
            });
            return tcs.Task;
        }
        /// <summary>
        /// The current async method to request opening a connection to a database.
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="dbVersion"></param>
        /// <param name="onUpgradeNeeded"></param>
        /// <returns></returns>
        public Task<IDBDatabase> OpenAsync(string dbName, long dbVersion, Action<IDBVersionChangeEvent>? onUpgradeNeeded = null)
        {
            var openRequest = Open(dbName, dbVersion);
            var tcs = new TaskCompletionSource<IDBDatabase>();
            Action<string?, IDBDatabase?>? onComplete = null;
            var onSuccess = new Action(() =>
            {
                var result = openRequest.Result;
                onComplete?.Invoke(null, result);
            });
            var onError = new Action(() =>
            {
                onComplete?.Invoke("Open failed", null);
            });
            openRequest.OnSuccess += onSuccess;
            openRequest.OnError += onError;
            if (onUpgradeNeeded != null) openRequest.OnUpgradeNeeded += onUpgradeNeeded;
            onComplete = new Action<string?, IDBDatabase?>((error, result) =>
            {
                onComplete = null;
                openRequest.OnSuccess -= onSuccess;
                openRequest.OnError -= onError;
                if (onUpgradeNeeded != null) openRequest.OnUpgradeNeeded -= onUpgradeNeeded;
                if (result == null && string.IsNullOrEmpty(error)) error = "Open failed";
                if (result == null)
                {
                    tcs.TrySetException(new Exception(error));
                }
                else
                {
                    tcs.TrySetResult(result);
                }
                openRequest.Dispose();
            });
            return tcs.Task;
        }
        /// <summary>
        /// A method to request the deletion of a database.
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public IDBOpenDBRequest DeleteDatabase(string dbName) => JSRef!.Call<IDBOpenDBRequest>("deleteDatabase", dbName);
        /// <summary>
        /// A method to request the deletion of a database.
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public Task DeleteDatabaseAsync(string dbName) => JSRef!.Call<IDBOpenDBRequest>("deleteDatabase", dbName).WaitAsync();
        /// <summary>
        /// A method that returns a list of all available databases, including their names and versions.
        /// </summary>
        /// <returns></returns>
        public Task<List<IDBDatabaseInfo>> Databases() => JSRef!.CallAsync<List<IDBDatabaseInfo>>("databases");
        /// <summary>
        /// The cmp() method of the IDBFactory interface compares two values as keys to determine equality and ordering for IndexedDB operations, such as storing and iterating.<br/>
        /// 
        /// </summary>
        /// <param name="first">The first key to compare.</param>
        /// <param name="second">The second key to compare.</param>
        /// <returns>An integer that indicates the result of the comparison:<br/>
        /// -1 - 1st key is less than the 2nd key<br/>
        ///  0 - 1st key is equal to the 2nd key<br/>
        ///  1 - 1st key is greater than the 2nd key
        /// </returns>
        public int Cmp<TKey>(TKey first, TKey second) => JSRef!.Call<int>("cmp", first, second);
    }
}
