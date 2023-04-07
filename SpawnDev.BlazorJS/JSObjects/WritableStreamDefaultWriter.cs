using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class WritableStreamDefaultWriter : JSObject
    {
        public WritableStreamDefaultWriter(WritableStream writableStream) : base(JS.New(nameof(WritableStreamDefaultWriter), writableStream)) { }
        public WritableStreamDefaultWriter(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Closed => JSRef.Get<bool>("closed");
        public int DesiredSize => JSRef.Get<int>("desiredSize");
        public Task Ready => JSRef.Get<Task>("ready");
        public void Abort() => JSRef.CallVoid("abort");
        public void Close() => JSRef.CallVoid("close");
        public void ReleaseLock() => JSRef.CallVoid("releaseLock");
        public Task Write(object chunk) => JSRef.CallVoidAsync("write", chunk);
    }
}
