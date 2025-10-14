using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGLObject is part of the WebGL API and is the parent interface for all WebGL objects.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGLObject
    /// </summary>
    public class WebGLObject : JSObject
    {
        /// <inheritdoc/>
        public WebGLObject(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
