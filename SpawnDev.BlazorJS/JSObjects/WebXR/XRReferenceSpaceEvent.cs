using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebXR Device API interface XRReferenceSpaceEvent represents an event sent to an XRReferenceSpace. Currently, the only event that uses this type is the reset event.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRReferenceSpaceEvent
    /// </summary>
    public class XRReferenceSpaceEvent : Event
    {
        /// <inheritdoc/>
        public XRReferenceSpaceEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An XRReferenceSpace indicating the reference space that generated the event.
        /// </summary>
        public XRReferenceSpace ReferenceSpace => JSRef!.Get<XRReferenceSpace>("referenceSpace");
        /// <summary>
        /// An XRRigidTransform object indicating the position and orientation of the specified referenceSpace's native origin after the event, defined relative to the coordinate system before the event.
        /// </summary>
        public XRRigidTransform Transform => JSRef!.Get<XRRigidTransform>("transform");
    }
}
