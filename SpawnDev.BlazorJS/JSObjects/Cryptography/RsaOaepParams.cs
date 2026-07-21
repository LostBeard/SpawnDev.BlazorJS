using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The RsaOaepParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.encrypt(), SubtleCrypto.decrypt(), SubtleCrypto.wrapKey(), or SubtleCrypto.unwrapKey(), when using the RSA_OAEP algorithm.
    /// </summary>
    public class RsaOaepParams : EncryptParams
    {
        /// <summary>
        /// Creates a new instance. The algorithm name is fixed by this type, so a caller does
        /// not supply it even though the base declares it required.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public RsaOaepParams()
        {
            Name = "RSA-OAEP";
        }
        // Name is inherited from the base and set in the constructor above. It is deliberately NOT
        // overridden here: an override auto-property would reintroduce CS8618, because nullable
        // analysis does not count assigning a VIRTUAL property in a constructor as definite
        // assignment. The base declares it required, which is what makes the base warning free.
        /// <summary>
        /// An ArrayBuffer, a TypedArray, or a DataView — an array of bytes that does not itself need to be encrypted but which should be bound to the ciphertext. A digest of the label is part of the input to the encryption operation. Unless your application calls for a label, you can just omit this argument and it will not affect the security of the encryption operation.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BufferSource? Label { get; set; }
    }
}
