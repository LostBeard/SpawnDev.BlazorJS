# HkdfParams

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `KeyDeriveParams`  
**Source:** `JSObjects/Cryptography/HkdfParams.cs`  
**MDN Reference:** [HkdfParams on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HkdfParams)

> The HkdfParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.deriveKey(), when using the HKDF algorithm. https://developer.mozilla.org/en-US/docs/Web/API/HkdfParams

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `override string` | get | A string. This should be set to HKDF. |
| `Hash` | `string` | get | A string representing the digest algorithm to use. This may be one of: SHA-1 SHA-256 SHA-384 SHA-512 |
| `Salt` | `BufferSource` | get | An ArrayBuffer, a TypedArray, or a DataView. The HKDF specification states that adding salt "adds significantly to the strength of HKDF". Ideally, the salt is a random or pseudo-random value with the same length as the output of the digest function. Unlike the input key material passed into deriveKey(), salt does not need to be kept secret. |
| `Info` | `BufferSource` | get | An ArrayBuffer, a TypedArray, or a DataView representing application-specific contextual information. This is used to bind the derived key to an application or context, and enables you to derive different keys for different contexts while using the same input key material. It's important that this should be independent of the input key material itself. This property is required but may be an empty buffer. |

