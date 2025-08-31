using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BigUint64Array typed array represents an array of 64-bit signed integers in the platform byte order. If control over byte order is needed, use DataView instead. The contents are initialized to 0n. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/BigUint64Array
    /// </summary>
    public class BigUint64Array : TypedArray<ulong>
    {
        /// <summary>
        /// Returns true if BigInt64Array appears to be supported
        /// </summary>
        public static bool Supported => BlazorJSRuntime.JS?.Get<int>("BigUint64Array?.BYTES_PER_ELEMENT") > 0;
        /// <summary>
        /// Returns a copy of the Javascript typed array as a .Net array
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator ulong[]?(BigUint64Array? values) => values == null ? null : values.ToArray();
        /// <summary>
        /// Returns a copy of the .Net array as a Javascript typed array
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator BigUint64Array?(ulong[]? values) => values == null ? null : new BigUint64Array(values);
        /// <summary>
        /// The TypedArray.from() static method creates a new typed array from an array-like or iterable object. This method is nearly the same as Array.from().
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static BigUint64Array From<T>(IEnumerable<T> values) where T : unmanaged => JS.Call<BigUint64Array>($"{nameof(BigUint64Array)}.from", values);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public BigUint64Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new BigUint64Array object.
        /// </summary>
        public BigUint64Array() : base(JS.New(nameof(BigUint64Array))) { }
        /// <summary>
        /// Creates a new BigUint64Array object.
        /// </summary>
        /// <param name="length"></param>
        public BigUint64Array(long length) : base(JS.New(nameof(BigUint64Array), length)) { }
        /// <summary>
        /// Creates a new BigUint64Array object.
        /// </summary>
        /// <param name="array"></param>
        public BigUint64Array(BigInt<ulong>[] array) : base(JS.New(nameof(BigUint64Array), array)) { }
        /// <summary>
        /// Creates a new BigUint64Array object.
        /// </summary>
        /// <param name="array"></param>
        public BigUint64Array(Array<BigInt<ulong>> array) : base(JS.New(nameof(BigUint64Array), array)) { }
        /// <summary>
        /// Creates a new BigUint64Array object.
        /// </summary>
        /// <param name="array"></param>
        public BigUint64Array(ulong[] array) : base(JS.New(nameof(BigUint64Array), (ArrayBuffer)array)) { }
        /// <summary>
        /// Creates a new BigUint64Array object.
        /// </summary>
        /// <param name="typedArray"></param>
        public BigUint64Array(TypedArray typedArray) : base(JS.New(nameof(BigUint64Array), typedArray)) { }
        /// <summary>
        /// Creates a new BigUint64Array object.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public BigUint64Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(BigUint64Array), arrayBuffer)) { }
        /// <summary>
        /// Creates a new BigUint64Array object.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public BigUint64Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(BigUint64Array), arrayBuffer, byteOffset)) { }
        /// <summary>
        /// Creates a new BigUint64Array object.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public BigUint64Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(BigUint64Array), arrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// Creates a new BigUint64Array object.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        public BigUint64Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(BigUint64Array), sharedArrayBuffer)) { }
        /// <summary>
        /// Creates a new BigUint64Array object.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public BigUint64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(BigUint64Array), sharedArrayBuffer, byteOffset)) { }
        /// <summary>
        /// Creates a new BigUint64Array object.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public BigUint64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(BigUint64Array), sharedArrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <returns></returns>
        public BigUint64Array Slice() => JSRef!.Call<BigUint64Array>("slice");
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public BigUint64Array Slice(long start) => JSRef!.Call<BigUint64Array>("slice", start);
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public BigUint64Array Slice(long start, long end) => JSRef!.Call<BigUint64Array>("slice", start, end);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <returns></returns>
        public BigUint64Array SubArray() => JSRef!.Call<BigUint64Array>("subarray");
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <returns></returns>
        public BigUint64Array SubArray(long start) => JSRef!.Call<BigUint64Array>("subarray", start);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <param name="end">Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view.</param>
        /// <returns></returns>
        public BigUint64Array SubArray(long start, long end) => JSRef!.Call<BigUint64Array>("subarray", start, end);
        /// <summary>
        /// Takes an integer value and returns the item at that index. This method allows for negative integers, which count back from the last item.
        /// </summary>
        /// <param name="index">Zero-based index of the typed array element to be returned, converted to an integer. Negative index counts back from the end of the typed array — if index &lt; 0, index + array.length is accessed.</param>
        /// <returns>The element in the typed array matching the given index. Always returns undefined if index &lt; -array.length or index &gt;= array.length without attempting to access the corresponding property.</returns>
        public override ulong At(long index) => JSRef!.Call<BigInt<ulong>>("at", index);
        /// <inheritdoc />
        public override ulong this[long i]
        {
            get => JSRef!.Get<BigInt<ulong>>(i);
            set => JSRef!.Set(i, (BigInt<ulong>)value);
        }
    }
}