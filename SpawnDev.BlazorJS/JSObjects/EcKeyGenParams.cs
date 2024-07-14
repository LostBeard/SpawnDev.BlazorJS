using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The EcKeyGenParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.generateKey(), when generating any elliptic-curve-based key pair: that is, when the algorithm is identified as either of ECDSA or ECDH.
    /// </summary>
    public class EcKeyGenParams : KeyGenParams
    {
        /// <summary>
        /// A string. This should be set to:<br/>
        /// ECDSA<br/>
        /// ECDH
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
