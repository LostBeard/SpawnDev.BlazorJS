# HeapView

**Namespace:** `SpawnDev.BlazorJS.Toolbox`  
**Inheritance:** `HeapView` (base), `HeapView<TElement>` (generic), `HeapViewString` (string variant)

> Pins .NET arrays (or strings) in WASM linear memory using `GCHandle`, then creates JavaScript TypedArray or DataView views that point directly at the pinned memory. This enables **zero-copy** data sharing between .NET and JavaScript - the JS TypedArray reads and writes the exact same bytes as the .NET array. HeapView is fundamental to SpawnDev.BlazorJS's high-performance data transfer and is used extensively throughout the library.

## WARNING - Heap Resize Invalidation

.NET frequently resizes its WASM heap. When it does, **all existing TypedArray views become invalid** because the underlying `ArrayBuffer` is detached. Views created with `As<T>()` point directly at the heap and will be invalidated by a resize. Use `To<T>()` for a safe copy that survives heap resizes. Only use `As<T>()` for short-lived operations within a single synchronous call.

## PrimeHeap

On first HeapView creation, `PrimeHeap()` allocates 16MB to force a heap resize, then releases it. This delays future heap growth, reducing the chance of views being invalidated during typical operations.

## Constructors

### HeapView&lt;TElement&gt;

| Signature | Description |
|---|---|
| `HeapView<TElement>(TElement[] data, long offset = 0)` | Pins the array starting at the given offset through to the end. |
| `HeapView<TElement>(TElement[] data, long offset, long length)` | Pins a specific range of the array. |

### HeapViewString

| Signature | Description |
|---|---|
| `HeapViewString(string data, long offset = 0)` | Pins the string's internal char buffer. Element size is 2 bytes (UTF-16). |
| `HeapViewString(string data, long offset, long length)` | Pins a specific range of characters. |

## Properties

| Property | Type | Description |
|---|---|---|
| `Address` | `long` | The memory address (as a long) of the pinned data in WASM linear memory. |
| `Pointer` | `IntPtr` | Pointer to the pinned memory region. |
| `ByteLength` | `long` | Total size of the pinned region in bytes. |
| `ElementSize` | `int` | Size of a single element in bytes (e.g., 4 for `float`, 8 for `double`). |
| `Length` | `long` | Number of elements in the pinned region. |
| `Offset` | `long` | Start index offset within the original data. |
| `ElementType` | `Type` | The .NET type of each element. |
| `DataType` | `Type` | The .NET type of the pinned data (array type or `string`). |
| `Disposed` | `bool` | Whether the HeapView has been disposed. |

### HeapView&lt;TElement&gt; Additional

| Property | Type | Description |
|---|---|---|
| `Data` | `TElement[]` | The pinned array. |

### HeapViewString Additional

| Property | Type | Description |
|---|---|---|
| `Data` | `string` | The pinned string. |

## Factory Methods

| Method | Return Type | Description |
|---|---|---|
| `HeapView.Create<T>(T[] data, long offset = 0)` | `HeapView` | Creates a HeapView for any struct array. |
| `HeapView.Create<T>(T[] data, long offset, long length)` | `HeapView` | Creates a HeapView for a range of a struct array. |
| `HeapView.Create(string data, long offset = 0)` | `HeapView` | Creates a HeapViewString. |
| `HeapView.Create(string data, long offset, long length)` | `HeapView` | Creates a HeapViewString for a character range. |

## Explicit Cast Operators (data -> HeapView)

| Cast | Description |
|---|---|
| `(HeapView)byte[]` | Pins a byte array. |
| `(HeapView)sbyte[]` | Pins a sbyte array. |
| `(HeapView)short[]` | Pins a short array. |
| `(HeapView)ushort[]` | Pins a ushort array. |
| `(HeapView)int[]` | Pins an int array. |
| `(HeapView)uint[]` | Pins a uint array. |
| `(HeapView)long[]` | Pins a long array. |
| `(HeapView)ulong[]` | Pins a ulong array. |
| `(HeapView)Half[]` | Pins a Half array. |
| `(HeapView)float[]` | Pins a float array. |
| `(HeapView)double[]` | Pins a double array. |
| `(HeapView)string` | Pins a string's character buffer. |

## Implicit Cast Operators (HeapView -> JS types)

These create **zero-copy views** into the pinned memory. Disposed automatically when the HeapView is disposed.

| Cast | Target Type | Description |
|---|---|---|
| `(Uint8Array)heapView` | `Uint8Array` | Zero-copy byte view. |
| `(Uint8ClampedArray)heapView` | `Uint8ClampedArray` | Zero-copy clamped byte view. |
| `(Int8Array)heapView` | `Int8Array` | Zero-copy signed byte view. |
| `(Uint16Array)heapView` | `Uint16Array` | Zero-copy unsigned 16-bit view. |
| `(Int16Array)heapView` | `Int16Array` | Zero-copy signed 16-bit view. |
| `(Uint32Array)heapView` | `Uint32Array` | Zero-copy unsigned 32-bit view. |
| `(Int32Array)heapView` | `Int32Array` | Zero-copy signed 32-bit view. |
| `(BigUint64Array)heapView` | `BigUint64Array` | Zero-copy unsigned 64-bit view. |
| `(BigInt64Array)heapView` | `BigInt64Array` | Zero-copy signed 64-bit view. |
| `(Float16Array)heapView` | `Float16Array` | Zero-copy half-precision float view. |
| `(Float32Array)heapView` | `Float32Array` | Zero-copy single-precision float view. |
| `(Float64Array)heapView` | `Float64Array` | Zero-copy double-precision float view. |
| `(DataView)heapView` | `DataView` | Zero-copy DataView. |
| `(ArrayBuffer)heapView` | `ArrayBuffer` | **Safe copy** to a new ArrayBuffer. |
| `(SharedArrayBuffer)heapView` | `SharedArrayBuffer` | **Safe copy** to a new SharedArrayBuffer. |

