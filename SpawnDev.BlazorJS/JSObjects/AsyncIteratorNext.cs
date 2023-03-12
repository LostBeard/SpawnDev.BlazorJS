using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<AsyncIteratorNext>))]
    public class AsyncIteratorNext : JSObject
    {
        public AsyncIteratorNext(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Done => JSRef.Get<bool>("done");
        public T GetValue<T>() => JSRef.Get<T>("value");
        public JSObject GetValue() => JSRef.Get<JSObject>("value");
    }
}
