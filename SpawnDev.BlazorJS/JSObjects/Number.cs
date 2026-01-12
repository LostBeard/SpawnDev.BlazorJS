using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Number values represent floating-point numbers like 37 or -9.25.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Number
    /// </summary>
    public class Number : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Number(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Number(Union<int, uint, float, double, long, ulong, byte, short, ushort> value) : base(JS.New(nameof(Number), value)) { }
        public float ValueOfFloat() => JSRef!.Call<float>("valueOf");
        public double ValueOfDouble() => JSRef!.Call<double>("valueOf");
        public int ValueOfInt32() => JSRef!.Call<int>("valueOf");
        public uint ValueOfUint32() => JSRef!.Call<uint>("valueOf");
        public short ValueOfInt16() => JSRef!.Call<short>("valueOf");
        public ushort ValueOfUint16() => JSRef!.Call<ushort>("valueOf");
        public long ValueOfInt64() => JSRef!.Call<long>("valueOf");
        public ulong ValueOfUint64() => JSRef!.Call<ulong>("valueOf");
        public byte ValueOfByte() => JSRef!.Call<byte>("valueOf");
        public static implicit operator long(Number number) => number.ValueOfInt64();
        public static implicit operator ulong(Number number) => number.ValueOfUint64();
        public static implicit operator float(Number number) => number.ValueOfFloat();
        public static implicit operator double(Number number) => number.ValueOfDouble();
        public static implicit operator short(Number number) => number.ValueOfInt16();
        public static implicit operator ushort(Number number) => number.ValueOfUint16();
        public static implicit operator byte(Number number) => number.ValueOfByte();
        public static implicit operator int(Number number) => number.ValueOfInt32();
        public static implicit operator uint(Number number) => number.ValueOfUint32();
        /// <summary>
        /// The Number.isNaN() static method determines whether the passed value is the number value NaN, and returns false if the input is not of the Number type. It is a more robust version of the original, global isNaN() function.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNaN(object value) => JS.Call<bool>($"Number.isNaN", value);
        /// <summary>
        /// The Number.isInteger() static method determines whether the passed value is an integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInteger(object value) => JS.Call<bool>($"Number.isInteger", value);
        /// <summary>
        /// The Number.isSafeInteger() static method determines whether the provided value is a number that is a safe integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsSafeInteger(object value) => JS.Call<bool>($"Number.isSafeInteger", value);
        /// <summary>
        /// The Number.isFinite() static method determines whether the passed value is a finite number — that is, it checks that a given value is a number, and the number is neither positive Infinity, negative Infinity, nor NaN.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsFinite(object value) => JS.Call<bool>($"Number.isFinite", value);
        /// <summary>
        /// The Number.POSITIVE_INFINITY static data property represents the positive Infinity value.
        /// </summary>
        public static Number POSITIVE_INFINITY => JS.Get<Number>("Number.POSITIVE_INFINITY");
        /// <summary>
        /// The Number.NEGATIVE_INFINITY static data property represents the negative Infinity value.
        /// </summary>
        public static Number NEGATIVE_INFINITY => JS.Get<Number>("Number.NEGATIVE_INFINITY");
        /// <summary>
        /// The Number.NaN static data property represents Not-A-Number, which is equivalent to NaN. For more information about the behaviors of NaN, see the description for the global property.
        /// </summary>
        public static Number NaN => JS.Get<Number>("Number.NaN");
        /// <summary>
        /// The Number.MIN_VALUE static data property represents the smallest positive numeric value representable in JavaScript.
        /// </summary>
        public static Number MIN_VALUE => JS.Get<Number>("Number.MIN_VALUE");
        /// <summary>
        /// The Number.MAX_VALUE static data property represents the maximum numeric value representable in JavaScript.
        /// </summary>
        public static Number MAX_VALUE => JS.Get<Number>("Number.MAX_VALUE");
        /// <summary>
        /// The Number.MAX_SAFE_INTEGER static data property represents the maximum safe integer in JavaScript (253 – 1).
        /// </summary>
        public static long MAX_SAFE_INTEGER { get; } = 9007199254740991;
        /// <summary>
        /// The Number.MIN_SAFE_INTEGER static data property represents the minimum safe integer in JavaScript, or -(253 - 1).
        /// </summary>
        public static long MIN_SAFE_INTEGER { get; } = -9007199254740991;
    }
}
