using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Document : Node {
        public Document(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Element ActiveElement => JSRef.Get<Element>("sctiveElement");
        public T CreateElement<T>(string tagName) where T : JSObject => JSRef.Call<T>("createElement", tagName);
        public IJSInProcessObjectReference CreateElement(string tagName) => JSRef.Call<IJSInProcessObjectReference>("createElement", tagName);
        public Task ExitFullscreen() => JSRef.CallVoidAsync("exitFullscreen");
    }
}
