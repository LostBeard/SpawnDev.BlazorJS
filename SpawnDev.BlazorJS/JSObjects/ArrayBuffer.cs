using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ArrayBuffer object is used to represent a generic raw binary data buffer.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer
    /// </summary>
    public class ArrayBuffer : JSObject
    {
        /// <summary>
        /// Returns a copy of the Javascript ArrayBuffer as a .Net byte[]
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public static explicit operator byte[]?(ArrayBuffer? arrayBuffer) => arrayBuffer?.ReadBytes();
        /// <summary>
        /// The size, in bytes, of the ArrayBuffer. This is established when the array is constructed and can only be changed using the ArrayBuffer.prototype.resize() method if the ArrayBuffer is resizable.
        /// </summary>
        public long ByteLength => JSRef!.Get<long>("byteLength");
        /// <summary>
        /// The read-only maximum length, in bytes, that the ArrayBuffer can be resized to. This is established when the array is constructed and cannot be changed.
        /// </summary>
        public long MaxByteLength => JSRef!.Get<long>("maxByteLength");
        /// <summary>
        /// Read-only. Returns true if the ArrayBuffer has been detached (transferred), or false if not.
        /// </summary>
        public bool Detached => JSRef!.Get<bool>("detached");
        /// <summary>
        /// Read-only. Returns true if the ArrayBuffer can be resized, or false if not.
        /// </summary>
        public bool Resizable => JSRef!.Get<bool>("resizable");
        /// <summary>
        /// The ArrayBuffer() constructor creates ArrayBuffer objects.
        /// </summary>
        /// <param name="length">The size, in bytes, of the array buffer to create.</param>
        public ArrayBuffer(long length) : base(JS.New(nameof(ArrayBuffer), length)) { }
        /// <summary>
        /// The ArrayBuffer() constructor creates ArrayBuffer objects.
        /// </summary>
        /// <param name="length">The size, in bytes, of the array buffer to create.</param>
        /// <param name="options">Additional options</param>
        public ArrayBuffer(long length, ArrayBufferOptions options) : base(JS.New(nameof(ArrayBuffer), length, options)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ArrayBuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Non-standard implementation. Creates a Uint8Array from the ArrayBuffer and reads it into .Net as a byte array.
        /// </summary>
        /// <returns></returns>
        public byte[] ReadBytes()
        {
            using var uint8array = new Uint8Array(this);
            return uint8array.ReadBytes();
        }
        /// <summary>
        /// Returns true if arg is one of the ArrayBuffer views, such as typed array objects or a DataView. Returns false otherwise.
        /// </summary>
        /// <returns></returns>
        public static bool IsView(object value) => JS.Call<bool>("ArrayBuffer.isView");
        /// <summary>
        /// Resizes the ArrayBuffer to the specified size, in bytes.
        /// </summary>
        /// <param name="newLength"></param>
        public void Resize(long newLength) => JSRef!.CallVoid("resize", newLength);
        /// <summary>
        /// Creates a new ArrayBuffer with the same byte content as this buffer, then detaches this buffer.
        /// </summary>
        /// <param name="newByteLength"></param>
        /// <returns></returns>
        public ArrayBuffer Transfer(long newByteLength) => JSRef!.Call<ArrayBuffer>("transfer", newByteLength);
        /// <summary>
        /// Creates a new ArrayBuffer with the same byte content as this buffer, then detaches this buffer.
        /// </summary>
        /// <returns></returns>
        public ArrayBuffer Transfer() => JSRef!.Call<ArrayBuffer>("transfer");
        /// <summary>
        /// Returns a new ArrayBuffer whose contents are a copy of this ArrayBuffer's bytes from begin (inclusive) up to end (exclusive). If either begin or end is negative, it refers to an index from the end of the array, as opposed to from the beginning.
        /// </summary>
        /// <returns></returns>
        public ArrayBuffer Slice() => JSRef!.Call<ArrayBuffer>("slice");
        /// <summary>
        /// Returns a new ArrayBuffer whose contents are a copy of this ArrayBuffer's bytes from begin (inclusive) up to end (exclusive). If either begin or end is negative, it refers to an index from the end of the array, as opposed to from the beginning.
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public ArrayBuffer Slice(long start) => JSRef!.Call<ArrayBuffer>("slice", start);
        /// <summary>
        /// Returns a new ArrayBuffer whose contents are a copy of this ArrayBuffer's bytes from begin (inclusive) up to end (exclusive). If either begin or end is negative, it refers to an index from the end of the array, as opposed to from the beginning.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public ArrayBuffer Slice(long start, long end) => JSRef!.Call<ArrayBuffer>("slice", start, end);
        /// <summary>
        /// Creates a new non-resizable ArrayBuffer with the same byte content as this buffer, then detaches this buffer.
        /// </summary>
        /// <returns></returns>
        public ArrayBuffer TransferToFixedLength() => JSRef!.Call<ArrayBuffer>("transferToFixedLength");
        /// <summary>
        /// Creates a new non-resizable ArrayBuffer with the same byte content as this buffer, then detaches this buffer.
        /// </summary>
        /// <param name="newByteLength"></param>
        /// <returns></returns>
        public ArrayBuffer TransferToFixedLength(long newByteLength) => JSRef!.Call<ArrayBuffer>("transferToFixedLength", newByteLength);
    }
}
