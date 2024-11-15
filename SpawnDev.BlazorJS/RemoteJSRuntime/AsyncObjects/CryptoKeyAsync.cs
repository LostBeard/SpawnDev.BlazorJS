using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    /// <summary>
    /// The CryptoKey interface of the Web Crypto API represents a cryptographic key obtained from one of the SubtleCrypto methods generateKey(), deriveKey(), importKey(), or unwrapKey().<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CryptoKey
    /// </summary>
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class CryptoKeyAsync : JSObjectAsync
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public CryptoKeyAsync(IJSObjectReference jsRef) : base(jsRef) { }
        /// <summary>
        /// The type of key the object represents. It may take one of the following values: "secret", "private" or "public".
        /// </summary>
        public Task<string> Get_Type() => JSRef!.GetAsync<string>("type");
        /// <summary>
        /// A boolean value indicating whether or not the key may be extracted using SubtleCrypto.exportKey() or SubtleCrypto.wrapKey().
        /// </summary>
        public Task<bool> Get_Extractable() => JSRef!.GetAsync<bool>("extractable");
        /// <summary>
        /// An object describing the algorithm for which this key can be used and any associated extra parameters.<br/>
        /// Use AlgorithmAs to get the full object
        /// </summary>
        public Task<KeyGenParams> Get_Algorithm() => JSRef!.GetAsync<KeyGenParams>("algorithm");
        /// <summary>
        /// An Array of strings, indicating what can be done with the key. Possible values for array elements are "encrypt", "decrypt", "sign", "verify", "deriveKey", "deriveBits", "wrapKey", and "unwrapKey".
        /// </summary>
        public Task<string[]> Get_Usages => JSRef!.GetAsync<string[]>("usages");
    }
}
