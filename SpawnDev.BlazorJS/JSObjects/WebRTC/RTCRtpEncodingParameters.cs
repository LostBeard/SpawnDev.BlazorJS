using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// Per-encoding parameters for an RTCRtpSender. The array-of-these field
    /// <c>encodings</c> on RTCRtpSendParameters is what simulcast is built on:
    /// pass 2+ encodings (each with its own <see cref="RTCRtpCodingParameters.Rid"/>,
    /// bitrate cap, resolution scale) to emit multiple parallel encodings of the
    /// same track.<br/>
    /// https://www.w3.org/TR/webrtc/#dom-rtcrtpencodingparameters
    /// </summary>
    public class RTCRtpEncodingParameters : RTCRtpCodingParameters
    {
        /// <summary>
        /// Whether this encoding is currently being sent. Default true. Set false to
        /// temporarily mute an encoding without removing it from the parameters.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// Maximum bitrate the encoder may use for this encoding, in bits per second.
        /// Not present = browser default (typically ~2.5 Mbps for video). Typical
        /// simulcast layering: 180p = 150_000, 360p = 500_000, 720p = 2_500_000.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("maxBitrate")]
        public uint? MaxBitrate { get; set; }

        /// <summary>
        /// Maximum frame rate in frames per second. Omit for the encoder's default.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("maxFramerate")]
        public double? MaxFramerate { get; set; }

        /// <summary>
        /// Factor by which to scale the source resolution down before encoding this
        /// layer. 1.0 = full, 2.0 = half-dimensions, 4.0 = quarter-dimensions.
        /// Simulcast layering typically uses 1.0 / 2.0 / 4.0 in the same
        /// <c>encodings</c> array to produce 720p + 360p + 180p from a 720p source.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("scaleResolutionDownBy")]
        public double? ScaleResolutionDownBy { get; set; }

        /// <summary>
        /// Scalability mode identifier per the Scalable Video Coding spec (e.g.
        /// <c>"L1T1"</c>, <c>"L1T3"</c>, <c>"L3T3_KEY"</c>). Non-simulcast SVC layering
        /// uses this instead of multiple encodings.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("scalabilityMode")]
        public string? ScalabilityMode { get; set; }

        /// <summary>
        /// Application-level priority hint: <c>"very-low"</c>, <c>"low"</c>,
        /// <c>"medium"</c> (default), <c>"high"</c>.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("priority")]
        public string? Priority { get; set; }

        /// <summary>
        /// Network-level DSCP priority hint, same set as <see cref="Priority"/>.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("networkPriority")]
        public string? NetworkPriority { get; set; }
    }
}
