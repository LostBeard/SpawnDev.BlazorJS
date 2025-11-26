using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGLSync interface is part of the WebGL 2 API and is used to synchronize activities between the GPU and the application.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGLSync
    /// </summary>
    public class WebGLSync : WebGLObject
    {
        /// <inheritdoc/>
        public WebGLSync(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
