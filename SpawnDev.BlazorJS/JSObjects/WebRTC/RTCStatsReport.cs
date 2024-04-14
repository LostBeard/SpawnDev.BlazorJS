using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCStatsReport interface of the WebRTC API provides a statistics report for a RTCPeerConnection, RTCRtpSender, or RTCRtpReceiver.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCStatsReport<br />
    /// TODO - verify return values
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
        /// <summary>
        /// Returns a new Iterator object that contains a two-member array of [id, statistic-dictionary] for each element in the RTCStatsReport object, in insertion order.
        /// </summary>
        public (string, RTCStats)[] Entries => JSRef.Call<(string, RTCStats)[]>("entries");
        /// <summary>
        /// Returns the statistics dictionary associated with the passed id, or undefined if there is none.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RTCStats? Get(string id) => JSRef.Call<RTCStats?>("get", id);
        /// <summary>
        /// Returns the statistics dictionary associated with the passed id, or undefined if there is none.
        /// </summary>
        /// <typeparam name="TStats"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public TStats? Get<TStats>(string id) where TStats : RTCStats => JSRef.Call<TStats?>("get", id);
        /// <summary>
        /// Returns a boolean indicating whether the RTCStatsReport contains a statistics dictionary associated with the specified id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Has(string id) => JSRef.Call<bool>("has", id);
        /// <summary>
        /// Returns a new Iterator object that contains the keys (IDs) for each element in the RTCStatsReport object, in insertion order.
        /// </summary>
        public string[] Keys() => JSRef.Call<string[]>("keys");
        /// <summary>
        /// Returns a new Iterator object that contains the values (statistics object) for each element in the RTCStatsReport object, in insertion order.
        /// </summary>
        /// <returns></returns>
        public RTCStats[] Values() => JSRef.Call<RTCStats[]>("values");
    }
}
