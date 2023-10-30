using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Crypto.subtle read-only property returns a SubtleCrypto which can then be used to perform low-level cryptographic operations.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/SubtleCrypto<br />
    /// TODO - finish class
    /// </summary>
    public class SubtleCrypto : JSObject
    {
        #region Constructors
        public SubtleCrypto(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Methods
        //public void Decrypt() => JSRef.CallVoid("decrypt");
        //public void DeriveBits() => JSRef.CallVoid("deriveBits");
        //public void DeriveKey() => JSRef.CallVoid("deriveKey");
        //public void Digest() => JSRef.CallVoid("digest");
        /// <summary>
        /// The encrypt() method of the SubtleCrypto interface encrypts data. It takes as its arguments a key to encrypt with, some algorithm-specific parameters, and the data to encrypt(also known as "plaintext"). It returns a Promise which will be fulfilled with the encrypted data(also known as "ciphertext").
        /// </summary>
        public Task<ArrayBuffer> Encrypt(Union<RsaOaepParams, AesCtrParams, AesCbcParams, AesGcmParams> algorithm, CryptoKey key, Union<ArrayBuffer, TypedArray, DataView, byte[]> data) => JSRef.CallAsync<ArrayBuffer>("encrypt", algorithm, key, data);
        /// <summary>
        /// The exportKey() method of the SubtleCrypto interface exports a key: that is, it takes as input a CryptoKey object and gives you the key in an external, portable format.
        /// To export a key, the key must have CryptoKey.extractable set to true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="format">raw, pkcs8, spki, or jwk</param>
        /// <param name="key">the CryptoKey to export</param>
        /// <returns></returns>
        public Task<T> ExportKey<T>(string format, CryptoKey key) => JSRef.CallAsync<T>("exportKey", format, key);
        /// <summary>
        /// Export key in SubjectPublicKeyInfo format.<br />
        /// You can use this format to import or export RSA or Elliptic Curve public keys.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<ArrayBuffer> ExportKeySpki(CryptoKey key) => JSRef.CallAsync<ArrayBuffer>("exportKey", "spki", key);
        /// <summary>
        /// Export key in PKCS #8 format.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<ArrayBuffer> ExportKeyPkcs8(CryptoKey key) => JSRef.CallAsync<ArrayBuffer>("exportKey", "pkcs8", key);
        /// <summary>
        /// You can use this format to import or export AES or HMAC secret keys, or Elliptic Curve public keys.<br />
        /// In this format the key is supplied as an ArrayBuffer containing the raw bytes for the key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<ArrayBuffer> ExportKeyRaw(CryptoKey key) => JSRef.CallAsync<ArrayBuffer>("exportKey", "raw", key);
        /// <summary>
        /// You can use JSON Web Key format to import or export RSA or Elliptic Curve public or private keys, as well as AES and HMAC secret keys.<br />
        /// JSON Web Key format is defined in RFC 7517. It describes a way to represent public, private, and secret keys as JSON objects.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<string> ExportKeyJwk(CryptoKey key) => JSRef.CallAsync<string>("exportKey", "jwk", key);
        /// <summary>
        /// Use the generateKey() method of the SubtleCrypto interface to generate a new key (for symmetric algorithms) or key pair (for public-key algorithms).
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="extractable"></param>
        /// <param name="keyUsages"></param>
        /// <returns></returns>
        public Task<T> GenerateKey<T>(Union<RsaHashedKeyGenParams, EcKeyGenParams, HmacKeyGenParams, AesKeyGenParams> algorithm, bool extractable, string[] keyUsages) where T : CryptoKeyBase => JSRef.CallAsync<T>("generateKey", algorithm, extractable, keyUsages);
        //public void ImportKey() => JSRef.CallVoid("importKey");
        //public void Sign() => JSRef.CallVoid("sign");
        //public void UnwrapKey() => JSRef.CallVoid("unwrapKey");
        //public void Verify() => JSRef.CallVoid("verify");
        //public void WrapKey() => JSRef.CallVoid("wrapKey");
        #endregion
    }
}
