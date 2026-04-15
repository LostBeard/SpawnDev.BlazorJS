# TypedArray

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `TypedArray` -> `TypedArray<TElement>`  
**MDN Reference:** [TypedArray - MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/TypedArray)

> `TypedArray` is the abstract base class for all typed array views over binary data buffers. There is no global `TypedArray` constructor in JavaScript - instead, concrete subclasses like `Uint8Array`, `Float32Array`, etc. are used. SpawnDev.BlazorJS provides both the non-generic `TypedArray` base (with byte-level operations) and the generic `TypedArray<TElement>` (with element-typed operations). The library extends the standard API with high-performance `Read<T>`, `Write<T>`, `ToArray`, `FromArray`, and `ReCast` methods that use `HeapView` for efficient data transfer between .NET and JavaScript.

## TypedArray (non-generic base)

### Properties

| Property | Type | Description |
|---|---|---|
| `Buffer` | `ArrayBuffer` | The underlying `ArrayBuffer`. |
| `ByteLength` | `long` | Length of the view in bytes. |
| `ByteOffset` | `long` | Offset in bytes from the start of the buffer. |
| `Length` | `long` | Number of elements in the typed array. |
| `IsPartialView` | `bool` | (Non-standard) `true` if the view does not span the entire buffer. |
| `IsSharedArrayBuffer` | `bool` | `true` if the underlying buffer is a `SharedArrayBuffer`. |
| `IsArrayBuffer` | `bool` | `true` if the underlying buffer is an `ArrayBuffer`. |

### Methods - Standard JS

| Method | Return Type | Description |
|---|---|---|
| `Set(TypedArray source)` | `void` | Copies all elements from `source` into this array. |
| `Set(TypedArray source, long targetOffset)` | `void` | Copies elements from `source` starting at `targetOffset`. |
| `Set(Array source, long targetOffset = 0)` | `void` | Copies from a JS `Array`. |
| `Set(byte[] array, long targetOffset = 0)` | `void` | Copies from a .NET `byte[]` via `HeapView`. |
| `Set(sbyte[] array, long targetOffset = 0)` | `void` | Copies from a .NET `sbyte[]`. |
| `Set(short[] array, long targetOffset = 0)` | `void` | Copies from a .NET `short[]`. |
| `Set(ushort[] array, long targetOffset = 0)` | `void` | Copies from a .NET `ushort[]`. |
| `Set(int[] array, long targetOffset = 0)` | `void` | Copies from a .NET `int[]`. |
| `Set(uint[] array, long targetOffset = 0)` | `void` | Copies from a .NET `uint[]`. |
| `Set(long[] array, long targetOffset = 0)` | `void` | Copies from a .NET `long[]`. |
| `Set(ulong[] array, long targetOffset = 0)` | `void` | Copies from a .NET `ulong[]`. |
| `Set(Half[] array, long targetOffset = 0)` | `void` | Copies from a .NET `Half[]`. |
| `Set(float[] array, long targetOffset = 0)` | `void` | Copies from a .NET `float[]`. |
| `Set(double[] array, long targetOffset = 0)` | `void` | Copies from a .NET `double[]`. |

### Methods - SpawnDev Extensions

| Method | Return Type | Description |
|---|---|---|
| `ReadBytes(long byteOffset = 0)` | `byte[]` | Reads all bytes starting at `byteOffset`. |
| `ReadBytes(long byteOffset, long byteLength)` | `byte[]` | Reads `byteLength` bytes starting at `byteOffset`. |
| `WriteBytes(byte[] data, long byteOffset = 0)` | `void` | Writes bytes at `byteOffset`. |
| `Read<T>(long srcByteOffset = 0)` | `T[]` | Reads all elements of type `T` from the byte offset. Direct byte copy - no type conversion. |
| `Read<T>(long srcByteOffset, long count)` | `T[]` | Reads `count` elements of type `T`. |
| `Read<T>(long srcByteOffset, T[] buffer, long offset, long count)` | `long` | Reads into an existing buffer. Returns elements read. |
| `Write<T>(T[] srcData, long destByteOffset = 0)` | `void` | Writes a .NET struct array at the byte offset. |
| `Write<T>(T[] srcData, long destByteOffset, long srcOffset, long length)` | `void` | Writes `length` elements from `srcOffset` to `destByteOffset`. |
| `ToArray<T>(long start = 0)` | `T[]` | Reads all elements of type `T` starting at element index `start`. |
| `ToArray<T>(long start, long count)` | `T[]` | Reads `count` elements starting at element index `start`. |
| `ToArray<T>(long srcOffset, T[] dest, long destOffset, long count)` | `long` | Copies into an existing array. Returns count copied. |
| `FromArray<T>(T[] srcData, long destOffset = 0)` | `void` | Writes a .NET array starting at element index `destOffset`. |
| `FromArray<T>(T[] srcData, long destOffset, long srcOffset, long length)` | `void` | Writes `length` elements. |
| `ReCast<TTypedArray>()` | `TTypedArray` | Creates a new typed array view over the same buffer region. |
| `ReCast<TTypedArray>(long byteOffset, long length)` | `TTypedArray` | Creates a new typed array view at the specified offset with the given length. |

