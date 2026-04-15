# CryptoKey

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `CryptoKeyBase`  
**Source:** `JSObjects/Cryptography/CryptoKey.cs`  
**MDN Reference:** [CryptoKey on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CryptoKey)

> The CryptoKey interface of the Web Crypto API represents a cryptographic key obtained from one of the SubtleCrypto methods generateKey(), deriveKey(), importKey(), or unwrapKey(). https://developer.mozilla.org/en-US/docs/Web/API/CryptoKey

## Constructors

| Signature | Description |
|---|---|
| `CryptoKey(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Type` | `string` | get | The type of key the object represents. It may take one of the following values: "secret", "private" or "public". |
| `Extractable` | `bool` | get | A boolean value indicating whether or not the key may be extracted using SubtleCrypto.exportKey() or SubtleCrypto.wrapKey(). |
| `Algorithm` | `KeyGenParams` | get | An object describing the algorithm for which this key can be used and any associated extra parameters. Use AlgorithmAs to get the full object |
| `AlgorithmName` | `string` | get | Returns the Algorithm.Name |
| `Usages` | `string[]` | get | An Array of strings, indicating what can be done with the key. Possible values for array elements are "encrypt", "decrypt", "sign", "verify", "deriveKey", "deriveBits", "wrapKey", and "unwrapKey". |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `AlgorithmAs()` | `T` | An object describing the algorithm for which this key can be used and any associated extra parameters. |

