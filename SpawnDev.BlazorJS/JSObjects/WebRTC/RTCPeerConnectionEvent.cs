using Microsoft.JSInterop;


namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCPeerConnectionEvent interface represents an event that is fired when an RTCPeerConnection receives an ICE candidate.
    /// </summary>
    public class RTCPeerConnectionEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCPeerConnectionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The RTCIceCandidate that was received.
        /// </summary>
        public RTCIceCandidate Candidate => JSRef!.Get<RTCIceCandidate>("candidate");
    }
}
