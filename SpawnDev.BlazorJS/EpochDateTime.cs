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
        public EpochDateTime() { }
        public EpochDateTime(DateTime value) { Value = value; }
        public EpochDateTime(long valueEpoch) { ValueEpoch = valueEpoch; }
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
        public static implicit operator EpochDateTime?(DateTime? dateTime) => dateTime == null ? null : new EpochDateTime(dateTime.Value);
        public static implicit operator DateTime?(EpochDateTime? epochDateTime) => epochDateTime == null ? null : epochDateTime.Value;
        // DateTime
        public static implicit operator EpochDateTime(DateTime dateTime) => new EpochDateTime(dateTime);
        public static implicit operator DateTime(EpochDateTime epochDateTime) => epochDateTime.Value;
        // long?
        public static implicit operator EpochDateTime?(long? epochDateTimeMS) => epochDateTimeMS == null ? null : new EpochDateTime(epochDateTimeMS.Value);
        public static implicit operator long?(EpochDateTime? epochDateTime) => epochDateTime == null ? null : epochDateTime.ValueEpoch;
        // long
        public static implicit operator EpochDateTime(long epochDateTimeMS) => new EpochDateTime(epochDateTimeMS);
        public static implicit operator long(EpochDateTime epochDateTime) => epochDateTime.ValueEpoch;
    }
}
