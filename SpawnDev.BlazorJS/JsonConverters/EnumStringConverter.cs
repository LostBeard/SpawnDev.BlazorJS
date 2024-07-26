using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// Converter for EnumString that serializes to EnumString.Text and deserializes from a string value
    /// </summary>
    public class EnumStringConverter : JsonConverter<EnumString?>
    {
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override bool CanConvert(Type typeToConvert)
        {
            var baseType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : typeToConvert;
            return baseType == typeof(EnumString<>);
        }
        /// <summary>
        /// Reads the type value from the Json reader
        /// </summary>
        public override EnumString? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var v = JsonSerializer.Deserialize<string?>(ref reader);
            if (string.IsNullOrEmpty(v)) return null;
            var ret = (EnumString)Activator.CreateInstance(typeToConvert)!;
            ret.String = v;
            return ret;
        }
        /// <summary>
        /// Writes the type value to the Json reader
        /// </summary>
        public override void Write(Utf8JsonWriter writer, EnumString? value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value == null ? null : value.String);
        }
    }
}
