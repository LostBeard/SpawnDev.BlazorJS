# Int32Array

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `TypedArray` -> `TypedArray<int>` -> `Int32Array`  
**MDN Reference:** [Int32Array - MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Int32Array)

> The `Int32Array` typed array represents an array of 32-bit signed integers in the platform byte order. Each element occupies 4 bytes. Contents are initialized to `0`. `Int32Array` is particularly important for `Atomics` operations - `Atomics.wait()` and `Atomics.notify()` require an `Int32Array` backed by a `SharedArrayBuffer` for thread synchronization.

## Constructors

| Signature | Description |
|---|---|
| `Int32Array()` | Creates an empty `Int32Array`. |
| `Int32Array(long length)` | Creates an `Int32Array` of the given element count, initialized to zeros. |
| `Int32Array(int[] array)` | Creates from a .NET `int[]`. |
| `Int32Array(TypedArray typedArray)` | Creates by copying from another typed array. |
| `Int32Array(ArrayBuffer arrayBuffer)` | Creates a view over the entire `ArrayBuffer`. |
| `Int32Array(ArrayBuffer arrayBuffer, long byteOffset)` | Creates a view at `byteOffset` (must be 4-byte aligned). |
| `Int32Array(ArrayBuffer arrayBuffer, long byteOffset, long length)` | Creates a view of `length` elements at `byteOffset`. |
| `Int32Array(SharedArrayBuffer sharedArrayBuffer)` | Creates a view over a `SharedArrayBuffer`. |
| `Int32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset)` | Creates a view at `byteOffset`. |
| `Int32Array(SharedArrayBuffer sharedArrayBuffer, long byteOffset, long length)` | Creates a view of `length` elements at `byteOffset`. |
| `Int32Array(Array<int> array)` | Creates from a JS `Array<int>`. |
| `Int32Array(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|---|---|---|
| `Buffer` | `ArrayBuffer` | The underlying buffer. |
| `ByteLength` | `long` | Length in bytes (`Length * 4`). |
| `ByteOffset` | `long` | Offset from buffer start. |
| `Length` | `long` | Number of int elements. |
| `BYTES_PER_ELEMENT` | `int` | Always `4`. |
| `this[long i]` | `int` | Indexer for element access. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Slice()` | `Int32Array` | Returns a new `Int32Array` copy. |
| `Slice(long start)` | `Int32Array` | Copy from `start` to end. |
| `Slice(long start, long end)` | `Int32Array` | Copy from `start` to `end`. |
| `SubArray()` | `Int32Array` | View over the same buffer. |
| `SubArray(long start)` | `Int32Array` | View from `start`. |
| `SubArray(long start, long end)` | `Int32Array` | View from `start` to `end`. No copy. |
| `ToArray(long start = 0)` | `int[]` | Reads elements into a .NET array. |
| `ToArray(long start, long length)` | `int[]` | Reads `length` elements. |
| `At(long index)` | `int` | Returns element at `index`. |

## Static Methods

| Method | Return Type | Description |
|---|---|---|
| `From<T>(IEnumerable<T> values)` | `Int32Array` | Creates from an iterable via `Int32Array.from()`. |

## Explicit Cast Operators

| Cast | Description |
|---|---|
| `(int[])Int32Array` | Reads into a .NET `int[]`. |
| `(Int32Array)int[]` | Creates a new `Int32Array` from an `int[]`. |

## Example

```csharp
// Create from .NET data
int[] ids = { 100, 200, 300, 400 };
using var arr = new Int32Array(ids);

// Read back
int[] data = arr.ToArray();
int[] viaCast = (int[])arr;

// Element access
int val = arr[1];  // 200
arr[1] = 999;

// Use with Atomics for shared memory synchronization
using var sab = new SharedArrayBuffer(256);
using var shared = new Int32Array(sab);
Atomics.Store(shared, 0, 0);

// Worker A: wait for value to change from 0
// string result = Atomics.Wait(shared, 0, 0);  // blocks until notified

// Worker B: update and notify
Atomics.Store(shared, 0, 42);
int woken = Atomics.Notify(shared, 0, 1);  // Wake one waiting thread

// Slice and SubArray
using var firstHalf = arr.Slice(0, 2);       // Copy: [100, 999]
using var viewAll = arr.SubArray();            // View: same buffer
```
