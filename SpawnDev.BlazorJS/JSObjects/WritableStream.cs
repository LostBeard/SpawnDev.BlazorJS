using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class WritableStream : JSObject {
        public WritableStream(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Locked => JSRef.Get<bool>("locked");
        public void Abort() => JSRef.CallVoid("abort");
        public void Close() => JSRef.CallVoid("close");
        public WritableStreamDefaultWriter GetWriter() => JSRef.Call<WritableStreamDefaultWriter>("getWriter");
    }
}
