using Microsoft.JSInterop;
using System;

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
