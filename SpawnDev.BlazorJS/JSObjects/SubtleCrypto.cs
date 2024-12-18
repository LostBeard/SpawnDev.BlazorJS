using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Crypto.subtle read-only property returns a SubtleCrypto which can then be used to perform low-level cryptographic operations.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/SubtleCrypto<br/>
    /// </summary>
    public class SubtleCrypto : JSObject
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public SubtleCrypto(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Methods
        /// <summary>
        /// The digest() method of the SubtleCrypto interface generates a digest of the given data. A digest is a short fixed-length value derived from some variable-length input. Cryptographic digests should exhibit collision-resistance, meaning that it's hard to come up with two different inputs that have the same digest value.
        /// </summary>
        /// <param name="algorithm">
        /// The string names the hash function to use. Supported values are:<br/>
        /// "SHA-1" (but don't use this in cryptographic applications)<br/>
        /// "SHA-256"<br/>
        /// "SHA-384"<br/>
        /// "SHA-512".
        /// </param>
        /// <param name="data">An ArrayBuffer, a TypedArray or a DataView object containing the data to be digested.</param>
        /// <returns>A Promise that fulfills with an ArrayBuffer containing the digest.</returns>
        public Task<ArrayBuffer> Digest(string algorithm, Union<ArrayBuffer, TypedArray, DataView, byte[]> data) => JSRef!.CallAsync<ArrayBuffer>("digest", algorithm, data);
        /// <summary>
        /// The decrypt() method of the SubtleCrypto interface decrypts some encrypted data. It takes as arguments a key to decrypt with, some optional extra parameters, and the data to decrypt (also known as "ciphertext"). It returns a Promise which will be fulfilled with the decrypted data (also known as "plaintext").<br/>
        /// </summary>
        /// <param name="algorithm">
        /// An object specifying the algorithm to be used and any extra parameters if required:<br/>
        /// - To use RSA-OAEP, pass an RsaOaepParams object.<br/>
        /// - To use AES-CTR, pass an AesCtrParams object.<br/>
        /// - To use AES-CBC, pass an AesCbcParams object.<br/>
        /// - To use AES-GCM, pass an AesGcmParams object.<br/>
        /// - To use AES-KW, pass an AesKwParams object.
        /// </param>
        /// <param name="key">A CryptoKey containing the key to be used for decryption. If using RSA-OAEP, this is the privateKey property of the CryptoKeyPair object.</param>
        /// <param name="data">An ArrayBuffer, a TypedArray, or a DataView containing the data to be decrypted (also known as ciphertext).</param>
        /// <returns>A Promise that fulfills with an ArrayBuffer containing the plaintext.</returns>
        public Task<ArrayBuffer> Decrypt(EncryptParams algorithm, CryptoKey key, Union<ArrayBuffer, TypedArray, DataView, byte[]> data) => JSRef!.CallAsync<ArrayBuffer>("decrypt", algorithm, key, data);
        /// <summary>
        /// The encrypt() method of the SubtleCrypto interface encrypts data. It takes as its arguments a key to encrypt with, some algorithm-specific parameters, and the data to encrypt(also known as "plaintext"). It returns a Promise which will be fulfilled with the encrypted data(also known as "ciphertext").
        /// </summary>
        /// <param name="algorithm">
        /// An object specifying the algorithm to be used and any extra parameters if required:<br/>
        /// - To use RSA-OAEP, pass an RsaOaepParams object.<br/>
        /// - To use AES-CTR, pass an AesCtrParams object.<br/>
        /// - To use AES-CBC, pass an AesCbcParams object.<br/>
        /// - To use AES-GCM, pass an AesGcmParams object.<br/>
        /// - To use AES-KW, pass an AesKwParams object.
        /// </param>
        /// <param name="key">A CryptoKey containing the key to be used for encryption.</param>
        /// <param name="data">An ArrayBuffer, a TypedArray, or a DataView containing the data to be encrypted (also known as the plaintext).</param>
        /// <returns>A Promise that fulfills with an ArrayBuffer containing the "ciphertext".</returns>
        public Task<ArrayBuffer> Encrypt(EncryptParams algorithm, CryptoKey key, Union<ArrayBuffer, TypedArray, DataView, byte[]> data) => JSRef!.CallAsync<ArrayBuffer>("encrypt", algorithm, key, data);
        /// <summary>
        /// The exportKey() method of the SubtleCrypto interface exports a key: that is, it takes as input a CryptoKey object and gives you the key in an external, portable format.
        /// To export a key, the key must have CryptoKey.extractable set to true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="format">
        /// A string describing the data format of the key to export. It can be one of the following:<br/>
        /// - "raw" - Raw format.<br/>
        /// - "pkcs8" - Public-Key Cryptography Standards (PKCS) #8 format.<br/>
        /// - "spki" - SubjectPublicKeyInfo format.<br/>
        /// - "jwk" - JSON Web Key format.<br/>
        /// </param>
        /// <param name="key">the CryptoKey to export</param>
        /// <returns>
        /// If format was jwk, then the Promise that fulfills with a JSON object containing the key.<br/>
        /// Otherwise the Promise that fulfills with an ArrayBuffer containing the key.
        /// </returns>
        public Task<T> ExportKey<T>(string format, CryptoKey key) => JSRef!.CallAsync<T>("exportKey", format, key);
        /// <summary>
        /// Export key in SubjectPublicKeyInfo format.<br/>
        /// Can be used to export RSA or Elliptic Curve public keys.
        /// </summary>
        /// <param name="key">the CryptoKey to export</param>
        /// <returns>A Promise that fulfills with an ArrayBuffer containing the key</returns>
        public Task<ArrayBuffer> ExportKeySpki(CryptoKey key) => JSRef!.CallAsync<ArrayBuffer>("exportKey", "spki", key);
        /// <summary>
        /// Export key in PKCS #8 format. Can be used to export RSA or Elliptic Curve private keys.
        /// </summary>
        /// <param name="key">the CryptoKey to export</param>
        /// <returns>A Promise that fulfills with an ArrayBuffer containing the key</returns>
        public Task<ArrayBuffer> ExportKeyPkcs8(CryptoKey key) => JSRef!.CallAsync<ArrayBuffer>("exportKey", "pkcs8", key);
        /// <summary>
        /// You can use this format to export AES or HMAC secret keys, or Elliptic Curve public keys.<br/>
        /// In this format the key is supplied as an ArrayBuffer containing the raw bytes for the key.
        /// </summary>
        /// <param name="key">the CryptoKey to export</param>
        /// <returns>A Promise that fulfills with an ArrayBuffer containing the key</returns>
        public Task<ArrayBuffer> ExportKeyRaw(CryptoKey key) => JSRef!.CallAsync<ArrayBuffer>("exportKey", "raw", key);
        /// <summary>
        /// You can use JSON Web Key format to export RSA or Elliptic Curve public or private keys, as well as AES and HMAC secret keys.<br/>
        /// JSON Web Key format is defined in RFC 7517. It describes a way to represent public, private, and secret keys as JSON objects.
        /// </summary>
        /// <param name="key">the CryptoKey to export</param>
        /// <returns>A Promise that fulfills with a JSON object containing the key</returns>
        public Task<JSObject> ExportKeyJwk(CryptoKey key) => JSRef!.CallAsync<JSObject>("exportKey", "jwk", key);
        /// <summary>
        /// Use the generateKey() method of the SubtleCrypto interface to generate a new key (for symmetric algorithms) or key pair (for public-key algorithms).
        /// </summary>
        /// <param name="algorithm">
        /// An object defining the type of key to generate and providing extra algorithm-specific parameters.<br/>
        /// For RSASSA-PKCS1-v1_5, RSA-PSS, or RSA-OAEP: pass an RsaHashedKeyGenParams object.<br/>
        /// For ECDSA or ECDH: pass an EcKeyGenParams object.<br/>
        /// For HMAC: pass an HmacKeyGenParams object.<br/>
        /// For AES-CTR, AES-CBC, AES-GCM, or AES-KW: pass an AesKeyGenParams object.
        /// </param>
        /// <param name="extractable">A boolean value indicating whether it will be possible to export the key using SubtleCrypto.exportKey() or SubtleCrypto.wrapKey().</param>
        /// <param name="keyUsages">An Array indicating what can be done with the key. Possible array values are: encrypt, decrypt, sign, verify, deriveKey, deriveBits, wrapKey, or unwrapKey.</param>
        /// <returns>A Promise that fulfills with a CryptoKey (for symmetric algorithms) or a CryptoKeyPair (for public-key algorithms).</returns>
        public Task<T> GenerateKey<T>(Union<RsaHashedKeyGenParams, EcKeyGenParams, HmacKeyGenParams, AesKeyGenParams> algorithm, bool extractable, IEnumerable<string> keyUsages) where T : CryptoKeyBase => JSRef!.CallAsync<T>("generateKey", algorithm, extractable, keyUsages);
        /// <summary>
        /// The importKey() method of the SubtleCrypto interface imports a key: that is, it takes as input a key in an external, portable format and gives you a CryptoKey object that you can use in the Web Crypto API.
        /// </summary>
        /// <param name="format">
        /// A string describing the data format of the key to import. It can be one of the following:<br/>
        /// - "raw" - Raw format.<br/>
        /// - "pkcs8" - Public-Key Cryptography Standards (PKCS) #8 format.<br/>
        /// - "spki" - SubjectPublicKeyInfo format.<br/>
        /// - "jwk" - JSON Web Key format.<br/>
        /// </param>
        /// <param name="keyData">An ArrayBuffer, a TypedArray, a DataView, or a JSONWebKey object containing the key in the given format.</param>
        /// <param name="algorithm">An object defining the type of key to import and providing extra algorithm-specific parameters. CryptoImportParams, RsaHashedImportParams, EcKeyImportParams, HmacImportParams, or a string.</param>
        /// <param name="extractable">A boolean value indicating whether it will be possible to export the key using SubtleCrypto.exportKey() or SubtleCrypto.wrapKey().</param>
        /// <param name="keyUsages">An Array indicating what can be done with the key. Possible array values are: encrypt, decrypt, sign, verify, deriveKey, deriveBits, wrapKey, or unwrapKey.</param>
        /// <returns>A Promise that fulfills with the imported key as a CryptoKey object.</returns>
        public Task<CryptoKey> ImportKey(string format, Union<ArrayBuffer, TypedArray, DataView, byte[], JSObject> keyData, Union<CryptoImportParams, string> algorithm, bool extractable, IEnumerable<string> keyUsages) => JSRef!.CallAsync<CryptoKey>("importKey", format, keyData, algorithm, extractable, keyUsages);
        /// <summary>
        /// The importKey() method of the SubtleCrypto interface imports a key: that is, it takes as input a key in an external, portable format and gives you a CryptoKey object that you can use in the Web Crypto API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="format">
        /// A string describing the data format of the key to import. It can be one of the following:<br/>
        /// - "raw" - Raw format.<br/>
        /// - "pkcs8" - Public-Key Cryptography Standards (PKCS) #8 format.<br/>
        /// - "spki" - SubjectPublicKeyInfo format.<br/>
        /// - "jwk" - JSON Web Key format.<br/>
        /// </param>
        /// <param name="keyData">An ArrayBuffer, a TypedArray, a DataView, or a JSONWebKey object containing the key in the given format.</param>
        /// <param name="algorithm">An object defining the type of key to import and providing extra algorithm-specific parameters. CryptoImportParams, RsaHashedImportParams, EcKeyImportParams, HmacImportParams, or a string.</param>
        /// <param name="extractable">A boolean value indicating whether it will be possible to export the key using SubtleCrypto.exportKey() or SubtleCrypto.wrapKey().</param>
        /// <param name="keyUsages">An Array indicating what can be done with the key. Possible array values are: encrypt, decrypt, sign, verify, deriveKey, deriveBits, wrapKey, or unwrapKey.</param>
        /// <returns>A Promise that fulfills with the imported key as a CryptoKey object.</returns>
        public Task<T> ImportKey<T>(string format, Union<ArrayBuffer, TypedArray, DataView, byte[], JSObject> keyData, Union<CryptoImportParams, string> algorithm, bool extractable, IEnumerable<string> keyUsages) where T : CryptoKeyBase => JSRef!.CallAsync<T>("importKey", format, keyData, algorithm, extractable, keyUsages);
        /// <summary>
        /// The sign() method of the SubtleCrypto interface generates a digital signature.<br/>
        /// It takes as its arguments a key to sign with, some algorithm-specific parameters, and the data to sign. It returns a Promise which will be fulfilled with the signature.
        /// </summary>
        /// <param name="algorithm">A string or object that specifies the signature algorithm to use and its parameters</param>
        /// <param name="key">A CryptoKey object containing the key to be used for signing. If algorithm identifies a public-key cryptosystem, this is the private key.</param>
        /// <param name="data">An ArrayBuffer, a TypedArray, byte array or a DataView object containing the data to be signed.</param>
        /// <returns>A Promise that fulfills with an ArrayBuffer containing the signature.</returns>
        public Task<ArrayBuffer> Sign(Union<CryptoSignParams, string> algorithm, CryptoKey key, Union<ArrayBuffer, TypedArray, DataView, byte[]> data) => JSRef!.CallAsync<ArrayBuffer>("sign", algorithm, key, data);
        /// <summary>
        /// The verify() method of the SubtleCrypto interface verifies a digital signature.<br/>
        /// It takes as its arguments a key to verify the signature with, some algorithm-specific parameters, the signature, and the original signed data.It returns a Promise which will be fulfilled with a boolean value indicating whether the signature is valid.
        /// </summary>
        /// <param name="algorithm">A string or object defining the algorithm to use, and for some algorithm choices, some extra parameters. The values given for the extra parameters must match those passed into the corresponding sign() call.</param>
        /// <param name="key">A CryptoKey containing the key that will be used to verify the signature. It is the secret key for a symmetric algorithm and the public key for a public-key system.</param>
        /// <param name="signature">An ArrayBuffer, a TypedArray, byte array or a DataView object containing the signature to verify.</param>
        /// <param name="data">An ArrayBuffer, a TypedArray, byte array or a DataView object containing the data whose signature is to be verified.</param>
        /// <returns>A Promise that fulfills with a boolean value: true if the signature is valid, false otherwise.</returns>
        public Task<bool> Verify(Union<CryptoSignParams, string> algorithm, CryptoKey key, Union<ArrayBuffer, TypedArray, DataView, byte[]> signature, Union<ArrayBuffer, TypedArray, DataView, byte[]> data) => JSRef!.CallAsync<bool>("verify", algorithm, key, signature, data);
        /// <summary>
        /// The unwrapKey() method of the SubtleCrypto interface "unwraps" a key. This means that it takes as its input a key that has been exported and then encrypted (also called "wrapped"). It decrypts the key and then imports it, returning a CryptoKey object that can be used in the Web Crypto API.
        /// </summary>
        /// <param name="format">
        /// A string describing the data format of the key to import after it is decrypted. It can be one of the following:<br/>
        /// - "raw" - Raw format.<br/>
        /// - "pkcs8" - Public-Key Cryptography Standards (PKCS) #8 format.<br/>
        /// - "spki" - SubjectPublicKeyInfo format.<br/>
        /// - "jwk" - JSON Web Key format.<br/>
        /// </param>
        /// <param name="wrappedKey">An ArrayBuffer containing the wrapped key in the given format.</param>
        /// <param name="unwrappingKey">The CryptoKey to use to decrypt the wrapped key. The key must have the unwrapKey usage set.</param>
        /// <param name="unwrapAlgo">An object specifying the algorithm to be used to decrypt the wrapped key, and any extra parameters as required:<br/>
        /// - To use RSA-OAEP, pass an RsaOaepParams object.<br/>
        /// - To use AES-CTR, pass an AesCtrParams object.<br/>
        /// - To use AES-CBC, pass an AesCbcParams object.<br/>
        /// - To use AES-GCM, pass an AesGcmParams object.<br/>
        /// - To use AES-KW, pass an AesKwParams object.
        /// </param>
        /// <param name="unwrappedKeyAlgo">
        /// An object defining the type of key to unwrap and providing extra algorithm-specific parameters as required.<br/>
        /// - For RSASSA-PKCS1-v1_5, RSA-PSS, or RSA-OAEP: Pass an RsaHashedImportParams object.<br/>
        /// - For ECDSA or ECDH: Pass an EcKeyImportParams object.<br/>
        /// - For HMAC: Pass an HmacImportParams object.<br/>
        /// - For AES-CTR, AES-CBC, AES-GCM, or AES-KW: Pass a CryptoImportParams object with the Name property set to the name of the algorithm.<br/>
        /// - For Ed25519: Pass a CryptoImportParams with Name property set to "Ed25519"<br/>
        /// - For X25519: Pass a CryptoImportParams with Name property set to "X25519"
        /// </param>
        /// <param name="extractable">A boolean indicating whether it will be possible to export the key using SubtleCrypto.exportKey() or SubtleCrypto.wrapKey().</param>
        /// <param name="keyUsages">An Array indicating what can be done with the key. Possible values of the array are:<br/>
        /// encrypt: The key may be used to encrypt messages.<br/>
        /// decrypt: The key may be used to decrypt messages.<br/>
        /// sign: The key may be used to sign messages.<br/>
        /// verify: The key may be used to verify signatures.<br/>
        /// deriveKey: The key may be used in deriving a new key.<br/>
        /// deriveBits: The key may be used in deriving bits.<br/>
        /// wrapKey: The key may be used to wrap a key.<br/>
        /// unwrapKey: The key may be used to unwrap a key.<br/>
        /// </param>
        /// <returns>A Promise that fulfills with the unwrapped key as a CryptoKey object.</returns>
        public Task<CryptoKey> UnwrapKey(string format, ArrayBuffer wrappedKey, CryptoKey unwrappingKey, EncryptParams unwrapAlgo, CryptoImportParams unwrappedKeyAlgo, bool extractable, IEnumerable<string> keyUsages) => JSRef!.CallAsync<CryptoKey>("unwrapKey", format, wrappedKey, unwrappingKey, unwrapAlgo, unwrappedKeyAlgo, extractable, keyUsages);
        /// <summary>
        /// The wrapKey() method of the SubtleCrypto interface "wraps" a key. This means that it exports the key in an external, portable format, then encrypts the exported key. Wrapping a key helps protect it in untrusted environments, such as inside an otherwise unprotected data store or in transmission over an unprotected network.
        /// </summary>
        /// <param name="format">
        /// A string describing the data format of the key to export before it is encrypted. It can be one of the following:<br/>
        /// - "raw" - Raw format.<br/>
        /// - "pkcs8" - Public-Key Cryptography Standards (PKCS) #8 format.<br/>
        /// - "spki" - SubjectPublicKeyInfo format.<br/>
        /// - "jwk" - JSON Web Key format.<br/>
        /// </param>
        /// <param name="key">The CryptoKey to wrap.</param>
        /// <param name="wrappingKey">The CryptoKey used to encrypt the exported key. The key must have the wrapKey usage set.</param>
        /// <param name="wrapAlgo">
        /// An object specifying the algorithm to be used to encrypt the exported key, and any required extra parameters:<br/>
        /// - To use RSA-OAEP, pass an RsaOaepParams object.<br/>
        /// - To use AES-CTR, pass an AesCtrParams object.<br/>
        /// - To use AES-CBC, pass an AesCbcParams object.<br/>
        /// - To use AES-GCM, pass an AesGcmParams object.<br/>
        /// - To use AES-KW, pass an AesKwParams object.
        /// </param>
        /// <returns>A Promise that fulfills with an ArrayBuffer containing the encrypted exported key.</returns>
        public Task<ArrayBuffer> WrapKey(string format, CryptoKey key, CryptoKey wrappingKey, EncryptParams wrapAlgo) => JSRef!.CallAsync<ArrayBuffer>("wrapKey", format, key, wrappingKey, wrapAlgo);
        /// <summary>
        /// The deriveKey() method of the SubtleCrypto interface can be used to derive a secret key from a master key.<br/>
        /// It takes as arguments some initial key material, the derivation algorithm to use, and the desired properties for the key to derive. It returns a Promise which will be fulfilled with a CryptoKey object representing the new key.<br/>
        /// It's worth noting that the three key derivation algorithms you can use have quite different characteristics and are appropriate in quite different situations. See Supported algorithms for some more detail on this.<br/>
        /// </summary>
        /// <param name="algorithm">
        /// An object defining the derivation algorithm to use.<br/>
        /// To use ECDH, pass an EcdhKeyDeriveParams object.<br/>
        /// To use HKDF, pass an HkdfParams object.<br/>
        /// To use PBKDF2, pass a Pbkdf2Params object.
        /// </param>
        /// <param name="baseKey">
        /// A CryptoKey representing the input to the derivation algorithm. If algorithm is ECDH, then this will be the ECDH private key. Otherwise it will be the initial key material for the derivation function: for example, for PBKDF2 it might be a password, imported as a CryptoKey using SubtleCrypto.importKey().
        /// </param>
        /// <param name="derivedKeyAlgorithm">
        /// An object defining the algorithm the derived key will be used for:<br/>
        /// For HMAC pass an HmacKeyGenParams object.<br/>
        /// For AES-CTR, AES-CBC, AES-GCM, or AES-KW, pass an AesKeyGenParams object.<br/>
        /// For HKDF, pass an HkdfParams object.<br/>
        /// For PBKDF2, pass a Pbkdf2Params object.
        /// </param>
        /// <param name="extractable">A boolean value indicating whether it will be possible to export the key using SubtleCrypto.exportKey() or SubtleCrypto.wrapKey().</param>
        /// <param name="keyUsages">
        /// An Array indicating what can be done with the derived key. Note that the key usages must be allowed by the algorithm set in derivedKeyAlgorithm. Possible values of the array are:<br/>
        /// encrypt: The key may be used to encrypt messages.<br/>
        /// decrypt: The key may be used to decrypt messages.<br/>
        /// sign: The key may be used to sign messages.<br/>
        /// verify: The key may be used to verify signatures.<br/>
        /// deriveKey: The key may be used in deriving a new key.<br/>
        /// deriveBits: The key may be used in deriving bits.<br/>
        /// wrapKey: The key may be used to wrap a key.<br/>
        /// unwrapKey: The key may be used to unwrap a key.<br/>
        /// </param>
        /// <returns>A Promise that fulfills with a CryptoKey.</returns>
        public Task<CryptoKey> DeriveKey(KeyDeriveParams algorithm, CryptoKey baseKey, Union<HmacKeyGenParams, AesKeyGenParams, HkdfParams, Pbkdf2Params> derivedKeyAlgorithm, bool extractable, string[] keyUsages) => JSRef!.CallAsync<CryptoKey>("deriveKey", algorithm, baseKey, derivedKeyAlgorithm, extractable, keyUsages);
        /// <summary>
        /// The deriveBits() method of the SubtleCrypto interface can be used to derive an array of bits from a base key.<br/>
        /// It takes as its arguments the base key, the derivation algorithm to use, and the length of the bits to derive. It returns a Promise which will be fulfilled with an ArrayBuffer containing the derived bits.<br/>
        /// This method is very similar to SubtleCrypto.deriveKey(), except that deriveKey() returns a CryptoKey object rather than an ArrayBuffer. Essentially deriveKey() is composed of deriveBits() followed by importKey().<br/>
        /// This function supports the same derivation algorithms as deriveKey(): ECDH, HKDF, PBKDF2, and X25519. See Supported algorithms for some more detail on these algorithms.
        /// </summary>
        /// <param name="algorithm">An object defining the derivation algorithm to use.<br/>
        /// To use ECDH, pass an EcdhKeyDeriveParams object.<br/>
        /// To use HKDF, pass an HkdfParams object.<br/>
        /// To use PBKDF2, pass a Pbkdf2Params object.<br/>
        /// To use X25519, pass an EcdhKeyDeriveParams object, specifying the string X25519 as the name property.
        /// </param>
        /// <param name="baseKey">A CryptoKey representing the input to the derivation algorithm. If algorithm is ECDH, this will be the ECDH private key. Otherwise it will be the initial key material for the derivation function: for example, for PBKDF2 it might be a password, imported as a CryptoKey using SubtleCrypto.importKey().</param>
        /// <param name="length">A number representing the number of bits to derive. To be compatible with all browsers, the number should be a multiple of 8.</param>
        /// <returns>A Promise that fulfills with an ArrayBuffer containing the derived bits.</returns>
        public Task<ArrayBuffer> DeriveBits(KeyDeriveParams algorithm, CryptoKey baseKey, int length) => JSRef!.CallAsync<ArrayBuffer>("deriveBits", algorithm, baseKey, length);
        #endregion
    }
}
