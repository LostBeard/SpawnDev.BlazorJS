using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    /// <summary>
    /// The ArrayBuffer object is used to represent a generic raw binary data buffer.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer
    /// </summary>
    [JsonConverter(typeof(JSObjectAsyncConverter<ArrayBufferAsync>))]
    public class ArrayBufferAsync : JSObjectAsync
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public static async Task<ArrayBufferAsync> New(IJSRuntime jsr, byte[] data)
        {
            await using var uint8Array = await jsr.ReturnAs<Uint8ArrayAsync>(data);
            var arrayBuffer =  await uint8Array.Get_Buffer();
            return arrayBuffer!;
        }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="jsRef"></param>
        public ArrayBufferAsync(IJSObjectReference jsRef) : base(jsRef) { }
        /// <summary>
        /// Returns the array buffer as a byte array
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> ReadBytes()
        {
            await using var uint8Array = await Uint8ArrayAsync.New(JSRuntime, this);
            var bytes = await uint8Array.ReadBytes();
            return bytes;
        }
    }
}
