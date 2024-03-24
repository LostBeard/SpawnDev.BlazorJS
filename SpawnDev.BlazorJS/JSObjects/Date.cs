using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// JavaScript Date objects represent a single moment in time in a platform-independent format. Date objects encapsulate an integral number that represents milliseconds since the midnight at the beginning of January 1, 1970, UTC (the epoch).<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Date
    /// </summary>
    internal class Date : JSObject
    {
        /// <summary>
        /// Creates a new Date object.
        /// </summary>
        public Date() : base(JS.New(nameof(Date))) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Date(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the numeric value of the specified date as the number of milliseconds since January 1, 1970, 00:00:00 UTC. (Negative values are returned for prior times.)
        /// </summary>
        /// <returns></returns>
        public long GetTime() => JSRef.Call<long>("getTime");
        /// <summary>
        /// Returns the time-zone offset in minutes for the current locale.
        /// </summary>
        /// <returns></returns>
        public int GetTimezoneOffset() => JSRef.Call<int>("getTimezoneOffset");
        /// <summary>
        /// Converts a date to a string following the ISO 8601 Extended Format.
        /// </summary>
        /// <returns></returns>
        public string ToISOString() => JSRef.Call<string>("toISOString");
        /// <summary>
        /// Returns the DateTimeOffset
        /// </summary>
        /// <returns></returns>
        public DateTimeOffset GetDateTimeOffset() => DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromMinutes(-GetTimezoneOffset()));
    }
}
