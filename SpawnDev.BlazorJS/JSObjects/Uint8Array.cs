using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Uint8Array : TypedArray
    {
        public Uint8Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Uint8Array() : base(JS.New(nameof(Uint8Array))) { }
        public Uint8Array(long length) : base(JS.New(nameof(Uint8Array), length)) { }
        public Uint8Array(TypedArray typedArray) : base(JS.New(nameof(Uint8Array), typedArray)) { }
        public Uint8Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Uint8Array), arrayBuffer)) { }
        public Uint8Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Uint8Array), arrayBuffer, byteOffset)) { }
        public Uint8Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint8Array), arrayBuffer, byteOffset, length)) { }
        public Uint8Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Uint8Array), sharedArrayBuffer)) { }
        public Uint8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Uint8Array), sharedArrayBuffer, byteOffset)) { }
        public Uint8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint8Array), sharedArrayBuffer, byteOffset, length)) { }
        public Uint8Array(byte[] sourceBytes) : base(JS.ReturnMe<IJSInProcessObjectReference>(sourceBytes)) { }
        public override byte[] ReadBytes() => JS.ReturnMe<byte[]>(JSRef);
    }
}
