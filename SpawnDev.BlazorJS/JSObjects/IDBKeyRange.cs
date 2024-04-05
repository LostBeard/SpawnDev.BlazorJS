using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The IDBKeyRange interface of the IndexedDB API represents a continuous interval over some data type that is used for keys. Records can be retrieved from IDBObjectStore and IDBIndex objects using keys or a range of keys. You can limit the range using lower and upper bounds. For example, you can iterate over all values of a key in the value range A–Z.
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBKeyRange
    /// </summary>
    public class IDBKeyRange<TKey> : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBKeyRange(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a boolean indicating whether a specified key is inside the key range.
        /// </summary>
        /// <param name="key">The key you want to check for in your key range. This can be any type.</param>
        /// <returns>IDBKeyRange: The newly created key range.</returns>
        public bool Includes(TKey? key) => JSRef!.Call<bool>("includes", key);
        /// <summary>
        /// Lower bound of the key range.
        /// </summary>
        public TKey Lower => JSRef!.Get<TKey>("lower");
        /// <summary>
        /// Upper bound of the key range.
        /// </summary>
        public TKey Upper => JSRef!.Get<TKey>("upper");
        /// <summary>
        /// Returns false if the upper-bound value is included in the key range.
        /// </summary>
        public bool UpperOpen => JSRef!.Get<bool>("upperOpen");
        /// <summary>
        /// Returns false if the lower-bound value is included in the key range.
        /// </summary>
        public bool LowerOpen => JSRef!.Get<bool>("lowerOpen");
        #region Static methods
        /// <summary>
        /// Creates a new key range with upper and lower bounds.
        /// </summary>
        /// <param name="lower">specifies the lower bound of the new key range.</param>
        /// <param name="upper">specifies the upper bound of the new key range.</param>
        /// <param name="lowerOpen">indicates whether the lower bound excludes the endpoint value. The default is false.</param>
        /// <param name="upperOpen">Indicates whether the upper bound excludes the endpoint value. The default is false.</param>
        /// <returns>IDBKeyRange: The newly created key range.</returns>
        public static IDBKeyRange<TKey> Bound(TKey lower, TKey upper, bool lowerOpen = false, bool upperOpen = false) => JS.Call<IDBKeyRange<TKey>>($"IDBKeyRange.bound", lower, upper, lowerOpen, upperOpen);
        /// <summary>
        /// Creates a new key range containing a single value.
        /// </summary>
        /// <param name="value">The value for the new key range.</param>
        /// <returns></returns>
        public static IDBKeyRange<TKey> Only(TKey value) => JS.Call<IDBKeyRange<TKey>>($"IDBKeyRange.only", value);
        /// <summary>
        /// Creates a new key range with only a lower bound.
        /// </summary>
        /// <param name="lower">Specifies the lower bound of the new key range.</param>
        /// <param name="open">Indicates whether the lower bound excludes the endpoint value. The default is false.</param>
        /// <returns>IDBKeyRange: The newly created key range.</returns>
        public static IDBKeyRange<TKey> LowerBound(TKey lower, bool open = false) => JS.Call<IDBKeyRange<TKey>>($"IDBKeyRange.lowerBound", lower, open);
        /// <summary>
        /// Creates a new upper-bound key range.
        /// </summary>
        /// <param name="upper">Specifies the upper bound of the new key range.</param>
        /// <param name="open">Indicates whether the upper bound excludes the endpoint value. The default is false.</param>
        /// <returns>IDBKeyRange: The newly created key range.</returns>
        public static IDBKeyRange<TKey> UpperBound(TKey upper, bool open = false) => JS.Call<IDBKeyRange<TKey>>($"IDBKeyRange.upperBound", upper, open);
        #endregion
    }
}
