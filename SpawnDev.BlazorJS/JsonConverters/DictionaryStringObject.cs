using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// Type of Dictionary&lt;string, object?>
    /// </summary>
    [JsonConverter(typeof(DictionaryStringObjectJsonConverter))]
    public class DictionaryStringObject : Dictionary<string, object?> { }
    /// <summary>
    /// DictionaryStringObject JsonConverter
    /// </summary>
    public class DictionaryStringObjectJsonConverter : JsonConverter<DictionaryStringObject>
    {
        /// <summary>
        /// Returns true if this converter can convert the specified type
        /// </summary>
        public override bool CanConvert(Type typeToConvert)
        {
            var ret = typeToConvert == typeof(DictionaryStringObject);
            return ret;
        }
        /// <summary>
        /// Reads the type value from the Json reader
        /// </summary>
        public override DictionaryStringObject? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException($"JsonTokenType was of type {reader.TokenType}, only objects are supported");
            }
            var ret = new DictionaryStringObject();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    break;
                }
                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException("JsonTokenType was not PropertyName");
                }
                var propertyName = reader.GetString();
                if (string.IsNullOrWhiteSpace(propertyName))
                {
                    throw new JsonException("Failed to get property name");
                }
                reader.Read();
                ret.Add(propertyName!, ExtractValue(ref reader, options));
            }
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, DictionaryStringObject? value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (IDictionary<string, object?>?)value, options);
        }
        private object? ExtractValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    if (reader.TryGetDateTime(out var date))
                    {
                        return date;
                    }
                    return reader.GetString();
                case JsonTokenType.False:
                    return false;
                case JsonTokenType.True:
                    return true;
                case JsonTokenType.Null:
                    return null;
                case JsonTokenType.Number:
                    if (reader.TryGetInt64(out var result))
                    {
                        return result;
                    }
                    return reader.GetDecimal();
                case JsonTokenType.StartObject:
                    return Read(ref reader, null!, options);
                case JsonTokenType.StartArray:
                    var list = new List<object?>();
                    while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                    {
                        list.Add(ExtractValue(ref reader, options));
                    }
                    return list;
                default:
                    throw new JsonException($"'{reader.TokenType}' is not supported");
            }
        }
    }
}
