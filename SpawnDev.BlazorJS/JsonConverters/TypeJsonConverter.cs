using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// Type JsonConverter factory
    /// </summary>
    public class TypeJsonConverter : JsonConverter<Type>
    {
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override bool CanConvert(Type type)
        {
            return typeof(Type).IsAssignableFrom(type);
        }
        /// <summary>
        /// Reads the type value from the Json reader
        /// </summary>
        public override Type? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var typeFullName = JsonSerializer.Deserialize<string?>(ref reader, options);
            return string.IsNullOrEmpty(typeFullName) ? null : TypeExtensions.GetType(typeFullName);
        }
        /// <summary>
        /// Writes the type value to the Json reader
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Type? value, JsonSerializerOptions options)
        {
            var writeValue = value == null ? null : value.FullName;
            JsonSerializer.Serialize(writer, writeValue, options);
        }
    }
}
