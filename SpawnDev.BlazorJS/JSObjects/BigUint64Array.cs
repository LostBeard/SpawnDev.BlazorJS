using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class BigUint64Array : TypedArray
    {
        public BigUint64Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public BigUint64Array() : base(JS.New(nameof(BigUint64Array))) { }
        public BigUint64Array(long length) : base(JS.New(nameof(BigUint64Array), length)) { }
        public BigUint64Array(TypedArray typedArray) : base(JS.New(nameof(BigUint64Array), typedArray)) { }
        public BigUint64Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(BigUint64Array), arrayBuffer)) { }
        public BigUint64Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(BigUint64Array), arrayBuffer, byteOffset)) { }
        public BigUint64Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(BigUint64Array), arrayBuffer, byteOffset, length)) { }
        public BigUint64Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(BigUint64Array), sharedArrayBuffer)) { }
        public BigUint64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(BigUint64Array), sharedArrayBuffer, byteOffset)) { }
        public BigUint64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(BigUint64Array), sharedArrayBuffer, byteOffset, length)) { }
    }
}