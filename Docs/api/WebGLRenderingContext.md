# WebGLRenderingContext

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `WebGLRenderingContextBase` -> `WebGLRenderingContext`  
**MDN Reference:** [WebGLRenderingContext](https://developer.mozilla.org/en-US/docs/Web/API/WebGLRenderingContext)

> The `WebGLRenderingContext` class provides the WebGL 1.0 rendering context (OpenGL ES 2.0). It is obtained from an `HTMLCanvasElement` or `OffscreenCanvas` via `getContext("webgl")`. SpawnDev.BlazorJS provides the full WebGL 1.0 API surface through `WebGLRenderingContextBase`, which contains all methods shared between WebGL 1.0 and 2.0. All WebGL constants are accessible via the static `WebGLConstants` class.

## Constructors

| Signature | Description |
|-----------|-------------|
| `WebGLRenderingContext(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Key Methods (from WebGLRenderingContextBase)

### Shader Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateShader(int type)` | `WebGLShader` | Creates a shader. Use `WebGLConstants.VERTEX_SHADER` or `FRAGMENT_SHADER`. |
| `ShaderSource(WebGLShader shader, string source)` | `void` | Sets the GLSL source code for a shader. |
| `CompileShader(WebGLShader shader)` | `void` | Compiles the shader source. |
| `GetShaderParameter(WebGLShader shader, int pname)` | `T` | Gets shader compile status. Use `WebGLConstants.COMPILE_STATUS`. |
| `GetShaderInfoLog(WebGLShader shader)` | `string?` | Returns the shader compilation log (error messages). |
| `DeleteShader(WebGLShader shader)` | `void` | Deletes a shader object. |

### Program Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateProgram()` | `WebGLProgram` | Creates a shader program. |
| `AttachShader(WebGLProgram program, WebGLShader shader)` | `void` | Attaches a shader to a program. |
| `LinkProgram(WebGLProgram program)` | `void` | Links the program (after attaching both shaders). |
| `UseProgram(WebGLProgram? program)` | `void` | Sets the active shader program. |
| `GetProgramParameter<T>(WebGLProgram program, int pname)` | `T` | Gets link status. Use `WebGLConstants.LINK_STATUS`. |
| `GetProgramInfoLog(WebGLProgram program)` | `string?` | Returns the program link log. |
| `DeleteProgram(WebGLProgram program)` | `void` | Deletes a program. |

### Buffer Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateBuffer()` | `WebGLBuffer` | Creates a buffer object. |
| `BindBuffer(int target, WebGLBuffer? buffer)` | `void` | Binds a buffer. Target: `ARRAY_BUFFER`, `ELEMENT_ARRAY_BUFFER`. |
| `BufferData(int target, TypedArray data, int usage)` | `void` | Uploads data to the bound buffer. Usage: `STATIC_DRAW`, `DYNAMIC_DRAW`, `STREAM_DRAW`. |
| `BufferData(int target, long size, int usage)` | `void` | Allocates buffer storage. |
| `BufferData(int target, ArrayBuffer data, int usage)` | `void` | Uploads ArrayBuffer data. |
| `BufferSubData(int target, long offset, TypedArray data)` | `void` | Updates a portion of the buffer. |
| `DeleteBuffer(WebGLBuffer buffer)` | `void` | Deletes a buffer. |

### Texture Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateTexture()` | `WebGLTexture` | Creates a texture object. |
| `BindTexture(int target, WebGLTexture? texture)` | `void` | Binds a texture. Target: `TEXTURE_2D`, `TEXTURE_CUBE_MAP`. |
| `TexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, TypedArray? pixels)` | `void` | Specifies a 2D texture image. |
| `TexParameteri(int target, int pname, int param)` | `void` | Sets texture parameters (filtering, wrapping). |
| `GenerateMipmap(int target)` | `void` | Generates mipmaps for the bound texture. |
| `ActiveTexture(int texture)` | `void` | Selects the active texture unit. |
| `DeleteTexture(WebGLTexture texture)` | `void` | Deletes a texture. |

### Vertex Attribute Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `GetAttribLocation(WebGLProgram program, string name)` | `int` | Returns the location of an attribute variable. |
| `VertexAttribPointer(int index, int size, int type, bool normalized, int stride, long offset)` | `void` | Specifies the layout of vertex attribute data. |
| `EnableVertexAttribArray(int index)` | `void` | Enables a vertex attribute array. |
| `DisableVertexAttribArray(int index)` | `void` | Disables a vertex attribute array. |

### Uniform Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `GetUniformLocation(WebGLProgram program, string name)` | `WebGLUniformLocation` | Returns the location of a uniform variable. |
| `Uniform1f(WebGLUniformLocation location, float v0)` | `void` | Sets a float uniform. |
| `Uniform1i(WebGLUniformLocation location, int v0)` | `void` | Sets an integer uniform. |
| `Uniform2f(WebGLUniformLocation loc, float v0, float v1)` | `void` | Sets a vec2 uniform. |
| `Uniform3f(WebGLUniformLocation loc, float v0, float v1, float v2)` | `void` | Sets a vec3 uniform. |
| `Uniform4f(WebGLUniformLocation loc, float v0, float v1, float v2, float v3)` | `void` | Sets a vec4 uniform. |
| `UniformMatrix4fv(WebGLUniformLocation location, bool transpose, Float32Array value)` | `void` | Sets a 4x4 matrix uniform. |

### Drawing Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `DrawArrays(int mode, int first, int count)` | `void` | Draws primitives from array data. Mode: `TRIANGLES`, `LINES`, `POINTS`, etc. |
| `DrawElements(int mode, int count, int type, long offset)` | `void` | Draws indexed primitives. |

### State Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Clear(int mask)` | `void` | Clears buffers. Mask: `COLOR_BUFFER_BIT`, `DEPTH_BUFFER_BIT`, `STENCIL_BUFFER_BIT`. |
| `ClearColor(float red, float green, float blue, float alpha)` | `void` | Sets the clear color. |
| `ClearDepth(float depth)` | `void` | Sets the clear depth value. |
| `Viewport(int x, int y, int width, int height)` | `void` | Sets the viewport. |
| `Enable(int cap)` | `void` | Enables a capability (e.g., `DEPTH_TEST`, `BLEND`, `CULL_FACE`). |
| `Disable(int cap)` | `void` | Disables a capability. |
| `BlendFunc(int sfactor, int dfactor)` | `void` | Sets the blending function. |
| `DepthFunc(int func)` | `void` | Sets the depth comparison function. |
| `Scissor(int x, int y, int width, int height)` | `void` | Sets the scissor rectangle. |

### Framebuffer Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateFramebuffer()` | `WebGLFramebuffer` | Creates a framebuffer. |
| `BindFramebuffer(int target, WebGLFramebuffer? framebuffer)` | `void` | Binds a framebuffer. |
| `FramebufferTexture2D(int target, int attachment, int textarget, WebGLTexture texture, int level)` | `void` | Attaches a texture to a framebuffer. |
| `DeleteFramebuffer(WebGLFramebuffer framebuffer)` | `void` | Deletes a framebuffer. |

### Other Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Flush()` | `void` | Flushes the GL command queue. |
| `Finish()` | `void` | Blocks until all GL commands are complete. |
| `GetError()` | `int` | Returns the current error code. |
| `ReadPixels(int x, int y, int width, int height, int format, int type, TypedArray pixels)` | `void` | Reads pixel data from the framebuffer. |
| `GetExtension(string name)` | `JSObject?` | Returns a WebGL extension, or `null`. |
| `GetParameter<T>(int pname)` | `T` | Returns a GL parameter value. |

## WebGLConstants

All WebGL constants are available as static fields on `WebGLConstants`:

```csharp
WebGLConstants.VERTEX_SHADER         // 35633
WebGLConstants.FRAGMENT_SHADER       // 35632
WebGLConstants.ARRAY_BUFFER          // 34962
WebGLConstants.ELEMENT_ARRAY_BUFFER  // 34963
WebGLConstants.STATIC_DRAW           // 35044
WebGLConstants.TRIANGLES             // 4
WebGLConstants.TEXTURE_2D            // 3553
WebGLConstants.COLOR_BUFFER_BIT      // 16384
WebGLConstants.DEPTH_BUFFER_BIT      // 256
// ... and many more
```

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Canvas` | `HTMLCanvasElement` | get | Returns the canvas element that the drawing context is bound to. This may be an HTMLCanvasElement or an OffscreenCanvas, depending on how the context was created. |
| `DrawingBufferHeight` | `int` | get | The read-only height of the current drawing buffer. Should match the height of the canvas element associated with this context. |
| `DrawingBufferWidth` | `int` | get | The read-only width of the current drawing buffer. Should match the width of the canvas element associated with this context. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ActiveTexture(GLenum texture)` | `void` | Selects the active texture unit. Subsequent calls that modify the texture state will affect this texture. |
| `BindAttribLocation(WebGLProgram program, uint index, string name)` | `void` | Binds a generic vertex index to a named attribute variable. |
| `BindBuffer(GLenum target, WebGLBuffer buffer)` | `void` | The WebGLRenderingContext.bindBuffer() method of the WebGL API binds a given WebGLBuffer to a target. |
| `BindFramebuffer(GLenum target, WebGLFramebuffer? framebuffer)` | `void` | The WebGLRenderingContext.bindFramebuffer() method of the WebGL API binds to the specified target the provided WebGLFramebuffer, or, if the framebuffer argument is null, the default WebGLFramebuffer, which is associated with the canvas rendering context. |
| `BindRenderbuffer(GLenum target, WebGLRenderbuffer renderbuffer)` | `void` | The WebGLRenderingContext.bindRenderbuffer() method of the WebGL API binds a given WebGLRenderbuffer to a target, which must be gl.RENDERBUFFER. |
| `BindTexture(GLenum target, WebGLTexture texture)` | `void` | The WebGLRenderingContext.bindTexture() method of the WebGL API binds a given WebGLTexture to a target (binding point). |
| `BlendColor(float red = 0, float green = 0, float blue = 0, float alpha = 0)` | `void` | The WebGLRenderingContext.blendColor() method of the WebGL API is used to set the source and destination blending factors. |
| `BlendEquation(GLenum mode)` | `void` | The WebGLRenderingContext.blendEquation() method of the WebGL API is used to set both the RGB blend equation and alpha blend equation to a single equation. The blend equation determines how a new pixel is combined with a pixel already in the WebGLFramebuffer. |
| `BlendEquationSeparate(GLenum modeRGB, GLenum modeAlpha)` | `void` | The WebGLRenderingContext.blendEquationSeparate() method of the WebGL API is used to set the RGB blend equation and alpha blend equation separately. The blend equation determines how a new pixel is combined with a pixel already in the WebGLFramebuffer. |
| `BlendFunc(GLenum sfactor, GLenum dfactor)` | `void` | The WebGLRenderingContext.blendFunc() method of the WebGL API defines which function is used for blending pixel arithmetic. |
| `BlendFuncSeparate(GLenum srcRGB, GLenum dstRGB, GLenum srcAlpha, GLenum dstAlpha)` | `void` | The WebGLRenderingContext.blendFuncSeparate() method of the WebGL API defines which function is used for blending pixel arithmetic for RGB and alpha components separately. |
| `BufferData(GLenum target, GLsizeiptr size, GLenum usage)` | `void` | The WebGLRenderingContext.bufferData() method of the WebGL API initializes and creates the buffer object's data store. |
| `BufferData(GLenum target, ArrayBuffer srcData, GLenum usage)` | `void` | The WebGLRenderingContext.bufferData() method of the WebGL API initializes and creates the buffer object's data store. |
| `BufferData(GLenum target, SharedArrayBuffer srcData, GLenum usage)` | `void` | The WebGLRenderingContext.bufferData() method of the WebGL API initializes and creates the buffer object's data store. |
| `BufferData(GLenum target, TypedArray srcData, GLenum usage)` | `void` | The WebGLRenderingContext.bufferData() method of the WebGL API initializes and creates the buffer object's data store. |
| `BufferData(GLenum target, byte[] srcData, GLenum usage)` | `void` | The WebGLRenderingContext.bufferData() method of the WebGL API initializes and creates the buffer object's data store. |
| `BufferData(GLenum target, DataView srcData, GLenum usage)` | `void` | The WebGLRenderingContext.bufferData() method of the WebGL API initializes and creates the buffer object's data store. |
| `BufferSubData(GLenum target, long offset)` | `void` | The WebGLRenderingContext.bufferSubData() method of the WebGL API updates a subset of a buffer object's data store. |
| `BufferSubData(GLenum target, long offset, ArrayBuffer srcData)` | `void` | The WebGLRenderingContext.bufferSubData() method of the WebGL API updates a subset of a buffer object's data store. |
| `BufferSubData(GLenum target, long offset, SharedArrayBuffer srcData)` | `void` | The WebGLRenderingContext.bufferSubData() method of the WebGL API updates a subset of a buffer object's data store. |
| `BufferSubData(GLenum target, long offset, DataView srcData)` | `void` | The WebGLRenderingContext.bufferSubData() method of the WebGL API updates a subset of a buffer object's data store. |
| `BufferSubData(GLenum target, long offset, TypedArray srcData)` | `void` | The WebGLRenderingContext.bufferSubData() method of the WebGL API updates a subset of a buffer object's data store. |
| `BufferSubData(GLenum target, long offset, byte[] srcData)` | `void` | The WebGLRenderingContext.bufferSubData() method of the WebGL API updates a subset of a buffer object's data store. |
| `CheckFramebufferStatus(GLenum target)` | `GLenum` | The WebGLRenderingContext.checkFramebufferStatus() method of the WebGL API returns the completeness status of the WebGLFramebuffer object. |
| `Clear(GLbitfield mask)` | `void` | The WebGLRenderingContext.clear() method of the WebGL API clears buffers to preset values. The preset values can be set by clearColor(), clearDepth() or clearStencil(). The scissor box, dithering, and buffer writemasks can affect the clear() method. |
| `ClearStencil(int s = 0)` | `void` | The WebGLRenderingContext.clearStencil() method of the WebGL API specifies the clear value for the stencil buffer. This specifies what stencil value to use when calling the clear() method. |
| `ColorMask(bool red = true, bool green = true, bool blue = true, bool alpha = true)` | `void` | The WebGLRenderingContext.colorMask() method of the WebGL API sets which color components to enable or to disable when drawing or rendering to a WebGLFramebuffer. |
| `CompressedTexImage2D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, TypedArray pixels)` | `void` | The compressedTexImage2D() method of the WebGLRenderingContext interface of the WebGL API specifies a two-dimensional texture image in a compressed format. Compressed image formats must be enabled by WebGL extensions before using these methods. |
| `CompressedTexImage2D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border)` | `void` | The compressedTexImage2D() method of the WebGLRenderingContext interface of the WebGL API specifies a two-dimensional texture image in a compressed format. Compressed image formats must be enabled by WebGL extensions before using these methods. |
| `CompressedTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, TypedArray data)` | `void` | The WebGLRenderingContext.compressedTexSubImage2D() method of the WebGL API specifies a two-dimensional sub-rectangle for a texture image in a compressed format. Compressed image formats must be enabled by WebGL extensions before using this method or a WebGL2RenderingContext must be used. |
| `CompressedTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, byte[] data)` | `void` | The WebGLRenderingContext.compressedTexSubImage2D() method of the WebGL API specifies a two-dimensional sub-rectangle for a texture image in a compressed format. Compressed image formats must be enabled by WebGL extensions before using this method or a WebGL2RenderingContext must be used. |
| `CopyTexImage2D(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height, GLint border)` | `void` | The WebGLRenderingContext.copyTexImage2D() method of the WebGL API copies pixels from the current WebGLFramebuffer into a 2D texture image. |
| `CopyTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height)` | `void` | The WebGLRenderingContext.copyTexSubImage2D() method of the WebGL API copies pixels from the current WebGLFramebuffer into an existing 2D texture sub-image. |
| `CreateRenderbuffer()` | `WebGLRenderbuffer` | The WebGLRenderingContext.createRenderbuffer() method of the WebGL API creates and initializes a WebGLRenderbuffer object. |
| `CreateShader(GLenum type)` | `WebGLShader` | The WebGLRenderingContext method createShader() of the WebGL API creates a WebGLShader that can then be configured further using WebGLRenderingContext.shaderSource() and WebGLRenderingContext.compileShader(). |
| `CullFace(GLenum mode = 0x0405)` | `void` | The WebGLRenderingContext.cullFace() method of the WebGL API specifies whether or not front- and/or back-facing polygons can be culled. |
| `DeleteRenderbuffer(WebGLRenderbuffer renderbuffer)` | `void` | The WebGLRenderingContext.deleteRenderbuffer() method of the WebGL API deletes a given WebGLRenderbuffer object. This method has no effect if the render buffer has already been deleted. |
| `DepthFunc(GLenum func = 0x0201)` | `void` | The WebGLRenderingContext.depthFunc() method of the WebGL API specifies a function that compares incoming pixel depth to the current depth buffer value. |
| `DepthMask(bool flag = true)` | `void` | The WebGLRenderingContext.depthMask() method of the WebGL API sets whether writing into the depth buffer is enabled or disabled. |
| `DepthRange(float zNear = 0, float zFar = 1)` | `void` | The WebGLRenderingContext.depthRange() method of the WebGL API specifies the depth range mapping from normalized device coordinates to window or viewport coordinates. |
| `DetachShader(WebGLProgram program, WebGLShader shader)` | `void` | The WebGLRenderingContext.detachShader() method of the WebGL API detaches a previously attached WebGLShader from a WebGLProgram. |
| `Disable(GLenum cap)` | `void` | The WebGLRenderingContext.disable() method of the WebGL API disables specific WebGL capabilities for this context. |
| `DisableVertexAttribArray(GLuint index)` | `void` | The WebGLRenderingContext.disableVertexAttribArray() method of the WebGL API turns the generic vertex attribute array off at a given index position. |
| `DrawArrays(GLenum mode, GLint first, GLsizei count)` | `void` | The WebGLRenderingContext.drawArrays() method of the WebGL API renders primitives from array data. |
| `DrawElements(GLenum mode, GLsizei count, GLenum type, GLintptr offset)` | `void` | The WebGLRenderingContext.drawElements() method of the WebGL API renders primitives from array data. |
| `Enable(GLenum cap)` | `void` | The WebGLRenderingContext.enable() method of the WebGL API enables specific WebGL capabilities for this context. |
| `EnableVertexAttribArray(GLuint index)` | `void` | The WebGLRenderingContext.disableVertexAttribArray() method of the WebGL API turns the generic vertex attribute array off at a given index position. |
| `FramebufferRenderbuffer(GLenum target, GLenum attachment, GLenum renderbuffertarget, WebGLRenderbuffer renderbuffer)` | `void` | The WebGLRenderingContext.framebufferRenderbuffer() method of the WebGL API attaches a WebGLRenderbuffer object to a WebGLFramebuffer object. |
| `FramebufferTexture2D(GLenum target, GLenum attachment, GLenum textarget, WebGLTexture texture, GLint level)` | `void` | The WebGLRenderingContext.framebufferTexture2D() method of the WebGL API attaches a texture to a WebGLFramebuffer. |
| `FrontFace(GLenum mode = 0x0901)` | `void` | The WebGLRenderingContext.frontFace() method of the WebGL API specifies whether polygons are front- or back-facing by setting a winding orientation. |
| `GenerateMipmap(GLenum target)` | `void` | The WebGLRenderingContext.generateMipmap() method of the WebGL API generates a set of mipmaps for a WebGLTexture object. Mipmaps are used to create distance with objects. A higher-resolution mipmap is used for objects that are closer, and a lower-resolution mipmap is used for objects that are farther away. It starts with the resolution of the texture image and halves the resolution until a 1x1 dimension texture image is created. |
| `GetActiveAttrib(WebGLProgram program, uint index)` | `WebGLActiveInfo` | The WebGLRenderingContext.getActiveAttrib() method of the WebGL API returns a WebGLActiveInfo object containing size, type, and name of a vertex attribute. It is generally used when querying unknown attributes either for debugging or generic library creation. |
| `GetActiveUniform(WebGLProgram program, uint index)` | `WebGLActiveInfo` | The WebGLRenderingContext.getActiveUniform() method of the WebGL API returns a WebGLActiveInfo object containing size, type, and name of a uniform attribute. It is generally used when querying unknown uniforms either for debugging or generic library creation. |
| `GetAttachedShaders(WebGLProgram program)` | `WebGLShader[]` | The WebGLRenderingContext.getAttachedShaders() method of the WebGL API returns a list of WebGLShader objects attached to a WebGLProgram. |
| `GetBufferParameter<T>(GLenum target, GLenum pname)` | `T` | The WebGLRenderingContext.getBufferParameter() method of the WebGL API returns information about the buffer. |
| `GetBufferParameter(GLenum target, GLenum pname)` | `GLint` | The WebGLRenderingContext.getBufferParameter() method of the WebGL API returns information about the buffer. |
| `GetContextAttributes()` | `WebGLContextAttributes` | The WebGLRenderingContext.getContextAttributes() method returns a WebGLContextAttributes object that contains the actual context parameters. Might return null, if the context is lost. |
| `GetFramebufferAttachmentParameter<T>(GLenum target, GLenum attachment, GLenum pname)` | `T` | The WebGLRenderingContext.getFramebufferAttachmentParameter() method of the WebGL API returns information about a framebuffer's attachment. |
| `GetParameter<T>(GLenum pname)` | `T` | The WebGLRenderingContext.getParameter() method of the WebGL API returns a value for the passed parameter name. |
| `GetProgramParameter<T>(WebGLProgram program, GLenum pname)` | `T` | The WebGLRenderingContext.getProgramParameter() method of the WebGL API returns information about the given program. |
| `GetRenderbufferParameter<T>(GLenum target, GLenum pname)` | `T` | The WebGLRenderingContext.getRenderbufferParameter() method of the WebGL API returns information about the renderbuffer. |
| `GetShaderParameter<T>(WebGLShader shader, GLenum pname)` | `T` | The WebGLRenderingContext.getShaderParameter() method of the WebGL API returns information about the given shader. |
| `GetShaderPrecisionFormat(GLenum shadertype, GLenum precisiontype)` | `WebGLShaderPrecisionFormat?` | The WebGLRenderingContext.getShaderPrecisionFormat() method of the WebGL API returns a new WebGLShaderPrecisionFormat object describing the range and precision for the specified shader numeric format. |
| `GetShaderSource(WebGLShader shader)` | `string` | The WebGLRenderingContext.getShaderSource() method of the WebGL API returns the source code of a WebGLShader as a string. |
| `GetSupportedExtensions()` | `string[]` | The WebGLRenderingContext.getSupportedExtensions() method returns a list of all the supported WebGL extensions. |
| `GetTexParameter<T>(GLenum target, GLenum pname)` | `T` | The WebGLRenderingContext.getTexParameter() method of the WebGL API returns information about the given texture. |
| `GetUniform<T>(WebGLProgram program, WebGLUniformLocation location)` | `T` | The WebGLRenderingContext.getUniform() method of the WebGL API returns the value of a uniform variable at a given location. |
| `GetVertexAttrib<T>(GLuint index, GLenum pname)` | `T` | The WebGLRenderingContext.getVertexAttrib() method of the WebGL API returns information about a vertex attribute at a given position. |
| `GetVertexAttribOffset(GLuint index, GLenum pname)` | `GLintptr` | The WebGLRenderingContext.getVertexAttribOffset() method of the WebGL API returns the address of a specified vertex attribute. |
| `Hint(GLenum target, GLenum mode)` | `void` | The WebGLRenderingContext.hint() method of the WebGL API specifies hints for certain behaviors. The interpretation of these hints depend on the implementation. |
| `IsBuffer(WebGLBuffer buffer)` | `bool` | The WebGLRenderingContext.isBuffer() method of the WebGL API returns true if the passed WebGLBuffer is valid and false otherwise. |
| `IsContextLost()` | `bool` | The WebGLRenderingContext.isContextLost() method returns a boolean value indicating whether or not the WebGL context has been lost and must be re-established before rendering can resume. |
| `IsEnabled(GLenum cap)` | `bool` | The WebGLRenderingContext.isEnabled() method of the WebGL API tests whether a specific WebGL capability is enabled or not for this context. |
| `IsFramebuffer(WebGLFramebuffer framebuffer)` | `bool` | The WebGLRenderingContext.isFramebuffer() method of the WebGL API returns true if the passed WebGLFramebuffer is valid and false otherwise. |
| `IsProgram(WebGLProgram program)` | `bool` | The WebGLRenderingContext.isProgram() method of the WebGL API returns true if the passed WebGLProgram is valid, false otherwise. |
| `IsRenderbuffer(WebGLRenderbuffer renderbuffer)` | `bool` | The WebGLRenderingContext.isRenderbuffer() method of the WebGL API returns true if the passed WebGLRenderbuffer is valid and false otherwise. |
| `IsShader(WebGLShader shader)` | `bool` | The WebGLRenderingContext.isShader() method of the WebGL API returns true if the passed WebGLShader is valid, false otherwise. |
| `IsTexture(WebGLTexture texture)` | `bool` | The WebGLRenderingContext.isTexture() method of the WebGL API returns true if the passed WebGLTexture is valid and false otherwise. |
| `LineWidth(float width)` | `void` | The WebGLRenderingContext.lineWidth() method of the WebGL API sets the line width of rasterized lines. |
| `MakeXRCompatible()` | `Task` | The WebGLRenderingContext method makeXRCompatible() ensures that the rendering context described by the WebGLRenderingContext is ready to render the scene for the immersive WebXR device on which it will be displayed. If necessary, the WebGL layer may reconfigure the context to be ready to render to a different device than it originally was. This is useful if you have an application which can start out being presented on a standard 2D display but can then be transitioned to a 3D immersion system. |
| `PixelStorei(GLenum pname, GLint param)` | `void` | The WebGLRenderingContext.pixelStorei() method of the WebGL API specifies the pixel storage modes. |
| `PolygonOffset(float factor = 0, float units = 0)` | `void` | The WebGLRenderingContext.polygonOffset() method of the WebGL API specifies the scale factors and units to calculate depth values. The offset is added before the depth test is performed and before the value is written into the depth buffer. |
| `ReadPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, Uint8Array pixels)` | `void` | The WebGLRenderingContext.readPixels() method of the WebGL API reads a block of pixels from a specified rectangle of the current color framebuffer into a TypedArray or a DataView object. |
| `ReadPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, Uint16Array pixels)` | `void` | The WebGLRenderingContext.readPixels() method of the WebGL API reads a block of pixels from a specified rectangle of the current color framebuffer into a Uint16Array. https://developer.mozilla.org/en-US/docs/Web/API/WebGLRenderingContext/readPixels |
| `ReadPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, Float32Array pixels)` | `void` | The WebGLRenderingContext.readPixels() method of the WebGL API reads a block of pixels from a specified rectangle of the current color framebuffer into a Float32Array. https://developer.mozilla.org/en-US/docs/Web/API/WebGLRenderingContext/readPixels |
| `ReadPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, TypedArray pixels)` | `void` | The WebGLRenderingContext.readPixels() method of the WebGL API reads a block of pixels from a specified rectangle of the current color framebuffer into a TypedArray. https://developer.mozilla.org/en-US/docs/Web/API/WebGLRenderingContext/readPixels |
| `RenderbufferStorage(GLenum target, GLenum internalformat, GLsizei width, GLsizei height)` | `void` | The WebGLRenderingContext.renderbufferStorage() method of the WebGL API creates and initializes a renderbuffer object's data store. |
| `SampleCoverage(float value = 1, bool invert = false)` | `void` | The WebGLRenderingContext.sampleCoverage() method of the WebGL API specifies multi-sample coverage parameters for anti-aliasing effects. |
| `StencilFunc(GLenum func = 0x0207, GLint refValue = 0, GLuint mask = 1)` | `void` | The WebGLRenderingContext.stencilFunc() method of the WebGL API sets the front and back function and reference value for stencil testing. Stenciling enables and disables drawing on a per-pixel basis. It is typically used in multipass rendering to achieve special effects. |
| `StencilFuncSeparate(GLenum face, GLenum func = 0x0207, GLint refValue = 0, GLuint mask = 1)` | `void` | The WebGLRenderingContext.stencilFuncSeparate() method of the WebGL API sets the front and/or back function and reference value for stencil testing. Stencilling enables and disables drawing on a per-pixel basis. It is typically used in multipass rendering to achieve special effects. |
| `StencilMask(uint mask = 1)` | `void` | The WebGLRenderingContext.stencilMask() method of the WebGL API controls enabling and disabling of both the front and back writing of individual bits in the stencil planes. The WebGLRenderingContext.stencilMaskSeparate() method can set front and back stencil writemasks to different values. |
| `StencilMaskSeparate(GLenum face, GLuint mask = 1)` | `void` | The WebGLRenderingContext.stencilMaskSeparate() method of the WebGL API controls enabling and disabling of front and/or back writing of individual bits in the stencil planes. The WebGLRenderingContext.stencilMask() method can set both, the front and back stencil writemasks to one value at the same time. |
| `StencilOp(GLenum fail = 0x1E00, GLenum zfail = 0x1E00, GLenum zpass = 0x1E00)` | `void` | The WebGLRenderingContext.stencilOp() method of the WebGL API sets both the front and back-facing stencil test actions. |
| `StencilOpSeparate(GLenum face, GLenum fail, GLenum zfail, GLenum zpass)` | `void` | The WebGLRenderingContext.stencilOpSeparate() method of the WebGL API sets the front and/or back-facing stencil test actions. |
| `TexImage2D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, byte[] pixels)` | `void` | The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image. |
| `TexImage2D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, Uint8Array pixels)` | `void` | The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image. |
| `TexImage2D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, Uint16Array pixels)` | `void` | The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image. |
| `TexImage2D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, Uint32Array pixels)` | `void` | The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image. |
| `TexImage2D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, Float32Array pixels)` | `void` | The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image. |
| `TexImage2D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, TypedArray pixels)` | `void` | The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image. https://developer.mozilla.org/en-US/docs/Web/API/WebGLRenderingContext/texImage2D |
| `TexImage2D(GLenum target, GLint level, GLenum internalformat, GLenum format, GLenum type, ImageData source)` | `void` | The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image. |
| `TexImage2D(GLenum target, GLint level, GLenum internalformat, GLenum format, GLenum type, ImageBitmap source)` | `void` | The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image. |
| `TexImage2D(GLenum target, GLint level, GLenum internalformat, GLenum format, GLenum type, HTMLImageElement source)` | `void` | The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image. |
| `TexImage2D(GLenum target, GLint level, GLenum internalformat, GLenum format, GLenum type, HTMLCanvasElement source)` | `void` | The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image. |
| `TexImage2D(GLenum target, GLint level, GLenum internalformat, GLenum format, GLenum type, OffscreenCanvas source)` | `void` | The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image. |
| `TexImage2D(GLenum target, GLint level, GLenum internalformat, GLenum format, GLenum type, HTMLVideoElement source)` | `void` | The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image. |
| `TexParameterf(GLenum target, GLenum pname, GLfloat param)` | `void` | The WebGLRenderingContext.texParameter[fi]() methods of the WebGL API set texture parameters. |
| `TexParameterf(GLenum target, GLenum pname, GLenum param)` | `void` | The WebGLRenderingContext.texParameterf() method of the WebGL API sets texture parameters. Overload accepting a GLenum value for the param parameter. https://developer.mozilla.org/en-US/docs/Web/API/WebGLRenderingContext/texParameter |
| `TexParameteri(GLenum target, GLenum pname, GLint param)` | `void` | The WebGLRenderingContext.texParameter[fi]() methods of the WebGL API set texture parameters. |
| `TexParameteri(GLenum target, GLenum pname, GLenum param)` | `void` | The WebGLRenderingContext.texParameter[fi]() methods of the WebGL API set texture parameters. |
| `TexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, byte[] pixels)` | `void` | The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture. |
| `TexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, Uint8Array pixels)` | `void` | The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture. |
| `TexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, Uint16Array pixels)` | `void` | The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture. |
| `TexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, Uint32Array pixels)` | `void` | The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture. |
| `TexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, Float32Array pixels)` | `void` | The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture. |
| `TexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, TypedArray pixels)` | `void` | The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture. https://developer.mozilla.org/en-US/docs/Web/API/WebGLRenderingContext/texSubImage2D |
| `TexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLenum format, GLenum type, ImageData source)` | `void` | The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture. |
| `TexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLenum format, GLenum type, ImageBitmap source)` | `void` | The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture. |
| `TexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLenum format, GLenum type, HTMLImageElement source)` | `void` | The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture. |
| `TexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLenum format, GLenum type, HTMLCanvasElement source)` | `void` | The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture. |
| `TexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLenum format, GLenum type, OffscreenCanvas source)` | `void` | The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture. |
| `TexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLenum format, GLenum type, HTMLVideoElement source)` | `void` | The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture. |
| `Uniform1fv(WebGLUniformLocation location, IEnumerable<float> v)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform1iv(WebGLUniformLocation location, IEnumerable<int> v)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform2fv(WebGLUniformLocation location, IEnumerable<float> v)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform2i(WebGLUniformLocation location, int x, int y)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform2iv(WebGLUniformLocation location, IEnumerable<int> v)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform3fv(WebGLUniformLocation location, IEnumerable<float> v)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform3i(WebGLUniformLocation location, int x, int y, int z)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform3iv(WebGLUniformLocation location, IEnumerable<int> v)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform4fv(WebGLUniformLocation location, IEnumerable<float> v)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform4i(WebGLUniformLocation location, int x, int y, int z, int w)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `Uniform4iv(WebGLUniformLocation location, IEnumerable<int> v)` | `void` | The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables. |
| `UniformMatrix2fv(WebGLUniformLocation location, bool transpose, IEnumerable<float> value)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix3fv(WebGLUniformLocation location, bool transpose, IEnumerable<float> value)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UniformMatrix4fv(WebGLUniformLocation location, bool transpose, IEnumerable<float> value)` | `void` | The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables. |
| `UseProgram(WebGLProgram program)` | `void` | The WebGLRenderingContext.useProgram() method of the WebGL API sets the specified WebGLProgram as part of the current rendering state. |
| `ValidateProgram(WebGLProgram program)` | `void` | The WebGLRenderingContext.validateProgram() method of the WebGL API validates a WebGLProgram. It checks if it is successfully linked and if it can be used in the current WebGL state. |
| `VertexAttrib1f(uint index, float x)` | `void` | The WebGLRenderingContext.vertexAttrib[1234]f[v]() methods of the WebGL API specify constant values for generic vertex attributes. |
| `VertexAttrib1fv(uint index, IEnumerable<float> values)` | `void` | The WebGLRenderingContext.vertexAttrib[1234]f[v]() methods of the WebGL API specify constant values for generic vertex attributes. |
| `VertexAttrib2f(uint index, float x, float y)` | `void` | The WebGLRenderingContext.vertexAttrib[1234]f[v]() methods of the WebGL API specify constant values for generic vertex attributes. |
| `VertexAttrib2fv(uint index, IEnumerable<float> values)` | `void` | The WebGLRenderingContext.vertexAttrib[1234]f[v]() methods of the WebGL API specify constant values for generic vertex attributes. |
| `VertexAttrib3f(uint index, float x, float y, float z)` | `void` | The WebGLRenderingContext.vertexAttrib[1234]f[v]() methods of the WebGL API specify constant values for generic vertex attributes. |
| `VertexAttrib3fv(uint index, IEnumerable<float> values)` | `void` | The WebGLRenderingContext.vertexAttrib[1234]f[v]() methods of the WebGL API specify constant values for generic vertex attributes. |
| `VertexAttrib4f(uint index, float x, float y, float z, float w)` | `void` | The WebGLRenderingContext.vertexAttrib[1234]f[v]() methods of the WebGL API specify constant values for generic vertex attributes. |
| `VertexAttrib4fv(uint index, IEnumerable<float> values)` | `void` | The WebGLRenderingContext.vertexAttrib[1234]f[v]() methods of the WebGL API specify constant values for generic vertex attributes. |
| `VertexAttribPointer(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, GLintptr offset)` | `void` | The WebGLRenderingContext.vertexAttribPointer() method of the WebGL API binds the buffer currently bound to the gl.ARRAY_BUFFER target to a generic vertex attribute of the current vertex buffer object and specifies its layout. |
| `CreateProgram(string vertexShader, string fragmentShader)` | `WebGLProgram` | Helper functionto create a WebGLProgram from a vertex shader source and a fragment shader source. |

## Example

```csharp
// Get WebGL context from an OffscreenCanvas
using var canvas = new OffscreenCanvas(800, 600);
using var gl = canvas.GetWebGLContext();

// Set clear color and clear
gl.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
gl.Clear(WebGLConstants.COLOR_BUFFER_BIT);

// Create and compile vertex shader
using var vertShader = gl.CreateShader(WebGLConstants.VERTEX_SHADER);
gl.ShaderSource(vertShader, @"
    attribute vec4 aPosition;
    void main() {
        gl_Position = aPosition;
    }
");
gl.CompileShader(vertShader);

// Create and compile fragment shader
using var fragShader = gl.CreateShader(WebGLConstants.FRAGMENT_SHADER);
gl.ShaderSource(fragShader, @"
    precision mediump float;
    void main() {
        gl_FragColor = vec4(1.0, 0.0, 0.0, 1.0);
    }
");
gl.CompileShader(fragShader);

// Create program
using var program = gl.CreateProgram();
gl.AttachShader(program, vertShader);
gl.AttachShader(program, fragShader);
gl.LinkProgram(program);
gl.UseProgram(program);

// Create vertex buffer
float[] vertices = { 0.0f, 0.5f, -0.5f, -0.5f, 0.5f, -0.5f };
using var vertexArray = new Float32Array(vertices);
using var buffer = gl.CreateBuffer();
gl.BindBuffer(WebGLConstants.ARRAY_BUFFER, buffer);
gl.BufferData(WebGLConstants.ARRAY_BUFFER, vertexArray, WebGLConstants.STATIC_DRAW);

// Set up vertex attribute
int posLocation = gl.GetAttribLocation(program, "aPosition");
gl.VertexAttribPointer(posLocation, 2, WebGLConstants.FLOAT, false, 0, 0);
gl.EnableVertexAttribArray(posLocation);

// Draw
gl.Viewport(0, 0, 800, 600);
gl.DrawArrays(WebGLConstants.TRIANGLES, 0, 3);
```
