using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<ServiceWorker>))]
    public class ServiceWorker : EventTarget
    {
        public string State => JSRef.Get<string>("state");
        public string ScriptURL => JSRef.Get<string>("scriptURL");
        public delegate void MessageDelegate(MessageEvent msg);
        public event MessageDelegate OnStateChange;
        public static bool IsSupported => !JS.IsUndefined("navigator.serviceWorker");
        public ServiceWorker(IJSInProcessObjectReference _ref) : base(_ref) { }

        public ServiceWorker(string serviceWorkerSrc) : base(NullRef)
        {
            using var serviceWorkerContainer = JS.Get<ServiceWorkerContainer>("navigator.serviceWorker");
            // TODO
            throw new System.Exception("TODO ServiceWorker() constructor unfinshed");
        }

        //public ServiceWorker(string url) : base(NullRef)
        //{
        //    FromReference(CreateNew("Worker", url));
        //}
        public override void FromReference(IJSInProcessObjectReference _ref)
        {
            base.FromReference(_ref);
            AddEventListener("statechange", Callback.Create<MessageEvent>((e) => {
                OnStateChange?.Invoke(e);
                e.Dispose();
            }));
        }
        //public void PostMessaage(object message, IEnumerable<ArrayBuffer> transfer = null)
        //{
        //    if (transfer == null) _ref.CallVoid("postMessage", message);
        //    else _ref.CallVoid("postMessage", message, transfer);
        //}
        //public void Terminate() => _ref.CallVoid("terminate");
    }
}
