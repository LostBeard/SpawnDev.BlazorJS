using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class MessageEvent : JSObject {
        public MessageEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public T GetData<T>() => JSRef.Get<T>("data");
    }
}
