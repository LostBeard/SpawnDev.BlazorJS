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

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `DrawingBufferColorSpace` | `string` | get | The WebGL2RenderingContext.drawingBufferColorSpace property specifies the color space of the WebGL drawing buffer. Along with the default (srgb), the display-p3 color space can be used. This property can have the following values: "srgb" selects the sRGB color space. This is the default value. "display-p3" selects the display-p3 color space. |
| `UnpackColorSpace` | `string` | get | The WebGL2RenderingContext.unpackColorSpace property specifies the color space to convert to when importing textures. Along with the default (srgb), the display-p3 color space can be used. This property can have the following values: "srgb" selects the sRGB color space. This is the default value. "display-p3" selects the display-p3 color space. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetIndexedParameter(GLenum target, GLuint index)` | `GLuint` | The WebGL2RenderingContext.getIndexedParameter() method of the WebGL 2 API returns indexed information about a given target. |
| `BufferData(GLenum target, Union<TypedArray, DataView, byte[]> sourceData, GLenum usage, GLuint srcOffset = 0, GLuint length = 0)` | `void` | The WebGL2RenderingContext.bufferData() method of the WebGL API creates and initializes the buffer object's data store. |
| `BufferSubData(GLenum target, GLsizeiptr dstByteOffset, Union<TypedArray, DataView, byte[]> sourceData, GLuint srcOffset = 0, GLuint length = 0)` | `void` | The WebGL2RenderingContext.bufferSubData() method of the WebGL API updates a subset of a buffer object's data store. |
| `CopyBufferSubData(GLenum readTarget, GLenum writeTarget, GLintptr readOffset, GLintptr writeOffset, GLsizei size)` | `void` | The WebGL2RenderingContext.copyBufferSubData() method of the WebGL 2 API copies part of the data of a buffer to another buffer. |
| `GetBufferSubData(GLenum target, GLintptr srcByteOffset, Union<TypedArray, DataView> dstData, GLuint dstOffset = 0, GLuint length = 0)` | `void` | The WebGL2RenderingContext.getBufferSubData() method of the WebGL 2 API reads data from a buffer binding point and writes them to an ArrayBuffer or SharedArrayBuffer. |
| `GetBufferSubData(GLenum target, GLintptr srcByteOffset, byte[] dstData, GLuint dstOffset = 0, GLuint length = 0)` | `void` | The WebGL2RenderingContext.getBufferSubData() method of the WebGL 2 API reads data from a buffer binding point and writes them to an ArrayBuffer or SharedArrayBuffer. |
| `BlitFramebuffer(GLint srcX0, GLint srcY0, GLint srcX1, GLint srcY1, GLint dstX0, GLint dstY0, GLint dstX1, GLint dstY1, GLbitfield mask, GLenum filter)` | `void` | The WebGL2RenderingContext.blitFramebuffer() method of the WebGL 2 API transfers a block of pixels from the read framebuffer to the draw framebuffer. Read and draw framebuffers are bound using WebGLRenderingContext.bindFramebuffer(). |
| `FramebufferTextureLayer(GLenum target, GLenum attachment, WebGLTexture texture, GLint level, GLint layer)` | `void` | The WebGL2RenderingContext.framebufferTextureLayer() method of the WebGL 2 API attaches a single layer of a texture to a framebuffer. This method is similar to WebGLRenderingContext.framebufferTexture2D(), but only a given single layer of the texture level is attached to the attachment point. |
| `InvalidateFramebuffer(GLenum target, GLenum[] attachments)` | `void` | The WebGL2RenderingContext.invalidateFramebuffer() method of the WebGL 2 API invalidates the contents of attachments in a framebuffer. |
| `InvalidateSubFramebuffer(GLenum target, GLenum[] attachments, GLint x, GLint y, GLsizei width, GLsizei height)` | `void` | The WebGL2RenderingContext.invalidateSubFramebuffer() method of the WebGL 2 API invalidates portions of the contents of attachments in a framebuffer. |
| `ReadBuffer(GLenum source)` | `void` | The WebGL2RenderingContext.readBuffer() method of the WebGL 2 API selects a color buffer as the source for pixels for subsequent calls to copyTexImage2D, copyTexSubImage2D, copyTexSubImage3D or readPixels. |
| `GetInternalformatParameter(GLenum target, GLenum internalformat, GLenum pname)` | `Int32Array` | The WebGL2RenderingContext.getInternalformatParameter() method of the WebGL 2 API returns information about implementation-dependent support for internal formats. |
| `GetInternalformatParameter<T>(GLenum target, GLenum internalformat, GLenum pname)` | `T` | The WebGL2RenderingContext.getInternalformatParameter() method of the WebGL 2 API returns information about implementation-dependent support for internal formats. |
| `RenderbufferStorageMultisample(GLenum target, GLsizei samples, GLenum internalFormat, GLsizei width, GLsizei height)` | `void` | The WebGL2RenderingContext.renderbufferStorageMultisample() method of the WebGL 2 API returns creates and initializes a renderbuffer object's data store and allows specifying a number of samples to be used. |
| `TexStorage2D(GLenum target, GLint levels, GLenum internalformat, GLsizei width, GLsizei height)` | `void` | The texStorage2D() method of the WebGL2RenderingContext of the WebGL API specifies all levels of two-dimensional texture storage. |
| `TexStorage3D(GLenum target, GLint levels, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth)` | `void` | The texStorage3D() method of the WebGL2RenderingContext of the WebGL API specifies all levels of three-dimensional texture storage. |
| `TexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, Union<TypedArray, DataView> srcData, GLint srcOffset = 0)` | `void` | The texImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional texture image. |
| `TexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, Union<ImageBitmap, ImageData, HTMLImageElement, HTMLCanvasElement, HTMLVideoElement, OffscreenCanvas, VideoFrame> source)` | `void` | The texImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional texture image. |
| `TexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, GLintptr offset)` | `void` | The texImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional texture image. |
| `TexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, Union<TypedArray, DataView> srcData, GLint srcOffset = 0)` | `void` | The texSubImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional sub-rectangle for a texture image. |
| `TexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, Union<ImageBitmap, ImageData, HTMLImageElement, HTMLCanvasElement, HTMLVideoElement, OffscreenCanvas, VideoFrame> source)` | `void` | The texSubImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional sub-rectangle for a texture image. |
| `TexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, GLint offset)` | `void` | The texSubImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional sub-rectangle for a texture image. |
| `CopyTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height)` | `void` | The copyTexSubImage3D() method of the WebGL2RenderingContext interface of the WebGL API copies pixels from the current WebGLFramebuffer into a 3D texture sub-image. |
| `CompressedTexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, GLintptr offset)` | `void` | The compressedTexImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional texture image in a compressed format. |
| `CompressedTexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, Union<TypedArray, DataView> srcData, GLint srcOffset = 0)` | `void` | The compressedTexImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional texture image in a compressed format. |
| `CompressedTexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, Union<TypedArray, DataView> srcData, GLint srcOffset, GLintptr srcLengthOverride)` | `void` | The compressedTexImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional texture image in a compressed format. |
| `CompressedTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, GLintptr offset)` | `void` | The compressedTexSubImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional sub-rectangle for a texture image in a compressed format. Compressed image formats are only available via some WebGL extension. |
| `CompressedTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, Union<TypedArray, DataView> srcData, GLint srcOffset = 0)` | `void` | The compressedTexSubImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional sub-rectangle for a texture image in a compressed format. Compressed image formats are only available via some WebGL extension. |
| `CompressedTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, Union<TypedArray, DataView> srcData, GLint srcOffset, GLint srcLengthOverride)` | `void` | The compressedTexSubImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional sub-rectangle for a texture image in a compressed format. Compressed image formats are only available via some WebGL extension. |
| `GetFragDataLocation(WebGLProgram program, string name)` | `GLint` | The WebGL2RenderingContext.getFragDataLocation() method of the WebGL 2 API returns the binding of color numbers to user-defined varying out variables. |
| `Uniform1ui(WebGLUniformLocation location, uint v0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform2ui(WebGLUniformLocation location, uint v0, uint v1)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform3ui(WebGLUniformLocation location, uint v0, uint v1, uint v2)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform4ui(WebGLUniformLocation location, uint v0, uint v1, uint v2, uint v3)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform1fv(WebGLUniformLocation location, float[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform1fv(WebGLUniformLocation location, float[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform2fv(WebGLUniformLocation location, float[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform2fv(WebGLUniformLocation location, float[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform3fv(WebGLUniformLocation location, float[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform3fv(WebGLUniformLocation location, float[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform4fv(WebGLUniformLocation location, float[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform4fv(WebGLUniformLocation location, float[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform1fv(WebGLUniformLocation location, Float32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform1fv(WebGLUniformLocation location, Float32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform2fv(WebGLUniformLocation location, Float32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform2fv(WebGLUniformLocation location, Float32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform3fv(WebGLUniformLocation location, Float32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform3fv(WebGLUniformLocation location, Float32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform4fv(WebGLUniformLocation location, Float32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform4fv(WebGLUniformLocation location, Float32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform1iv(WebGLUniformLocation location, int[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform1iv(WebGLUniformLocation location, int[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform2iv(WebGLUniformLocation location, int[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform2iv(WebGLUniformLocation location, int[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform3iv(WebGLUniformLocation location, int[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform3iv(WebGLUniformLocation location, int[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform4iv(WebGLUniformLocation location, int[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform4iv(WebGLUniformLocation location, int[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform1iv(WebGLUniformLocation location, Int32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform1iv(WebGLUniformLocation location, Int32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform2iv(WebGLUniformLocation location, Int32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform2iv(WebGLUniformLocation location, Int32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform3iv(WebGLUniformLocation location, Int32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform3iv(WebGLUniformLocation location, Int32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform4iv(WebGLUniformLocation location, Int32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform4iv(WebGLUniformLocation location, Int32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform1uiv(WebGLUniformLocation location, uint[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform1uiv(WebGLUniformLocation location, uint[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform2uiv(WebGLUniformLocation location, uint[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform2uiv(WebGLUniformLocation location, uint[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform3uiv(WebGLUniformLocation location, uint[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform3uiv(WebGLUniformLocation location, uint[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform4uiv(WebGLUniformLocation location, uint[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform4uiv(WebGLUniformLocation location, uint[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform1uiv(WebGLUniformLocation location, Uint32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform1uiv(WebGLUniformLocation location, Uint32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform2uiv(WebGLUniformLocation location, Uint32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform2uiv(WebGLUniformLocation location, Uint32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform3uiv(WebGLUniformLocation location, Uint32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform3uiv(WebGLUniformLocation location, Uint32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform4uiv(WebGLUniformLocation location, Uint32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform4uiv(WebGLUniformLocation location, Uint32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `UniformMatrix2fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix2fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix3x2fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix3x2fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix4x2fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix4x2fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix2x3fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix2x3fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix3fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix3fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix4x3fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix4x3fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix2x4fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix2x4fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix3x4fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix3x4fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix4fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix4fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix2fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix2fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix3x2fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix3x2fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix4x2fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix4x2fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix2x3fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix2x3fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix3fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix3fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix4x3fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix4x3fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix2x4fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix2x4fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix3x4fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix3x4fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix4fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix4fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `VertexAttribI4i(GLuint index, int v0, int v1, int v2, int v3)` | `void` | The WebGL2RenderingContext.vertexAttribI4[u]i[v]() methods of the WebGL 2 API specify integer values for generic vertex attributes. |
| `VertexAttribI4ui(GLuint index, uint v0, uint v1, uint v2, uint v3)` | `void` | The WebGL2RenderingContext.vertexAttribI4[u]i[v]() methods of the WebGL 2 API specify integer values for generic vertex attributes. |
| `VertexAttribI4iv(GLuint index, Int32Array value)` | `void` | The WebGL2RenderingContext.vertexAttribI4[u]i[v]() methods of the WebGL 2 API specify integer values for generic vertex attributes. |
| `VertexAttribI4iv(GLuint index, int[] value)` | `void` | The WebGL2RenderingContext.vertexAttribI4[u]i[v]() methods of the WebGL 2 API specify integer values for generic vertex attributes. |
| `VertexAttribI4uiv(GLuint index, Uint32Array value)` | `void` | The WebGL2RenderingContext.vertexAttribI4[u]i[v]() methods of the WebGL 2 API specify integer values for generic vertex attributes. |
| `VertexAttribI4uiv(GLuint index, uint[] value)` | `void` | The WebGL2RenderingContext.vertexAttribI4[u]i[v]() methods of the WebGL 2 API specify integer values for generic vertex attributes. |
| `VertexAttribIPointer(GLuint index, GLint size, GLenum type, GLsizei stride, GLintptr offset)` | `void` | The WebGL2RenderingContext.vertexAttribIPointer() method of the WebGL 2 API specifies integer data formats and locations of vertex attributes in a vertex attributes array. |
| `VertexAttribDivisor(GLuint index, GLuint divisor)` | `void` | The WebGL2RenderingContext.vertexAttribDivisor() method of the WebGL 2 API modifies the rate at which generic vertex attributes advance when rendering multiple instances of primitives with gl.drawArraysInstanced() and gl.drawElementsInstanced(). |
| `DrawArraysInstanced(GLenum mode, GLint first, GLsizei count, GLsizei instanceCount)` | `void` | The WebGL2RenderingContext.drawArraysInstanced() method of the WebGL 2 API renders primitives from array data like the gl.drawArrays() method. In addition, it can execute multiple instances of the range of elements. |
| `DrawElementsInstanced(GLenum mode, GLsizei count, GLenum type, GLintptr offset, GLsizei instanceCount)` | `void` | The WebGL2RenderingContext.drawElementsInstanced() method of the WebGL 2 API renders primitives from array data like the gl.drawElements() method. In addition, it can execute multiple instances of a set of elements. |
| `DrawRangeElements(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, GLintptr offset)` | `void` | The WebGL2RenderingContext.drawRangeElements() method of the WebGL API renders primitives from array data in a given range. |
| `DrawBuffers(GLenum[] buffers)` | `void` | The WebGL2RenderingContext.drawBuffers() method of the WebGL 2 API defines draw buffers to which fragment colors are written into. The draw buffer settings are part of the state of the currently bound framebuffer or the drawing buffer if no framebuffer is bound. |
| `ClearBufferfv(GLenum buffer, GLint drawbuffer, float[] values, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.clearBuffer[fiuv]() methods of the WebGL 2 API clear buffers from the currently bound framebuffer. |
| `ClearBufferuiv(GLenum buffer, GLint drawbuffer, uint[] values, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.clearBuffer[fiuv]() methods of the WebGL 2 API clear buffers from the currently bound framebuffer. |
| `ClearBufferiv(GLenum buffer, GLint drawbuffer, int[] values, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.clearBuffer[fiuv]() methods of the WebGL 2 API clear buffers from the currently bound framebuffer. |
| `ClearBufferfv(GLenum buffer, GLint drawbuffer, Float32Array values, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.clearBuffer[fiuv]() methods of the WebGL 2 API clear buffers from the currently bound framebuffer. |
| `ClearBufferuiv(GLenum buffer, GLint drawbuffer, Uint32Array values, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.clearBuffer[fiuv]() methods of the WebGL 2 API clear buffers from the currently bound framebuffer. |
| `ClearBufferiv(GLenum buffer, GLint drawbuffer, Int32Array values, int srcOffset = 0)` | `void` | The WebGL2RenderingContext.clearBuffer[fiuv]() methods of the WebGL 2 API clear buffers from the currently bound framebuffer. |
| `ClearBufferfi(GLenum buffer, GLint drawbuffer, GLfloat depth, GLint stencil)` | `void` | The WebGL2RenderingContext.clearBuffer[fiuv]() methods of the WebGL 2 API clear buffers from the currently bound framebuffer. |
| `BeginQuery(GLenum target, WebGLQuery query)` | `void` | The WebGL2RenderingContext.beginQuery() method of the WebGL 2 API starts an asynchronous query. The target parameter indicates which kind of query to begin. |
| `EndQuery(GLenum target)` | `void` | The WebGL2RenderingContext.endQuery() method of the WebGL 2 API marks the end of a given query target. |
| `IsQuery(WebGLQuery query)` | `bool` | The WebGL2RenderingContext.isQuery() method of the WebGL 2 API returns true if the passed object is a valid WebGLQuery object. |
| `GetQuery(GLenum target, GLenum pname)` | `WebGLQuery` | The WebGL2RenderingContext.getQuery() method of the WebGL 2 API returns the currently active WebGLQuery for the target, or null. |
| `GetQueryParameter<T>(WebGLQuery query, GLenum pname)` | `T` | The WebGL2RenderingContext.getQueryParameter() method of the WebGL 2 API returns parameter information of a WebGLQuery object. |
| `GetQueryParameterAvailable(WebGLQuery query)` | `GLboolean` | Returns true if the query parameter is available. |
| `GetQueryParameterResult(WebGLQuery query)` | `GLuint` | Returns the query result. |
| `BindSampler(GLuint unit, WebGLSampler sampler)` | `void` | The WebGL2RenderingContext.bindSampler() method of the WebGL 2 API binds a passed WebGLSampler object to the texture unit at the passed index. |
| `IsSampler(WebGLSampler sampler)` | `GLboolean` | The WebGL2RenderingContext.isSampler() method of the WebGL 2 API returns true if the passed object is a valid WebGLSampler object. |
| `SamplerParameteri(WebGLSampler sampler, GLenum pname, GLint param)` | `void` | The WebGL2RenderingContext.samplerParameter[if]() methods of the WebGL 2 API set WebGLSampler parameters. |
| `SamplerParameterf(WebGLSampler sampler, GLenum pname, GLfloat param)` | `void` | The WebGL2RenderingContext.samplerParameter[if]() methods of the WebGL 2 API set WebGLSampler parameters. |
| `GetSamplerParameter(WebGLSampler sampler, GLenum pname)` | `float` | The WebGL2RenderingContext.getSamplerParameter() method of the WebGL 2 API returns parameter information of a WebGLSampler object. |
| `FenceSync(GLenum condition, GLbitfield flags)` | `WebGLSync` | The WebGL2RenderingContext.fenceSync() method of the WebGL 2 API creates a new WebGLSync object and inserts it into the GL command stream. |
| `clientWaitSync(WebGLSync sync, GLbitfield flags, GLint64 timeout)` | `GLenum` | The WebGL2RenderingContext.clientWaitSync() method of the WebGL 2 API blocks and waits for a WebGLSync object to become signaled or a given timeout to be passed. |
| `WaitSync(WebGLSync sync, GLbitfield flags, GLint64 timeout)` | `void` | The WebGL2RenderingContext.waitSync() method of the WebGL 2 API returns immediately, but waits on the GL server until the given WebGLSync object is signaled. The method is a no-op in the absence of the possibility of synchronizing between multiple GL contexts. |
| `GetSyncParameter(WebGLSync sync, GLenum pname)` | `uint` | The WebGL2RenderingContext.getSyncParameter() method of the WebGL 2 API returns parameter information of a WebGLSync object. |
| `IsTransformFeedback(WebGLTransformFeedback transformFeedback)` | `bool` | The WebGL2RenderingContext.isTransformFeedback() method of the WebGL 2 API returns true if the passed object is a valid WebGLTransformFeedback object. |
| `BindTransformFeedback(GLenum target, WebGLTransformFeedback? transformFeedback)` | `void` | The WebGL2RenderingContext.bindTransformFeedback() method of the WebGL 2 API binds a passed WebGLTransformFeedback object to the current GL state. |
| `BeginTransformFeedback(GLenum primitiveMode)` | `void` | The WebGL2RenderingContext.beginTransformFeedback() method of the WebGL 2 API starts a transform feedback operation. |
| `TransformFeedbackVaryings(WebGLProgram program, string[] varyings, GLenum bufferMode)` | `void` | The WebGL2RenderingContext.transformFeedbackVaryings() method of the WebGL 2 API specifies values to record in WebGLTransformFeedback buffers. |
| `GetTransformFeedbackVarying(WebGLProgram program, GLuint index)` | `WebGLActiveInfo` | The WebGL2RenderingContext.getTransformFeedbackVarying() method of the WebGL 2 API returns information about varying variables from WebGLTransformFeedback buffers. |
| `PauseTransformFeedback()` | `void` | The WebGL2RenderingContext.pauseTransformFeedback() method of the WebGL 2 API pauses a transform feedback operation. |
| `ResumeTransformFeedback()` | `void` | The WebGL2RenderingContext.resumeTransformFeedback() method of the WebGL 2 API resumes a transform feedback operation. |
| `BindBufferBase(GLenum target, GLuint index, WebGLBuffer buffer)` | `void` | The WebGL2RenderingContext.bindBufferBase() method of the WebGL 2 API binds a given WebGLBuffer to a given binding point (target) at a given index. |
| `BindBufferRange(GLenum target, GLuint index, WebGLBuffer buffer, GLintptr offset, GLsizeiptr size)` | `void` | The WebGL2RenderingContext.bindBufferRange() method of the WebGL 2 API binds a range of a given WebGLBuffer to a given binding point (target) at a given index. |
| `GetUniformIndices(WebGLProgram program, string[] uniformNames)` | `GLuint[]` | The WebGL2RenderingContext.getUniformIndices() method of the WebGL 2 API retrieves the indices of a number of uniforms within a WebGLProgram. |
| `GetActiveUniforms<T>(WebGLProgram program, GLuint[] uniformIndices, GLenum pname)` | `T[]` | The WebGL2RenderingContext.getActiveUniforms() method of the WebGL 2 API retrieves information about active uniforms within a WebGLProgram. |
| `GetActiveUniformBlockParameter<T>(WebGLProgram program, GLuint uniformBlockIndex, GLenum pname)` | `T?` | The WebGL2RenderingContext.getActiveUniformBlockParameter() method of the WebGL 2 API retrieves information about an active uniform block within a WebGLProgram. |
| `GetActiveUniformBlockName(WebGLProgram program, GLuint uniformBlockIndex)` | `string` | The WebGL2RenderingContext.getActiveUniformBlockName() method of the WebGL 2 API retrieves the name of the active uniform block at a given index within a WebGLProgram. |
| `UniformBlockBinding(WebGLProgram program, GLuint uniformBlockIndex, GLuint uniformBlockBinding)` | `void` | The WebGL2RenderingContext.uniformBlockBinding() method of the WebGL 2 API assigns binding points for active uniform blocks. |
| `BindVertexArray(WebGLVertexArrayObject vertexArray)` | `void` | The WebGL2RenderingContext.bindVertexArray() method of the WebGL 2 API binds a passed WebGLVertexArrayObject object to the buffer. |

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
