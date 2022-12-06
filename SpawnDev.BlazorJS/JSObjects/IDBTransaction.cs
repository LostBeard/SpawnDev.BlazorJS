using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<IDBTransaction>))]
    public class IDBTransaction : JSObject
    {
        public IDBTransaction(IJSInProcessObjectReference _ref) : base(_ref) { }
        public IDBObjectStore ObjectStore(string storeName) => _ref.Call<IDBObjectStore>("objectStore", storeName);
        public void Abort(string key) => _ref.CallVoid("abort", key);
        public void Commit() => _ref.CallVoid("commit");
    }
}
