# TypedArrays and Data Transfer

SpawnDev.BlazorJS provides complete wrappers for all JavaScript TypedArray types, ArrayBuffer, SharedArrayBuffer, and DataView. These types allow efficient binary data transfer between .NET and JavaScript.

**Namespace:** `SpawnDev.BlazorJS.JSObjects`

---

## TypedArray Types

| C# Class | JavaScript Type | Element Type | Bytes per Element |
|---|---|---|---|
| `Uint8Array` | `Uint8Array` | `byte` | 1 |
| `Uint8ClampedArray` | `Uint8ClampedArray` | `byte` | 1 |
| `Int8Array` | `Int8Array` | `sbyte` | 1 |
| `Uint16Array` | `Uint16Array` | `ushort` | 2 |
| `Int16Array` | `Int16Array` | `short` | 2 |
| `Uint32Array` | `Uint32Array` | `uint` | 4 |
| `Int32Array` | `Int32Array` | `int` | 4 |
| `Float16Array` | `Float16Array` | `Half` | 2 |
| `Float32Array` | `Float32Array` | `float` | 4 |
| `Float64Array` | `Float64Array` | `double` | 8 |
| `BigInt64Array` | `BigInt64Array` | `long` | 8 |
| `BigUint64Array` | `BigUint64Array` | `ulong` | 8 |

All types inherit from the `TypedArray` base class.

---

## Creating TypedArrays from .NET Arrays

```csharp
// From a byte array
byte[] data = [1, 2, 3, 4, 5];
using var uint8 = new Uint8Array(data);

// From a float array
float[] floats = [1.0f, 2.5f, 3.14f];
using var float32 = new Float32Array(floats);

// From an int array
int[] ints = [10, 20, 30, 40];
using var int32 = new Int32Array(ints);

// From a double array
double[] doubles = [1.0, 2.0, 3.0];
using var float64 = new Float64Array(doubles);

// Empty with a specific length
using var empty = new Uint8Array(1024);
```

---

## Reading Data Back to .NET

### ToArray()

Returns a copy of the data as a .NET array:

```csharp
using var uint8 = new Uint8Array(myBytes);
byte[] readBack = uint8.ToArray();

using var float32 = new Float32Array(myFloats);
float[] readBack = float32.ToArray();
```

### ToArray(start, length)

Returns a subset of the data:

```csharp
float[] subset = float32Array.ToArray(10, 5);
// Returns elements 10 through 14
```

### Read\<T\>()

Read the underlying buffer as a different element type:

```csharp
using var uint8 = new Uint8Array(rawBytes);
byte[] data = uint8.Read<byte>();
```

---

## Indexer Access

TypedArrays support indexer access for reading and writing individual elements:

```csharp
using var uint8 = new Uint8Array(new byte[] { 10, 20, 30 });

// Read at index
byte val = uint8[0];  // 10

// Write at index
uint8[0] = 42;

// Verify
byte newVal = uint8[0];  // 42
```

---

## Explicit Cast Operators

SpawnDev.BlazorJS provides explicit cast operators between .NET arrays and TypedArrays:

```csharp
// .NET array -> TypedArray (creates a new JS TypedArray)
byte[] bytes = [1, 2, 3];
Uint8Array jsArray = (Uint8Array)bytes;

// TypedArray -> .NET array (copies data back)
byte[] backToNet = (byte[])jsArray;

jsArray.Dispose();
```

---

## ArrayBuffer

`ArrayBuffer` represents a fixed-length raw binary data buffer in JavaScript.

### Creating

```csharp
// Create from .NET data
using var buffer = ArrayBuffer.Create(myByteArray);
using var buffer2 = ArrayBuffer.Create(myFloatArray);

// Explicit cast from byte array
using var buffer3 = (ArrayBuffer)myBytes;

// Create empty with specific byte length
using var buffer4 = new ArrayBuffer(1024);
```

### Reading

```csharp
// Read as byte array
byte[] data = buffer.ReadBytes();

// Explicit cast to byte array
byte[] data2 = (byte[])buffer;
```

### Slicing

```csharp
// Create a new ArrayBuffer from a portion of an existing one
using var slice = buffer.Slice(0, 100);  // First 100 bytes
```

---

## SharedArrayBuffer

`SharedArrayBuffer` is like `ArrayBuffer` but can be shared between Web Workers (requires cross-origin isolation).

```csharp
// Create a SharedArrayBuffer
using var sab = new SharedArrayBuffer(1024);

// Create a typed view on it
using var int32View = new Int32Array(sab);

// SharedArrayBuffers can be transferred to workers
// and both the main thread and worker see the same memory
```

**Note:** SharedArrayBuffer requires the site to be cross-origin isolated (`Cross-Origin-Opener-Policy: same-origin` and `Cross-Origin-Embedder-Policy: require-corp`). Check `JS.CrossOriginIsolated` to verify.

---

## DataView

`DataView` provides a low-level interface for reading and writing multiple number types in an `ArrayBuffer`, with explicit control over byte order (endianness).

```csharp
using var buffer = new ArrayBuffer(16);
using var view = new DataView(buffer);

// Write values with explicit byte order
view.SetInt32(0, 42, true);       // little-endian
view.SetFloat32(4, 3.14f, true);

// Read values
int val = view.GetInt32(0, true);         // 42
float fval = view.GetFloat32(4, true);    // 3.14
```

---

## Passing TypedArrays to JavaScript APIs

TypedArrays are JSObject wrappers, so they can be passed directly to any JavaScript API:

```csharp
// Create data
float[] audioSamples = GenerateAudioSamples();
using var float32 = new Float32Array(audioSamples);

// Pass to Web Audio API
audioBufferSourceNode.Buffer.CopyToChannel(float32, 0);

// Pass to WebGL
gl.BufferData(GL.ARRAY_BUFFER, float32, GL.STATIC_DRAW);

// Pass to WebSocket
using var uint8 = new Uint8Array(messageBytes);
webSocket.Send(uint8.Buffer);
```

---

## TypedArray Properties

All TypedArray types inherit these properties from the base `TypedArray` class:

| Property | Type | Description |
|---|---|---|
| `Length` | `int` | Number of elements |
| `ByteLength` | `int` | Size in bytes |
| `ByteOffset` | `int` | Offset from start of buffer |
| `Buffer` | `ArrayBuffer` | The underlying ArrayBuffer |

---

## Performance Considerations

- **Creating a TypedArray from a .NET array** copies the data from .NET to JavaScript. This is a one-time cost.
- **ToArray()** copies data from JavaScript back to .NET. Also a one-time cost.
- **For zero-copy access**, use [HeapView](heapview.md) instead, which pins .NET arrays in WASM linear memory.
- **Explicit casts** (`(Uint8Array)bytes`) create new objects - they are not views.
- **Prefer passing TypedArrays directly** to JS APIs rather than converting to/from .NET arrays multiple times.

---

## See Also

- [HeapView (Zero-Copy)](heapview.md) - Zero-copy data sharing without copies
- [JSObject](jsobject.md) - Base wrapper class
