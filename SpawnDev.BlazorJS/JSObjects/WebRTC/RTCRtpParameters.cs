using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// Base dictionary for RTCRtpSender.GetParameters / SetParameters and
    /// RTCRtpReceiver.GetParameters. Carries the round-trip-only fields (codecs,
    /// header extensions, rtcp) that browsers set from the negotiated SDP and
    /// consumers must not edit.<br/>
    /// https://www.w3.org/TR/webrtc/#dom-rtcrtpparameters
    /// </summary>
    public class RTCRtpParameters
    {
        /// <summary>
        /// Negotiated codecs for this sender/receiver. Read-from getParameters +
        /// pass back unchanged on setParameters - use setCodecPreferences on the
        /// transceiver to actually influence codec selection.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("codecs")]
        public RTCRtpCodecParameters[]? Codecs { get; set; }

        /// <summary>Negotiated RTP header extensions. Round-trip-only.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("headerExtensions")]
        public RTCRtpHeaderExtensionParameters[]? HeaderExtensions { get; set; }

        /// <summary>RTCP parameters (cname, reducedSize). Round-trip-only.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("rtcp")]
        public RTCRtcpParameters? Rtcp { get; set; }
    }
}
