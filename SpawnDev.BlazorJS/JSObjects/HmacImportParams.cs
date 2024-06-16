using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HmacImportParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.importKey() or SubtleCrypto.unwrapKey(), when generating a key for the HMAC algorithm.
    /// </summary>
    public class HmacImportParams : CryptoImportParams
    {
        /// <summary>
        /// A string. This should be set to HMAC.
        /// </summary>
        [JsonPropertyName("name")]
        public override string Name { get; set; }
        /// <summary>
        /// A string representing the name of the digest function to use. The can take a value of SHA-256, SHA-384, or SHA-512
        /// </summary>
        [JsonPropertyName("hash")]
        public string Hash { get; set; }
    }
}
