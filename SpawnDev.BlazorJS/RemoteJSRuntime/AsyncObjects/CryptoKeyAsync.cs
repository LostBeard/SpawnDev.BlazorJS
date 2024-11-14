using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    [JsonConverter(typeof(JSObjectAsyncConverter<CryptoKeyAsync>))]
    public class CryptoKeyAsync : CryptoKeyBaseAsync
    {
        public CryptoKeyAsync(IJSObjectReference jsRef) : base(jsRef) { }
    }
}
