namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The RsaPssParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.sign() or SubtleCrypto.verify(), when using the RSA-PSS algorithm.
    /// </summary>
    public class RsaPssParams : CryptoSignParams
    {
        /// <summary>
        /// Creates a new instance. The algorithm name is fixed by this type, so a caller does
        /// not supply it even though the base declares it required.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public RsaPssParams()
        {
            Name = "RSA-PSS";
        }
        // Name is inherited from the base and set in the constructor above. It is deliberately NOT
        // overridden here: an override auto-property would reintroduce CS8618, because nullable
        // analysis does not count assigning a VIRTUAL property in a constructor as definite
        // assignment. The base declares it required, which is what makes the base warning free.
        /// <summary>
        /// A long integer representing the length of the random salt to use, in bytes.<br/>
        /// RFC 3447 says that "Typical salt lengths" are either 0 or the length of the output of the digest algorithm that was selected when this key was generated.For example, if you use SHA-256 as the digest algorithm, this could be 32.
        /// </summary>
        public int SaltLength { get; set; } = 32;
    }
}
