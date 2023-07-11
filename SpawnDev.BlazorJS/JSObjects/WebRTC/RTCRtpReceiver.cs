using Microsoft.JSInterop;


namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    public class RTCRtpReceiver : JSObject
    {
        public RTCRtpReceiver(IJSInProcessObjectReference _ref) : base(_ref) { }
        public MediaStreamTrack Track => JSRef.Get<MediaStreamTrack>("track");
        public RTCDtlsTransport Transport => JSRef.Get<RTCDtlsTransport>("transport");
        /// <summary>
        /// The static method RTCRtpReceiver.getCapabilities() returns an object describing the codec and header extension capabilities supported by RTCRtpReceiver objects on the current device.
        /// </summary>
        /// <param name="kind">A string indicating the type of media for which the browser's receiver capabilities are requested. The supported media kinds are: audio and video.</param>
        /// <returns>A new object that indicates what capabilities the browser has for receiving the specified media kind over an RTCPeerConnection. If the browser doesn't have any support for the given media kind, the returned value is null.</returns>
        public static RTCRtpSenderCapabilities GetCapabilities(string kind) => JS.Call<RTCRtpSenderCapabilities>("getCapabilities");
    }
}
