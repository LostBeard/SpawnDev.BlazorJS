namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The RsaHashedImportParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.importKey() or SubtleCrypto.unwrapKey(), when importing any RSA-based key pair: that is, when the algorithm is identified as any of RSASSA-PKCS1-v1_5, RSA-PSS, or RSA-OAEP.
    /// </summary>
    public class RsaHashedImportParams : CryptoImportParams
    {
        /// <summary>
        /// A string. This should be set to RSASSA-PKCS1-v1_5, RSA-PSS, or RSA-OAEP, depending on the algorithm you want to use.
        /// </summary>
        public override string Name { get; set; }
        /// <summary>
        /// A string representing the name of the digest function to use. This can be one of SHA-256, SHA-384, or SHA-512
        /// </summary>
        public string Hash { get; set; }
    }
}
