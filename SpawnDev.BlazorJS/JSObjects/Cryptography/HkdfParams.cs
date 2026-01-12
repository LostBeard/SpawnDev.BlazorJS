namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HkdfParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.deriveKey(), when using the HKDF algorithm.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/HkdfParams
    /// </summary>
    public class HkdfParams : KeyDeriveParams
    {
        /// <summary>
        /// A string. This should be set to HKDF.
        /// </summary>
        public override string Name { get; set; } = "HKDF";
        /// <summary>
        /// A string representing the digest algorithm to use. This may be one of:<br/>
        /// SHA-1<br/>
        /// SHA-256<br/>
        /// SHA-384<br/>
        /// SHA-512
        /// </summary>
        public string Hash { get; set; }
        /// <summary>
        /// An ArrayBuffer, a TypedArray, or a DataView. The HKDF specification states that adding salt "adds significantly to the strength of HKDF". Ideally, the salt is a random or pseudo-random value with the same length as the output of the digest function. Unlike the input key material passed into deriveKey(), salt does not need to be kept secret.
        /// </summary>
        public BufferSource Salt { get; set; }
        /// <summary>
        /// An ArrayBuffer, a TypedArray, or a DataView representing application-specific contextual information. This is used to bind the derived key to an application or context, and enables you to derive different keys for different contexts while using the same input key material. It's important that this should be independent of the input key material itself. This property is required but may be an empty buffer.
        /// </summary>
        public BufferSource Info { get; set; }
    }
}
