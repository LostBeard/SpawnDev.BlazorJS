using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRSessionEvent
    /// </summary>
    public class XRSessionEvent : Event
    {
        /// <inheritdoc/>
        public XRSessionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The XRSession to which the event refers.
        /// </summary>
        public XRSession Session => JSRef!.Get<XRSession>("session");
    }
}
