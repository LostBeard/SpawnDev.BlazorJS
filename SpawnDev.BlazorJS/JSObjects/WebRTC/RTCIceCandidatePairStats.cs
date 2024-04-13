using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCIceCandidatePairStats dictionary of the WebRTC API is used to report statistics that provide insight into the quality and performance of an RTCPeerConnection while connected and configured as described by the specified pair of ICE candidates.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCIceCandidatePairStats
    /// </summary>
    public class RTCIceCandidatePairStats : RTCStats
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCIceCandidatePairStats(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Provides a value representing the available inbound capacity of the network by reporting the total number of bits per second available for all of the candidate pair's incoming RTP streams. This does not take into account the size of the IP overhead, nor any other transport layers such as TCP or UDP.
        /// </summary>
        public long? AvailableIncomingBitrate => JSRef.Get<long?>("availableIncomingBitrate");
        /// <summary>
        /// Provides an informative value representing the available outbound capacity of the network by reporting the total number of bits per second available for all of the candidate pair's outgoing RTP streams. This does not take into account the size of the IP overhead, nor any other transport layers such as TCP or UDP.
        /// </summary>
        public long? AvailableOutgoingBitrate => JSRef.Get<long?>("availableOutgoingBitrate");
        /// <summary>
        /// The total number of payload bytes received (that is, the total number of bytes received minus any headers, padding, or other administrative overhead) on this candidate pair so far.
        /// </summary>
        public long? BytesReceived => JSRef.Get<long?>("bytesReceived");
        /// <summary>
        /// The total number of payload bytes sent (that is, the total number of bytes sent minus any headers, padding, or other administrative overhead) so far on this candidate pair.
        /// </summary>
        public long? BytesSent => JSRef.Get<long?>("bytesSent");
        /// <summary>
        /// A floating-point value indicating the total time, in seconds, that elapsed between the most recently-sent STUN request and the response being received. This may be based upon requests that were involved in confirming permission to open the connection.
        /// </summary>
        public float? CurrentRoundTripTime => JSRef.Get<float?>("currentRoundTripTime");
        /// <summary>
        /// A DOMHighResTimeStamp value indicating the time at which the last packet was received by the local peer from the remote peer for this candidate pair. Timestamps are not recorded for STUN packets.
        /// </summary>
        public double? LastPacketReceivedTimestamp => JSRef.Get<double?>("lastPacketReceivedTimestamp");
        /// <summary>
        /// A DOMHighResTimeStamp value indicating the time at which the last packet was sent from the local peer to the remote peer for this candidate pair. Timestamps are not recorded for STUN packets.
        /// </summary>
        public double? LastPacketSentTimestamp => JSRef.Get<double?>("lastPacketSentTimestamp");
        /// <summary>
        /// The unique ID string corresponding to the RTCIceCandidate from the data included in the RTCIceCandidateStats object providing statistics for the candidate pair's local candidate.
        /// </summary>
        public string? LocalCandidateId => JSRef.Get<string?>("localCandidateId");
        /// <summary>
        /// A Boolean value which, if true, indicates that the candidate pair described by this object is one which has been proposed for use, and will be (or was) used if its priority is the highest among the nominated candidate pairs. See RFC 5245, section 7.1.3.2.4 for details.
        /// </summary>
        public bool? Nominated => JSRef.Get<bool?>("nominated");
        /// <summary>
        /// The unique ID string corresponding to the remote candidate from which data was taken to construct the RTCIceCandidateStats object describing the remote end of the connection.
        /// </summary>
        public string? RemoteCandidateId => JSRef.Get<string?>("remoteCandidateId");
        /// <summary>
        /// The total number of connectivity check requests that have been received, including retransmissions. This value includes both connectivity checks and STUN consent checks.
        /// </summary>
        public int? RequestsReceived => JSRef.Get<int?>("requestsReceived");
        /// <summary>
        /// The total number of connectivity check requests that have been sent, not including retransmissions.
        /// </summary>
        public int? RequestsSent => JSRef.Get<int?>("requestsSent");
        /// <summary>
        /// The total number of connectivity check responses that have been sent. This includes both connectivity check requests and STUN consent requests.
        /// </summary>
        public int? ResponsesSent => JSRef.Get<int?>("responsesSent");
        /// <summary>
        /// The total number of connectivity check responses that have been received.
        /// </summary>
        public int? ResponsesReceived => JSRef.Get<int?>("responsesReceived");
        /// <summary>
        /// A string which indicates the state of the connection between the two candidates.
        /// </summary>
        public string? State => JSRef.Get<string?>("state");
        /// <summary>
        /// A floating-point value indicating the total time, in seconds, that has elapsed between sending STUN requests and receiving responses to them, for all such requests made to date on this candidate pair. This includes both connectivity check and consent check requests. You can compute the average round trip time (RTT) by dividing this value by responsesReceived.
        /// </summary>
        public float? TotalRoundTripTime => JSRef.Get<float?>("totalRoundTripTime");
        /// <summary>
        /// A string that uniquely identifies the RTCIceTransport that was inspected to obtain the transport-related statistics (as found in RTCTransportStats) used in generating this object.
        /// </summary>
        public string? TransportId => JSRef.Get<string?>("transportId");
    }
}
