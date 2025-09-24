using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webxr/#xrwebgllayer
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLLayer
    /// </summary>
    public class XRWebGLLayer : XRLayer
    {
        /// <inheritdoc/>
        public XRWebGLLayer(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="session"></param>
        /// <param name="context"></param>
        /// <param name="options"></param>
        public XRWebGLLayer(XRSession session, WebGLRenderingContext context, XRWebGLLayerInit? options = null) : base(options == null ? JS.New(nameof(XRWebGLLayer), session, context) : JS.New(nameof(XRWebGLLayer), session, context, options)) { }

        /// <summary>
        /// Returns a WebGLFramebuffer suitable for passing into the bindFrameBuffer() method.
        /// </summary>
        public WebGLFramebuffer Framebuffer => JSRef!.Get<WebGLFramebuffer>("framebuffer");
        /// <summary>
        /// Returns a new XRViewport instance representing the position, width, and height to which the WebGL context's viewport must be set to contain drawing to the area of the framebuffer designated for the specified view's contents. In this way, for example, the rendering of the left eye's point of view and of the right eye's point of view are each placed into the correct parts of the framebuffer.
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public XRViewport GetViewport(XRView view) => JSRef!.Call<XRViewport>("getViewport",  view);

        // TODO
    }
}
