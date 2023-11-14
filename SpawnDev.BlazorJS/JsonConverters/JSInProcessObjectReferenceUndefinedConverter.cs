using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    public class JSInProcessObjectReferenceUndefinedConverter : JsonConverter<JSInProcessObjectReferenceUndefined>
    {
        public override bool CanConvert(Type type)
        {
            return type == typeof(JSInProcessObjectReferenceUndefined);
        }
        public override JSInProcessObjectReferenceUndefined Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // this has no use really. the converter is for writing undefined to Javascript
            return new JSInProcessObjectReferenceUndefined();
        }
        public override void Write(Utf8JsonWriter writer, JSInProcessObjectReferenceUndefined value, JsonSerializerOptions options)
        {
            // below write the instance as json so the reviver can pick it up
            JsonSerializer.Serialize(writer, value);
        }
    }
}
