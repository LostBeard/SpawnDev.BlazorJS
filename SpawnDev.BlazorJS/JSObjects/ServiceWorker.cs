using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class ServiceWorker : EventTarget {
        public string State => JSRef.Get<string>("state");
        public string ScriptURL => JSRef.Get<string>("scriptURL");
        public static bool IsSupported => !JS.IsUndefined("navigator.serviceWorker");
        public ServiceWorker(IJSInProcessObjectReference _ref) : base(_ref) { }
        public JSEventCallback OnStateChange { get => new JSEventCallback(o => AddEventListener("statechange", o), o => RemoveEventListener("statechange", o)); set { } }
    }
}
