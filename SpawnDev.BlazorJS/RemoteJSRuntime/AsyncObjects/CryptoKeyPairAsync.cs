using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    [JsonConverter(typeof(JSObjectAsyncConverter<CryptoKeyPairAsync>))]
    public class CryptoKeyPairAsync : CryptoKeyBaseAsync
    {
        public CryptoKeyPairAsync(IJSObjectReference jsRef) : base(jsRef) { }
        public Task Set_PublicKey(CryptoKeyAsync? key) => JSRef.SetAsync("publicKey", key);
        public Task<CryptoKeyAsync?> Get_PublicKey() => JSRef.GetAsync<CryptoKeyAsync?>("publicKey");
        public Task Set_PrivateKey(CryptoKeyAsync? key) => JSRef.SetAsync("privateKey", key);
        public Task<CryptoKeyAsync?> Get_PrivateKey() => JSRef.GetAsync<CryptoKeyAsync?>("privateKey");
    }
}
