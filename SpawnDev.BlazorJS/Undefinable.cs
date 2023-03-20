using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    public class Undefinable<T>
    {
        public static Undefinable<T> Null => new Undefinable<T>(false);
        [JsonIgnore]
        public T? Value { get; set; }
        [JsonIgnore]
        public bool IsUndefinedIfNull { get; set; } = true;
        [JsonPropertyName("__undefinedref__")]
        public bool IsUndefined => Value == null && IsUndefinedIfNull;
        public static explicit operator T?(Undefinable<T> instance) => instance.Value;
        //public static explicit operator UndefinedIfNull<T>(T? instance) => new UndefinedIfNull<T>(instance);
        //public static implicit operator T?(UndefinedIfNull<T> instance) => instance.Value;
        public static implicit operator Undefinable<T>(T instance) => new Undefinable<T>(instance);
        public Undefinable() { }
        public Undefinable(bool isUndefinedIfNull) => IsUndefinedIfNull = isUndefinedIfNull;
        public Undefinable(T? value = default, bool isUndefinedIfNull = true)
        {
            Value = value;
            IsUndefinedIfNull = isUndefinedIfNull;
        }
    }
}