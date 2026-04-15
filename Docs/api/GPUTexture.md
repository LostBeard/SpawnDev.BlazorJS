# GPUTexture

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebGPU`  
**Inheritance:** `JSObject` -> `GPUTexture`  
**MDN Reference:** [GPUTexture](https://developer.mozilla.org/en-US/docs/Web/API/GPUTexture)

> The `GPUTexture` class represents a GPU texture resource. Textures hold image data for rendering (color attachments, depth/stencil) or for sampling in shaders. Created via `GPUDevice.CreateTexture()`. Texture data can be uploaded via `GPUQueue.WriteTexture()` or `GPUQueue.CopyExternalImageToTexture()`.

## Constructors

| Signature | Description |
|-----------|-------------|
| `GPUTexture(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Width` | `int` | The width of the texture in texels. |
| `Height` | `int` | The height of the texture in texels. |
| `DepthOrArrayLayers` | `int` | The depth (for 3D textures) or array layer count. |
| `MipLevelCount` | `int` | The number of mip levels. |
| `SampleCount` | `int` | The number of samples per texel (for multisampled textures). |
| `Dimension` | `string` | The texture dimension: `"1d"`, `"2d"`, or `"3d"`. |
| `Format` | `string` | The texture format (e.g., `"rgba8unorm"`, `"bgra8unorm"`, `"depth24plus"`). |
| `Usage` | `int` | The usage flags (bitwise OR of `GPUTextureUsage` values). |
| `Label` | `string?` | A label for debugging. |

## Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateView()` | `GPUTextureView` | Creates a default texture view. |
| `CreateView(GPUTextureViewDescriptor descriptor)` | `GPUTextureView` | Creates a texture view with specific settings (format, dimension, mip levels, array layers). |
| `Destroy()` | `void` | Destroys the texture, releasing GPU memory. |

## GPUTextureUsage Flags

| Flag | Value | Description |
|------|-------|-------------|
| `COPY_SRC` | `0x01` | Texture can be used as a source for copy operations. |
| `COPY_DST` | `0x02` | Texture can be used as a destination for copy/write operations. |
| `TEXTURE_BINDING` | `0x04` | Texture can be bound for sampling in shaders. |
| `STORAGE_BINDING` | `0x08` | Texture can be bound as a storage texture (read/write in compute shaders). |
| `RENDER_ATTACHMENT` | `0x10` | Texture can be used as a render target (color/depth/stencil attachment). |

## Example

```csharp
// Create a 2D texture for rendering
using var colorTexture = device.CreateTexture(new GPUTextureDescriptor
{
    Size = new GPUExtent3DDict { Width = 1024, Height = 768 },
    Format = "bgra8unorm",
    Usage = GPUTextureUsage.RENDER_ATTACHMENT | GPUTextureUsage.TEXTURE_BINDING,
    Label = "Color Texture"
});

Console.WriteLine($"Texture: {colorTexture.Width}x{colorTexture.Height}");
Console.WriteLine($"Format: {colorTexture.Format}");

// Create a texture view for use as a render target
using var colorView = colorTexture.CreateView();

// Create a depth texture
using var depthTexture = device.CreateTexture(new GPUTextureDescriptor
{
    Size = new GPUExtent3DDict { Width = 1024, Height = 768 },
    Format = "depth24plus",
    Usage = GPUTextureUsage.RENDER_ATTACHMENT,
    Label = "Depth Texture"
});
using var depthView = depthTexture.CreateView();

// Create a texture with mip maps
using var mipmappedTexture = device.CreateTexture(new GPUTextureDescriptor
{
    Size = new GPUExtent3DDict { Width = 512, Height = 512 },
    MipLevelCount = 10,
    Format = "rgba8unorm",
    Usage = GPUTextureUsage.TEXTURE_BINDING | GPUTextureUsage.COPY_DST | GPUTextureUsage.RENDER_ATTACHMENT
});

// Upload pixel data
byte[] pixels = new byte[512 * 512 * 4];
using var pixelData = new Uint8Array(pixels);
device.Queue.WriteTexture(
    new GPUTexelCopyTextureInfo { Texture = mipmappedTexture },
    pixelData,
    new GPUTexelCopyBufferLayout { BytesPerRow = 512 * 4, RowsPerImage = 512 },
    new GPUExtent3DDict { Width = 512, Height = 512 }
);

// Clean up
colorTexture.Destroy();
depthTexture.Destroy();
```
