namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The EcdhKeyDeriveParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.deriveKey(), when using the ECDH algorithm.<br/>
    /// ECDH enables two people who each have a key pair consisting of a public and a private key to derive a shared secret. They exchange public keys and use the combination of their private key and the other entity's public key to derive a secret key that they — and no one else — share.<br/>
    /// The parameters for ECDH deriveKey() therefore include the other entity's public key, which is combined with this entity's private key to derive the shared secret.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/EcdhKeyDeriveParams
    /// </summary>
    public class EcdhKeyDeriveParams : KeyDeriveParams
    {
        /// <summary>
        /// A string. This should be set to ECDH.
        /// </summary>
        public override string Name { get; set; } = "ECDH";
        /// <summary>
        /// A CryptoKey object representing the public key of the other entity.
        /// </summary>
        public CryptoKey Public { get; set; }
    }
}
