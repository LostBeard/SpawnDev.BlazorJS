using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Int8Array typed array represents an array of 8-bit signed integers. The contents are initialized to 0. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Int8Array
    /// </summary>
    public class Int8Array : TypedArray<sbyte>
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Int8Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Int8Array() : base(JS.New(nameof(Int8Array))) { }
        public Int8Array(long length) : base(JS.New(nameof(Int8Array), length)) { }
        public Int8Array(TypedArray typedArray) : base(JS.New(nameof(Int8Array), typedArray)) { }
        public Int8Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Int8Array), arrayBuffer)) { }
        public Int8Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Int8Array), arrayBuffer, byteOffset)) { }
        public Int8Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Int8Array), arrayBuffer, byteOffset, length)) { }
        public Int8Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Int8Array), sharedArrayBuffer)) { }
        public Int8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Int8Array), sharedArrayBuffer, byteOffset)) { }
        public Int8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Int8Array), sharedArrayBuffer, byteOffset, length)) { }
    }
}
