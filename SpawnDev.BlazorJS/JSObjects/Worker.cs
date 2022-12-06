using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Worker>))]
    public class Worker : EventTarget
    {
        public delegate void MessageDelegate(MessageEvent msg);
        public event MessageDelegate OnMessage;
        public Worker(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Worker(string url) : base(NullRef)
        {
            FromReference(JS.CreateNew("Worker", url));
        }
        public override void FromReference(IJSInProcessObjectReference _ref)
        {
            base.FromReference(_ref);
            AddEventListener("message", Callback.Create<MessageEvent>((e) => {
                OnMessage?.Invoke(e);
                e.Dispose();
            }));
        }
        public void PostMessaage(object message, IEnumerable<ArrayBuffer> transfer = null)
        {
            if (transfer == null) _ref.CallVoid("postMessage", message);
            else _ref.CallVoid("postMessage", message, transfer);
        }
        public void Terminate() => _ref.CallVoid("terminate");
    }
}
