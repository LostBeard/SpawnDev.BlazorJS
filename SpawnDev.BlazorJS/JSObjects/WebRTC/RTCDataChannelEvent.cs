using Microsoft.JSInterop;


namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    public class RTCDataChannelEvent : Event
    {
        public RTCDataChannelEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public RTCDataChannel Channel => JSRef.Get<RTCDataChannel>("channel");
    }
}
