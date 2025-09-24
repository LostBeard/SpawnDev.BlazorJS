using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webxr/#dictdef-xrrenderstateinit
    /// </summary>
    public class XRRenderStateInit
    {
        /// <summary>
        /// The depthNear attribute defines the distance, in meters, of the near clip plane from the viewer. The depthFar attribute defines the distance, in meters, of the far clip plane from the viewer.
        /// </summary>
        public double DepthNear { get; set; }
        /// <summary>
        /// depthNear and depthFar are used in the computation of the projectionMatrix of XRViews. When the projectionMatrix is used during rendering, only geometry with a distance to the viewer that falls between depthNear and depthFar will be drawn. They also determine how the values of an XRWebGLLayer depth buffer are interpreted. depthNear MAY be greater than depthFar.
        /// </summary>
        public double DepthFar { get; set; }
        /// <summary>
        /// The passthroughFullyObscured attribute is a hint to the XRSystem from the author to indicate that they intend to completely cover the viewport with virtual content. The author SHOULD set this flag back to false once the viewport is no longer covered by opaque pixels.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PassthroughFullyObscured { get; set; }
        /// <summary>
        /// The inlineVerticalFieldOfView attribute defines the default vertical field of view in radians used when computing projection matrices for "inline" XRSessions. The projection matrix calculation also takes into account the aspect ratio of the output canvas. This value MUST be null for immersive sessions.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public  double? InlineVerticalFieldOfView { get; set; }
        /// <summary>
        /// The baseLayer attribute defines an XRWebGLLayer which the XR compositor will obtain images from.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public XRWebGLLayer? BaseLayer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<XRLayer>? Layers { get; set; }
    }
}
