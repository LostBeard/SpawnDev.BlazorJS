using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCTransportStats dictionary of the WebRTC API provides information about the transport (RTCDtlsTransport and its underlying RTCIceTransport) used by a particular candidate pair.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCTransportStats
    /// </summary>
    public class RTCTransportStats : RTCStats
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCTransportStats(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string containing the unique identifier for the object that was inspected to produce the RTCIceCandidatePairStats associated with this transport.
        /// </summary>
        public string? SelectedCandidatePairId => JSRef!.Get<string?>("selectedCandidatePairId");
    }
}
