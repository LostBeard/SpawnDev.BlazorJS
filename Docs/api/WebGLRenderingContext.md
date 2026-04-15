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
