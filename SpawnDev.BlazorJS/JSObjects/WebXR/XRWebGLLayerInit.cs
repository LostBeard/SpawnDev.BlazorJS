namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webxr/#dictdef-xrwebgllayerinit
    /// </summary>
    public class XRWebGLLayerInit
    {
        public bool Antialias { get; set; } = true;
        public bool Depth { get; set; } = true;
        public bool Stencil { get; set; } = false;
        public bool Alpha { get; set; } = true;
        public bool IgnoreDepthValues { get; set; } = false;
        public double FramebufferScaleFactor { get; set; } = 1;
    }
}
