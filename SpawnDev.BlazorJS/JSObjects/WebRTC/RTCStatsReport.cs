using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCStatsReport interface of the WebRTC API provides a statistics report for a RTCPeerConnection, RTCRtpSender, or RTCRtpReceiver.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCStatsReport
    /// </summary>
    public class RTCStatsReport : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCStatsReport(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the number of items in the RTCStatsReport object.
        /// </summary>
        public int Size => JSRef.Get<int>("size");

        public Dictionary<string, object> Entries => JSRef.Call<Dictionary<string, object>>("entries");
    }
}
