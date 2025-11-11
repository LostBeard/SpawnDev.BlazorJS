using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for Intl.DateTimeFormat constructor<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Intl/DateTimeFormat/DateTimeFormat#options
    /// </summary>
    public class IntlDateTimeFormatOptions
    {
        /// <summary>
        /// The locale matching algorithm to use. Possible values are "lookup" and "best fit"; the default is "best fit".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? LocaleMatcher { get; set; }

        /// <summary>
        /// The time zone to use. The only value implementations must recognize is "UTC"; the default is the runtime's default time zone.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// Whether to use 12-hour time (as opposed to 24-hour time). Possible values are true and false; the default is locale dependent.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Hour12 { get; set; }

        /// <summary>
        /// The format matching algorithm to use. Possible values are "basic" and "best fit"; the default is "best fit".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FormatMatcher { get; set; }

        /// <summary>
        /// The representation of the weekday. Possible values are "narrow", "short", "long".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Weekday { get; set; }

        /// <summary>
        /// The representation of the era. Possible values are "narrow", "short", "long".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Era { get; set; }

        /// <summary>
        /// The representation of the year. Possible values are "numeric", "2-digit".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Year { get; set; }

        /// <summary>
        /// The representation of the month. Possible values are "numeric", "2-digit", "narrow", "short", "long".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Month { get; set; }

        /// <summary>
        /// The representation of the day. Possible values are "numeric", "2-digit".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Day { get; set; }

        /// <summary>
        /// The representation of the hour. Possible values are "numeric", "2-digit".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Hour { get; set; }

        /// <summary>
        /// The representation of the minute. Possible values are "numeric", "2-digit".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Minute { get; set; }

        /// <summary>
        /// The representation of the second. Possible values are "numeric", "2-digit".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Second { get; set; }

        /// <summary>
        /// The number of digits used to represent fractions of a second (any additional digits are truncated). Possible values are 1, 2, 3.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FractionalSecondDigits { get; set; }

        /// <summary>
        /// The localized representation of the time zone name. Possible values are "short", "long", "shortOffset", "longOffset", "shortGeneric", "longGeneric".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TimeZoneName { get; set; }

        /// <summary>
        /// The calendar to use. Possible values include: "buddhist", "chinese", "coptic", "ethiopia", "ethiopic", "gregory", "hebrew", "indian", "islamic", "iso8601", "japanese", "persian", "roc".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Calendar { get; set; }

        /// <summary>
        /// The date formatting style to use. Possible values are "full", "long", "medium", "short".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DateStyle { get; set; }

        /// <summary>
        /// The time formatting style to use. Possible values are "full", "long", "medium", "short".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TimeStyle { get; set; }

        /// <summary>
        /// The numbering system to use. Possible values include: "arab", "arabext", "bali", "beng", "deva", "fullwide", "gujr", "guru", "hanidec", "khmr", "knda", "laoo", "latn", "limb", "mlym", "mong", "mymr", "orya", "tamldec", "telu", "thai", "tibt".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? NumberingSystem { get; set; }

        /// <summary>
        /// The hour cycle to use. Possible values are "h11", "h12", "h23", "h24".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? HourCycle { get; set; }

        /// <summary>
        /// The way day periods should be expressed. Possible values are "narrow", "short", "long".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DayPeriod { get; set; }
    }
}
