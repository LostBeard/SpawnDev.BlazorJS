using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {

    public class Uint8ClampedArray : TypedArray
    {
        public Uint8ClampedArray(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Uint8ClampedArray(byte[] uint8Array) : base(JS.New(nameof(Uint8ClampedArray), uint8Array)) { }
        public Uint8ClampedArray(TypedArray typedArray) : base(JS.New(nameof(Uint8ClampedArray), typedArray)) { }
        public Uint8ClampedArray(long length) : base(JS.New(nameof(Uint8ClampedArray), length)) { }
        public Uint8ClampedArray(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Uint8ClampedArray), arrayBuffer)) { }
        public Uint8ClampedArray(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Uint8ClampedArray), arrayBuffer, byteOffset)) { }
        public Uint8ClampedArray(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint8ClampedArray), arrayBuffer, byteOffset, length)) { }
    }
}
