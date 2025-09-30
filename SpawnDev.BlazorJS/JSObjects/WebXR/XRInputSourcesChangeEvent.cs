using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebXR Device API interface XRInputSourcesChangeEvent is used to represent the inputsourceschange event sent to an XRSession when the set of available WebXR input controllers changes.
    /// </summary>
    public class XRInputSourcesChangeEvent : Event
    {
        /// <inheritdoc/>
        public XRInputSourcesChangeEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The XRSession to which the event refers.
        /// </summary>
        public XRSession Session => JSRef!.Get<XRSession>("session");
        /// <summary>
        /// An array of zero or more XRInputSource objects, each representing an input device which has been newly connected or enabled for use.
        /// </summary>
        public XRInputSource[] Added => JSRef!.Get<XRInputSource[]>("added");
        /// <summary>
        /// An array of zero or more XRInputSource objects representing the input devices newly connected or enabled for use.
        /// </summary>
        public XRInputSource[] Removed => JSRef!.Get<XRInputSource[]>("removed");
    }
}
