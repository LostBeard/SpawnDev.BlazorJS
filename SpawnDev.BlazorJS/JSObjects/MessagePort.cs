using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/MessagePort
    [JsonConverter(typeof(JSObjectConverter<MessagePort>))]
    public class MessagePort : EventTarget
    {
        CallbackGroup _callbacks = new CallbackGroup();
        public delegate void ErrorDelete();
        public event ErrorDelete OnError;
        public delegate void MessageDelegate(MessageEvent msg);
        public event MessageDelegate OnMessage;
        public MessagePort(IJSInProcessObjectReference _ref) : base(_ref) { }
        protected override void FromReference(IJSInProcessObjectReference _ref)
        {
            base.FromReference(_ref);
            AddEventListener("message", Callback.Create<MessageEvent>((e) => {
                OnMessagePre(e);
                e.Dispose();
            }, _callbacks));
            AddEventListener("error", Callback.Create<MessageEvent>((e) => {
                OnErrorPre();
                e.Dispose();
            }, _callbacks));
        }

        protected virtual void OnMessagePre(MessageEvent e)
        {
            OnMessage?.Invoke(e);
        }

        protected virtual void OnErrorPre()
        {
            OnError?.Invoke();
        }

        public void Start() => JSRef.CallVoid("start");
        //public void PostMessage(string message, object[]? transferList = null) => JSRef.CallVoid("postMessage", message, transferList);
        public void PostMessage(object message, object[]? transfer = null)
        {
            if (transfer == null) JSRef.CallVoid("postMessage", message);
            else JSRef.CallVoid("postMessage", message, transfer);
        }

        public override void Dispose()
        {
            _callbacks.Dispose();
            base.Dispose();
        }
    }
}
