using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Float32Array : TypedArray
    {
        public Float32Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Float32Array(float[] data) : base(JS.New(nameof(Float32Array), data)) { }
        public Float32Array() : base(JS.New(nameof(Float32Array))) { }
        public Float32Array(long length) : base(JS.New(nameof(Float32Array), length)) { }
        public Float32Array(TypedArray typedArray) : base(JS.New(nameof(Float32Array), typedArray)) { }
        public Float32Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Float32Array), arrayBuffer)) { }
        public Float32Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Float32Array), arrayBuffer, byteOffset)) { }
        public Float32Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Float32Array), arrayBuffer, byteOffset, length)) { }
        public Float32Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Float32Array), sharedArrayBuffer)) { }
        public Float32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Float32Array), sharedArrayBuffer, byteOffset)) { }
        public Float32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Float32Array), sharedArrayBuffer, byteOffset, length)) { }
    }
}