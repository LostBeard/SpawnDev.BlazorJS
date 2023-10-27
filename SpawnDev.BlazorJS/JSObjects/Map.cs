using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Map object holds key-value pairs and remembers the original insertion order of the keys. Any value (both objects and primitive values) may be used as either a key or a value.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Map
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class Map<TKey, TValue> : MapReadOnly<TKey, TValue>
    {
        #region Constructors
        public Map() : base(JS.New("Map")) { }
        public Map(Array iterable) : base(JS.New("Map", iterable)) { }
        public Map(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        #endregion

        #region Methods
        /// <summary>
        /// Removes all key-value pairs from the Map object.
        /// </summary>
        public void Clear() => JSRef.CallVoid("clear");
        /// <summary>
        /// Returns true if an element in the Map object existed and has been removed, or false if the element does not exist. map.has(key) will return false afterwards.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Delete(TKey key) => JSRef.Call<bool>("delete");
        /// <summary>
        /// Sets the value for the passed key in the Map object. Returns the Map object.
        /// </summary>
        public Map<TKey, TValue> Set(TKey key, TValue value) => JSRef.Call<Map<TKey, TValue>>("set", key, value);
        #endregion

        #region Events
        #endregion
    }
    /// <summary>
    /// The Map object holds key-value pairs and remembers the original insertion order of the keys. Any value (both objects and primitive values) may be used as either a key or a value.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Map
    /// </summary>
    public class Map : MapReadOnly
    {
        #region Constructors
        public Map() : base(JS.New("Map")) { }
        public Map(Array iterable) : base(JS.New("Map", iterable)) { }
        public Map(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        #endregion

        #region Methods
        /// <summary>
        /// Removes all key-value pairs from the Map object.
        /// </summary>
        public void Clear() => JSRef.CallVoid("clear");
        /// <summary>
        /// Returns true if an element in the Map object existed and has been removed, or false if the element does not exist. map.has(key) will return false afterwards.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Delete<TKey>(TKey key) => JSRef.Call<bool>("delete");
        /// <summary>
        /// Sets the value for the passed key in the Map object. Returns the Map object.
        /// </summary>
        public Map<TKey, TValue> Set<TKey, TValue>(TKey key, TValue value) => JSRef.Call<Map<TKey, TValue>>("set", key, value);
        #endregion

        #region Events
        #endregion
    }
}
