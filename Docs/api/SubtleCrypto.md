# SubtleCrypto

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `SubtleCrypto`  
**MDN Reference:** [SubtleCrypto - MDN](https://developer.mozilla.org/en-US/docs/Web/API/SubtleCrypto)

> The `SubtleCrypto` interface provides a number of low-level cryptographic functions. Access it via `Crypto.Subtle`. All methods are asynchronous, returning `Task<T>` (mapping to JavaScript Promises). This is a secure-context API - only available over HTTPS or localhost.

## Constructors

| Signature | Description |
|---|---|
| `SubtleCrypto(IJSInProcessObjectReference _ref)` | Deserialization constructor. Not directly instantiated - obtain via `Crypto.Subtle`. |

## Methods

### Key Generation and Import

| Method | Return Type | Description |
|---|---|---|
| `GenerateKey<T>(algorithm, bool extractable, IEnumerable<string> keyUsages)` | `Task<T>` | Generates a new key or key pair. `T` is `CryptoKey` (symmetric) or `CryptoKeyPair` (asymmetric). Algorithm accepts `RsaHashedKeyGenParams`, `EcKeyGenParams`, `HmacKeyGenParams`, or `AesKeyGenParams`. |
| `ImportKey(string format, keyData, algorithm, bool extractable, IEnumerable<string> keyUsages)` | `Task<CryptoKey>` | Imports a key from external format. `format`: `"raw"`, `"pkcs8"`, `"spki"`, or `"jwk"`. `keyData` accepts `ArrayBuffer`, `TypedArray`, `DataView`, `byte[]`, or `JWK`. |
| `ImportKey(JWK keyData, algorithm, bool extractable, IEnumerable<string> keyUsages)` | `Task<CryptoKey>` | Imports a key from JWK format (shorthand). |
| `ImportKey<T>(...)` | `Task<T>` | Generic import returning `CryptoKey` or `CryptoKeyPair`. |

### Key Export

| Method | Return Type | Description |
|---|---|---|
| `ExportKey<T>(string format, CryptoKey key)` | `Task<T>` | Exports a key. `T` is `ArrayBuffer` for `"raw"`/`"pkcs8"`/`"spki"`, or `JSObject` for `"jwk"`. |
| `ExportKeyRaw(CryptoKey key)` | `Task<ArrayBuffer>` | Exports as raw bytes. For AES, HMAC, or EC public keys. |
| `ExportKeySpki(CryptoKey key)` | `Task<ArrayBuffer>` | Exports public key in SubjectPublicKeyInfo format. |
| `ExportKeyPkcs8(CryptoKey key)` | `Task<ArrayBuffer>` | Exports private key in PKCS#8 format. |
| `ExportKeyJwk(CryptoKey key)` | `Task<JSObject>` | Exports in JSON Web Key format. |
| `ExportKey<TJWK>(CryptoKey key)` | `Task<TJWK>` | Exports as a typed JWK object. |

### Encryption and Decryption

| Method | Return Type | Description |
|---|---|---|
| `Encrypt(EncryptParams algorithm, CryptoKey key, BufferSource data)` | `Task<ArrayBuffer>` | Encrypts data. Algorithm: `RsaOaepParams`, `AesCtrParams`, `AesCbcParams`, `AesGcmParams`, or `AesKwParams`. |
| `Decrypt(EncryptParams algorithm, CryptoKey key, BufferSource data)` | `Task<ArrayBuffer>` | Decrypts data. Same algorithm options. |

### Signing and Verification

| Method | Return Type | Description |
|---|---|---|
| `Sign(algorithm, CryptoKey key, BufferSource data)` | `Task<ArrayBuffer>` | Signs data. Algorithm: `CryptoSignParams` (e.g., `EcdsaParams`) or string (e.g., `"Ed25519"`). |
| `Verify(algorithm, CryptoKey key, BufferSource signature, BufferSource data)` | `Task<bool>` | Verifies a signature. Returns `true` if valid. |

### Hashing

| Method | Return Type | Description |
|---|---|---|
| `Digest(string algorithm, BufferSource data)` | `Task<ArrayBuffer>` | Generates a digest. Algorithm: `"SHA-1"`, `"SHA-256"`, `"SHA-384"`, `"SHA-512"`. |

### Key Derivation

| Method | Return Type | Description |
|---|---|---|
| `DeriveKey(algorithm, CryptoKey baseKey, derivedKeyAlgorithm, bool extractable, string[] keyUsages)` | `Task<CryptoKey>` | Derives a key. Algorithm: `EcdhKeyDeriveParams`, `HkdfParams`, or `Pbkdf2Params`. |
| `DeriveBits(algorithm, CryptoKey baseKey, int length)` | `Task<ArrayBuffer>` | Derives raw bits. Length should be a multiple of 8. |

### Key Wrapping

| Method | Return Type | Description |
|---|---|---|
| `WrapKey(string format, CryptoKey key, CryptoKey wrappingKey, EncryptParams wrapAlgo)` | `Task<ArrayBuffer>` | Exports and encrypts a key. |
| `UnwrapKey(string format, ArrayBuffer wrappedKey, CryptoKey unwrappingKey, EncryptParams unwrapAlgo, CryptoImportParams unwrappedKeyAlgo, bool extractable, IEnumerable<string> keyUsages)` | `Task<CryptoKey>` | Decrypts and imports a wrapped key. |

## Example 1: ECDSA Sign/Verify

```csharp
using var crypto = new Crypto();
using var subtle = crypto.Subtle;

// Generate ECDSA key pair
using var keyPair = await subtle.GenerateKey<CryptoKeyPair>(
    new EcKeyGenParams { Name = "ECDSA", NamedCurve = "P-384" },
    extractable: true,
    keyUsages: new[] { "sign", "verify" }
);

// Sign data
byte[] data = System.Text.Encoding.UTF8.GetBytes("Hello, World!");
using var signature = await subtle.Sign(
    new EcdsaParams { Name = "ECDSA", Hash = "SHA-384" },
    keyPair.PrivateKey,
    data
);

// Verify
bool isValid = await subtle.Verify(
    new EcdsaParams { Name = "ECDSA", Hash = "SHA-384" },
    keyPair.PublicKey,
    signature,
    data
);
Console.WriteLine($"Signature valid: {isValid}");  // true
```

## Example 2: AES-GCM Encrypt/Decrypt

```csharp
using var crypto = new Crypto();
using var subtle = crypto.Subtle;

// Generate AES-GCM key
using var aesKey = await subtle.GenerateKey<CryptoKey>(
    new AesKeyGenParams { Name = "AES-GCM", Length = 256 },
    extractable: false,
    keyUsages: new[] { "encrypt", "decrypt" }
);

// Create IV
using var iv = new Uint8Array(12);
crypto.GetRandomValues(iv);

// Encrypt
byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");
using var ciphertext = await subtle.Encrypt(
    new AesGcmParams { Name = "AES-GCM", Iv = iv },
    aesKey,
    plaintext
);

// Decrypt
using var decrypted = await subtle.Decrypt(
    new AesGcmParams { Name = "AES-GCM", Iv = iv },
    aesKey,
    ciphertext
);
byte[] result = decrypted.ReadBytes();
string text = System.Text.Encoding.UTF8.GetString(result);
Console.WriteLine(text);  // "Secret message"
```

## Example 3: SHA-256 Digest

```csharp
using var crypto = new Crypto();
using var subtle = crypto.Subtle;

byte[] data = System.Text.Encoding.UTF8.GetBytes("hash me");
using var hash = await subtle.Digest("SHA-256", data);
byte[] hashBytes = hash.ReadBytes();
string hex = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
Console.WriteLine(hex);
```

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GenerateKey<T>(Union<RsaHashedKeyGenParams, EcKeyGenParams, HmacKeyGenParams, AesKeyGenParams> algorithm, bool extractable, IEnumerable<string> keyUsages)` | `Task<T>` | Use the generateKey() method of the SubtleCrypto interface to generate a new key (for symmetric algorithms) or key pair (for public-key algorithms). |
| `ImportKey(string format, Union<ArrayBuffer, TypedArray, DataView, byte[], JWK> keyData, Union<CryptoImportParams, string> algorithm, bool extractable, IEnumerable<string> keyUsages)` | `Task<CryptoKey>` | The importKey() method of the SubtleCrypto interface imports a key: that is, it takes as input a key in an external, portable format and gives you a CryptoKey object that you can use in the Web Crypto API. |
| `ImportKey(JWK keyData, Union<CryptoImportParams, string> algorithm, bool extractable, IEnumerable<string> keyUsages)` | `Task<CryptoKey>` | The importKey() method of the SubtleCrypto interface imports a key: that is, it takes as input a key in an external, portable format and gives you a CryptoKey object that you can use in the Web Crypto API. |
| `ImportKey<T>(string format, Union<ArrayBuffer, TypedArray, DataView, byte[], JWK> keyData, Union<CryptoImportParams, string> algorithm, bool extractable, IEnumerable<string> keyUsages)` | `Task<T>` | The importKey() method of the SubtleCrypto interface imports a key: that is, it takes as input a key in an external, portable format and gives you a CryptoKey object that you can use in the Web Crypto API. |
| `ImportKey<T>(JWK keyData, Union<CryptoImportParams, string> algorithm, bool extractable, IEnumerable<string> keyUsages)` | `Task<T>` | The importKey() method of the SubtleCrypto interface imports a key: that is, it takes as input a key in an external, portable format and gives you a CryptoKey object that you can use in the Web Crypto API. |
| `Sign(Union<CryptoSignParams, string> algorithm, CryptoKey key, BufferSource data)` | `Task<ArrayBuffer>` | The sign() method of the SubtleCrypto interface generates a digital signature. It takes as its arguments a key to sign with, some algorithm-specific parameters, and the data to sign. It returns a Promise which will be fulfilled with the signature. |
| `Verify(Union<CryptoSignParams, string> algorithm, CryptoKey key, BufferSource signature, BufferSource data)` | `Task<bool>` | The verify() method of the SubtleCrypto interface verifies a digital signature. It takes as its arguments a key to verify the signature with, some algorithm-specific parameters, the signature, and the original signed data.It returns a Promise which will be fulfilled with a boolean value indicating whether the signature is valid. |
| `DeriveKey(KeyDeriveParams algorithm, CryptoKey baseKey, Union<HmacKeyGenParams, AesKeyGenParams, HkdfParams, Pbkdf2Params> derivedKeyAlgorithm, bool extractable, string[] keyUsages)` | `Task<CryptoKey>` | The deriveKey() method of the SubtleCrypto interface can be used to derive a secret key from a master key. It takes as arguments some initial key material, the derivation algorithm to use, and the desired properties for the key to derive. It returns a Promise which will be fulfilled with a CryptoKey object representing the new key. It's worth noting that the three key derivation algorithms you can use have quite different characteristics and are appropriate in quite different situations. See Supported algorithms for some more detail on this. |
| `DeriveBits(KeyDeriveParams algorithm, CryptoKey baseKey, int length)` | `Task<ArrayBuffer>` | The deriveBits() method of the SubtleCrypto interface can be used to derive an array of bits from a base key. It takes as its arguments the base key, the derivation algorithm to use, and the length of the bits to derive. It returns a Promise which will be fulfilled with an ArrayBuffer containing the derived bits. This method is very similar to SubtleCrypto.deriveKey(), except that deriveKey() returns a CryptoKey object rather than an ArrayBuffer. Essentially deriveKey() is composed of deriveBits() followed by importKey(). This function supports the same derivation algorithms as deriveKey(): ECDH, HKDF, PBKDF2, and X25519. See Supported algorithms for some more detail on these algorithms. |

