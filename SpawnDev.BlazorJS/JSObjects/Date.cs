using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// JavaScript Date objects represent a single moment in time in a platform-independent format. Date objects encapsulate an integral number that represents milliseconds since the midnight at the beginning of January 1, 1970, UTC (the epoch).<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Date
    /// </summary>
    public class Date : JSObject
    {
        /// <summary>
        /// Create a new instance of Date from a .Net DateTime
        /// </summary>
        /// <param name="dateTime"></param>
        public static implicit operator Date(DateTime dateTime)=>new Date(dateTime);
        /// <summary>
        /// Returns the Date.ateTime property
        /// </summary>
        /// <param name="dateTime"></param>
        public static implicit operator DateTime(Date dateTime) => dateTime.DateTime;
        /// <summary>
        /// Creates a new Date object.
        /// </summary>
        public Date() : base(JS.New(nameof(Date))) { }
        /// <summary>
        /// Returns a .Net DateTime
        /// </summary>
        public DateTime DateTime => GetTime().EpochTimeToDateTime();
        /// <summary>
        /// Create a new instance of Date from .Net DateTime
        /// </summary>
        /// <param name="dateTime"></param>
        public Date(DateTime dateTime) : base(JS.New(nameof(Date), dateTime.GetEpochTime())) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Date(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the numeric value of the specified date as the number of milliseconds since January 1, 1970, 00:00:00 UTC. (Negative values are returned for prior times.)
        /// </summary>
        /// <returns></returns>
        public long GetTime() => JSRef!.Call<long>("getTime");
        /// <summary>
        /// Returns the time-zone offset in minutes for the current locale.
        /// </summary>
        /// <returns></returns>
        public int GetTimezoneOffset() => JSRef!.Call<int>("getTimezoneOffset");
        /// <summary>
        /// Converts a date to a string following the ISO 8601 Extended Format.
        /// </summary>
        /// <returns></returns>
        public string ToISOString() => JSRef!.Call<string>("toISOString");
        /// <summary>
        /// Returns the DateTimeOffset
        /// </summary>
        /// <returns></returns>
        public DateTimeOffset GetDateTimeOffset() => DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromMinutes(-GetTimezoneOffset()));
    }
}
