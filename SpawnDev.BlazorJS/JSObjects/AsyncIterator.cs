using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class AsyncIterator : JSObject {
        public AsyncIterator(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Task<AsyncIteratorNext> Next() => JSRef.CallAsync<AsyncIteratorNext>("next");
    }
}
