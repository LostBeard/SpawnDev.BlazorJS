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
    }
}
