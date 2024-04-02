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
    /// Enum string class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [JsonConverter(typeof(EnumStringConverter))]
    public class EnumString<T> : EnumString where T : struct, Enum
    {
        public bool Valid { get; private set; }
        private T _Value { get; set; }
        public T Value
        {
            get => Valid ? _Value : throw new Exception("Invalid enum value. Check EnumString.Valid property before using EnumString.Value");
            set
            {
                Valid = Enum.IsDefined(typeof(T), value);
                if (Valid) _Value = value;
            }
        }
        public int Int
        {
            get => (int)Convert.ChangeType(Value, Value.GetTypeCode());
            set
            {
                var v = (T)Enum.ToObject(typeof(T), value);
                Valid = Enum.IsDefined(typeof(T), v);
                if (Valid) _Value = v;
            }
        }
        public override string? Text
        {
            get => Valid ? _Value.ToString() : null;
            set
            {
                Valid = Enum.TryParse(typeof(T), value, out var e);
                if (Valid) Value = (T)e!;
            }
        }
        public EnumString() { }
        public EnumString(int value) { Int = value; }
        public EnumString(T value) { Value = value; }
        public EnumString(string value) { Text = value; }
        // int
        public static implicit operator EnumString<T>(int value) => new EnumString<T>(value);
        public static implicit operator int(EnumString<T> value) => value.Int;   // will throw if !Valid
        // int?
        public static implicit operator EnumString<T>?(int? value) => value == null ? null : new EnumString<T>(value.Value);
        public static implicit operator int?(EnumString<T>? value) => value == null || !value.Valid ? null : value.Int;
        // T
        public static implicit operator EnumString<T>(T value) => new EnumString<T>(value);
        public static implicit operator T(EnumString<T> value) => value.Value;
        // T?
        public static implicit operator EnumString<T>?(T? value) => value == null ? null : new EnumString<T>(value.Value);
        public static implicit operator T?(EnumString<T> value) => value == null || !value.Valid ? null : value.Value;
        // string?
        public static implicit operator EnumString<T>?(string? value) => value == null ? null : new EnumString<T>(value);
        public static implicit operator string?(EnumString<T>? value) => value == null ? null : value.Text;
    }
}
