# ArrayBufferStream

**Namespace:** `SpawnDev.BlazorJS.Toolbox`  
**Inheritance:** `Stream` -> `ArrayBufferStream`

> A .NET `Stream` implementation backed by a JavaScript `ArrayBuffer` or `SharedArrayBuffer`. Supports reading, writing, seeking, and resizing. Uses `Uint8Array` views and HeapView for efficient data transfer between .NET and JS. Ideal for streaming binary data to/from JS APIs while maintaining full .NET Stream compatibility.

## Constructors

| Signature | Description |
|---|---|
| `ArrayBufferStream(long length = 0, long? maxLength = null, bool shared = false)` | Creates a new stream. If `shared` is true, uses a `SharedArrayBuffer`. If `maxLength` is set, creates a resizable/growable buffer. |
| `ArrayBufferStream(ArrayBuffer arrayBuffer)` | Creates a stream wrapping an existing `ArrayBuffer`. |
| `ArrayBufferStream(SharedArrayBuffer arrayBuffer)` | Creates a stream wrapping an existing `SharedArrayBuffer`. |
| `ArrayBufferStream(Uint8Array uint8Array)` | Creates a stream from an existing `Uint8Array`. Detects whether the backing buffer is shared. |
| `ArrayBufferStream(long length, ArrayBufferOptions? options)` | Creates a stream backed by an `ArrayBuffer` with options (e.g., `MaxByteLength` for resizable buffers). |
| `ArrayBufferStream(long length, SharedArrayBufferOptions? options)` | Creates a stream backed by a `SharedArrayBuffer` with options (e.g., `MaxByteLength` for growable buffers). |

## Properties

| Property | Type | Description |
|---|---|---|
| `Source` | `Uint8Array` | The underlying `Uint8Array` view. May change if the buffer is recreated during resize. |
| `IsSharedArrayBuffer` | `bool` | `true` if the backing buffer is a `SharedArrayBuffer`. |
| `CanShrink` | `bool` | `true` if the buffer supports shrinking (only resizable `ArrayBuffer`). |
| `CanGrow` | `bool` | `true` if the buffer supports growing (resizable `ArrayBuffer` or growable `SharedArrayBuffer`). |
| `AllowRecreateBuffer` | `bool` | If `true`, `SetLength` will create a new buffer and copy contents when the current buffer can't be resized to the requested size. Default: `false`. |
| `ReadOnly` | `bool` | If `true`, all write operations and `SetLength` throw `NotSupportedException`. |
| `IsDisposed` | `bool` | `true` if the stream has been disposed. |

### Standard Stream Properties

| Property | Type | Description |
|---|---|---|
| `CanRead` | `bool` | `true` if the stream is not disposed. |
| `CanWrite` | `bool` | `true` if the stream is not disposed and not read-only. |
| `CanSeek` | `bool` | `true` if the stream is not disposed. |
| `CanTimeout` | `bool` | Always `false`. |
| `Length` | `long` | Current size of the buffer in bytes. |
| `Position` | `long` | Current read/write position. |

## Methods

### Standard Stream Methods

| Method | Return Type | Description |
|---|---|---|
| `Read(byte[] buffer, int offset, int count)` | `int` | Reads bytes into a .NET byte array using HeapView for efficient transfer. Returns bytes read. |
| `Write(byte[] buffer, int offset, int count)` | `void` | Writes bytes from a .NET byte array using HeapView. |
| `Seek(long offset, SeekOrigin origin)` | `long` | Moves the position. Supports `Begin`, `Current`, and `End` origins. Returns the new position. |
| `SetLength(long value)` | `void` | Resizes the stream. Uses `ArrayBuffer.Resize()`/`SharedArrayBuffer.Grow()` if possible, or recreates the buffer if `AllowRecreateBuffer` is true. |
| `Flush()` | `void` | No-op (data is always written immediately to the JS buffer). |
| `Close()` | `void` | Closes the stream. |

