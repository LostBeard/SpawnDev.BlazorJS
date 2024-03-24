using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Uint16Array typed array represents an array of 16-bit unsigned integers in the platform byte order. If control over byte order is needed, use DataView instead. The contents are initialized to 0. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint16Array
    /// </summary>
    public class Uint16Array : TypedArray
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Uint16Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. The contents are initialized to 0.
        /// </summary>
        public Uint16Array() : base(JS.New(nameof(Uint16Array))) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="length"></param>
        public Uint16Array(long length) : base(JS.New(nameof(Uint16Array), length)) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="typedArray"></param>
        public Uint16Array(TypedArray typedArray) : base(JS.New(nameof(Uint16Array), typedArray)) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public Uint16Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Uint16Array), arrayBuffer)) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Uint16Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Uint16Array), arrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Uint16Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint16Array), arrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        public Uint16Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Uint16Array), sharedArrayBuffer)) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Uint16Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Uint16Array), sharedArrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Uint16Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint16Array), sharedArrayBuffer, byteOffset, length)) { }
    }
}
