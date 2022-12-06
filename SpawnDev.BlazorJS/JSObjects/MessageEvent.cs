using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<MessageEvent>))]
    public class MessageEvent : JSObject
    {
        public MessageEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public T GetData<T>() => JSRef.Call<T>("data");
    }
}
