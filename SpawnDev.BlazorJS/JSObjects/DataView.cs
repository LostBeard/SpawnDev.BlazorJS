using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/DataView/byteOffset
    public class DataView : JSObject
    {
        public DataView(ArrayBuffer arrayBuffer) : base(JS.New(nameof(DataView), arrayBuffer)) { }
        public DataView(IJSInProcessObjectReference _ref) : base(_ref) { }
        public ArrayBuffer Buffer => JSRef.Get<ArrayBuffer>("buffer");
        public long ByteLength => JSRef.Get<long>("byteLength");
        public long ByteOffset => JSRef.Get<long>("byteOffset");
        
        // TODO finish methods
    }
}
