using Microsoft.JSInterop;


namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    public class RTCPeerConnectionIceErrorEvent : Event
    {
        public RTCPeerConnectionIceErrorEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string? Address => JSRef!.Get<string?>("address");
        public uint? Port => JSRef!.Get<uint?>("port");
        public uint ErrorCode => JSRef!.Get<uint>("errorCode");
        public string ErrorText => JSRef!.Get<string>("errorText");
        public string Url => JSRef!.Get<string>("url");
    }
}
