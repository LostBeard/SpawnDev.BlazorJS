using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// This JSON converter allows converting between Javascript epoch long value and .Net DateTime
    /// </summary>
    public class DateTimeEpochConverter : JsonConverter<DateTime>
    {
        public override bool CanConvert(Type typeToConvert) => typeof(DateTime) == typeToConvert;
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var v = JsonSerializer.Deserialize<long>(ref reader);
            var ret = v.EpochTimeToDateTime();
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var time = value.GetEpochTime();
            JsonSerializer.Serialize(writer, time);
        }
    }
    /// <summary>
    /// This JSON converter allows converting between Javascript epoch long? value and .Net DateTime?
    /// </summary>
    public class NullableDateTimeEpochConverter : JsonConverter<DateTime?>
    {
        public override bool CanConvert(Type typeToConvert) => typeof(DateTime?) == typeToConvert;
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var v = JsonSerializer.Deserialize<long?>(ref reader);
            var ret = v?.EpochTimeToDateTime();
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {

            var time = value?.GetEpochTime();
            JsonSerializer.Serialize(writer, time);
        }
    }
}
