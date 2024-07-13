using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class IteratorResult : JSObject {
        public IteratorResult(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Done => JSRef!.Get<bool>("done");
        public T GetValue<T>() => JSRef!.Get<T>("value");
    }
    public class IteratorResult<TValue> : JSObject
    {
        public IteratorResult(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Done => JSRef!.Get<bool>("done");
        public TValue Value => JSRef!.Get<TValue>("value");
    }
}
