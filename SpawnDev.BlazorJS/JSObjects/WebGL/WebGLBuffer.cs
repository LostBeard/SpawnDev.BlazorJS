using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGLBuffer interface is part of the WebGL API and represents an opaque buffer object storing data such as vertices or colors.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGLBuffer
    /// </summary>
    public class WebGLBuffer : WebGLObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WebGLBuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
