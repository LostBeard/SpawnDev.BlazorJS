using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// One codec's negotiated parameters inside RTCRtpParameters. Populated from the
    /// negotiated SDP m= section; consumers round-trip these through setParameters
    /// rather than editing them (setCodecPreferences is the right knob for choosing
    /// codecs).<br/>
    /// https://www.w3.org/TR/webrtc/#dom-rtcrtpcodecparameters
    /// </summary>
    public class RTCRtpCodecParameters
    {
        /// <summary>RTP payload type (SDP <c>a=rtpmap</c> first field, e.g. 96, 111).</summary>
        [JsonPropertyName("payloadType")]
        public int PayloadType { get; set; }

        /// <summary>Codec MIME type (e.g. <c>"video/VP8"</c>, <c>"audio/opus"</c>).</summary>
        [JsonPropertyName("mimeType")]
        public string MimeType { get; set; } = "";

        /// <summary>Codec clock rate in Hz (e.g. 90000 for video, 48000 for Opus).</summary>
        [JsonPropertyName("clockRate")]
        public int ClockRate { get; set; }

        /// <summary>Audio channel count. Present for audio codecs; omitted for video.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("channels")]
        public int? Channels { get; set; }

        /// <summary>
        /// Codec-specific format parameters from SDP <c>a=fmtp</c> (e.g. H.264 profile-level-id,
        /// Opus maxaveragebitrate).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("sdpFmtpLine")]
        public string? SdpFmtpLine { get; set; }
    }
}
