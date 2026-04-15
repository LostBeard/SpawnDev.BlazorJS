# GPUShaderModule

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `GPUObjectBase`  
**Source:** `JSObjects/WebGPU/GPUShaderModule.cs`  
**MDN Reference:** [GPUShaderModule on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPUShaderModule)

> The GPUShaderModule interface of the WebGPU API represents an internal shader module object, a container for WGSL shader code that can be submitted to the GPU for execution by a pipeline. A GPUShaderModule object instance is created using GPUDevice.createShaderModule(). https://developer.mozilla.org/en-US/docs/Web/API/GPUShaderModule

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetCompilationInfo()` | `Task<GPUCompilationInfo>` |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<GPUShaderModule>(...)` or constructor `new GPUShaderModule(...)`

```js
const shaders = `
struct VertexOut {
  @builtin(position) position : vec4f,
  @location(0) color : vec4f
}

@vertex
fn vertex_main(@location(0) position: vec4f,
               @location(1) color: vec4f) -> VertexOut
{
  var output : VertexOut;
  output.position = position;
  output.color = color;
  return output;
}

@fragment
fn fragment_main(fragData: VertexOut) -> @location(0) vec4f
{
  return fragData.color;
}
`;

async function init() {
  if (!navigator.gpu) {
    throw Error("WebGPU not supported.");
  }

  const adapter = await navigator.gpu.requestAdapter();

  if (!adapter) {
    throw Error("Couldn't request WebGPU adapter.");
  }

  const device = await adapter.requestDevice();

  // …
  // later on

  const shaderModule = device.createShaderModule({
    code: shaders,
  });

  // …
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPUShaderModule)*

