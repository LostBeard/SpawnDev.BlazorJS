# GPUQueue

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `GPUObjectBase`  
**Source:** `JSObjects/WebGPU/GPUQueue.cs`  
**MDN Reference:** [GPUQueue on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPUQueue)

> The GPUQueue interface of the WebGPU API controls execution of encoded commands on the GPU. https://developer.mozilla.org/en-US/docs/Web/API/GPUQueue https://www.w3.org/TR/webgpu/#gpuqueue

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Submit(GPUCommandBuffer[] commandBuffers)` | `void` | Schedules the execution of the command buffers by the GPU on this queue. Submitted command buffers cannot be used again. |
| `OnSubmittedWorkDone()` | `Task` | Returns a Promise that resolves when all the work submitted to the GPU via this GPUQueue at the point the method is called has been processed. |
| `WriteBuffer(GPUBuffer gpuBuffer, GPUSize64 bufferOffset, AllowSharedBufferSource data, int? dataOffset, GPUSize64? size)` | `void` | The writeBuffer() method of the GPUQueue interface writes a provided data source into a given GPUBuffer. This is a convenience function, which provides an alternative to setting buffer data via buffer mapping and buffer-to-buffer copies. It lets the user agent determine the most efficient way to copy the data over. A GPUBuffer object representing the buffer to write data to. A number representing the offset, in bytes, to start writing the data at inside the GPUBuffer. An object representing the data source to write into the GPUBuffer. This can be an ArrayBuffer, TypedArray, or DataView. A number representing the offset to start writing the data from inside the data source. This value is a number of elements if data is a TypedArray, and a number of bytes if not. If omitted, dataOffset defaults to 0. A number representing the size of the content to write from data to buffer. This value is a number of elements if data is a TypedArray, and a number of bytes if not. If omitted, size will be equal to the overall size of data, minus dataOffset. |
| `WriteBuffer(GPUBuffer gpuBuffer, long bufferOffset, AllowSharedBufferSource data, int? dataOffset, long? size)` | `void` | The writeBuffer() method of the GPUQueue interface writes a provided data source into a given GPUBuffer. This is a convenience function, which provides an alternative to setting buffer data via buffer mapping and buffer-to-buffer copies. It lets the user agent determine the most efficient way to copy the data over. A GPUBuffer object representing the buffer to write data to. A number representing the offset, in bytes, to start writing the data at inside the GPUBuffer. An object representing the data source to write into the GPUBuffer. This can be an ArrayBuffer, TypedArray, or DataView. A number representing the offset to start writing the data from inside the data source. This value is a number of elements if data is a TypedArray, and a number of bytes if not. If omitted, dataOffset defaults to 0. A number representing the size of the content to write from data to buffer. This value is a number of elements if data is a TypedArray, and a number of bytes if not. If omitted, size will be equal to the overall size of data, minus dataOffset. |
| `WriteTexture(GPUTexelCopyTextureInfo destination, AllowSharedBufferSource data, GPUTexelCopyBufferLayout dataLayout, GPUExtent3D size)` | `void` | Issues a write operation of the provided data into a GPUTexture. The texture subresource and origin to write to. Data to write into destination. Layout of the content in data. Extents of the content to write from data to destination. |
| `CopyExternalImageToTexture(GPUCopyExternalImageSourceInfo source, GPUCopyExternalImageDestInfo destination, GPUExtent3D copySize)` | `void` | Issues a copy operation of the contents of a platform image/canvas into the destination texture. This operation performs color encoding into the destination encoding according to the parameters of GPUCopyExternalImageDestInfo. Copying into a -srgb texture results in the same texture bytes, not the same decoded values, as copying into the corresponding non--srgb format. Thus, after a copy operation, sampling the destination texture has different results depending on whether its format is -srgb, all else unchanged. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<GPUQueue>(...)` or constructor `new GPUQueue(...)`

```js
const vertices = new Float32Array([
  0.0, 0.6, 0, 1, 1, 0, 0, 1, -0.5, -0.6, 0, 1, 0, 1, 0, 1, 0.5, -0.6, 0, 1, 0,
  0, 1, 1,
]);
```

```js
const vertexBuffer = device.createBuffer({
  size: vertices.byteLength, // make it big enough to store vertices in
  usage: GPUBufferUsage.VERTEX | GPUBufferUsage.COPY_DST,
});
```

```js
device.queue.writeBuffer(vertexBuffer, 0, vertices, 0, vertices.length);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPUQueue)*

