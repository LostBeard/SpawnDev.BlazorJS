using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// Configuration passed to new RTCPeerConnection<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/RTCPeerConnection#configuration
    /// </summary>
    public class RTCConfiguration
    {
        /// <summary>
        /// SDPSemanticsUnifiedPlanWithFallback prefers unified-plan offers and answers, but will respond to a plan-b offer with a plan-b answer
        /// </summary>
        public const string SdpSemanticsUnifiedPlanWithFallback = "unified-plan-with-fallback";
        /// <summary>
        /// SDPSemanticsUnifiedPlan uses unified-plan offers and answers (the default in Chrome since M72) https://tools.ietf.org/html/draft-roach-mmusic-unified-plan-00
        /// </summary>
        public const string SdpSemanticsUnifiedPlan = "unified-plan";
        /// <summary>
        /// SDPSemanticsPlanB uses plan-b offers and answers NB: This format should be considered deprecated https://tools.ietf.org/html/draft-uberti-rtcweb-plan-00
        /// </summary>
        public const string SdpSemanticsPlanB = "plan-b";
        /// <summary>
        /// SDPSemantics determines which style of SDP offers and answers
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SdpSemantics { get; set; }
        /// <summary>
        /// An array of objects, each describing one server which may be used by the ICE agent; these are typically STUN and/or TURN servers. If this isn't specified, the connection attempt will be made with no STUN or TURN server available, which limits the connection to local peers. Each object may have the following properties:
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RTCIceServer[]? IceServers { get; set; }
        /// <summary>
        /// Specifies how to handle negotiation of candidates when the remote peer is not compatible with the SDP BUNDLE standard. If the remote endpoint is BUNDLE-aware, all media tracks and data channels are bundled onto a single transport at the completion of negotiation, regardless of policy used, and any superfluous transports that were created initially are closed at that point.<br/>
        /// In technical terms, a BUNDLE lets all media flow between two peers flow across a single 5-tuple; that is, from a single IP and port on one peer to a single IP and port on the other peer, using the same transport protocol.<br/>
        /// This must be one of the following string values, if not balanced is assumed:<br/>
        /// "balanced" - The ICE agent initially creates one RTCDtlsTransport for each type of content added: audio, video, and data channels. If the remote endpoint is not BUNDLE-aware, then each of these DTLS transports handles all the communication for one type of data.<br/>
        /// "max-compat" - The ICE agent initially creates one RTCDtlsTransport per media track and a separate one for data channels. If the remote endpoint is not BUNDLE-aware, everything is negotiated on these separate DTLS transports.<br/>
        /// "max-bundle" - The ICE agent initially creates only a single RTCDtlsTransport to carry all of the RTCPeerConnection's data. If the remote endpoint is not BUNDLE-aware, then only a single track will be negotiated and the rest ignored.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BundlePolicy { get; set; }
        /// <summary>
        /// An Array of objects of type RTCCertificate which are used by the connection for authentication. If this property isn't specified, a set of certificates is generated automatically for each RTCPeerConnection instance. Although only one certificate is used by a given connection, providing certificates for multiple algorithms may improve the odds of successfully connecting in some circumstances. See Using certificates for further information.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RTCCertificate[]? Certificates { get; set; }
        /// <summary>
        /// An unsigned 16-bit integer value which specifies the size of the prefetched ICE candidate pool. The default value is 0 (meaning no candidate prefetching will occur). You may find in some cases that connections can be established more quickly by allowing the ICE agent to start fetching ICE candidates before you start trying to connect, so that they're already available for inspection when RTCPeerConnection.setLocalDescription() is called.<br/>
        /// Note: Changing the size of the ICE candidate pool may trigger the beginning of ICE gathering.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ushort? IceCandidatePoolSize { get; set; }
        /// <summary>
        /// A string representing the current ICE transport policy. Possible values are:<br/>
        /// "all" - All ICE candidates will be considered. This is the default value.<br/>
        /// "relay" - Only ICE candidates whose IP addresses are being relayed, such as those being passed through a TURN server, will be considered.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? IceTransportPolicy { get; set; }
        /// <summary>
        /// A string which specifies the target peer identity for the RTCPeerConnection. If this value is set (it defaults to null), the RTCPeerConnection will not connect to a remote peer unless it can successfully authenticate with the given name.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PeerIdentity { get; set; }
        /// <summary>
        /// A string which specifies the RTCP mux policy to use when gathering ICE candidates, in order to support non-multiplexed RTCP. Possible values are:<br/>
        /// "negotiate" - Instructs the ICE agent to gather both RTP and RTCP candidates. If the remote peer can multiplex RTCP, then RTCP candidates are multiplexed atop the corresponding RTP candidates. Otherwise, both the RTP and RTCP candidates are returned, separately.<br/>
        /// "require" - Tells the ICE agent to gather ICE candidates for only RTP, and to multiplex RTCP atop them. If the remote peer doesn't support RTCP multiplexing, then session negotiation fails. This is the default value.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RtcMuxPolicy { get; set; }
    }
}
