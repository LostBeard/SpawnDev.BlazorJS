using Microsoft.JSInterop;


namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    public class RTCPeerConnectionEvent : Event
    {
        public RTCPeerConnectionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public RTCIceCandidate Candidate => JSRef.Get<RTCIceCandidate>("candidate");
    }
}
