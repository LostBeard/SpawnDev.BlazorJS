using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Document : Node {
        public Document(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Element ActiveElement => JSRef.Get<Element>("activeElement");
        public T CreateElement<T>(string tagName) where T : JSObject => JSRef.Call<T>("createElement", tagName);
        public IJSInProcessObjectReference CreateElement(string tagName) => JSRef.Call<IJSInProcessObjectReference>("createElement", tagName);
        public Task ExitFullscreen() => JSRef.CallVoidAsync("exitFullscreen");
        public Element? FullscreenElement => JSRef.Get<Element?>("fullscreenElement");
        public JSEventCallback OnFullscreenChange { get => new JSEventCallback(o => AddEventListener("fullscreenchange", o), o => RemoveEventListener("fullscreenchange", o)); set { } }
        public HTMLHeadElement Head => JSRef.Get<HTMLHeadElement>("head");
        public HTMLBodyElement Body => JSRef.Get<HTMLBodyElement>("body");
    }
}
