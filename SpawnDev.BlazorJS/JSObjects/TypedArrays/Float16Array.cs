using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Float16Array typed array represents an array of 16-bit floating point numbers in the platform byte order. If control over byte order is needed, use DataView instead. The contents are initialized to 0 unless initialization data is explicitly provided. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br/>
    /// NOTE - As of 2025-02-17 this feature has narrow support and should be tested for before using.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Float16Array
    /// </summary>
    public class Float16Array : TypedArray<Half>
    {
        /// <summary>
        /// Returns a copy of the Javascript typed array as a .Net array
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator Half[](Float16Array values) => values == null ? null! : values.ToArray();
        /// <summary>
        /// Returns a copy of the .Net array as a Javascript typed array
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator Float16Array(Half[] values) => values == null ? null! : new Float16Array(values);
        /// <summary>
        /// The TypedArray.from() static method creates a new typed array from an array-like or iterable object. This method is nearly the same as Array.from().
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Float16Array From<T>(IEnumerable<T> values) where T : struct => JS.Call<Float16Array>($"{nameof(Float16Array)}.from", values);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Float16Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The Float16Array() constructor creates Float16Array objects.
        /// </summary>
        public Float16Array() : base(JS.New(nameof(Float16Array))) { }
        /// <summary>
        /// The Float16Array() constructor creates Float16Array objects. 
        /// </summary>
        /// <param name="length"></param>
        public Float16Array(long length) : base(JS.New(nameof(Float16Array), length)) { }
        /// <summary>
        /// The Float16Array() constructor creates Float16Array objects. 
        /// </summary>
        /// <param name="typedArray"></param>
        public Float16Array(TypedArray typedArray) : base(JS.New(nameof(Float16Array), typedArray)) { }
        /// <summary>
        /// The Float16Array() constructor creates Float16Array objects. 
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public Float16Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Float16Array), arrayBuffer)) { }
        /// <summary>
        /// The Float16Array() constructor creates Float16Array objects. 
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Float16Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Float16Array), arrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Float16Array() constructor creates Float16Array objects. 
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Float16Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Float16Array), arrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// The Float16Array() constructor creates Float16Array objects. 
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        public Float16Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Float16Array), sharedArrayBuffer)) { }
        /// <summary>
        /// The Float16Array() constructor creates Float16Array objects. 
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Float16Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Float16Array), sharedArrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Float16Array() constructor creates Float16Array objects. 
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Float16Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Float16Array), sharedArrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// The Float16Array() constructor creates Float16Array objects.
        /// </summary>
        /// <param name="array"></param>
        public Float16Array(Half[] array) : base(JS.New(nameof(Float16Array), (ArrayBuffer)array)) { }
        /// <summary>
        /// The Float16Array() constructor creates Float16Array objects.
        /// </summary>
        /// <param name="array"></param>
        public Float16Array(Array<Half> array) : base(JS.New(nameof(Float16Array), array)) { }
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <returns></returns>
        public Float16Array Slice() => JSRef!.Call<Float16Array>("slice");
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public Float16Array Slice(long start) => JSRef!.Call<Float16Array>("slice", start);
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Float16Array Slice(long start, long end) => JSRef!.Call<Float16Array>("slice", start, end);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <returns></returns>
        public Float16Array SubArray() => JSRef!.Call<Float16Array>("subarray");
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <returns></returns>
        public Float16Array SubArray(long start) => JSRef!.Call<Float16Array>("subarray", start);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <param name="end">Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view.</param>
        /// <returns></returns>
        public Float16Array SubArray(long start, long end) => JSRef!.Call<Float16Array>("subarray", start, end);
    }
}
