using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRGPUBinding interface is used to create GPU layers for WebXR rendering with WebGPU.<br/>
    /// This is the WebGPU counterpart to XRWebGLBinding.<br/>
    /// Requires the "webgpu" feature in the XR session and Chrome's webxr-webgpu flag.<br/>
    /// https://immersive-web.github.io/WebXR-WebGPU-Binding/
    /// </summary>
    public class XRGPUBinding : JSObject
    {
        /// <inheritdoc/>
        public XRGPUBinding(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new XRGPUBinding for the given XR session and GPU device.
        /// </summary>
        /// <param name="session">The XRSession to bind to.</param>
        /// <param name="device">The GPUDevice to use for rendering.</param>
        public XRGPUBinding(XRSession session, GPUDevice device) : base(JS.New(nameof(XRGPUBinding), session, device)) { }
        /// <summary>
        /// The read-only nativeProjectionScaleFactor property represents the scaling factor
        /// by which the projection layer's resolution is multiplied to get the native resolution.
        /// </summary>
        public float NativeProjectionScaleFactor => JSRef!.Get<float>("nativeProjectionScaleFactor");
        /// <summary>
        /// Creates an XRProjectionLayer that fills the entire view and is refreshed at the device's native frame rate.
        /// </summary>
        /// <param name="options">Configuration options for the projection layer.</param>
        /// <returns>An XRProjectionLayer object.</returns>
        public XRProjectionLayer CreateProjectionLayer(XRGPUProjectionLayerInit? options = null)
            => options == null
                ? JSRef!.Call<XRProjectionLayer>("createProjectionLayer")
                : JSRef!.Call<XRProjectionLayer>("createProjectionLayer", options);
        /// <summary>
        /// Returns an XRGPUSubImage for a projection layer view, providing the GPU texture to render into.
        /// </summary>
        /// <param name="layer">The XRProjectionLayer to get the sub-image for.</param>
        /// <param name="view">The XRView (eye) to get the sub-image for.</param>
        /// <returns>An XRGPUSubImage containing the GPU texture and viewport.</returns>
        public XRGPUSubImage GetViewSubImage(XRProjectionLayer layer, XRView view) => JSRef!.Call<XRGPUSubImage>("getViewSubImage", layer, view);
        /// <summary>
        /// Returns the preferred GPU texture format for the XR session's color attachments.
        /// </summary>
        /// <returns>A GPUTextureFormat string (e.g., "rgba8unorm").</returns>
        public string GetPreferredColorFormat() => JSRef!.Call<string>("getPreferredColorFormat");
    }

    /// <summary>
    /// Configuration options for XRGPUBinding.createProjectionLayer().
    /// </summary>
    public class XRGPUProjectionLayerInit
    {
        /// <summary>
        /// The GPUTextureFormat to use for the color texture. Defaults to the binding's preferred format.
        /// </summary>
        public string? ColorFormat { get; set; }
        /// <summary>
        /// The GPUTextureFormat for the depth/stencil texture, or null for no depth.
        /// </summary>
        public string? DepthStencilFormat { get; set; }
        /// <summary>
        /// A scaling factor for the projection layer resolution. Default 1.0.
        /// </summary>
        public float? ScaleFactor { get; set; }
    }
}