## As Methods (Zero-Copy Views)

Views created by `As` methods are tracked and disposed when the HeapView is disposed.

| Method | Return Type | Description |
|---|---|---|
| `As<TTypedArray>(long byteOffset = 0)` | `TTypedArray` | Returns a TypedArray view into the pinned memory at the given byte offset. **Invalidated by heap resize.** |
| `As<TTypedArray>(long byteOffset, long elementCount)` | `TTypedArray` | Returns a TypedArray view with explicit element count. |
| `As(Type typedArrayType, long byteOffset = 0)` | `TypedArray` | Non-generic variant. |
| `AsDataView(long byteOffset = 0)` | `DataView` | Returns a DataView into the pinned memory. |
| `AsDataView(long byteOffset, long byteLength)` | `DataView` | Returns a DataView with explicit byte length. |
| `AsTypedArray()` | `TypedArray` | Returns a TypedArray matching the element type (e.g., `float[]` -> `Float32Array`). |
| `AsNativeView()` | `JSObject` | Returns the appropriate JS view - TypedArray for arrays, decoded string for strings. |

## To Methods (Safe Copies)

These create independent copies that survive heap resizes.

| Method | Return Type | Description |
|---|---|---|
| `To<TTypedArray>(long byteOffset = 0)` | `TTypedArray` | Creates a new TypedArray with a copy of the data. |
| `To<TTypedArray>(long byteOffset, long elementCount)` | `TTypedArray` | Creates a copy with explicit element count. |
| `To(Type typedArrayType, long byteOffset = 0)` | `TypedArray` | Non-generic variant. |
| `ToArrayBuffer(long byteOffset = 0)` | `ArrayBuffer` | Creates a new ArrayBuffer with a copy of the data. |
| `ToArrayBuffer(long byteOffset, long byteLength)` | `ArrayBuffer` | Creates a copy with explicit byte range. |
| `ToSharedArrayBuffer(long byteOffset = 0)` | `SharedArrayBuffer` | Creates a new SharedArrayBuffer with a copy of the data. |
| `ToSharedArrayBuffer(long byteOffset, long byteLength)` | `SharedArrayBuffer` | Creates a copy with explicit byte range. |
| `ToDataView(long byteOffset = 0)` | `DataView` | Creates a DataView backed by a new ArrayBuffer copy. |
| `ToTypedArray()` | `TypedArray` | Creates a TypedArray copy matching the element type. |
| `ToNativeView()` | `JSObject` | Creates a copy as the appropriate JS type. |

## Static Utility Methods

| Method | Return Type | Description |
|---|---|---|
| `PrimeHeap(int preAllocateSize = 16MB)` | `void` | Allocates and releases memory to delay future heap growth. Called automatically on first HeapView creation. |
| `GetHeapBuffer()` | `ArrayBuffer` | Returns the current WASM heap ArrayBuffer. Becomes detached on resize. |
| `GetHeapBufferSize()` | `long` | Returns the current heap ArrayBuffer size in bytes. |
| `GetHeap()` | `Uint8Array` | Returns the current WASM heap as a Uint8Array. Must be used immediately - invalidated on resize. |

## Example

```csharp
// Pin a float array for zero-copy JS access
float[] data = new float[] { 1.0f, 2.0f, 3.0f, 4.0f };
using var heap = new HeapView<float>(data);

// Zero-copy view - JS reads/writes the same memory as .NET
using var jsView = heap.As<Float32Array>();
// jsView[0] === 1.0, jsView[1] === 2.0, etc.

// Safe copy - independent of heap state
using var safeCopy = heap.To<Float32Array>();
// safeCopy survives .NET heap resizes

// Use implicit casts for one-liner zero-copy
byte[] bytes = new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F };
using var heapBytes = (HeapView)bytes;
Uint8Array uint8View = heapBytes;  // Implicit cast to zero-copy view

// Pin a subset of an array
float[] bigArray = new float[1000];
using var subset = new HeapView<float>(bigArray, offset: 100, length: 50);
// Only elements 100-149 are exposed to JS

// HeapView for strings (UTF-16 char buffer)
string text = "Hello SpawnDev";
using var heapStr = new HeapViewString(text);
Console.WriteLine($"Byte length: {heapStr.ByteLength}");  // 28 (14 chars x 2 bytes)

// Convert to ArrayBuffer (always a safe copy)
using var arrayBuffer = heap.ToArrayBuffer();

// The pattern used throughout SpawnDev.BlazorJS for fast data transfer:
// .NET array -> HeapView -> As<TypedArray>() -> pass to JS API -> dispose
int[] ints = new int[] { 10, 20, 30 };
using var hv = HeapView.Create(ints);
using var int32View = hv.As<Int32Array>();
// Pass int32View to any JS API that accepts Int32Array
```
