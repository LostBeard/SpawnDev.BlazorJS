using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Uint8Array : TypedArray
    {
        public Uint8Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Uint8Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Uint8Array), arrayBuffer)) { }
        public Uint8Array(long length) : base(JS.New(nameof(Uint8Array), length)) { }
        public Uint8Array(byte[] sourceBytes) : base(JS.ReturnMe<IJSInProcessObjectReference>(sourceBytes)) { }
        public override byte[] ReadBytes() => JS.ReturnMe<byte[]>(JSRef);
    }
}
