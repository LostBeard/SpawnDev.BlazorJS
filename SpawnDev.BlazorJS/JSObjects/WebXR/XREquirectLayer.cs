using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XREquirectLayer
    /// </summary>
    public class XREquirectLayer : XRCompositionLayer
    {
        /// <inheritdoc/>
        public XREquirectLayer(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A number indicating the central horizontal angle in radians for the sphere.
        /// </summary>
        public float CentralHorizontalAngle { get => JSRef!.Get<float>("centralHorizontalAngle"); set => JSRef!.Set("centralHorizontalAngle", value); }
        /// <summary>
        /// A number indicating the lower vertical angle in radians for the sphere.
        /// </summary>
        public float LowerVerticalAngle { get => JSRef!.Get<float>("lowerVerticalAngle"); set => JSRef!.Set("lowerVerticalAngle", value); }
        /// <summary>
        /// A number indicating the radius of the sphere.
        /// </summary>
        public float Radius { get => JSRef!.Get<float>("radius"); set => JSRef!.Set("radius", value); }
        /// <summary>
        /// An XRSpace representing the layer's spatial relationship with the user's physical environment.
        /// </summary>
        public XRSpace Space { get => JSRef!.Get<XRSpace>("space"); set => JSRef!.Set("space", value); }
        /// <summary>
        /// An XRRigidTransform representing the offset and orientation relative to space.
        /// </summary>
        public XRRigidTransform Transform { get => JSRef!.Get<XRRigidTransform>("transform"); set => JSRef!.Set("transform", value); }
        /// <summary>
        /// A number indicating the upper vertical angle in radians for the sphere.
        /// </summary>
        public float UpperVerticalAngle { get => JSRef!.Get<float>("upperVerticalAngle"); set => JSRef!.Set("upperVerticalAngle", value); }
        /// <summary>
        /// Sent to the XREquirectLayer object when the underlying resources of the layer are lost or when the XR Compositor can no longer reproject the layer. If this event is sent, authors should redraw the content of the layer in the next XR animation frame.
        /// </summary>
        public ActionEvent<XRLayerEvent> OnRedraw { get => new ActionEvent<XRLayerEvent>("redraw", AddEventListener, RemoveEventListener); set { } }
    }
}
