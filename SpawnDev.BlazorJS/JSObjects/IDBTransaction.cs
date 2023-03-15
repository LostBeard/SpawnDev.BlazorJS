using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class IDBTransaction : JSObject {
        public IDBTransaction(IJSInProcessObjectReference _ref) : base(_ref) { }
        public IDBObjectStore ObjectStore(string storeName) => JSRef.Call<IDBObjectStore>("objectStore", storeName);
        public void Abort(string key) => JSRef.CallVoid("abort", key);
        public void Commit() => JSRef.CallVoid("commit");
    }
}
