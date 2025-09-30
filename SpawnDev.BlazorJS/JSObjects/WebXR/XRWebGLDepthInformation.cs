using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRWebGLDepthInformation interface contains depth information from the GPU/WebGL (returned by XRWebGLBinding.getDepthInformation()).<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLDepthInformation
    /// </summary>
    public class XRWebGLDepthInformation : XRDepthInformation
    {
        /// <inheritdoc/>
        public XRWebGLDepthInformation(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A WebGLTexture containing depth buffer information as an opaque texture.
        /// </summary>
        public WebGLTexture Texture => JSRef!.Get<WebGLTexture>("texture");
    }
}
