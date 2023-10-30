using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The RsaOaepParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.encrypt(), SubtleCrypto.decrypt(), SubtleCrypto.wrapKey(), or SubtleCrypto.unwrapKey(), when using the RSA_OAEP algorithm.
    /// </summary>
    public class RsaOaepParams : EncryptParams
    {
        /// <summary>
        /// A string. This should be set to RSA-OAEP
        /// </summary>
        public override string Name { get; set; } = "RSA-OAEP";
        /// <summary>
        /// An ArrayBuffer, a TypedArray, or a DataView — an array of bytes that does not itself need to be encrypted but which should be bound to the ciphertext. A digest of the label is part of the input to the encryption operation. Unless your application calls for a label, you can just omit this argument and it will not affect the security of the encryption operation.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Union<ArrayBuffer, TypedArray, DataView, byte[]>? Label { get; set; }
    }
}
