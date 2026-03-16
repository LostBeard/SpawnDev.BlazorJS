using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRGPUSubImage interface provides the GPU textures for rendering a view in an XR session.<br/>
    /// This is the WebGPU counterpart to XRWebGLSubImage.<br/>
    /// https://immersive-web.github.io/WebXR-WebGPU-Binding/
    /// </summary>
    public class XRGPUSubImage : XRSubImage
    {
        /// <inheritdoc/>
        public XRGPUSubImage(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The GPU texture to render the color attachment into for this view.
        /// </summary>
        public GPUTexture ColorTexture => JSRef!.Get<GPUTexture>("colorTexture");
        /// <summary>
        /// The GPU texture for the depth/stencil attachment, or null if not requested.
        /// </summary>
        public GPUTexture? DepthStencilTexture => JSRef!.Get<GPUTexture?>("depthStencilTexture");
        /// <summary>
        /// The viewport describing the region of the texture to render into.
        /// </summary>
        public XRViewport Viewport => JSRef!.Get<XRViewport>("viewport");
    }
}
