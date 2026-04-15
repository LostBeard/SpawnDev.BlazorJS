# GPUBuffer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `GPUObjectBase`  
**Source:** `JSObjects/WebGPU/GPUBuffer.cs`  

> The GPUBuffer interface of the WebGPU API represents a block of memory that can be used to store raw data to use in GPU operations. A GPUBuffer object instance is created using the GPUDevice.createBuffer() method. https://www.w3.org/TR/webgpu/#gpubuffer

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `MapState` | `EnumString<GPUBufferMapState>?` | get | An enumerated value representing the mapped state of the GPUBuffer. |
| `Size` | `GPUSize64Out` | get | A number representing the length of the GPUBuffer's memory allocation, in bytes. |
| `Usage` | `GPUBufferUsage` | get | The usage read-only property of the GPUBuffer interface contains the bitwise flags representing the allowed usages of the GPUBuffer. usage is set via the usage property in the descriptor object passed into the originating GPUDevice.createBuffer() call. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Destroy()` | `void` | Destroys the GPUBuffer |
| `GetMappedRange()` | `ArrayBuffer` | The getMappedRange() method of the GPUBuffer interface returns an ArrayBuffer containing the mapped contents of the GPUBuffer in the specified range. This can only happen once the GPUBuffer has been successfully mapped with GPUBuffer.mapAsync() (this can be checked via GPUBuffer.mapState). While the GPUBuffer is mapped it cannot be used in any GPU commands. When you have finished working with the GPUBuffer values, call GPUBuffer.unmap() to unmap it, making it accessible to the GPU again. An ArrayBuffer. |
| `GetMappedRange(long offset)` | `ArrayBuffer` | The getMappedRange() method of the GPUBuffer interface returns an ArrayBuffer containing the mapped contents of the GPUBuffer in the specified range. This can only happen once the GPUBuffer has been successfully mapped with GPUBuffer.mapAsync() (this can be checked via GPUBuffer.mapState). While the GPUBuffer is mapped it cannot be used in any GPU commands. When you have finished working with the GPUBuffer values, call GPUBuffer.unmap() to unmap it, making it accessible to the GPU again. A number representing the offset, in bytes, from the start of the GPUBuffer's mapped range to the start of the range to be returned in the ArrayBuffer. If offset is omitted, it defaults to 0. An ArrayBuffer. |
| `GetMappedRange(long offset, long size)` | `ArrayBuffer` | The getMappedRange() method of the GPUBuffer interface returns an ArrayBuffer containing the mapped contents of the GPUBuffer in the specified range. This can only happen once the GPUBuffer has been successfully mapped with GPUBuffer.mapAsync() (this can be checked via GPUBuffer.mapState). While the GPUBuffer is mapped it cannot be used in any GPU commands. When you have finished working with the GPUBuffer values, call GPUBuffer.unmap() to unmap it, making it accessible to the GPU again. A number representing the offset, in bytes, from the start of the GPUBuffer's mapped range to the start of the range to be returned in the ArrayBuffer. If offset is omitted, it defaults to 0. A number representing the size, in bytes, of the ArrayBuffer to return. If size is omitted, the range extends to the end of the GPUBuffer's mapped range. An ArrayBuffer. |
| `MapAsync(GPUMapMode mode, long offset, long size)` | `Task` | The mapAsync() method of the GPUBuffer interface maps the specified range of the GPUBuffer. It returns a Promise that resolves when the GPUBuffer's content is ready to be accessed. While the GPUBuffer is mapped it cannot be used in any GPU commands. Once the buffer is successfully mapped (which can be checked via GPUBuffer.mapState), calls to GPUBuffer.getMappedRange() will return an ArrayBuffer containing the GPUBuffer's current values, to be read and updated by JavaScript as required. When you have finished working with the GPUBuffer values, call GPUBuffer.unmap() to unmap it, making it accessible to the GPU again. A bitwise flag that specifies whether the GPUBuffer is mapped for reading or writing. Possible values are: GPUMapMode.READ - The GPUBuffer is mapped for reading. Values can be read, but any changes made to the ArrayBuffer returned by GPUBuffer.getMappedRange() will be discarded once GPUBuffer.unmap() is called. Read-mode mapping can only be used on GPUBuffers that have a usage of GPUBufferUsage.MAP_READ set on them (i.e. when created with GPUDevice.createBuffer()). GPUMapMode.WRITE - The GPUBuffer is mapped for writing. Values can be read and updated - any changes made to the ArrayBuffer returned by GPUBuffer.getMappedRange() will be saved to the GPUBuffer once GPUBuffer.unmap() is called. Write-mode mapping can only be used on GPUBuffers that have a usage of GPUBufferUsage.MAP_WRITE set on them (i.e. when created with GPUDevice.createBuffer()). A number representing the offset, in bytes, from the start of the buffer to the start of the range to be mapped. If offset is omitted, it defaults to 0. A number representing the size, in bytes, of the range to be mapped. If size is omitted, the range mapped extends to the end of the GPUBuffer. A Promise that resolves to Undefined when the GPUBuffer's content is ready to be accessed. |
| `MapAsync(GPUMapMode mode, long offset)` | `Task` | The mapAsync() method of the GPUBuffer interface maps the specified range of the GPUBuffer. It returns a Promise that resolves when the GPUBuffer's content is ready to be accessed. While the GPUBuffer is mapped it cannot be used in any GPU commands. Once the buffer is successfully mapped (which can be checked via GPUBuffer.mapState), calls to GPUBuffer.getMappedRange() will return an ArrayBuffer containing the GPUBuffer's current values, to be read and updated by JavaScript as required. When you have finished working with the GPUBuffer values, call GPUBuffer.unmap() to unmap it, making it accessible to the GPU again. A bitwise flag that specifies whether the GPUBuffer is mapped for reading or writing. Possible values are: GPUMapMode.READ - The GPUBuffer is mapped for reading. Values can be read, but any changes made to the ArrayBuffer returned by GPUBuffer.getMappedRange() will be discarded once GPUBuffer.unmap() is called. Read-mode mapping can only be used on GPUBuffers that have a usage of GPUBufferUsage.MAP_READ set on them (i.e. when created with GPUDevice.createBuffer()). GPUMapMode.WRITE - The GPUBuffer is mapped for writing. Values can be read and updated - any changes made to the ArrayBuffer returned by GPUBuffer.getMappedRange() will be saved to the GPUBuffer once GPUBuffer.unmap() is called. Write-mode mapping can only be used on GPUBuffers that have a usage of GPUBufferUsage.MAP_WRITE set on them (i.e. when created with GPUDevice.createBuffer()). A number representing the offset, in bytes, from the start of the buffer to the start of the range to be mapped. If offset is omitted, it defaults to 0. A Promise that resolves to Undefined when the GPUBuffer's content is ready to be accessed. |
| `Unmap()` | `void` | The unmap() method of the GPUBuffer interface unmaps the mapped range of the GPUBuffer, making its contents available for use by the GPU again after it has previously been mapped with GPUBuffer.mapAsync() (the GPU cannot access a mapped GPUBuffer). When unmap() is called, any ArrayBuffers created via GPUBuffer.getMappedRange() are detached. |

## Example

```csharp
// Create a buffer that can be mapped for reading results back to CPU
using var readBuffer = device.CreateBuffer(new GPUBufferDescriptor
{
    Size = 1024,
    Usage = GPUBufferUsage.MapRead | GPUBufferUsage.CopyDst,
});

// Create a buffer mapped at creation for writing initial data
using var writeBuffer = device.CreateBuffer(new GPUBufferDescriptor
{
    Size = 256,
    Usage = GPUBufferUsage.MapWrite | GPUBufferUsage.CopySrc,
    MappedAtCreation = true,
});

// Write data into the mapped buffer
using var mappedRange = writeBuffer.GetMappedRange();
byte[] data = mappedRange.ReadBytes();
// ... modify data ...
writeBuffer.Unmap(); // Makes the buffer usable by the GPU again

// Map the read buffer asynchronously to read GPU results
await readBuffer.MapAsync(GPUMapMode.Read);
Console.WriteLine($"Map state: {readBuffer.MapState}");

// Read the mapped data
using var resultRange = readBuffer.GetMappedRange(0, 256);
byte[] resultData = resultRange.ReadBytes();
Console.WriteLine($"Read {resultData.Length} bytes from GPU buffer");

// Unmap when done reading
readBuffer.Unmap();

// Check buffer properties
Console.WriteLine($"Buffer size: {readBuffer.Size} bytes");
Console.WriteLine($"Buffer usage: {readBuffer.Usage}");

// Destroy buffers when no longer needed
readBuffer.Destroy();
writeBuffer.Destroy();
```

