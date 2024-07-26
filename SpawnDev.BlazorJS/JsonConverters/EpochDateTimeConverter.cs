using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// EpochDateTime JsonConverter
    /// </summary>
    public class EpochDateTimeConverter : JsonConverter<EpochDateTime?>
    {
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override bool CanConvert(Type typeToConvert)
        {
            var baseType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : typeToConvert;
            return typeof(EpochDateTime).IsAssignableFrom(baseType);
        }
        /// <summary>
        /// Reads the type value from the Json reader
        /// </summary>
        public override EpochDateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var v = JsonSerializer.Deserialize<long?>(ref reader);
            if (v == null) return null;
            var ret = (EpochDateTime)Activator.CreateInstance(typeToConvert)!;
            ret.ValueEpoch = v.Value;
            return ret;
        }
        /// <summary>
        /// Writes the type value to the Json reader
        /// </summary>
        public override void Write(Utf8JsonWriter writer, EpochDateTime? value, JsonSerializerOptions options)
        {
            long? v = value == null ? null : value.ValueEpoch;
            JsonSerializer.Serialize(writer, v);
        }
    }
}
