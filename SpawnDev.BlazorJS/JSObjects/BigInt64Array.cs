using Microsoft.JSInterop;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BigInt64Array typed array represents an array of 64-bit signed integers in the platform byte order. If control over byte order is needed, use DataView instead. The contents are initialized to 0n. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/BigInt64Array
    /// </summary>
    public class BigInt64Array : TypedArray<long>
    {
        public static explicit operator long[]?(BigInt64Array? values) => values == null ? null : values.ToArray();
        public static explicit operator BigInt64Array?(long[]? values) => values == null ? null : new BigInt64Array(values);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public BigInt64Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        public BigInt64Array() : base(JS.New(nameof(BigInt64Array))) { }
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        /// <param name="length"></param>
        public BigInt64Array(long length) : base(JS.New(nameof(BigInt64Array), length)) { }
        public BigInt64Array(BigInt[] array) : base(JS.New(nameof(BigInt64Array), array)) { }
        public BigInt64Array(long[] array) : base(NullRef)
        {
            var myByteArray = new byte[array.Length * sizeof(long)];
            System.Buffer.BlockCopy(array, 0, myByteArray, 0, array.Length * sizeof(long));
            using var uint8Array = new Uint8Array(myByteArray);
            var jsRef = JS.New(nameof(BigInt64Array), uint8Array.Buffer);
            FromReference(jsRef);
        }
        #region Disabled - Throws error on Chrome
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        /// <param name="typedArray"></param>
        //public BigInt64Array(TypedArray typedArray) : base(JS.New(nameof(BigInt64Array), typedArray)) { }
        #endregion
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public BigInt64Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(BigInt64Array), arrayBuffer)) { }
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public BigInt64Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(BigInt64Array), arrayBuffer, byteOffset)) { }
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public BigInt64Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(BigInt64Array), arrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        public BigInt64Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(BigInt64Array), sharedArrayBuffer)) { }
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public BigInt64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(BigInt64Array), sharedArrayBuffer, byteOffset)) { }
        /// <summary>
        /// Creates a new BigInt64Array object.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public BigInt64Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(BigInt64Array), sharedArrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <returns></returns>
        public BigInt64Array Slice() => JSRef!.Call<BigInt64Array>("slice");
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public BigInt64Array Slice(long start) => JSRef!.Call<BigInt64Array>("slice", start);
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public BigInt64Array Slice(long start, long end) => JSRef!.Call<BigInt64Array>("slice", start, end);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <returns></returns>
        public BigInt64Array SubArray() => JSRef!.Call<BigInt64Array>("subarray");
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <returns></returns>
        public BigInt64Array SubArray(long start) => JSRef!.Call<BigInt64Array>("subarray", start);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <param name="end">Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view.</param>
        /// <returns></returns>
        public BigInt64Array SubArray(long start, long end) => JSRef!.Call<BigInt64Array>("subarray", start, end);
        /// <summary>
        /// Takes an integer value and returns the item at that index. This method allows for negative integers, which count back from the last item.
        /// </summary>
        /// <param name="index">Zero-based index of the typed array element to be returned, converted to an integer. Negative index counts back from the end of the typed array — if index &lt; 0, index + array.length is accessed.</param>
        /// <returns>The element in the typed array matching the given index. Always returns undefined if index &lt; -array.length or index &gt;= array.length without attempting to access the corresponding property.</returns>
        public override long At(long index) => BitConverter.ToInt64(ReadBytes(index * BYTES_PER_ELEMENT, BYTES_PER_ELEMENT));
        /// <summary>
        /// Gets or sets the element at the given index
        /// </summary>
        /// <param name="i">the index of the element to get or set</param>
        /// <returns>The value of the element at the given index if getting</returns>
        public override long this[long i]
        {
            get => At(i);
            set => new BigInt64Array(new[] { value }).Using(o => Set(o, i));
        }
    }
}