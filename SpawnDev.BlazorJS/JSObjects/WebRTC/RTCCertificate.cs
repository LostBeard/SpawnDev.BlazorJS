using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCCertificate interface provides an object representing a certificate used by an RTCPeerConnection for authentication.
    /// </summary>
    public class RTCCertificate : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCCertificate(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
    /// <summary>
    /// The RTCIdentityAssertion interface represents an identity assertion which can be used to authenticate an RTCPeerConnection's remote peer.
    /// </summary>
    public class RTCIdentityAssertion : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCIdentityAssertion(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
    /// <summary>
    /// The RTCSctpTransport interface provides information which describes a Stream Control Transmission Protocol (SCTP) transport.
    /// </summary>
    public class RTCSctpTransport : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCSctpTransport(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
