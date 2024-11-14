using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    [JsonConverter(typeof(JSObjectAsyncConverter<ArrayBufferAsync>))]
    public class ArrayBufferAsync : JSObjectAsync
    {
        public ArrayBufferAsync(IJSObjectReference jsRef) : base(jsRef) { }
        public async Task<byte[]> ReadBytes()
        {
            await using var uint8Array = await JSI.GlobalPropertyNew<Uint8ArrayAsync>("Uint8Array", new object[] { JSRef });
            var bytes = await uint8Array.ReadBytes();
            return bytes;
        }
    }
}
