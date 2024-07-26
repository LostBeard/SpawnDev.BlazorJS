using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// Union JsonConverter factory
    /// </summary>
    public class UnionConverterFactory : JsonConverterFactory
    {
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override bool CanConvert(Type type)
        {
            return typeof(Union).IsAssignableFrom(type);
        }
        /// <summary>
        /// Returns a new JsonConverter
        /// </summary>
        public override JsonConverter? CreateConverter(Type type, JsonSerializerOptions options)
        {
            return new UnionJSRuntimeConverter(type);
        }
    }
}
