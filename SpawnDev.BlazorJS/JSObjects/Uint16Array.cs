using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Uint16Array : TypedArray {
        public Uint16Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Uint16Array() : base(JS.New(nameof(Uint16Array))) { }
        public Uint16Array(long length) : base(JS.New(nameof(Uint16Array), length)) { }
        public Uint16Array(TypedArray typedArray) : base(JS.New(nameof(Uint16Array), typedArray)) { }
        public Uint16Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Uint16Array), arrayBuffer)) { }
        public Uint16Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Uint16Array), arrayBuffer, byteOffset)) { }
        public Uint16Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint16Array), arrayBuffer, byteOffset, length)) { }
        public Uint16Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Uint16Array), sharedArrayBuffer)) { }
        public Uint16Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Uint16Array), sharedArrayBuffer, byteOffset)) { }
        public Uint16Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint16Array), sharedArrayBuffer, byteOffset, length)) { }
    }
}
