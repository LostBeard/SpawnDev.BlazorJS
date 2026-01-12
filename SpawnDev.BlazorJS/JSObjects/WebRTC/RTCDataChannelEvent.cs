using Microsoft.JSInterop;


namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCDataChannelEvent interface represents an event that is fired when an RTCDataChannel is added to an RTCPeerConnection.
    /// </summary>
    public class RTCDataChannelEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCDataChannelEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The RTCDataChannel that was added to the connection.
        /// </summary>
        public RTCDataChannel Channel => JSRef!.Get<RTCDataChannel>("channel");
    }
}
