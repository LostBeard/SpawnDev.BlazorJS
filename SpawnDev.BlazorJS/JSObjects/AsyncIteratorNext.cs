using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class AsyncIteratorNext : JSObject {
        public AsyncIteratorNext(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Done => JSRef.Get<bool>("done");
        public T GetValue<T>() => JSRef.Get<T>("value");
        public JSObject GetValue() => JSRef.Get<JSObject>("value");
    }
}
