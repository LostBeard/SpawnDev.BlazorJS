namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webxr/#dictdef-xrwebgllayerinit
    /// </summary>
    public class XRWebGLLayerInit
    {
        /// <summary>
        /// A Boolean value which is true if anti-aliasing is to be used when rendering in the context; otherwise false. The browser selects the anti-aliasing method to use; there is no support for requesting a specific mode yet. The default value is true.
        /// </summary>
        public bool Antialias { get; set; } = true;
        /// <summary>
        /// A Boolean value which, if true, requests that the new layer have a depth buffer; otherwise, no depth layer is allocated. The default is true.
        /// </summary>
        public bool Depth { get; set; } = true;
        /// <summary>
        /// A Boolean value which, if true, requests that the new layer include a stencil buffer. Otherwise, no stencil buffer is allocated. The default is false.
        /// </summary>
        public bool Stencil { get; set; } = false;
        /// <summary>
        /// The frame buffer's color buffer will be established with an alpha channel if the alpha Boolean property is true. Otherwise, the color buffer will not have an alpha channel. The default value is true.
        /// </summary>
        public bool Alpha { get; set; } = true;
        /// <summary>
        /// A Boolean value which indicates whether or not to ignore the contents of the depth buffer while compositing the scene. The default is false.
        /// </summary>
        public bool IgnoreDepthValues { get; set; } = false;
        /// <summary>
        /// A floating-point value which is used to scale the image during compositing, with a value of 1.0 represents the default pixel size for the frame buffer. The static XRWebGLLayer function XRWebGLLayer.getNativeFramebufferScaleFactor() returns the scale that would result in a 1:1 pixel ratio, thereby ensuring that the rendering is occurring at the device's native resolution. The default is 1.0.
        /// </summary>
        public float FramebufferScaleFactor { get; set; } = 1;
    }
}
