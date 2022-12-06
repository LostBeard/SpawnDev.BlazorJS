using Microsoft.JSInterop;
using System.Dynamic;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<MessageChannel>))]
    public class MessageChannel : JSObject
    {
        public MessageChannel(IJSInProcessObjectReference _ref) : base(_ref) { }
        public MessageChannel(ExpandoObject options) : base("MessageChannel", options) { }
        public MessageChannel() : base("MessageChannel") { }
        public MessagePort Port1 => _ref.Get<MessagePort>("port1");
        public MessagePort Port2 => _ref.Get<MessagePort>("port2");
    }
}
