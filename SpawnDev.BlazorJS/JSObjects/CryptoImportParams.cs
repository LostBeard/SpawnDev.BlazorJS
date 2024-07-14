using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents the object that should be passed as the algorithm parameter into SubtleCrypto.importKey() or SubtleCrypto.unwrapKey()
    /// </summary>
    public class CryptoImportParams
    {
        /// <summary>
        /// For AES-CTR, AES-CBC, AES-GCM, or AES-KW: Pass the string identifying the algorithm or an object of the form { "name": ALGORITHM }, where ALGORITHM is the name of the algorithm.<br/>
        /// For PBKDF2: Pass the string PBKDF2.<br/>
        /// For HKDF: Pass the string HKDF.
        /// </summary>
        [JsonPropertyName("name")]
        public virtual string Name { get; set; }
    }
}
