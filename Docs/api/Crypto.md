# Crypto

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `Crypto`  
**MDN Reference:** [Crypto - MDN](https://developer.mozilla.org/en-US/docs/Web/API/Crypto)

> The `Crypto` interface represents basic cryptography features available in the current context. It allows access to a cryptographically strong random number generator and to cryptographic primitives via the `Subtle` property. Access the global instance via `new Crypto()` which returns `window.crypto` (or `self.crypto` in workers).

## Constructors

| Signature | Description |
|---|---|
| `Crypto()` | Gets the global `crypto` instance. Equivalent to `JS.Get<Crypto>("crypto")`. |
| `Crypto(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Static Properties

| Property | Type | Description |
|---|---|---|
| `IsSupported` | `bool` | Returns `true` if the global `crypto` object is defined. |

## Properties

| Property | Type | Description |
|---|---|---|
| `Subtle` | `SubtleCrypto` | Provides access to low-level cryptographic operations (encrypt, decrypt, sign, verify, etc.). |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetRandomValues<TTypedArray>(TTypedArray typedArray)` | `TTypedArray` | Fills the typed array with cryptographically strong random values. Returns the same array. Works with integer typed arrays only (not `Float32Array` or `Float64Array`). |
| `GetRandomValues(long size)` | `byte[]` | (SpawnDev extension) Returns `size` random bytes as a .NET `byte[]`. Internally creates a temporary `Uint8Array`. |
| `RandomUUID()` | `string` | Returns a randomly generated 36-character v4 UUID string. |

## Example

```csharp
// Get the global crypto instance
using var crypto = new Crypto();

// Generate random bytes
byte[] randomBytes = crypto.GetRandomValues(32);  // 32 random bytes

// Fill a typed array with random values
using var iv = new Uint8Array(16);
crypto.GetRandomValues(iv);  // iv is now filled with random bytes

// Generate a UUID
string uuid = crypto.RandomUUID();
Console.WriteLine(uuid);  // e.g., "550e8400-e29b-41d4-a716-446655440000"

// Access SubtleCrypto for advanced operations
using var subtle = crypto.Subtle;
// Use subtle for encrypt, decrypt, sign, verify, etc.

// Check support
if (Crypto.IsSupported)
{
    Console.WriteLine("Web Crypto API is available");
}
```
