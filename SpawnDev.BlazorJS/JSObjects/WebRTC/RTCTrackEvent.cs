using Microsoft.JSInterop;


namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCTrackEvent interface, part of the WebRTC API, represents an event which is sent when a new MediaStreamTrack has been added to an RTCRtpReceiver which is part of an RTCPeerConnection.
    /// </summary>
    public class RTCTrackEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCTrackEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The RTCRtpReceiver used by the track that is indicated by the event.
        /// </summary>
        public RTCRtpReceiver Receiver => JSRef!.Get<RTCRtpReceiver>("receiver");
        /// <summary>
        /// An array of MediaStream objects, each representing one of the media streams that include the event's track.
        /// </summary>
        public MediaStream[] Streams => JSRef!.Get<MediaStream[]>("streams");
        /// <summary>
        /// The MediaStreamTrack which has been added to the connection.
        /// </summary>
        public MediaStreamTrack Track => JSRef!.Get<MediaStreamTrack>("track");
        /// <summary>
        /// The RTCRtpTransceiver being used by the new track.
        /// </summary>
        public RTCRtpTransceiver Transceiver => JSRef!.Get<RTCRtpTransceiver>("transceiver");
    }
}
