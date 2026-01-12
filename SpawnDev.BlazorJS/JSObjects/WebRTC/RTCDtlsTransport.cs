using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCDtlsTransport interface provides access to information about the Datagram Transport Layer Security (DTLS) transport over which a RTCPeerConnection's RTP and RTCP packets are sent and received by its RTCRtpSender and RTCRtpReceiver objects.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCDtlsTransport
    /// </summary>
    public class RTCDtlsTransport : EventTarget
    {
        /// <inheritdoc/>
        public RTCDtlsTransport(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a reference to the underlying RTCIceTransport object.
        /// </summary>
        public RTCIceTransport IceTransport => JSRef!.Get<RTCIceTransport>("iceTransport");
        /// <summary>
        /// Returns a string which describes the underlying Datagram Transport Layer Security (DTLS) transport state. It can be one of the following values: new, connecting, connected, closed, or failed.
        /// </summary>
        public string State => JSRef!.Get<string>("state");
        /// <summary>
        /// Sent when a transport-level error occurs on the RTCPeerConnection.
        /// </summary>
        public ActionEvent<RTCErrorEvent> OnError { get => new ActionEvent<RTCErrorEvent>("error", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Sent when the state of the DTLS transport changes.
        /// </summary>
        public ActionEvent<Event> OnStateChange { get => new ActionEvent<Event>("statechange", AddEventListener, RemoveEventListener); set { } }
    }
    /// <summary>
    /// The RTCIceTransport interface provides access to information about the ICE transport layer over which the data is being sent and received. This is particularly useful if you need to access state information about the connection.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCIceTransport
    /// </summary>
    public class RTCIceTransport : EventTarget
    {
        /// <inheritdoc/>
        public RTCIceTransport(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The ICE component being used by the transport. The value is one of the strings from the RTCIceTransport enumerated type: "RTP" or "RTSP".
        /// </summary>
        public string Component => JSRef!.Get<string>("component");
        /// <summary>
        /// A string indicating which current gathering state of the ICE agent: "new", "gathering", or "complete".
        /// </summary>
        public string GatheringState => JSRef!.Get<string>("gatheringState");
        /// <summary>
        /// Returns a string whose value is either "controlling" or "controlled"; this indicates whether the ICE agent is the one that makes the final decision as to the candidate pair to use or not.
        /// </summary>
        public string Role => JSRef!.Get<string>("role");
        /// <summary>
        /// A string indicating what the current state of the ICE agent is. The value of state can be used to determine whether the ICE agent has made an initial connection using a viable candidate pair ("connected"), made its final selection of candidate pairs ("completed"), or in an error state ("failed"), among other states.
        /// </summary>
        public string State => JSRef!.Get<string>("state");
        /// <summary>
        /// Returns an array of RTCIceCandidate objects, each describing one of the ICE candidates that have been gathered so far for the local device. These are the same candidates which have already been sent to the remote peer by sending an icecandidate event to the RTCPeerConnection for transmission.
        /// </summary>
        /// <returns></returns>
        public Array<RTCIceCandidate> GetLocalCandidates() => JSRef!.Call<Array<RTCIceCandidate>>("getLocalCandidates");
    }
}
