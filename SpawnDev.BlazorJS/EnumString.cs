using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Enum string class
    /// </summary>
    public abstract class EnumString
    {
        public abstract string ValueText { get; set; }
    }
    /// <summary>
    /// Enum string class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [JsonConverter(typeof(EnumStringConverter))]
    public class EnumString<T> : EnumString where T : Enum
    {
        public T Value { get; set; }
        public override string ValueText
        {
            get => Value.ToString();
            set
            {
                if (!Enum.TryParse(typeof(T), value, out var e)) throw new Exception("Invalid EnumString value for enum");
                Value = (T)e;
            }
        }
        public static implicit operator int?(EnumString<T>? enumString) => enumString == null ? null : (int)Convert.ChangeType(enumString.Value, enumString.Value.GetTypeCode());
        public static implicit operator int(EnumString<T> enumString) => (int)Convert.ChangeType(enumString.Value, enumString.Value.GetTypeCode());
        public static implicit operator string?(EnumString<T>? enumString) => enumString == null ? null : enumString.ValueText;
        public static implicit operator EnumString<T>?(string? enumString) => string.IsNullOrEmpty(enumString) ? null : new EnumString<T> { ValueText = enumString };
        public static implicit operator T(EnumString<T> enumString) => enumString.Value;
        public static implicit operator EnumString<T>(T enumValue) => new EnumString<T> { Value = enumValue };
    }
}
