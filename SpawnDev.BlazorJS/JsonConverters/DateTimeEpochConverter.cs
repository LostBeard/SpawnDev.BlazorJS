using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// This JSON converter allows converting between Javascript epoch long value and .Net DateTime
    /// </summary>
    public class DateTimeEpochConverter : JsonConverter<DateTime>
    {
        /// <summary>
        /// Returns true if this converter can convert the specified type
        /// </summary>
        public override bool CanConvert(Type typeToConvert) => typeof(DateTime) == typeToConvert;
        /// <summary>
        /// Reads the type value from the Json reader
        /// </summary>
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var v = JsonSerializer.Deserialize<long>(ref reader);
            var ret = v.EpochTimeToDateTime();
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var time = value.GetEpochTime();
            JsonSerializer.Serialize(writer, time);
        }
    }
}
