using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BigInt64Array typed array represents an array of 64-bit signed integers in the platform byte order. If control over byte order is needed, use DataView instead. The contents are initialized to 0n. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/BigInt64Array
    /// </summary>
    public class BigInt64Array : TypedArray
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public BigInt64Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        public BigInt64Array() : base(JS.New(nameof(BigInt64Array))) { }
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        /// <param name="length"></param>
        public BigInt64Array(long length) : base(JS.New(nameof(BigInt64Array), length)) { }
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        /// <param name="typedArray"></param>
        public BigInt64Array(TypedArray typedArray) : base(JS.New(nameof(BigInt64Array), typedArray)) { }
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public BigInt64Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(BigInt64Array), arrayBuffer)) { }
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public BigInt64Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(BigInt64Array), arrayBuffer, byteOffset)) { }
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public BigInt64Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(BigInt64Array), arrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        public BigInt64Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(BigInt64Array), sharedArrayBuffer)) { }
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public BigInt64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(BigInt64Array), sharedArrayBuffer, byteOffset)) { }
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public BigInt64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(BigInt64Array), sharedArrayBuffer, byteOffset, length)) { }
    }
}