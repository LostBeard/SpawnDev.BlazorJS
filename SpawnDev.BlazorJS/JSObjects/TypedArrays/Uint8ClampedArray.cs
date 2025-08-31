using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Uint8ClampedArray typed array represents an array of 8-bit unsigned integers clamped to 0–255. The contents are initialized to 0. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint8ClampedArray
    /// </summary>
    public class Uint8ClampedArray : TypedArray<byte>
    {
        /// <summary>
        /// Returns a copy of the Javascript typed array as a .Net array
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator byte[]?(Uint8ClampedArray? values) => values == null ? null : values.ToArray();
        /// <summary>
        /// Returns a copy of the .Net array as a Javascript typed array
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator Uint8ClampedArray?(byte[]? values) => values == null ? null : new Uint8ClampedArray(values);
        /// <summary>
        /// The TypedArray.from() static method creates a new typed array from an array-like or iterable object. This method is nearly the same as Array.from().
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Uint8ClampedArray From<T>(IEnumerable<T> values) where T : unmanaged => JS.Call<Uint8ClampedArray>($"{nameof(Uint8ClampedArray)}.from", values);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Uint8ClampedArray(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects.
        /// </summary>
        public Uint8ClampedArray() : base(JS.New(nameof(Uint8ClampedArray))) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. 
        /// </summary>
        /// <param name="length"></param>
        public Uint8ClampedArray(long length) : base(JS.New(nameof(Uint8ClampedArray), length)) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. 
        /// </summary>
        /// <param name="typedArray"></param>
        public Uint8ClampedArray(TypedArray typedArray) : base(JS.New(nameof(Uint8ClampedArray), typedArray)) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. 
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public Uint8ClampedArray(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Uint8ClampedArray), arrayBuffer)) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. 
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Uint8ClampedArray(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Uint8ClampedArray), arrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. 
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Uint8ClampedArray(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint8ClampedArray), arrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. 
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        public Uint8ClampedArray(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Uint8ClampedArray), sharedArrayBuffer)) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. 
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Uint8ClampedArray(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Uint8ClampedArray), sharedArrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects. 
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Uint8ClampedArray(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint8ClampedArray), sharedArrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects.
        /// </summary>
        /// <param name="array"></param>
        public Uint8ClampedArray(byte[] array) : base(JS.New(nameof(Uint8ClampedArray), (ArrayBuffer)array)) { }
        /// <summary>
        /// The Uint8ClampedArray() constructor creates Uint8ClampedArray objects.
        /// </summary>
        /// <param name="array"></param>
        public Uint8ClampedArray(Array<byte> array) : base(JS.New(nameof(Uint8ClampedArray), array)) { }
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <returns></returns>
        public Uint8ClampedArray Slice() => JSRef!.Call<Uint8ClampedArray>("slice");
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public Uint8ClampedArray Slice(long start) => JSRef!.Call<Uint8ClampedArray>("slice", start);
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Uint8ClampedArray Slice(long start, long end) => JSRef!.Call<Uint8ClampedArray>("slice", start, end);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <returns></returns>
        public Uint8ClampedArray SubArray() => JSRef!.Call<Uint8ClampedArray>("subarray");
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <returns></returns>
        public Uint8ClampedArray SubArray(long start) => JSRef!.Call<Uint8ClampedArray>("subarray", start);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <param name="end">Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view.</param>
        /// <returns></returns>
        public Uint8ClampedArray SubArray(long start, long end) => JSRef!.Call<Uint8ClampedArray>("subarray", start, end);
    }
}
