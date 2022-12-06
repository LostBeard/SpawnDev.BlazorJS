using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<AsyncIteratorNext>))]
    public class AsyncIteratorNext : JSObject
    {
        public AsyncIteratorNext(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Done => _ref.Get<bool>("done");
        public T GetValue<T>() => _ref.Call<T>("value");
        public JSObject GetValue() => _ref.Call<JSObject>("value");
    }
}
