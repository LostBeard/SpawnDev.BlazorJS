using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Intl.DateTimeFormat object enables language-sensitive date and time formatting.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl/DateTimeFormat
    /// </summary>
    public class IntlDateTimeFormat : JSObject
    {
        #region Constructors
        /// <summary>
        /// Creates a new Intl.DateTimeFormat object with default locale
        /// </summary>
        public IntlDateTimeFormat() : base(JS.New("Intl.DateTimeFormat")) { }

        /// <summary>
        /// Creates a new Intl.DateTimeFormat object with the specified locale
        /// </summary>
        /// <param name="locales">A string with a BCP 47 language tag, or an array of such strings</param>
        public IntlDateTimeFormat(string locales) : base(JS.New("Intl.DateTimeFormat", locales)) { }

        /// <summary>
        /// Creates a new Intl.DateTimeFormat object with the specified locales
        /// </summary>
        /// <param name="locales">An array of strings with BCP 47 language tags</param>
        public IntlDateTimeFormat(string[] locales) : base(JS.New("Intl.DateTimeFormat", locales)) { }

        /// <summary>
        /// Creates a new Intl.DateTimeFormat object with the specified locale and options
        /// </summary>
        /// <param name="locales">A string with a BCP 47 language tag, or an array of such strings</param>
        /// <param name="options">An object with some or all options</param>
        public IntlDateTimeFormat(string locales, IntlDateTimeFormatOptions options) : base(JS.New("Intl.DateTimeFormat", locales, options)) { }

        /// <summary>
        /// Creates a new Intl.DateTimeFormat object with the specified locales and options
        /// </summary>
        /// <param name="locales">An array of strings with BCP 47 language tags</param>
        /// <param name="options">An object with some or all options</param>
        public IntlDateTimeFormat(string[] locales, IntlDateTimeFormatOptions options) : base(JS.New("Intl.DateTimeFormat", locales, options)) { }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IntlDateTimeFormat(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Methods
        /// <summary>
        /// Formats a date according to the locale and formatting options of this Intl.DateTimeFormat object.
        /// </summary>
        /// <param name="date">The date to format</param>
        /// <returns>A string representing the given date formatted according to the locale and formatting options</returns>
        public string Format(DateTime date) => JSRef!.Call<string>("format", date);

        /// <summary>
        /// Formats a date according to the locale and formatting options of this Intl.DateTimeFormat object.
        /// </summary>
        /// <param name="date">The date to format (as milliseconds since epoch)</param>
        /// <returns>A string representing the given date formatted according to the locale and formatting options</returns>
        public string Format(long date) => JSRef!.Call<string>("format", date);

        /// <summary>
        /// Returns an Array of objects representing the date string in parts that can be used for custom locale-aware formatting.
        /// </summary>
        /// <param name="date">The date to format</param>
        /// <returns>An Array of objects containing the formatted date in parts</returns>
        public IntlDateTimeFormatPart[] FormatToParts(DateTime date) => JSRef!.Call<IntlDateTimeFormatPart[]>("formatToParts", date);

        /// <summary>
        /// Returns an Array of objects representing the date string in parts that can be used for custom locale-aware formatting.
        /// </summary>
        /// <param name="date">The date to format (as milliseconds since epoch)</param>
        /// <returns>An Array of objects containing the formatted date in parts</returns>
        public IntlDateTimeFormatPart[] FormatToParts(long date) => JSRef!.Call<IntlDateTimeFormatPart[]>("formatToParts", date);

        /// <summary>
        /// Formats a date range in the most concise way based on the locale and options provided when instantiating Intl.DateTimeFormat object.
        /// </summary>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <returns>A string representing the given date range formatted according to the locale and formatting options</returns>
        public string FormatRange(DateTime startDate, DateTime endDate) => JSRef!.Call<string>("formatRange", startDate, endDate);

        /// <summary>
        /// Formats a date range in the most concise way based on the locale and options provided when instantiating Intl.DateTimeFormat object.
        /// </summary>
        /// <param name="startDate">The start date (as milliseconds since epoch)</param>
        /// <param name="endDate">The end date (as milliseconds since epoch)</param>
        /// <returns>A string representing the given date range formatted according to the locale and formatting options</returns>
        public string FormatRange(long startDate, long endDate) => JSRef!.Call<string>("formatRange", startDate, endDate);

        /// <summary>
        /// Returns an Array of objects representing the date range string in parts that can be used for custom locale-aware formatting.
        /// </summary>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <returns>An Array of objects containing the formatted date range in parts</returns>
        public IntlDateTimeFormatPart[] FormatRangeToParts(DateTime startDate, DateTime endDate) => JSRef!.Call<IntlDateTimeFormatPart[]>("formatRangeToParts", startDate, endDate);

        /// <summary>
        /// Returns an Array of objects representing the date range string in parts that can be used for custom locale-aware formatting.
        /// </summary>
        /// <param name="startDate">The start date (as milliseconds since epoch)</param>
        /// <param name="endDate">The end date (as milliseconds since epoch)</param>
        /// <returns>An Array of objects containing the formatted date range in parts</returns>
        public IntlDateTimeFormatPart[] FormatRangeToParts(long startDate, long endDate) => JSRef!.Call<IntlDateTimeFormatPart[]>("formatRangeToParts", startDate, endDate);

        /// <summary>
        /// Returns a new object with properties reflecting the locale and date and time formatting options computed during initialization of this Intl.DateTimeFormat object.
        /// </summary>
        /// <returns>A new object with properties reflecting the locale and formatting options</returns>
        public IntlResolvedDateTimeFormatOptions ResolvedOptions() => JSRef!.Call<IntlResolvedDateTimeFormatOptions>("resolvedOptions");

        /// <summary>
        /// Returns an array containing those of the provided locales that are supported in date and time formatting without having to fall back to the runtime's default locale.
        /// </summary>
        /// <param name="locales">A string with a BCP 47 language tag, or an array of such strings</param>
        /// <returns>An array of strings representing a subset of the given locale tags that are supported in date and time formatting</returns>
        public static string[] SupportedLocalesOf(Union<string, string[]> locales) => JS.Call<string[]>("Intl.DateTimeFormat.supportedLocalesOf", locales);

        /// <summary>
        /// Returns an array containing those of the provided locales that are supported in date and time formatting without having to fall back to the runtime's default locale.
        /// </summary>
        /// <param name="locales">A string with a BCP 47 language tag, or an array of such strings</param>
        /// <param name="options">An object with a localeMatcher property</param>
        /// <returns>An array of strings representing a subset of the given locale tags that are supported in date and time formatting</returns>
        public static string[] SupportedLocalesOf(Union<string, string[]> locales, IntlDateTimeFormatOptions options) => JS.Call<string[]>("Intl.DateTimeFormat.supportedLocalesOf", locales, options);
        #endregion
    }
}
