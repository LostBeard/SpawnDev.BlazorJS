using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    public class JsonConverterCollection : JsonConverterFactory
    {
        private List<JsonConverter> _converters = new List<JsonConverter>();
        public IReadOnlyList<JsonConverter> JsonConverterFactories => _converters.AsReadOnly();
        JsonConverter? GetJsonConverter(Type type)
        {
            foreach (var converter in _converters)
            {
                if (converter.CanConvert(type)) return converter;
            }
            return null;
        }
        public override bool CanConvert(Type type) => GetJsonConverter(type) != null;
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
        public void Add(JsonConverter jsonConverter)
        {
            if (Locked) throw new Exception("Collection is locked. JsonConverters cannot be added.");
            _converters.Add(jsonConverter);
        }
        public bool Locked { get; private set; } = false;
        public void Lock() => Locked = true;
    }
}
