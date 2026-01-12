using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// EpochDateTime serializes to a long representing the milliseconds since 1970-01-01<br />
    /// and deserializes to EpochDateTime if a number or null if null or undefined
    /// </summary>
    [JsonConverter(typeof(EpochDateTimeConverter))]
    public class EpochDateTime
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public EpochDateTime() { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="value"></param>
        public EpochDateTime(DateTime value) { Value = value; }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="valueEpoch"></param>
        public EpochDateTime(long valueEpoch) { ValueEpoch = valueEpoch; }
        /// <summary>
        /// Returns the current date and time as an EpochDateTime
        /// </summary>
        public static EpochDateTime Now => (EpochDateTime)DateTime.Now;
        /// <summary>
        /// The DateTime value of EpochDateTime in local time (DateTimeKind.Local)
        /// </summary>
        public DateTime Value { get; set; }
        /// <summary>
        /// A long representing the milliseconds since 1970-01-01 utc
        /// </summary>
        public long ValueEpoch
        {
            get => Value.GetEpochTime();
            set => Value = value.EpochTimeToDateTime();
        }
        // DateTime?
        /// <summary>
        /// Implicit conversion to EpochDateTime?
        /// </summary>
        /// <param name="dateTime"></param>
        public static implicit operator EpochDateTime?(DateTime? dateTime) => dateTime == null ? null : new EpochDateTime(dateTime.Value);
        /// <summary>
        /// Implicit conversion to DateTime?
        /// </summary>
        /// <param name="epochDateTime"></param>
        public static implicit operator DateTime?(EpochDateTime? epochDateTime) => epochDateTime == null ? null : epochDateTime.Value;
        // DateTime
        /// <summary>
        /// Implicit conversion to EpochDateTime
        /// </summary>
        /// <param name="dateTime"></param>
        public static implicit operator EpochDateTime(DateTime dateTime) => new EpochDateTime(dateTime);
        /// <summary>
        /// Implicit conversion to DateTime
        /// </summary>
        /// <param name="epochDateTime"></param>
        public static implicit operator DateTime(EpochDateTime epochDateTime) => epochDateTime.Value;
        // long?
        /// <summary>
        /// Implicit conversion to EpochDateTime?
        /// </summary>
        /// <param name="epochDateTimeMS"></param>
        public static implicit operator EpochDateTime?(long? epochDateTimeMS) => epochDateTimeMS == null ? null : new EpochDateTime(epochDateTimeMS.Value);
        /// <summary>
        /// Implicit conversion to long?
        /// </summary>
        /// <param name="epochDateTime"></param>
        public static implicit operator long?(EpochDateTime? epochDateTime) => epochDateTime == null ? null : epochDateTime.ValueEpoch;
        // long
        /// <summary>
        /// Implicit conversion to EpochDateTime
        /// </summary>
        /// <param name="epochDateTimeMS"></param>
        public static implicit operator EpochDateTime(long epochDateTimeMS) => new EpochDateTime(epochDateTimeMS);
        /// <summary>
        /// Implicit conversion to long
        /// </summary>
        /// <param name="epochDateTime"></param>
        public static implicit operator long(EpochDateTime epochDateTime) => epochDateTime.ValueEpoch;
    }
}
