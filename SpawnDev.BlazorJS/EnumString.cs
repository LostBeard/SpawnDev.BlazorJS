using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Enum string class
    /// </summary>
    public abstract class EnumString
    {
        /// <summary>
        /// The string value of this EnumString
        /// </summary>
        public abstract string? String { get; set; }
        /// <inheritdoc/>
        public override string ToString() => String ?? "";
    }
    /// <summary>
    /// Enum string class is a class that allows easy conversion to and from Enums, and strings<br />
    /// Serializes to: if (null) null; else Text, which can be null, an enum string, or any string value<br />
    /// Deserializes to: if (null) null; else EnumString<br />
    /// Setting Text to the deserialized string value<br />
    /// and if matching enum string is found:<br />
    /// - Sets Enum to the defined enum string<br />
    /// - Sets IsDefined = true<br />
    /// else:<br />
    /// - Sets Enum = null<br />
    /// - Sets IsDefined = false<br />
    /// Flags are not supported at this time
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public class EnumString<T> : EnumString where T : struct, Enum
    {
        private T? _Enum { get; set; }
        /// <summary>
        /// Enum value
        /// </summary>
        public T? Enum
        {
            get => _Enum;
            set
            {
                if (value != null && TypeMapping.TryGetValue(value.Value, out var jsonName))
                {
                    _String = jsonName;
                    _Enum = value;
                    IsDefined = true;
                }
                else
                {
                    _Enum = null;
                    _String = null;
                    IsDefined = false;
                }
            }
        }
        /// <summary>
        /// Returns true if the Enum value IsDefined
        /// </summary>
        public bool IsDefined { get; private set; }
        private string? _String = null;
        /// <summary>
        /// string value
        /// </summary>
        public override string? String
        {
            get => _String;
            set
            {
                foreach (var typeMapping in TypeMapping)
                {
                    if (typeMapping.Value == value)
                    {
                        IsDefined = true;
                        _Enum = (T)typeMapping.Key;
                        _String = typeMapping.Value;
                        return;
                    }
                }
                IsDefined = false;
                _Enum = null;
                _String = null;
            }
        }
        static Dictionary<Type, Dictionary<Enum, string>> Mappings = new Dictionary<Type, Dictionary<Enum, string>>();
        Dictionary<Enum, string> GetMapping()
        {
            var enumType = typeof(T);
            if (!Mappings.TryGetValue(enumType, out var typeMappings))
            {
                typeMappings = new Dictionary<Enum, string>();
                var values = (T[])System.Enum.GetValues(enumType);
                foreach (var value in values)
                {
                    var stringValue = value.ToString();
                    var jsonPropertyNameAttr = (JsonPropertyNameAttribute?)typeof(T).GetField(stringValue)?.GetCustomAttributes(typeof(JsonPropertyNameAttribute), false).FirstOrDefault();
                    typeMappings[value] = jsonPropertyNameAttr?.Name ?? stringValue;
                }
                Mappings.Add(enumType, typeMappings);
            }
            return typeMappings;
        }
        Dictionary<Enum, string> TypeMapping;
        /// <summary>
        /// New instance
        /// </summary>
        public EnumString()
        {
            TypeMapping = GetMapping();
        }
        /// <summary>
        /// New instance
        /// </summary>
        /// <param name="value"></param>
        public EnumString(T value)
        {
            TypeMapping = GetMapping();
            Enum = value;
        }
        /// <summary>
        /// New instance
        /// </summary>
        /// <param name="value"></param>
        public EnumString(string value)
        {
            TypeMapping = GetMapping();
            String = value;
        }
        /// <summary>
        /// Convert from enum
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator EnumString<T>(T value) => new EnumString<T>(value);
        /// <summary>
        /// Convert to enum
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator T(EnumString<T> value) => value.Enum!.Value;
        /// <summary>
        /// Convert from enum
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator EnumString<T>?(T? value) => value == null ? null : new EnumString<T>(value.Value);
        /// <summary>
        /// Convert to enum
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator T?(EnumString<T> value) => value == null || !value.IsDefined ? null : value.Enum;
        /// <summary>
        /// Convert from string
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator EnumString<T>(string value) => value == null ? null! : new EnumString<T>(value);
        /// <summary>
        /// Convert to string
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator string(EnumString<T> value) => value == null ? null! : value.String!;
    }
}
