using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class IDBTransaction : JSObject
    {
        public IDBTransaction(IJSInProcessObjectReference _ref) : base(_ref) { }
        public IDBObjectStore<TValue> ObjectStore<TValue>(string storeName) => JSRef.Call<IDBObjectStore<TValue>>("objectStore", storeName);
        public IDBObjectStore<TKey, TValue> ObjectStore<TKey, TValue>(string storeName) => JSRef.Call<IDBObjectStore<TKey, TValue>>("objectStore", storeName);
        public void Abort(string key) => JSRef.CallVoid("abort", key);
        public void Commit() => JSRef.CallVoid("commit");
    }
}
