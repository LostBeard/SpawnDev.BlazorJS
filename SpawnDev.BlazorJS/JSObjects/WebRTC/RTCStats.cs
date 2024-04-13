using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// Base class for RTC stats objects
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCStatsReport#the_statistic_types
    /// </summary>
    public class RTCStats : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCStats(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string that uniquely identifies the object was monitored to produce the set of statistics. This value persists across reports for (at least) the lifetime of the connection. Note however that for some statistics the ID may vary between browsers and for subsequent connections, even to the same peer.
        /// </summary>
        public string Id => JSRef.Get<string>("id");
        /// <summary>
        /// A string with a value that indicates the type of statistics that the object contains, such as candidate-pair, inbound-rtp, certificate, and so on. The types of statistics and their corresponding objects are listed below.
        /// </summary>
        public string Type => JSRef.Get<string>("type");
        /// <summary>
        /// A DOMHighResTimeStamp object indicating the time at which the sample was taken for this statistics object.
        /// </summary>
        public double Timestamp => JSRef.Get<double>("timestamp");
    }
}
