using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRWebGLSubImage interface is used during rendering of WebGL layers.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLSubImage
    /// </summary>
    public class XRWebGLSubImage : XRSubImage
    {
        /// <inheritdoc/>
        public XRWebGLSubImage(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A color WebGLTexture object for the XRCompositionLayer to render.
        /// </summary>
        public WebGLTexture ColorTexture => JSRef!.Get<WebGLTexture>("colorTexture");
        /// <summary>
        /// A depth/stencil WebGLTexture object for the XRCompositionLayer to render.
        /// </summary>
        public WebGLTexture DepthStencilTexture => JSRef!.Get<WebGLTexture>("depthStencilTexture");
        /// <summary>
        /// A number representing the offset into the texture array if the layer was requested with texture-array; null otherwise.
        /// </summary>
        public int? ImageIndex => JSRef!.Get<int?>("imageIndex");
        /// <summary>
        /// A number representing the width in pixels of the GL attachment.
        /// </summary>
        public int ColorTextureWidth => JSRef!.Get<int>("colorTextureWidth");
        /// <summary>
        /// A number representing the height in pixels of the GL attachment.
        /// </summary>
        public int ColorTextureHeight => JSRef!.Get<int>("colorTextureHeight");
    }
}
