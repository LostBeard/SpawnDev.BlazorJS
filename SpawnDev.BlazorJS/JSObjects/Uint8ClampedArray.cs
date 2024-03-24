using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Uint8ClampedArray typed array represents an array of 8-bit unsigned integers clamped to 0–255. The contents are initialized to 0. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint8ClampedArray
    /// </summary>
    public class Uint8ClampedArray : TypedArray
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Uint8ClampedArray(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="uint8Array"></param>
        public Uint8ClampedArray(byte[] uint8Array) : base(JS.New(nameof(Uint8ClampedArray), uint8Array)) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="typedArray"></param>
        public Uint8ClampedArray(TypedArray typedArray) : base(JS.New(nameof(Uint8ClampedArray), typedArray)) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="length"></param>
        public Uint8ClampedArray(long length) : base(JS.New(nameof(Uint8ClampedArray), length)) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public Uint8ClampedArray(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Uint8ClampedArray), arrayBuffer)) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Uint8ClampedArray(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Uint8ClampedArray), arrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Uint8ClampedArray(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint8ClampedArray), arrayBuffer, byteOffset, length)) { }
    }
}
