using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRRenderState
    /// </summary>
    public class XRRenderState : JSObject
    {
        /// <inheritdoc/>
        public XRRenderState(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The XRWebGLLayer from which the browser's compositing system obtains the image for the XR session.
        /// </summary>
        public XRWebGLLayer BaseLayer => JSRef!.Get<XRWebGLLayer>("baseLayer");
        /// <summary>
        /// The distance, in meters, of the far clip plane from the viewer. The far clip plane is the plane which is parallel to the display beyond which rendering of the scene no longer takes place. This, essentially, specifies the maximum distance the user can see.
        /// </summary>
        public float DepthFar => JSRef!.Get<float>("depthFar");
        /// <summary>
        /// The distance, in meters, of the near clip plane from the viewer. The near clip plane is the plane, parallel to the display, at which rendering of the scene begins. Any closer to the viewer than this, and no portions of the scene are drawn.
        /// </summary>
        public float DepthNear => JSRef!.Get<float>("depthNear");
        /// <summary>
        /// The default vertical field of view, defined in radians, to use when the session is in inline mode. null for all immersive sessions.
        /// </summary>
        public float? InlineVerticalFieldOfView => JSRef!.Get<float?>("inlineVerticalFieldOfView");
        /// <summary>
        /// An ordered array containing XRLayer objects that are displayed by the XR compositor.
        /// </summary>
        public Array<XRLayer> Layers => JSRef!.Get<Array<XRLayer>>("layers");
    }
}
