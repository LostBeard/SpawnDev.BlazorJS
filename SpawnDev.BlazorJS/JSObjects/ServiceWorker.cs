using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class ServiceWorker : EventTarget {
        CallbackGroup _callbacks = new CallbackGroup();
        public string State => JSRef.Get<string>("state");
        public string ScriptURL => JSRef.Get<string>("scriptURL");
        public delegate void MessageDelegate(MessageEvent msg);
        public event MessageDelegate OnStateChange;
        public static bool IsSupported => !JS.IsUndefined("navigator.serviceWorker");
        public ServiceWorker(IJSInProcessObjectReference _ref) : base(_ref) { }

        //public ServiceWorker(string serviceWorkerSrc) : base(NullRef)
        //{
        //    using var serviceWorkerContainer = JS.Get<ServiceWorkerContainer>("navigator.serviceWorker");
        //    // TODO
        //    throw new System.Exception("TODO ServiceWorker() constructor unfinshed");
        //}

        //public ServiceWorker(string url) : base(NullRef)
        //{
        //    FromReference(CreateNew("Worker", url));
        //}
        protected override void FromReference(IJSInProcessObjectReference _ref) {
            base.FromReference(_ref);
            AddEventListener("statechange", Callback.Create<MessageEvent>((e) => {
                OnStateChange?.Invoke(e);
                e.Dispose();
            }, _callbacks));
        }
        public override void Dispose() {
            _callbacks.Dispose();
            base.Dispose();
        }
        //public void PostMessaage(object message, IEnumerable<ArrayBuffer> transfer = null)
        //{
        //    if (transfer == null) _ref.CallVoid("postMessage", message);
        //    else _ref.CallVoid("postMessage", message, transfer);
        //}
        //public void Terminate() => _ref.CallVoid("terminate");
    }
}
