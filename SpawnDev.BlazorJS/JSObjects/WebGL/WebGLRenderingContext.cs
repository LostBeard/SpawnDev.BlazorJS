using Microsoft.JSInterop;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGLRenderingContext interface provides an interface to the OpenGL ES 2.0 graphics rendering context for the drawing surface of an HTML canvas element.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGLRenderingContext<br/>
    /// https://www.khronos.org/registry/webgl/specs/latest/1.0/#5.14.9
    /// </summary>
    public partial class WebGLRenderingContext : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WebGLRenderingContext(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the canvas element that the drawing context is bound to.
        /// </summary>
        public HTMLCanvasElement Canvas => JSRef!.Get<HTMLCanvasElement>("canvas");
        /// <summary>
        /// The read-only height of the current drawing buffer. Should match the height of the canvas element associated with this context.
        /// </summary>
        public int DrawingBufferHeight => JSRef!.Get<int>("drawingBufferHeight");
        /// <summary>
        /// The read-only width of the current drawing buffer. Should match the width of the canvas element associated with this context.
        /// </summary>
        public int DrawingBufferWidth => JSRef!.Get<int>("drawingBufferWidth");
        /// <summary>
        /// Selects the active texture unit. Subsequent calls that modify the texture state will affect this texture.
        /// </summary>
        /// <param name="texture">The texture unit to make active. The value is a gl.TEXTUREI where I is within the range from 0 to gl.MAX_COMBINED_TEXTURE_IMAGE_UNITS - 1.</param>
        public void ActiveTexture(int texture) => JSRef!.CallVoid("activeTexture", texture);
        /// <summary>
        /// Attaches a WebGLShader to a WebGLProgram.
        /// </summary>
        /// <param name="program">A WebGLProgram.</param>
        /// <param name="shader">A fragment or vertex WebGLShader.</param>
        public void AttachShader(WebGLProgram program, WebGLShader shader) => JSRef!.CallVoid("attachShader", program, shader);
        /// <summary>
        /// Binds a generic vertex index to a named attribute variable.
        /// </summary>
        /// <param name="program">A WebGLProgram.</param>
        /// <param name="index">A GLuint specifying the index of the generic vertex to bind.</param>
        /// <param name="name">A string specifying the name of the variable to bind to the generic vertex index. This name cannot start with "webgl_" or "_webgl_", as these are reserved for use by WebGL.</param>
        public void BindAttribLocation(WebGLProgram program, uint index, string name) => JSRef!.CallVoid("bindAttribLocation", index, name);
        /// <summary>
        /// The WebGLRenderingContext.bindBuffer() method of the WebGL API binds a given WebGLBuffer to a target.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// </param>
        /// <param name="buffer">A WebGLBuffer to bind.</param>
        public void BindBuffer(int target, WebGLBuffer buffer) => JSRef!.CallVoid("bindBuffer", target, buffer);
        /// <summary>
        /// The WebGLRenderingContext.bindFramebuffer() method of the WebGL API binds to the specified target the provided WebGLFramebuffer, or, if the framebuffer argument is null, the default WebGLFramebuffer, which is associated with the canvas rendering context.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.FRAMEBUFFER - Collection buffer data storage of color, alpha, depth and stencil buffers used as both a destination for drawing and as a source for reading (see below).<br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.DRAW_FRAMEBUFFER - Used as a destination for drawing operations such as gl.draw*, gl.clear* and gl.blitFramebuffer.<br/>
        /// gl.READ_FRAMEBUFFER - Used as a source for reading operations such as gl.readPixels and gl.blitFramebuffer.<br/>
        /// </param>
        /// <param name="framebuffer">A WebGLFramebuffer object to bind, or null for binding the HTMLCanvasElement or OffscreenCanvas object associated with the rendering context.</param>
        public void BindFramebuffer(int target, WebGLFramebuffer framebuffer) => JSRef!.CallVoid("bindFramebuffer", target, framebuffer);
        /// <summary>
        /// The WebGLRenderingContext.bindRenderbuffer() method of the WebGL API binds a given WebGLRenderbuffer to a target, which must be gl.RENDERBUFFER.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.RENDERBUFFER - Buffer data storage for single images in a renderable internal format.
        /// </param>
        /// <param name="renderbuffer">A WebGLRenderbuffer object to bind.</param>
        public void BindRenderbuffer(int target, WebGLRenderbuffer renderbuffer) => JSRef!.CallVoid("bindRenderbuffer", target, renderbuffer);
        /// <summary>
        /// The WebGLRenderingContext.bindTexture() method of the WebGL API binds a given WebGLTexture to a target (binding point).
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.TEXTURE_2D - A two-dimensional texture.<br/>
        /// gl.TEXTURE_CUBE_MAP - A cube-mapped texture.<br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.TEXTURE_3D - A three-dimensional texture.<br/>
        /// gl.TEXTURE_2D_ARRAY - A two-dimensional array texture.
        /// </param>
        /// <param name="texture">A WebGLTexture object to bind.</param>
        public void BindTexture(int target, WebGLTexture texture) => JSRef!.CallVoid("bindTexture", target, texture);
        /// <summary>
        /// The WebGLRenderingContext.blendColor() method of the WebGL API is used to set the source and destination blending factors.
        /// </summary>
        /// <param name="red">A GLclampf for the red component in the range of 0 to 1. Default value is 0.</param>
        /// <param name="green">A GLclampf for the green component in the range of 0 to 1. Default value is 0.</param>
        /// <param name="blue">A GLclampf for the blue component in the range of 0 to 1. Default value is 0.</param>
        /// <param name="alpha">A GLclampf for the alpha component (transparency) in the range of 0. to 1. Default value is 0.</param>
        public void BlendColor(float red = 0, float green = 0, float blue = 0, float alpha = 0) => JSRef!.CallVoid("blendColor", red, green, blue, alpha);
        /// <summary>
        /// The WebGLRenderingContext.blendEquation() method of the WebGL API is used to set both the RGB blend equation and alpha blend equation to a single equation.<br/>
        /// The blend equation determines how a new pixel is combined with a pixel already in the WebGLFramebuffer.
        /// </summary>
        /// <param name="mode">
        /// A GLenum specifying how source and destination colors are combined. Must be either:<br/>
        /// gl.FUNC_ADD - source + destination(default value)<br/>
        /// gl.FUNC_SUBTRACT - source - destination<br/>
        /// gl.FUNC_REVERSE_SUBTRACT - destination - source<br/>
        /// When using the EXT_blend_minmax extension:<br/>
        /// ext.MIN_EXT - Minimum of source and destination<br/>
        /// ext.MAX_EXT - Maximum of source and destination<br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.MIN - Minimum of source and destination<br/>
        /// gl.MAX - Maximum of source and destination<br/>
        /// </param>
        public void BlendEquation(int mode) => JSRef!.CallVoid("blendEquation", mode);
        /// <summary>
        /// The WebGLRenderingContext.blendEquationSeparate() method of the WebGL API is used to set the RGB blend equation and alpha blend equation separately.<br/>
        /// The blend equation determines how a new pixel is combined with a pixel already in the WebGLFramebuffer.
        /// </summary>
        /// <param name="modeRGB">
        /// A GLenum specifying how the red, green and blue components of source and destination colors are combined.Must be either:<br/>
        /// gl.FUNC_ADD - source + destination (default value),<br/>
        /// gl.FUNC_SUBTRACT - source - destination,<br/>
        /// gl.FUNC_REVERSE_SUBTRACT - destination - source,<br/>
        /// When using the EXT_blend_minmax extension:<br/>
        /// ext.MIN_EXT - Minimum of source and destination,<br/>
        /// ext.MAX_EXT - Maximum of source and destination.<br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.MIN - Minimum of source and destination,<br/>
        /// gl.MAX - Maximum of source and destination.
        /// </param>
        /// <param name="modeAlpha">
        /// A GLenum specifying how the alpha component (transparency) of source and destination colors are combined. Must be either:<br/>
        /// gl.FUNC_ADD: source + destination(default value),<br/>
        /// gl.FUNC_SUBTRACT: source - destination,<br/>
        /// gl.FUNC_REVERSE_SUBTRACT: destination - source,<br/>
        /// When using the EXT_blend_minmax extension:<br/>
        /// ext.MIN_EXT: Minimum of source and destination,<br/>
        /// ext.MAX_EXT: Maximum of source and destination.<br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.MIN: Minimum of source and destination,<br/>
        /// gl.MAX: Maximum of source and destination.<br/>
        /// </param>
        public void BlendEquationSeparate(int modeRGB, int modeAlpha) => JSRef!.CallVoid("blendEquationSeparate", modeRGB, modeAlpha);
        /// <summary>
        /// The WebGLRenderingContext.blendFunc() method of the WebGL API defines which function is used for blending pixel arithmetic.
        /// </summary>
        /// <param name="sfactor">A GLenum specifying a multiplier for the source blending factors. The default value is gl.ONE.</param>
        /// <param name="dfactor">A GLenum specifying a multiplier for the destination blending factors. The default value is gl.ZERO.</param>
        public void BlendFunc(int sfactor, int dfactor) => JSRef!.CallVoid("blendFunc", sfactor, dfactor);
        /// <summary>
        /// The WebGLRenderingContext.blendFuncSeparate() method of the WebGL API defines which function is used for blending pixel arithmetic for RGB and alpha components separately.
        /// </summary>
        /// <param name="srcRGB">A GLenum specifying a multiplier for the red, green and blue (RGB) source blending factors. The default value is gl.ONE.</param>
        /// <param name="dstRGB">A GLenum specifying a multiplier for the red, green and blue (RGB) destination blending factors. The default value is gl.ZERO.</param>
        /// <param name="srcAlpha">A GLenum specifying a multiplier for the alpha source blending factor. The default value is gl.ONE.</param>
        /// <param name="dstAlpha">A GLenum specifying a multiplier for the alpha destination blending factor. The default value is gl.ZERO.</param>
        public void BlendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha) => JSRef!.CallVoid("blendFuncSeparate", srcRGB, dstRGB, srcAlpha, dstAlpha);
        /// <summary>
        /// The WebGLRenderingContext.bufferData() method of the WebGL API initializes and creates the buffer object's data store.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// </param>
        /// <param name="size">A GLsizeiptr setting the size in bytes of the buffer object's data store.</param>
        /// <param name="usage">
        /// A GLenum specifying the intended usage pattern of the data store for optimization purposes. Possible values:<br/>
        /// gl.STATIC_DRAW - The contents are intended to be specified once by the application, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.DYNAMIC_DRAW - The contents are intended to be respecified repeatedly by the application, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STREAM_DRAW - The contents are intended to be specified once by the application, and used at most a few times as the source for WebGL drawing and image specification commands.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.STATIC_READ - The contents are intended to be specified once by reading data from WebGL, and queried many times by the application.<br/>
        /// gl.DYNAMIC_READ - The contents are intended to be respecified repeatedly by reading data from WebGL, and queried many times by the application.<br/>
        /// gl.STREAM_READ - The contents are intended to be specified once by reading data from WebGL, and queried at most a few times by the application<br/>
        /// gl.STATIC_COPY - The contents are intended to be specified once by reading data from WebGL, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.DYNAMIC_COPY - The contents are intended to be respecified repeatedly by reading data from WebGL, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STREAM_COPY - The contents are intended to be specified once by reading data from WebGL, and used at most a few times as the source for WebGL drawing and image specification commands.
        /// </param>
        public void BufferData(int target, int size, int usage) => JSRef!.CallVoid("bufferData", target, size, usage);
        /// <summary>
        /// The WebGLRenderingContext.bufferData() method of the WebGL API initializes and creates the buffer object's data store.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// </param>
        /// <param name="srcData">An ArrayBuffer, SharedArrayBuffer, a TypedArray or a DataView that will be copied into the data store. If null, a data store is still created, but the content is uninitialized and undefined.</param>
        /// <param name="usage">
        /// A GLenum specifying the intended usage pattern of the data store for optimization purposes. Possible values:<br/>
        /// gl.STATIC_DRAW - The contents are intended to be specified once by the application, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.DYNAMIC_DRAW - The contents are intended to be respecified repeatedly by the application, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STREAM_DRAW - The contents are intended to be specified once by the application, and used at most a few times as the source for WebGL drawing and image specification commands.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.STATIC_READ - The contents are intended to be specified once by reading data from WebGL, and queried many times by the application.<br/>
        /// gl.DYNAMIC_READ - The contents are intended to be respecified repeatedly by reading data from WebGL, and queried many times by the application.<br/>
        /// gl.STREAM_READ - The contents are intended to be specified once by reading data from WebGL, and queried at most a few times by the application<br/>
        /// gl.STATIC_COPY - The contents are intended to be specified once by reading data from WebGL, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.DYNAMIC_COPY - The contents are intended to be respecified repeatedly by reading data from WebGL, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STREAM_COPY - The contents are intended to be specified once by reading data from WebGL, and used at most a few times as the source for WebGL drawing and image specification commands.
        /// </param>
        public void BufferData(int target, ArrayBuffer srcData, int usage) => JSRef!.CallVoid("bufferData", target, srcData, usage);
        /// <summary>
        /// The WebGLRenderingContext.bufferData() method of the WebGL API initializes and creates the buffer object's data store.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// </param>
        /// <param name="srcData">An ArrayBuffer, SharedArrayBuffer, a TypedArray or a DataView that will be copied into the data store. If null, a data store is still created, but the content is uninitialized and undefined.</param>
        /// <param name="usage">
        /// A GLenum specifying the intended usage pattern of the data store for optimization purposes. Possible values:<br/>
        /// gl.STATIC_DRAW - The contents are intended to be specified once by the application, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.DYNAMIC_DRAW - The contents are intended to be respecified repeatedly by the application, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STREAM_DRAW - The contents are intended to be specified once by the application, and used at most a few times as the source for WebGL drawing and image specification commands.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.STATIC_READ - The contents are intended to be specified once by reading data from WebGL, and queried many times by the application.<br/>
        /// gl.DYNAMIC_READ - The contents are intended to be respecified repeatedly by reading data from WebGL, and queried many times by the application.<br/>
        /// gl.STREAM_READ - The contents are intended to be specified once by reading data from WebGL, and queried at most a few times by the application<br/>
        /// gl.STATIC_COPY - The contents are intended to be specified once by reading data from WebGL, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.DYNAMIC_COPY - The contents are intended to be respecified repeatedly by reading data from WebGL, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STREAM_COPY - The contents are intended to be specified once by reading data from WebGL, and used at most a few times as the source for WebGL drawing and image specification commands.
        /// </param>
        public void BufferData(int target, SharedArrayBuffer srcData, int usage) => JSRef!.CallVoid("bufferData", target, srcData, usage);
        /// <summary>
        /// The WebGLRenderingContext.bufferData() method of the WebGL API initializes and creates the buffer object's data store.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// </param>
        /// <param name="srcData">An ArrayBuffer, SharedArrayBuffer, a TypedArray or a DataView that will be copied into the data store. If null, a data store is still created, but the content is uninitialized and undefined.</param>
        /// <param name="usage">
        /// A GLenum specifying the intended usage pattern of the data store for optimization purposes. Possible values:<br/>
        /// gl.STATIC_DRAW - The contents are intended to be specified once by the application, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.DYNAMIC_DRAW - The contents are intended to be respecified repeatedly by the application, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STREAM_DRAW - The contents are intended to be specified once by the application, and used at most a few times as the source for WebGL drawing and image specification commands.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.STATIC_READ - The contents are intended to be specified once by reading data from WebGL, and queried many times by the application.<br/>
        /// gl.DYNAMIC_READ - The contents are intended to be respecified repeatedly by reading data from WebGL, and queried many times by the application.<br/>
        /// gl.STREAM_READ - The contents are intended to be specified once by reading data from WebGL, and queried at most a few times by the application<br/>
        /// gl.STATIC_COPY - The contents are intended to be specified once by reading data from WebGL, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.DYNAMIC_COPY - The contents are intended to be respecified repeatedly by reading data from WebGL, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STREAM_COPY - The contents are intended to be specified once by reading data from WebGL, and used at most a few times as the source for WebGL drawing and image specification commands.
        /// </param>
        public void BufferData(int target, TypedArray srcData, int usage) => JSRef!.CallVoid("bufferData", target, srcData, usage);
        /// <summary>
        /// The WebGLRenderingContext.bufferData() method of the WebGL API initializes and creates the buffer object's data store.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// </param>
        /// <param name="srcData">An ArrayBuffer, SharedArrayBuffer, a TypedArray or a DataView that will be copied into the data store. If null, a data store is still created, but the content is uninitialized and undefined.</param>
        /// <param name="usage">
        /// A GLenum specifying the intended usage pattern of the data store for optimization purposes. Possible values:<br/>
        /// gl.STATIC_DRAW - The contents are intended to be specified once by the application, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.DYNAMIC_DRAW - The contents are intended to be respecified repeatedly by the application, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STREAM_DRAW - The contents are intended to be specified once by the application, and used at most a few times as the source for WebGL drawing and image specification commands.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.STATIC_READ - The contents are intended to be specified once by reading data from WebGL, and queried many times by the application.<br/>
        /// gl.DYNAMIC_READ - The contents are intended to be respecified repeatedly by reading data from WebGL, and queried many times by the application.<br/>
        /// gl.STREAM_READ - The contents are intended to be specified once by reading data from WebGL, and queried at most a few times by the application<br/>
        /// gl.STATIC_COPY - The contents are intended to be specified once by reading data from WebGL, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.DYNAMIC_COPY - The contents are intended to be respecified repeatedly by reading data from WebGL, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STREAM_COPY - The contents are intended to be specified once by reading data from WebGL, and used at most a few times as the source for WebGL drawing and image specification commands.
        /// </param>
        public void BufferData(int target, byte[] srcData, int usage) => JSRef!.CallVoid("bufferData", target, srcData, usage);
        /// <summary>
        /// The WebGLRenderingContext.bufferData() method of the WebGL API initializes and creates the buffer object's data store.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// </param>
        /// <param name="srcData">An ArrayBuffer, SharedArrayBuffer, a TypedArray or a DataView that will be copied into the data store. If null, a data store is still created, but the content is uninitialized and undefined.</param>
        /// <param name="usage">
        /// A GLenum specifying the intended usage pattern of the data store for optimization purposes. Possible values:<br/>
        /// gl.STATIC_DRAW - The contents are intended to be specified once by the application, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.DYNAMIC_DRAW - The contents are intended to be respecified repeatedly by the application, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STREAM_DRAW - The contents are intended to be specified once by the application, and used at most a few times as the source for WebGL drawing and image specification commands.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.STATIC_READ - The contents are intended to be specified once by reading data from WebGL, and queried many times by the application.<br/>
        /// gl.DYNAMIC_READ - The contents are intended to be respecified repeatedly by reading data from WebGL, and queried many times by the application.<br/>
        /// gl.STREAM_READ - The contents are intended to be specified once by reading data from WebGL, and queried at most a few times by the application<br/>
        /// gl.STATIC_COPY - The contents are intended to be specified once by reading data from WebGL, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.DYNAMIC_COPY - The contents are intended to be respecified repeatedly by reading data from WebGL, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STREAM_COPY - The contents are intended to be specified once by reading data from WebGL, and used at most a few times as the source for WebGL drawing and image specification commands.
        /// </param>
        public void BufferData(int target, DataView srcData, int usage) => JSRef!.CallVoid("bufferData", target, srcData, usage);
        /// <summary>
        /// The WebGLRenderingContext.bufferSubData() method of the WebGL API updates a subset of a buffer object's data store.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.
        /// </param>
        /// <param name="offset">A GLintptr specifying an offset in bytes where the data replacement will start.</param>
        public void BufferSubData(int target, long offset) => JSRef!.CallVoid("bufferSubData", target, offset);
        /// <summary>
        /// The WebGLRenderingContext.bufferSubData() method of the WebGL API updates a subset of a buffer object's data store.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.
        /// </param>
        /// <param name="offset">A GLintptr specifying an offset in bytes where the data replacement will start.</param>
        /// <param name="srcData">An ArrayBuffer, SharedArrayBuffer, a DataView, or a TypedArray that will be copied into the data store.</param>
        public void BufferSubData(int target, long offset, ArrayBuffer srcData) => JSRef!.CallVoid("bufferSubData", target, offset, srcData);
        /// <summary>
        /// The WebGLRenderingContext.bufferSubData() method of the WebGL API updates a subset of a buffer object's data store.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.
        /// </param>
        /// <param name="offset">A GLintptr specifying an offset in bytes where the data replacement will start.</param>
        /// <param name="srcData">An ArrayBuffer, SharedArrayBuffer, a DataView, or a TypedArray that will be copied into the data store.</param>
        public void BufferSubData(int target, long offset, SharedArrayBuffer srcData) => JSRef!.CallVoid("bufferSubData", target, offset, srcData);
        /// <summary>
        /// The WebGLRenderingContext.bufferSubData() method of the WebGL API updates a subset of a buffer object's data store.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.
        /// </param>
        /// <param name="offset">A GLintptr specifying an offset in bytes where the data replacement will start.</param>
        /// <param name="srcData">An ArrayBuffer, SharedArrayBuffer, a DataView, or a TypedArray that will be copied into the data store.</param>
        public void BufferSubData(int target, long offset, DataView srcData) => JSRef!.CallVoid("bufferSubData", target, offset, srcData);
        /// <summary>
        /// The WebGLRenderingContext.bufferSubData() method of the WebGL API updates a subset of a buffer object's data store.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.
        /// </param>
        /// <param name="offset">A GLintptr specifying an offset in bytes where the data replacement will start.</param>
        /// <param name="srcData">An ArrayBuffer, SharedArrayBuffer, a DataView, or a TypedArray that will be copied into the data store.</param>
        public void BufferSubData(int target, long offset, TypedArray srcData) => JSRef!.CallVoid("bufferSubData", target, offset, srcData);
        /// <summary>
        /// The WebGLRenderingContext.bufferSubData() method of the WebGL API updates a subset of a buffer object's data store.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.
        /// </param>
        /// <param name="offset">A GLintptr specifying an offset in bytes where the data replacement will start.</param>
        /// <param name="srcData">An ArrayBuffer, SharedArrayBuffer, a DataView, or a TypedArray that will be copied into the data store.</param>
        public void BufferSubData(int target, long offset, byte[] srcData) => JSRef!.CallVoid("bufferSubData", target, offset, srcData);
        /// <summary>
        /// The WebGLRenderingContext.checkFramebufferStatus() method of the WebGL API returns the completeness status of the WebGLFramebuffer object.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.FRAMEBUFFER - Collection buffer data storage of color, alpha, depth and stencil buffers used as both a destination for drawing and as a source for reading (see below).<br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.DRAW_FRAMEBUFFER - Used as a destination for drawing operations such as gl.draw*, gl.clear* and gl.blitFramebuffer.<br/>
        /// gl.READ_FRAMEBUFFER - Used as a source for reading operations such as gl.readPixels and gl.blitFramebuffer.<br/>
        /// </param>
        /// <returns>
        /// A GLenum indicating the completeness status of the framebuffer or 0 if an error occurs. Possible enum return values:<br/>
        /// gl.FRAMEBUFFER_COMPLETE - The framebuffer is ready to display.<br/>
        /// gl.FRAMEBUFFER_INCOMPLETE_ATTACHMENT - The attachment types are mismatched or not all framebuffer attachment points are framebuffer attachment complete.<br/>
        /// gl.FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT - There is no attachment.<br/>
        /// gl.FRAMEBUFFER_INCOMPLETE_DIMENSIONS - Height and width of the attachment are not the same.<br/>
        /// gl.FRAMEBUFFER_UNSUPPORTED - The format of the attachment is not supported or if depth and stencil attachments are not the same renderbuffer.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values can be returned additionally:<br/>
        /// gl.FRAMEBUFFER_INCOMPLETE_MULTISAMPLE - The values of gl.RENDERBUFFER_SAMPLES are different among attached renderbuffers, or are non-zero if the attached images are a mix of renderbuffers and textures.<br/>
        /// <br/>
        /// When using the OVR_multiview2 extension, the following value can be returned additionally:<br/>
        /// ext.FRAMEBUFFER_INCOMPLETE_VIEW_TARGETS_OVR - If baseViewIndex is not the same for all framebuffer attachment points where the value of FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE is not NONE, the framebuffer is considered incomplete.
        /// </returns>
        public int CheckFramebufferStatus(int target) => JSRef!.Call<int>("checkFramebufferStatus", target);
        /// <summary>
        /// The WebGLRenderingContext.clear() method of the WebGL API clears buffers to preset values.<br/>
        /// The preset values can be set by clearColor(), clearDepth() or clearStencil().<br/>
        /// The scissor box, dithering, and buffer writemasks can affect the clear() method.
        /// </summary>
        /// <param name="mask">
        /// A GLbitfield bitwise OR mask that indicates the buffers to be cleared. Possible values are:<br/>
        /// gl.COLOR_BUFFER_BIT<br/>
        /// gl.DEPTH_BUFFER_BIT<br/>
        /// gl.STENCIL_BUFFER_BIT
        /// </param>
        public void Clear(int mask) => JSRef!.CallVoid("clear", mask);
        /// <summary>
        /// The WebGLRenderingContext.clearColor() method of the WebGL API specifies the color values used when clearing color buffers.<br/>
        /// This specifies what color values to use when calling the clear() method. The values are clamped between 0 and 1.
        /// </summary>
        /// <param name="red">A GLclampf specifying the red color value used when the color buffers are cleared. Default value: 0.</param>
        /// <param name="green">A GLclampf specifying the green color value used when the color buffers are cleared. Default value: 0.</param>
        /// <param name="blue">A GLclampf specifying the blue color value used when the color buffers are cleared. Default value: 0.</param>
        /// <param name="alpha">A GLclampf specifying the alpha (transparency) value used when the color buffers are cleared. Default value: 0.</param>
        public void ClearColor(float red = 0, float green = 0, float blue = 0, float alpha = 0) => JSRef!.CallVoid("clearColor", red, green, blue, alpha);
        /// <summary>
        /// The WebGLRenderingContext.clearDepth() method of the WebGL API specifies the clear value for the depth buffer.<br/>
        /// This specifies what depth value to use when calling the clear() method. The value is clamped between 0 and 1.
        /// </summary>
        /// <param name="depth">A GLclampf specifying the depth value used when the depth buffer is cleared. Default value: 1.</param>
        public void ClearDepth(float depth = 1) => JSRef!.CallVoid("clearDepth", depth);
        /// <summary>
        /// The WebGLRenderingContext.clearStencil() method of the WebGL API specifies the clear value for the stencil buffer.<br/>
        /// This specifies what stencil value to use when calling the clear() method.
        /// </summary>
        /// <param name="s">A GLint specifying the index used when the stencil buffer is cleared. Default value: 0.</param>
        public void ClearStencil(int s = 0) => JSRef!.CallVoid("clearStencil", s);
        /// <summary>
        /// The WebGLRenderingContext.colorMask() method of the WebGL API sets which color components to enable or to disable when drawing or rendering to a WebGLFramebuffer.
        /// </summary>
        /// <param name="red">A GLboolean specifying whether or not the red color component can be written into the frame buffer. Default value: true.</param>
        /// <param name="green">A GLboolean specifying whether or not the green color component can be written into the frame buffer. Default value: true.</param>
        /// <param name="blue">A GLboolean specifying whether or not the blue color component can be written into the frame buffer. Default value: true.</param>
        /// <param name="alpha">A GLboolean specifying whether or not the alpha (transparency) component can be written into the frame buffer. Default value: true.</param>
        public void ColorMask(bool red = true, bool green = true, bool blue = true, bool alpha = true) => JSRef!.CallVoid("colorMask", red, green, blue, alpha);
        /// <summary>
        /// The WebGLRenderingContext.compileShader() method of the WebGL API compiles a GLSL shader into binary data so that it can be used by a WebGLProgram.
        /// </summary>
        /// <param name="shader">A fragment or vertex WebGLShader.</param>
        public void CompileShader(WebGLShader shader) => JSRef!.CallVoid("compileShader", shader);
        /// <summary>
        /// The compressedTexImage2D() method of the WebGLRenderingContext interface of the WebGL API specifies a two-dimensional texture image in a compressed format.<br/>
        /// Compressed image formats must be enabled by WebGL extensions before using these methods.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point(target) of the active texture.Possible values for compressedTexImage2D:<br/>
        /// gl.TEXTURE_2D - A two-dimensional texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_X - Positive X face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_X - Negative X face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_Y - Positive Y face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_Y - Negative Y face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_Z - Positive Z face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_Z - Negative Z face for a cube-mapped texture.
        /// </param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="internalformat">A GLenum specifying the compressed image format. Compressed image formats must be enabled by WebGL extensions before using this method.</param>
        /// <param name="width">A GLsizei specifying the width of the texture.</param>
        /// <param name="height">A GLsizei specifying the height of the texture.</param>
        /// <param name="border">A GLint specifying the width of the border. Must be 0.</param>
        /// <param name="pixels">A TypedArray or a DataView that will be used as a data store for the compressed image data in memory.</param>
        public void CompressedTexImage2D(int target, int level, int internalformat, int width, int height, int border, TypedArray pixels) => JSRef!.CallVoid("compressedTexImage2D", target, level, internalformat, width, height, border, pixels);
        /// <summary>
        /// The compressedTexImage2D() method of the WebGLRenderingContext interface of the WebGL API specifies a two-dimensional texture image in a compressed format.<br/>
        /// Compressed image formats must be enabled by WebGL extensions before using these methods.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point(target) of the active texture.Possible values for compressedTexImage2D:<br/>
        /// gl.TEXTURE_2D - A two-dimensional texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_X - Positive X face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_X - Negative X face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_Y - Positive Y face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_Y - Negative Y face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_Z - Positive Z face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_Z - Negative Z face for a cube-mapped texture.
        /// </param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="internalformat">A GLenum specifying the compressed image format. Compressed image formats must be enabled by WebGL extensions before using this method.</param>
        /// <param name="width">A GLsizei specifying the width of the texture.</param>
        /// <param name="height">A GLsizei specifying the height of the texture.</param>
        /// <param name="border">A GLint specifying the width of the border. Must be 0.</param>
        public void CompressedTexImage2D(int target, int level, int internalformat, int width, int height, int border) => JSRef!.CallVoid("compressedTexImage2D", target, level, internalformat, width, height, border);
        /// <summary>
        /// The WebGLRenderingContext.compressedTexSubImage2D() method of the WebGL API specifies a two-dimensional sub-rectangle for a texture image in a compressed format.<br/>
        /// Compressed image formats must be enabled by WebGL extensions before using this method or a WebGL2RenderingContext must be used.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point(target) of the active texture.Possible values for compressedTexImage2D:<br/>
        /// gl.TEXTURE_2D - A two-dimensional texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_X - Positive X face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_X - Negative X face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_Y - Positive Y face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_Y - Negative Y face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_Z - Positive Z face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_Z - Negative Z face for a cube-mapped texture.
        /// </param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="xoffset">A GLint specifying the horizontal offset within the compressed texture image.</param>
        /// <param name="yoffset">A GLint specifying the vertical offset within the compressed texture image.</param>
        /// <param name="width">A GLsizei specifying the width of the compressed texture.</param>
        /// <param name="height">A GLsizei specifying the height of the compressed texture.</param>
        /// <param name="format">A GLenum specifying the compressed image format. Compressed image formats must be enabled by WebGL extensions before using this method.</param>
        /// <param name="data">A TypedArray or a DataView that will be used as a data store for the compressed image data in memory.</param>
        public void CompressedTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, TypedArray data) => JSRef!.CallVoid("compressedTexSubImage2D", target, level, xoffset, yoffset, width, height, format, data);
        /// <summary>
        /// The WebGLRenderingContext.compressedTexSubImage2D() method of the WebGL API specifies a two-dimensional sub-rectangle for a texture image in a compressed format.<br/>
        /// Compressed image formats must be enabled by WebGL extensions before using this method or a WebGL2RenderingContext must be used.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point(target) of the active texture.Possible values for compressedTexImage2D:<br/>
        /// gl.TEXTURE_2D - A two-dimensional texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_X - Positive X face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_X - Negative X face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_Y - Positive Y face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_Y - Negative Y face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_Z - Positive Z face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_Z - Negative Z face for a cube-mapped texture.
        /// </param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="xoffset">A GLint specifying the horizontal offset within the compressed texture image.</param>
        /// <param name="yoffset">A GLint specifying the vertical offset within the compressed texture image.</param>
        /// <param name="width">A GLsizei specifying the width of the compressed texture.</param>
        /// <param name="height">A GLsizei specifying the height of the compressed texture.</param>
        /// <param name="format">A GLenum specifying the compressed image format. Compressed image formats must be enabled by WebGL extensions before using this method.</param>
        /// <param name="data">A TypedArray or a DataView that will be used as a data store for the compressed image data in memory.</param>
        public void CompressedTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, byte[] data) => JSRef!.CallVoid("compressedTexSubImage2D", target, level, xoffset, yoffset, width, height, format, data);
        /// <summary>
        /// The WebGLRenderingContext.copyTexImage2D() method of the WebGL API copies pixels from the current WebGLFramebuffer into a 2D texture image.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_2D - A two-dimensional texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_X - Positive X face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_X - Negative X face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_Y - Positive Y face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_Y - Negative Y face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_Z - Positive Z face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_Z - Negative Z face for a cube-mapped texture.
        /// </param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="internalformat">
        /// A GLenum specifying the color components in the texture. Possible values:<br/>
        /// gl.ALPHA - Discards the red, green and blue components and reads the alpha component.<br/>
        /// gl.RGB - Discards the alpha components and reads the red, green and blue components.<br/>
        /// gl.RGBA - Red, green, blue and alpha components are read from the color buffer.<br/>
        /// gl.LUMINANCE - Each color component is a luminance component, alpha is 1.0.<br/>
        /// gl.LUMINANCE_ALPHA - Each component is a luminance/alpha component.
        /// </param>
        /// <param name="x">A GLint specifying the x coordinate of the lower left corner where to start copying.</param>
        /// <param name="y">A GLint specifying the y coordinate of the lower left corner where to start copying.</param>
        /// <param name="width">A GLsizei specifying the width of the texture.</param>
        /// <param name="height">A GLsizei specifying the height of the texture.</param>
        /// <param name="border">A GLint specifying the width of the border. Must be 0.</param>
        public void CopyTexImage2D(int target, int level, int internalformat, int x, int y, int width, int height, int border) => JSRef!.CallVoid("copyTexImage2D", target, level, internalformat, x, y, width, height);
        /// <summary>
        /// The WebGLRenderingContext.copyTexSubImage2D() method of the WebGL API copies pixels from the current WebGLFramebuffer into an existing 2D texture sub-image.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_2D - A two-dimensional texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_X - Positive X face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_X - Negative X face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_Y - Positive Y face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_Y - Negative Y face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_Z - Positive Z face for a cube-mapped texture.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_Z - Negative Z face for a cube-mapped texture.
        /// </param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="xoffset">A GLint specifying the horizontal offset within the texture image.</param>
        /// <param name="yoffset">A GLint specifying the vertical offset within the texture image.</param>
        /// <param name="x">A GLint specifying the x coordinate of the lower left corner where to start copying.</param>
        /// <param name="y">A GLint specifying the y coordinate of the lower left corner where to start copying.</param>
        /// <param name="width">A GLsizei specifying the width of the texture.</param>
        /// <param name="height">A GLsizei specifying the height of the texture.</param>
        public void CopyTexSubImage2D(int target, int level, int xoffset, int yoffset, int x, int y, int width, int height) => JSRef!.CallVoid("copyTexSubImage2D", target, level, xoffset, yoffset, x, y, width, height);
        /// <summary>
        /// The WebGLRenderingContext.createBuffer() method of the WebGL API creates and initializes a WebGLBuffer storing data such as vertices or colors.
        /// </summary>
        /// <returns>A WebGLBuffer storing data such as vertices or colors.</returns>
        public WebGLBuffer CreateBuffer() => JSRef!.Call<WebGLBuffer>("createBuffer");
        /// <summary>
        /// The WebGLRenderingContext.createFramebuffer() method of the WebGL API creates and initializes a WebGLFramebuffer object.
        /// </summary>
        /// <returns>A WebGLFramebuffer object.</returns>
        public WebGLFramebuffer CreateFramebuffer() => JSRef!.Call<WebGLFramebuffer>("createFramebuffer");
        /// <summary>
        /// The WebGLRenderingContext.createProgram() method of the WebGL API creates and initializes a WebGLProgram object.
        /// </summary>
        /// <returns>A WebGLProgram object that is a combination of two compiled WebGLShaders consisting of a vertex shader and a fragment shader (both written in GLSL). These are then linked into a usable program.</returns>
        public WebGLProgram CreateProgram() => JSRef!.Call<WebGLProgram>("createProgram");
        /// <summary>
        /// The WebGLRenderingContext.createRenderbuffer() method of the WebGL API creates and initializes a WebGLRenderbuffer object.
        /// </summary>
        /// <returns>A WebGLRenderbuffer object that stores data such an image, or can be source or target of an rendering operation.</returns>
        public WebGLRenderbuffer CreateRenderbuffer() => JSRef!.Call<WebGLRenderbuffer>("createRenderbuffer");
        /// <summary>
        /// The WebGLRenderingContext method createShader() of the WebGL API creates a WebGLShader that can then be configured further using WebGLRenderingContext.shaderSource() and WebGLRenderingContext.compileShader().
        /// </summary>
        /// <param name="type">Either gl.VERTEX_SHADER or gl.FRAGMENT_SHADER</param>
        /// <returns>A new WebGLShader.</returns>
        public WebGLShader CreateShader(int type) => JSRef!.Call<WebGLShader>("createShader", type);
        /// <summary>
        /// The WebGLRenderingContext.createTexture() method of the WebGL API creates and initializes a WebGLTexture object.
        /// </summary>
        /// <returns>A WebGLTexture object to which images can be bound to.</returns>
        public WebGLTexture CreateTexture() => JSRef!.Call<WebGLTexture>("createTexture");
        /// <summary>
        /// The WebGLRenderingContext.cullFace() method of the WebGL API specifies whether or not front- and/or back-facing polygons can be culled.
        /// </summary>
        /// <param name="mode">
        /// A GLenum specifying whether front- or back-facing polygons are candidates for culling. The default value is gl.BACK. Possible values are:<br/>
        /// gl.FRONT<br/>
        /// gl.BACK<br/>
        /// gl.FRONT_AND_BACK
        /// </param>
        public void CullFace(int mode = 0x0405) => JSRef!.CallVoid("cullFace", mode);
        /// <summary>
        /// The WebGLRenderingContext.deleteBuffer() method of the WebGL API deletes a given WebGLBuffer. This method has no effect if the buffer has already been deleted. Normally you don't need to call this method yourself, when the buffer object is dereferenced it will be marked as free.
        /// </summary>
        /// <param name="buffer">A WebGLBuffer object to delete.</param>
        public void DeleteBuffer(WebGLBuffer buffer) => JSRef!.CallVoid("deleteBuffer", buffer);
        /// <summary>
        /// The WebGLRenderingContext.deleteFramebuffer() method of the WebGL API deletes a given WebGLFramebuffer object. This method has no effect if the frame buffer has already been deleted.
        /// </summary>
        /// <param name="framebuffer">A WebGLFramebuffer object to delete.</param>
        public void DeleteFramebuffer(WebGLFramebuffer framebuffer) => JSRef!.CallVoid("deleteFramebuffer", framebuffer);
        /// <summary>
        /// The WebGLRenderingContext.deleteProgram() method of the WebGL API deletes a given WebGLProgram object. This method has no effect if the program has already been deleted.
        /// </summary>
        /// <param name="program">A WebGLProgram object to delete.</param>
        public void DeleteProgram(WebGLProgram program) => JSRef!.CallVoid("deleteProgram", program);
        /// <summary>
        /// The WebGLRenderingContext.deleteRenderbuffer() method of the WebGL API deletes a given WebGLRenderbuffer object. This method has no effect if the render buffer has already been deleted.
        /// </summary>
        /// <param name="renderbuffer">A WebGLRenderbuffer object to delete.</param>
        public void DeleteRenderbuffer(WebGLRenderbuffer renderbuffer) => JSRef!.CallVoid("deleteRenderbuffer", renderbuffer);
        /// <summary>
        /// The WebGLRenderingContext.deleteShader() method of the WebGL API marks a given WebGLShader object for deletion. It will then be deleted whenever the shader is no longer in use. This method has no effect if the shader has already been deleted, and the WebGLShader is automatically marked for deletion when it is destroyed by the garbage collector.
        /// </summary>
        /// <param name="shader">A WebGLShader object to delete.</param>
        public void DeleteShader(WebGLShader shader) => JSRef!.CallVoid("deleteShader", shader);
        /// <summary>
        /// The WebGLRenderingContext.deleteTexture() method of the WebGL API deletes a given WebGLTexture object. This method has no effect if the texture has already been deleted.
        /// </summary>
        /// <param name="texture">A WebGLTexture object to delete.</param>
        public void DeleteTexture(WebGLTexture texture) => JSRef!.CallVoid("deleteTexture", texture);
        /// <summary>
        /// The WebGLRenderingContext.depthFunc() method of the WebGL API specifies a function that compares incoming pixel depth to the current depth buffer value.
        /// </summary>
        /// <param name="func">
        /// A GLenum specifying the depth comparison function, which sets the conditions under which the pixel will be drawn. The default value is gl.LESS. Possible values are:<br/>
        /// gl.NEVER - never pass<br/>
        /// gl.LESS - pass if the incoming value is less than the depth buffer value<br/>
        /// gl.EQUAL - pass if the incoming value equals the depth buffer value<br/>
        /// gl.LEQUAL - pass if the incoming value is less than or equal to the depth buffer value<br/>
        /// gl.GREATER - pass if the incoming value is greater than the depth buffer value<br/>
        /// gl.NOTEQUAL - pass if the incoming value is not equal to the depth buffer value<br/>
        /// gl.GEQUAL - pass if the incoming value is greater than or equal to the depth buffer value<br/>
        /// gl.ALWAYS - always pass
        /// </param>
        public void DepthFunc(int func = 0x0201) => JSRef!.CallVoid("depthFunc", func);
        /// <summary>
        /// The WebGLRenderingContext.depthMask() method of the WebGL API sets whether writing into the depth buffer is enabled or disabled.
        /// </summary>
        /// <param name="flag">A GLboolean specifying whether or not writing into the depth buffer is enabled. Default value: true, meaning that writing is enabled.</param>
        public void DepthMask(bool flag = true) => JSRef!.CallVoid("depthMask", flag);
        /// <summary>
        /// The WebGLRenderingContext.depthRange() method of the WebGL API specifies the depth range mapping from normalized device coordinates to window or viewport coordinates.
        /// </summary>
        /// <param name="zNear">A GLclampf specifying the mapping of the near clipping plane to window or viewport coordinates. Clamped to the range 0 to 1 and must be less than or equal to zFar. The default value is 0.</param>
        /// <param name="zFar">A GLclampf specifying the mapping of the far clipping plane to window or viewport coordinates. Clamped to the range 0 to 1. The default value is 1.</param>
        public void DepthRange(float zNear = 0, float zFar = 1) => JSRef!.CallVoid("depthRange", zNear, zFar);
        /// <summary>
        /// The WebGLRenderingContext.detachShader() method of the WebGL API detaches a previously attached WebGLShader from a WebGLProgram.
        /// </summary>
        /// <param name="program">A WebGLProgram.</param>
        /// <param name="shader">A fragment or vertex WebGLShader.</param>
        public void DetachShader(WebGLProgram program, WebGLShader shader) => JSRef!.CallVoid("detachShader", program, shader);
        /// <summary>
        /// The WebGLRenderingContext.disable() method of the WebGL API disables specific WebGL capabilities for this context.
        /// </summary>
        /// <param name="cap">
        /// A GLenum specifying which WebGL capability to disable. Possible values:<br/>
        /// gl.BLEND - Deactivates blending of the computed fragment color values. See WebGLRenderingContext.blendFunc().<br/>
        /// gl.CULL_FACE - Deactivates culling of polygons.See WebGLRenderingContext.cullFace().<br/>
        /// gl.DEPTH_TEST - Deactivates depth comparisons and updates to the depth buffer.See WebGLRenderingContext.depthFunc().<br/>
        /// gl.DITHER - Deactivates dithering of color components before they get written to the color buffer.<br/>
        /// gl.POLYGON_OFFSET_FILL - Deactivates adding an offset to depth values of polygon's fragments. See WebGLRenderingContext.polygonOffset().<br/>
        /// gl.SAMPLE_ALPHA_TO_COVERAGE - Deactivates the computation of a temporary coverage value determined by the alpha value.<br/>
        /// gl.SAMPLE_COVERAGE - Deactivates ANDing the fragment's coverage with the temporary coverage value. See WebGLRenderingContext.sampleCoverage().<br/>
        /// gl.SCISSOR_TEST - Deactivates the scissor test that discards fragments that are outside of the scissor rectangle.See WebGLRenderingContext.scissor().<br/>
        /// gl.STENCIL_TEST - Deactivates stencil testing and updates to the stencil buffer. See WebGLRenderingContext.stencilFunc().<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.RASTERIZER_DISCARD - Deactivates that primitives are discarded immediately before the rasterization stage, but after the optional transform feedback stage.gl.clear() commands are ignored.
        /// </param>
        public void Disable(int cap) => JSRef!.CallVoid("disable", cap);
        /// <summary>
        /// The WebGLRenderingContext.disableVertexAttribArray() method of the WebGL API turns the generic vertex attribute array off at a given index position.
        /// </summary>
        /// <param name="index">A GLuint specifying the index of the vertex attribute to disable.</param>
        public void DisableVertexAttribArray(uint index) => JSRef!.CallVoid("disableVertexAttribArray", index);
        /// <summary>
        /// The WebGLRenderingContext.drawArrays() method of the WebGL API renders primitives from array data.
        /// </summary>
        /// <param name="mode">
        /// A GLenum specifying the type primitive to render. Possible values are:<br/>
        /// gl.POINTS - Draws a single dot.<br/>
        /// gl.LINE_STRIP - Draws a straight line to the next vertex.<br/>
        /// gl.LINE_LOOP - Draws a straight line to the next vertex, and connects the last vertex back to the first.<br/>
        /// gl.LINES - Draws a line between a pair of vertices.<br/>
        /// gl.TRIANGLE_STRIP<br/>
        /// gl.TRIANGLE_FAN<br/>
        /// gl.TRIANGLES - Draws a triangle for a group of three vertices.
        /// </param>
        /// <param name="first">A GLint specifying the starting index in the array of vector points.</param>
        /// <param name="count">A GLsizei specifying the number of indices to be rendered.</param>
        public void DrawArrays(int mode, int first, int count) => JSRef!.CallVoid("drawArrays", mode, first, count);
        /// <summary>
        /// The WebGLRenderingContext.drawElements() method of the WebGL API renders primitives from array data.
        /// </summary>
        /// <param name="mode">
        /// A GLenum specifying the type primitive to render. Possible values are:<br/>
        /// gl.POINTS - Draws a single dot.<br/>
        /// gl.LINE_STRIP - Draws a straight line to the next vertex.<br/>
        /// gl.LINE_LOOP - Draws a straight line to the next vertex, and connects the last vertex back to the first.<br/>
        /// gl.LINES - Draws a line between a pair of vertices.<br/>
        /// gl.TRIANGLE_STRIP<br/>
        /// gl.TRIANGLE_FAN<br/>
        /// gl.TRIANGLES - Draws a triangle for a group of three vertices.
        /// </param>
        /// <param name="count">A GLsizei specifying the number of elements of the bound element array buffer to be rendered. For example, to draw a wireframe triangle with gl.LINES the count should be 2 endpoints per line × 3 lines = 6 elements. However to draw the same wireframe triangle with gl.LINE_STRIP the element array buffer does not repeat the indices for the end of the first line/start of the second line, and end of the second line/start of the third line, so count will be four. To draw the same triangle with gl.LINE_LOOP the element array buffer does not repeat the first/last vertex either so count will be three.</param>
        /// <param name="type">
        /// A GLenum specifying the type of the values in the element array buffer. Possible values are:<br/>
        /// gl.UNSIGNED_BYTE<br/>
        /// gl.UNSIGNED_SHORT<br/>
        /// When using the OES_element_index_uint extension:<br/>
        /// gl.UNSIGNED_INT
        /// </param>
        /// <param name="offset">A GLintptr specifying a byte offset in the element array buffer. Must be a valid multiple of the size of the given type.</param>
        public void DrawElements(int mode, int count, int type, long offset) => JSRef!.CallVoid("drawElements", mode, count, type, offset);
        /// <summary>
        /// The WebGLRenderingContext.enable() method of the WebGL API enables specific WebGL capabilities for this context.
        /// </summary>
        /// <param name="cap">
        /// A GLenum specifying which WebGL capability to disable. Possible values:<br/>
        /// gl.BLEND - Deactivates blending of the computed fragment color values. See WebGLRenderingContext.blendFunc().<br/>
        /// gl.CULL_FACE - Deactivates culling of polygons.See WebGLRenderingContext.cullFace().<br/>
        /// gl.DEPTH_TEST - Deactivates depth comparisons and updates to the depth buffer.See WebGLRenderingContext.depthFunc().<br/>
        /// gl.DITHER - Deactivates dithering of color components before they get written to the color buffer.<br/>
        /// gl.POLYGON_OFFSET_FILL - Deactivates adding an offset to depth values of polygon's fragments. See WebGLRenderingContext.polygonOffset().<br/>
        /// gl.SAMPLE_ALPHA_TO_COVERAGE - Deactivates the computation of a temporary coverage value determined by the alpha value.<br/>
        /// gl.SAMPLE_COVERAGE - Deactivates ANDing the fragment's coverage with the temporary coverage value. See WebGLRenderingContext.sampleCoverage().<br/>
        /// gl.SCISSOR_TEST - Deactivates the scissor test that discards fragments that are outside of the scissor rectangle.See WebGLRenderingContext.scissor().<br/>
        /// gl.STENCIL_TEST - Deactivates stencil testing and updates to the stencil buffer. See WebGLRenderingContext.stencilFunc().<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.RASTERIZER_DISCARD - Deactivates that primitives are discarded immediately before the rasterization stage, but after the optional transform feedback stage.gl.clear() commands are ignored.
        /// </param>
        public void Enable(int cap) => JSRef!.CallVoid("enable", cap);
        /// <summary>
        /// The WebGLRenderingContext.disableVertexAttribArray() method of the WebGL API turns the generic vertex attribute array off at a given index position.
        /// </summary>
        /// <param name="index">A GLuint specifying the index of the vertex attribute to disable.</param>
        public void EnableVertexAttribArray(int index) => JSRef!.CallVoid("enableVertexAttribArray", index);
        /// <summary>
        /// The WebGLRenderingContext.finish() method of the WebGL API blocks execution until all previously called commands are finished.
        /// </summary>
        public void Finish() => JSRef!.CallVoid("finish");
        /// <summary>
        /// The WebGLRenderingContext.flush() method of the WebGL API empties different buffer commands, causing all commands to be executed as quickly as possible.
        /// </summary>
        public void Flush() => JSRef!.CallVoid("flush");
        /// <summary>
        /// The WebGLRenderingContext.framebufferRenderbuffer() method of the WebGL API attaches a WebGLRenderbuffer object to a WebGLFramebuffer object.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target) for the framebuffer. Possible values:<br/>
        /// gl.FRAMEBUFFER - Collection buffer data storage of color, alpha, depth and stencil buffers used to render an image.<br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.DRAW_FRAMEBUFFER - Equivalent to gl.FRAMEBUFFER.Used as a destination for drawing, rendering, clearing, and writing operations.<br/>
        /// gl.READ_FRAMEBUFFER - Used as a source for reading operations.
        /// </param>
        /// <param name="attachment">A GLenum specifying the attachment point for the render buffer.</param>
        /// <param name="renderbuffertarget">
        /// A GLenum specifying the binding point (target) for the render buffer. Possible values:
        /// gl.RENDERBUFFER - Buffer data storage for single images in a renderable internal format.
        /// </param>
        /// <param name="renderbuffer">A WebGLRenderbuffer object to attach.</param>
        public void FramebufferRenderbuffer(int target, int attachment, int renderbuffertarget, WebGLRenderbuffer renderbuffer) => JSRef!.CallVoid("framebufferRenderbuffer", target, attachment, renderbuffertarget, renderbuffer);
        /// <summary>
        /// The WebGLRenderingContext.framebufferTexture2D() method of the WebGL API attaches a texture to a WebGLFramebuffer.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.FRAMEBUFFER - Collection buffer data storage of color, alpha, depth and stencil buffers used to render an image.<br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.DRAW_FRAMEBUFFER - Used as a destination for drawing, rendering, clearing, and writing operations.<br/>
        /// gl.READ_FRAMEBUFFER - Used as a source for reading operations.<br/>
        /// When binding, gl.FRAMEBUFFER sets both the gl.DRAW_FRAMEBUFFER and gl.READ_FRAMEBUFFER binding points.When referencing, gl.FRAMEBUFFER refers to the gl.DRAW_FRAMEBUFFER binding
        /// </param>
        /// <param name="attachment">A GLenum specifying the attachment point for the texture.</param>
        /// <param name="textarget">
        /// A GLenum specifying the texture target. Possible values:<br/>
        /// gl.TEXTURE_2D - A 2D image.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_X - Image for the positive X face of the cube.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_X - Image for the negative X face of the cube.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_Y - Image for the positive Y face of the cube.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_Y - Image for the negative Y face of the cube.<br/>
        /// gl.TEXTURE_CUBE_MAP_POSITIVE_Z - Image for the positive Z face of the cube.<br/>
        /// gl.TEXTURE_CUBE_MAP_NEGATIVE_Z - Image for the negative Z face of the cube.
        /// </param>
        /// <param name="texture">A WebGLTexture object whose image to attach.</param>
        /// <param name="level">A GLint specifying the mipmap level of the texture image to be attached. Must be 0.</param>
        public void FramebufferTexture2D(int target, int attachment, int textarget, WebGLTexture texture, int level) => JSRef!.CallVoid("framebufferTexture2D", target, attachment, textarget, texture, level);
        /// <summary>
        /// The WebGLRenderingContext.frontFace() method of the WebGL API specifies whether polygons are front- or back-facing by setting a winding orientation.
        /// </summary>
        /// <param name="mode">
        /// A GLenum type winding orientation. The default value is gl.CCW (0x0901). Possible values:<br/>
        /// gl.CW - Clock-wise winding.<br/>
        /// gl.CCW - Counter-clock-wise winding.
        /// </param>
        public void FrontFace(int mode = 0x0901) => JSRef!.CallVoid("frontFace", mode);
        /// <summary>
        /// The WebGLRenderingContext.generateMipmap() method of the WebGL API generates a set of mipmaps for a WebGLTexture object.<br/>
        /// Mipmaps are used to create distance with objects. A higher-resolution mipmap is used for objects that are closer, and a lower-resolution mipmap is used for objects that are farther away. It starts with the resolution of the texture image and halves the resolution until a 1x1 dimension texture image is created.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target) of the active texture whose mipmaps will be generated. Possible values:<br/>
        /// gl.TEXTURE_2D - A two-dimensional texture.<br/>
        /// gl.TEXTURE_CUBE_MAP - A cube-mapped texture.<br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.TEXTURE_3D - A three-dimensional texture.<br/>
        /// gl.TEXTURE_2D_ARRAY - A two-dimensional array texture.
        /// </param>
        public void GenerateMipmap(int target) => JSRef!.CallVoid("generateMipmap", target);
        /// <summary>
        /// The WebGLRenderingContext.getActiveAttrib() method of the WebGL API returns a WebGLActiveInfo object containing size, type, and name of a vertex attribute. It is generally used when querying unknown attributes either for debugging or generic library creation.
        /// </summary>
        /// <param name="program">A WebGLProgram containing the vertex attribute.</param>
        /// <param name="index">A GLuint specifying the index of the vertex attribute to get. This value is an index 0 to N - 1 as returned by gl.getProgramParameter(program, gl.ACTIVE_ATTRIBUTES).</param>
        /// <returns>A WebGLActiveInfo object.</returns>
        public WebGLActiveInfo GetActiveAttrib(WebGLProgram program, uint index) => JSRef!.Call<WebGLActiveInfo>("getActiveAttrib", program, index);
        /// <summary>
        /// The WebGLRenderingContext.getActiveUniform() method of the WebGL API returns a WebGLActiveInfo object containing size, type, and name of a uniform attribute. It is generally used when querying unknown uniforms either for debugging or generic library creation.
        /// </summary>
        /// <param name="program">A WebGLProgram specifying the WebGL shader program from which to obtain the uniform variable's information.</param>
        /// <param name="index">A GLuint specifying the index of the uniform attribute to get. This value is an index 0 to N - 1 as returned by gl.getProgramParameter(program, gl.ACTIVE_UNIFORMS).</param>
        /// <returns>A WebGLActiveInfo object describing the uniform.</returns>
        public WebGLActiveInfo GetActiveUniform(WebGLProgram program, uint index) => JSRef!.Call<WebGLActiveInfo>("getActiveUniform", program, index);
        /// <summary>
        /// The WebGLRenderingContext.getAttachedShaders() method of the WebGL API returns a list of WebGLShader objects attached to a WebGLProgram.
        /// </summary>
        /// <param name="program">A WebGLProgram object to get attached shaders for.</param>
        /// <returns>An Array of WebGLShader objects that are attached to the given WebGLProgram.</returns>
        public WebGLShader[] GetAttachedShaders(WebGLProgram program) => JSRef!.Call<WebGLShader[]>("getAttachedShaders", program);
        /// <summary>
        /// The WebGLRenderingContext.getAttribLocation() method of the WebGL API returns the location of an attribute variable in a given WebGLProgram.
        /// </summary>
        /// <param name="program">A WebGLProgram containing the attribute variable.</param>
        /// <param name="name">A string specifying the name of the attribute variable whose location to get.</param>
        /// <returns>A GLint number indicating the location of the variable name if found. Returns -1 otherwise.</returns>
        public int GetAttribLocation(WebGLProgram program, string name) => JSRef!.Call<int>("getAttribLocation", program, name);
        /// <summary>
        /// The WebGLRenderingContext.getBufferParameter() method of the WebGL API returns information about the buffer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">
        /// A GLenum specifying the target buffer object. Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.
        /// </param>
        /// <param name="pname">
        /// A GLenum specifying information to query. Possible values:<br/>
        /// gl.BUFFER_SIZE<br/>
        /// <br/>
        /// Returns a GLint indicating the size of the buffer in bytes.<br/>
        /// gl.BUFFER_USAGE<br/>
        /// <br/>
        /// Returns a GLenum indicating the usage pattern of the buffer. One of the following:<br/>
        /// gl.STATIC_DRAW<br/>
        /// gl.DYNAMIC_DRAW<br/>
        /// gl.STREAM_DRAW<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.STATIC_READ<br/>
        /// gl.DYNAMIC_READ<br/>
        /// gl.STREAM_READ<br/>
        /// gl.STATIC_COPY<br/>
        /// gl.DYNAMIC_COPY<br/>
        /// gl.STREAM_COPY
        /// </param>
        /// <returns>Depends on the requested information (as specified with pname). Either a GLint or a GLenum.</returns>
        public T GetBufferParameter<T>(int target, int pname) => JSRef!.Call<T>("getBufferParameter", target, pname);
        /// <summary>
        /// The WebGLRenderingContext.getBufferParameter() method of the WebGL API returns information about the buffer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">
        /// A GLenum specifying the target buffer object. Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.
        /// </param>
        /// <param name="pname">
        /// A GLenum specifying information to query. Possible values:<br/>
        /// gl.BUFFER_SIZE<br/>
        /// <br/>
        /// Returns a GLint indicating the size of the buffer in bytes.<br/>
        /// gl.BUFFER_USAGE<br/>
        /// <br/>
        /// Returns a GLenum indicating the usage pattern of the buffer. One of the following:<br/>
        /// gl.STATIC_DRAW<br/>
        /// gl.DYNAMIC_DRAW<br/>
        /// gl.STREAM_DRAW<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.STATIC_READ<br/>
        /// gl.DYNAMIC_READ<br/>
        /// gl.STREAM_READ<br/>
        /// gl.STATIC_COPY<br/>
        /// gl.DYNAMIC_COPY<br/>
        /// gl.STREAM_COPY
        /// </param>
        /// <returns>Depends on the requested information (as specified with pname). Either a GLint or a GLenum.</returns>
        public int GetBufferParameter(int target, int pname) => JSRef!.Call<int>("getBufferParameter", target, pname);
        /// <summary>
        /// The WebGLRenderingContext.getContextAttributes() method returns a WebGLContextAttributes object that contains the actual context parameters. Might return null, if the context is lost.
        /// </summary>
        /// <returns></returns>
        public WebGLContextAttributes GetContextAttributes() => JSRef!.Call<WebGLContextAttributes>("getContextAttributes");
        /// <summary>
        /// The WebGLRenderingContext.getError() method of the WebGL API returns error information.
        /// </summary>
        /// <returns>
        /// gl.NO_ERROR	- No error has been recorded. The value of this constant is 0.<br/>
        /// gl.INVALID_ENUM - An unacceptable value has been specified for an enumerated argument.The command is ignored and the error flag is set.<br/>
        /// gl.INVALID_VALUE - A numeric argument is out of range.The command is ignored and the error flag is set.<br/>
        /// gl.INVALID_OPERATION - The specified command is not allowed for the current state.The command is ignored and the error flag is set.<br/>
        /// gl.INVALID_FRAMEBUFFER_OPERATION - The currently bound framebuffer is not framebuffer complete when trying to render to or to read from it.<br/>
        /// gl.OUT_OF_MEMORY - Not enough memory is left to execute the command.<br/>
        /// gl.CONTEXT_LOST_WEBGL - If the WebGL context is lost, this error is returned on the first call to getError.Afterwards and until the context has been restored, it returns gl.NO_ERROR.
        /// </returns>
        public int GetError() => JSRef!.Call<int>("getError");
        /// <summary>
        /// The WebGLRenderingContext.getExtension() method enables a WebGL extension.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">A String for the name of the WebGL extension to enable.</param>
        /// <returns>A WebGL extension object, or null if name does not match (case-insensitive) to one of the strings in WebGLRenderingContext.getSupportedExtensions.</returns>
        public T GetExtension<T>(string name) => JSRef!.Call<T>("getExtension", name);
        /// <summary>
        /// The WebGLRenderingContext.getFramebufferAttachmentParameter() method of the WebGL API returns information about a framebuffer's attachment.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.FRAMEBUFFER - Collection buffer data storage of color, alpha, depth and stencil buffers used as both a destination for drawing and as a source for reading (see below).<br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.DRAW_FRAMEBUFFER - Used as a destination for drawing operations such as gl.draw*, gl.clear* and gl.blitFramebuffer.<br/>
        /// gl.READ_FRAMEBUFFER - Used as a source for reading operations such as gl.readPixels and gl.blitFramebuffer.<br/>
        /// </param>
        /// <param name="attachment">A GLenum specifying the attachment point for the texture. </param>
        /// <param name="pname">A GLenum specifying information to query.</param>
        /// <returns>Depends on the requested information (as specified with pname). Either a GLint, a GLenum, a WebGLRenderbuffer, or a WebGLTexture.</returns>
        public T GetFramebufferAttachmentParameter<T>(int target, int attachment, int pname) => JSRef!.Call<T>("getFramebufferAttachmentParameter", target, attachment, pname);
        /// <summary>
        /// The WebGLRenderingContext.getParameter() method of the WebGL API returns a value for the passed parameter name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pname">A GLenum specifying which parameter value to return. </param>
        /// <returns></returns>
        public T GetParameter<T>(int pname) => JSRef!.Call<T>("getParameter", pname);
        /// <summary>
        /// The WebGLRenderingContext.getProgramInfoLog returns the information log for the specified WebGLProgram object. It contains errors that occurred during failed linking or validation of WebGLProgram objects.
        /// </summary>
        /// <param name="program">The WebGLProgram to query.</param>
        /// <returns>A string that contains diagnostic messages, warning messages, and other information about the last linking or validation operation. When a WebGLProgram object is initially created, its information log will be a string of length 0.</returns>
        public string GetProgramInfoLog(WebGLProgram program) => JSRef!.Call<string>("getProgramInfoLog", program);
        /// <summary>
        /// The WebGLRenderingContext.getProgramParameter() method of the WebGL API returns information about the given program.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="program">A WebGLProgram to get parameter information from.</param>
        /// <param name="pname">
        /// A GLenum specifying the information to query. Possible values:<br/>
        /// gl.DELETE_STATUS - Returns a GLboolean indicating whether or not the program is flagged for deletion.<br/>
        /// gl.LINK_STATUS - Returns a GLboolean indicating whether or not the last link operation was successful.<br/>
        /// gl.VALIDATE_STATUS - Returns a GLboolean indicating whether or not the last validation operation was successful.<br/>
        /// gl.ATTACHED_SHADERS - Returns a GLint indicating the number of attached shaders to a program.<br/>
        /// gl.ACTIVE_ATTRIBUTES - Returns a GLint indicating the number of active attribute variables to a program.<br/>
        /// gl.ACTIVE_UNIFORMS - Returns a GLint indicating the number of active uniform variables to a program.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER_MODE - Returns a GLenum indicating the buffer mode when transform feedback is active. May be gl.SEPARATE_ATTRIBS or gl.INTERLEAVED_ATTRIBS.<br/>
        /// gl.TRANSFORM_FEEDBACK_VARYINGS - Returns a GLint indicating the number of varying variables to capture in transform feedback mode.<br/>
        /// gl.ACTIVE_UNIFORM_BLOCKS - Returns a GLint indicating the number of uniform blocks containing active uniforms.
        /// </param>
        /// <returns>Returns the requested program information (as specified with pname).</returns>
        public T GetProgramParameter<T>(WebGLProgram program, int pname) => JSRef!.Call<T>("getProgramParameter", program, pname);
        /// <summary>
        /// The WebGLRenderingContext.getRenderbufferParameter() method of the WebGL API returns information about the renderbuffer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">
        /// A GLenum specifying the target renderbuffer object. Possible values:<br/>
        /// gl.RENDERBUFFER - Buffer data storage for single images in a renderable internal format.
        /// </param>
        /// <param name="pname">
        /// A GLenum specifying the information to query. Possible values:<br/>
        /// gl.RENDERBUFFER_WIDTH - Returns a GLint indicating the width of the image of the currently bound renderbuffer.<br/>
        /// gl.RENDERBUFFER_HEIGHT - Returns a GLint indicating the height of the image of the currently bound renderbuffer.<br/>
        /// gl.RENDERBUFFER_INTERNAL_FORMAT - Returns a GLenum indicating the internal format of the currently bound renderbuffer.<br/>
        ///   The default is gl.RGBA4. Possible return values:<br/>
        ///   gl.RGBA4: 4 red bits, 4 green bits, 4 blue bits 4 alpha bits.<br/>
        ///   gl.RGB565: 5 red bits, 6 green bits, 5 blue bits.<br/>
        ///   gl.RGB5_A1: 5 red bits, 5 green bits, 5 blue bits, 1 alpha bit.<br/>
        ///   gl.DEPTH_COMPONENT16: 16 depth bits.<br/>
        ///   gl.STENCIL_INDEX8: 8 stencil bits.<br/>
        /// gl.RENDERBUFFER_GREEN_SIZE - Returns a GLint that is the resolution size (in bits) for the green color.<br/>
        /// gl.RENDERBUFFER_BLUE_SIZE - Returns a GLint that is the resolution size (in bits) for the blue color.<br/>
        /// gl.RENDERBUFFER_RED_SIZE - Returns a GLint that is the resolution size (in bits) for the red color.<br/>
        /// gl.RENDERBUFFER_ALPHA_SIZE - Returns a GLint that is the resolution size (in bits) for the alpha component.<br/>
        /// gl.RENDERBUFFER_DEPTH_SIZE - Returns a GLint that is the resolution size (in bits) for the depth component.<br/>
        /// gl.RENDERBUFFER_STENCIL_SIZE - Returns a GLint that is the resolution size (in bits) for the stencil component.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following value is available additionally:<br/>
        /// gl.RENDERBUFFER_SAMPLES - Returns a GLint indicating the number of samples of the image of the currently bound renderbuffer.
        /// </param>
        /// <returns>Depends on the requested information (as specified with pname). Either a GLint or a GLenum.</returns>
        public T GetRenderbufferParameter<T>(int target, int pname) => JSRef!.Call<T>("getRenderbufferParameter", target, pname);
        /// <summary>
        /// The WebGLRenderingContext.getShaderInfoLog returns the information log for the specified WebGLShader object. It contains warnings, debugging and compile information.
        /// </summary>
        /// <param name="shader">A WebGLShader to query.</param>
        /// <returns>A string that contains diagnostic messages, warning messages, and other information about the last compile operation. When a WebGLShader object is initially created, its information log will be a string of length 0.</returns>
        public string GetShaderInfoLog(WebGLShader shader) => JSRef!.Call<string>("getShaderInfoLog", shader);
        /// <summary>
        /// The WebGLRenderingContext.getShaderParameter() method of the WebGL API returns information about the given shader.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="shader">A WebGLShader to get parameter information from.</param>
        /// <param name="pname">
        /// A GLenum specifying the information to query. Possible values:<br/>
        /// gl.DELETE_STATUS - Returns a GLboolean indicating whether or not the shader is flagged for deletion.<br/>
        /// gl.COMPILE_STATUS - Returns a GLboolean indicating whether or not the last shader compilation was successful.<br/>
        /// gl.SHADER_TYPE - Returns a GLenum indicating whether the shader is a vertex shader (gl.VERTEX_SHADER) or fragment shader (gl.FRAGMENT_SHADER) object.
        /// </param>
        /// <returns>Returns the requested shader information (as specified with pname).</returns>
        public T GetShaderParameter<T>(WebGLShader shader, int pname) => JSRef!.Call<T>("getShaderParameter", shader, pname);
        /// <summary>
        /// The WebGLRenderingContext.getShaderPrecisionFormat() method of the WebGL API returns a new WebGLShaderPrecisionFormat object describing the range and precision for the specified shader numeric format.
        /// </summary>
        /// <param name="shadertype">Either a gl.FRAGMENT_SHADER or a gl.VERTEX_SHADER.</param>
        /// <param name="precisiontype">A precision type value. Either gl.LOW_FLOAT, gl.MEDIUM_FLOAT, gl.HIGH_FLOAT, gl.LOW_INT, gl.MEDIUM_INT, or gl.HIGH_INT.</param>
        /// <returns>A WebGLShaderPrecisionFormat object or null, if an error occurs.</returns>
        public WebGLShaderPrecisionFormat? GetShaderPrecisionFormat(int shadertype, int precisiontype) => JSRef!.Call<WebGLShaderPrecisionFormat?>("getShaderPrecisionFormat", shadertype, precisiontype);
        /// <summary>
        /// The WebGLRenderingContext.getShaderSource() method of the WebGL API returns the source code of a WebGLShader as a string.
        /// </summary>
        /// <param name="shader">A WebGLShader object to get the source code from.</param>
        /// <returns>A string containing the source code of the shader.</returns>
        public string GetShaderSource(WebGLShader shader) => JSRef!.Call<string>("getShaderSource", shader);
        /// <summary>
        /// The WebGLRenderingContext.getSupportedExtensions() method returns a list of all the supported WebGL extensions.
        /// </summary>
        /// <returns>An Array of strings with all the supported WebGL extensions.</returns>
        public string[] GetSupportedExtensions() => JSRef!.Call<string[]>("getSupportedExtensions");
        /// <summary>
        /// The WebGLRenderingContext.getTexParameter() method of the WebGL API returns information about the given texture.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">
        /// A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.TEXTURE_2D: A two-dimensional texture.<br/>
        /// gl.TEXTURE_CUBE_MAP: A cube-mapped texture.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.TEXTURE_3D: A three-dimensional texture.<br/>
        /// gl.TEXTURE_2D_ARRAY: A two-dimensional array texture.
        /// </param>
        /// <param name="pname">A GLenum specifying the information to query.</param>
        /// <returns>Returns the requested texture information (as specified with pname). If an error occurs, null is returned.</returns>
        public T GetTexParameter<T>(int target, int pname) => JSRef!.Call<T>("getTexParameter", target, pname);
        /// <summary>
        /// The WebGLRenderingContext.getUniform() method of the WebGL API returns the value of a uniform variable at a given location.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="program">A WebGLProgram containing the uniform attribute.</param>
        /// <param name="location">A WebGLUniformLocation object containing the location of the uniform attribute to get.</param>
        /// <returns>The returned type depends on the uniform type</returns>
        public T GetUniform<T>(WebGLProgram program, WebGLUniformLocation location) => JSRef!.Call<T>("getUniform", program, location);
        /// <summary>
        /// Part of the WebGL API, the WebGLRenderingContext method getUniformLocation() returns the location of a specific uniform variable which is part of a given WebGLProgram.<br/>
        /// The uniform variable is returned as a WebGLUniformLocation object, which is an opaque identifier used to specify where in the GPU's memory that uniform variable is located.<br/>
        /// </summary>
        /// <param name="program">The WebGLProgram in which to locate the specified uniform variable.</param>
        /// <param name="name">
        /// A string specifying the name of the uniform variable whose location is to be returned. The name can't have any whitespace in it, and you can't use this function to get the location of any uniforms starting with the reserved string "gl_", since those are internal to the WebGL layer.<br/>
        /// The possible values correspond to the uniform names returned by getActiveUniform; see that function for specifics on how declared uniforms map to uniform location names.<br/>
        /// Additionally, for uniforms declared as arrays, the following names are also valid:<br/>
        /// - The uniform name without the [0] suffix. E.g. the location returned for arrayUniform is equivalent to the one for arrayUniform[0].<br/>
        /// - The uniform name indexed with an integer. E.g. the location returned for arrayUniform[2] would point directly to the third entry of the arrayUniform uniform.
        /// </param>
        /// <returns>A WebGLUniformLocation value indicating the location of the named variable, if it exists. If the specified variable doesn't exist, null is returned instead.</returns>
        public WebGLUniformLocation? GetUniformLocation(WebGLProgram program, string name) => JSRef!.Call<WebGLUniformLocation?>("getUniformLocation", program, name);
        /// <summary>
        /// The WebGLRenderingContext.getVertexAttrib() method of the WebGL API returns information about a vertex attribute at a given position.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index">A GLuint specifying the index of the vertex attribute.</param>
        /// <param name="pname">
        /// A GLenum specifying the information to query. Possible values:<br/>
        /// gl.VERTEX_ATTRIB_ARRAY_BUFFER_BINDING - Returns the currently bound WebGLBuffer.<br/>
        /// gl.VERTEX_ATTRIB_ARRAY_ENABLED - Returns a GLboolean that is true if the vertex attribute is enabled at this index. Otherwise false.<br/>
        /// gl.VERTEX_ATTRIB_ARRAY_SIZE - Returns a GLint indicating the size of an element of the vertex array.<br/>
        /// gl.VERTEX_ATTRIB_ARRAY_STRIDE - Returns a GLint indicating the number of bytes between successive elements in the array. 0 means that the elements are sequential.<br/>
        /// gl.VERTEX_ATTRIB_ARRAY_TYPE - Returns a GLenum representing the array type. One of<br/>
        /// - gl.BYTE<br/>
        /// - gl.UNSIGNED_BYTE<br/>
        /// - gl.SHORT,<br/>
        /// - gl.UNSIGNED_SHORT<br/>
        /// - gl.FLOAT<br/>
        /// gl.VERTEX_ATTRIB_ARRAY_NORMALIZED - Returns a GLboolean that is true if fixed-point data types are normalized for the vertex attribute array at the given index.<br/>
        /// gl.CURRENT_VERTEX_ATTRIB - Returns a Float32Array (with 4 elements) representing the current value of the vertex attribute at the given index.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.VERTEX_ATTRIB_ARRAY_INTEGER - Returns a GLboolean indicating whether an integer data type is in the vertex attribute array at the given index.<br/>
        /// gl.VERTEX_ATTRIB_ARRAY_DIVISOR - Returns a GLint describing the frequency divisor used for instanced rendering.<br/>
        /// <br/>
        /// When using the ANGLE_instanced_arrays extension:<br/>
        /// ext.VERTEX_ATTRIB_ARRAY_DIVISOR_ANGLE - Returns a GLint describing the frequency divisor used for instanced rendering.<br/>
        /// </param>
        /// <returns>Returns the requested vertex attribute information (as specified with pname).</returns>
        public T GetVertexAttrib<T>(uint index, int pname) => JSRef!.Call<T>("getVertexAttrib", index, pname);
        /// <summary>
        /// The WebGLRenderingContext.getVertexAttribOffset() method of the WebGL API returns the address of a specified vertex attribute.
        /// </summary>
        /// <param name="index">A GLuint specifying the index of the vertex attribute.</param>
        /// <param name="pname">A GLenum which must be gl.VERTEX_ATTRIB_ARRAY_POINTER.</param>
        /// <returns>A GLintptr indicating the address of the vertex attribute.</returns>
        public long GetVertexAttribOffset(uint index, int pname) => JSRef!.Call<int>("getVertexAttribOffset", index, pname);
        /// <summary>
        /// The WebGLRenderingContext.hint() method of the WebGL API specifies hints for certain behaviors. The interpretation of these hints depend on the implementation.
        /// </summary>
        /// <param name="target">
        /// Sets which behavior to be controlled. Possible values:<br/>
        /// gl.GENERATE_MIPMAP_HINT - Quality of filtering when generating mipmap images with WebGLRenderingContext.generateMipmap().<br/>
        /// <br/>
        /// When using the OES_standard_derivatives extension:<br/>
        /// ext.FRAGMENT_SHADER_DERIVATIVE_HINT_OES - Accuracy of the derivative calculation for the GLSL built-in functions: dFdx, dFdy, and fwidth.<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.FRAGMENT_SHADER_DERIVATIVE_HINT - Same as ext.FRAGMENT_SHADER_DERIVATIVE_HINT_OES
        /// </param>
        /// <param name="mode">
        /// Sets the behavior. The default value is gl.DONT_CARE. The possible values are:<br/>
        /// gl.FASTEST - The most efficient behavior should be used.<br/>
        /// gl.NICEST - The most correct or the highest quality option should be used.<br/>
        /// gl.DONT_CARE - There is no preference for this behavior.
        /// </param>
        public void Hint(int target, int mode) => JSRef!.CallVoid("hint", target, mode);
        /// <summary>
        /// The WebGLRenderingContext.isBuffer() method of the WebGL API returns true if the passed WebGLBuffer is valid and false otherwise.
        /// </summary>
        /// <param name="buffer">A WebGLBuffer to check.</param>
        /// <returns>A GLboolean indicating whether or not the buffer is valid.</returns>
        public bool IsBuffer(WebGLBuffer buffer) => JSRef!.Call<bool>("isBuffer", buffer);
        /// <summary>
        /// The WebGLRenderingContext.isContextLost() method returns a boolean value indicating whether or not the WebGL context has been lost and must be re-established before rendering can resume.
        /// </summary>
        /// <returns>A boolean value which is true if the context is lost, or false if not.</returns>
        public bool IsContextLost() => JSRef!.Call<bool>("isContextLost");
        /// <summary>
        /// The WebGLRenderingContext.isEnabled() method of the WebGL API tests whether a specific WebGL capability is enabled or not for this context.
        /// </summary>
        /// <param name="cap">
        /// A GLenum specifying which WebGL capability to disable. Possible values:<br/>
        /// gl.BLEND - Deactivates blending of the computed fragment color values. See WebGLRenderingContext.blendFunc().<br/>
        /// gl.CULL_FACE - Deactivates culling of polygons.See WebGLRenderingContext.cullFace().<br/>
        /// gl.DEPTH_TEST - Deactivates depth comparisons and updates to the depth buffer.See WebGLRenderingContext.depthFunc().<br/>
        /// gl.DITHER - Deactivates dithering of color components before they get written to the color buffer.<br/>
        /// gl.POLYGON_OFFSET_FILL - Deactivates adding an offset to depth values of polygon's fragments. See WebGLRenderingContext.polygonOffset().<br/>
        /// gl.SAMPLE_ALPHA_TO_COVERAGE - Deactivates the computation of a temporary coverage value determined by the alpha value.<br/>
        /// gl.SAMPLE_COVERAGE - Deactivates ANDing the fragment's coverage with the temporary coverage value. See WebGLRenderingContext.sampleCoverage().<br/>
        /// gl.SCISSOR_TEST - Deactivates the scissor test that discards fragments that are outside of the scissor rectangle.See WebGLRenderingContext.scissor().<br/>
        /// gl.STENCIL_TEST - Deactivates stencil testing and updates to the stencil buffer. See WebGLRenderingContext.stencilFunc().<br/>
        /// <br/>
        /// When using a WebGL 2 context, the following values are available additionally:<br/>
        /// gl.RASTERIZER_DISCARD - Deactivates that primitives are discarded immediately before the rasterization stage, but after the optional transform feedback stage.gl.clear() commands are ignored.
        /// </param>
        /// <returns>A GLboolean indicating if the capability cap is enabled (true), or not (false).</returns>
        public bool IsEnabled(int cap) => JSRef!.Call<bool>("isEnabled", cap);
        /// <summary>
        /// The WebGLRenderingContext.isFramebuffer() method of the WebGL API returns true if the passed WebGLFramebuffer is valid and false otherwise.
        /// </summary>
        /// <param name="framebuffer">A WebGLFramebuffer to check.</param>
        /// <returns>A GLboolean indicating whether or not the frame buffer is valid.</returns>
        public bool IsFramebuffer(WebGLFramebuffer framebuffer) => JSRef!.Call<bool>("isFramebuffer", framebuffer);
        /// <summary>
        /// The WebGLRenderingContext.isProgram() method of the WebGL API returns true if the passed WebGLProgram is valid, false otherwise.
        /// </summary>
        /// <param name="program">A WebGLProgram to check.</param>
        /// <returns>A GLboolean indicating whether or not the program is valid.</returns>
        public bool IsProgram(WebGLProgram program) => JSRef!.Call<bool>("isProgram", program);
        /// <summary>
        /// The WebGLRenderingContext.isRenderbuffer() method of the WebGL API returns true if the passed WebGLRenderbuffer is valid and false otherwise.
        /// </summary>
        /// <param name="renderbuffer">A WebGLRenderbuffer to check.</param>
        /// <returns>A GLboolean indicating whether or not the renderbuffer is valid.</returns>
        public bool IsRenderbuffer(WebGLRenderbuffer renderbuffer) => JSRef!.Call<bool>("isRenderbuffer", renderbuffer);
        /// <summary>
        /// The WebGLRenderingContext.isShader() method of the WebGL API returns true if the passed WebGLShader is valid, false otherwise.
        /// </summary>
        /// <param name="shader">A WebGLShader to check.</param>
        /// <returns>A GLboolean indicating whether or not the shader is valid.</returns>
        public bool IsShader(WebGLShader shader) => JSRef!.Call<bool>("isShader", shader);
        /// <summary>
        /// The WebGLRenderingContext.isTexture() method of the WebGL API returns true if the passed WebGLTexture is valid and false otherwise.
        /// </summary>
        /// <param name="texture">A WebGLTexture to check.</param>
        /// <returns>A GLboolean indicating whether or not the texture is valid.</returns>
        public bool IsTexture(WebGLTexture texture) => JSRef!.Call<bool>("isTexture", texture);
        /// <summary>
        /// The WebGLRenderingContext.lineWidth() method of the WebGL API sets the line width of rasterized lines.
        /// </summary>
        /// <param name="width">A GLfloat specifying the width of rasterized lines. Default value: 1.</param>
        public void LineWidth(float width) => JSRef!.CallVoid("lineWidth", width);
        /// <summary>
        /// The WebGLRenderingContext interface's linkProgram() method links a given WebGLProgram, completing the process of preparing the GPU code for the program's fragment and vertex shaders.
        /// </summary>
        /// <param name="program">The WebGLProgram to link.</param>
        public void LinkProgram(WebGLProgram program) => JSRef!.CallVoid("linkProgram", program);
        /// <summary>
        /// The WebGLRenderingContext method makeXRCompatible() ensures that the rendering context described by the WebGLRenderingContext is ready to render the scene for the immersive WebXR device on which it will be displayed. If necessary, the WebGL layer may reconfigure the context to be ready to render to a different device than it originally was.<br/>
        /// This is useful if you have an application which can start out being presented on a standard 2D display but can then be transitioned to a 3D immersion system.
        /// </summary>
        /// <returns></returns>
        public Task MakeXRCompatible() => JSRef!.CallVoidAsync("makeXRCompatible");
        /// <summary>
        /// The WebGLRenderingContext.pixelStorei() method of the WebGL API specifies the pixel storage modes.
        /// </summary>
        /// <param name="pname">A GLenum specifying which parameter to set.</param>
        /// <param name="param">A GLint specifying a value to set the pname parameter to.</param>
        public void PixelStorei(int pname, int param) => JSRef!.CallVoid("pixelStorei", pname, param);
        /// <summary>
        /// The WebGLRenderingContext.polygonOffset() method of the WebGL API specifies the scale factors and units to calculate depth values.<br/>
        /// The offset is added before the depth test is performed and before the value is written into the depth buffer.
        /// </summary>
        /// <param name="factor">A GLfloat which sets the scale factor for the variable depth offset for each polygon. The default value is 0.</param>
        /// <param name="units">A GLfloat which sets the multiplier by which an implementation-specific value is multiplied with to create a constant depth offset. The default value is 0.</param>
        public void PolygonOffset(float factor = 0, float units = 0) => JSRef!.CallVoid("polygonOffset", factor, units);
        /// <summary>
        /// The WebGLRenderingContext.readPixels() method of the WebGL API reads a block of pixels from a specified rectangle of the current color framebuffer into a TypedArray or a DataView object.
        /// </summary>
        /// <param name="x">A GLint specifying the first horizontal pixel that is read from the lower left corner of a rectangular block of pixels.</param>
        /// <param name="y">A GLint specifying the first vertical pixel that is read from the lower left corner of a rectangular block of pixels.</param>
        /// <param name="width">A GLsizei specifying the width of the rectangle.</param>
        /// <param name="height">A GLsizei specifying the height of the rectangle.</param>
        /// <param name="format">A GLenum specifying the format of the pixel data.</param>
        /// <param name="type">A GLenum specifying the data type of the pixel data.</param>
        /// <param name="pixels">
        /// An object to read data into. The array type must match the type of the type parameter:<br/>
        /// Uint8Array for gl.UNSIGNED_BYTE.<br/>
        /// Uint16Array for gl.UNSIGNED_SHORT_5_6_5, gl.UNSIGNED_SHORT_4_4_4_4, or gl.UNSIGNED_SHORT_5_5_5_1.<br/>
        /// Float32Array for gl.FLOAT.
        /// </param>
        public void ReadPixels(int x, int y, int width, int height, int format, int type, Uint8Array pixels) => JSRef!.CallVoid("readPixels", x, y, width, height, format, type, pixels);
        /// <summary>
        /// The WebGLRenderingContext.renderbufferStorage() method of the WebGL API creates and initializes a renderbuffer object's data store.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the target renderbuffer object. Possible values:<br/>
        /// gl.RENDERBUFFER - Buffer data storage for single images in a renderable internal format.
        /// </param>
        /// <param name="internalformat">A GLenum specifying the internal format of the renderbuffer.</param>
        /// <param name="width">A GLsizei specifying the width of the renderbuffer in pixels.</param>
        /// <param name="height">A GLsizei specifying the height of the renderbuffer in pixels.</param>
        public void RenderbufferStorage(int target, int internalformat, int width, int height) => JSRef!.CallVoid("renderbufferStorage", target, internalformat, width, height);
        /// <summary>
        /// The WebGLRenderingContext.sampleCoverage() method of the WebGL API specifies multi-sample coverage parameters for anti-aliasing effects.
        /// </summary>
        /// <param name="value">A GLclampf which sets a single floating-point coverage value clamped to the range [0,1]. The default value is 1.0.</param>
        /// <param name="invert">A GLboolean which sets whether or not the coverage masks should be inverted. The default value is false.</param>
        public void SampleCoverage(float value = 1, bool invert = false) => JSRef!.CallVoid("sampleCoverage", value, invert);
        /// <summary>
        /// The WebGLRenderingContext.scissor() method of the WebGL API sets a scissor box, which limits the drawing to a specified rectangle.
        /// </summary>
        /// <param name="x">A GLint specifying the horizontal coordinate for the lower left corner of the box. Default value: 0.</param>
        /// <param name="y">A GLint specifying the vertical coordinate for the lower left corner of the box. Default value: 0.</param>
        /// <param name="width">A non-negative GLsizei specifying the width of the scissor box. Default value: width of the canvas.</param>
        /// <param name="height">A non-negative GLsizei specifying the height of the scissor box. Default value: height of the canvas.</param>
        public void Scissor(int x, int y, int width, int height) => JSRef!.CallVoid("scissor", x, y, width, height);
        /// <summary>
        /// The WebGLRenderingContext.shaderSource() method of the WebGL API sets the source code of a WebGLShader.
        /// </summary>
        /// <param name="shader">A WebGLShader object in which to set the source code.</param>
        /// <param name="source">A string containing the GLSL source code to set.</param>
        public void ShaderSource(WebGLShader shader, string source) => JSRef!.CallVoid("shaderSource", shader, source);
        /// <summary>
        /// The WebGLRenderingContext.stencilFunc() method of the WebGL API sets the front and back function and reference value for stencil testing.<br/>
        /// Stenciling enables and disables drawing on a per-pixel basis. It is typically used in multipass rendering to achieve special effects.
        /// </summary>
        /// <param name="func">
        /// A GLenum specifying the test function. The default function is gl.ALWAYS (0x0207). The possible values are:<br/>
        /// gl.NEVER - Never pass.<br/>
        /// gl.LESS - Pass if (ref & mask) < (stencil & mask).<br/>
        /// gl.EQUAL - Pass if (ref & mask) = (stencil & mask).<br/>
        /// gl.LEQUAL - Pass if (ref & mask) <= (stencil & mask).<br/>
        /// gl.GREATER - Pass if (ref & mask) > (stencil & mask).<br/>
        /// gl.NOTEQUAL - Pass if (ref & mask) !== (stencil & mask).<br/>
        /// gl.GEQUAL - Pass if (ref & mask) >= (stencil & mask).<br/>
        /// gl.ALWAYS - Always pass.<br/>
        /// </param>
        /// <param name="refValue">A GLint specifying the reference value for the stencil test. This value is clamped to the range 0 to 2^n - 1 where n is the number of bitplanes in the stencil buffer. The default value is 0.</param>
        /// <param name="mask">A GLuint specifying a bit-wise mask that is used to AND the reference value and the stored stencil value when the test is done. The default value is all 1.</param>
        public void StencilFunc(int func = 0x0207, int refValue = 0, uint mask = 1) => JSRef!.CallVoid("stencilFunc", func, refValue, mask);
        /// <summary>
        /// The WebGLRenderingContext.stencilFuncSeparate() method of the WebGL API sets the front and/or back function and reference value for stencil testing.<br/>
        /// Stencilling enables and disables drawing on a per-pixel basis. It is typically used in multipass rendering to achieve special effects.
        /// </summary>
        /// <param name="face">A GLenum specifying whether the front and/or back stencil state is updated. The possible values are:<br/>
        /// gl.FRONT<br/>
        /// gl.BACK<br/>
        /// gl.FRONT_AND_BACK</param>
        /// <param name="func">
        /// A GLenum specifying the test function. The default function is gl.ALWAYS (0x0207). The possible values are:<br/>
        /// gl.NEVER - Never pass.<br/>
        /// gl.LESS - Pass if (ref & mask) < (stencil & mask).<br/>
        /// gl.EQUAL - Pass if (ref & mask) = (stencil & mask).<br/>
        /// gl.LEQUAL - Pass if (ref & mask) <= (stencil & mask).<br/>
        /// gl.GREATER - Pass if (ref & mask) > (stencil & mask).<br/>
        /// gl.NOTEQUAL - Pass if (ref & mask) !== (stencil & mask).<br/>
        /// gl.GEQUAL - Pass if (ref & mask) >= (stencil & mask).<br/>
        /// gl.ALWAYS - Always pass.<br/>
        /// </param>
        /// <param name="refValue">A GLint specifying the reference value for the stencil test. This value is clamped to the range 0 to 2^n - 1 where n is the number of bitplanes in the stencil buffer. The default value is 0.</param>
        /// <param name="mask">A GLuint specifying a bit-wise mask that is used to AND the reference value and the stored stencil value when the test is done. The default value is all 1.</param>
        public void StencilFuncSeparate(int face, int func = 0x0207, int refValue  = 0, uint mask = 1) => JSRef!.CallVoid("stencilFuncSeparate", face, func, refValue, mask);
        /// <summary>
        /// The WebGLRenderingContext.stencilMask() method of the WebGL API controls enabling and disabling of both the front and back writing of individual bits in the stencil planes.<br/>
        /// The WebGLRenderingContext.stencilMaskSeparate() method can set front and back stencil writemasks to different values.
        /// </summary>
        /// <param name="mask">A GLuint specifying a bit mask to enable or disable writing of individual bits in the stencil planes. By default, the mask is all 1.</param>
        public void StencilMask(uint mask = 1) => JSRef!.CallVoid("stencilMask", mask);
        /// <summary>
        /// The WebGLRenderingContext.stencilMaskSeparate() method of the WebGL API controls enabling and disabling of front and/or back writing of individual bits in the stencil planes.<br/>
        /// The WebGLRenderingContext.stencilMask() method can set both, the front and back stencil writemasks to one value at the same time.
        /// </summary>
        /// <param name="face">A GLenum specifying whether the front and/or back stencil writemask is updated. The possible values are:<br/>
        /// gl.FRONT<br/>
        /// gl.BACK<br/>
        /// gl.FRONT_AND_BACK</param>
        /// <param name="mask">A GLuint specifying a bit mask to enable or disable writing of individual bits in the stencil planes. By default, the mask is all 1.</param>
        public void StencilMaskSeparate(int face, uint mask = 1) => JSRef!.CallVoid("stencilMaskSeparate", face, mask);
        /// <summary>
        /// The WebGLRenderingContext.stencilOp() method of the WebGL API sets both the front and back-facing stencil test actions.
        /// </summary>
        /// <param name="fail">A GLenum specifying the function to use when the stencil test fails. The default value is gl.KEEP.</param>
        /// <param name="zfail">A GLenum specifying the function to use when the stencil test passes, but the depth test fails. The default value is gl.KEEP.</param>
        /// <param name="zpass">A GLenum specifying the function to use when both the stencil test and the depth test pass, or when the stencil test passes and there is no depth buffer or depth testing is disabled. The default value is gl.KEEP.</param>
        public void StencilOp(int fail = 0x1E00, int zfail = 0x1E00, int zpass = 0x1E00) => JSRef!.CallVoid("stencilOp", fail, zfail, zpass);
        /// <summary>
        /// The WebGLRenderingContext.stencilOpSeparate() method of the WebGL API sets the front and/or back-facing stencil test actions.
        /// </summary>
        /// <param name="face">A GLenum specifying whether the front and/or back stencil writemask is updated. The possible values are:<br/>
        /// gl.FRONT<br/>
        /// gl.BACK<br/>
        /// gl.FRONT_AND_BACK</param>
        /// <param name="fail">A GLenum specifying the function to use when the stencil test fails. The default value is gl.KEEP.</param>
        /// <param name="zfail">A GLenum specifying the function to use when the stencil test passes, but the depth test fails. The default value is gl.KEEP.</param>
        /// <param name="zpass">A GLenum specifying the function to use when both the stencil test and the depth test pass, or when the stencil test passes and there is no depth buffer or depth testing is disabled. The default value is gl.KEEP.</param>
        public void StencilOpSeparate(int face, int fail, int zfail, int zpass) => JSRef!.CallVoid("stencilOpSeparate", face, fail, zfail, zpass);
        /// <summary>
        /// The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="border"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public void TexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, byte[] pixels) => JSRef!.CallVoid("texImage2D", target, level, internalformat, width, height, border, format, type, pixels);
        /// <summary>
        /// The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="border"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public void TexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, Uint8Array pixels) => JSRef!.CallVoid("texImage2D", target, level, internalformat, width, height, border, format, type, pixels);
        /// <summary>
        /// The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="border"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public void TexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, Uint16Array pixels) => JSRef!.CallVoid("texImage2D", target, level, internalformat, width, height, border, format, type, pixels);
        /// <summary>
        /// The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="border"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public void TexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, Uint32Array pixels) => JSRef!.CallVoid("texImage2D", target, level, internalformat, width, height, border, format, type, pixels);
        /// <summary>
        /// The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="border"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public void TexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, Float32Array pixels) => JSRef!.CallVoid("texImage2D", target, level, internalformat, width, height, border, format, type, pixels);
        /// <summary>
        /// The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="internalformat"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="source"></param>
        public void TexImage2D(int target, int level, int internalformat, int format, int type, ImageData source) => JSRef!.CallVoid("texImage2D", target, level, internalformat, format, type, source);
        /// <summary>
        /// The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="internalformat"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="source"></param>
        public void TexImage2D(int target, int level, int internalformat, int format, int type, ImageBitmap source) => JSRef!.CallVoid("texImage2D", target, level, internalformat, format, type, source);
        /// <summary>
        /// The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="internalformat"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="source"></param>
        public void TexImage2D(int target, int level, int internalformat, int format, int type, HTMLImageElement source) => JSRef!.CallVoid("texImage2D", target, level, internalformat, format, type, source);
        /// <summary>
        /// The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="internalformat"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="source"></param>
        public void TexImage2D(int target, int level, int internalformat, int format, int type, HTMLCanvasElement source) => JSRef!.CallVoid("texImage2D", target, level, internalformat, format, type, source);
        /// <summary>
        /// The WebGLRenderingContext.texImage2D() method of the WebGL API specifies a two-dimensional texture image.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="internalformat"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="source"></param>
        public void TexImage2D(int target, int level, int internalformat, int format, int type, HTMLVideoElement source) => JSRef!.CallVoid("texImage2D", target, level, internalformat, format, type, source);
        /// <summary>
        /// The WebGLRenderingContext.texParameter[fi]() methods of the WebGL API set texture parameters.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="pname"></param>
        /// <param name="param"></param>
        public void TexParameterf(int target, int pname, float param) => JSRef!.CallVoid("texParameterf", target, pname, param);
        /// <summary>
        /// The WebGLRenderingContext.texParameter[fi]() methods of the WebGL API set texture parameters.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="pname"></param>
        /// <param name="param"></param>
        public void TexParameteri(int target, int pname, int param) => JSRef!.CallVoid("texParameteri", target, pname, param);
        /// <summary>
        /// The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="xoffset"></param>
        /// <param name="yoffset"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public void TexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, byte[] pixels) => JSRef!.CallVoid("texSubImage2D", target, level, xoffset, yoffset, width, height, format, type, pixels);
        /// <summary>
        /// The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="xoffset"></param>
        /// <param name="yoffset"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public void TexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, Uint8Array pixels) => JSRef!.CallVoid("texSubImage2D", target, level, xoffset, yoffset, width, height, format, type, pixels);
        /// <summary>
        /// The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="xoffset"></param>
        /// <param name="yoffset"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public void TexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, Uint16Array pixels) => JSRef!.CallVoid("texSubImage2D", target, level, xoffset, yoffset, width, height, format, type, pixels);
        /// <summary>
        /// The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="xoffset"></param>
        /// <param name="yoffset"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public void TexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, Uint32Array pixels) => JSRef!.CallVoid("texSubImage2D", target, level, xoffset, yoffset, width, height, format, type, pixels);
        /// <summary>
        /// The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="xoffset"></param>
        /// <param name="yoffset"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public void TexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, Float32Array pixels) => JSRef!.CallVoid("texSubImage2D", target, level, xoffset, yoffset, width, height, format, type, pixels);
        /// <summary>
        /// The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="xoffset"></param>
        /// <param name="yoffset"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="source"></param>
        public void TexSubImage2D(int target, int level, int xoffset, int yoffset, int format, int type, ImageData source) => JSRef!.CallVoid("texSubImage2D", target, level, xoffset, yoffset, format, type, source);
        /// <summary>
        /// The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="xoffset"></param>
        /// <param name="yoffset"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="source"></param>
        public void TexSubImage2D(int target, int level, int xoffset, int yoffset, int format, int type, ImageBitmap source) => JSRef!.CallVoid("texSubImage2D", target, level, xoffset, yoffset, format, type, source);
        /// <summary>
        /// The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="xoffset"></param>
        /// <param name="yoffset"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="source"></param>
        public void TexSubImage2D(int target, int level, int xoffset, int yoffset, int format, int type, HTMLImageElement source) => JSRef!.CallVoid("texSubImage2D", target, level, xoffset, yoffset, format, type, source);
        /// <summary>
        /// The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="xoffset"></param>
        /// <param name="yoffset"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="source"></param>
        public void TexSubImage2D(int target, int level, int xoffset, int yoffset, int format, int type, HTMLCanvasElement source) => JSRef!.CallVoid("texSubImage2D", target, level, xoffset, yoffset, format, type, source);
        /// <summary>
        /// The WebGLRenderingContext.texSubImage2D() method of the WebGL API specifies a sub-rectangle of the current texture.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="xoffset"></param>
        /// <param name="yoffset"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="source"></param>
        public void TexSubImage2D(int target, int level, int xoffset, int yoffset, int format, int type, HTMLVideoElement source) => JSRef!.CallVoid("texSubImage2D", target, level, xoffset, yoffset, format, type, source);
        public void Uniform1f(WebGLUniformLocation location, float x) => JSRef!.CallVoid("uniform1f", location, x);
        public void Uniform1fv(WebGLUniformLocation location, IEnumerable<float> v) => JSRef!.CallVoid("uniform1fv", location, v);
        public void Uniform1i(WebGLUniformLocation location, int x) => JSRef!.CallVoid("uniform1i", location, x);
        public void Uniform1iv(WebGLUniformLocation location, IEnumerable<int> v) => JSRef!.CallVoid("uniform1iv", location, v);
        public void Uniform2f(WebGLUniformLocation location, float x, float y) => JSRef!.CallVoid("uniform2f", location, x, y);
        public void Uniform2fv(WebGLUniformLocation location, IEnumerable<float> v) => JSRef!.CallVoid("uniform2fv", location, v);
        public void Uniform2i(WebGLUniformLocation location, int x, int y) => JSRef!.CallVoid("uniform2i", location, x, y);
        public void Uniform2iv(WebGLUniformLocation location, IEnumerable<int> v) => JSRef!.CallVoid("uniform2iv", location, v);
        public void Uniform3f(WebGLUniformLocation location, float x, float y, float z) => JSRef!.CallVoid("uniform3f", location, x, y, z);
        public void Uniform3fv(WebGLUniformLocation location, IEnumerable<float> v) => JSRef!.CallVoid("uniform3fv", location, v);
        public void Uniform3i(WebGLUniformLocation location, int x, int y, int z) => JSRef!.CallVoid("uniform3i", location, x, y, z);
        public void Uniform3iv(WebGLUniformLocation location, IEnumerable<int> v) => JSRef!.CallVoid("uniform3iv", location, v);
        public void Uniform4f(WebGLUniformLocation location, float x, float y, float z, float w) => JSRef!.CallVoid("uniform4f", location, x, y, z, w);
        public void Uniform4fv(WebGLUniformLocation location, IEnumerable<float> v) => JSRef!.CallVoid("uniform4fv", location, v);
        public void Uniform4i(WebGLUniformLocation location, int x, int y, int z, int w) => JSRef!.CallVoid("uniform4i", location, x, y, z, w);
        public void Uniform4iv(WebGLUniformLocation location, IEnumerable<int> v) => JSRef!.CallVoid("uniform4iv", location, v);
        public void UniformMatrix2fv(WebGLUniformLocation location, bool transpose, IEnumerable<float> value) => JSRef!.CallVoid("uniformMatrix2fv", location, transpose, value);
        public void UniformMatrix3fv(WebGLUniformLocation location, bool transpose, IEnumerable<float> value) => JSRef!.CallVoid("uniformMatrix3fv", location, transpose, value);
        public void UniformMatrix4fv(WebGLUniformLocation location, bool transpose, IEnumerable<float> value) => JSRef!.CallVoid("uniformMatrix4fv", location, transpose, value);
        /// <summary>
        /// The WebGLRenderingContext.useProgram() method of the WebGL API sets the specified WebGLProgram as part of the current rendering state.
        /// </summary>
        /// <param name="program">A WebGLProgram to use.</param>
        public void UseProgram(WebGLProgram program) => JSRef!.CallVoid("useProgram", program);
        /// <summary>
        /// The WebGLRenderingContext.validateProgram() method of the WebGL API validates a WebGLProgram. It checks if it is successfully linked and if it can be used in the current WebGL state.
        /// </summary>
        /// <param name="program">A WebGLProgram to validate.</param>
        public void ValidateProgram(WebGLProgram program) => JSRef!.CallVoid("validateProgram", program);
        public void VertexAttrib1f(uint index, float x) => JSRef!.CallVoid("vertexAttrib1f", index, x);
        public void VertexAttrib1fv(uint index, IEnumerable<float> values) => JSRef!.CallVoid("vertexAttrib1fv", index, values);
        public void VertexAttrib2f(uint index, float x, float y) => JSRef!.CallVoid("vertexAttrib2f", index, x, y);
        public void VertexAttrib2fv(uint index, IEnumerable<float> values) => JSRef!.CallVoid("vertexAttrib2fv", index, values);
        public void VertexAttrib3f(uint index, float x, float y, float z) => JSRef!.CallVoid("vertexAttrib3f", index, x, y, z);
        public void VertexAttrib3fv(uint index, IEnumerable<float> values) => JSRef!.CallVoid("vertexAttrib3fv", index, values);
        public void VertexAttrib4f(uint index, float x, float y, float z, float w) => JSRef!.CallVoid("vertexAttrib4f", index, x, y, z, w);
        public void VertexAttrib4fv(uint index, IEnumerable<float> values) => JSRef!.CallVoid("vertexAttrib4fv", index, values);
        public void VertexAttribPointer(int index, int size, int type, bool normalized, int stride, int offset) => JSRef!.CallVoid("vertexAttribPointer", index, size, type, normalized, stride, offset);
        /// <summary>
        /// The WebGLRenderingContext.viewport() method of the WebGL API sets the viewport, which specifies the affine transformation of x and y from normalized device coordinates to window coordinates.
        /// </summary>
        /// <param name="x">A GLint specifying the horizontal coordinate for the lower left corner of the viewport origin. Default value: 0.</param>
        /// <param name="y">A GLint specifying the vertical coordinate for the lower left corner of the viewport origin. Default value: 0.</param>
        /// <param name="width">A non-negative GLsizei specifying the width of the viewport. Default value: width of the canvas.</param>
        /// <param name="height">A non-negative GLsizei specifying the height of the viewport. Default value: height of the canvas.</param>
        public void Viewport(int x, int y, int width, int height) => JSRef!.CallVoid("viewport", x, y, width, height);
        // Helper functions (non-spec) 
        public WebGLProgram CreateProgram(string vertexShader, string fragmentShader)
        {
            //vertex shader
            using var vsShader = CreateShader(VERTEX_SHADER);
            ShaderSource(vsShader, vertexShader);
            CompileShader(vsShader);
            var vsShaderSucc = GetShaderParameter<bool>(vsShader, COMPILE_STATUS);
            if (!vsShaderSucc)
            {
                var compilationLog = GetShaderInfoLog(vsShader);
                DeleteShader(vsShader);
                throw new Exception($"Error compile vertex shader for WebGLProgram. {compilationLog}");
            }
            // fragment shader
            using var psShader = CreateShader(FRAGMENT_SHADER);
            ShaderSource(psShader, fragmentShader);
            CompileShader(psShader);
            var psShaderSucc = GetShaderParameter<bool>(psShader, COMPILE_STATUS);
            if (!psShaderSucc)
            {
                var compilationLog = GetShaderInfoLog(psShader);
                DeleteShader(vsShader);
                DeleteShader(psShader);
                throw new Exception($"Error compile fragment shader for WebGLProgram. {compilationLog}");
            }
            // program
            var program = CreateProgram();
            AttachShader(program, vsShader);
            AttachShader(program, psShader);
            LinkProgram(program);
            var programSucc = GetProgramParameter<bool>(program, LINK_STATUS);
            DeleteShader(vsShader);
            DeleteShader(psShader);
            if (programSucc) return program;
            //DeleteShader(vsShader);
            //DeleteShader(psShader);
            DeleteProgram(program);
            program.Dispose();
            throw new Exception("Error creating shader program for WebGLProgram");
        }
    }
}
