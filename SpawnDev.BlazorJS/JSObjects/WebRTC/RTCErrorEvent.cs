using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    public class RTCErrorEvent : Event
    {
        public RTCErrorEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public RTCError Error => JSRef.Get<RTCError>("error");
    }
}
