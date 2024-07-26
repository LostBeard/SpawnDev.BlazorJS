using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// JsonConverterCollection enables presenting a collection of JsonConverters as a single converter
    /// </summary>
    public class JsonConverterCollection : JsonConverterFactory
    {
        private List<JsonConverter> _converters = new List<JsonConverter>();
        /// <summary>
        /// ReadOnly list of JsonConverters
        /// </summary>
        public IReadOnlyList<JsonConverter> JsonConverterFactories => _converters.AsReadOnly();
        /// <summary>
        /// Returns the converter, if any, that can convert the specified type
        /// </summary>
        public JsonConverter? GetJsonConverter(Type type)
        {
            foreach (var converter in _converters)
            {
                if (converter.CanConvert(type)) return converter;
            }
            return null;
        }
        /// <summary>
        /// Returns true if any of the converters in the collection can convert the given type
        /// </summary>
        public override bool CanConvert(Type type) => GetJsonConverter(type) != null;
        /// <summary>
        /// Creates a converter for a specified type
        /// </summary>
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converter = GetJsonConverter(typeToConvert);
            if (converter == null) return null;
            if (converter is JsonConverterFactory factory)
            {
                return factory.CreateConverter(typeToConvert, options);
            }
            else
            {
                return converter;
            }
        }
        /// <summary>
        /// Add new json converter or converter factory
        /// </summary>
        public void Add(JsonConverter jsonConverter)
        {
            if (Locked) throw new Exception("Collection is locked. JsonConverters cannot be added.");
            _converters.Add(jsonConverter);
        }
        /// <summary>
        /// Once locked, the converter collection cannot be modified
        /// </summary>
        public bool Locked { get; private set; } = false;
        /// <summary>
        /// Locks the converter collection so it cannot be modified
        /// </summary>
        public void Lock() => Locked = true;
    }
}
