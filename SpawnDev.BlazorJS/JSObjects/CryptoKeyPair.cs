using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CryptoKeyPair dictionary of the Web Crypto API represents a key pair for an asymmetric cryptography algorithm, also known as a public-key algorithm.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/CryptoKeyPair
    /// </summary>
    public class CryptoKeyPair : CryptoKeyBase
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public CryptoKeyPair(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new instance of Object represented as a CryptoKeyPair
        /// </summary>
        public CryptoKeyPair() : base(JS.New("Object")) { }
        /// <summary>
        /// A CryptoKey object representing the private key. For encryption and decryption algorithms, this key is used to decrypt. For signing and verification algorithms it is used to sign.
        /// </summary>
        public CryptoKey PrivateKey { get => JSRef!.Get<CryptoKey>("privateKey"); set => JSRef!.Set("privateKey", value); }
        /// <summary>
        /// A CryptoKey object representing the public key. For encryption and decryption algorithms, this key is used to encrypt. For signing and verification algorithms it is used to verify signatures.
        /// </summary>
        public CryptoKey PublicKey { get => JSRef!.Get<CryptoKey>("publicKey"); set => JSRef!.Set("publicKey", value); }
    }
}
