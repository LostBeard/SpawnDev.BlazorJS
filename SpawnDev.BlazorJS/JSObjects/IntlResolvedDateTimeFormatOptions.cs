using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Resolved options returned by Intl.DateTimeFormat.resolvedOptions()<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl/DateTimeFormat/resolvedOptions
    /// </summary>
    public class IntlResolvedDateTimeFormatOptions : JSObject
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IntlResolvedDateTimeFormatOptions(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// The BCP 47 language tag for the locale actually used.
        /// </summary>
        public string Locale => JSRef!.Get<string>("locale");

        /// <summary>
        /// The value provided for this property in the options argument, or using the Unicode extension key "ca".
        /// </summary>
        public string? Calendar => JSRef!.Get<string?>("calendar");

        /// <summary>
        /// The value provided for this property in the options argument, or using the Unicode extension key "nu".
        /// </summary>
        public string? NumberingSystem => JSRef!.Get<string?>("numberingSystem");

        /// <summary>
        /// The value provided for this property in the options argument, or filled in as a default.
        /// </summary>
        public string? TimeZone => JSRef!.Get<string?>("timeZone");

        /// <summary>
        /// The value provided for this property in the options argument, or filled in as a default.
        /// </summary>
        public bool? Hour12 => JSRef!.Get<bool?>("hour12");

        /// <summary>
        /// The value provided for this property in the options argument, or filled in as a default.
        /// </summary>
        public string? HourCycle => JSRef!.Get<string?>("hourCycle");

        /// <summary>
        /// The value provided for this property in the options argument, or filled in as a default.
        /// </summary>
        public string? Weekday => JSRef!.Get<string?>("weekday");

        /// <summary>
        /// The value provided for this property in the options argument, or filled in as a default.
        /// </summary>
        public string? Era => JSRef!.Get<string?>("era");

        /// <summary>
        /// The value provided for this property in the options argument, or filled in as a default.
        /// </summary>
        public string? Year => JSRef!.Get<string?>("year");

        /// <summary>
        /// The value provided for this property in the options argument, or filled in as a default.
        /// </summary>
        public string? Month => JSRef!.Get<string?>("month");

        /// <summary>
        /// The value provided for this property in the options argument, or filled in as a default.
        /// </summary>
        public string? Day => JSRef!.Get<string?>("day");

        /// <summary>
        /// The value provided for this property in the options argument, or filled in as a default.
        /// </summary>
        public string? Hour => JSRef!.Get<string?>("hour");

        /// <summary>
        /// The value provided for this property in the options argument, or filled in as a default.
        /// </summary>
        public string? Minute => JSRef!.Get<string?>("minute");

        /// <summary>
        /// The value provided for this property in the options argument, or filled in as a default.
        /// </summary>
        public string? Second => JSRef!.Get<string?>("second");

        /// <summary>
        /// The value provided for this property in the options argument, or filled in as a default.
        /// </summary>
        public int? FractionalSecondDigits => JSRef!.Get<int?>("fractionalSecondDigits");

        /// <summary>
        /// The value provided for this property in the options argument, or filled in as a default.
        /// </summary>
        public string? TimeZoneName => JSRef!.Get<string?>("timeZoneName");

        /// <summary>
        /// The value provided for this property in the options argument, or filled in as a default.
        /// </summary>
        public string? DateStyle => JSRef!.Get<string?>("dateStyle");

        /// <summary>
        /// The value provided for this property in the options argument, or filled in as a default.
        /// </summary>
        public string? TimeStyle => JSRef!.Get<string?>("timeStyle");

        /// <summary>
        /// The value provided for this property in the options argument, or filled in as a default.
        /// </summary>
        public string? DayPeriod => JSRef!.Get<string?>("dayPeriod");
        #endregion
    }
}
