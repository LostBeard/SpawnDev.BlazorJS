using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    /// <summary>
    /// The Uint8Array typed array represents an array of 8-bit unsigned integers. The contents are initialized to 0. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint8Array
    /// </summary>
    public class Uint8Array : TypedArray
    {
        public Uint8Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Uint8Array() : base(JS.New(nameof(Uint8Array))) { }
        public Uint8Array(long length) : base(JS.New(nameof(Uint8Array), length)) { }
        public Uint8Array(TypedArray typedArray) : base(JS.New(nameof(Uint8Array), typedArray)) { }
        public Uint8Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Uint8Array), arrayBuffer)) { }
        public Uint8Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Uint8Array), arrayBuffer, byteOffset)) { }
        public Uint8Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint8Array), arrayBuffer, byteOffset, length)) { }
        public Uint8Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Uint8Array), sharedArrayBuffer)) { }
        public Uint8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Uint8Array), sharedArrayBuffer, byteOffset)) { }
        public Uint8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint8Array), sharedArrayBuffer, byteOffset, length)) { }
        public Uint8Array(byte[] sourceBytes) : base(JS.ReturnMe<IJSInProcessObjectReference>(sourceBytes)) { }
        /// <summary>
        /// Returns a copy of the Uint8Array as a byte array 
        /// </summary>
        /// <returns></returns>
        public override byte[] ReadBytes() => JS.ReturnMe<byte[]>(JSRef);
        /// <summary>
        /// Returns a copy of the Uint8Array bytes starting at position "start"
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public byte[] ReadBytes(long start) => JSRef.Call<byte[]>("subarray", start);
        /// <summary>
        /// Returns a copy of the Uint8Array bytes starting at position "start" with a length of "length"
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public byte[] ReadBytes(long start, long length) => JSRef.Call<byte[]>("subarray", start, start + length);
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <returns></returns>
        public Uint8Array Slice() => JSRef.Call<Uint8Array>("slice");
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public Uint8Array Slice(long start) => JSRef.Call<Uint8Array>("slice", start);
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Uint8Array Slice(long start, long end) => JSRef.Call<Uint8Array>("slice", start, end);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as for this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <returns></returns>
        public Uint8Array SubArray() => JSRef.Call<Uint8Array>("subarray");
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as for this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <returns></returns>
        public Uint8Array SubArray(long start) => JSRef.Call<Uint8Array>("subarray", start);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as for this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <param name="end">Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view.</param>
        /// <returns></returns>
        public Uint8Array SubArray(long start, long end) => JSRef.Call<Uint8Array>("subarray", start, end);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as for this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <returns></returns>
        public byte[] SubArrayBytes() => JSRef.Call<byte[]>("subarray");
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as for this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <returns></returns>
        public byte[] SubArrayBytes(long start) => JSRef.Call<byte[]>("subarray", start);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as for this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <param name="end">Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view.</param>
        /// <returns></returns>
        public byte[] SubArrayBytes(long start, long end) => JSRef.Call<byte[]>("subarray", start, end);
        /// <summary>
        /// Returns a number value of the element size. 1 in the case of Uint8Array.
        /// </summary>
        public static int BYTES_PER_ELEMENT => JS.Get<int>($"{nameof(Uint8Array)}.BYTES_PER_ELEMENT");
        public byte this[long i]
        {
            get => JSRef.Get<byte>(i);
            set => JSRef.Set(i, value);
        }
    }
}