### JS-Native Read/Write Methods

| Method | Return Type | Description |
|---|---|---|
| `Read(Uint8Array buffer, int offset, int count)` | `int` | Reads directly into a JS `Uint8Array` - no .NET marshaling overhead. |
| `Write(Uint8Array buffer, int offset, long count)` | `void` | Writes directly from a JS `Uint8Array`. |
| `ReadUint8Array(int count, bool subArray = false)` | `Uint8Array?` | Reads bytes as a `Uint8Array`. If `subArray` is true, returns a view (no copy) instead of a slice (copy). Returns `null` if no bytes available. |

### Extended Methods

| Method | Return Type | Description |
|---|---|---|
| `SetLength(long value, bool allowRecreateBuffer)` | `void` | Resizes with explicit control over buffer recreation. Overrides the instance `AllowRecreateBuffer` property for this call. |
| `SetReadOnly()` | `void` | Sets the stream to read-only mode. |

## Resize Behavior

| Buffer Type | Shrink | Grow | Beyond MaxByteLength |
|---|---|---|---|
| Resizable `ArrayBuffer` | `Resize()` | `Resize()` | Recreate (if allowed) or throw |
| Non-resizable `ArrayBuffer` | Recreate or throw | Recreate or throw | Recreate or throw |
| Growable `SharedArrayBuffer` | Not supported | `Grow()` | Recreate (if allowed) or throw |
| Non-growable `SharedArrayBuffer` | Not supported | Recreate or throw | Recreate or throw |

When `AllowRecreateBuffer` is true and the native resize/grow is not possible, a new buffer is created and the existing contents are copied over. The `Source` Uint8Array reference is updated.

## Example

```csharp
// Create a resizable stream
using var stream = new ArrayBufferStream(1024, maxLength: 1024 * 1024);
Console.WriteLine($"Length: {stream.Length}");  // 1024

// Write .NET byte data
byte[] data = System.Text.Encoding.UTF8.GetBytes("Hello, SpawnDev!");
stream.Write(data, 0, data.Length);
Console.WriteLine($"Position: {stream.Position}");  // 16

// Seek back and read
stream.Seek(0, SeekOrigin.Begin);
byte[] readBuf = new byte[data.Length];
int bytesRead = stream.Read(readBuf, 0, readBuf.Length);
string text = System.Text.Encoding.UTF8.GetString(readBuf, 0, bytesRead);
Console.WriteLine(text);  // "Hello, SpawnDev!"

// Write directly from a JS Uint8Array (no .NET marshaling)
using var jsData = new Uint8Array(new byte[] { 1, 2, 3, 4 });
stream.Write(jsData, 0, jsData.Length);

// Read as a Uint8Array (zero-copy subarray view)
stream.Seek(0, SeekOrigin.Begin);
using var view = stream.ReadUint8Array(16, subArray: true);

// Resize the stream
stream.SetLength(2048);
Console.WriteLine($"New length: {stream.Length}");  // 2048

// Shared buffer for cross-worker use
using var shared = new ArrayBufferStream(512, maxLength: 4096, shared: true);
Console.WriteLine($"Shared: {shared.IsSharedArrayBuffer}");  // true
Console.WriteLine($"Can grow: {shared.CanGrow}");  // true

// Wrap an existing ArrayBuffer
using var existingBuffer = new ArrayBuffer(256);
using var wrapped = new ArrayBufferStream(existingBuffer);
wrapped.Write(new byte[] { 0xDE, 0xAD, 0xBE, 0xEF }, 0, 4);

// Read-only mode
wrapped.SetReadOnly();
// wrapped.Write(...) would throw NotSupportedException

// Allow buffer recreation for unrestricted resizing
using var flexible = new ArrayBufferStream(100);
flexible.AllowRecreateBuffer = true;
flexible.SetLength(500);  // Creates a new ArrayBuffer and copies data
```
