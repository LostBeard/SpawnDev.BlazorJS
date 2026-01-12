using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCErrorEvent interface represents an error that occurred while using the WebRTC API.
    /// </summary>
    public class RTCErrorEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCErrorEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The error that occurred.
        /// </summary>
        public RTCError Error => JSRef!.Get<RTCError>("error");
    }
}
