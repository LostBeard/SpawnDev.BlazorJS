using SpawnDev.BlazorJS.JSObjects;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// This converter is designed to allow converting Union types to and from JSON<br />
    /// When being serialized/deserialized by the Blazor JSRuntime UnionConverterFactory overrides this converter and is used<br />
    /// This allows handling serialization based on the environment the result will be used in<br />
    /// Ex. JSObjects and IJSInProcessObjectReferences are only valid in the Javascript scope
    /// </summary>
    public class UnionJsonConverter : JsonConverter<object?>
    {
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(Union).IsAssignableFrom(typeToConvert);
        }
        /// <summary>
        /// Reads the type value from the Json reader
        /// </summary>
        public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var types = UnionConverter.GetUnionTypeGenericTypes(typeToConvert);
            var value = UnionConverter.ImportFromJson(ref reader, options, types!);
            if (value == null) return null;
            var ret = Activator.CreateInstance(typeToConvert, value);
            return ret;
        }
        /// <summary>
        /// Writes the type value to the Json reader
        /// </summary>
        public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
        {
            var u = (Union?)value;
            if (u != null && u.Value != null)
            {
                var vType = u.Value.GetType();
                var uType = u.ValueType;
                if (u.Value is TypedArray t)
                {
                    var bytes = t.ReadBytes();
                    JsonSerializer.Serialize(writer, bytes, options);
                    return;
                }
                else if (u.Value is ArrayBuffer r)
                {
                    var bytes = r.ReadBytes();
                    JsonSerializer.Serialize(writer, bytes, options);
                    return;
                }
                else if (typeof(JSObject).IsAssignableFrom(vType))
                {
                    throw new Exception("Unsupported type serialization in Union");
                }
            }
            JsonSerializer.Serialize(writer, u == null ? null : u.Value, options);
        }
    }
}
