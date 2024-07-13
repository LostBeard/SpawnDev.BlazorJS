using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class ResizeObserver : JSObject {
        public ResizeObserver(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ResizeObserver(ActionCallback<ResizeObserverEntry[]> callback) : base(JS.New(nameof(ResizeObserver), callback)) { }
        public ResizeObserver(Callback callback) : base(JS.New(nameof(ResizeObserver), callback)) { }
        public void Observe(IJSInProcessObjectReference el) => JSRef!.CallVoid("observe", el);
        public void Unobserve(IJSInProcessObjectReference el) => JSRef!.CallVoid("unobserve", el);
        public void Observe(ElementReference el) => JSRef!.CallVoid("observe", el);
        public void Unobserve(ElementReference el) => JSRef!.CallVoid("unobserve", el);
    }
}
