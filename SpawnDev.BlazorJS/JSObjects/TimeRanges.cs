using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// When loading a media resource for use by an &lt;audio> or &lt;video> element, the TimeRanges interface is used for representing the time ranges of the media resource that have been buffered, the time ranges that have been played, and the time ranges that are seekable.<br/>
    /// A TimeRanges object includes one or more ranges of time, each specified by a starting time offset and an ending time offset. You reference each time range by using the start() and end() methods, passing the index number of the time range you want to retrieve.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TimeRanges
    /// </summary>
    public class TimeRanges : JSObject
    {
        /// <inheritdoc/>
        public TimeRanges(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns an unsigned long representing the number of time ranges represented by the time range object.
        /// </summary>
        public int Length => JSRef!.Get<int>("length");
        /// <summary>
        /// Returns the time for the start of the range with the specified index.
        /// </summary>
        /// <param name="i">The range number to return the starting time for.</param>
        /// <returns>A number.</returns>
        public double Start(int i) => JSRef!.Call<double>("start", i);
        /// <summary>
        /// Returns the time for the end of the specified range.
        /// </summary>
        /// <param name="i">The range number to return the ending time for.</param>
        /// <returns>A number.</returns>
        public double End(int i) => JSRef!.Call<double>("end", i);
    }
}