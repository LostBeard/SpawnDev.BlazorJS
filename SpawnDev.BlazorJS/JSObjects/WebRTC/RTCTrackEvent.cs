using Microsoft.JSInterop;


namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    public class RTCTrackEvent : Event
    {
        public RTCTrackEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public RTCRtpReceiver Receiver => JSRef!.Get<RTCRtpReceiver>("receiver");
        public MediaStream[] Streams => JSRef!.Get<MediaStream[]>("streams");
        public MediaStreamTrack Track => JSRef!.Get<MediaStreamTrack>("track");
        public RTCRtpTransceiver Transceiver => JSRef!.Get<RTCRtpTransceiver>("transceiver");
    }
}
