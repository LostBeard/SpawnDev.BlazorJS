using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Int16Array : TypedArray
    {
        public Int16Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Int16Array() : base(JS.New(nameof(Int16Array))) { }
        public Int16Array(long length) : base(JS.New(nameof(Int16Array), length)) { }
        public Int16Array(TypedArray typedArray) : base(JS.New(nameof(Int16Array), typedArray)) { }
        public Int16Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Int16Array), arrayBuffer)) { }
        public Int16Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Int16Array), arrayBuffer, byteOffset)) { }
        public Int16Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Int16Array), arrayBuffer, byteOffset, length)) { }
        public Int16Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Int16Array), sharedArrayBuffer)) { }
        public Int16Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Int16Array), sharedArrayBuffer, byteOffset)) { }
        public Int16Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Int16Array), sharedArrayBuffer, byteOffset, length)) { }
    }
}
