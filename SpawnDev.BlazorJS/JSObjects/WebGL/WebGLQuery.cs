using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGLQuery interface is part of the WebGL 2 API and provides ways to asynchronously query for information. By default, occlusion queries and primitive queries are available.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebGLQuery
    /// </summary>
    public class WebGLQuery : WebGLObject
    {
        /// <inheritdoc/>
        public WebGLQuery(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
