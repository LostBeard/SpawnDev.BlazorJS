using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCIceCandidateInfo interface of the WebRTC API represents a candidate Internet Connectivity Establishment (ICE) configuration which may be used to establish an RTCPeerConnection.
    /// </summary>
    public class RTCIceCandidateInfo
    {
        /// <summary>
        /// A string describing the properties of the candidate, taken directly from the SDP attribute "candidate". The candidate string specifies the network connectivity information for the candidate. If the candidate is an empty string (""), the end of the candidate list has been reached; this candidate is known as the "end-of-candidates" marker.<br/>
        /// The syntax of the candidate string is described in RFC 5245, section 15.1. <br/>
        /// For an a-line (attribute line) that looks like this:<br/>
        /// a=candidate:4234997325 1 udp 2043278322 192.168.0.56 44323 typ host
        /// </summary>
        [JsonPropertyName("candidate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Candidate { get; set; }
        /// <summary>
        /// A string containing the identification tag of the media stream with which the candidate is associated, or null if there is no associated media stream. The default is null.
        /// </summary>
        [JsonPropertyName("sdpMid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SdpMid { get; set; }
        /// <summary>
        /// A number property containing the zero-based index of the m-line with which the candidate is associated, within the SDP of the media description, or null if no such associated exists. The default is null.
        /// </summary>
        [JsonPropertyName("sdpMLineIndex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SdpMLineIndex { get; set; }
        /// <summary>
        /// A string containing the username fragment (usually referred to in shorthand as "ufrag" or "ice-ufrag"). This fragment, along with the ICE password ("ice-pwd"), uniquely identifies a single ongoing ICE interaction (including for any communication with the STUN server).
        /// </summary>
        [JsonPropertyName("usernameFragment")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? UsernameFragment { get; set; }
    }
}
