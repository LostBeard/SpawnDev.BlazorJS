# Crypto

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Cryptography/Crypto.cs`  
**MDN Reference:** [Crypto on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Crypto)

> The Crypto interface represents basic cryptography features available in the current context. It allows access to a cryptographically strong random number generator and to cryptographic primitives. https://developer.mozilla.org/en-US/docs/Web/API/Crypto

## Constructors

| Signature | Description |
|---|---|
| `Crypto(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Crypto()` | Gets the global instance of Crypto |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `IsSupported` | `bool` | get | Returns true is the the global variable 'crypto' is defined |
| `Subtle` | `SubtleCrypto` | get | Returns a SubtleCrypto object providing access to common cryptographic primitives, like hashing, signing, encryption, or decryption. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetRandomValues(TTypedArray typedArray)` | `TTypedArray` | The Crypto.getRandomValues() method lets you get cryptographically strong random values. The array given as the parameter is filled with random numbers (random in its cryptographic meaning). TypedArray An integer-based TypedArray, that is one of: Int8Array, Uint8Array, Uint8ClampedArray, Int16Array, Uint16Array, Int32Array, Uint32Array, BigInt64Array, BigUint64Array (but not Float32Array nor Float64Array). All elements in the array will be overwritten with random numbers. The same TypedArray passed in |
| `GetRandomValues(long size)` | `byte[]` | The Crypto.getRandomValues() method lets you get cryptographically strong random values. The array given as the parameter is filled with random numbers (random in its cryptographic meaning). non-standard implementation to accommodate byte[] The number of random bytes to return |
| `RandomUUID()` | `string` | A string containing a randomly generated, 36 character long v4 UUID. |

## Example

```csharp
// Create a Crypto instance (wraps the global 'crypto' object)
using var crypto = new Crypto();

// Check if crypto is supported in this context
if (!Crypto.IsSupported)
{
    Console.WriteLine("Crypto API not available.");
    return;
}

// Generate a random UUID
string uuid = crypto.RandomUUID();
Console.WriteLine($"Generated UUID: {uuid}");

// Generate 32 random bytes (returns a .NET byte array)
byte[] randomBytes = crypto.GetRandomValues(32);
Console.WriteLine($"Random bytes: {BitConverter.ToString(randomBytes)}");

// Fill a TypedArray with random values
using var uint8Array = new Uint8Array(16);
using var filled = crypto.GetRandomValues(uint8Array);
byte[] randomData = filled.ReadBytes();
Console.WriteLine($"Filled {randomData.Length} random bytes into Uint8Array");

// Access SubtleCrypto for advanced operations (hashing, signing, encryption)
using var subtle = crypto.Subtle;
// Use subtle.Digest(), subtle.GenerateKey(), subtle.Sign(), etc.
```

