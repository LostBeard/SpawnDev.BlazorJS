using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HmacKeyGenParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.generateKey(), when generating a key for the HMAC algorithm.
    /// </summary>
    public class HmacKeyGenParams : KeyGenParams
    {
        /// <summary>
        /// A string. This should be set to HMAC.
        /// </summary>
        [JsonPropertyName("name")]
        public override string Name { get; set; }
        /// <summary>
        /// A string representing the name of the digest function to use. You can pass any of SHA-1, SHA-256, SHA-384, or SHA-512 here.
        /// </summary>
        [JsonPropertyName("hash")]
        public string Hash { get; set; }
        /// <summary>
        /// A Number — the length in bits of the key. If this is omitted, the length of the key is equal to the block size of the hash function you have chosen. Unless you have a good reason to use a different length, omit this property and use the default.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("length")]
        public int? Length { get; set; }
    }
}
