# Float32Array

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `TypedArray` -> `TypedArray<float>` -> `Float32Array`  
**MDN Reference:** [Float32Array - MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Float32Array)

> The `Float32Array` typed array represents an array of 32-bit floating point numbers in the platform byte order. Each element occupies 4 bytes. This is the standard format for GPU vertex data, audio samples, neural network weights, and most real-time numerical computing. If byte order control is needed, use `DataView` instead.

## Constructors

| Signature | Description |
|---|---|
| `Float32Array()` | Creates an empty `Float32Array`. |
| `Float32Array(long length)` | Creates a `Float32Array` of the given element count, initialized to zeros. |
| `Float32Array(float[] array)` | Creates from a .NET `float[]`. Copies data via an intermediate `ArrayBuffer`. |
| `Float32Array(TypedArray typedArray)` | Creates by copying from another typed array. |
| `Float32Array(ArrayBuffer arrayBuffer)` | Creates a view over the entire `ArrayBuffer`. |
| `Float32Array(ArrayBuffer arrayBuffer, long byteOffset)` | Creates a view starting at `byteOffset` (must be 4-byte aligned). |
| `Float32Array(ArrayBuffer arrayBuffer, long byteOffset, long length)` | Creates a view of `length` elements starting at `byteOffset`. |
| `Float32Array(SharedArrayBuffer sharedArrayBuffer)` | Creates a view over a `SharedArrayBuffer`. |
| `Float32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset)` | Creates a view at `byteOffset`. |
| `Float32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length)` | Creates a view of `length` elements at `byteOffset`. |
| `Float32Array(Array<float> array)` | Creates from a JS `Array<float>`. |
| `Float32Array(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|---|---|---|
| `Buffer` | `ArrayBuffer` | The underlying buffer. |
| `ByteLength` | `long` | Length in bytes (`Length * 4`). |
| `ByteOffset` | `long` | Offset from buffer start. |
| `Length` | `long` | Number of float elements. |
| `BYTES_PER_ELEMENT` | `int` | Always `4`. |
| `this[long i]` | `float` | Indexer for element access. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Slice()` | `Float32Array` | Returns a new `Float32Array` with a copy of all elements. |
| `Slice(long start)` | `Float32Array` | Copy from `start` to end. |
| `Slice(long start, long end)` | `Float32Array` | Copy from `start` (inclusive) to `end` (exclusive). |
| `SubArray()` | `Float32Array` | View over the same buffer. |
| `SubArray(long start)` | `Float32Array` | View from `start` (inclusive). |
| `SubArray(long start, long end)` | `Float32Array` | View from `start` to `end`. Same buffer - no copy. |
| `ToArray(long start = 0)` | `float[]` | Reads elements into a .NET array. |
| `ToArray(long start, long length)` | `float[]` | Reads `length` elements. |
| `At(long index)` | `float` | Returns element at `index`. Negative counts from end. |
| `Fill(float value)` | `TypedArray` | Fills all elements with `value`. |

## Static Methods

| Method | Return Type | Description |
|---|---|---|
| `From<T>(IEnumerable<T> values)` | `Float32Array` | Creates from an iterable via `Float32Array.from()`. |

## Explicit Cast Operators

| Cast | Description |
|---|---|
| `(float[])Float32Array` | Reads the array into a .NET `float[]`. |
| `(Float32Array)float[]` | Creates a new `Float32Array` from a `float[]`. |

## Example

```csharp
// Create from .NET float data (e.g., model weights)
float[] weights = { 0.1f, 0.5f, -0.3f, 0.8f };
using var arr = new Float32Array(weights);

// Read back to .NET
float[] data = arr.ToArray();
float[] viaCast = (float[])arr;

// Element access
float val = arr[2];    // -0.3
arr[2] = 0.0f;

// Slice a portion (creates a copy)
using var firstTwo = arr.Slice(0, 2);  // [0.1, 0.5]

// SubArray (view, no copy - shares the buffer)
using var view = arr.SubArray(1, 3);  // View of elements [1..3)

// Create a zeroed buffer for GPU compute
using var gpuBuffer = new Float32Array(1024);  // 1024 floats = 4096 bytes

// Write .NET data into the buffer
float[] newWeights = { 1.0f, 2.0f, 3.0f };
gpuBuffer.FromArray(newWeights, destOffset: 10);  // Write at element index 10

// Read a subset back
float[] subset = gpuBuffer.ToArray(10, 3);  // [1.0, 2.0, 3.0]

// Cast operators for concise usage
using var fromCast = (Float32Array)weights;
```
