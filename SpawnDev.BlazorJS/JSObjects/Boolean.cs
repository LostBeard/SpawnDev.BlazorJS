using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Boolean object represents a truth value: true or false.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Boolean
    /// </summary>
    public class Boolean : JSObject
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Boolean(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion
        /// <summary>
        /// The valueOf() method of Boolean values returns the primitive value of a Boolean object.
        /// </summary>
        /// <returns></returns>
        public bool ValueOf() => JSRef.Call<bool>("valueOf");
        /// <summary>
        /// The toString() method of Boolean values returns a string representing the specified boolean value.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JSRef.Call<string>("toString");
        /// <summary>
        /// Implicit conversion to a .Net bool
        /// </summary>
        /// <param name="booleanObj"></param>
        public static implicit operator bool(Boolean booleanObj) => booleanObj.ValueOf();
    }
}
