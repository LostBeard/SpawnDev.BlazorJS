# AesGcmParams

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EncryptParams`  
**Source:** `JSObjects/Cryptography/AesGcmParams.cs`  
**MDN Reference:** [AesGcmParams on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AesGcmParams)

> The AesGcmParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.encrypt(), SubtleCrypto.decrypt(), SubtleCrypto.wrapKey(), or SubtleCrypto.unwrapKey(), when using the AES-GCM algorithm. https://developer.mozilla.org/en-US/docs/Web/API/AesGcmParams

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `override string` | get | A string. This should be set to AES-GCM. |
| `Iv` | `BufferSource?` | get | An ArrayBuffer, a TypedArray, or a DataView with the initialization vector. This must be unique for every encryption operation carried out with a given key. Put another way: never reuse an IV with the same key. The AES-GCM specification recommends that the IV should be 96 bits long, and typically contains bits from a random number generator. Section 8.2 of the specification outlines methods for constructing IVs. Note that the IV does not have to be secret, just unique: so it is OK, for example, to transmit it in the clear alongside the encrypted message. |
| `AdditionalData` | `BufferSource?` | get |  |
| `TagLength` | `int?` | get |  |

