using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// A helper class to allow passing undefined to JS
    /// </summary>
    public class Undefinable
    {
        /// <summary>
        /// Returns an Undefinable with a null value
        /// </summary>
        public static Undefinable Null => _Null.Value;
        /// <summary>
        /// Returns an Undefinable with an undefined value
        /// </summary>
        public static Undefinable Undefined => _Undefined.Value;
        private static Lazy<Undefinable> _Null = new Lazy<Undefinable>(() => new Undefinable() { IsUndefinedIfNull = false });
        private static Lazy<Undefinable> _Undefined = new Lazy<Undefinable>(() => new Undefinable());
        
        /// <summary>
        /// The value
        /// </summary>
        [JsonIgnore]
        public object? Value { get; set; }
        
        /// <summary>
        /// If true, null values are treated as undefined
        /// </summary>
        [JsonIgnore]
        public bool IsUndefinedIfNull { get; set; } = true;
        
        /// <summary>
        /// Returns true if the value is undefined
        /// </summary>
        [JsonPropertyName("__undefinedref__")]
        public bool IsUndefined => Value == null && IsUndefinedIfNull;
        
        //public static explicit operator object?(Undefinable instance) => instance.Value;
        //public static explicit operator UndefinedIfNull<TValue>(TValue? instance) => new UndefinedIfNull<TValue>(instance);
        //public static implicit operator TValue?(UndefinedIfNull<TValue> instance) => instance.Value;
        //public static implicit operator Undefinable(TValue? instance) => new Undefinable(instance);
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public Undefinable() { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isUndefinedIfNull"></param>
        public Undefinable(object? value, bool isUndefinedIfNull = true)
        {
            Value = value;
            IsUndefinedIfNull = isUndefinedIfNull;
        }
    }
    /// <summary>
    /// A helper class to allow passing undefined to JS
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Undefinable<T>
    {
        static Undefinable()
        {
            // Runtime check that TValue is a nullable type (compile time constraint not available)
            // Currently only firing exception if the type default value isn't null. This allows classes without the ? annotation
            //var isTypeNullable = Nullable.GetUnderlyingType(typeof(TValue)) != null;
            var isTypeDefaultNull = default(T) == null;
            if (!isTypeDefaultNull)
            {
                throw new Exception("T of Undefinable<T> must be a nullable type.");
            }
        }
        /// <summary>
        /// Returns an Undefinable with a null value
        /// </summary>
        public static Undefinable<T> Null => _Null.Value;
        /// <summary>
        /// Returns an Undefinable with an undefined value
        /// </summary>
        public static Undefinable<T> Undefined => _Undefined.Value;
        private static Lazy<Undefinable<T>> _Null = new Lazy<Undefinable<T>>(() => new Undefinable<T>() { IsUndefinedIfNull = false });
        private static Lazy<Undefinable<T>> _Undefined = new Lazy<Undefinable<T>>(() => new Undefinable<T>());

        /// <summary>
        /// The value
        /// </summary>
        [JsonIgnore]
        public T? Value { get; set; }
        
        /// <summary>
        /// If true, null values are treated as undefined
        /// </summary>
        [JsonIgnore]
        public bool IsUndefinedIfNull { get; set; } = true;

        /// <summary>
        /// Returns true if the value is undefined
        /// </summary>
        [JsonPropertyName("__undefinedref__")]
        public bool IsUndefined => Value == null && IsUndefinedIfNull;
        /// <summary>
        /// Explicit conversion to T
        /// </summary>
        /// <param name="instance"></param>
        public static explicit operator T?(Undefinable<T> instance) => instance.Value;
        //public static explicit operator UndefinedIfNull<TValue>(TValue? instance) => new UndefinedIfNull<TValue>(instance);
        //public static implicit operator TValue?(UndefinedIfNull<TValue> instance) => instance.Value;
        /// <summary>
        /// Implicit conversion to Undefinable
        /// </summary>
        /// <param name="instance"></param>
        public static implicit operator Undefinable<T>(T? instance) => new Undefinable<T>(instance);
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public Undefinable() { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isUndefinedIfNull"></param>
        public Undefinable(T? value, bool isUndefinedIfNull = true)
        {
            Value = value;
            IsUndefinedIfNull = isUndefinedIfNull;
        }
    }
}