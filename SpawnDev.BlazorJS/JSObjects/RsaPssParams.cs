namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The RsaPssParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.sign() or SubtleCrypto.verify(), when using the RSA-PSS algorithm.
    /// </summary>
    public class RsaPssParams : CryptoSignParams
    {
        /// <summary>
        /// A string. This should be set to RSA-PSS.
        /// </summary>
        public override string Name { get; set; } = "RSA-PSS";
        /// <summary>
        /// A long integer representing the length of the random salt to use, in bytes.<br />
        /// RFC 3447 says that "Typical salt lengths" are either 0 or the length of the output of the digest algorithm that was selected when this key was generated.For example, if you use SHA-256 as the digest algorithm, this could be 32.
        /// </summary>
        public int SaltLength { get; set; } = 32;
    }
}
