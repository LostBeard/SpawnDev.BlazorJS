# GPUTexture

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `GPUObjectBase`  
**Source:** `JSObjects/WebGPU/GPUTexture.cs`  
**MDN Reference:** [GPUTexture on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPUTexture)

> The GPUTexture interface of the WebGPU API represents a container used to store 1D, 2D, or 3D arrays of data, such as images, to use in GPU rendering operations. A GPUTexture object instance is created using the GPUDevice.createTexture() method. https://www.w3.org/TR/webgpu/#gputexture https://developer.mozilla.org/en-US/docs/Web/API/GPUTexture

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Width` | `GPUIntegerCoordinateOut` | get | A number representing the width of the GPUTexture in pixels. |
| `Height` | `GPUIntegerCoordinateOut` | get | A number representing the height of the GPUTexture in pixels. |
| `DepthOrArrayLayers` | `GPUIntegerCoordinateOut` | get | A number representing the depth or layer count of the GPUTexture (pixels, or number of layers). |
| `MipLevelCount` | `GPUIntegerCoordinateOut` | get | A number representing the number of mip levels of the GPUTexture. |
| `SampleCount` | `GPUSize32Out` | get/set | A number representing the sample count of the GPUTexture. |
| `Dimension` | `string` | get | An enumerated value representing the dimension of the set of texels for each GPUTexture subresource. |
| `Format` | `string` | get | An enumerated value representing the format of the GPUTexture. See the Texture formats section of the specification for all the possible values. |
| `Usage` | `GPUFlagsConstant` | get | The bitwise flags representing the allowed usages of the GPUTexture. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CreateView()` | `GPUTextureView` | The createView() method of the GPUTexture interface creates a GPUTextureView representing a specific view of the GPUTexture. |
| `CreateView(GPUTextureViewDescriptor descriptor)` | `GPUTextureView` | Creates a GPUTextureView representing a specific view of the GPUTexture with the given descriptor. |
| `Destroy()` | `void` | Destroys the GPUTexture. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<GPUTexture>(...)` or constructor `new GPUTexture(...)`

```js
// …
let cubeTexture;
{
  const img = document.createElement("img");

  img.src = new URL(
    "../../../assets/img/Di-3d.png",
    import.meta.url,
  ).toString();

  await img.decode();

  const imageBitmap = await createImageBitmap(img);

  cubeTexture = device.createTexture({
    size: [imageBitmap.width, imageBitmap.height, 1],
    format: "rgba8unorm",
    usage:
      GPUTextureUsage.TEXTURE_BINDING |
      GPUTextureUsage.COPY_DST |
      GPUTextureUsage.RENDER_ATTACHMENT,
  });

  device.queue.copyExternalImageToTexture(
    { source: imageBitmap },
    { texture: cubeTexture },
    [imageBitmap.width, imageBitmap.height],
  );
}
// …
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPUTexture)*

