using Microsoft.JSInterop;


namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    public class RTCRtpSender : JSObject
    {
        public RTCRtpSender(IJSInProcessObjectReference _ref) : base(_ref) { }
        public MediaStreamTrack Track => JSRef.Get<MediaStreamTrack>("track");
        public RTCDtlsTransport Transport => JSRef.Get<RTCDtlsTransport>("transport");
        public RTCDTMFSender DTMF => JSRef.Get<RTCDTMFSender>("dtmf");
        /// <summary>
        /// The static method RTCRtpSender.getCapabilities() returns an object describing the codec and header extension capabilities supported by the RTCRtpSender.
        /// </summary>
        /// <param name="kind">A string indicating the type of media for which the browser's send capabilities are requested. The supported media kinds are: audio and video.</param>
        /// <returns>A new object that indicates what capabilities the browser has for sending the specified media kind over an RTCPeerConnection. If the browser doesn't have any support for the given media kind, the returned value is null.</returns>
        public static RTCRtpSenderCapabilities GetCapabilities(string kind) => JS.Call<RTCRtpSenderCapabilities>("getCapabilities");

        public Task ReplaceTrack(MediaStreamTrack newTrack) => JSRef.CallVoidAsync("replaceTrack", newTrack);
        public void SetStreams() => JSRef.CallVoid("setStreams");
        public void SetStreams(params MediaStream[] mediaStreams) => JSRef.CallApplyVoid("setStreams", mediaStreams);
    }
}
