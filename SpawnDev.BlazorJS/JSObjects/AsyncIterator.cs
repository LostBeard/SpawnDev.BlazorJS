using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class AsyncIterator : JSObject {
        public AsyncIterator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Task<IteratorResult> Next() => JSRef.CallAsync<IteratorResult>("next");
    }
    public class AsyncIterator<TValue> : JSObject
    {
        public AsyncIterator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Task<IteratorResult<TValue>> Next() => JSRef.CallAsync<IteratorResult<TValue>>("next");
    }
}
