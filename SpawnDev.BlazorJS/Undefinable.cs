using System;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    public class Undefinable<T>
    {
        static Undefinable()
        {
            // Runtime check that T is a nullable type (compile time constraint not available)
            // Currently only firing exception if the type default value isn't null. This allows classes without the ? annotation
            //var isTypeNullable = Nullable.GetUnderlyingType(typeof(T)) != null;
            var isTypeDefaultNull = default(T) == null;
            if (!isTypeDefaultNull)
            {
                throw new Exception("T of Undefinable<T> must be a nullable type.");
            }
        }
        public static Undefinable<T> Null => _Null.Value;
        public static Undefinable<T> Undefined => _Undefined.Value;
        private static Lazy<Undefinable<T>> _Null = new Lazy<Undefinable<T>>(() => new Undefinable<T>(false));
        private static Lazy<Undefinable<T>> _Undefined = new Lazy<Undefinable<T>>(() => new Undefinable<T>());

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