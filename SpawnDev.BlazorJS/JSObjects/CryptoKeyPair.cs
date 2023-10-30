using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CryptoKeyPair dictionary of the Web Crypto API represents a key pair for an asymmetric cryptography algorithm, also known as a public-key algorithm.
    /// </summary>
    public class CryptoKeyPair : CryptoKeyBase
    {
        public CryptoKeyPair(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A CryptoKey object representing the private key. For encryption and decryption algorithms, this key is used to decrypt. For signing and verification algorithms it is used to sign.
        /// </summary>
        public CryptoKey PrivateKey => JSRef.Get<CryptoKey>("privateKey");
        /// <summary>
        /// A CryptoKey object representing the public key. For encryption and decryption algorithms, this key is used to encrypt. For signing and verification algorithms it is used to verify signatures.
        /// </summary>
        public CryptoKey PublicKey => JSRef.Get<CryptoKey>("publicKey");
    }
}
