using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    /// <summary>
    /// The CryptoKeyPair dictionary of the Web Crypto API represents a key pair for an asymmetric cryptography algorithm, also known as a public-key algorithm.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CryptoKeyPair
    /// </summary>
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class CryptoKeyPairAsync : CryptoKeyBaseAsync
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public static Task<CryptoKeyPairAsync> New(IJSRuntime jsr) => jsr.NewAsync<CryptoKeyPairAsync>();
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public CryptoKeyPairAsync(IJSObjectReference jsRef) : base(jsRef) { }
        /// <summary>
        /// A CryptoKey object representing the public key. For encryption and decryption algorithms, this key is used to encrypt. For signing and verification algorithms it is used to verify signatures.
        /// </summary>
        public Task Set_PublicKey(CryptoKeyAsync? key) => JSRef.SetAsync("publicKey", key);
        /// <summary>
        /// A CryptoKey object representing the public key. For encryption and decryption algorithms, this key is used to encrypt. For signing and verification algorithms it is used to verify signatures.
        /// </summary>
        public Task<CryptoKeyAsync?> Get_PublicKey() => JSRef.GetAsync<CryptoKeyAsync?>("publicKey");
        /// <summary>
        /// A CryptoKey object representing the private key. For encryption and decryption algorithms, this key is used to decrypt. For signing and verification algorithms it is used to sign.
        /// </summary>
        public Task Set_PrivateKey(CryptoKeyAsync? key) => JSRef.SetAsync("privateKey", key);
        /// <summary>
        /// A CryptoKey object representing the private key. For encryption and decryption algorithms, this key is used to decrypt. For signing and verification algorithms it is used to sign.
        /// </summary>
        public Task<CryptoKeyAsync?> Get_PrivateKey() => JSRef.GetAsync<CryptoKeyAsync?>("privateKey");
    }
}
