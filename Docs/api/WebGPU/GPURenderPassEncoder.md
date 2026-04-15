# GPURenderPassEncoder

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `GPUObjectBase`, `GPUCommandsMixin`, `GPUDebugCommandsMixin`, `GPUBindingCommandsMixin`, `GPURenderCommandsMixin`  
**Source:** `JSObjects/WebGPU/GPURenderPassEncoder.cs`  

> Represents an encoder for recording commands within a GPU render pass. https://www.w3.org/TR/webgpu/#gpurenderpassencoder

## Methods

| Method | Return Type | Description |
|---|---|---|
| `PushDebugGroup(string groupLabel)` | `void` |  |
| `PopDebugGroup()` | `void` |  |
| `InsertDebugMarker(string markerLabel)` | `void` |  |
| `SetPipeline(GPURenderPipeline pipeline)` | `void` |  |
| `SetIndexBuffer(GPUBuffer buffer, EnumString<GPUIndexFormat> indexFormat, GPUSize64 offset)` | `void` |  |
| `SetIndexBuffer(GPUBuffer buffer, EnumString<GPUIndexFormat> indexFormat, GPUSize64 offset, GPUSize64 size)` | `void` |  |
| `SetVertexBuffer(GPUIndex32 slot, GPUBuffer? buffer, GPUSize64 offset)` | `void` |  |
| `SetVertexBuffer(GPUIndex32 slot, GPUBuffer? buffer, GPUSize64 offset, GPUSize64 size)` | `void` |  |
| `Draw(GPUSize32 vertexCount, GPUSize32 instanceCount, GPUSize32 firstVertex, GPUSize32 firstInstance)` | `void` |  |
| `DrawIndexed(GPUSize32 indexCount, GPUSize32 instanceCount, GPUSize32 firstIndex, GPUSignedOffset32 baseVertex, GPUSize32 firstInstance)` | `void` |  |
| `DrawIndirect(GPUBuffer indirectBuffer, GPUSize64 indirectOffset)` | `void` |  |
| `DrawIndexedIndirect(GPUBuffer indirectBuffer, GPUSize64 indirectOffset)` | `void` |  |
| `SetBindGroup(GPUIndex32 index, GPUBindGroup? bindGroup, IEnumerable<GPUBufferDynamicOffset>? dynamicOffsets)` | `void` |  |
| `SetBindGroup(GPUIndex32 index, GPUBindGroup? bindGroup, Uint32Array dynamicOffsetsData, GPUSize64 dynamicOffsetsDataStart, GPUSize32 dynamicOffsetsDataLength)` | `void` |  |
| `SetViewport(float x, float y, float width, float height, float minDepth, float maxDepth)` | `void` | Sets the viewport used during the rasterization stage to linearly map from normalized device coordinates to viewport coordinates. Minimum X value of the viewport in pixels. Minimum Y value of the viewport in pixels. Width of the viewport in pixels. Height of the viewport in pixels. Minimum depth value of the viewport. Maximum depth value of the viewport. |
| `SetScissorRect(GPUIntegerCoordinate x, GPUIntegerCoordinate y, GPUIntegerCoordinate width, GPUIntegerCoordinate height)` | `void` | Sets the scissor rectangle used during the rasterization stage. After transformation into viewport coordinates any fragments which fall outside the scissor rectangle will be discarded. Minimum X value of the scissor rectangle in pixels. Minimum Y value of the scissor rectangle in pixels. Width of the scissor rectangle in pixels. Height of the scissor rectangle in pixels. |
| `SetBlendConstant(GPUColor color)` | `void` | Sets the constant blend color and alpha values used with "constant" and "one-minus-constant" GPUBlendFactors. The color to use when blending. |
| `SetStencilReference(GPUStencilValue reference)` | `void` | Sets the [[stencilReference]] value used during stencil tests with the "replace" GPUStencilOperation. The new stencil reference value. |
| `BeginOcclusionQuery(GPUSize32 queryIndex)` | `void` | Begin occlusion query The index of the query in the query set. |
| `EndOcclusionQuery()` | `void` | End occlusion query |
| `ExecuteBundles(IEnumerable<GPURenderBundle> bundles)` | `void` | Executes the commands previously recorded into the given GPURenderBundles as part of this render pass. When a GPURenderBundle is executed, it does not inherit the render pass’s pipeline, bind groups, or vertex and index buffers. After a GPURenderBundle has executed, the render pass’s pipeline, bind group, and vertex/index buffer state is cleared (to the initial, empty values). |
| `End()` | `void` | Completes recording of the current render pass command sequence. https://developer.mozilla.org/en-US/docs/Web/API/GPURenderPassEncoder/end |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<GPURenderPassEncoder>(...)` or constructor `new GPURenderPassEncoder(...)`

```js
// …

const renderPipeline = device.createRenderPipeline(pipelineDescriptor);

// Create GPUCommandEncoder to issue commands to the GPU
// Note: render pass descriptor, command encoder, etc. are destroyed after use, fresh one needed for each frame.
const commandEncoder = device.createCommandEncoder();

// Create GPURenderPassDescriptor to tell WebGPU which texture to draw into, then initiate render pass
const renderPassDescriptor = {
  colorAttachments: [
    {
      clearValue: clearColor,
      loadOp: "clear",
      storeOp: "store",
      view: context.getCurrentTexture().createView(),
    },
  ],
};

const passEncoder = commandEncoder.beginRenderPass(renderPassDescriptor);

// Draw the triangle
passEncoder.setPipeline(renderPipeline);
passEncoder.setVertexBuffer(0, vertexBuffer);
passEncoder.draw(3);

// End the render pass
passEncoder.end();

// End frame by passing array of command buffers to command queue for execution
device.queue.submit([commandEncoder.finish()]);

// …
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPURenderPassEncoder/end)*

