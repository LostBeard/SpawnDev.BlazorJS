using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Int8Array : TypedArray
    {
        public Int8Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Int8Array() : base(JS.New(nameof(Int8Array))) { }
        public Int8Array(long length) : base(JS.New(nameof(Int8Array), length)) { }
        public Int8Array(TypedArray typedArray) : base(JS.New(nameof(Int8Array), typedArray)) { }
        public Int8Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Int8Array), arrayBuffer)) { }
        public Int8Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Int8Array), arrayBuffer, byteOffset)) { }
        public Int8Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Int8Array), arrayBuffer, byteOffset, length)) { }
        public Int8Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Int8Array), sharedArrayBuffer)) { }
        public Int8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Int8Array), sharedArrayBuffer, byteOffset)) { }
        public Int8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Int8Array), sharedArrayBuffer, byteOffset, length)) { }
    }
}
