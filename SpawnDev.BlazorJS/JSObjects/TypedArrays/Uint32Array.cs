using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Uint32Array typed array represents an array of 32-bit unsigned integers in the platform byte order. If control over byte order is needed, use DataView instead.  Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint32Array
    /// </summary>
    public class Uint32Array : TypedArray<uint>
    {
        /// <summary>
        /// Returns a copy of the Javascript typed array as a .Net array
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator uint[](Uint32Array values) => values == null ? null! : values.ToArray();
        /// <summary>
        /// Returns a copy of the .Net array as a Javascript typed array
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator Uint32Array(uint[] values) => values == null ? null! : new Uint32Array(values);
        /// <summary>
        /// The TypedArray.from() static method creates a new typed array from an array-like or iterable object. This method is nearly the same as Array.from().
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Uint32Array From<T>(IEnumerable<T> values) where T : struct => JS.Call<Uint32Array>($"{nameof(Uint32Array)}.from", values);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Uint32Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects.
        /// </summary>
        public Uint32Array() : base(JS.New(nameof(Uint32Array))) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects. 
        /// </summary>
        /// <param name="length"></param>
        public Uint32Array(long length) : base(JS.New(nameof(Uint32Array), length)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects. 
        /// </summary>
        /// <param name="typedArray"></param>
        public Uint32Array(TypedArray typedArray) : base(JS.New(nameof(Uint32Array), typedArray)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects. 
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public Uint32Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Uint32Array), arrayBuffer)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects. 
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Uint32Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Uint32Array), arrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects. 
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Uint32Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint32Array), arrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects. 
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        public Uint32Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Uint32Array), sharedArrayBuffer)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects. 
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Uint32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Uint32Array), sharedArrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects. 
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Uint32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint32Array), sharedArrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects.
        /// </summary>
        /// <param name="array"></param>
        public Uint32Array(uint[] array) : base(JS.New(nameof(Uint32Array), (ArrayBuffer)array)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects.
        /// </summary>
        /// <param name="array"></param>
        public Uint32Array(Array<uint> array) : base(JS.New(nameof(Uint32Array), array)) { }
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <returns></returns>
        public Uint32Array Slice() => JSRef!.Call<Uint32Array>("slice");
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public Uint32Array Slice(long start) => JSRef!.Call<Uint32Array>("slice", start);
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Uint32Array Slice(long start, long end) => JSRef!.Call<Uint32Array>("slice", start, end);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <returns></returns>
        public Uint32Array SubArray() => JSRef!.Call<Uint32Array>("subarray");
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <returns></returns>
        public Uint32Array SubArray(long start) => JSRef!.Call<Uint32Array>("subarray", start);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <param name="end">Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view.</param>
        /// <returns></returns>
        public Uint32Array SubArray(long start, long end) => JSRef!.Call<Uint32Array>("subarray", start, end);
    }
}
