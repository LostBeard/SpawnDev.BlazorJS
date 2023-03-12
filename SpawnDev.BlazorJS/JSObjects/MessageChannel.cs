using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Dynamic;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<MessageChannel>))]
    public class MessageChannel : JSObject
    {
        public MessageChannel(IJSInProcessObjectReference _ref) : base(_ref) { }
        public MessageChannel(ExpandoObject options) : base(JS.New(nameof(MessageChannel), options)) { }
        public MessageChannel() : base(JS.New(nameof(MessageChannel))) { }
        public MessagePort Port1 => JSRef.Get<MessagePort>("port1");
        public MessagePort Port2 => JSRef.Get<MessagePort>("port2");
    }
}
