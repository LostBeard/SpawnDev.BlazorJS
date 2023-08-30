using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class BigInt64Array : TypedArray
    {
        public BigInt64Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public BigInt64Array() : base(JS.New(nameof(BigInt64Array))) { }
        public BigInt64Array(long length) : base(JS.New(nameof(BigInt64Array), length)) { }
        public BigInt64Array(TypedArray typedArray) : base(JS.New(nameof(BigInt64Array), typedArray)) { }
        public BigInt64Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(BigInt64Array), arrayBuffer)) { }
        public BigInt64Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(BigInt64Array), arrayBuffer, byteOffset)) { }
        public BigInt64Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(BigInt64Array), arrayBuffer, byteOffset, length)) { }
        public BigInt64Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(BigInt64Array), sharedArrayBuffer)) { }
        public BigInt64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(BigInt64Array), sharedArrayBuffer, byteOffset)) { }
        public BigInt64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(BigInt64Array), sharedArrayBuffer, byteOffset, length)) { }
    }
}