using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents a part of a formatted date/time string returned by Intl.DateTimeFormat.formatToParts()<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl/DateTimeFormat/formatToParts
    /// </summary>
    public class IntlDateTimeFormatPart : JSObject
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IntlDateTimeFormatPart(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// The type of the token. Possible values are: "day", "dayPeriod", "era", "fractionalSecond", "hour", "literal", "minute", "month", "relatedYear", "second", "timeZoneName", "weekday", "year", "yearName"
        /// </summary>
        public string Type => JSRef!.Get<string>("type");

        /// <summary>
        /// The string value of the token
        /// </summary>
        public string Value => JSRef!.Get<string>("value");

        /// <summary>
        /// The source of the token. Possible values are: "shared", "startRange", "endRange". Only present in formatRangeToParts() results.
        /// </summary>
        public string? Source => JSRef!.Get<string?>("source");
        #endregion
    }
}
