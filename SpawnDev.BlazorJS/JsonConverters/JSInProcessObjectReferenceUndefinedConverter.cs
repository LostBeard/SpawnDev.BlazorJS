using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// Undefined JsonConverter
    /// </summary>
    public class JSInProcessObjectReferenceUndefinedConverter : JsonConverter<JSInProcessObjectReferenceUndefined>
    {
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override bool CanConvert(Type type)
        {
            return type == typeof(JSInProcessObjectReferenceUndefined);
        }
        /// <summary>
        /// Reads the type value from the Json reader
        /// </summary>
        public override JSInProcessObjectReferenceUndefined Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // this has no use really. the converter is for writing undefined to Javascript
            return new JSInProcessObjectReferenceUndefined();
        }
        /// <summary>
        /// Writes the type value to the Json reader
        /// </summary>
        public override void Write(Utf8JsonWriter writer, JSInProcessObjectReferenceUndefined value, JsonSerializerOptions options)
        {
            // below write the instance as json so the reviver can pick it up
            JsonSerializer.Serialize(writer, value);
        }
    }
}
