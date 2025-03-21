﻿using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    /// <summary>
    /// Base class for CryptoKeyPairAsync and CryptoKeyAsync
    /// </summary>
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class CryptoKeyBaseAsync : JSObjectAsync
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public CryptoKeyBaseAsync(IJSObjectReference jsRef) : base(jsRef) { }
    }
}
