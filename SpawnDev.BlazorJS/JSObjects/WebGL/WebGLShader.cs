using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGLShader is part of the WebGL API and can either be a vertex or a fragment shader. A WebGLProgram requires both types of shaders.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGLShader
    /// </summary>
    public class WebGLShader : WebGLObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WebGLShader(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
