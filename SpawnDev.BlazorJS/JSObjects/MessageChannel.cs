using Microsoft.JSInterop;
using System.Dynamic;

namespace SpawnDev.BlazorJS.JSObjects {
    public class MessageChannel : JSObject {
        public MessageChannel(IJSInProcessObjectReference _ref) : base(_ref) { }
        public MessageChannel(ExpandoObject options) : base(JS.New(nameof(MessageChannel), options)) { }
        public MessageChannel() : base(JS.New(nameof(MessageChannel))) { }
        public MessagePort Port1 => JSRef.Get<MessagePort>("port1");
        public MessagePort Port2 => JSRef.Get<MessagePort>("port2");
    }
}
