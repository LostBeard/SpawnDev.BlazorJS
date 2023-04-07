using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCError interface describes an error which has occurred while handling WebRTC operations. It's based upon the standard DOMException interface that describes general DOM errors.
    /// </summary>
    public class RTCError : DOMException
    {
        public RTCError(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string specifying the WebRTC-specific error code identifying the type of error that occurred.
        /// </summary>
        public string ErrorDetail => JSRef.Get<string>("errorDetail");
        /// <summary>
        /// An unsigned long integer value indicating the fatal DTLS error which was received from the network. Only valid if the errorDetail string is dtls-failure. If null, no DTLS error was received.
        /// </summary>
        public ulong ReceivedAlert => JSRef.Get<ulong>("receivedAlert");
        /// <summary>
        /// If errorDetail is sctp-failure, this property is a long integer specifying the SCTP cause code indicating the cause of the failed SCTP negotiation. null if the error isn't an SCTP error.
        /// </summary>
        public long SctpCauseCode => JSRef.Get<long>("sctpCauseCode");
        /// <summary>
        /// If errorDetail is sdp-syntax-error, this property is a long integer identifying the line number of the SDP on which the syntax error occurred. null if the error isn't an SDP syntax error.
        /// </summary>
        public long SdpLineNumber => JSRef.Get<long>("sdpLineNumber");
        /// <summary>
        /// If errorDetail is dtls-failure, this property is an unsigned long integer indicating the fatal DTLS error that was sent out by this device. If null, no DTLS error was transmitted.
        /// </summary>
        public ulong SentAlert => JSRef.Get<ulong>("sentAlert");
    }
}
