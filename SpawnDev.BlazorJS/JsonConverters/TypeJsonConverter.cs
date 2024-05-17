using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    public class TypeJsonConverter : JsonConverter<Type>
    {
        public override bool CanConvert(Type type)
        {
            return typeof(Type).IsAssignableFrom(type);
        }
        public override Type? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var typeFullName = JsonSerializer.Deserialize<string?>(ref reader, options);
            return string.IsNullOrEmpty(typeFullName) ? null : TypeExtensions.GetType(typeFullName);
        }
        public override void Write(Utf8JsonWriter writer, Type? value, JsonSerializerOptions options)
        {
            var writeValue = value == null ? null : value.FullName;
            JsonSerializer.Serialize(writer, writeValue, options);
        }
    }
}
