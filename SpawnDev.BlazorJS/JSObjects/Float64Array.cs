using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Float64Array : TypedArray
    {
        public Float64Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Float64Array(double[] data) : base(JS.New(nameof(Float64Array), data)) { }
        public Float64Array() : base(JS.New(nameof(Float64Array))) { }
        public Float64Array(long length) : base(JS.New(nameof(Float64Array), length)) { }
        public Float64Array(TypedArray typedArray) : base(JS.New(nameof(Float64Array), typedArray)) { }
        public Float64Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Float64Array), arrayBuffer)) { }
        public Float64Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Float64Array), arrayBuffer, byteOffset)) { }
        public Float64Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Float64Array), arrayBuffer, byteOffset, length)) { }
        public Float64Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Float64Array), sharedArrayBuffer)) { }
        public Float64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Float64Array), sharedArrayBuffer, byteOffset)) { }
        public Float64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Float64Array), sharedArrayBuffer, byteOffset, length)) { }
    }
}