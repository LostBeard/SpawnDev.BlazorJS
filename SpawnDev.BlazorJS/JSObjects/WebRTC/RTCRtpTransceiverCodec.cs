using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// RTCRtpTransceiverCodec
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCRtpTransceiver/setCodecPreferences#channels
    /// </summary>
    public class RTCRtpTransceiverCodec
    {
        /// <summary>
        /// A positive integer value indicating the maximum number of channels supported by the codec; for example, a codec that supports only mono sound would have a value of 1; stereo codecs would have a 2, etc.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Channels { get; set; }
        /// <summary>
        /// A positive integer specifying the codec's clock rate in Hertz (Hz). The IANA maintains a list of codecs and their parameters, including their clock rates.
        /// </summary>
        public int ClockRate { get; set; }
        /// <summary>
        /// A string indicating the codec's MIME media type and subtype. The MIME type strings used by RTP differ from those used elsewhere. See RFC 3555, section 4 for the complete IANA registry of these types. Also see Codecs used by WebRTC for details about potential codecs that might be referenced here.
        /// </summary>
        public string MimeType { get; set; }
        /// <summary>
        /// A string giving the format specific parameters field from the a=fmtp line in the SDP which corresponds to the codec, if such a line exists. If there is no parameters field, this property is left out.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SdpFmtpLine { get; set; }
    }
}
