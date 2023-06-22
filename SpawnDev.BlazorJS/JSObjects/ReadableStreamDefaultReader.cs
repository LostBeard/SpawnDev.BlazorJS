using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamDefaultReader
    public class ReadableStreamDefaultReader : JSObject
    {
        public ReadableStreamDefaultReader(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Closed => JSRef.Get<bool>("closed");
        public Task Cancel() => JSRef.CallVoidAsync("cancel");
        public Task<ReadableStreamReaderReadResponse> Read() => JSRef.CallAsync<ReadableStreamReaderReadResponse>("read");
        public void ReleaseLock() => JSRef.CallVoid("releaseLock");
    }
}
