using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Worker>))]
    public class Worker : EventTarget
    {
        CallbackGroup _callbacks = new CallbackGroup();
        public delegate void MessageDelegate(MessageEvent msg);
        public event MessageDelegate OnMessage;
        public Worker(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Worker(string url) : base(NullRef)
        {
            FromReference(JS.CreateNew("Worker", url));
        }
        protected override void FromReference(IJSInProcessObjectReference _ref)
        {
            base.FromReference(_ref);
            AddEventListener("message", Callback.Create<MessageEvent>((e) => {
                OnMessage?.Invoke(e);
                e.Dispose();
            }, _callbacks));
        }
        public override void Dispose()
        {
            _callbacks.Dispose();
            base.Dispose();
        }
        public void PostMessaage(object message, IEnumerable<ArrayBuffer>? transfer = null)
        {
            if (transfer == null) JSRef.CallVoid("postMessage", message);
            else JSRef.CallVoid("postMessage", message, transfer);
        }
        public void Terminate() => JSRef.CallVoid("terminate");
    }
}
