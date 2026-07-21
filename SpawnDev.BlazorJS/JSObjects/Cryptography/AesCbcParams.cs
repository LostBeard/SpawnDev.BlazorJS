namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AesCbcParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.encrypt(), SubtleCrypto.decrypt(), SubtleCrypto.wrapKey(), or SubtleCrypto.unwrapKey(), when using the AES-CBC algorithm.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AesCbcParams
    /// </summary>
    public class AesCbcParams : EncryptParams
    {
        /// <summary>
        /// Creates a new instance. The algorithm name is fixed by this type, so a caller does
        /// not supply it even though the base declares it required.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public AesCbcParams()
        {
            Name = "AES-CBC";
        }
        // Name is inherited from EncryptParams and set in the constructor above. It is deliberately NOT
        // overridden here: an override auto-property would reintroduce CS8618, because nullable analysis
        // does not count assigning a VIRTUAL property in a constructor as definite assignment - it cannot
        // know a further override actually stores the value. The base declares it required, which is what
        // makes the base itself warning free.
        /// <summary>
        /// An ArrayBuffer, a TypedArray, or a DataView. The initialization vector. Must be 16 bytes, unpredictable, and preferably cryptographically random. However, it need not be secret (for example, it may be transmitted unencrypted along with the ciphertext).
        /// </summary>
        public BufferSource? Iv { get; set; }
    }
}
