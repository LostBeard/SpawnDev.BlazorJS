# Pbkdf2Params

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `KeyDeriveParams`  
**Source:** `JSObjects/Cryptography/Pbkdf2Params.cs`  
**MDN Reference:** [Pbkdf2Params on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Pbkdf2Params)

> The Pbkdf2Params dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.deriveKey(), when using the PBKDF2 algorithm. https://developer.mozilla.org/en-US/docs/Web/API/Pbkdf2Params

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `override string` | get | A string. This should be set to HKDF. |
| `Hash` | `string` | get | A string representing the digest algorithm to use. This may be one of: SHA-1 SHA-256 SHA-384 SHA-512 |
| `Salt` | `BufferSource` | get | An ArrayBuffer, a TypedArray, or a DataView. This should be a random or pseudo-random value of at least 16 bytes. Unlike the input key material passed into deriveKey(), salt does not need to be kept secret. |
| `Iterations` | `int` | get | A Number representing the number of times the hash function will be executed in deriveKey(). This determines how computationally expensive (that is, slow) the deriveKey() operation will be. In this context, slow is good, since it makes it more expensive for an attacker to run a dictionary attack against the keys. The general guidance here is to use as many iterations as possible, subject to keeping an acceptable level of performance for your application. |

