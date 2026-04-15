# AesCbcParams

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EncryptParams`  
**Source:** `JSObjects/Cryptography/AesCbcParams.cs`  
**MDN Reference:** [AesCbcParams on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AesCbcParams)

> The AesCbcParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.encrypt(), SubtleCrypto.decrypt(), SubtleCrypto.wrapKey(), or SubtleCrypto.unwrapKey(), when using the AES-CBC algorithm. https://developer.mozilla.org/en-US/docs/Web/API/AesCbcParams

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `override string` | get | A string. This should be set to AES-CBC. |
| `Iv` | `BufferSource?` | get | An ArrayBuffer, a TypedArray, or a DataView. The initialization vector. Must be 16 bytes, unpredictable, and preferably cryptographically random. However, it need not be secret (for example, it may be transmitted unencrypted along with the ciphertext). |

