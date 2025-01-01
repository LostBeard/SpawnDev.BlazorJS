using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    /// <summary>
    /// The Uint8Array typed array represents an array of 8-bit unsigned integers. Once established, you can reference elements in the array using the object's methods, or using standard array index syntax (that is, using bracket notation).<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint8Array
    /// </summary>
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class Uint8ArrayAsync : TypedArrayAsync
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public static Task<Uint8ArrayAsync> New(IJSRuntime jsr, long length) => jsr.NewAsync<Uint8ArrayAsync>("Uint8Array", length);
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public static Task<Uint8ArrayAsync> New(IJSRuntime jsr, byte[] data) => jsr.NewAsync<Uint8ArrayAsync>("Uint8Array", data);
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public static Task<Uint8ArrayAsync> New(IJSRuntime jsr, ArrayBufferAsync arrayBuffer) => jsr.NewAsync<Uint8ArrayAsync>("Uint8Array", arrayBuffer);
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public static Task<Uint8ArrayAsync> New(IJSRuntime jsr, ArrayBufferAsync arrayBuffer, long byteOffset) => jsr.NewAsync<Uint8ArrayAsync>("Uint8Array", arrayBuffer, byteOffset);
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public static Task<Uint8ArrayAsync> New(IJSRuntime jsr, ArrayBufferAsync arrayBuffer, long byteOffset, long length) => jsr.NewAsync<Uint8ArrayAsync>("Uint8Array", arrayBuffer, byteOffset, length);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="jsRef"></param>
        public Uint8ArrayAsync(IJSObjectReference jsRef) : base(jsRef) { }
        /// <summary>
        /// Returns the Uint8Array as a byte array
        /// </summary>
        /// <returns></returns>
        public override Task<byte[]> ReadBytes() => JSRef.As<byte[]>();
        /// <summary>
        /// Fills all the elements of an array from a start index to an end index with a static value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task FillVoid(byte value) => JSRef!.CallVoidAsync("fill", value);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <returns></returns>
        public Task<Uint8ArrayAsync> SubArray() => JSRef!.CallAsync<Uint8ArrayAsync>("subarray");
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <returns></returns>
        public Task<Uint8ArrayAsync> SubArray(long start) => JSRef!.CallAsync<Uint8ArrayAsync>("subarray", start);
        /// <summary>
        /// The subarray() method of TypedArray instances returns a new typed array on the same ArrayBuffer store and with the same element types as this typed array. The begin offset is inclusive and the end offset is exclusive.
        /// </summary>
        /// <param name="start">Element to begin at. The offset is inclusive. The whole array will be included in the new view if this value is not specified.</param>
        /// <param name="end">Element to end at. The offset is exclusive. If not specified, all elements from the one specified by begin to the end of the array are included in the new view.</param>
        /// <returns></returns>
        public Task<Uint8ArrayAsync> SubArray(long start, long end) => JSRef!.CallAsync<Uint8ArrayAsync>("subarray", start, end);
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <returns></returns>
        public Task<Uint8ArrayAsync> Slice() => JSRef!.CallAsync<Uint8ArrayAsync>("slice");
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public Task<Uint8ArrayAsync> Slice(long start) => JSRef!.CallAsync<Uint8ArrayAsync>("slice", start);
        /// <summary>
        /// Extracts a section of an array and returns a new array. See also Array.prototype.slice().
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Task<Uint8ArrayAsync> Slice(long start, long end) => JSRef!.CallAsync<Uint8ArrayAsync>("slice", start, end);
    }
}
