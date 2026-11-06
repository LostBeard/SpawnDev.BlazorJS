# RsaOaepParams

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EncryptParams`  
**Source:** `JSObjects/Cryptography/RsaOaepParams.cs`  

> The RsaOaepParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.encrypt(), SubtleCrypto.decrypt(), SubtleCrypto.wrapKey(), or SubtleCrypto.unwrapKey(), when using the RSA_OAEP algorithm.

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `override string` | get | A string. This should be set to RSA-OAEP |
| `Label` | `BufferSource?` | get |  |

## Constructors

| Signature | Description |
|---|---|
| `RsaOaepParams()` | Creates a new instance. The algorithm name is fixed by this type, so a caller does not supply it even though the base declares it required. |

