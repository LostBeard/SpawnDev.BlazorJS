using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// One RTP header extension (RFC 8285) parameter entry carried on RTCRtpParameters.
    /// Negotiated via SDP <c>a=extmap</c>; consumers round-trip these through
    /// setParameters rather than editing them.<br/>
    /// https://www.w3.org/TR/webrtc/#dom-rtcrtpheaderextensionparameters
    /// </summary>
    public class RTCRtpHeaderExtensionParameters
    {
        /// <summary>URI identifying the header extension (e.g. <c>"urn:ietf:params:rtp-hdrext:ssrc-audio-level"</c>).</summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; } = "";

        /// <summary>
        /// Extension ID (1-14 one-byte header or 1-255 two-byte header) negotiated in SDP.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Whether this extension is carried over SRTP-encrypted header extensions
        /// (RFC 6904).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("encrypted")]
        public bool? Encrypted { get; set; }
    }
}
