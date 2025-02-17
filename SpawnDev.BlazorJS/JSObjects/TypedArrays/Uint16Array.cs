using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Uint16Array typed array represents an array of 32-bit unsigned integers in the platform byte order. If control over byte order is needed, use DataView instead.  Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint16Array
    /// </summary>
    public class Uint16Array : TypedArray<ushort>
    {
        /// <summary>
        /// Returns a copy of the Javascript typed array as a .Net array
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator ushort[]?(Uint16Array? values) => values == null ? null : values.ToArray();
        /// <summary>
        /// Returns a copy of the .Net array as a Javascript typed array
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator Uint16Array?(ushort[]? values) => values == null ? null : new Uint16Array(values);
        /// <summary>
        /// The TypedArray.from() static method creates a new typed array from an array-like or iterable object. This method is nearly the same as Array.from().
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Uint16Array From(IEnumerable<ushort> values) => JS.Call<Uint16Array>($"{nameof(Uint16Array)}.from", values);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Uint16Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects.
        /// </summary>
        public Uint16Array() : base(JS.New(nameof(Uint16Array))) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. 
        /// </summary>
        /// <param name="length"></param>
        public Uint16Array(long length) : base(JS.New(nameof(Uint16Array), length)) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. 
        /// </summary>
        /// <param name="typedArray"></param>
        public Uint16Array(TypedArray typedArray) : base(JS.New(nameof(Uint16Array), typedArray)) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. 
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public Uint16Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Uint16Array), arrayBuffer)) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. 
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Uint16Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Uint16Array), arrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. 
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Uint16Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint16Array), arrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. 
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        public Uint16Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Uint16Array), sharedArrayBuffer)) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. 
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Uint16Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Uint16Array), sharedArrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects. 
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Uint16Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint16Array), sharedArrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// The Uint16Array() constructor creates Uint16Array objects.
        /// </summary>
        /// <param name="array"></param>
        public Uint16Array(ushort[] array) : base(JS.New(nameof(Uint16Array), array)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects.
        /// </summary>
        /// <param name="array"></param>
        public Uint16Array(Array<ushort> array) : base(JS.New(nameof(Uint32Array), array)) { }
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <returns></returns>
        public Uint16Array Slice() => JSRef!.Call<Uint16Array>("slice");
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public Uint16Array Slice(long start) => JSRef!.Call<Uint16Array>("slice", start);
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Uint16Array Slice(long start, long end) => JSRef!.Call<Uint16Array>("slice", start, end);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <returns></returns>
        public Uint16Array SubArray() => JSRef!.Call<Uint16Array>("subarray");
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <returns></returns>
        public Uint16Array SubArray(long start) => JSRef!.Call<Uint16Array>("subarray", start);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <param name="end">Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view.</param>
        /// <returns></returns>
        public Uint16Array SubArray(long start, long end) => JSRef!.Call<Uint16Array>("subarray", start, end);
    }
}
