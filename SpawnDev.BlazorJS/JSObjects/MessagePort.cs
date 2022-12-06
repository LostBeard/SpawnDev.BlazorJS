using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<MessagePort>))]
    public class MessagePort : JSObject
    {
        public MessagePort(IJSInProcessObjectReference _ref) : base(_ref) { }
        private Callback _OnMessage = null;
        public Callback OnMessage
        {
            get
            {
                return _OnMessage;
            }
            set
            {
                _OnMessage?.Dispose();
                _OnMessage = value;
                JSRef.Set("onmessage", _OnMessage);
            }
        }
        public void PostMessage(string message, object[] transferList = null) => JSRef.CallVoid("postMessage", message, transferList);
        public void PostMessage<T>(T message, object[] transferList = null) => JSRef.CallVoid("postMessage", message, transferList);
        public override void Dispose()
        {
            if (IsWrapperDisposed) return;
            base.Dispose();
            _OnMessage?.Dispose();
            _OnMessage = null;
            //callbacks.Dispose();
        }
    }
}
