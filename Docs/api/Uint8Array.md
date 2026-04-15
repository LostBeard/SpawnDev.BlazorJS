# Uint8Array

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `TypedArray` -> `TypedArray<byte>` -> `Uint8Array`  
**MDN Reference:** [Uint8Array - MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Uint8Array)

> The `Uint8Array` typed array represents an array of 8-bit unsigned integers. This is the most commonly used typed array for binary data in web applications and serves as the bridge between .NET `byte[]` and JavaScript binary data. SpawnDev.BlazorJS provides explicit cast operators for seamless conversion between `byte[]` and `Uint8Array`, plus `Create` factory methods for efficient copies via `HeapView`.

## Constructors

| Signature | Description |
|---|---|
| `Uint8Array()` | Creates an empty `Uint8Array`. |
| `Uint8Array(long length)` | Creates a `Uint8Array` of the given length, initialized to zeros. |
| `Uint8Array(byte[] sourceBytes)` | Creates a `Uint8Array` from a .NET `byte[]`. Internally creates an `ArrayBuffer` copy. |
| `Uint8Array(TypedArray typedArray)` | Creates a `Uint8Array` by copying from another typed array. |
| `Uint8Array(ArrayBuffer arrayBuffer)` | Creates a view over the entire `ArrayBuffer`. |
| `Uint8Array(ArrayBuffer arrayBuffer, long byteOffset)` | Creates a view starting at `byteOffset`. |
| `Uint8Array(ArrayBuffer arrayBuffer, long byteOffset, long length)` | Creates a view of `length` bytes at `byteOffset`. |
| `Uint8Array(SharedArrayBuffer sharedArrayBuffer)` | Creates a view over a `SharedArrayBuffer`. |
| `Uint8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset)` | Creates a view at `byteOffset`. |
| `Uint8Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length)` | Creates a view of `length` bytes at `byteOffset`. |
| `Uint8Array(Array<byte> array)` | Creates from a JS `Array<byte>`. |
| `Uint8Array(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

Inherits all properties from `TypedArray<byte>` and `TypedArray`:

| Property | Type | Description |
|---|---|---|
| `Buffer` | `ArrayBuffer` | The underlying buffer. |
| `ByteLength` | `long` | Length in bytes (same as `Length` for `Uint8Array`). |
| `ByteOffset` | `long` | Offset from buffer start. |
| `Length` | `long` | Number of elements. |
| `BYTES_PER_ELEMENT` | `int` | Always `1` for `Uint8Array`. |
| `this[long i]` | `byte` | Indexer for element access. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Slice()` | `Uint8Array` | Returns a new `Uint8Array` with a copy of all elements. |
| `Slice(long start)` | `Uint8Array` | Returns a copy from `start` to end. |
| `Slice(long start, long end)` | `Uint8Array` | Returns a copy from `start` (inclusive) to `end` (exclusive). |
| `SubArray()` | `Uint8Array` | Returns a new view over the same buffer. |
| `SubArray(long start)` | `Uint8Array` | Returns a view from `start` (inclusive). |
| `SubArray(long start, long end)` | `Uint8Array` | Returns a view from `start` (inclusive) to `end` (exclusive). Same buffer - no copy. |
| `Fill(byte value)` | `Uint8Array` | Fills all elements with `value`. Returns this array. |
| `ToArray(long start = 0)` | `byte[]` | Reads all bytes starting at element `start` into a .NET array. |
| `ToArray(long start, long length)` | `byte[]` | Reads `length` bytes. |
| `ReadBytes(long byteOffset = 0)` | `byte[]` | Reads raw bytes. |

## Static Methods

| Method | Return Type | Description |
|---|---|---|
| `From<T>(IEnumerable<T> values)` | `Uint8Array` | Creates from an iterable via `Uint8Array.from()`. |
| `Create<T>(T[] data, long offset = 0)` | `Uint8Array` | Creates from a .NET struct array via `HeapView`. |
| `Create<T>(T[] data, long offset, long length)` | `Uint8Array` | Creates from a portion of a struct array. |
| `Create(string data, long offset = 0)` | `Uint8Array` | Creates from string character data. |
| `Create(string data, long offset, long length)` | `Uint8Array` | Creates from a portion of a string. |

## Explicit Cast Operators

| Cast | Description |
|---|---|
| `(byte[])Uint8Array` | Reads the `Uint8Array` into a .NET `byte[]`. Returns `null` if source is `null`. |
| `(Uint8Array)byte[]` | Creates a new `Uint8Array` from a `byte[]`. Returns `null` if source is `null`. |
| `(Uint8Array)ArrayBuffer` | Creates a new `Uint8Array` view over the `ArrayBuffer`. |

## Example

```csharp
// Create from .NET byte array
byte[] myBytes = new byte[] { 72, 101, 108, 108, 111 };  // "Hello" in ASCII
using var arr = new Uint8Array(myBytes);

// Read back
byte[] readBack = arr.ToArray();
byte[] alsoWorks = (byte[])arr;

// Use explicit casts for concise code
using var fromCast = (Uint8Array)myBytes;
byte[] toCast = (byte[])fromCast;

// Create a zeroed buffer and fill it
using var zeros = new Uint8Array(256);
zeros.Fill(0xFF);  // Fill with 255

// Slice creates a copy
using var slice = arr.Slice(1, 4);  // [101, 108, 108]

// SubArray creates a view (no copy, shares the buffer)
using var view = arr.SubArray(0, 3);
view[0] = 0x57;  // Modifies the original buffer

// Create from struct array (e.g., ints) - reinterprets bytes
int[] ints = { 1, 2, 3 };
using var fromInts = Uint8Array.Create(ints);  // 12 bytes (3 x 4 bytes per int)

// Access via indexer
byte first = arr[0];
arr[0] = 0x42;
```
