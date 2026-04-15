# ArrayBuffer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `ArrayBuffer`  
**Attribute:** `[Transferable]`  
**MDN Reference:** [ArrayBuffer - MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer)

> The `ArrayBuffer` object represents a generic raw binary data buffer. It is an array of bytes, often referred to in other languages as a "byte array". You cannot directly manipulate the contents of an `ArrayBuffer`; instead, you create a typed array view or a `DataView` to read and write the buffer contents. SpawnDev.BlazorJS extends this class with `Create` factory methods that use `HeapView` for fast zero-copy transfers from .NET arrays, and explicit cast operators for common .NET types.

## Constructors

| Signature | Description |
|---|---|
| `ArrayBuffer(long length)` | Creates an `ArrayBuffer` of the specified size in bytes, initialized to zeros. |
| `ArrayBuffer(long length, ArrayBufferOptions options)` | Creates an `ArrayBuffer` with the specified size and additional options (e.g., `maxByteLength` for resizable buffers). |
| `ArrayBuffer(IJSInProcessObjectReference _ref)` | Deserialization constructor - wraps an existing JS reference. |

## Properties

| Property | Type | Description |
|---|---|---|
| `ByteLength` | `long` | The size, in bytes, of the `ArrayBuffer`. Established at construction and can only be changed via `Resize()` if the buffer is resizable. |
| `MaxByteLength` | `long` | The read-only maximum length, in bytes, that the `ArrayBuffer` can be resized to. Established at construction. |
| `Detached` | `bool` | Read-only. Returns `true` if the `ArrayBuffer` has been detached (transferred), `false` otherwise. |
| `Resizable` | `bool` | Read-only. Returns `true` if the `ArrayBuffer` can be resized, `false` otherwise. |
| `IsSharedArrayBuffer` | `bool` | Returns `true` if the underlying JS object is actually a `SharedArrayBuffer`. Aids interop when using `SharedArrayBuffer` through `ArrayBuffer`-typed APIs. |
| `IsArrayBuffer` | `bool` | Returns `true` if the underlying JS object is an `ArrayBuffer` (not a `SharedArrayBuffer`). |

## Static Methods

| Method | Return Type | Description |
|---|---|---|
| `IsView(object value)` | `bool` | Returns `true` if `value` is one of the `ArrayBuffer` views (typed array or `DataView`). |
| `Create<T>(T[] data, long offset = 0)` | `ArrayBuffer` | Creates a new `ArrayBuffer` containing a copy of the .NET struct array, starting at the given offset. Uses `HeapView` for fast copy. |
| `Create<T>(T[] data, long offset, long length)` | `ArrayBuffer` | Creates a new `ArrayBuffer` containing a copy of `length` elements from the .NET struct array, starting at `offset`. |
| `Create(string data, long offset = 0)` | `ArrayBuffer` | Creates a new `ArrayBuffer` from a string's internal character data (UTF-16). |
| `Create(string data, long offset, long length)` | `ArrayBuffer` | Creates a new `ArrayBuffer` from `length` characters of the string, starting at `offset`. |

## Instance Methods

| Method | Return Type | Description |
|---|---|---|
| `ReadBytes()` | `byte[]` | Reads the entire `ArrayBuffer` content into a .NET `byte[]`. Internally creates a `Uint8Array` view. |
| `Slice()` | `ArrayBuffer` | Returns a new `ArrayBuffer` containing a copy of all bytes. |
| `Slice(long start)` | `ArrayBuffer` | Returns a new `ArrayBuffer` from `start` (inclusive) to the end. Negative values count from the end. |
| `Slice(long start, long end)` | `ArrayBuffer` | Returns a new `ArrayBuffer` from `start` (inclusive) to `end` (exclusive). |
| `Resize(long newLength)` | `void` | Resizes the `ArrayBuffer` to `newLength` bytes. Only works on resizable buffers. |
| `Transfer()` | `ArrayBuffer` | Creates a new `ArrayBuffer` with the same content, then detaches this buffer. |
| `Transfer(long newByteLength)` | `ArrayBuffer` | Creates a new `ArrayBuffer` of `newByteLength` with the same content (truncated or zero-padded), then detaches this buffer. |
| `TransferToFixedLength()` | `ArrayBuffer` | Creates a new non-resizable `ArrayBuffer` with the same content, then detaches this buffer. |
| `TransferToFixedLength(long newByteLength)` | `ArrayBuffer` | Creates a new non-resizable `ArrayBuffer` of `newByteLength`, then detaches this buffer. |

## Explicit Cast Operators

SpawnDev.BlazorJS provides explicit cast operators using `HeapView` for fast data transfer between .NET arrays and `ArrayBuffer`.

| Cast | Description |
|---|---|
| `(ArrayBuffer)byte[]` | Copies a `byte[]` to a new `ArrayBuffer`. |
| `(byte[])ArrayBuffer` | Reads an `ArrayBuffer` into a `byte[]`. Returns `null` if the source is `null`. |
| `(ArrayBuffer)string` | Copies a string's character data (UTF-16) to a new `ArrayBuffer`. |
| `(ArrayBuffer)sbyte[]` | Copies an `sbyte[]` to a new `ArrayBuffer`. |
| `(ArrayBuffer)short[]` | Copies a `short[]` to a new `ArrayBuffer`. |
| `(ArrayBuffer)ushort[]` | Copies a `ushort[]` to a new `ArrayBuffer`. |
| `(ArrayBuffer)int[]` | Copies an `int[]` to a new `ArrayBuffer`. |
| `(ArrayBuffer)uint[]` | Copies a `uint[]` to a new `ArrayBuffer`. |
| `(ArrayBuffer)long[]` | Copies a `long[]` to a new `ArrayBuffer`. |
| `(ArrayBuffer)ulong[]` | Copies a `ulong[]` to a new `ArrayBuffer`. |
| `(ArrayBuffer)Half[]` | Copies a `Half[]` to a new `ArrayBuffer`. |
| `(ArrayBuffer)float[]` | Copies a `float[]` to a new `ArrayBuffer`. |
| `(ArrayBuffer)double[]` | Copies a `double[]` to a new `ArrayBuffer`. |

## Example

```csharp
// Create from .NET data
byte[] myData = new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F };
using var buffer = (ArrayBuffer)myData;

// Read properties
Console.WriteLine($"ByteLength: {buffer.ByteLength}");    // 5
Console.WriteLine($"Detached: {buffer.Detached}");         // false
Console.WriteLine($"Resizable: {buffer.Resizable}");       // false

// Read back to .NET
byte[] readBack = buffer.ReadBytes();
byte[] alsoWorks = (byte[])buffer;

// Slice a portion
using var sliced = buffer.Slice(1, 4);  // bytes at index 1, 2, 3
Console.WriteLine($"Sliced length: {sliced.ByteLength}");  // 3

// Create from float array using generic factory
float[] floats = new float[] { 1.0f, 2.0f, 3.0f };
using var floatBuffer = ArrayBuffer.Create(floats);
Console.WriteLine($"Float buffer size: {floatBuffer.ByteLength}");  // 12

// Transfer detaches the original
using var transferred = buffer.Transfer();
Console.WriteLine($"Original detached: {buffer.Detached}");  // true
```
