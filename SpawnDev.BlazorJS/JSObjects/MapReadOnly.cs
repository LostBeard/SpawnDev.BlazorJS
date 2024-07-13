using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Map object holds key-value pairs and remembers the original insertion order of the keys. Any value (both objects and primitive values) may be used as either a key or a value.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Map
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class MapReadOnly<TKey, TValue> : JSObject
    {
        #region Constructors
        public MapReadOnly(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the number of key/value pairs in the Map object.
        /// </summary>
        public int Size => JSRef!.Get<int>("size");
        #endregion

        #region Methods
        /// <summary>
        /// Returns a new Iterator object that contains a two-member array of [key, value] for each element in the Map object in insertion order.
        /// </summary>
        /// <returns></returns>
        public Iterator<Array> Entries() => JSRef!.Call<Iterator<Array>>("entries");
        /// <summary>
        /// Calls callbackFn once for each key-value pair present in the Map object, in insertion order. If a thisArg parameter is provided to forEach, it will be used as the this value for each callback.
        /// </summary>
        public void ForEach(ActionCallback<TValue, TKey, Map<TKey, TValue>> callbackFn) => JSRef!.CallVoid("forEach", callbackFn);
        /// <summary>
        /// Returns the value associated to the passed key, or undefined if there is none.
        /// </summary>
        public TValue? Get(TKey key) => JSRef!.Call<TValue?>("get", key);
        /// <summary>
        /// Returns a boolean indicating whether a value has been associated with the passed key in the Map object or not.
        /// </summary>
        /// <returns></returns>
        public bool Has(TKey key) => JSRef!.Call<bool>("has", key);
        /// <summary>
        /// Returns a new Iterator object that contains the keys for each element in the Map object in insertion order.
        /// </summary>
        public Iterator<TKey> Keys() => JSRef!.Call<Iterator<TKey>>("keys");
        /// <summary>
        /// Returns a new Iterator object that contains the values for each element in the Map object in insertion order.
        /// </summary>
        /// <returns></returns>
        public Iterator<TValue> Values() => JSRef!.Call<Iterator<TValue>>("values");
        #endregion

        #region Events
        #endregion
    }
    /// <summary>
    /// The Map object holds key-value pairs and remembers the original insertion order of the keys. Any value (both objects and primitive values) may be used as either a key or a value.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Map
    /// </summary>
    public class MapReadOnly : JSObject
    {
        #region Constructors
        public MapReadOnly(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the number of key/value pairs in the Map object.
        /// </summary>
        public int Size => JSRef!.Get<int>("size");
        #endregion

        #region Methods
        /// <summary>
        /// Returns a new Iterator object that contains a two-member array of [key, value] for each element in the Map object in insertion order.
        /// </summary>
        /// <returns></returns>
        public Iterator<Array> Entries() => JSRef!.Call<Iterator<Array>>("entries");
        /// <summary>
        /// Calls callbackFn once for each key-value pair present in the Map object, in insertion order. If a thisArg parameter is provided to forEach, it will be used as the this value for each callback.
        /// </summary>
        public void ForEach<TKey, TValue>(ActionCallback<TValue, TKey, Map<TKey, TValue>> callbackFn) => JSRef!.CallVoid("forEach", callbackFn);
        /// <summary>
        /// Returns the value associated to the passed key, or undefined if there is none.
        /// </summary>
        public TValue? Get<TKey, TValue>(TKey key) => JSRef!.Call<TValue?>("get", key);
        /// <summary>
        /// Returns a boolean indicating whether a value has been associated with the passed key in the Map object or not.
        /// </summary>
        /// <returns></returns>
        public bool Has<TKey>(TKey key) => JSRef!.Call<bool>("has", key);
        /// <summary>
        /// Returns a new Iterator object that contains the keys for each element in the Map object in insertion order.
        /// </summary>
        public Iterator<TKey> Keys<TKey>() => JSRef!.Call<Iterator<TKey>>("keys");
        /// <summary>
        /// Returns a new Iterator object that contains the values for each element in the Map object in insertion order.
        /// </summary>
        /// <returns></returns>
        public Iterator<TValue> Values<TValue>() => JSRef!.Call<Iterator<TValue>>("values");
        #endregion

        #region Events
        #endregion
    }
}
