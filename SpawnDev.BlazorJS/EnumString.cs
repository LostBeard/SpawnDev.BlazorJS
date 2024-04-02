using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Enum string class
    /// </summary>
    public abstract class EnumString
    {
        public abstract string? Text { get; set; }
    }
    /// <summary>
    /// Enum string class is a class that allows easy conversion to and from Enums, strings, and ints<br />
    /// Serializes to: if (null) null; else Text, which can be null, an enum string, or any string value<br />
    /// Deserializes to: if (null) null; else EnumString<br />
    /// Setting Text to the deserialized string value<br />
    /// and if matching enum string is found:<br />
    /// - Value to the matching enum string and IsDefined = true<br />
    /// else:<br />
    /// - IsDefined = false<br />
    /// Flags are not supported at this time
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [JsonConverter(typeof(EnumStringConverter))]
    public class EnumString<T> : EnumString where T : struct, Enum
    {
        public T? Value
        {
            get => _Value;
            set
            {
                IsDefined = value != null && Enum.IsDefined(typeof(T), value.Value);
                if (IsDefined)
                {
                    _Value = value;
                    _Text = value!.Value.ToString();
                    _Int = (int)Convert.ChangeType(value!.Value, value!.Value.GetTypeCode());
                }
                else
                {
                    _Text = null;
                    _Value = null;
                    _Int = null;
                }
            }
        }
        public int? Int
        {
            get => _Int;
            set
            {
                if (value == null)
                {
                    Value = null;
                }
                else
                {
                    Value = (T)Enum.ToObject(typeof(T), value.Value);
                }
            }
        }
        public bool IsDefined { get; private set; }
        private string? _Text = null;
        private T? _Value { get; set; }
        private int? _Int { get; set; }
        public override string? Text
        {
            get => _Text;
            set
            {
                _Text = value;
                if (!string.IsNullOrEmpty(value) && Enum.TryParse(typeof(T), value, out var e))
                {
                    IsDefined = true;
                    _Value = (T)e!;
                    _Int = (int)Convert.ChangeType(_Value!.Value, _Value!.Value.GetTypeCode());
                }
                else
                {
                    IsDefined = false;
                    _Value = null;
                    _Int = null;
                }
            }
        }
        public EnumString() { }
        public EnumString(int value) { Int = value; }
        public EnumString(T value) { Value = value; }
        public EnumString(string value) { Text = value; }
        // int
        public static implicit operator EnumString<T>(int value) => new EnumString<T>(value);
        public static implicit operator int(EnumString<T> value) => value.Int!.Value;   // will throw if !Valid
        // int?
        public static implicit operator EnumString<T>?(int? value) => value == null ? null : new EnumString<T>(value.Value);
        public static implicit operator int?(EnumString<T>? value) => value == null || !value.IsDefined ? null : value.Int;
        // T
        public static implicit operator EnumString<T>(T value) => new EnumString<T>(value);
        public static implicit operator T(EnumString<T> value) => value.Value!.Value;
        // T?
        public static implicit operator EnumString<T>?(T? value) => value == null ? null : new EnumString<T>(value.Value);
        public static implicit operator T?(EnumString<T> value) => value == null || !value.IsDefined ? null : value.Value;
        // string?
        public static implicit operator EnumString<T>?(string? value) => value == null ? null : new EnumString<T>(value);
        public static implicit operator string?(EnumString<T>? value) => value == null ? null : value.Text;
    }
}
