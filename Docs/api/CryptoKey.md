# CryptoKey

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `CryptoKeyBase` -> `CryptoKey`  
**MDN Reference:** [CryptoKey - MDN](https://developer.mozilla.org/en-US/docs/Web/API/CryptoKey)

> The `CryptoKey` interface represents a cryptographic key obtained from `SubtleCrypto.GenerateKey()`, `DeriveKey()`, `ImportKey()`, or `UnwrapKey()`. It is an opaque handle - you cannot directly read the key material. Use `SubtleCrypto.ExportKey()` to extract it. The related `CryptoKeyPair` class holds asymmetric key pairs (public + private).

## Constructors

| Signature | Description |
|---|---|
| `CryptoKey(IJSInProcessObjectReference _ref)` | Deserialization constructor. Not directly instantiated - obtained from `SubtleCrypto` methods. |

## Properties

| Property | Type | Description |
|---|---|---|
| `Type` | `string` | The key type: `"public"`, `"private"`, or `"secret"`. |
| `Extractable` | `bool` | Whether the key can be exported via `ExportKey()` or `WrapKey()`. |
| `Algorithm` | `KeyGenParams` | Basic algorithm info. Use `AlgorithmAs<T>()` for full typed details. |
| `AlgorithmName` | `string` | Shorthand for `Algorithm.Name` (e.g., `"ECDSA"`, `"AES-GCM"`, `"Ed25519"`). |
| `Usages` | `string[]` | Allowed operations: `"encrypt"`, `"decrypt"`, `"sign"`, `"verify"`, `"deriveKey"`, `"deriveBits"`, `"wrapKey"`, `"unwrapKey"`. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `AlgorithmAs<T>()` | `T` | Returns the algorithm object cast to a specific type (e.g., `EcKeyGenParams`, `AesKeyGenParams`). |

## Related: CryptoKeyPair

`CryptoKeyPair` (also extends `CryptoKeyBase`) represents an asymmetric key pair:

| Property | Type | Description |
|---|---|---|
| `PublicKey` | `CryptoKey` | The public key. |
| `PrivateKey` | `CryptoKey` | The private key. |

## Example

```csharp
using var crypto = new Crypto();
using var subtle = crypto.Subtle;

// Generate a key pair
using var keyPair = await subtle.GenerateKey<CryptoKeyPair>(
    new EcKeyGenParams { Name = "ECDSA", NamedCurve = "P-256" },
    extractable: true,
    keyUsages: new[] { "sign", "verify" }
);

// Inspect the private key
CryptoKey privateKey = keyPair.PrivateKey;
Console.WriteLine($"Type: {privateKey.Type}");            // "private"
Console.WriteLine($"Extractable: {privateKey.Extractable}"); // true
Console.WriteLine($"Algorithm: {privateKey.AlgorithmName}");  // "ECDSA"
Console.WriteLine($"Usages: {string.Join(", ", privateKey.Usages)}"); // "sign"

// Get full algorithm details
var ecParams = privateKey.AlgorithmAs<EcKeyGenParams>();
Console.WriteLine($"Curve: {ecParams.NamedCurve}");  // "P-256"

// Inspect the public key
CryptoKey publicKey = keyPair.PublicKey;
Console.WriteLine($"Type: {publicKey.Type}");  // "public"

// Export the public key
using var exported = await subtle.ExportKeyRaw(publicKey);
byte[] publicKeyBytes = exported.ReadBytes();
```
