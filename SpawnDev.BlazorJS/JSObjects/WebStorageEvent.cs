using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<WebStorageEvent>))]
    public class WebStorageEvent : JSObject
    {
        public WebStorageEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string Key => _ref.Get<string>("key");
        public string OldValue => _ref.Get<string>("oldValue");
        public string NewValue => _ref.Get<string>("newValue");
        public string Url => _ref.Get<string>("url");
    }
}
