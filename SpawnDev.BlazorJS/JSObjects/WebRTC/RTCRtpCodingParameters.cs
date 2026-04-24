using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// Base dictionary for encoding/decoding parameters. Provides the per-encoding
    /// restriction identifier (RID) used by simulcast to distinguish encodings in
    /// the same m= section.<br/>
    /// https://www.w3.org/TR/webrtc/#dom-rtcrtpcodingparameters
    /// </summary>
    public class RTCRtpCodingParameters
    {
        /// <summary>
        /// RTP stream identifier (RID) for this encoding. Max 16 alphanumeric / `-` / `_`
        /// characters. Lets simulcast signal multiple encodings in one m= line so the
        /// receiver can tell them apart in the SDP a=rid and RTP header extension.
        /// Read-only after the initial createOffer (browsers reject RID changes at
        /// setParameters time per RFC 8853).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("rid")]
        public string? Rid { get; set; }
    }
}
