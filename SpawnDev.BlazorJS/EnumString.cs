using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Enum string class
    /// </summary>
    public abstract class EnumString
    {
        public abstract string? String { get; set; }
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
    [JsonConverter(typeof(EnumStringConverter))]
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
                IsDefined = value != null && System.Enum.IsDefined(typeof(T), value.Value);
                if (IsDefined)
                {
                    _Enum = value;
                    _String = value!.Value.ToString();
                }
                else
                {
                    _Enum = null;
                    _String = null;
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
                _String = value;
                if (!string.IsNullOrEmpty(value) && System.Enum.TryParse(typeof(T), value, out var e))
                {
                    IsDefined = true;
                    _Enum = (T)e!;
                }
                else
                {
                    IsDefined = false;
                    _Enum = null;
                }
            }
        }
        public EnumString() { }
        public EnumString(T value) { Enum = value; }
        public EnumString(string value) { String = value; }
        // T
        public static implicit operator EnumString<T>(T value) => new EnumString<T>(value);
        public static implicit operator T(EnumString<T> value) => value.Enum!.Value;
        // T?
        public static implicit operator EnumString<T>?(T? value) => value == null ? null : new EnumString<T>(value.Value);
        public static implicit operator T?(EnumString<T> value) => value == null || !value.IsDefined ? null : value.Enum;
        // string?
        public static implicit operator EnumString<T>?(string? value) => value == null ? null : new EnumString<T>(value);
        public static implicit operator string?(EnumString<T>? value) => value == null ? null : value.String;
    }
}
