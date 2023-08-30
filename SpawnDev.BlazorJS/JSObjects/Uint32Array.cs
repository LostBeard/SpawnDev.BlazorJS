using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Uint32Array : TypedArray
    {
        public Uint32Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Uint32Array() : base(JS.New(nameof(Uint32Array))) { }
        public Uint32Array(long length) : base(JS.New(nameof(Uint32Array), length)) { }
        public Uint32Array(TypedArray typedArray) : base(JS.New(nameof(Uint32Array), typedArray)) { }
        public Uint32Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Uint32Array), arrayBuffer)) { }
        public Uint32Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Uint32Array), arrayBuffer, byteOffset)) { }
        public Uint32Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint32Array), arrayBuffer, byteOffset, length)) { }
        public Uint32Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Uint32Array), sharedArrayBuffer)) { }
        public Uint32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Uint32Array), sharedArrayBuffer, byteOffset)) { }
        public Uint32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint32Array), sharedArrayBuffer, byteOffset, length)) { }
    }
}
