using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AesKeyGenParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.generateKey(), when generating an AES key: that is, when the algorithm is identified as any of AES-CBC, AES-CTR, AES-GCM, or AES-KW.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AesKeyGenParams
    /// </summary>
    public class AesKeyGenParams : KeyGenParams
    {
        /// <summary>
        /// A string. This should be set to AES-CBC, AES-CTR, AES-GCM, or AES-KW, depending on the algorithm you want to use.
        /// </summary>
        [JsonPropertyName("name")]
        public override string Name { get; set; }
        /// <summary>
        /// A Number — the length in bits of the key to generate. This must be one of: 128, 192, or 256.
        /// </summary>
        [JsonPropertyName("length")]
        public int Length { get; set; }
    }
}
