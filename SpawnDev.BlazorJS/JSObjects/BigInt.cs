using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// BigInt values represent numeric values which are too large to be represented by the number primitive.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/BigInt
    /// </summary>
    public class BigInt : JSObject
    {
        public static implicit operator long?(BigInt? bigInt) => bigInt == null ? null : bigInt.ValueOf();

        public static implicit operator BigInt?(long? value) => value == null ? null : new BigInt(value.Value);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public BigInt(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The BigInt() function returns primitive values of type BigInt.
        /// </summary>
        /// <param name="value">The value to be converted to a BigInt value. It may be a string, an integer, a boolean, or another BigInt.</param>
        public BigInt(long value) : base(JS.Call<IJSInProcessObjectReference>(nameof(BigInt), value.ToString())) { }
        //public BigInt(long value) : base(NullRef)
        //{
        //    using var bigIntArray = new BigInt64Array(new[] { value });
        //    var jsRef = bigIntArray.JSRef!.Get<IJSInProcessObjectReference>(0);
        //    FromReference(jsRef);
        //}
        /// <summary>
        /// Returns this BigInt value. Overrides the Object.prototype.valueOf() method.
        /// </summary>
        /// <returns></returns>
        public long ValueOf() => long.Parse(JSRef!.Call<string>("toString"));
        //{
        //    var longStr = JSRef!.Call<string>("toString");
        //    using var bigIntArray = new BigInt64Array(new[] { this });
        //    return bigIntArray[0];
        //}
    }
}
