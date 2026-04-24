using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// RTCP (RTP Control Protocol) parameters carried on RTCRtpParameters. Read-only
    /// in practice - browsers populate these from the negotiated SDP; consumers
    /// round-trip them through setParameters unchanged.<br/>
    /// https://www.w3.org/TR/webrtc/#dom-rtcrtcpparameters
    /// </summary>
    public class RTCRtcpParameters
    {
        /// <summary>
        /// Canonical Name (CNAME) identifying the RTP source (RFC 3550 §6.5.1).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("cname")]
        public string? Cname { get; set; }

        /// <summary>
        /// Whether reduced-size RTCP (RFC 5506) is in use on this stream.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("reducedSize")]
        public bool? ReducedSize { get; set; }
    }
}
