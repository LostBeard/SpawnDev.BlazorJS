# HeapView - Zero-Copy Data Sharing

`HeapView` pins .NET arrays in WebAssembly linear memory and creates JavaScript TypedArray views that point directly at the pinned memory. This enables zero-copy data sharing between .NET and JavaScript - no serialization, no copying.

**Namespace:** `SpawnDev.BlazorJS.Toolbox`

---

## How It Works

In Blazor WebAssembly, .NET and JavaScript share the same WebAssembly linear memory (the "heap"). `HeapView` uses `GCHandle.Alloc` to pin a .NET array in place, then creates a JavaScript TypedArray that views the same memory region. Both .NET and JavaScript can read and write the same data without any copy operations.

```
.NET Array (pinned via GCHandle)
    |
    v
[WebAssembly Linear Memory: ... | pinned data bytes | ... ]
    ^
    |
JavaScript TypedArray (view into the same memory)
```

---

## HeapView\<TElement\>

### Creating a HeapView

```csharp
float[] myData = new float[1024];

// Pin the entire array
using var heap = new HeapView<float>(myData);

// Pin starting from an offset
using var heap2 = new HeapView<float>(myData, offset: 100);

// Pin a specific range
using var heap3 = new HeapView<float>(myData, offset: 100, length: 200);
```

### As\<T\>() - Zero-Copy View

`As<T>()` creates a JavaScript TypedArray that points directly at the pinned .NET memory. **No data is copied.** Changes made from JavaScript are immediately visible in .NET and vice versa.

```csharp
float[] weights = new float[4096];
using var heap = new HeapView<float>(weights);

// Zero-copy - this Float32Array IS the .NET array
using var jsView = heap.As<Float32Array>();

// Pass to a JS API (e.g., WebGL, WebGPU, Canvas)
gl.BufferData(GL.ARRAY_BUFFER, jsView, GL.STATIC_DRAW);
```

### To\<T\>() - Safe Copy

`To<T>()` creates a new JavaScript TypedArray with a **copy** of the data. The copy is independent of the .NET array - changes to one do not affect the other.

```csharp
float[] data = new float[1024];
using var heap = new HeapView<float>(data);

// Safe copy - independent of the .NET array
using var jsCopy = heap.To<Float32Array>();
```

---

## WARNINGS

### Heap Resize Invalidates As\<T\>() Views

The .NET runtime frequently resizes the WebAssembly heap. When a resize occurs, the old heap `ArrayBuffer` becomes **detached**, and ALL TypedArray views created with `As<T>()` become **invalid** - reading or writing them will throw or return garbage data.

**Rules for As\<T\>():**

1. Only use `As<T>()` views for short-lived operations within a single synchronous call
2. Do not store `As<T>()` views across await points
3. Do not store `As<T>()` views in fields or properties
4. If you need a view that outlives the current synchronous call, use `To<T>()` instead

```csharp
// SAFE: As<T>() used within a single synchronous operation
using var heap = new HeapView<float>(data);
using var view = heap.As<Float32Array>();
gl.BufferData(GL.ARRAY_BUFFER, view, GL.STATIC_DRAW);

// UNSAFE: As<T>() stored across an await point
using var heap = new HeapView<float>(data);
using var view = heap.As<Float32Array>();
await Task.Delay(100);  // Heap may resize during await!
gl.BufferData(GL.ARRAY_BUFFER, view, GL.STATIC_DRAW);  // view may be invalid!

// SAFE alternative for async: use To<T>()
using var heap = new HeapView<float>(data);
using var copy = heap.To<Float32Array>();
await Task.Delay(100);  // copy is independent, still valid
gl.BufferData(GL.ARRAY_BUFFER, copy, GL.STATIC_DRAW);
```

### Heap Priming

The first `HeapView` creation in a session calls `PrimeHeap()`, which allocates a 16MB temporary buffer to force the runtime to grow the heap early. This reduces the likelihood of heap resizes during pinned operations. You can call `HeapView.PrimeHeap()` manually with a custom size if needed.

---

## HeapViewString

`HeapViewString` pins a .NET `string` in memory, providing access to its UTF-16 character data:

```csharp
string text = "Hello, World!";
using var heap = new HeapViewString(text);
using var uint16View = heap.As<Uint16Array>(); // UTF-16 characters as uint16
```

---

## Implicit Conversions

`HeapView` supports implicit conversions to all TypedArray types and DataView:

```csharp
float[] data = new float[1024];
using var heap = new HeapView<float>(data);

// Implicit conversion to Float32Array (zero-copy As<T>())
Float32Array view = heap;

// Implicit conversion to DataView
DataView dv = heap;

// Implicit conversion to ArrayBuffer (creates a copy via ToArrayBuffer())
ArrayBuffer buffer = heap;

// Implicit conversion to SharedArrayBuffer (creates a copy)
SharedArrayBuffer sab = heap;
```

