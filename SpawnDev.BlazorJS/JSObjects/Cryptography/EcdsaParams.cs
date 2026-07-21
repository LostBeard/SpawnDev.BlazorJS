namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The EcdsaParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.sign() or SubtleCrypto.verify() when using the ECDSA algorithm.
    /// </summary>
    public class EcdsaParams : CryptoSignParams
    {
        /// <summary>
        /// Creates a new instance. The algorithm name is fixed by this type, so a caller does
        /// not supply it even though the base declares it required.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public EcdsaParams()
        {
            Name = "ECDSA";
        }
        // Name is inherited from the base and set in the constructor above. It is deliberately NOT
        // overridden here: an override auto-property would reintroduce CS8618, because nullable
        // analysis does not count assigning a VIRTUAL property in a constructor as definite
        // assignment. The base declares it required, which is what makes the base warning free.
        /// <summary>
        /// A string. An identifier for the digest algorithm to use. This should be one of the following:<br/>
        /// SHA-256: selects the SHA-256 algorithm.<br/>
        /// SHA-384: selects the SHA-384 algorithm.<br/>
        /// SHA-512: selects the SHA-512 algorithm.<br/>
        /// SHA-1: selects the SHA-1 algorithm.<br/>
        /// Warning: SHA-1 is supported here but the SHA-1 algorithm is considered vulnerable and should no longer be used.
        /// </summary>
        public string Hash { get; set; }
    }
}
