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
    }
}
