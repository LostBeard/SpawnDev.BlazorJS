using Microsoft.JSInterop;
using SpawnDev.BlazorJS.Toolbox;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGL2RenderingContext interface provides the OpenGL ES 3.0 rendering context for the drawing surface of an HTML canvas element.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext
    /// TODO - Finish implementing this class.<br/>
    /// </summary>
    public partial class WebGL2RenderingContext : WebGLRenderingContext
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WebGL2RenderingContext(IJSInProcessObjectReference _ref) : base(_ref) { }

        #region State information - https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext#state_information
        /// <summary>
        /// The WebGL2RenderingContext.getIndexedParameter() method of the WebGL 2 API returns indexed information about a given target.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the target for which to return information. Possible values:<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER_BINDING: Returns a WebGLBuffer.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER_SIZE: Returns a GLsizeiptr.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER_START: Returns a GLintptr.<br/>
        /// gl.UNIFORM_BUFFER_BINDING: Returns a WebGLBuffer.<br/>
        /// gl.UNIFORM_BUFFER_SIZE: Returns a GLsizeiptr.<br/>
        /// gl.UNIFORM_BUFFER_START: Returns a GLintptr.
        /// </param>
        /// <param name="index">A GLuint specifying the index of the target that is queried.</param>
        /// <returns></returns>
        public GLuint GetIndexedParameter(GLenum target, GLuint index) => JSRef!.Call<GLuint>("getIndexedParameter", target, index);
        #endregion

        #region Buffers - https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext#buffers
        /// <summary>
        /// The WebGL2RenderingContext.bufferData() method of the WebGL API creates and initializes the buffer object's data store.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target).<br/>
        /// Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// </param>
        /// <param name="size">A GLsizeiptr setting the size in bytes of the buffer object's data store. One of size and srcData must be provided.</param>
        /// <param name="usage">
        /// A GLenum specifying the intended usage pattern of the data store for optimization purposes.<br/>
        /// Possible values:<br/>
        /// gl.STATIC_DRAW - The contents are intended to be specified once by the application, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.DYNAMIC_DRAW - The contents are intended to be respecified repeatedly by the application, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STREAM_DRAW - The contents are intended to be specified once by the application, and used at most a few times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STATIC_READ - The contents are intended to be specified once by reading data from WebGL, and queried many times by the application.<br/>
        /// gl.DYNAMIC_READ - The contents are intended to be respecified repeatedly by reading data from WebGL, and queried many times by the application.<br/>
        /// gl.STREAM_READ - The contents are intended to be specified once by reading data from WebGL, and queried at most a few times by the application<br/>
        /// gl.STATIC_COPY - The contents are intended to be specified once by reading data from WebGL, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.DYNAMIC_COPY - The contents are intended to be respecified repeatedly by reading data from WebGL, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STREAM_COPY - The contents are intended to be specified once by reading data from WebGL, and used at most a few times as the source for WebGL drawing and image specification commands.
        /// </param>
        public void BufferData(GLenum target, GLsizeiptr size, GLenum usage) => JSRef!.CallVoid("bufferData", target, size, usage);
        /// <summary>
        /// The WebGL2RenderingContext.bufferData() method of the WebGL API creates and initializes the buffer object's data store.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target).<br/>
        /// Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// </param>
        /// <param name="sourceData">A TypedArray or a DataView that views an ArrayBuffer or SharedArrayBuffer that will be copied into the data store. If null, a data store is still created, but the content is uninitialized and undefined. One of size and srcData must be provided.</param>
        /// <param name="usage">
        /// A GLenum specifying the intended usage pattern of the data store for optimization purposes.<br/>
        /// Possible values:<br/>
        /// gl.STATIC_DRAW - The contents are intended to be specified once by the application, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.DYNAMIC_DRAW - The contents are intended to be respecified repeatedly by the application, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STREAM_DRAW - The contents are intended to be specified once by the application, and used at most a few times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STATIC_READ - The contents are intended to be specified once by reading data from WebGL, and queried many times by the application.<br/>
        /// gl.DYNAMIC_READ - The contents are intended to be respecified repeatedly by reading data from WebGL, and queried many times by the application.<br/>
        /// gl.STREAM_READ - The contents are intended to be specified once by reading data from WebGL, and queried at most a few times by the application<br/>
        /// gl.STATIC_COPY - The contents are intended to be specified once by reading data from WebGL, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.DYNAMIC_COPY - The contents are intended to be respecified repeatedly by reading data from WebGL, and used many times as the source for WebGL drawing and image specification commands.<br/>
        /// gl.STREAM_COPY - The contents are intended to be specified once by reading data from WebGL, and used at most a few times as the source for WebGL drawing and image specification commands.
        /// </param>
        /// <param name="srcOffset">A GLuint specifying the element index offset where to start reading the buffer. Only allowed if srcData is provided.</param>
        /// <param name="length">A GLuint defaulting to 0. Only allowed if srcOffset is given.</param>
        public void BufferData(GLenum target, Union<TypedArray, DataView, byte[]> sourceData, GLenum usage, GLuint srcOffset = 0, GLuint length = 0)
        {
            if (length == 0) JSRef!.CallVoid("bufferData", target, sourceData, usage, srcOffset);
            else JSRef!.CallVoid("bufferData", target, sourceData, usage, srcOffset, length);
        }
        /// <summary>
        /// The WebGL2RenderingContext.bufferSubData() method of the WebGL API updates a subset of a buffer object's data store.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target).<br/>
        /// Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// </param>
        /// <param name="dstByteOffset">A GLintptr specifying an offset in bytes where the data replacement will start.</param>
        /// <param name="sourceData">A TypedArray or a DataView that views an ArrayBuffer or SharedArrayBuffer that will be copied into the data store.</param>
        /// <param name="srcOffset">A GLuint specifying the element index offset where to start reading the buffer.</param>
        /// <param name="length">A GLuint defaulting to 0, where 0 means bufferSubData should calculate the length.</param>
        public void BufferSubData(GLenum target, GLsizeiptr dstByteOffset, Union<TypedArray, DataView, byte[]> sourceData, GLuint srcOffset = 0, GLuint length = 0)
        {
            if (length == 0) JSRef!.CallVoid("bufferSubData", target, sourceData, srcOffset);
            else JSRef!.CallVoid("bufferSubData", target, sourceData, srcOffset, length);
        }
        /// <summary>
        /// The WebGL2RenderingContext.copyBufferSubData() method of the WebGL 2 API copies part of the data of a buffer to another buffer.
        /// </summary>
        /// <param name="readTarget">
        /// A GLenum specifying the binding point (target).<br/>
        /// Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// </param>
        /// <param name="writeTarget">
        /// A GLenum specifying the binding point (target).<br/>
        /// Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// </param>
        /// <param name="readOffset">A GLintptr specifying the byte offset from which to start reading from or writing to the buffer.</param>
        /// <param name="writeOffset">A GLintptr specifying the byte offset from which to start reading from or writing to the buffer.</param>
        /// <param name="size">A GLsizei in bytes specifying the size of the data to be copied from readTarget to writeTarget.</param>
        public void CopyBufferSubData(GLenum readTarget, GLenum writeTarget, GLintptr readOffset, GLintptr writeOffset, GLsizei size)
            => JSRef!.CallVoid("copyBufferSubData", readTarget, writeTarget, readOffset, writeOffset, size);
        /// <summary>
        /// The WebGL2RenderingContext.getBufferSubData() method of the WebGL 2 API reads data from a buffer binding point and writes them to an ArrayBuffer or SharedArrayBuffer.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target).<br/>
        /// Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// </param>
        /// <param name="srcByteOffset">A GLintptr specifying the byte offset from which to start reading from the buffer.</param>
        /// <param name="dstData">A TypedArray or a DataView object to copy the data to. If dstData is a DataView then dstOffset and length are interpreted in bytes, otherwise dstData's element type is used.</param>
        /// <param name="dstOffset">A GLuint specifying the element index offset to start writing in dstData.</param>
        /// <param name="length">A GLuint specifying the number of elements to copy. If this is 0 or not specified, getBufferSubData will copy until the end of dstData.</param>
        public void GetBufferSubData(GLenum target, GLintptr srcByteOffset, Union<TypedArray, DataView> dstData, GLuint dstOffset = 0, GLuint length = 0)
            => JSRef!.CallVoid("getBufferSubData", target, srcByteOffset, dstData, dstOffset, length);
        /// <summary>
        /// The WebGL2RenderingContext.getBufferSubData() method of the WebGL 2 API reads data from a buffer binding point and writes them to an ArrayBuffer or SharedArrayBuffer.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the binding point (target).<br/>
        /// Possible values:<br/>
        /// gl.ARRAY_BUFFER - Buffer containing vertex attributes, such as vertex coordinates, texture coordinate data, or vertex color data.<br/>
        /// gl.ELEMENT_ARRAY_BUFFER - Buffer used for element indices.<br/>
        /// gl.COPY_READ_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.COPY_WRITE_BUFFER - Buffer for copying from one buffer object to another.<br/>
        /// gl.TRANSFORM_FEEDBACK_BUFFER - Buffer for transform feedback operations.<br/>
        /// gl.UNIFORM_BUFFER - Buffer used for storing uniform blocks.<br/>
        /// gl.PIXEL_PACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// gl.PIXEL_UNPACK_BUFFER - Buffer used for pixel transfer operations.<br/>
        /// </param>
        /// <param name="srcByteOffset">A GLintptr specifying the byte offset from which to start reading from the buffer.</param>
        /// <param name="dstData">A TypedArray or a DataView object to copy the data to. If dstData is a DataView then dstOffset and length are interpreted in bytes, otherwise dstData's element type is used.</param>
        /// <param name="dstOffset">A GLuint specifying the element index offset to start writing in dstData.</param>
        /// <param name="length">A GLuint specifying the number of elements to copy. If this is 0 or not specified, getBufferSubData will copy until the end of dstData.</param>
        public void GetBufferSubData(GLenum target, GLintptr srcByteOffset, byte[] dstData, GLuint dstOffset = 0, GLuint length = 0)
        {
            // pin the array using HeapView so it doesn't get moved by the GC while we're working with it 
            using var heapView = new HeapView<byte>(dstData);
            JSRef!.CallVoid("getBufferSubData", target, srcByteOffset, heapView, dstOffset, length);
        }
        #endregion

        #region Framebuffers - https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext#framebuffers
        /// <summary>
        /// The WebGL2RenderingContext.blitFramebuffer() method of the WebGL 2 API transfers a block of pixels from the read framebuffer to the draw framebuffer. Read and draw framebuffers are bound using WebGLRenderingContext.bindFramebuffer().
        /// </summary>
        /// <param name="srcX0">A GLint specifying the bounds of the source rectangle.</param>
        /// <param name="srcY0">A GLint specifying the bounds of the source rectangle.</param>
        /// <param name="srcX1">A GLint specifying the bounds of the source rectangle.</param>
        /// <param name="srcY1">A GLint specifying the bounds of the source rectangle.</param>
        /// <param name="dstX0">A GLint specifying the bounds of the destination rectangle.</param>
        /// <param name="dstY0">A GLint specifying the bounds of the destination rectangle.</param>
        /// <param name="dstX1">A GLint specifying the bounds of the destination rectangle.</param>
        /// <param name="dstY1">A GLint specifying the bounds of the destination rectangle.</param>
        /// <param name="mask">A GLbitfield specifying a bitwise OR mask indicating which buffers are to be copied. Possible values:<br/>
        /// gl.COLOR_BUFFER_BIT<br/>
        /// gl.DEPTH_BUFFER_BIT<br/>
        /// gl.STENCIL_BUFFER_BIT
        /// </param>
        /// <param name="filter">A GLenum specifying the interpolation to be applied if the image is stretched. Possible values:<br/>
        /// gl.NEAREST<br/>
        /// gl.LINEAR</param>
        public void BlitFramebuffer(GLint srcX0, GLint srcY0, GLint srcX1, GLint srcY1, GLint dstX0, GLint dstY0, GLint dstX1, GLint dstY1, GLbitfield mask, GLenum filter) => JSRef!.CallVoid("blitFramebuffer", srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
        /// <summary>
        /// The WebGL2RenderingContext.framebufferTextureLayer() method of the WebGL 2 API attaches a single layer of a texture to a framebuffer.<br/>
        /// This method is similar to WebGLRenderingContext.framebufferTexture2D(), but only a given single layer of the texture level is attached to the attachment point.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.FRAMEBUFFER: Collection buffer data storage of color, alpha, depth and stencil buffers used to render an image.<br/>
        /// gl.DRAW_FRAMEBUFFER: Equivalent to gl.FRAMEBUFFER.<br/>
        /// gl.READ_FRAMEBUFFER: Used as a source for reading operations.
        /// </param>
        /// <param name="attachment">A GLenum specifying the attachment point for the texture. Possible values:<br/>
        /// gl.COLOR_ATTACHMENT{0-15}: Attaches the texture to one of the framebuffer's color buffers.<br/>
        /// gl.DEPTH_ATTACHMENT: Attaches the texture to the framebuffer's depth buffer.<br/>
        /// gl.STENCIL_ATTACHMENT: Attaches the texture to the framebuffer's stencil buffer.<br/>
        /// gl.DEPTH_STENCIL_ATTACHMENT: depth and stencil buffer.
        /// </param>
        /// <param name="texture">A WebGLTexture object whose image to attach.</param>
        /// <param name="level">A GLint specifying the mipmap level of the texture image to attach.</param>
        /// <param name="layer">A GLint specifying the layer of the texture image to attach.</param>
        public void FramebufferTextureLayer(GLenum target, GLenum attachment, WebGLTexture texture, GLint level, GLint layer) => JSRef!.CallVoid("framebufferTextureLayer", target, attachment, texture, level, layer);
        /// <summary>
        /// The WebGL2RenderingContext.invalidateFramebuffer() method of the WebGL 2 API invalidates the contents of attachments in a framebuffer.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.FRAMEBUFFER: Collection buffer data storage of color, alpha, depth and stencil buffers used to render an image.<br/>
        /// gl.DRAW_FRAMEBUFFER: Equivalent to gl.FRAMEBUFFER.<br/>
        /// gl.READ_FRAMEBUFFER: Used as a source for reading operations.
        /// </param>
        /// <param name="attachments">An Array of GLenum specifying the attachment points to invalidate. Possible values:<br/>
        /// gl.COLOR_ATTACHMENT{0-15}: Attaches the texture to one of the framebuffer's color buffers.<br/>
        /// gl.DEPTH_ATTACHMENT: Attaches the texture to the framebuffer's depth buffer.<br/>
        /// gl.STENCIL_ATTACHMENT: Attaches the texture to the framebuffer's stencil buffer.<br/>
        /// gl.DEPTH_STENCIL_ATTACHMENT: depth and stencil buffer.
        /// </param>
        public void InvalidateFramebuffer(GLenum target, GLenum[] attachments) => JSRef!.CallVoid("invalidateFramebuffer", target, attachments);
        /// <summary>
        /// The WebGL2RenderingContext.invalidateSubFramebuffer() method of the WebGL 2 API invalidates portions of the contents of attachments in a framebuffer.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target). Possible values:<br/>
        /// gl.FRAMEBUFFER: Collection buffer data storage of color, alpha, depth and stencil buffers used to render an image.<br/>
        /// gl.DRAW_FRAMEBUFFER: Equivalent to gl.FRAMEBUFFER.<br/>
        /// gl.READ_FRAMEBUFFER: Used as a source for reading operations.
        /// </param>
        /// <param name="attachments">An Array of GLenum specifying the attachment points to invalidate. Possible values:<br/>
        /// gl.COLOR_ATTACHMENT{0-15}: Attaches the texture to one of the framebuffer's color buffers.<br/>
        /// gl.DEPTH_ATTACHMENT: Attaches the texture to the framebuffer's depth buffer.<br/>
        /// gl.STENCIL_ATTACHMENT: Attaches the texture to the framebuffer's stencil buffer.<br/>
        /// gl.DEPTH_STENCIL_ATTACHMENT: depth and stencil buffer.
        /// </param>
        /// <param name="x">A GLint specifying the left origin of the pixel rectangle to invalidate.</param>
        /// <param name="y">A GLint specifying the bottom origin of the pixel rectangle to invalidate.</param>
        /// <param name="width">A GLsizei specifying the width of the pixel rectangle to invalidate.</param>
        /// <param name="height">A GLsizei specifying the height of the pixel rectangle to invalidate.</param>
        public void InvalidateSubFramebuffer(GLenum target, GLenum[] attachments, GLint x, GLint y, GLsizei width, GLsizei height) => JSRef!.CallVoid("invalidateSubFramebuffer", target, attachments, x, y, width, height);
        /// <summary>
        /// The WebGL2RenderingContext.readBuffer() method of the WebGL 2 API selects a color buffer as the source for pixels for subsequent calls to copyTexImage2D, copyTexSubImage2D, copyTexSubImage3D or readPixels.
        /// </summary>
        /// <param name="source">A GLenum specifying a color buffer. Possible values:<br/>
        /// gl.BACK - Reads from the back color buffer.
        /// gl.NONE - Reads from no color buffer.
        /// gl.COLOR_ATTACHMENT{0 - 15} - Reads from one of the 16 color attachment buffers.</param>
        public void ReadBuffer(GLenum source) => JSRef!.CallVoid("readBuffer", source);
        #endregion

        #region Renderbuffers - https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext#renderbuffers
        /// <summary>
        /// The WebGL2RenderingContext.getInternalformatParameter() method of the WebGL 2 API returns information about implementation-dependent support for internal formats.
        /// </summary>
        /// <param name="target">A GLenum specifying the target renderbuffer object. Possible values:<br/>
        ///  gl.RENDERBUFFER - Buffer data storage for single images in a renderable internal format.</param>
        /// <param name="internalformat">A GLenum specifying the internal format about which to retrieve information (must be a color-renderable, depth-renderable or stencil-renderable format).</param>
        /// <param name="pname">A GLenum specifying the type of information to query. Possible values:<br/>
        /// gl.SAMPLES - Returns an Int32Array containing sample counts supported for internalformat in descending order.</param>
        public Int32Array GetInternalformatParameter(GLenum target, GLenum internalformat, GLenum pname) => JSRef!.Call<Int32Array>("getInternalformatParameter", target, internalformat, pname);
        /// <summary>
        /// The WebGL2RenderingContext.getInternalformatParameter() method of the WebGL 2 API returns information about implementation-dependent support for internal formats.
        /// </summary>
        /// <param name="target">A GLenum specifying the target renderbuffer object. Possible values:<br/>
        ///  gl.RENDERBUFFER - Buffer data storage for single images in a renderable internal format.</param>
        /// <param name="internalformat">A GLenum specifying the internal format about which to retrieve information (must be a color-renderable, depth-renderable or stencil-renderable format).</param>
        /// <param name="pname">A GLenum specifying the type of information to query. Possible values:<br/>
        /// gl.SAMPLES - Returns an Int32Array containing sample counts supported for internalformat in descending order.</param>
        public T GetInternalformatParameter<T>(GLenum target, GLenum internalformat, GLenum pname) => JSRef!.Call<T>("getInternalformatParameter", target, internalformat, pname);
        /// <summary>
        /// The WebGL2RenderingContext.renderbufferStorageMultisample() method of the WebGL 2 API returns creates and initializes a renderbuffer object's data store and allows specifying a number of samples to be used.
        /// </summary>
        /// <param name="target">A GLenum specifying the target renderbuffer object. Possible values:<br/>
        ///  gl.RENDERBUFFER - Buffer data storage for single images in a renderable internal format.</param>
        /// <param name="samples">A GLsizei specifying the number of samples to be used for the renderbuffer storage.</param>
        /// <param name="internalFormat">A GLenum specifying the internal format of the renderbuffer. Possible values (gl.DEPTH_STENCIL is not supported):<br/>
        /// gl.R8<br/>
        /// gl.R8UI<br/>
        /// gl.R8I<br/>
        /// gl.R16UI<br/>
        /// gl.R16I<br/>
        /// gl.R32UI<br/>
        /// gl.R32I<br/>
        /// gl.RG8<br/>
        /// gl.RG8UI<br/>
        /// gl.RG8I<br/>
        /// gl.RG16UI<br/>
        /// gl.RG16I<br/>
        /// gl.RG32UI<br/>
        /// gl.RG32I<br/>
        /// gl.RGB8<br/>
        /// gl.RGBA8<br/>
        /// gl.SRGB8_ALPHA8<br/>
        /// gl.RGBA4<br/>
        /// gl.RGB565<br/>
        /// gl.RGB5_A1<br/>
        /// gl.RGB10_A2<br/>
        /// gl.RGBA8UI<br/>
        /// gl.RGBA8I<br/>
        /// gl.RGB10_A2UI<br/>
        /// gl.RGBA16UI<br/>
        /// gl.RGBA16I<br/>
        /// gl.RGBA32I<br/>
        /// gl.RGBA32UI<br/>
        /// gl.DEPTH_COMPONENT16<br/>
        /// gl.DEPTH_COMPONENT24<br/>
        /// gl.DEPTH_COMPONENT32F<br/>
        /// gl.DEPTH_STENCIL<br/>
        /// gl.DEPTH24_STENCIL8<br/>
        /// gl.DEPTH32F_STENCIL8<br/>
        /// gl.STENCIL_INDEX8
        /// </param>
        /// <param name="width">A GLsizei specifying the width of the renderbuffer in pixels.</param>
        /// <param name="height">A GLsizei specifying the height of the renderbuffer in pixels.</param>
        public void RenderbufferStorageMultisample(GLenum target, GLsizei samples, GLenum internalFormat, GLsizei width, GLsizei height) => JSRef!.CallVoid("renderbufferStorageMultisample", target, samples, internalFormat, width, height);
        #endregion

        #region Textures - https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext#textures
        /// <summary>
        /// The texStorage2D() method of the WebGL2RenderingContext of the WebGL API specifies all levels of two-dimensional texture storage.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_2D: A two-dimensional texture.<br/>
        /// gl.TEXTURE_CUBE_MAP: A cube-mapped texture.</param>
        /// <param name="levels">A GLint specifying the number of texture levels.</param>
        /// <param name="internalformat">A GLenum specifying the texture store format. Possible values:<br/>
        /// gl.R8<br/>
        /// gl.R8_SNORM<br/>
        /// gl.R16F<br/>
        /// gl.R32F<br/>
        /// gl.R8UI<br/>
        /// gl.R8I<br/>
        /// gl.R16UI<br/>
        /// gl.R16I<br/>
        /// gl.R32UI<br/>
        /// gl.R32I<br/>
        /// gl.RG8<br/>
        /// gl.RG8_SNORM<br/>
        /// gl.RG16F<br/>
        /// gl.RG32F<br/>
        /// gl.RG8UI<br/>
        /// gl.RG8I<br/>
        /// gl.RG16UI<br/>
        /// gl.RG16I<br/>
        /// gl.RG32UI<br/>
        /// gl.RG32I<br/>
        /// gl.RGB8<br/>
        /// gl.SRGB8<br/>
        /// gl.RGB565<br/>
        /// gl.RGB8_SNORM<br/>
        /// gl.R11F_G11F_B10F<br/>
        /// gl.RGB9_E5<br/>
        /// gl.RGB16F<br/>
        /// gl.RGB32F<br/>
        /// gl.RGB8UI<br/>
        /// gl.RGB8I<br/>
        /// gl.RGB16UI<br/>
        /// gl.RGB16I<br/>
        /// gl.RGB32UI<br/>
        /// gl.RGB32I<br/>
        /// gl.RGBA8<br/>
        /// gl.SRGB8_ALPHA8<br/>
        /// gl.RGBA8_SNORM<br/>
        /// gl.RGB5_A1<br/>
        /// gl.RGBA4<br/>
        /// gl.RGB10_A2<br/>
        /// gl.RGBA16F<br/>
        /// gl.RGBA32F<br/>
        /// gl.RGBA8UI<br/>
        /// gl.RGBA8I<br/>
        /// gl.RGB10_A2UI<br/>
        /// gl.RGBA16UI<br/>
        /// gl.RGBA16I<br/>
        /// gl.RGBA32UI<br/>
        /// gl.RGBA32I<br/>
        /// gl.DEPTH_COMPONENT16<br/>
        /// gl.DEPTH_COMPONENT24<br/>
        /// gl.DEPTH_COMPONENT32F<br/>
        /// gl.DEPTH24_STENCIL8<br/>
        /// gl.DEPTH32F_STENCIL8
        /// </param>
        /// <param name="width">A GLsizei specifying the width of the texture in texels.</param>
        /// <param name="height">A GLsizei specifying the height of the texture in texels.</param>
        public void TexStorage2D(GLenum target, GLint levels, GLenum internalformat, GLsizei width, GLsizei height) => JSRef!.CallVoid("texStorage2D", target, levels, internalformat, width, height);
        /// <summary>
        /// The texStorage3D() method of the WebGL2RenderingContext of the WebGL API specifies all levels of three-dimensional texture storage.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_3D: A three-dimensional texture.
        /// gl.TEXTURE_2D_ARRAY: A two-dimensional array texture.</param>
        /// <param name="levels">A GLint specifying the number of texture levels.</param>
        /// <param name="internalformat">A GLenum specifying the texture store format. For a list of possible values, see WebGL2RenderingContext.texStorage2D().</param>
        /// <param name="width">A GLsizei specifying the width of the texture in texels.</param>
        /// <param name="height">A GLsizei specifying the height of the texture in texels.</param>
        /// <param name="depth">A GLsizei specifying the depth of the texture/the number of textures in a TEXTURE_2D_ARRAY.</param>
        public void TexStorage3D(GLenum target, GLint levels, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth) => JSRef!.CallVoid("texStorage3D", target, levels, internalformat, width, height, depth);
        /// <summary>
        /// The texImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional texture image.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_3D: A three-dimensional texture.
        /// gl.TEXTURE_2D_ARRAY: A two-dimensional array texture.</param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="internalformat">A GLenum specifying how the texture should be stored after it's loaded.</param>
        /// <param name="width">A GLsizei specifying the width of the texture in texels.</param>
        /// <param name="height">A GLsizei specifying the height of the texture in texels.</param>
        /// <param name="depth">A GLsizei specifying the depth of the texture/the number of textures in a TEXTURE_2D_ARRAY.</param>
        /// <param name="border">A GLint specifying the width of the border. Must be 0.</param>
        /// <param name="format">A GLenum specifying how each integer element in the raw texel data should be interpreted as color components.</param>
        /// <param name="type">A GLenum specifying the size of each integer element in the raw texel data.</param>
        /// <param name="srcData">A TypedArray or DataView containing the compressed texture data. Its type must match the type parameter; see WebGLRenderingContext.texImage2D(). When type is FLOAT_32_UNSIGNED_INT_24_8_REV, srcData must be null.</param>
        /// <param name="srcOffset">An integer specifying the index of srcData to start reading from. Defaults to 0.</param>
        public void TexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, Union<TypedArray, DataView> srcData, GLint srcOffset = 0)
            => JSRef!.CallVoid("texImage3D", target, level, internalformat, width, height, depth, border, format, type, srcData, srcOffset);
        /// <summary>
        /// The texImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional texture image.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_3D: A three-dimensional texture.
        /// gl.TEXTURE_2D_ARRAY: A two-dimensional array texture.</param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="internalformat">A GLenum specifying how the texture should be stored after it's loaded.</param>
        /// <param name="width">A GLsizei specifying the width of the texture in texels.</param>
        /// <param name="height">A GLsizei specifying the height of the texture in texels.</param>
        /// <param name="depth">A GLsizei specifying the depth of the texture/the number of textures in a TEXTURE_2D_ARRAY.</param>
        /// <param name="border">A GLint specifying the width of the border. Must be 0.</param>
        /// <param name="format">A GLenum specifying how each integer element in the raw texel data should be interpreted as color components.</param>
        /// <param name="type">A GLenum specifying the size of each integer element in the raw texel data.</param>
        /// <param name="source">Read from a DOM pixel source</param>
        public void TexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, Union<ImageBitmap, ImageData, HTMLImageElement, HTMLCanvasElement, HTMLVideoElement, OffscreenCanvas, VideoFrame> source)
            => JSRef!.CallVoid("texImage3D", target, level, internalformat, width, height, depth, border, format, type, source);
        /// <summary>
        /// The texImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional texture image.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_3D: A three-dimensional texture.
        /// gl.TEXTURE_2D_ARRAY: A two-dimensional array texture.</param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="internalformat">A GLenum specifying how the texture should be stored after it's loaded.</param>
        /// <param name="width">A GLsizei specifying the width of the texture in texels.</param>
        /// <param name="height">A GLsizei specifying the height of the texture in texels.</param>
        /// <param name="depth">A GLsizei specifying the depth of the texture/the number of textures in a TEXTURE_2D_ARRAY.</param>
        /// <param name="border">A GLint specifying the width of the border. Must be 0.</param>
        /// <param name="format">A GLenum specifying how each integer element in the raw texel data should be interpreted as color components.</param>
        /// <param name="type">A GLenum specifying the size of each integer element in the raw texel data.</param>
        /// <param name="offset">A GLintptr specifying the starting address in the buffer bound to gl.PIXEL_UNPACK_BUFFER.</param>
        public void TexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, GLintptr offset)
            => JSRef!.CallVoid("texImage3D", target, level, internalformat, width, height, depth, border, format, type, offset);

        /// <summary>
        /// The texSubImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional sub-rectangle for a texture image.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_3D: A three-dimensional texture.
        /// gl.TEXTURE_2D_ARRAY: A two-dimensional array texture.</param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="xoffset">A GLint specifying the x offset within the texture image.</param>
        /// <param name="yoffset">A GLint specifying the y offset within the texture image.</param>
        /// <param name="zoffset">A GLint specifying the z offset within the texture image.</param>
        /// <param name="width">A GLsizei specifying the width of the texture in texels.</param>
        /// <param name="height">A GLsizei specifying the height of the texture in texels.</param>
        /// <param name="depth">A GLsizei specifying the depth of the texture/the number of textures in a TEXTURE_2D_ARRAY.</param>
        /// <param name="format">A GLenum specifying how each integer element in the raw texel data should be interpreted as color components.</param>
        /// <param name="type">A GLenum specifying the size of each integer element in the raw texel data. For the combinations of format and type available, see WebGLRenderingContext.texSubImage2D().</param>
        /// <param name="srcData">A TypedArray or DataView containing the compressed texture data. Its type must match the type parameter; see WebGLRenderingContext.texImage2D().</param>
        /// <param name="srcOffset">An integer specifying the index of srcData to start reading from. Defaults to 0.</param>
        public void TexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, Union<TypedArray, DataView> srcData, GLint srcOffset = 0)
            => JSRef!.CallApplyVoid("texSubImage3D", new object[] { target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, srcData, srcOffset });
        /// <summary>
        /// The texSubImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional sub-rectangle for a texture image.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_3D: A three-dimensional texture.
        /// gl.TEXTURE_2D_ARRAY: A two-dimensional array texture.</param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="xoffset">A GLint specifying the x offset within the texture image.</param>
        /// <param name="yoffset">A GLint specifying the y offset within the texture image.</param>
        /// <param name="zoffset">A GLint specifying the z offset within the texture image.</param>
        /// <param name="width">A GLsizei specifying the width of the texture in texels.</param>
        /// <param name="height">A GLsizei specifying the height of the texture in texels.</param>
        /// <param name="depth">A GLsizei specifying the depth of the texture/the number of textures in a TEXTURE_2D_ARRAY.</param>
        /// <param name="format">A GLenum specifying how each integer element in the raw texel data should be interpreted as color components.</param>
        /// <param name="type">A GLenum specifying the size of each integer element in the raw texel data. For the combinations of format and type available, see WebGLRenderingContext.texSubImage2D().</param>
        /// <param name="source">Read from a DOM pixel source</param>
        public void TexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, Union<ImageBitmap, ImageData, HTMLImageElement, HTMLCanvasElement, HTMLVideoElement, OffscreenCanvas, VideoFrame> source)
            => JSRef!.CallVoid("texSubImage3D", target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, source);
        /// <summary>
        /// The texSubImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional sub-rectangle for a texture image.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_3D: A three-dimensional texture.
        /// gl.TEXTURE_2D_ARRAY: A two-dimensional array texture.</param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="xoffset">A GLint specifying the x offset within the texture image.</param>
        /// <param name="yoffset">A GLint specifying the y offset within the texture image.</param>
        /// <param name="zoffset">A GLint specifying the z offset within the texture image.</param>
        /// <param name="width">A GLsizei specifying the width of the texture in texels.</param>
        /// <param name="height">A GLsizei specifying the height of the texture in texels.</param>
        /// <param name="depth">A GLsizei specifying the depth of the texture/the number of textures in a TEXTURE_2D_ARRAY.</param>
        /// <param name="format">A GLenum specifying how each integer element in the raw texel data should be interpreted as color components.</param>
        /// <param name="type">A GLenum specifying the size of each integer element in the raw texel data. For the combinations of format and type available, see WebGLRenderingContext.texSubImage2D().</param>
        /// <param name="offset">A GLintptr specifying the starting address in the buffer bound to gl.PIXEL_UNPACK_BUFFER.</param>
        public void TexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, GLint offset)
            => JSRef!.CallVoid("texSubImage3D", target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, offset);
        /// <summary>
        /// The copyTexSubImage3D() method of the WebGL2RenderingContext interface of the WebGL API copies pixels from the current WebGLFramebuffer into a 3D texture sub-image.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_3D: A three-dimensional texture.
        /// gl.TEXTURE_2D_ARRAY: A two-dimensional array texture.</param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="xoffset">A GLint specifying the x offset within the texture image.</param>
        /// <param name="yoffset">A GLint specifying the y offset within the texture image.</param>
        /// <param name="zoffset">A GLint specifying the z offset within the texture image.</param>
        /// <param name="x">A GLint specifying the x coordinate of the lower left corner where to start copying.</param>
        /// <param name="y">A GLint specifying the y coordinate of the lower left corner where to start copying.</param>
        /// <param name="width">A GLsizei specifying the width of the texture in texels.</param>
        /// <param name="height">A GLsizei specifying the height of the texture in texels.</param>
        public void CopyTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height)
            => JSRef!.CallVoid("copyTexSubImage3D", target, level, xoffset, yoffset, zoffset, x, y, width, height);
        /// <summary>
        /// The compressedTexImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional texture image in a compressed format.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_3D: A three-dimensional texture.
        /// gl.TEXTURE_2D_ARRAY: A two-dimensional array texture.</param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="internalformat">A GLenum specifying the compressed image format. For a list of possible values, see WebGLRenderingContext.compressedTexImage2D().</param>
        /// <param name="width">A GLsizei specifying the width of the texture in texels.</param>
        /// <param name="height">A GLsizei specifying the height of the texture in texels.</param>
        /// <param name="depth">A GLsizei specifying the depth of the texture/the number of textures in a TEXTURE_2D_ARRAY.</param>
        /// <param name="border">A GLint specifying the width of the border. Must be 0.</param>
        /// <param name="imageSize">A GLsizei specifying the size of the image data in bytes.</param>
        /// <param name="offset">A GLintptr specifying the starting address in the buffer bound to gl.PIXEL_UNPACK_BUFFER.</param>
        public void CompressedTexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, GLintptr offset)
            => JSRef!.CallVoid("compressedTexImage3D", target, level, internalformat, width, height, depth, border, imageSize, offset);
        /// <summary>
        /// The compressedTexImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional texture image in a compressed format.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_3D: A three-dimensional texture.
        /// gl.TEXTURE_2D_ARRAY: A two-dimensional array texture.</param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="internalformat">A GLenum specifying the compressed image format. For a list of possible values, see WebGLRenderingContext.compressedTexImage2D().</param>
        /// <param name="width">A GLsizei specifying the width of the texture in texels.</param>
        /// <param name="height">A GLsizei specifying the height of the texture in texels.</param>
        /// <param name="depth">A GLsizei specifying the depth of the texture/the number of textures in a TEXTURE_2D_ARRAY.</param>
        /// <param name="border">A GLint specifying the width of the border. Must be 0.</param>
        /// <param name="srcData">A TypedArray or DataView containing the compressed texture data.</param>
        /// <param name="srcOffset">An integer specifying the index of srcData to start reading from. Defaults to 0.</param>
        public void CompressedTexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, Union<TypedArray, DataView> srcData, GLint srcOffset = 0)
            => JSRef!.CallVoid("compressedTexImage3D", target, level, internalformat, width, height, depth, border, srcData, srcOffset);
        /// <summary>
        /// The compressedTexImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional texture image in a compressed format.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_3D: A three-dimensional texture.
        /// gl.TEXTURE_2D_ARRAY: A two-dimensional array texture.</param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="internalformat">A GLenum specifying the compressed image format. For a list of possible values, see WebGLRenderingContext.compressedTexImage2D().</param>
        /// <param name="width">A GLsizei specifying the width of the texture in texels.</param>
        /// <param name="height">A GLsizei specifying the height of the texture in texels.</param>
        /// <param name="depth">A GLsizei specifying the depth of the texture/the number of textures in a TEXTURE_2D_ARRAY.</param>
        /// <param name="border">A GLint specifying the width of the border. Must be 0.</param>
        /// <param name="srcData">A TypedArray or DataView containing the compressed texture data.</param>
        /// <param name="srcOffset">An integer specifying the index of srcData to start reading from. Defaults to 0.</param>
        /// <param name="srcLengthOverride">An integer specifying the number of elements in srcData to read. Defaults to srcData.length - srcOffset.</param>
        public void CompressedTexImage3D(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, Union<TypedArray, DataView> srcData, GLint srcOffset, GLintptr srcLengthOverride)
            => JSRef!.CallVoid("compressedTexImage3D", target, level, internalformat, width, height, depth, border, srcData, srcOffset, srcLengthOverride);
        /// <summary>
        /// The compressedTexSubImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional sub-rectangle for a texture image in a compressed format.<br/>
        /// Compressed image formats are only available via some WebGL extension.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_3D: A three-dimensional texture.
        /// gl.TEXTURE_2D_ARRAY: A two-dimensional array texture.</param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="xoffset">A GLint specifying the x offset within the compressed texture image.</param>
        /// <param name="yoffset">A GLint specifying the y offset within the compressed texture image.</param>
        /// <param name="zoffset">A GLint specifying the z offset within the compressed texture image.</param>
        /// <param name="width">A GLsizei specifying the width of the compressed texture in texels.</param>
        /// <param name="height">A GLsizei specifying the height of the compressed texture in texels.</param>
        /// <param name="depth">A GLsizei specifying the depth of the texture/the number of textures in a TEXTURE_2D_ARRAY.</param>
        /// <param name="format">A GLenum specifying the compressed image format. For a list of possible values, see WebGLRenderingContext.compressedTexImage2D().</param>
        /// <param name="imageSize">A GLsizei specifying the size of the image data in bytes.</param>
        /// <param name="offset">A GLintptr specifying the starting address in the buffer bound to gl.PIXEL_UNPACK_BUFFER.</param>
        public void CompressedTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, GLintptr offset)
            => JSRef!.CallVoid("compressedTexSubImage3D", target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, offset);
        /// <summary>
        /// The compressedTexSubImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional sub-rectangle for a texture image in a compressed format.<br/>
        /// Compressed image formats are only available via some WebGL extension.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_3D: A three-dimensional texture.
        /// gl.TEXTURE_2D_ARRAY: A two-dimensional array texture.</param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="xoffset">A GLint specifying the x offset within the compressed texture image.</param>
        /// <param name="yoffset">A GLint specifying the y offset within the compressed texture image.</param>
        /// <param name="zoffset">A GLint specifying the z offset within the compressed texture image.</param>
        /// <param name="width">A GLsizei specifying the width of the compressed texture in texels.</param>
        /// <param name="height">A GLsizei specifying the height of the compressed texture in texels.</param>
        /// <param name="depth">A GLsizei specifying the depth of the texture/the number of textures in a TEXTURE_2D_ARRAY.</param>
        /// <param name="format">A GLenum specifying the compressed image format. For a list of possible values, see WebGLRenderingContext.compressedTexImage2D().</param>
        /// <param name="srcData">A TypedArray or DataView containing the compressed texture data.</param>
        /// <param name="srcOffset">An integer specifying the index of srcData to start reading from. Defaults to 0.</param>
        public void CompressedTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, Union<TypedArray, DataView> srcData, GLint srcOffset = 0)
            => JSRef!.CallVoid("compressedTexSubImage3D", target, level, xoffset, yoffset, zoffset, width, height, depth, format, srcData, srcOffset);
        /// <summary>
        /// The compressedTexSubImage3D() method of the WebGL2RenderingContext interface of the WebGL API specifies a three-dimensional sub-rectangle for a texture image in a compressed format.<br/>
        /// Compressed image formats are only available via some WebGL extension.
        /// </summary>
        /// <param name="target">A GLenum specifying the binding point (target) of the active texture. Possible values:<br/>
        /// gl.TEXTURE_3D: A three-dimensional texture.
        /// gl.TEXTURE_2D_ARRAY: A two-dimensional array texture.</param>
        /// <param name="level">A GLint specifying the level of detail. Level 0 is the base image level and level n is the n-th mipmap reduction level.</param>
        /// <param name="xoffset">A GLint specifying the x offset within the compressed texture image.</param>
        /// <param name="yoffset">A GLint specifying the y offset within the compressed texture image.</param>
        /// <param name="zoffset">A GLint specifying the z offset within the compressed texture image.</param>
        /// <param name="width">A GLsizei specifying the width of the compressed texture in texels.</param>
        /// <param name="height">A GLsizei specifying the height of the compressed texture in texels.</param>
        /// <param name="depth">A GLsizei specifying the depth of the texture/the number of textures in a TEXTURE_2D_ARRAY.</param>
        /// <param name="format">A GLenum specifying the compressed image format. For a list of possible values, see WebGLRenderingContext.compressedTexImage2D().</param>
        /// <param name="srcData">A TypedArray or DataView containing the compressed texture data.</param>
        /// <param name="srcOffset">An integer specifying the index of srcData to start reading from. Defaults to 0.</param>
        /// <param name="srcLengthOverride">An integer specifying the number of elements in srcData to read. Defaults to srcData.length - srcOffset.</param>
        public void CompressedTexSubImage3D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, Union<TypedArray, DataView> srcData, GLint srcOffset, GLint srcLengthOverride)
            => JSRef!.CallApplyVoid("compressedTexSubImage3D", new object?[] { target, level, xoffset, yoffset, zoffset, width, height, depth, format, srcData, srcOffset, srcLengthOverride });
        #endregion

        #region Programs and shaders - https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext#programs_and_shaders
        /// <summary>
        /// The WebGL2RenderingContext.getFragDataLocation() method of the WebGL 2 API returns the binding of color numbers to user-defined varying out variables.
        /// </summary>
        /// <param name="program">A WebGLProgram to query.</param>
        /// <param name="name">A string specifying the name of the user-defined varying out variable.</param>
        /// <returns>A GLint indicating the assigned color number binding, or -1 otherwise.</returns>
        public GLint GetFragDataLocation(WebGLProgram program, string name) => JSRef!.Call<GLint>("getFragDataLocation", program, name);
        #endregion

        #region Uniforms and attributes - https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext#uniforms_and_attributes
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform1ui(WebGLUniformLocation location, uint v0) => JSRef!.CallVoid("uniform1ui", location, v0);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform2ui(WebGLUniformLocation location, uint v0, uint v1) => JSRef!.CallVoid("uniform2ui", location, v0, v1);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform3ui(WebGLUniformLocation location, uint v0, uint v1, uint v2) => JSRef!.CallVoid("uniform3ui", location, v0, v1, v2);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform4ui(WebGLUniformLocation location, uint v0, uint v1, uint v2, uint v3) => JSRef!.CallVoid("uniform4ui", location, v0, v1, v2, v3);

        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform1fv(WebGLUniformLocation location, float[] data, int srcOffset = 0) => JSRef!.CallVoid("uniform1fv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform1fv(WebGLUniformLocation location, float[] data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform1fv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform2fv(WebGLUniformLocation location, float[] data, int srcOffset = 0) => JSRef!.CallVoid("uniform2fv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform2fv(WebGLUniformLocation location, float[] data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform2fv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform3fv(WebGLUniformLocation location, float[] data, int srcOffset = 0) => JSRef!.CallVoid("uniform3fv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform3fv(WebGLUniformLocation location, float[] data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform3fv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform4fv(WebGLUniformLocation location, float[] data, int srcOffset = 0) => JSRef!.CallVoid("uniform4fv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform4fv(WebGLUniformLocation location, float[] data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform4fv", location, data, srcOffset, srcLength);

        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform1fv(WebGLUniformLocation location, Float32Array data, int srcOffset = 0) => JSRef!.CallVoid("uniform1fv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform1fv(WebGLUniformLocation location, Float32Array data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform1fv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform2fv(WebGLUniformLocation location, Float32Array data, int srcOffset = 0) => JSRef!.CallVoid("uniform2fv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform2fv(WebGLUniformLocation location, Float32Array data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform2fv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform3fv(WebGLUniformLocation location, Float32Array data, int srcOffset = 0) => JSRef!.CallVoid("uniform3fv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform3fv(WebGLUniformLocation location, Float32Array data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform3fv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform4fv(WebGLUniformLocation location, Float32Array data, int srcOffset = 0) => JSRef!.CallVoid("uniform4fv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform4fv(WebGLUniformLocation location, Float32Array data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform4fv", location, data, srcOffset, srcLength);

        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform1iv(WebGLUniformLocation location, int[] data, int srcOffset = 0) => JSRef!.CallVoid("uniform1iv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform1iv(WebGLUniformLocation location, int[] data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform1iv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform2iv(WebGLUniformLocation location, int[] data, int srcOffset = 0) => JSRef!.CallVoid("uniform2iv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform2iv(WebGLUniformLocation location, int[] data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform2iv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform3iv(WebGLUniformLocation location, int[] data, int srcOffset = 0) => JSRef!.CallVoid("uniform3iv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform3iv(WebGLUniformLocation location, int[] data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform3iv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform4iv(WebGLUniformLocation location, int[] data, int srcOffset = 0) => JSRef!.CallVoid("uniform4iv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform4iv(WebGLUniformLocation location, int[] data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform4iv", location, data, srcOffset, srcLength);

        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform1iv(WebGLUniformLocation location, Int32Array data, int srcOffset = 0) => JSRef!.CallVoid("uniform1iv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform1iv(WebGLUniformLocation location, Int32Array data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform1iv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform2iv(WebGLUniformLocation location, Int32Array data, int srcOffset = 0) => JSRef!.CallVoid("uniform2iv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform2iv(WebGLUniformLocation location, Int32Array data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform2iv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform3iv(WebGLUniformLocation location, Int32Array data, int srcOffset = 0) => JSRef!.CallVoid("uniform3iv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform3iv(WebGLUniformLocation location, Int32Array data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform3iv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform4iv(WebGLUniformLocation location, Int32Array data, int srcOffset = 0) => JSRef!.CallVoid("uniform4iv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform4iv(WebGLUniformLocation location, Int32Array data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform4iv", location, data, srcOffset, srcLength);

        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform1uiv(WebGLUniformLocation location, uint[] data, int srcOffset = 0) => JSRef!.CallVoid("uniform1uiv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform1uiv(WebGLUniformLocation location, uint[] data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform1uiv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform2uiv(WebGLUniformLocation location, uint[] data, int srcOffset = 0) => JSRef!.CallVoid("uniform2uiv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform2uiv(WebGLUniformLocation location, uint[] data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform2uiv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform3uiv(WebGLUniformLocation location, uint[] data, int srcOffset = 0) => JSRef!.CallVoid("uniform3uiv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform3uiv(WebGLUniformLocation location, uint[] data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform3uiv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform4uiv(WebGLUniformLocation location, uint[] data, int srcOffset = 0) => JSRef!.CallVoid("uniform4uiv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform4uiv(WebGLUniformLocation location, uint[] data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform4uiv", location, data, srcOffset, srcLength);

        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform1uiv(WebGLUniformLocation location, Uint32Array data, int srcOffset = 0) => JSRef!.CallVoid("uniform1uiv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform1uiv(WebGLUniformLocation location, Uint32Array data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform1uiv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform2uiv(WebGLUniformLocation location, Uint32Array data, int srcOffset = 0) => JSRef!.CallVoid("uniform2uiv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform2uiv(WebGLUniformLocation location, Uint32Array data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform2uiv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform3uiv(WebGLUniformLocation location, Uint32Array data, int srcOffset = 0) => JSRef!.CallVoid("uniform3uiv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform3uiv(WebGLUniformLocation location, Uint32Array data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform3uiv", location, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform4uiv(WebGLUniformLocation location, Uint32Array data, int srcOffset = 0) => JSRef!.CallVoid("uniform4uiv", location, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniform[1234][uif][v]() methods of the WebGL API specify values of uniform variables.
        /// </summary>
        public void Uniform4uiv(WebGLUniformLocation location, Uint32Array data, int srcOffset, int srcLength) => JSRef!.CallVoid("uniform4uiv", location, data, srcOffset, srcLength);

        #region Matrix uniforms
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix2fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix2fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix2fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix2fv", location, transpose, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix3x2fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix3x2fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix3x2fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix3x2fv", location, transpose, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix4x2fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix4x2fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix4x2fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix4x2fv", location, transpose, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix2x3fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix2x3fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix2x3fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix2x3fv", location, transpose, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix3fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix3fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix3fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix3fv", location, transpose, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix4x3fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix4x3fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix4x3fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix4x3fv", location, transpose, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix2x4fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix2x4fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix2x4fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix2x4fv", location, transpose, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix3x4fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix3x4fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix3x4fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix3x4fv", location, transpose, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix4fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix4fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix4fv(WebGLUniformLocation location, GLboolean transpose, float[] data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix4fv", location, transpose, data, srcOffset, srcLength);

        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix2fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix2fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix2fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix2fv", location, transpose, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix3x2fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix3x2fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix3x2fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix3x2fv", location, transpose, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix4x2fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix4x2fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix4x2fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix4x2fv", location, transpose, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix2x3fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix2x3fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix2x3fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix2x3fv", location, transpose, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix3fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix3fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix3fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix3fv", location, transpose, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix4x3fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix4x3fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix4x3fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix4x3fv", location, transpose, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix2x4fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix2x4fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix2x4fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix2x4fv", location, transpose, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix3x4fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix3x4fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix3x4fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix3x4fv", location, transpose, data, srcOffset, srcLength);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix4fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset = 0)
            => JSRef!.CallVoid("uniformMatrix4fv", location, transpose, data, srcOffset);
        /// <summary>
        /// The WebGL2RenderingContext.uniformMatrix[234]x[234]fv() methods of the WebGL 2 API specify matrix values for uniform variables.
        /// </summary>
        public void UniformMatrix4fv(WebGLUniformLocation location, GLboolean transpose, Float32Array data, int srcOffset, int srcLength)
            => JSRef!.CallVoid("uniformMatrix4fv", location, transpose, data, srcOffset, srcLength);
        #endregion
        /// <summary>
        /// The WebGL2RenderingContext.vertexAttribI4[u]i[v]() methods of the WebGL 2 API specify integer values for generic vertex attributes.
        /// </summary>
        public void VertexAttribI4i(GLuint index, int v0, int v1, int v2, int v3) => JSRef!.CallVoid("vertexAttribI4i", index, v0, v1, v2, v3);
        /// <summary>
        /// The WebGL2RenderingContext.vertexAttribI4[u]i[v]() methods of the WebGL 2 API specify integer values for generic vertex attributes.
        /// </summary>
        public void VertexAttribI4ui(GLuint index, uint v0, uint v1, uint v2, uint v3) => JSRef!.CallVoid("vertexAttribI4ui", index, v0, v1, v2, v3);
        /// <summary>
        /// The WebGL2RenderingContext.vertexAttribI4[u]i[v]() methods of the WebGL 2 API specify integer values for generic vertex attributes.
        /// </summary>
        public void VertexAttribI4iv(GLuint index, Int32Array value) => JSRef!.CallVoid("vertexAttribI4iv", index, value);
        /// <summary>
        /// The WebGL2RenderingContext.vertexAttribI4[u]i[v]() methods of the WebGL 2 API specify integer values for generic vertex attributes.
        /// </summary>
        public void VertexAttribI4iv(GLuint index, int[] value) => JSRef!.CallVoid("vertexAttribI4iv", index, value);
        /// <summary>
        /// The WebGL2RenderingContext.vertexAttribI4[u]i[v]() methods of the WebGL 2 API specify integer values for generic vertex attributes.
        /// </summary>
        public void VertexAttribI4uiv(GLuint index, Uint32Array value) => JSRef!.CallVoid("vertexAttribI4uiv", index, value);
        /// <summary>
        /// The WebGL2RenderingContext.vertexAttribI4[u]i[v]() methods of the WebGL 2 API specify integer values for generic vertex attributes.
        /// </summary>
        public void VertexAttribI4uiv(GLuint index, uint[] value) => JSRef!.CallVoid("vertexAttribI4uiv", index, value);
        /// <summary>
        /// The WebGL2RenderingContext.vertexAttribIPointer() method of the WebGL 2 API specifies integer data formats and locations of vertex attributes in a vertex attributes array.
        /// </summary>
        /// <param name="index">A GLuint specifying the index of the vertex attribute that is to be modified.</param>
        /// <param name="size">A GLint specifying the number of components per vertex attribute. Must be 1, 2, 3, or 4.</param>
        /// <param name="type">A GLenum specifying the data type of each component in the array. Must be one of: gl.BYTE, gl.UNSIGNED_BYTE, gl.SHORT, gl.UNSIGNED_SHORT, gl.INT, or gl.UNSIGNED_INT.</param>
        /// <param name="stride">A GLsizei specifying the offset in bytes between the beginning of consecutive vertex attributes.</param>
        /// <param name="offset">A GLintptr specifying an offset in bytes of the first component in the vertex attribute array. Must be a multiple of type.</param>
        public void VertexAttribIPointer(GLuint index, GLint size, GLenum type, GLsizei stride, GLintptr offset) => JSRef!.CallVoid("vertexAttribIPointer", index, size, type, stride, offset);
        #endregion

        #region Color spaces - https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext#color_spaces
        /// <summary>
        /// The WebGL2RenderingContext.drawingBufferColorSpace property specifies the color space of the WebGL drawing buffer. Along with the default (srgb), the display-p3 color space can be used.<br/>
        /// This property can have the following values:<br/>
        /// "srgb" selects the sRGB color space. This is the default value.<br/>
        /// "display-p3" selects the display-p3 color space.
        /// </summary>
        public string DrawingBufferColorSpace { get => JSRef!.Get<string>("drawingBufferColorSpace"); set => JSRef!.Set("drawingBufferColorSpace", value); }
        /// <summary>
        /// The WebGL2RenderingContext.unpackColorSpace property specifies the color space to convert to when importing textures. Along with the default (srgb), the display-p3 color space can be used.<br/>
        /// This property can have the following values:<br/>
        /// "srgb" selects the sRGB color space. This is the default value.<br/>
        /// "display-p3" selects the display-p3 color space.
        /// </summary>
        public string UnpackColorSpace { get => JSRef!.Get<string>("unpackColorSpace"); set => JSRef!.Set("unpackColorSpace", value); }
        #endregion

        #region Drawing buffers - https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext#drawing_buffers

        #endregion

        #region Query objects - https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext#query_objects
        /// <summary>
        /// The WebGL2RenderingContext.beginQuery() method of the WebGL 2 API starts an asynchronous query. The target parameter indicates which kind of query to begin.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the target of the query.<br/>
        /// Possible values:<br/>
        /// gl.ANY_SAMPLES_PASSED - Specifies an occlusion query: these queries detect whether an object is visible(whether the scoped drawing commands pass the depth test and if so, how many samples pass).<br/>
        /// gl.ANY_SAMPLES_PASSED_CONSERVATIVE - Same as above, but less accurate and faster version.<br/>
        /// gl.TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN - Number of primitives that are written to transform feedback buffers.<br/>
        /// </param>
        /// <param name="query">A WebGLQuery object for which to start the querying.</param>
        public void BeginQuery(GLenum target, WebGLQuery query) => JSRef!.CallVoid("beginQuery", target, query);
        /// <summary>
        /// The WebGL2RenderingContext.endQuery() method of the WebGL 2 API marks the end of a given query target.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the target of the query.<br/>
        /// Possible values:<br/>
        /// gl.ANY_SAMPLES_PASSED - Specifies an occlusion query: these queries detect whether an object is visible(whether the scoped drawing commands pass the depth test and if so, how many samples pass).<br/>
        /// gl.ANY_SAMPLES_PASSED_CONSERVATIVE - Same as above, but less accurate and faster version.<br/>
        /// gl.TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN - Number of primitives that are written to transform feedback buffers.<br/>
        /// </param>
        public void EndQuery(GLenum target) => JSRef!.CallVoid("endQuery", target);
        /// <summary>
        /// The WebGL2RenderingContext.createQuery() method of the WebGL 2 API creates and initializes WebGLQuery objects, which provide ways to asynchronously query for information.
        /// </summary>
        /// <returns></returns>
        public WebGLQuery CreateQuery() => JSRef!.Call<WebGLQuery>("createQuery");
        /// <summary>
        /// The WebGL2RenderingContext.deleteQuery() method of the WebGL 2 API deletes a given WebGLQuery object.
        /// </summary>
        /// <param name="query"></param>
        public void DeleteQuery(WebGLQuery query) => JSRef!.CallVoid("deleteQuery", query);
        /// <summary>
        /// The WebGL2RenderingContext.isQuery() method of the WebGL 2 API returns true if the passed object is a valid WebGLQuery object.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public bool IsQuery(WebGLQuery query) => JSRef!.Call<bool>("isQuery", query);
        /// <summary>
        /// The WebGL2RenderingContext.getQuery() method of the WebGL 2 API returns the currently active WebGLQuery for the target, or null.
        /// </summary>
        /// <param name="target">
        /// A GLenum specifying the target of the query.<br/>
        /// Possible values:<br/>
        /// gl.ANY_SAMPLES_PASSED - Specifies an occlusion query: these queries detect whether an object is visible(whether the scoped drawing commands pass the depth test and if so, how many samples pass).<br/>
        /// gl.ANY_SAMPLES_PASSED_CONSERVATIVE - Same as above, but less accurate and faster version.<br/>
        /// gl.TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN - Number of primitives that are written to transform feedback buffers.<br/>
        /// </param>
        /// <param name="pname">A GLenum specifying the query object target. Must be gl.CURRENT_QUERY.</param>
        /// <returns></returns>
        public WebGLQuery GetQuery(GLenum target, GLenum pname) => JSRef!.Call<WebGLQuery>("getQuery", target, pname);
        /// <summary>
        /// The WebGL2RenderingContext.getQueryParameter() method of the WebGL 2 API returns parameter information of a WebGLQuery object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">A WebGLQuery object.</param>
        /// <param name="pname">
        /// A GLenum specifying which information to return. <br/>
        /// Possible values:<br/>
        /// gl.QUERY_RESULT - Returns a GLuint containing the query result.<br/>
        /// gl.QUERY_RESULT_AVAILABLE - Returns a GLboolean indicating whether or not a query result is available.<br/>
        /// </param>
        /// <returns>Depends on the pname parameter, either a GLuint or a GLboolean.</returns>
        public T GetQueryParameter<T>(WebGLQuery query, GLenum pname) => JSRef!.Call<T>("getQueryParameter", query, pname);
        /// <summary>
        /// Returns true if the query parameter is available.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public GLboolean GetQueryParameterAvailable(WebGLQuery query) => JSRef!.Call<GLboolean>("getQueryParameter", query, QUERY_RESULT_AVAILABLE);
        /// <summary>
        /// Returns the query result.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public GLuint GetQueryParameterResult(WebGLQuery query) => JSRef!.Call<GLuint>("getQueryParameter", query, QUERY_RESULT);
        #endregion

        #region Sampler objects - https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext#sampler_objects

        #endregion

        #region Sync objects - https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext#sync_objects

        #endregion

        #region Transform feedback - https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext#transform_feedback

        #endregion

        #region Uniform buffer objects - https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext#uniform_buffer_objects

        #endregion

        #region Vertex array objects - https://developer.mozilla.org/en-US/docs/Web/API/WebGL2RenderingContext#vertex_array_objects
        /// <summary>
        /// The WebGL2RenderingContext.createVertexArray() method of the WebGL 2 API creates and initializes a WebGLVertexArrayObject object that represents a vertex array object (VAO) pointing to vertex array data and which provides names for different sets of vertex data.
        /// </summary>
        /// <returns>A WebGLVertexArrayObject representing a vertex array object (VAO) which points to vertex array data.</returns>
        public WebGLVertexArrayObject CreateVertexArray() => JSRef!.Call<WebGLVertexArrayObject>("createVertexArray");
        /// <summary>
        /// The WebGL2RenderingContext.deleteVertexArray() method of the WebGL 2 API deletes a given WebGLVertexArrayObject object.
        /// </summary>
        /// <param name="vertexArray">A WebGLVertexArrayObject (VAO) object to delete.</param>
        public void DeleteVertexArray(WebGLVertexArrayObject vertexArray) => JSRef!.CallVoid("deleteVertexArray", vertexArray);
        /// <summary>
        /// The WebGL2RenderingContext.isVertexArray() method of the WebGL API returns true if the passed object is a valid WebGLVertexArrayObject object.
        /// </summary>
        /// <param name="vertexArray">A WebGLVertexArrayObject (VAO) object to test.</param>
        /// <returns>A GLboolean indicating whether the given object is a valid WebGLVertexArrayObject object (true) or not (false).</returns>
        public bool IsVertexArray(WebGLVertexArrayObject vertexArray) => JSRef!.Call<bool>("isVertexArray", vertexArray);
        /// <summary>
        /// The WebGL2RenderingContext.bindVertexArray() method of the WebGL 2 API binds a passed WebGLVertexArrayObject object to the buffer.
        /// </summary>
        /// <param name="vertexArray">A WebGLVertexArrayObject (VAO) object to bind.</param>
        public void BindVertexArray(WebGLVertexArrayObject vertexArray) => JSRef!.CallVoid("bindVertexArray", vertexArray);
        #endregion
    }
}
