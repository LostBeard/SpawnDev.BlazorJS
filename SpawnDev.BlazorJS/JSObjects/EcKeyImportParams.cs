using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The EcKeyImportParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.importKey() or SubtleCrypto.unwrapKey(), when generating any elliptic-curve-based key pair: that is, when the algorithm is identified as either of ECDSA or ECDH.
    /// </summary>
    public class EcKeyImportParams : CryptoImportParams
    {
        /// <summary>
        /// A string. This should be set to ECDSA or ECDH, depending on the algorithm you want to use.
        /// </summary>
        [JsonPropertyName("name")]
        public override string Name { get; set; }
        /// <summary>
        /// A string representing the name of the elliptic curve to use. This may be any of the following names for NIST-approved curves:<br/>
        /// P-256<br/>
        /// P-384<br/>
        /// P-521
        /// </summary>
        [JsonPropertyName("namedCurve")]
        public string NamedCurve { get; set; }
    }
}
