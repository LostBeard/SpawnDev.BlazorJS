using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Int32Array : TypedArray
    {
        public Int32Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Int32Array() : base(JS.New(nameof(Int32Array))) { }
        public Int32Array(long length) : base(JS.New(nameof(Int32Array), length)) { }
        public Int32Array(TypedArray typedArray) : base(JS.New(nameof(Int32Array), typedArray)) { }
        public Int32Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Int32Array), arrayBuffer)) { }
        public Int32Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Int32Array), arrayBuffer, byteOffset)) { }
        public Int32Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Int32Array), arrayBuffer, byteOffset, length)) { }
        public Int32Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Int32Array), sharedArrayBuffer)) { }
        public Int32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Int32Array), sharedArrayBuffer, byteOffset)) { }
        public Int32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Int32Array), sharedArrayBuffer, byteOffset, length)) { }
    }
}
