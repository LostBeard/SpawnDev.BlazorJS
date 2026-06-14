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
        public Number(int value) : this((double)value) { }
        /// <summary>
        /// Creates a new Number
        /// </summary>
        public Number(uint value) : this((double)value) { }
        /// <summary>
        /// Creates a new Number
        /// </summary>
        public Number(long value) : this((double)value) { }
        /// <summary>
        /// Creates a new Number
        /// </summary>
        public Number(ulong value) : this((double)value) { }
        /// <summary>
        /// Creates a new Number
        /// </summary>
        public Number(byte value) : this((double)value) { }
        /// <summary>
        /// Creates a new Number
        /// </summary>
        public Number(short value) : this((double)value) { }
        /// <summary>
        /// Creates a new Number
        /// </summary>
        public Number(ushort value) : this((double)value) { }
        /// <summary>
        /// Creates a new Number
        /// </summary>
        public Number(Half value) : this((double)value) { }
        /// <summary>
        /// Creates a new Number
        /// </summary>
        public Number(double value) : base(new Float64Array(1).Using(float64Array => {
            float64Array.Write([value]);
            var firstValue = float64Array.JSRef!.Get<Number>(0);
            return firstValue;

        }).JSRefMove<IJSInProcessObjectReference>()) 
        { }
        /// <summary>
        /// Returns the value of the object as a float
        /// </summary>
        /// <returns></returns>
        public float ValueOfFloat() => (float)ValueOfDouble();
        /// <summary>
        /// Returns the value of the object as a double
        /// </summary>
        /// <returns></returns>
        public double ValueOfDouble()
        {
            using var float64Array = new Float64Array(1);
            float64Array.JSRef!.Set(0, this);
            var safeDouble = float64Array.Read<double>();
            return safeDouble[0];
        }

        public static Number FromDouble(double value)
        {
            using var float64Array = new Float64Array(1);
            float64Array.Write<double>([value]);
            var firstValue = float64Array.JSRef!.Get<Number>(0);
            return firstValue;
        }
        /// <summary>
        /// Returns the value of the object as an int
        /// </summary>
        /// <returns></returns>
        public int ValueOfInt32() => (int)ValueOfDouble();
        /// <summary>
        /// Returns the value of the object as a uint
        /// </summary>
        /// <returns></returns>
        public uint ValueOfUint32() => (uint)ValueOfDouble();
        /// <summary>
        /// Returns the value of the object as a short
        /// </summary>
        /// <returns></returns>
        public short ValueOfInt16() => (short)ValueOfDouble();
        /// <summary>
        /// Returns the value of the object as a ushort
        /// </summary>
        /// <returns></returns>
        public ushort ValueOfUint16() => (ushort)ValueOfDouble();
        /// <summary>
        /// Returns the value of the object as a long
        /// </summary>
        /// <returns></returns>
        public long ValueOfInt64() => (long)ValueOfDouble();
        /// <summary>
        /// Returns the value of the object as a ulong
        /// </summary>
        /// <returns></returns>
        public ulong ValueOfUint64() => (ulong)ValueOfDouble();
        /// <summary>
        /// Returns the value of the object as a byte
        /// </summary>
        /// <returns></returns>
        public byte ValueOfByte() => (byte)ValueOfDouble();
        /// <summary>
        /// Returns the value of the object as a Half
        /// </summary>
        /// <returns></returns>
        public Half ValueOfHalf() => (Half)ValueOfDouble();
        /// <summary>
        /// Implicit conversion to long
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator long(Number number) => number.ValueOfInt64();

        public static implicit operator Number(long number) => new Number(number);
        /// <summary>
        /// Implicit conversion to ulong
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator ulong(Number number) => number.ValueOfUint64();

        public static implicit operator Number(ulong number) => new Number(number);
        /// <summary>
        /// Implicit conversion to float
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator float(Number number) => number.ValueOfFloat();

        public static implicit operator Number(float number) => new Number(number);
        /// <summary>
        /// Implicit conversion to double
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator double(Number number) => number.ValueOfDouble();

        public static implicit operator Number(double number) => new Number(number);
        /// <summary>
        /// Implicit conversion to short
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator short(Number number) => number.ValueOfInt16();

        public static implicit operator Number(short number) => new Number(number);
        /// <summary>
        /// Implicit conversion to ushort
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator ushort(Number number) => number.ValueOfUint16();

        public static implicit operator Number(ushort number) => new Number(number);
        /// <summary>
        /// Implicit conversion to byte
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator byte(Number number) => number.ValueOfByte();

        public static implicit operator Number(byte number) => new Number(number);
        /// <summary>
        /// Implicit conversion to int
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator int(Number number) => number.ValueOfInt32();

        public static implicit operator Number(int number) => new Number(number);
        /// <summary>
        /// Implicit conversion to Half
        /// </summary>
        /// <param name="number"></param>
        public static implicit operator Half(Number number) => number.ValueOfHalf();

        public static implicit operator Number(Half number) => new Number(number);
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
