using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Worker>))]
    public class Worker : MessagePort
    {
        public Worker(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Worker(string url) : base(NullRef)
        {
            FromReference(JS.CreateNew("Worker", url));
        }
        public void Terminate() => JSRef.CallVoid("terminate");
    }
    //[JsonConverter(typeof(JSObjectConverter<Worker>))]
    //public class Worker : JSObject
    //{
    //    CallbackGroup _callbacks = new CallbackGroup();
    //    public delegate void MessageDelegate(MessageEvent msg);
    //    public event MessageDelegate OnMessage;
    //    public Worker(IJSInProcessObjectReference _ref) : base(_ref) { }
    //    public Worker(string url) : base(NullRef)
    //    {
    //        FromReference(JS.CreateNew("Worker", url));
    //    }
    //    protected override void FromReference(IJSInProcessObjectReference _ref)
    //    {
    //        base.FromReference(_ref);
    //        AddEventListener("message", Callback.Create<MessageEvent>((e) => {
    //            OnMessagePre(e);
    //            e.Dispose();
    //        }, _callbacks));
    //    }

    //    public override void Dispose()
    //    {
    //        _callbacks.Dispose();
    //        base.Dispose();
    //    }

    //    protected virtual void OnMessagePre(MessageEvent e)
    //    {
    //        OnMessage?.Invoke(e);
    //    }

    //    public void PostMessaage(object message, IEnumerable<object>? transfer = null)
    //    {
    //        if (transfer == null) JSRef.CallVoid("postMessage", message);
    //        else JSRef.CallVoid("postMessage", message, transfer);
    //    }

    //    public void PostMessaage(string message) => JSRef.CallVoid("postMessage", message);

    //    public void Terminate() => JSRef.CallVoid("terminate");
    //}
}
