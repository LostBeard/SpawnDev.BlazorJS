using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGLFramebuffer interface is part of the WebGL API and represents a collection of buffers that serve as a rendering destination.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGLFramebuffer
    /// </summary>
    public class WebGLFramebuffer : WebGLObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WebGLFramebuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
