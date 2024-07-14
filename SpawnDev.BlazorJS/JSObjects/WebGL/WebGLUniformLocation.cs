using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGLUniformLocation interface is part of the WebGL API and represents the location of a uniform variable in a shader program.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGLUniformLocation
    /// </summary>
    public class WebGLUniformLocation : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WebGLUniformLocation(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
