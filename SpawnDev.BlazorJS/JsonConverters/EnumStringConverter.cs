using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    public class EnumStringConverter : JsonConverter<EnumString?>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            var baseType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : typeToConvert;
            return baseType == typeof(EnumString<>);
        }
        public override EnumString? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var v = JsonSerializer.Deserialize<string?>(ref reader);
            if (string.IsNullOrEmpty(v)) return null;
            var ret = (EnumString)Activator.CreateInstance(typeToConvert)!;
            try
            {
                ret.ValueText = v;
            }
            catch
            {
                // likely unknown value
                return null;
            }
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, EnumString? value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value == null ? "" : value.ValueText);
        }
    }
}
