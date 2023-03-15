using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class ReadableStreamReaderReadResponse : JSObject {
        public ReadableStreamReaderReadResponse(IJSInProcessObjectReference _ref) : base(_ref) { }
        public bool Done => JSRef.Get<bool>("done");
        public Uint8Array Value => JSRef.Get<Uint8Array>("value");
    }
}
