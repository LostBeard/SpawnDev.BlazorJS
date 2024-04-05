using Microsoft.JSInterop;
using System.Diagnostics.Tracing;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Number : JSObject
    {
        public Number(IJSInProcessObjectReference _ref) : base(_ref){ }
        public Number(Union<int, uint, float, double, long, ulong, byte, short, ushort> value) : base(JS.New(nameof(Number), value)) { }
        public float ValueOfFloat() => JSRef.Call<float>("valueOf");
        public double ValueOfDouble() => JSRef.Call<double>("valueOf");
        public int ValueOfInt32() => JSRef.Call<int>("valueOf");
        public uint ValueOfUint32() => JSRef.Call<uint>("valueOf");
        public short ValueOfInt16() => JSRef.Call<short>("valueOf");
        public ushort ValueOfUint16() => JSRef.Call<ushort>("valueOf");
        public long ValueOfInt64() => JSRef.Call<long>("valueOf");
        public ulong ValueOfUint64() => JSRef.Call<ulong>("valueOf");
        public byte ValueOfByte() => JSRef.Call<byte>("valueOf");
        public static implicit operator long (Number number) => number.ValueOfInt64();
        public static implicit operator ulong(Number number) => number.ValueOfUint64();
        public static implicit operator float(Number number) => number.ValueOfFloat();
        public static implicit operator double(Number number) => number.ValueOfDouble();
        public static implicit operator short(Number number) => number.ValueOfInt16();
        public static implicit operator ushort(Number number) => number.ValueOfUint16();
        public static implicit operator byte(Number number) => number.ValueOfByte();
        public static implicit operator int(Number number) => number.ValueOfInt32();
        public static implicit operator uint(Number number) => number.ValueOfUint32();
        public static bool IsNaN(object value) => JS.Call<bool>($"{nameof(Number)}.isNaN", value);

        public static bool IsInteger(object value) => JS.Call<bool>($"{nameof(Number)}.isInteger", value);

        public static bool IsSafeInteger(object value) => JS.Call<bool>($"{nameof(Number)}.isSafeInteger", value);

        public static bool IsFinite(object value) => JS.Call<bool>($"{nameof(Number)}.isFinite", value);
    }
}
