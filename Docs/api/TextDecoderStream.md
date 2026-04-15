# TextDecoderStream

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/TextDecoderStream.cs`  
**MDN Reference:** [TextDecoderStream on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TextDecoderStream)

> The TextDecoderStream interface of the Encoding API converts a stream of text in a binary encoding, such as UTF-8 etc., to a stream of strings. It is the streaming equivalent of TextDecoder. https://developer.mozilla.org/en-US/docs/Web/API/TextDecoderStream

## Constructors

| Signature | Description |
|---|---|
| `TextDecoderStream()` | The TextDecoderStream() constructor creates a new TextDecoderStream object. |
| `TextDecoderStream(string label)` | The TextDecoderStream() constructor creates a new TextDecoderStream object. A string defaulting to utf-8. This may be any valid label. |
| `TextDecoderStream(string label, TextDecoderStreamOptions options)` | The TextDecoderStream() constructor creates a new TextDecoderStream object. A string defaulting to utf-8. This may be any valid label. Options |
| `TextDecoderStream(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Encoding` | `string` | get | An encoding. |
| `Fatal` | `bool` | get | A boolean indicating if the error mode is fatal. |
| `IgnoreBOM` | `bool` | get | A boolean indicating whether the byte order mark is ignored. |
| `Readable` | `ReadableStream` | get | Returns the ReadableStream instance controlled by this object. |
| `Writable` | `WritableStream` | get | Returns the WritableStream instance controlled by this object. |

