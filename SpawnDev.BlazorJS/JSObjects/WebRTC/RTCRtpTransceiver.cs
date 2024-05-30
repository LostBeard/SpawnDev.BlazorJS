using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The WebRTC interface RTCRtpTransceiver describes a permanent pairing of an RTCRtpSender and an RTCRtpReceiver, along with some shared state.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCRtpTransceiver
    /// </summary>
    public class RTCRtpTransceiver : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCRtpTransceiver(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Permanently stops the RTCRtpTransceiver. The associated sender stops sending data, and the associated receiver likewise stops receiving and decoding incoming data.
        /// </summary>
        public void Stop() => JSRef!.CallVoid("stop");
        /// <summary>
        /// A list of RTCRtpCodecParameters objects which override the default preferences used by the user agent for the transceiver's codecs.
        /// </summary>
        /// <param name="codecs"></param>
        public void SetCodecPreferences(RTCRtpTransceiverCodec[] codecs) => JSRef!.CallVoid("setCodecPreferences", codecs);
        /// <summary>
        /// A read-only string which indicates the transceiver's current negotiated directionality, or null if the transceiver has never participated in an exchange of offers and answers. To change the transceiver's directionality, set the value of the direction property.
        /// </summary>
        public string CurrentDirection => JSRef!.Get<string>("currentDirection");
        /// <summary>
        /// The RTCRtpTransceiver property direction is a string which indicates the transceiver's preferred directionality.
        /// </summary>
        public string Direction { get => JSRef!.Get<string>("direction"); set => JSRef!.Set("direction", value); }
        /// <summary>
        /// The media ID of the m-line associated with this transceiver. This association is established, when possible, whenever either a local or remote description is applied. This field is null if neither a local or remote description has been applied, or if its associated m-line is rejected by either a remote offer or any answer.
        /// </summary>
        public string? Mid => JSRef!.Get<string?>("mid");
        /// <summary>
        /// The RTCRtpReceiver object that handles receiving and decoding incoming media.
        /// </summary>
        public RTCRtpReceiver Receiver => JSRef!.Get<RTCRtpReceiver>("receiver");
        /// <summary>
        /// The RTCRtpSender object responsible for encoding and sending data to the remote peer.
        /// </summary>
        public RTCRtpSender Sender => JSRef!.Get<RTCRtpSender>("sender");
    }
}
