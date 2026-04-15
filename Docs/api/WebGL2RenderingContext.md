# WebGL2RenderingContext

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `WebGLRenderingContextBase` -> `WebGL2RenderingContextBase` -> `WebGL2RenderingContext`  
**MDN Reference:** [WebGL2RenderingContext](https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext)

> The `WebGL2RenderingContext` class provides the WebGL 2.0 rendering context (OpenGL ES 3.0). It inherits all WebGL 1.0 functionality from `WebGLRenderingContextBase` and adds WebGL 2.0 features through `WebGL2RenderingContextBase`, including vertex array objects (VAOs), transform feedback, instanced drawing, 3D textures, query objects, sync objects, samplers, and uniform buffer objects. Obtained via `getContext("webgl2")` on a canvas or `OffscreenCanvas.GetWebGL2Context()`.

## Constructors

| Signature | Description |
|-----------|-------------|
| `WebGL2RenderingContext(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Additional Methods (WebGL 2.0 - from WebGL2RenderingContextBase)

All WebGL 1.0 methods from `WebGLRenderingContext` are available. The following are WebGL 2.0 additions:

### Vertex Array Objects (VAOs)

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateVertexArray()` | `WebGLVertexArrayObject` | Creates a new VAO. |
| `BindVertexArray(WebGLVertexArrayObject? vao)` | `void` | Binds a VAO. Pass `null` to unbind. |
| `DeleteVertexArray(WebGLVertexArrayObject vao)` | `void` | Deletes a VAO. |
| `IsVertexArray(WebGLVertexArrayObject vao)` | `bool` | Tests if an object is a valid VAO. |

### Query Objects

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateQuery()` | `WebGLQuery` | Creates a query object. |
| `BeginQuery(int target, WebGLQuery query)` | `void` | Begins an asynchronous query (e.g., `ANY_SAMPLES_PASSED`). |
| `EndQuery(int target)` | `void` | Ends the active query on the target. |
| `GetQueryParameter<T>(WebGLQuery query, int pname)` | `T` | Gets a query result (e.g., `QUERY_RESULT`). |
| `DeleteQuery(WebGLQuery query)` | `void` | Deletes a query. |

### Sync Objects

| Method | Return Type | Description |
|--------|-------------|-------------|
| `FenceSync(int condition, int flags)` | `WebGLSync` | Creates a fence sync object. |
| `ClientWaitSync(WebGLSync sync, int flags, long timeout)` | `int` | Blocks until the sync condition is signaled or timeout. Returns `ALREADY_SIGNALED`, `TIMEOUT_EXPIRED`, `CONDITION_SATISFIED`, or `WAIT_FAILED`. |
| `DeleteSync(WebGLSync sync)` | `void` | Deletes a sync object. |
| `GetSyncParameter<T>(WebGLSync sync, int pname)` | `T` | Gets a sync parameter. |
| `WaitSync(WebGLSync sync, int flags, long timeout)` | `void` | Server-side wait on a sync object. |
| `IsSync(WebGLSync sync)` | `bool` | Tests if an object is a valid sync. |

### Texture Storage

| Method | Return Type | Description |
|--------|-------------|-------------|
| `TexStorage2D(int target, int levels, int internalformat, int width, int height)` | `void` | Allocates immutable 2D texture storage. |
| `TexStorage3D(int target, int levels, int internalformat, int width, int height, int depth)` | `void` | Allocates immutable 3D texture storage. |
| `TexImage3D(...)` | `void` | Specifies a 3D texture image. |
| `TexSubImage3D(...)` | `void` | Updates a sub-region of a 3D texture. |
| `CompressedTexSubImage3D(...)` | `void` | Specifies a compressed 3D texture sub-image. |

### Instanced Drawing

| Method | Return Type | Description |
|--------|-------------|-------------|
| `DrawArraysInstanced(int mode, int first, int count, int instanceCount)` | `void` | Draws instanced primitives from array data. |
| `DrawElementsInstanced(int mode, int count, int type, long offset, int instanceCount)` | `void` | Draws instanced indexed primitives. |
| `VertexAttribDivisor(int index, int divisor)` | `void` | Sets the divisor for instanced attributes. |
| `DrawRangeElements(int mode, int start, int end, int count, int type, long offset)` | `void` | Draws elements within a range. |

### Transform Feedback

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateTransformFeedback()` | `WebGLTransformFeedback` | Creates a transform feedback object. |
| `BindTransformFeedback(int target, WebGLTransformFeedback? tf)` | `void` | Binds a transform feedback object. |
| `BeginTransformFeedback(int primitiveMode)` | `void` | Begins transform feedback recording. |
| `EndTransformFeedback()` | `void` | Ends transform feedback recording. |
| `TransformFeedbackVaryings(WebGLProgram program, string[] varyings, int bufferMode)` | `void` | Specifies output varyings for transform feedback. |
| `DeleteTransformFeedback(WebGLTransformFeedback tf)` | `void` | Deletes a transform feedback object. |

