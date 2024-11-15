using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    /// <summary>
    /// A TypedArray object describes an array-like view of an underlying binary data buffer. There is no global property named TypedArray, nor is there a directly visible TypedArray constructor. Instead, there are a number of different global properties, whose values are typed array constructors for specific element types, listed below. On the following pages you will find common properties and methods that can be used with any typed array containing elements of any type.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/TypedArray
    /// </summary>
    [JsonConverter(typeof(JSObjectAsyncConverter<Uint8ArrayAsync>))]
    public class TypedArrayAsync : JSObjectAsync
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="jsRef"></param>
        public TypedArrayAsync(IJSObjectReference jsRef) : base(jsRef) { }
        /// <summary>
        /// Returns the Uint8Array as a byte array
        /// </summary>
        /// <returns></returns>
        public virtual async Task<byte[]> ReadBytes()
        {
            await using var buffer = await Get_Buffer();
            var ByteOffset = await Get_ByteOffset();
            var ByteLength = await Get_Length();
            await using var uint8Array = await Uint8ArrayAsync.New(JSRuntime, buffer!, ByteOffset, ByteLength);
            return await uint8Array.ReadBytes();
        }
        /// <summary>
        /// Returns the ArrayBuffer referenced by the typed array.
        /// </summary>
        public Task<ArrayBufferAsync?> Get_Buffer() => JSRef.GetAsync<ArrayBufferAsync?>("buffer");
        /// <summary>
        /// Returns the number of elements held in the typed array.
        /// </summary>
        public Task<long> Get_Length() => JSRef!.GetAsync<long>("length");
        /// <summary>
        /// Returns the offset (in bytes) of the typed array from the start of its ArrayBuffer.
        /// </summary>
        public Task<long> Get_ByteOffset() => JSRef!.GetAsync<long>("byteOffset");
    }
}
