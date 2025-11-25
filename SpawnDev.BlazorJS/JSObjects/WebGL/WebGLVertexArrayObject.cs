using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// TThe WebGLVertexArrayObject interface is part of the WebGL 2 API, represents vertex array objects (VAOs) pointing to vertex array data, and provides names for different sets of vertex data.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGLVertexArrayObject
    /// </summary>
    public class WebGLVertexArrayObject : WebGLObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WebGLVertexArrayObject(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
