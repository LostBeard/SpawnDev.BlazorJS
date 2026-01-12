using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AesGcmParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.encrypt(), SubtleCrypto.decrypt(), SubtleCrypto.wrapKey(), or SubtleCrypto.unwrapKey(), when using the AES-GCM algorithm.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AesGcmParams
    /// </summary>
    public class AesGcmParams : EncryptParams
    {
        /// <summary>
        /// A string. This should be set to AES-GCM.
        /// </summary>
        public override string Name { get; set; } = "AES-GCM";
        /// <summary>
        /// An ArrayBuffer, a TypedArray, or a DataView with the initialization vector. This must be unique for every encryption operation carried out with a given key. Put another way: never reuse an IV with the same key. The AES-GCM specification recommends that the IV should be 96 bits long, and typically contains bits from a random number generator. Section 8.2 of the specification outlines methods for constructing IVs. Note that the IV does not have to be secret, just unique: so it is OK, for example, to transmit it in the clear alongside the encrypted message.
        /// </summary>
        public BufferSource? Iv { get; set; }
        /// <summary>
        /// An ArrayBuffer, a TypedArray, or a DataView. This contains additional data that will not be encrypted but will be authenticated along with the encrypted data. If additionalData is given here then the same data must be given in the corresponding call to decrypt(): if the data given to the decrypt() call does not match the original data, the decryption will throw an exception. This gives you a way to authenticate associated data without having to encrypt it.<br/>
        /// The bit length of additionalData must be smaller than 2^64 - 1.<br/>
        /// The additionalData property is optional and may be omitted without compromising the security of the encryption operation.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BufferSource? AdditionalData { get; set; }
        /// <summary>
        /// A Number. This determines the size in bits of the authentication tag generated in the encryption operation and used for authentication in the corresponding decryption.<br/>
        /// According to the Web Crypto specification this must have one of the following values: 32, 64, 96, 104, 112, 120, or 128. The AES-GCM specification recommends that it should be 96, 104, 112, 120 or 128, although 32 or 64 bits may be acceptable in some applications: Appendix C of the specification provides additional guidance here.<br/>
        /// tagLength is optional and defaults to 128 if it is not specified.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TagLength { get; set; }
    }
}
