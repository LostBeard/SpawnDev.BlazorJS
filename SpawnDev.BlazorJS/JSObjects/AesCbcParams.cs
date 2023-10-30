namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AesCbcParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.encrypt(), SubtleCrypto.decrypt(), SubtleCrypto.wrapKey(), or SubtleCrypto.unwrapKey(), when using the AES-CBC algorithm.
    /// </summary>
    public class AesCbcParams : EncryptParams
    {
        /// <summary>
        /// A string. This should be set to AES-CBC.
        /// </summary>
        public override string Name { get; set; } = "AES-CBC";
        /// <summary>
        /// An ArrayBuffer, a TypedArray, or a DataView. The initialization vector. Must be 16 bytes, unpredictable, and preferably cryptographically random. However, it need not be secret (for example, it may be transmitted unencrypted along with the ciphertext).
        /// </summary>
        public Union<ArrayBuffer, TypedArray, DataView, byte[]>? Iv { get; set; }
    }
}
