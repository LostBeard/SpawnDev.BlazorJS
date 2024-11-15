using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    /// <summary>
    /// Base class for CryptoKeyPair and CryptoKey
    /// </summary>
    [JsonConverter(typeof(JSObjectAsyncConverter<CryptoKeyBaseAsync>))]
    public class CryptoKeyBaseAsync : JSObjectAsync
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public CryptoKeyBaseAsync(IJSObjectReference jsRef) : base(jsRef) { }
    }
}
