using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SharedArrayBuffer object is used to represent a generic raw binary data buffer, similar to the ArrayBuffer object, but in a way that they can be used to create views on shared memory. A SharedArrayBuffer is not a Transferable Object, unlike an ArrayBuffer which is transferable.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/SharedArrayBuffer
    /// </summary>
    public class SharedArrayBuffer : JSObject
    {
        /// <summary>
        /// The size, in bytes, of the array. This is established when the array is constructed and can only be changed using the SharedArrayBuffer.prototype.grow() method if the SharedArrayBuffer is growable.
        /// </summary>
        public long ByteLength => JSRef!.Get<long>("byteLength");
        /// <summary>
        /// The read-only maximum length, in bytes, that the SharedArrayBuffer can be grown to. This is established when the array is constructed and cannot be changed.
        /// </summary>
        public long MaxByteLength => JSRef!.Get<long>("maxByteLength");
        /// <summary>
        /// Read-only. Returns true if the SharedArrayBuffer can be grown, or false if not.
        /// </summary>
        public bool Growable => JSRef!.Get<bool>("growable");
        /// <summary>
        /// The SharedArrayBuffer() constructor creates SharedArrayBuffer objects.
        /// </summary>
        /// <param name="length">The size, in bytes, of the array buffer to create.</param>
        public SharedArrayBuffer(long length) : base(JS.New(nameof(SharedArrayBuffer), length)) { }
        /// <summary>
        /// The SharedArrayBuffer() constructor creates SharedArrayBuffer objects.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="options"></param>
        public SharedArrayBuffer(long length, SharedArrayBufferOptions options) : base(JS.New(nameof(SharedArrayBuffer), length, options)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public SharedArrayBuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Grows the SharedArrayBuffer to the specified size, in bytes.
        /// </summary>
        /// <param name="newLength"></param>
        public void Grow(long newLength) => JSRef!.CallVoid("grow", newLength);
        /// <summary>
        /// Returns a new SharedArrayBuffer whose contents are a copy of this SharedArrayBuffer's bytes from begin, inclusive, up to end, exclusive. If either begin or end is negative, it refers to an index from the end of the array, as opposed to from the beginning.
        /// </summary>
        /// <returns>SharedArrayBuffer</returns>
        public SharedArrayBuffer Slice() => JSRef!.Call<SharedArrayBuffer>("slice");
        /// <summary>
        /// Returns a new SharedArrayBuffer whose contents are a copy of this SharedArrayBuffer's bytes from begin, inclusive, up to end, exclusive. If either begin or end is negative, it refers to an index from the end of the array, as opposed to from the beginning.
        /// </summary>
        /// <param name="begin">Zero-based index at which to begin extraction. A negative index can be used, indicating an offset from the end of the sequence.slice(-2) extracts the last two elements in the sequence. If begin is undefined, slice begins from index 0</param>
        /// <returns></returns>
        public SharedArrayBuffer Slice(long begin) => JSRef!.Call<SharedArrayBuffer>("slice", begin);
        /// <summary>
        /// Returns a new SharedArrayBuffer whose contents are a copy of this SharedArrayBuffer's bytes from begin, inclusive, up to end, exclusive. If either begin or end is negative, it refers to an index from the end of the array, as opposed to from the beginning.
        /// </summary>
        /// <param name="begin">Zero-based index at which to begin extraction. A negative index can be used, indicating an offset from the end of the sequence.slice(-2) extracts the last two elements in the sequence. If begin is undefined, slice begins from index 0</param>
        /// <param name="end">Zero-based index before which to end extraction. slice extracts up to but not including end. For example, slice(1, 4) extracts the second element through the fourth element(elements indexed 1, 2, and 3). A negative index can be used, indicating an offset from the end of the sequence.slice(2,-1) extracts the third element through the second-to-last element in the sequence. If end is omitted, slice extracts through the end of the sequence (sab.byteLength).</param>
        /// <returns></returns>
        public SharedArrayBuffer Slice(long begin, long end) => JSRef!.Call<SharedArrayBuffer>("slice", begin, end);
    }
}
