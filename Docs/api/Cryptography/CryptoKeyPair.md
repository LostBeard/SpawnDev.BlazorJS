# CryptoKeyPair

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `CryptoKeyBase`  
**Source:** `JSObjects/Cryptography/CryptoKeyPair.cs`  
**MDN Reference:** [CryptoKeyPair on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CryptoKeyPair)

> The CryptoKeyPair dictionary of the Web Crypto API represents a key pair for an asymmetric cryptography algorithm, also known as a public-key algorithm. https://developer.mozilla.org/en-US/docs/Web/API/CryptoKeyPair

## Constructors

| Signature | Description |
|---|---|
| `CryptoKeyPair(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `CryptoKeyPair()` | Creates a new instance of Object represented as a CryptoKeyPair |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `PrivateKey` | `CryptoKey?` | get | A CryptoKey object representing the private key. For encryption and decryption algorithms, this key is used to decrypt. For signing and verification algorithms it is used to sign. |
| `PublicKey` | `CryptoKey?` | get | A CryptoKey object representing the public key. For encryption and decryption algorithms, this key is used to encrypt. For signing and verification algorithms it is used to verify signatures. |

