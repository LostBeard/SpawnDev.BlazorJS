using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Float64Array typed array represents an array of 32-bit unsigned integers in the platform byte order. If control over byte order is needed, use DataView instead.  Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Float64Array
    /// </summary>
    public class Float64Array : TypedArray<double>
    {
        /// <summary>
        /// Returns a copy of the Javascript typed array as a .Net array
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator double[]?(Float64Array? values) => values == null ? null : values.ToArray();
        /// <summary>
        /// Returns a copy of the .Net array as a Javascript typed array
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator Float64Array?(double[]? values) => values == null ? null : new Float64Array(values);
        /// <summary>
        /// The TypedArray.from() static method creates a new typed array from an array-like or iterable object. This method is nearly the same as Array.from().
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Float64Array From<T>(IEnumerable<T> values) where T : struct => JS.Call<Float64Array>($"{nameof(Float64Array)}.from", values);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Float64Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The Float64Array() constructor creates Float64Array objects.
        /// </summary>
        public Float64Array() : base(JS.New(nameof(Float64Array))) { }
        /// <summary>
        /// The Float64Array() constructor creates Float64Array objects. 
        /// </summary>
        /// <param name="length"></param>
        public Float64Array(long length) : base(JS.New(nameof(Float64Array), length)) { }
        /// <summary>
        /// The Float64Array() constructor creates Float64Array objects. 
        /// </summary>
        /// <param name="typedArray"></param>
        public Float64Array(TypedArray typedArray) : base(JS.New(nameof(Float64Array), typedArray)) { }
        /// <summary>
        /// The Float64Array() constructor creates Float64Array objects. 
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public Float64Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Float64Array), arrayBuffer)) { }
        /// <summary>
        /// The Float64Array() constructor creates Float64Array objects. 
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Float64Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Float64Array), arrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Float64Array() constructor creates Float64Array objects. 
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Float64Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Float64Array), arrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// The Float64Array() constructor creates Float64Array objects. 
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        public Float64Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Float64Array), sharedArrayBuffer)) { }
        /// <summary>
        /// The Float64Array() constructor creates Float64Array objects. 
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Float64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Float64Array), sharedArrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Float64Array() constructor creates Float64Array objects. 
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Float64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Float64Array), sharedArrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// The Float64Array() constructor creates Float64Array objects.
        /// </summary>
        /// <param name="array"></param>
        public Float64Array(double[] array) : base(JS.New(nameof(Float64Array), (ArrayBuffer)array)) { }
        /// <summary>
        /// The Float64Array() constructor creates Float64Array objects.
        /// </summary>
        /// <param name="array"></param>
        public Float64Array(Array<double> array) : base(JS.New(nameof(Float64Array), array)) { }
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <returns></returns>
        public Float64Array Slice() => JSRef!.Call<Float64Array>("slice");
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public Float64Array Slice(long start) => JSRef!.Call<Float64Array>("slice", start);
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Float64Array Slice(long start, long end) => JSRef!.Call<Float64Array>("slice", start, end);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <returns></returns>
        public Float64Array SubArray() => JSRef!.Call<Float64Array>("subarray");
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <returns></returns>
        public Float64Array SubArray(long start) => JSRef!.Call<Float64Array>("subarray", start);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <param name="end">Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view.</param>
        /// <returns></returns>
        public Float64Array SubArray(long start, long end) => JSRef!.Call<Float64Array>("subarray", start, end);
    }
}
