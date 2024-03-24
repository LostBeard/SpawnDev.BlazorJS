using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Uint32Array typed array represents an array of 32-bit unsigned integers in the platform byte order. If control over byte order is needed, use DataView instead. The contents are initialized to 0. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint32Array
    /// </summary>
    public class Uint32Array : TypedArray
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Uint32Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// 
        /// </summary>
        public Uint32Array() : base(JS.New(nameof(Uint32Array))) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="length"></param>
        public Uint32Array(long length) : base(JS.New(nameof(Uint32Array), length)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="typedArray"></param>
        public Uint32Array(TypedArray typedArray) : base(JS.New(nameof(Uint32Array), typedArray)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public Uint32Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Uint32Array), arrayBuffer)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Uint32Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Uint32Array), arrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Uint32Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint32Array), arrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        public Uint32Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Uint32Array), sharedArrayBuffer)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Uint32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Uint32Array), sharedArrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Uint32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint32Array), sharedArrayBuffer, byteOffset, length)) { }
    }
}
