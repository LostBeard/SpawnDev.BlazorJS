using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The VTTRegion interface of the WebVTT API represents a portion of the video representation where a VTTCue can be rendered.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/VTTRegion
    /// </summary>
    public class VTTRegion : JSObject
    {
        /// <inheritdoc/>
        public VTTRegion(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new VTTRegion object.
        /// </summary>
        public VTTRegion() : base(JS.New("VTTRegion")) { }
        /// <summary>
        /// A string that identifies the region.
        /// </summary>
        public string Id { get => JSRef!.Get<string>("id"); set => JSRef!.Set("id", value); }
        /// <summary>
        /// A double that represents the width of the region as a percentage of the video width.
        /// </summary>
        public double Width { get => JSRef!.Get<double>("width"); set => JSRef!.Set("width", value); }
        /// <summary>
        /// A double that represents the number of lines the region has.
        /// </summary>
        public double Lines { get => JSRef!.Get<double>("lines"); set => JSRef!.Set("lines", value); }
        /// <summary>
        /// A double that represents the region anchor X offset as a percentage of the region width.
        /// </summary>
        public double RegionAnchorX { get => JSRef!.Get<double>("regionAnchorX"); set => JSRef!.Set("regionAnchorX", value); }
        /// <summary>
        /// A double that represents the region anchor Y offset as a percentage of the region height.
        /// </summary>
        public double RegionAnchorY { get => JSRef!.Get<double>("regionAnchorY"); set => JSRef!.Set("regionAnchorY", value); }
        /// <summary>
        /// A double that represents the viewport anchor X offset as a percentage of the video width.
        /// </summary>
        public double ViewportAnchorX { get => JSRef!.Get<double>("viewportAnchorX"); set => JSRef!.Set("viewportAnchorX", value); }
        /// <summary>
        /// A double that represents the viewport anchor Y offset as a percentage of the video height.
        /// </summary>
        public double ViewportAnchorY { get => JSRef!.Get<double>("viewportAnchorY"); set => JSRef!.Set("viewportAnchorY", value); }
        /// <summary>
        /// A string that represents the scroll setting of the region.
        /// </summary>
        public string Scroll { get => JSRef!.Get<string>("scroll"); set => JSRef!.Set("scroll", value); }
    }
}
