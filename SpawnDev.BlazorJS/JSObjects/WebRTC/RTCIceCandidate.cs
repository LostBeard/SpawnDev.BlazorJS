using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{

    // https://developer.mozilla.org/en-US/docs/Web/API/RTCIceCandidate/RTCIceCandidate
    public class RTCIceCandidate : JSObject
    {
        // MDN states that RTCIceCandidate can be created with "new RTCIceCandidate()", but Chrome throws an exception (below)
        // VM452:1 Uncaught TypeError: Failed to construct 'RTCIceCandidate': sdpMid and sdpMLineIndex are both null.
        // MDN also states "Note: For backward compatibility with older versions of the WebRTC specification, the constructor also accepts this string directly as an argument."
        // but Chrome does not allow that either and will give the below exception
        // Uncaught TypeError: Failed to construct 'RTCIceCandidate': The provided value is not of type 'RTCIceCandidateInit'. at<anonymous>:1:10
        // Firefox throws exceptions similar exceptions for both cases
        // Uncaught TypeError: RTCIceCandidate constructor: Argument 1 can't be converted to a dictionary.
        public RTCIceCandidate(RTCIceCandidateInit candidate) : base(JS.New(nameof(RTCIceCandidate), candidate)) { }
        public string ToJSON() => JSRef.Call<string>("toJSON");
        public RTCIceCandidate(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string containing the IP address of the candidate.
        /// </summary>
        public string Address { get => JSRef.Get<string>("address"); set => JSRef.Set("address", value); }
        /// <summary>
        /// A string representing the transport address for the candidate that can be used for connectivity checks. The format of this address is a candidate-attribute as defined in RFC 5245. This string is empty ("") if the RTCIceCandidate is an "end of candidates" indicator.
        /// </summary>
        public string Candidate { get => JSRef.Get<string>("candidate"); set => JSRef.Set("candidate", value); }
        /// <summary>
        /// A string which indicates whether the candidate is an RTP or an RTCP candidate; its value is either rtp or rtcp, and is derived from the "component-id" field in the candidate a-line string.
        /// </summary>
        public string Component { get => JSRef.Get<string>("component"); set => JSRef.Set("component", value); }
        /// <summary>
        /// Returns a string containing a unique identifier that is the same for any candidates of the same type, share the same base (the address from which the ICE agent sent the candidate), and come from the same STUN server. This is used to help optimize ICE performance while prioritizing and correlating candidates that appear on multiple RTCIceTransport objects.
        /// </summary>
        public string Foundation { get => JSRef.Get<string>("foundation"); set => JSRef.Set("foundation", value); }
        /// <summary>
        /// An integer value indicating the candidate's port number.
        /// </summary>
        public int? Port { get => JSRef.Get<int?>("port"); set => JSRef.Set("port", value); }
        /// <summary>
        /// A long integer value indicating the candidate's priority.
        /// </summary>
        public int? Priority { get => JSRef.Get<int?>("priority"); set => JSRef.Set("priority", value); }
        /// <summary>
        /// A string indicating whether the candidate's protocol is "tcp" or "udp"
        /// </summary>
        public string Protocol { get => JSRef.Get<string>("protocol"); set => JSRef.Set("protocol", value); }
        /// <summary>
        /// If the candidate is derived from another candidate, relatedAddress is a string containing that host candidate's IP address. For host candidates, this value is nul
        /// </summary>
        public string? RelatedAddress { get => JSRef.Get<string?>("relatedAddress"); set => JSRef.Set("relatedAddress", value); }
        /// <summary>
        /// For a candidate that is derived from another, such as a relay or reflexive candidate, the relatedPort is a number indicating the port number of the candidate from which this candidate is derived. For host candidates, the relatedPort property is null.
        /// </summary>
        public int? RelatedPort { get => JSRef.Get<int?>("relatedPort"); set => JSRef.Set("relatedPort", value); }
        /// <summary>
        /// A string specifying the candidate's media stream identification tag which uniquely identifies the media stream within the component with which the candidate is associated, or null if no such association exists.
        /// </summary>
        public string SdpMid { get => JSRef.Get<string>("sdpMid"); set => JSRef.Set("sdpMid", value); }
        /// <summary>
        /// If not null, sdpMLineIndex indicates the zero-based index number of the media description (as defined in RFC 4566) in the SDP with which the candidate is associated.
        /// </summary>
        public int? SdpMLineIndex { get => JSRef.Get<int?>("sdpMLineIndex"); set => JSRef.Set("sdpMLineIndex", value); }
        /// <summary>
        /// If protocol is "tcp", tcpType represents the type of TCP candidate. Otherwise, tcpType is null
        /// </summary>
        public string TcpType { get => JSRef.Get<string>("tcpType"); set => JSRef.Set("tcpType", value); }
        /// <summary>
        /// A string indicating the type of candidate as one of the strings listed on RTCIceCandidate.type.
        /// </summary>
        public string Type { get => JSRef.Get<string>("type"); set => JSRef.Set("type", value); }
        /// <summary>
        /// A string containing a randomly-generated username fragment ("ice-ufrag") which ICE uses for message integrity along with a randomly-generated password ("ice-pwd"). You can use this string to verify generations of ICE generation; each generation of the same ICE process will use the same usernameFragment, even across ICE restarts.
        /// </summary>
        public string UsernameFragment { get => JSRef.Get<string>("usernameFragment"); set => JSRef.Set("usernameFragment", value); }
    }
    //public class RTCIceCandidateObj
    //{
    //    /// <summary>
    //    /// A string containing the IP address of the candidate.
    //    /// </summary>
    //    public string Address { get; set; } = "";
    //    /// <summary>
    //    /// A string representing the transport address for the candidate that can be used for connectivity checks. The format of this address is a candidate-attribute as defined in RFC 5245. This string is empty ("") if the RTCIceCandidate is an "end of candidates" indicator.
    //    /// </summary>
    //    public string Candidate { get; set; } = "";
    //    /// <summary>
    //    /// A string which indicates whether the candidate is an RTP or an RTCP candidate; its value is either rtp or rtcp, and is derived from the "component-id" field in the candidate a-line string.
    //    /// </summary>
    //    public string Component { get; set; } = "";
    //    /// <summary>
    //    /// Returns a string containing a unique identifier that is the same for any candidates of the same type, share the same base (the address from which the ICE agent sent the candidate), and come from the same STUN server. This is used to help optimize ICE performance while prioritizing and correlating candidates that appear on multiple RTCIceTransport objects.
    //    /// </summary>
    //    public string Foundation { get; set; } = "";
    //    /// <summary>
    //    /// An integer value indicating the candidate's port number.
    //    /// </summary>
    //    public int? Port { get; set; }
    //    /// <summary>
    //    /// A long integer value indicating the candidate's priority.
    //    /// </summary>
    //    public int? Priority { get; set; }
    //    /// <summary>
    //    /// A string indicating whether the candidate's protocol is "tcp" or "udp"
    //    /// </summary>
    //    public string Protocol { get; set; } = "";
    //    /// <summary>
    //    /// If the candidate is derived from another candidate, relatedAddress is a string containing that host candidate's IP address. For host candidates, this value is nul
    //    /// </summary>
    //    public string? RelatedAddress { get; set; } = "";
    //    /// <summary>
    //    /// For a candidate that is derived from another, such as a relay or reflexive candidate, the relatedPort is a number indicating the port number of the candidate from which this candidate is derived. For host candidates, the relatedPort property is null.
    //    /// </summary>
    //    public int? RelatedPort { get; set; }
    //    /// <summary>
    //    /// A string specifying the candidate's media stream identification tag which uniquely identifies the media stream within the component with which the candidate is associated, or null if no such association exists.
    //    /// </summary>
    //    public string SdpMid { get; set; } = "";
    //    /// <summary>
    //    /// If not null, sdpMLineIndex indicates the zero-based index number of the media description (as defined in RFC 4566) in the SDP with which the candidate is associated.
    //    /// </summary>
    //    public int? SdpMLineIndex { get; set; }
    //    /// <summary>
    //    /// If protocol is "tcp", tcpType represents the type of TCP candidate. Otherwise, tcpType is null
    //    /// </summary>
    //    public string TcpType { get; set; } = "";
    //    /// <summary>
    //    /// A string indicating the type of candidate as one of the strings listed on RTCIceCandidate.type.
    //    /// </summary>
    //    public string Type { get; set; } = "";
    //    /// <summary>
    //    /// A string containing a randomly-generated username fragment ("ice-ufrag") which ICE uses for message integrity along with a randomly-generated password ("ice-pwd"). You can use this string to verify generations of ICE generation; each generation of the same ICE process will use the same usernameFragment, even across ICE restarts.
    //    /// </summary>
    //    public string UsernameFragment { get; set; } = "";
    //}
}