### Static Methods

| Method | Return Type | Description |
|---|---|---|
| `GetTypeDefaultTypedArrayType<T>()` | `Type?` | Returns the JS TypedArray type for a .NET struct type (e.g., `float` -> `Float32Array`). |
| `GetTypeDefaultTypedArrayType(Type)` | `Type?` | Returns the JS TypedArray type for a .NET type. |
| `GetTypedArrayElementSize<TTypedArray>()` | `int` | Returns the element size in bytes for a TypedArray type. |
| `GetTypedArrayElementSize(Type)` | `int` | Returns the element size in bytes for a TypedArray type. |

## TypedArray&lt;TElement&gt; (generic)

Extends `TypedArray` with element-typed operations.

### Properties

| Property | Type | Description |
|---|---|---|
| `ElementType` | `Type` | The .NET `Type` of the element (`typeof(TElement)`). |
| `BYTES_PER_ELEMENT` | `int` | (Static) Size of one element in bytes. |
| `this[long i]` | `TElement` | Indexer - gets or sets element at index `i`. |

### Methods

| Method | Return Type | Description |
|---|---|---|
| `At(long index)` | `TElement` | Returns element at `index`. Negative indices count from end. |
| `ToArray(long start = 0)` | `TElement[]` | Reads all elements from `start`. |
| `ToArray(long start, long length)` | `TElement[]` | Reads `length` elements from `start`. |
| `ToArray(long srcOffset, TElement[] dest, long destOffset, long count)` | `long` | Copies into existing array. |
| `FromArray(TElement[] srcData, long destOffset = 0)` | `void` | Writes .NET array to this typed array at element `destOffset`. |
| `FromArray(TElement[] srcData, long destOffset, long srcOffset, long length)` | `void` | Writes `length` elements. |
| `Values()` | `Iterator<TElement>` | Returns a value iterator. |
| `Fill(TElement value)` | `TypedArray` | Fills all elements with `value`. Returns the typed array. |
| `FillVoid(TElement value)` | `void` | Fills all elements with `value`. |

## Concrete Subclasses

| Class | Element Type | Bytes | .NET Type |
|---|---|---|---|
| `Uint8Array` | unsigned 8-bit int | 1 | `byte` |
| `Uint8ClampedArray` | clamped unsigned 8-bit int | 1 | `byte` |
| `Int8Array` | signed 8-bit int | 1 | `sbyte` |
| `Uint16Array` | unsigned 16-bit int | 2 | `ushort` |
| `Int16Array` | signed 16-bit int | 2 | `short` |
| `Uint32Array` | unsigned 32-bit int | 4 | `uint` |
| `Int32Array` | signed 32-bit int | 4 | `int` |
| `Float16Array` | 16-bit float | 2 | `Half` |
| `Float32Array` | 32-bit float | 4 | `float` |
| `Float64Array` | 64-bit float | 8 | `double` |
| `BigInt64Array` | signed 64-bit int | 8 | `long` |
| `BigUint64Array` | unsigned 64-bit int | 8 | `ulong` |

## Example

```csharp
// Create a Float32Array from .NET data
float[] weights = { 0.5f, 1.0f, 1.5f, 2.0f };
using var arr = new Float32Array(weights);

// Access elements via indexer
float first = arr[0];    // 0.5
arr[3] = 3.0f;

// Read back to .NET
float[] data = arr.ToArray();

// Use ReCast to view the same buffer as bytes
using var bytes = arr.ReCast<Uint8Array>();
Console.WriteLine($"Float32 bytes: {bytes.Length}");  // 16

// Write .NET data directly into a typed array
using var buffer = new Float32Array(100);
float[] newData = { 10.0f, 20.0f, 30.0f };
buffer.FromArray(newData, destOffset: 5);  // Write at element index 5

// Read a subset
float[] subset = buffer.ToArray(5, 3);  // [10.0, 20.0, 30.0]

// Generic Read<T> for raw byte-level access
byte[] rawBytes = arr.Read<byte>();  // All bytes of the float array
```
