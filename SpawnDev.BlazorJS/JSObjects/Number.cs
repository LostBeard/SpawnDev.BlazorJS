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
        /// <summary>
        /// Creates a new Number
        /// </summary>
        /// <param name="value"></param>
        public Number(Union<int, uint, float, double, long, ulong, byte, short, ushort> value) : base(JS.New(nameof(Number), value)) { }
        /// <summary>
        /// Returns the value of the object as a float
        /// </summary>
        /// <returns></returns>
        public float ValueOfFloat() => JSRef!.Call<float>("valueOf");
        /// <summary>
        /// Returns the value of the object as a double
        /// </summary>
        /// <returns></returns>
        public double ValueOfDouble() => JSRef!.Call<double>("valueOf");
        /// <summary>
        /// Returns the value of the object as an int
        /// </summary>
        /// <returns></returns>
        public int ValueOfInt32() => JSRef!.Call<int>("valueOf");
        /// <summary>
        /// Returns the value of the object as a uint
        /// </summary>
        /// <returns></returns>
        public uint ValueOfUint32() => JSRef!.Call<uint>("valueOf");
        /// <summary>
        /// Returns the value of the object as a short
        /// </summary>
        /// <returns></returns>
        public short ValueOfInt16() => JSRef!.Call<short>("valueOf");
        /// <summary>
        /// Returns the value of the object as a ushort
        /// </summary>
        /// <returns></returns>
        public ushort ValueOfUint16() => JSRef!.Call<ushort>("valueOf");
        /// <summary>
        /// Returns the value of the object as a long
        /// </summary>
        /// <returns></returns>
        public long ValueOfInt64() => JSRef!.Call<long>("valueOf");
        /// <summary>
        /// Returns the value of the object as a ulong
        /// </summary>
        /// <returns></returns>
        public ulong ValueOfUint64() => JSRef!.Call<ulong>("valueOf");
        /// <summary>
        /// Returns the value of the object as a byte
        /// </summary>
        /// <returns></returns>
        public byte ValueOfByte() => JSRef!.Call<byte>("valueOf");
        /// <summary>
        /// Implicit conversion to long
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator long(Number number) => number.ValueOfInt64();
        /// <summary>
        /// Implicit conversion to ulong
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator ulong(Number number) => number.ValueOfUint64();
        /// <summary>
        /// Implicit conversion to float
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator float(Number number) => number.ValueOfFloat();
        /// <summary>
        /// Implicit conversion to double
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator double(Number number) => number.ValueOfDouble();
        /// <summary>
        /// Implicit conversion to short
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator short(Number number) => number.ValueOfInt16();
        /// <summary>
        /// Implicit conversion to ushort
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator ushort(Number number) => number.ValueOfUint16();
        /// <summary>
        /// Implicit conversion to byte
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator byte(Number number) => number.ValueOfByte();
        /// <summary>
        /// Implicit conversion to int
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator int(Number number) => number.ValueOfInt32();
        /// <summary>
        /// Implicit conversion to uint
        /// </summary>
        /// <param name="number"></param>
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
