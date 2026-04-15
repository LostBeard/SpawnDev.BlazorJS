# TextDecoder

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/TextDecoder.cs`  
**MDN Reference:** [TextDecoder on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TextDecoder)

> The TextDecoder interface represents a decoder for a specific text encoding, such as UTF-8, ISO-8859-2, KOI8-R, GBK, etc. A decoder takes a stream of bytes as input and emits a stream of code points. https://developer.mozilla.org/en-US/docs/Web/API/TextDecoder

## Constructors

| Signature | Description |
|---|---|
| `TextDecoder()` | Creates a new instance of TextDecoder |
| `TextDecoder(string label, TextDecoderOptions? options)` | A string, defaulting to "utf-8". This may be any valid label. A string identifying the character encoding that this decoder will use. This may be any valid label. Defaults to "utf-8". |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `FatalError` | `bool` | get | A Boolean indicating whether the error mode is fatal. |
| `IgnoreBOM` | `bool` | get | A Boolean indicating whether the byte order mark is ignored. |
| `Encoding` | `string` | get | A string containing the name of the decoder, which is a string describing the method the TextDecoder will use. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Decode(ArrayBuffer data)` | `string` | Returns a string containing the text decoded with the method of the specific TextDecoder object. |
| `DecodeToPrimitive(ArrayBuffer data)` | `StringPrimitive` | Returns a string containing the text decoded with the method of the specific TextDecoder object. |
| `Decode(DataView data)` | `string` | Returns a string containing the text decoded with the method of the specific TextDecoder object. |
| `DecodeToPrimitive(DataView data)` | `StringPrimitive` | Returns a string containing the text decoded with the method of the specific TextDecoder object. |
| `Decode(TypedArray data)` | `string` | Returns a string containing the text decoded with the method of the specific TextDecoder object. |
| `DecodeToPrimitive(TypedArray data)` | `StringPrimitive` | Returns a string containing the text decoded with the method of the specific TextDecoder object. |
| `Decode(byte[] data)` | `string` | Returns a string containing the text decoded with the method of the specific TextDecoder object. |
| `DecodeToPrimitive(byte[] data)` | `StringPrimitive` | Returns a string containing the text decoded with the method of the specific TextDecoder object. |

## Example

```csharp
// Create a UTF-8 decoder (default encoding)
using var decoder = new TextDecoder();
string encoding = decoder.Encoding; // "utf-8"

// Decode from an ArrayBuffer
using var response = await JS.CallAsync<Response>("fetch", "/api/data");
using var buffer = await response.ArrayBuffer();
string text = decoder.Decode(buffer);

// Decode from a TypedArray
using var uint8Array = new Uint8Array(new byte[] { 72, 101, 108, 108, 111 });
string hello = decoder.Decode(uint8Array); // "Hello"

// Decode directly from a .NET byte array
byte[] bytes = new byte[] { 72, 101, 108, 108, 111 };
string fromBytes = decoder.Decode(bytes); // "Hello"

// Decode non-UTF-8 text (e.g. Windows-1251 for Cyrillic)
using var win1251 = new TextDecoder("windows-1251");
byte[] cyrillic = new byte[] { 207, 240, 232, 226, 229, 242 };
string russian = win1251.Decode(cyrillic);

// Check decoder properties
bool isFatal = decoder.FatalError;
bool ignoreBom = decoder.IgnoreBOM;
```

