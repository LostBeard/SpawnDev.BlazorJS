using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    [JsonConverter(typeof(JSObjectAsyncConverter<Uint8ArrayAsync>))]
    public class Uint8ArrayAsync : JSObjectAsync
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="jsRef"></param>
        public Uint8ArrayAsync(IJSObjectReference jsRef) : base(jsRef) { }
        /// <summary>
        /// Returns the Uint8Array as a byte array
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> ReadBytes()
        {
            var bytes = await JSRef.As<byte[]>();
            return bytes;
        }
        public Task<ArrayBufferAsync?> Get_Buffer() => JSRef.GetAsync<ArrayBufferAsync?>("buffer");
    }
}