**Note:** Conversions to `ArrayBuffer` and `SharedArrayBuffer` create copies. Conversions to TypedArray types and DataView are zero-copy views.

---

## Explicit Conversions from Arrays

You can create a `HeapView` from common array types using explicit casts:

```csharp
HeapView heap1 = (HeapView)myByteArray;
HeapView heap2 = (HeapView)myFloatArray;
HeapView heap3 = (HeapView)myIntArray;
HeapView heap4 = (HeapView)myDoubleArray;
HeapView heap5 = (HeapView)"my string";
```

---

## HeapView Properties

| Property | Type | Description |
|---|---|---|
| `Data` | `TElement[]` | The pinned .NET array |
| `Address` | `long` | Memory address of the pinned data |
| `Pointer` | `IntPtr` | IntPtr to the pinned data |
| `Offset` | `long` | Start offset in elements |
| `Length` | `long` | Number of elements |
| `ByteLength` | `long` | Total size in bytes |
| `ElementSize` | `int` | Size of one element in bytes |
| `ElementType` | `Type` | The .NET element type |
| `DataType` | `Type` | The .NET array type |

---

## HeapView Methods

| Method | Description |
|---|---|
| `As<T>()` | Zero-copy TypedArray view (T must be a TypedArray type) |
| `To<T>()` | Safe copy as TypedArray (T must be a TypedArray type) |
| `AsTypedArray()` | Zero-copy view using the default TypedArray for the element type |
| `ToTypedArray()` | Safe copy using the default TypedArray for the element type |
| `AsDataView()` | Zero-copy DataView |
| `ToArrayBuffer()` | Copy as ArrayBuffer |
| `ToSharedArrayBuffer()` | Copy as SharedArrayBuffer |
| `Dispose()` | Unpin the array and dispose all created views |

---

## Performance

HeapView eliminates the most expensive part of .NET-to-JS data transfer: copying. For large arrays (textures, audio buffers, GPU compute data), the savings are significant:

- **Traditional transfer:** .NET array -> serialize -> copy to JS heap -> create TypedArray
- **HeapView As\<T\>():** .NET array -> pin in place -> create TypedArray view (zero bytes copied)
- **HeapView To\<T\>():** .NET array -> pin in place -> one memcpy -> create TypedArray (one copy, no serialization)

For GPU compute workloads (WebGL, WebGPU, ILGPU), HeapView is the standard way to get data to the GPU without unnecessary copies.

---

## Real-World Example

```csharp
// GPU compute: upload data to WebGL without copying
float[] vertices = GenerateVertexData(); // large array
using var heap = new HeapView<float>(vertices);
using var view = heap.As<Float32Array>();

// The Float32Array IS the .NET array - zero bytes copied
gl.BufferData(GL.ARRAY_BUFFER, view, GL.STATIC_DRAW);
// Data is now on the GPU
```

---

## Benchmarks

The [HeapViewTest](https://github.com/LostBeard/HeapViewTest) project benchmarks HeapView against standard .NET byte[] transfer for image data (PutImageData). Test: 8000x8000 image (256 MB), 20 iterations.

| Method | Avg | Min | Max | Throughput | Description |
|---|---|---|---|---|---|
| **HeapView Direct** | **53.6 ms** | 22.0 ms | 113.3 ms | **4.77 GB/s** | Zero-copy. Pins .NET memory and passes it directly to PutImageData. |
| HeapView Copy | 95.2 ms | 75.9 ms | 144.2 ms | 2.69 GB/s | Fast copy via Uint8ClampedArray constructor from pinned .NET memory. |
| .NET Built-in | 192.8 ms | 115.6 ms | 613.3 ms | 1.33 GB/s | Default byte[] serialization. Creates a full copy in JS memory. |

**HeapView Direct is 3.6x faster than .NET's built-in byte[] transfer** and achieves nearly 5 GB/s throughput on a 256 MB image. Even HeapView Copy (safe copy from pinned memory) is 2x faster than the default .NET approach.

The .NET built-in method also shows high variance (115ms to 613ms) due to GC pressure from the full copy, while HeapView Direct stays more consistent.

---

## See Also

- [HeapViewTest Benchmark](https://github.com/LostBeard/HeapViewTest) - Performance benchmarks comparing HeapView vs standard transfer
- [TypedArrays and Data Transfer](typed-arrays.md) - Standard (copying) data transfer
- [JSObject](jsobject.md) - Base wrapper class
