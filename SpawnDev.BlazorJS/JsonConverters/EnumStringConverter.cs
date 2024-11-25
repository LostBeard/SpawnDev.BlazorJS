using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// Converter for EnumString that serializes to EnumString.Text and deserializes from a string value
    /// </summary>
    public class EnumStringConverterFactory : JsonConverterFactory
    {
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert.IsEnum)
            {
                return true;
            }
            var baseType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : typeToConvert;
            var isEnumString = baseType == typeof(EnumString<>);
            if (isEnumString)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Create converter
        /// </summary>
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            if (typeToConvert.IsEnum)
            {
                var converterType = typeof(EnumAsStringConverter<>).MakeGenericType(typeToConvert);
                var converter = (JsonConverter)Activator.CreateInstance(converterType)!;
                return converter;
            }
            var baseType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : typeToConvert;
            var isEnumString = baseType == typeof(EnumString<>);
            if (isEnumString)
            {
                var enumType = typeToConvert.GenericTypeArguments.First();
                var converterType = typeof(EnumStringConverter<>).MakeGenericType(typeToConvert);
                var converter = (JsonConverter)Activator.CreateInstance(converterType)!;
                return converter;
            }
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Serializes and Deserializes an Enum as string<br/>
    /// To use add below to enum declaration:<br/>
    /// [JsonConverter(typeof(EnumStringConverterFactory))]<br/>
    /// Set string values using JsonPropertyName attribute on the enum value.<br/>
    /// Ex:<br/>
    /// [JsonPropertyName("enum_string_value")]<br/>
    /// </summary>
    /// <typeparam name="TEnum">Enum type</typeparam>
    public class EnumAsStringConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
    {
        /// <summary>
        /// Read
        /// </summary>
        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var v = JsonSerializer.Deserialize<string?>(ref reader);
            if (string.IsNullOrEmpty(v)) return default;
            var enumStringType = typeof(EnumString<TEnum>);
            var ret = (EnumString<TEnum>)Activator.CreateInstance(enumStringType)!;
            ret.String = v;
            return (TEnum)ret.Enum!;
        }
        /// <summary>
        /// Write
        /// </summary>
        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            var enumStringType = typeof(EnumString<TEnum>);
            var ret = (EnumString<TEnum>)Activator.CreateInstance(enumStringType)!;
            ret.Enum = value;
            JsonSerializer.Serialize(writer, ret.String);
        }
    }
    /// <summary>
    /// Serializes and Deserializes an EnumString type<br/>
    /// </summary>
    /// <typeparam name="TEnumString"></typeparam>
    public class EnumStringConverter<TEnumString> : JsonConverter<TEnumString> where TEnumString : EnumString
    {
        /// <summary>
        /// Read
        /// </summary>
        public override TEnumString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var v = JsonSerializer.Deserialize<string?>(ref reader);
            if (string.IsNullOrEmpty(v)) return default!;
            var ret = (EnumString)Activator.CreateInstance(typeToConvert)!;
            ret.String = v;
            return (TEnumString)ret;
        }
        /// <summary>
        /// Write
        /// </summary>
        public override void Write(Utf8JsonWriter writer, TEnumString value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value?.String);
        }
    }
}
