using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGLRenderbuffer interface is part of the WebGL API and represents a buffer that can contain an image, or that can be a source or target of a rendering operation.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGLRenderbuffer
    /// </summary>
    public class WebGLRenderbuffer : WebGLObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WebGLRenderbuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
