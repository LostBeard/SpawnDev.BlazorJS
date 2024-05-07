using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// BigInt values represent numeric values which are too large to be represented by the number primitive.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/BigInt
    /// </summary>
    public class BigInt<T> where T : struct
    {
        public static implicit operator T?(BigInt<T>? bigInt) => bigInt == null ? null : bigInt.Value;
        public static implicit operator BigInt<T>?(T? value) => value == null ? null : new BigInt<T>(value.Value);
        public static implicit operator T(BigInt<T> bigInt) => bigInt == null ? throw new NullReferenceException(nameof(bigInt)) : bigInt.Value;
        public static implicit operator BigInt<T>(T value) => new BigInt<T>(value);
        [JsonInclude]
        [JsonPropertyName("$bigint")]
        public string ValueString
        {
            get => Value.ToString()!;
            set => Value = (T)Convert.ChangeType(value, typeof(T))!;
        }
        [JsonIgnore]
        public T Value { get; set; }
        public BigInt() { }
        public BigInt(T value) { Value = value; }
    }
}
