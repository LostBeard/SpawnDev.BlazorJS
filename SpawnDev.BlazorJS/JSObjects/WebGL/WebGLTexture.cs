using Microsoft.JSInterop;
namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGLTexture interface is part of the WebGL API and represents an opaque texture object providing storage and state for texturing operations.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGLTexture
    /// </summary>
    public class WebGLTexture : WebGLObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WebGLTexture(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
