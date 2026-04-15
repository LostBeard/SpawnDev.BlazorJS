# RsaHashedKeyGenParams

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `KeyGenParams`  
**Source:** `JSObjects/Cryptography/RsaHashedKeyGenParams.cs`  

> The RsaHashedKeyGenParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.generateKey(), when generating any RSA-based key pair: that is, when the algorithm is identified as any of RSASSA-PKCS1-v1_5, RSA-PSS, or RSA-OAEP.

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `override string` | get |  |
| `ModulusLength` | `int` | get |  |
| `PublicExponent` | `byte[]` | get |  |
| `Hash` | `Union<string, RsaHash>` | get |  |
| `HashName` | `string?` | get |  |

