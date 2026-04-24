using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCSctpTransport interface provides information which describes a Stream Control
    /// Transmission Protocol (SCTP) transport. This also provides a way to access the underlying
    /// Datagram Transport Layer Security (DTLS) transport over which SCTP packets for all of an
    /// RTCPeerConnection's data channels are sent and received.&lt;br/&gt;
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCSctpTransport
    /// </summary>
    public class RTCSctpTransport : EventTarget
    {
        /// <inheritdoc/>
        public RTCSctpTransport(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// An RTCDtlsTransport object representing the DTLS transport over which the SCTP
        /// packets for all of this SCTP transport's data channels are sent and received.
        /// </summary>
        public RTCDtlsTransport? Transport => JSRef!.Get<RTCDtlsTransport?>("transport");

        /// <summary>
        /// The current state of the SCTP transport: "connecting", "connected", or "closed".
        /// </summary>
        public string State => JSRef!.Get<string>("state");

        /// <summary>
        /// An integer indicating the maximum size, in bytes, of a message which can be sent
        /// using the RTCDataChannel.send() method. Chromium-based browsers typically report
        /// 262144 (256 KiB - 1), Firefox reports larger values. May be Infinity.
        /// </summary>
        public double MaxMessageSize => JSRef!.Get<double>("maxMessageSize");

        /// <summary>
        /// An integer indicating the maximum number of RTCDataChannels that can be open on
        /// this SCTP transport simultaneously, or null if the implementation doesn't know
        /// the number of SCTP streams the remote peer supports (e.g. before connection).
        /// </summary>
        public int? MaxChannels => JSRef!.Get<int?>("maxChannels");

        /// <summary>
        /// The statechange event is sent when the value of the state property changes on
        /// an RTCSctpTransport.
        /// </summary>
        public ActionEvent<Event> OnStateChange
        {
            get => new ActionEvent<Event>("statechange", AddEventListener, RemoveEventListener);
            set { }
        }
    }
}
