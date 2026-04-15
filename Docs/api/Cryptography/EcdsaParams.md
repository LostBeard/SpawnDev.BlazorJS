# EcdsaParams

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `CryptoSignParams`  
**Source:** `JSObjects/Cryptography/EcdsaParams.cs`  

> The EcdsaParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.sign() or SubtleCrypto.verify() when using the ECDSA algorithm.

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `override string` | get | A string. This should be set to ECDSA. |
| `Hash` | `string` | get | A string. An identifier for the digest algorithm to use. This should be one of the following: SHA-256: selects the SHA-256 algorithm. SHA-384: selects the SHA-384 algorithm. SHA-512: selects the SHA-512 algorithm. SHA-1: selects the SHA-1 algorithm. Warning: SHA-1 is supported here but the SHA-1 algorithm is considered vulnerable and should no longer be used. |

