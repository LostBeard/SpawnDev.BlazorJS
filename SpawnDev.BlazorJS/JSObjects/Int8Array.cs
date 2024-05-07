using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Int8Array typed array represents an array of 32-bit signed integers in the platform byte order. If control over byte order is needed, use DataView instead. The contents are initialized to 0. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Int8Array
    /// </summary>
    public class Int8Array : TypedArray<sbyte>
    {
        /// <summary>
        /// Returns a copy of the Javascript typed array as a .Net array
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator sbyte[]?(Int8Array? values) => values == null ? null : values.ToArray();
        /// <summary>
        /// Returns a copy of the .Net array as a Javascript typed array
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator Int8Array?(sbyte[]? values) => values == null ? null : new Int8Array(values);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Int8Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The Int8Array() constructor creates Int8Array objects.
        /// </summary>
        public Int8Array() : base(JS.New(nameof(Int8Array))) { }
        /// <summary>
        /// The Int8Array() constructor creates Int8Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="length"></param>
        public Int8Array(long length) : base(JS.New(nameof(Int8Array), length)) { }
        /// <summary>
        /// The Int8Array() constructor creates Int8Array objects.
        /// </summary>
        /// <param name="typedArray"></param>
        public Int8Array(TypedArray typedArray) : base(JS.New(nameof(Int8Array), typedArray)) { }
        /// <summary>
        /// The Int8Array() constructor creates Int8Array objects.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public Int8Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Int8Array), arrayBuffer)) { }
        /// <summary>
        /// The Int8Array() constructor creates Int8Array objects.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Int8Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Int8Array), arrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Int8Array() constructor creates Int8Array objects.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Int8Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Int8Array), arrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// The Int8Array() constructor creates Int8Array objects.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        public Int8Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Int8Array), sharedArrayBuffer)) { }
        /// <summary>
        /// The Int8Array() constructor creates Int8Array objects.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Int8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Int8Array), sharedArrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Int8Array() constructor creates Int8Array objects.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Int8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Int8Array), sharedArrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// The Int8Array() constructor creates Int8Array objects.
        /// </summary>
        /// <param name="array"></param>
        public Int8Array(sbyte[] array) : base(JS.New(nameof(Int8Array), array)) { }
        /// <summary>
        /// The Int8Array() constructor creates Int8Array objects.
        /// </summary>
        /// <param name="array"></param>
        public Int8Array(Array<sbyte> array) : base(JS.New(nameof(Int8Array), array)) { }
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <returns></returns>
        public Int8Array Slice() => JSRef!.Call<Int8Array>("slice");
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public Int8Array Slice(long start) => JSRef!.Call<Int8Array>("slice", start);
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Int8Array Slice(long start, long end) => JSRef!.Call<Int8Array>("slice", start, end);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <returns></returns>
        public Int8Array SubArray() => JSRef!.Call<Int8Array>("subarray");
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <returns></returns>
        public Int8Array SubArray(long start) => JSRef!.Call<Int8Array>("subarray", start);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <param name="end">Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view.</param>
        /// <returns></returns>
        public Int8Array SubArray(long start, long end) => JSRef!.Call<Int8Array>("subarray", start, end);
    }
}
