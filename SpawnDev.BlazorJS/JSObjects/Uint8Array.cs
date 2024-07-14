using Microsoft.JSInterop;
using System.Runtime.InteropServices;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Uint8Array typed array represents an array of 8-bit unsigned integers. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint8Array
    /// </summary>
    public class Uint8Array : TypedArray<byte>
    {
        /// <summary>
        /// Returns a copy of the Javascript typed array as a .Net array
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator byte[]?(Uint8Array? values) => values == null ? null : values.ToArray();
        /// <summary>
        /// Returns a copy of the .Net array as a Javascript typed array
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator Uint8Array?(byte[]? values) => values == null ? null : new Uint8Array(values);
        /// <summary>
        /// Returns a new Uint8Array from an ArrayBuffer
        /// </summary>
        /// <param name="values"></param>
        public static explicit operator Uint8Array?(ArrayBuffer? values) => values == null ? null : new Uint8Array(values);
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Uint8Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The Uint8Array() constructor creates Uint8Array objects.
        /// </summary>
        public Uint8Array() : base(JS.New(nameof(Uint8Array))) { }
        /// <summary>
        /// The Uint8Array() constructor creates Uint8Array objects. The contents are initialized to 0.
        /// </summary>
        /// <param name="length"></param>
        public Uint8Array(long length) : base(JS.New(nameof(Uint8Array), length)) { }
        /// <summary>
        /// The Uint8Array() constructor creates Uint8Array objects.
        /// </summary>
        /// <param name="typedArray"></param>
        public Uint8Array(TypedArray typedArray) : base(JS.New(nameof(Uint8Array), typedArray)) { }
        /// <summary>
        /// The Uint8Array() constructor creates Uint8Array objects.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public Uint8Array(ArrayBuffer arrayBuffer) : base(JS.New(nameof(Uint8Array), arrayBuffer)) { }
        /// <summary>
        /// The Uint8Array() constructor creates Uint8Array objects.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Uint8Array(ArrayBuffer arrayBuffer, long byteOffset) : base(JS.New(nameof(Uint8Array), arrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Uint8Array() constructor creates Uint8Array objects.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Uint8Array(ArrayBuffer arrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint8Array), arrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// The Uint8Array() constructor creates Uint8Array objects.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        public Uint8Array(SharedArrayBuffer sharedArrayBuffer) : base(JS.New(nameof(Uint8Array), sharedArrayBuffer)) { }
        /// <summary>
        /// The Uint8Array() constructor creates Uint8Array objects.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        public Uint8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset) : base(JS.New(nameof(Uint8Array), sharedArrayBuffer, byteOffset)) { }
        /// <summary>
        /// The Uint8Array() constructor creates Uint8Array objects.
        /// </summary>
        /// <param name="sharedArrayBuffer"></param>
        /// <param name="byteOffset"></param>
        /// <param name="length"></param>
        public Uint8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length) : base(JS.New(nameof(Uint8Array), sharedArrayBuffer, byteOffset, length)) { }
        /// <summary>
        /// The Uint8Array() constructor creates Uint8Array objects.
        /// </summary>
        /// <param name="sourceBytes"></param>
        public Uint8Array(byte[] sourceBytes) : base(JS.ReturnMe<IJSInProcessObjectReference>(sourceBytes)) { }
        /// <summary>
        /// The Uint32Array() constructor creates Uint32Array objects.
        /// </summary>
        /// <param name="array"></param>
        public Uint8Array(Array<byte> array) : base(JS.New(nameof(Uint32Array), array)) { }
        #endregion
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <returns></returns>
        public Uint8Array Slice() => JSRef!.Call<Uint8Array>("slice");
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public Uint8Array Slice(long start) => JSRef!.Call<Uint8Array>("slice", start);
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Uint8Array Slice(long start, long end) => JSRef!.Call<Uint8Array>("slice", start, end);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <returns></returns>
        public Uint8Array SubArray() => JSRef!.Call<Uint8Array>("subarray");
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <returns></returns>
        public Uint8Array SubArray(long start) => JSRef!.Call<Uint8Array>("subarray", start);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <param name="end">Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view.</param>
        /// <returns></returns>
        public Uint8Array SubArray(long start, long end) => JSRef!.Call<Uint8Array>("subarray", start, end);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <returns></returns>
        public byte[] SubArrayBytes() => JSRef!.Call<byte[]>("subarray");
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <returns></returns>
        public byte[] SubArrayBytes(long start) => JSRef!.Call<byte[]>("subarray", start);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <param name="end">Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view.</param>
        /// <returns></returns>
        public byte[] SubArrayBytes(long start, long end) => JSRef!.Call<byte[]>("subarray", start, end);
        /// <summary>
        /// Read bytes from the underlying ArrayBuffer starting at this TypedArray's byteOffset
        /// </summary>
        /// <returns></returns>
        public override byte[] ReadBytes() => JS.ReturnMe<byte[]>(JSRef);
        /// <summary>
        /// Read bytes from the underlying ArrayBuffer starting at this TypedArray's byteOffset
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public override byte[] ReadBytes(long start) => JSRef!.Call<byte[]>("subarray", start);
        /// <summary>
        /// Read bytes from the underlying ArrayBuffer starting at this TypedArray's byteOffset
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public override byte[] ReadBytes(long start, long length) => JSRef!.Call<byte[]>("subarray", start, start + length);
        /// <summary>
        /// Write bytes to the underlying ArrayBuffer starting at this TypedArray's byteOffset
        /// </summary>
        /// <param name="data"></param>
        /// <param name="byteOffset"></param>
        public override void WriteBytes(byte[] data, long byteOffset = 0) => Set(data, byteOffset);
    }
}
