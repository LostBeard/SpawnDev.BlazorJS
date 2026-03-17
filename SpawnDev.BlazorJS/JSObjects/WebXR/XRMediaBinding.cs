using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRMediaBinding interface is used to create XR layers that display the content of an HTMLVideoElement.<br/>
    /// https://immersive-web.github.io/layers/#xrmediabinding
    /// </summary>
    public class XRMediaBinding : JSObject
    {
        /// <inheritdoc/>
        public XRMediaBinding(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new XRMediaBinding associated with the specified XRSession and XRWebGLBinding.
        /// </summary>
        /// <param name="session">An XRSession object to associate with the media binding.</param>
        /// <param name="binding">An XRWebGLBinding object to use for creating media layers.</param>
        public XRMediaBinding(XRSession session, XRWebGLBinding binding) : base(JS.New(nameof(XRMediaBinding), session, binding)) { }
        /// <summary>
        /// Creates an XRQuadLayer that displays a flat video on a quad in the XR scene.
        /// </summary>
        /// <param name="video">An HTMLVideoElement to display.</param>
        /// <param name="init">Optional configuration for the quad layer.</param>
        /// <returns></returns>
        public XRQuadLayer CreateQuadLayer(HTMLVideoElement video, XRMediaQuadLayerInit? init = null)
            => init == null ? JSRef!.Call<XRQuadLayer>("createQuadLayer", video) : JSRef!.Call<XRQuadLayer>("createQuadLayer", video, init);
        /// <summary>
        /// Creates an XRCylinderLayer that displays a video on a cylinder surface in the XR scene.
        /// </summary>
        /// <param name="video">An HTMLVideoElement to display.</param>
        /// <param name="init">Optional configuration for the cylinder layer.</param>
        /// <returns></returns>
        public XRCylinderLayer CreateCylinderLayer(HTMLVideoElement video, XRMediaCylinderLayerInit? init = null)
            => init == null ? JSRef!.Call<XRCylinderLayer>("createCylinderLayer", video) : JSRef!.Call<XRCylinderLayer>("createCylinderLayer", video, init);
        /// <summary>
        /// Creates an XREquirectLayer that displays a video on an equirectangular surface in the XR scene.
        /// </summary>
        /// <param name="video">An HTMLVideoElement to display.</param>
        /// <param name="init">Optional configuration for the equirect layer.</param>
        /// <returns></returns>
        public XREquirectLayer CreateEquirectLayer(HTMLVideoElement video, XRMediaEquirectLayerInit? init = null)
            => init == null ? JSRef!.Call<XREquirectLayer>("createEquirectLayer", video) : JSRef!.Call<XREquirectLayer>("createEquirectLayer", video, init);
    }

    /// <summary>
    /// Configuration options for XRMediaBinding.createQuadLayer().
    /// </summary>
    public class XRMediaQuadLayerInit
    {
        /// <summary>
        /// An XRSpace in which the layer is positioned. Defaults to the viewer space.
        /// </summary>
        public XRSpace? Space { get; set; }
        /// <summary>
        /// An XRRigidTransform specifying the position and orientation of the layer in the space.
        /// </summary>
        public XRRigidTransform? Transform { get; set; }
        /// <summary>
        /// The width of the quad layer in meters.
        /// </summary>
        public float? Width { get; set; }
        /// <summary>
        /// The height of the quad layer in meters.
        /// </summary>
        public float? Height { get; set; }
    }

    /// <summary>
    /// Configuration options for XRMediaBinding.createCylinderLayer().
    /// </summary>
    public class XRMediaCylinderLayerInit
    {
        /// <summary>
        /// An XRSpace in which the layer is positioned.
        /// </summary>
        public XRSpace? Space { get; set; }
        /// <summary>
        /// An XRRigidTransform specifying the position and orientation of the layer in the space.
        /// </summary>
        public XRRigidTransform? Transform { get; set; }
        /// <summary>
        /// The radius of the cylinder in meters.
        /// </summary>
        public float? Radius { get; set; }
        /// <summary>
        /// The central angle of the cylinder in radians.
        /// </summary>
        public float? CentralAngle { get; set; }
        /// <summary>
        /// The aspect ratio of the cylinder (width / height).
        /// </summary>
        public float? AspectRatio { get; set; }
    }

    /// <summary>
    /// Configuration options for XRMediaBinding.createEquirectLayer().
    /// </summary>
    public class XRMediaEquirectLayerInit
    {
        /// <summary>
        /// An XRSpace in which the layer is positioned.
        /// </summary>
        public XRSpace? Space { get; set; }
        /// <summary>
        /// An XRRigidTransform specifying the position and orientation of the layer in the space.
        /// </summary>
        public XRRigidTransform? Transform { get; set; }
        /// <summary>
        /// The radius of the sphere in meters.
        /// </summary>
        public float? Radius { get; set; }
        /// <summary>
        /// The central horizontal angle of the equirect layer in radians.
        /// </summary>
        public float? CentralHorizontalAngle { get; set; }
        /// <summary>
        /// The upper vertical angle of the portion of the sphere in radians.
        /// </summary>
        public float? UpperVerticalAngle { get; set; }
        /// <summary>
        /// The lower vertical angle of the portion of the sphere in radians.
        /// </summary>
        public float? LowerVerticalAngle { get; set; }
    }
}
