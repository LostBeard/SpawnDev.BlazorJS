using Microsoft.JSInterop;


namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCRtpSender interface provides the ability to control and obtain details about how a particular MediaStreamTrack is encoded and sent to a remote peer.
    /// </summary>
    public class RTCRtpSender : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCRtpSender(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The track read-only property of the RTCRtpSender interface returns the MediaStreamTrack which is being handled by the RTCRtpSender.
        /// </summary>
        public MediaStreamTrack Track => JSRef!.Get<MediaStreamTrack>("track");
        /// <summary>
        /// The transport read-only property of the RTCRtpSender interface returns the RTCDtlsTransport used by the sender to transmit networked packets of media data to the remote peer.
        /// </summary>
        public RTCDtlsTransport Transport => JSRef!.Get<RTCDtlsTransport>("transport");
        /// <summary>
        /// The dtmf read-only property of the RTCRtpSender interface returns an RTCDTMFSender which can be used to send DTMF tones over the PeerConnection.
        /// </summary>
        public RTCDTMFSender DTMF => JSRef!.Get<RTCDTMFSender>("dtmf");
        /// <summary>
        /// The static method RTCRtpSender.getCapabilities() returns an object describing the codec and header extension capabilities supported by the RTCRtpSender.
        /// </summary>
        /// <param name="kind">A string indicating the type of media for which the browser's send capabilities are requested. The supported media kinds are: audio and video.</param>
        /// <returns>A new object that indicates what capabilities the browser has for sending the specified media kind over an RTCPeerConnection. If the browser doesn't have any support for the given media kind, the returned value is null.</returns>
        public static RTCRtpSenderCapabilities GetCapabilities(string kind) => JS.Call<RTCRtpSenderCapabilities>("getCapabilities");

        /// <summary>
        /// The RTCRtpSender.replaceTrack() method replaces the track currently being used as the sender's source with a new MediaStreamTrack.
        /// </summary>
        /// <param name="newTrack">A MediaStreamTrack specifying the track with which to replace the existing one. The new track must be of the same media kind (audio or video) as the old one. If this parameter is null, the sender's current track is removed without being replaced by a new one.</param>
        /// <returns>A Promise which is fulfilled once the track has been successfully replaced. The promise is rejected if the track cannot be replaced for any reason. The fulfillment handler receives no input parameters.</returns>
        public Task ReplaceTrack(MediaStreamTrack newTrack) => JSRef!.CallVoidAsync("replaceTrack", newTrack);
        /// <summary>
        /// The setStreams() method of the RTCRtpSender interface sets the streams associated with this sender's track.
        /// </summary>
        public void SetStreams() => JSRef!.CallVoid("setStreams");
        /// <summary>
        /// The setStreams() method of the RTCRtpSender interface sets the streams associated with this sender's track.
        /// </summary>
        /// <param name="mediaStreams">An array of MediaStream objects (or a single MediaStream) which identify the streams to which the sender's track should belong.</param>
        public void SetStreams(params MediaStream[] mediaStreams) => JSRef!.CallApplyVoid("setStreams", mediaStreams);
    }
}
