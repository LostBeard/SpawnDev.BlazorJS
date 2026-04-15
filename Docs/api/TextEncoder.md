# TextEncoder

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/TextEncoder.cs`  
**MDN Reference:** [TextEncoder on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TextEncoder)

> The TextEncoder interface takes a stream of code points as input and emits a stream of UTF-8 bytes. https://developer.mozilla.org/en-US/docs/Web/API/TextEncoder

## Constructors

| Signature | Description |
|---|---|
| `TextEncoder()` | Creates a new instance of TextEncoder |
| `TextEncoder(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Encode(string text)` | `Uint8Array` | Takes a string as input, and returns a Uint8Array containing UTF-8 encoded text. |
| `EncodeInto(string text, Uint8Array dest)` | `EncodeIntoProgress` | Takes a string to encode and a destination Uint8Array to put resulting UTF-8 encoded text into, and returns an object indicating the progress of the encoding. This is potentially more performant than the older encode() method. |

## Example

```csharp
// Create a TextEncoder (always UTF-8)
using var encoder = new TextEncoder();

// Encode a string to a Uint8Array
using var encoded = encoder.Encode("Hello, World!");
byte[] bytes = encoded.ReadBytes();
Console.WriteLine($"Encoded {bytes.Length} bytes");

// Encode into an existing buffer for better performance
using var dest = new Uint8Array(100);
using var progress = encoder.EncodeInto("Hello!", dest);
// progress.Read and progress.Written indicate how much was processed

// Pair with TextDecoder to round-trip
using var decoder = new TextDecoder();
string roundTripped = decoder.Decode(encoded);
Console.WriteLine(roundTripped); // "Hello, World!"
```

