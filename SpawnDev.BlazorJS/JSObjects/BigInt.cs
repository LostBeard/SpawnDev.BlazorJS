using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// BigInt values represent numeric values which are too large to be represented by the number primitive.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/BigInt
    /// </summary>
    public class BigInt<T> where T : struct
    {
        /// <summary>
        /// Returns true if the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is BigInt<T> bigInt)
            {
                return Value.Equals(bigInt.Value);
            }
            return base.Equals(obj);
        }
        /// <summary>
        /// Implicit conversion to T?
        /// </summary>
        public static implicit operator T?(BigInt<T>? bigInt) => bigInt == null ? null : bigInt.Value;
        /// <summary>
        /// Implicit conversion to BigInt
        /// </summary>
        public static implicit operator BigInt<T>?(T? value) => value == null ? null : new BigInt<T>(value.Value);
        /// <summary>
        /// Implicit conversion to T
        /// </summary>
        public static implicit operator T(BigInt<T> bigInt) => bigInt == null ? throw new NullReferenceException(nameof(bigInt)) : bigInt.Value;
        /// <summary>
        /// Implicit conversion to BigInt
        /// </summary>
        public static implicit operator BigInt<T>(T value) => new BigInt<T>(value);
        /// <summary>
        /// The value as a numeric string
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("$bigint")]
        public string ValueString
        {
            get => Value.ToString()!;
            set => Value = (T)Convert.ChangeType(value, typeof(T))!;
        }
        /// <summary>
        /// The value as type T
        /// </summary>
        [JsonIgnore]
        public T Value { get; set; }
        /// <summary>
        /// Default 0 argument constructor
        /// </summary>
        public BigInt() { }
        /// <summary>
        /// Creates a new instance of BigInt
        /// </summary>
        public BigInt(T value) { Value = value; }
        /// <inheritdoc/>
        public override int GetHashCode() => Value.GetHashCode();
    }
}
