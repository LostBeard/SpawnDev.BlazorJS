using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGLProgram is part of the WebGL API and is a combination of two compiled WebGLShaders consisting of a vertex shader and a fragment shader (both written in GLSL).<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGLProgram
    /// </summary>
    public class WebGLProgram : WebGLObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WebGLProgram(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
