using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebXR Device API's XRInputSourceEvent interface describes an event which has occurred on a WebXR user input device such as a hand controller, gaze tracking system, or motion tracking system. More specifically, they represent a change in the state of an XRInputSource.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRInputSourceEvent
    /// </summary>
    public class XRInputSourceEvent : Event
    {
        /// <inheritdoc/>
        public XRInputSourceEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An XRFrame object providing the needed information about the event frame during which the event occurred. This frame may have been rendered in the past rather than being a current frame. Because this is an event frame, not an animation frame, you cannot call the XRFrame method getViewerPose() on it; instead, use getPose().
        /// </summary>
        public XRFrame Frame => JSRef!.Get<XRFrame>("frame");
        /// <summary>
        /// An XRInputSource object indicating which input source generated the input event.
        /// </summary>
        public XRInputSource InputSource => JSRef!.Get<XRInputSource>("inputSource");
    }
}
