using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    public class RTCIceCandidateInit
    {        
        public static explicit operator RTCIceCandidate(RTCIceCandidateInit candidate) => new RTCIceCandidate(candidate);

        public static explicit operator RTCIceCandidateInit(RTCIceCandidate candidate) => 
            new RTCIceCandidateInit { 
                Candidate = candidate.Candidate, 
                SdpMLineIndex = candidate.SdpMLineIndex, 
                SdpMid = candidate.SdpMid 
            };

        /// <summary>
        /// A string describing the properties of the candidate, taken directly from the SDP attribute "candidate". The candidate string specifies the network connectivity information for the candidate. If the candidate is an empty string (""), the end of the candidate list has been reached; this candidate is known as the "end-of-candidates" marker.<br/>
        /// The syntax of the candidate string is described in RFC 5245, section 15.1. <br/>
        /// For an a-line (attribute line) that looks like this:<br/>
        /// a=candidate:4234997325 1 udp 2043278322 192.168.0.56 44323 typ host
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Candidate { get; set; } = null;

        /// <summary>
        /// A string containing the identification tag of the media stream with which the candidate is associated, or null if there is no associated media stream. The default is null.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SdpMid { get; set; } = null;

        /// <summary>
        /// A number property containing the zero-based index of the m-line with which the candidate is associated, within the SDP of the media description, or null if no such associated exists. The default is null.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SdpMLineIndex { get; set; } = null;

        /// <summary>
        /// A string containing the username fragment (usually referred to in shorthand as "ufrag" or "ice-ufrag"). This fragment, along with the ICE password ("ice-pwd"), uniquely identifies a single ongoing ICE interaction (including for any communication with the STUN server).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? UsernameFragment { get; set; } = null;
    }
}
