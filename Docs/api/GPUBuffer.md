# GPUBuffer

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebGPU`  
**Inheritance:** `JSObject` -> `GPUBuffer`  
**MDN Reference:** [GPUBuffer](https://developer.mozilla.org/en-US/docs/Web/API/GPUBuffer)

> The `GPUBuffer` class represents a block of memory on the GPU that can be used for vertex data, index data, uniforms, storage, or staging/readback. Created via `GPUDevice.CreateBuffer()`. Buffers must specify their intended usage flags at creation time.

## Constructors

| Signature | Description |
|-----------|-------------|
| `GPUBuffer(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Size` | `long` | The size of the buffer in bytes. |
| `Usage` | `int` | The usage flags this buffer was created with. |
| `MapState` | `string` | The current map state: `"unmapped"`, `"pending"`, or `"mapped"`. |
| `Label` | `string?` | A label for debugging. |

## Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `MapAsync(int mode)` | `Task` | Maps the buffer for CPU access. Mode: `GPUMapMode.READ` or `GPUMapMode.WRITE`. |
| `MapAsync(int mode, long offset, long size)` | `Task` | Maps a sub-range of the buffer. |
| `GetMappedRange()` | `ArrayBuffer` | Returns an `ArrayBuffer` representing the mapped range. Only valid while mapped. |
| `GetMappedRange(long offset, long size)` | `ArrayBuffer` | Returns an `ArrayBuffer` for a sub-range of the mapped data. |
| `Unmap()` | `void` | Unmaps the buffer, making it available for GPU operations again. |
| `Destroy()` | `void` | Destroys the buffer, releasing GPU memory. |

## GPUBufferUsage Flags

The `GPUBufferUsage` static class provides the usage flag constants:

| Flag | Value | Description |
|------|-------|-------------|
| `MAP_READ` | `0x0001` | Buffer can be mapped for reading (CPU readback). |
| `MAP_WRITE` | `0x0002` | Buffer can be mapped for writing (CPU upload). |
| `COPY_SRC` | `0x0004` | Buffer can be used as a source for copy operations. |
| `COPY_DST` | `0x0008` | Buffer can be used as a destination for copy operations (including `WriteBuffer`). |
| `INDEX` | `0x0010` | Buffer can be used as an index buffer. |
| `VERTEX` | `0x0020` | Buffer can be used as a vertex buffer. |
| `UNIFORM` | `0x0040` | Buffer can be used as a uniform buffer. |
| `STORAGE` | `0x0080` | Buffer can be used as a storage buffer (read/write in shaders). |
| `INDIRECT` | `0x0100` | Buffer can be used for indirect draw/dispatch arguments. |
| `QUERY_RESOLVE` | `0x0200` | Buffer can receive query results. |

## GPUMapMode Flags

| Flag | Value | Description |
|------|-------|-------------|
| `READ` | `0x0001` | Map for reading. |
| `WRITE` | `0x0002` | Map for writing. |

## Example

```csharp
// Create a storage buffer
using var storageBuffer = device.CreateBuffer(new GPUBufferDescriptor
{
    Size = 4096,
    Usage = GPUBufferUsage.STORAGE | GPUBufferUsage.COPY_SRC | GPUBufferUsage.COPY_DST,
    Label = "My Storage Buffer"
});

Console.WriteLine($"Buffer size: {storageBuffer.Size}");
Console.WriteLine($"Map state: {storageBuffer.MapState}");  // "unmapped"

// Write data via the queue
float[] data = { 1.0f, 2.0f, 3.0f, 4.0f };
using var sourceData = new Float32Array(data);
device.Queue.WriteBuffer(storageBuffer, 0, sourceData);

// Create a mappable readback buffer
using var readbackBuffer = device.CreateBuffer(new GPUBufferDescriptor
{
    Size = 4096,
    Usage = GPUBufferUsage.MAP_READ | GPUBufferUsage.COPY_DST
});

// Copy from storage to readback
using var encoder = device.CreateCommandEncoder();
encoder.CopyBufferToBuffer(storageBuffer, 0, readbackBuffer, 0, 4096);
using var commands = encoder.Finish();
device.Queue.Submit(new[] { commands });

// Map and read data back to CPU
await readbackBuffer.MapAsync(GPUMapMode.READ);
using var mapped = readbackBuffer.GetMappedRange();
byte[] result = mapped.ReadBytes();
readbackBuffer.Unmap();

// Create a vertex buffer with initial data
using var vertexBuffer = device.CreateBuffer(new GPUBufferDescriptor
{
    Size = 128,
    Usage = GPUBufferUsage.VERTEX | GPUBufferUsage.COPY_DST,
    MappedAtCreation = true  // Start mapped for initial upload
});
using var mappedVerts = vertexBuffer.GetMappedRange();
// ... write vertex data into mappedVerts ...
vertexBuffer.Unmap();

// Clean up
storageBuffer.Destroy();
```
