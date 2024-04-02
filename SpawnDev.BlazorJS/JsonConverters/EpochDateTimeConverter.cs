using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    public class EpochDateTimeConverter : JsonConverter<EpochDateTime?>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            var baseType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : typeToConvert;
            return typeof(EpochDateTime).IsAssignableFrom(baseType);
        }
        public override EpochDateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var v = JsonSerializer.Deserialize<long?>(ref reader);
            if (v == null) return null;
            var ret = (EpochDateTime)Activator.CreateInstance(typeToConvert)!;
            ret.ValueEpoch = v.Value;
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, EpochDateTime? value, JsonSerializerOptions options)
        {
            long? v = value == null ? null : value.ValueEpoch;
            JsonSerializer.Serialize(writer, v);
        }
    }
}
