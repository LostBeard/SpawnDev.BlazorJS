using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class IDBFactory : JSObject
    {
        public IDBFactory(IJSInProcessObjectReference _ref) : base(_ref) { }
        public IDBFactory() : base(JS.Get<IJSInProcessObjectReference>("indexedDB")) { }
        public IDBOpenRequest Open(string dbName, ulong dbVersion) => JSRef.Call<IDBOpenRequest>("open", dbName, dbVersion);
        public IDBOpenRequest Open(string dbName) => JSRef.Call<IDBOpenRequest>("open", dbName);
        public IDBOpenRequest DeleteDatabase(string dbName) => JSRef.Call<IDBOpenRequest>("deleteDatabase", dbName);
        public Task<IDBDatabase> OpenAsync(string dbName, Action<IDBVersionChangeEvent>? onUpgradeNeeded = null)
        {
            var openRequest = Open(dbName);
            var tcs = new TaskCompletionSource<IDBDatabase>();
            if (onUpgradeNeeded != null) openRequest.OnUpgradeNeeded += onUpgradeNeeded;
            Action<string?, IDBDatabase?>? onComplete = null;
            var onSuccess = new Action(() =>
            {
                var result = openRequest.ResultAs<IDBDatabase>();
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
        public Task<IDBDatabase> OpenAsync(string dbName, ulong dbVersion, Action<IDBVersionChangeEvent>? onUpgradeNeeded = null)
        {
            var openRequest = Open(dbName, dbVersion);
            var tcs = new TaskCompletionSource<IDBDatabase>();
            if (onUpgradeNeeded != null) openRequest.OnUpgradeNeeded += onUpgradeNeeded;
            Action<string?, IDBDatabase?>? onComplete = null;
            var onSuccess = new Action(() =>
            {
                var result = openRequest.ResultAs<IDBDatabase>();
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
    }
}
