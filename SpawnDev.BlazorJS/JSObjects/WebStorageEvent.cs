using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<WebStorageEvent>))]
    public class WebStorageEvent : JSObject
    {
        public WebStorageEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string Key => JSRef.Get<string>("key");
        public string OldValue => JSRef.Get<string>("oldValue");
        public string NewValue => JSRef.Get<string>("newValue");
        public string Url => JSRef.Get<string>("url");
    }
}
