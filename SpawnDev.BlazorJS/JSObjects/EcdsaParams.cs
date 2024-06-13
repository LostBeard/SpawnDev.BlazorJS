namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The EcdsaParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.sign() or SubtleCrypto.verify() when using the ECDSA algorithm.
    /// </summary>
    public class EcdsaParams : CryptoSignParams
    {
        /// <summary>
        /// A string. This should be set to ECDSA.
        /// </summary>
        public override string Name { get; set; } = "ECDSA";
        /// <summary>
        /// A string. An identifier for the digest algorithm to use. This should be one of the following:<br />
        /// SHA-256: selects the SHA-256 algorithm.<br />
        /// SHA-384: selects the SHA-384 algorithm.<br />
        /// SHA-512: selects the SHA-512 algorithm.<br />
        /// SHA-1: selects the SHA-1 algorithm.<br />
        /// Warning: SHA-1 is supported here but the SHA-1 algorithm is considered vulnerable and should no longer be used.
        /// </summary>
        public string Hash { get; set; }
    }
}
