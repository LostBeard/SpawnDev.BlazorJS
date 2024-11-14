using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    [JsonConverter(typeof(JSObjectAsyncConverter<CryptoKeyBaseAsync>))]
    public class CryptoKeyBaseAsync : JSObjectAsync
    {
        public CryptoKeyBaseAsync(IJSObjectReference jsRef) : base(jsRef) { }
    }
}
