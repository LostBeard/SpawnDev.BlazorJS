# EcdhKeyDeriveParams

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `KeyDeriveParams`  
**Source:** `JSObjects/Cryptography/EcdhKeyDeriveParams.cs`  
**MDN Reference:** [EcdhKeyDeriveParams on MDN](https://developer.mozilla.org/en-US/docs/Web/API/EcdhKeyDeriveParams)

> The EcdhKeyDeriveParams dictionary of the Web Crypto API represents the object that should be passed as the algorithm parameter into SubtleCrypto.deriveKey(), when using the ECDH algorithm. ECDH enables two people who each have a key pair consisting of a public and a private key to derive a shared secret. They exchange public keys and use the combination of their private key and the other entity's public key to derive a secret key that they - and no one else - share. The parameters for ECDH deriveKey() therefore include the other entity's public key, which is combined with this entity's private key to derive the shared secret. https://developer.mozilla.org/en-US/docs/Web/API/EcdhKeyDeriveParams

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `override string` | get/set | A string. This should be set to ECDH. |
| `Public` | `CryptoKey` | get | A CryptoKey object representing the public key of the other entity. |

