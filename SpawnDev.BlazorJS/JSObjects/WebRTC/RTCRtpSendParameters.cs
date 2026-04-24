using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// Parameters for the send side of an RTP stream, returned by
    /// <see cref="RTCRtpSender.GetParameters"/> and passed back (possibly modified)
    /// to <see cref="RTCRtpSender.SetParameters"/>. The simulcast knobs are in
    /// <see cref="Encodings"/> - one encoding per simulcast layer, each with its
    /// own RID, bitrate cap, and resolution scale.<br/>
    /// https://www.w3.org/TR/webrtc/#dom-rtcrtpsendparameters
    /// </summary>
    public class RTCRtpSendParameters : RTCRtpParameters
    {
        /// <summary>
        /// Opaque token the browser generates on getParameters. Pass back unchanged
        /// on setParameters - setParameters rejects any call where transactionId
        /// doesn't match the value from the last getParameters (prevents lost-update
        /// races). Don't try to synthesize this value yourself.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("transactionId")]
        public string? TransactionId { get; set; }

        /// <summary>
        /// Per-encoding parameters. A single-encoding array is the default (no
        /// simulcast); a multi-encoding array turns on simulcast with one layer
        /// per entry. Non-simulcast SVC layering uses a single encoding with
        /// <see cref="RTCRtpEncodingParameters.ScalabilityMode"/> set.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("encodings")]
        public RTCRtpEncodingParameters[]? Encodings { get; set; }
    }
}