### Samplers

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateSampler()` | `WebGLSampler` | Creates a sampler object. |
| `BindSampler(int unit, WebGLSampler? sampler)` | `void` | Binds a sampler to a texture unit. |
| `SamplerParameteri(WebGLSampler sampler, int pname, int param)` | `void` | Sets an integer sampler parameter. |
| `SamplerParameterf(WebGLSampler sampler, int pname, float param)` | `void` | Sets a float sampler parameter. |
| `DeleteSampler(WebGLSampler sampler)` | `void` | Deletes a sampler. |

### Uniform Buffer Objects

| Method | Return Type | Description |
|--------|-------------|-------------|
| `GetUniformBlockIndex(WebGLProgram program, string uniformBlockName)` | `int` | Returns the index of a uniform block. |
| `UniformBlockBinding(WebGLProgram program, int uniformBlockIndex, int uniformBlockBinding)` | `void` | Assigns a binding point to a uniform block. |
| `BindBufferBase(int target, int index, WebGLBuffer? buffer)` | `void` | Binds a buffer to an indexed target. |
| `BindBufferRange(int target, int index, WebGLBuffer buffer, long offset, long size)` | `void` | Binds a buffer range to an indexed target. |

### Other WebGL 2.0 Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `ReadBuffer(int src)` | `void` | Selects a color buffer for reading pixels. |
| `BlitFramebuffer(...)` | `void` | Copies a region between framebuffers. |
| `InvalidateFramebuffer(int target, int[] attachments)` | `void` | Invalidates framebuffer attachments. |
| `GetBufferSubData(int target, long srcByteOffset, TypedArray dstData)` | `void` | Reads buffer data back to CPU. |
| `CopyBufferSubData(int readTarget, int writeTarget, long readOffset, long writeOffset, long size)` | `void` | Copies data between buffers. |

## Example

```csharp
// Get WebGL2 context
using var canvas = new OffscreenCanvas(800, 600);
using var gl = canvas.GetWebGL2Context();

// Use Vertex Array Objects (VAO) - WebGL 2.0 feature
using var vao = gl.CreateVertexArray();
gl.BindVertexArray(vao);

// Set up vertex buffer
float[] vertices = { -0.5f, -0.5f, 0.5f, -0.5f, 0.0f, 0.5f };
using var vbo = gl.CreateBuffer();
gl.BindBuffer(WebGLConstants.ARRAY_BUFFER, vbo);
using var vertData = new Float32Array(vertices);
gl.BufferData(WebGLConstants.ARRAY_BUFFER, vertData, WebGLConstants.STATIC_DRAW);
gl.VertexAttribPointer(0, 2, WebGLConstants.FLOAT, false, 0, 0);
gl.EnableVertexAttribArray(0);

// Instanced drawing - render 100 instances
gl.VertexAttribDivisor(1, 1);  // Per-instance attribute
gl.DrawArraysInstanced(WebGLConstants.TRIANGLES, 0, 3, 100);

// Sync objects for GPU-CPU synchronization
using var sync = gl.FenceSync(WebGLConstants.SYNC_GPU_COMMANDS_COMPLETE, 0);
gl.Flush();
int status = gl.ClientWaitSync(sync, WebGLConstants.SYNC_FLUSH_COMMANDS_BIT, 1000000);

// Texture storage (immutable allocation)
using var tex = gl.CreateTexture();
gl.BindTexture(WebGLConstants.TEXTURE_2D, tex);
gl.TexStorage2D(WebGLConstants.TEXTURE_2D, 1, WebGLConstants.RGBA8, 512, 512);
```
