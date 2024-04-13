using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCIceCandidateStats dictionary of the WebRTC API is used to report statistics related to an RTCIceCandidate.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCIceCandidateStats
    /// </summary>
    public class RTCIceCandidateStats : RTCStats
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCIceCandidateStats(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string containing the address of the candidate. This value may be an IPv4 address, an IPv6 address, or a fully-qualified domain name. This property was previously named ip and only accepted IP addresses.
        /// </summary>
        public string? Address => JSRef.Get<string?>("address");
        /// <summary>
        /// A string matching one of the values in RTCIceCandidate.type, indicating what kind of candidate the object provides statistics for.
        /// </summary>
        public string CandidateType => JSRef.Get<string>("candidateType");
        /// <summary>
        /// A Boolean value indicating whether or not the candidate has been released or deleted; the default value is false. For local candidates, its value is true if the candidate has been deleted or released. For host candidates, true means that any network resources (usually a network socket) associated with the candidate have already been released. For TURN candidates, the TURN allocation is no longer active for deleted candidates. This property is not present for remote candidates.
        /// </summary>
        public bool? Deleted => JSRef.Get<bool?>("deleted");
        /// <summary>
        /// The network port number used by the candidate.
        /// </summary>
        public Union<ushort, string>? Port => JSRef.Get<Union<ushort, string>?>("port");
        /// <summary>
        /// The candidate's priority, corresponding to RTCIceCandidate.priority.
        /// </summary>
        public ulong? Priority => JSRef.Get<ulong?>("priority");
        /// <summary>
        /// A string specifying the protocol (tcp or udp) used to transmit data on the port.
        /// </summary>
        public string? Protocol => JSRef.Get<string?>("protocol");
        /// <summary>
        /// A string identifying the protocol used by the endpoint for communicating with the TURN server; valid values are tcp, udp, and tls. Only present for local candidates.
        /// </summary>
        public string? RelayProtocol => JSRef.Get<string?>("relayProtocol");
        /// <summary>
        /// A string uniquely identifying the transport object that was inspected in order to obtain the RTCTransportStats associated with the candidate corresponding to these statistics.
        /// </summary>
        public string TransportId => JSRef.Get<string>("transportId");
        /// <summary>
        /// For local candidates, the url property is the URL of the ICE server from which the candidate was received. This URL matches the one included in the RTCPeerConnectionIceEvent object representing the icecandidate event that delivered the candidate to the local peer.
        /// </summary>
        public string? Url => JSRef.Get<string?>("url");
    }
}
