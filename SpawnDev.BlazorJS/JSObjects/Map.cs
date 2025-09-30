using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <inheritdoc/>
    [Obsolete("Use Map")]
    public class  MapReadOnly : Map
    {
        /// <inheritdoc/>
        public MapReadOnly(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
    /// <summary>
    /// The Map object holds key-value pairs and remembers the original insertion order of the keys. Any value (both objects and primitive values) may be used as either a key or a value.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Map
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class Map<TKey, TValue> : Map
    {
        #region Constructors
        /// <inheritdoc/>
        public Map(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public Map() : base(JS.New("Map")) { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public Map(IEnumerable<(TKey, TValue)> iterable) : base(JS.New("Map", iterable)) { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public Map(Dictionary<TKey, TValue> iterable) : base(JS.New("Map", iterable)) { }
        #endregion
        #region Methods
        /// <summary>
        /// Returns true if an element in the Map object existed and has been removed, or false if the element does not exist. map.has(key) will return false afterwards.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Delete(TKey key) => JSRef!.Call<bool>("delete");
        /// <summary>
        /// Sets the value for the passed key in the Map object. Returns the Map object.
        /// </summary>
        public Map<TKey, TValue> Set(TKey key, TValue value) => JSRef!.Call<Map<TKey, TValue>>("set", key, value);
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
    }
    /// <summary>
    /// The Map object holds key-value pairs and remembers the original insertion order of the keys. Any value (both objects and primitive values) may be used as either a key or a value.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Map
    /// </summary>
    public class Map : JSObject
    {
        #region Constructors
        /// <inheritdoc/>
        public Map(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public Map() : base(JS.New("Map")) { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public Map(Array iterable) : base(JS.New("Map", iterable)) { }
        #endregion
        #region Properties
        /// <summary>
        /// Returns the number of key/value pairs in the Map object.
        /// </summary>
        public int Size => JSRef!.Get<int>("size");
        /// <summary>
        /// Returns true if the clear method is not found indicating this is a read-only Map.<br/>
        /// Read-only Map-like objects have the property size, and the methods: entries(), forEach(), get(), has(), keys(), values(), and Symbol.iterator().<br/>
        /// Writeable Map-like objects additionally have the methods: clear(), delete(), and set().<br/>
        /// </summary>
        public bool ReadOnly => JSRef!.IsUndefined("clear");
        #endregion
        #region Methods
        /// <summary>
        /// Removes all key-value pairs from the Map object.
        /// </summary>
        public void Clear() => JSRef!.CallVoid("clear");
        /// <summary>
        /// Returns true if an element in the Map object existed and has been removed, or false if the element does not exist. map.has(key) will return false afterwards.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Delete<TKey>(TKey key) => JSRef!.Call<bool>("delete");
        /// <summary>
        /// Sets the value for the passed key in the Map object. Returns the Map object.
        /// </summary>
        public Map<TKey, TValue> Set<TKey, TValue>(TKey key, TValue value) => JSRef!.Call<Map<TKey, TValue>>("set", key, value);
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
    }
}
