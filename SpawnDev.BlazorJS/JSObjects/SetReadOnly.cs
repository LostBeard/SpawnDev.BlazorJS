using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class SetReadOnly : JSObject
    {
        #region Constructors
        public SetReadOnly(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        public int Size => JSRef.Get<int>("size");
        #endregion

        #region Methods
        /// <summary>
        /// Returns a new iterator object that contains an array of [value, value] for each element in the Set object, in insertion order. This is similar to the Map object, so that each entry's key is the same as its value for a Set.
        /// </summary>
        /// <returns></returns>
        public Iterator<Array<TValue>> Entries<TValue>() => JSRef.Call<Iterator<Array<TValue>>>("entries");
        /// <summary>
        /// Calls callbackFn once for each value present in the Set object, in insertion order. If a thisArg parameter is provided, it will be used as the this value for each invocation of callbackFn.
        /// </summary>
        /// <param name="callbackFn"></param>
        public void ForEach<TValue>(ActionCallback<TValue, TValue, Set<TValue>> callbackFn) => JSRef.CallVoid("forEach", callbackFn);
        /// <summary>
        /// Calls callbackFn once for each value present in the Set object, in insertion order. If a thisArg parameter is provided, it will be used as the this value for each invocation of callbackFn.
        /// </summary>
        /// <param name="callbackFn"></param>
        /// <param name="thisArg"></param>
        public void ForEach<TValue>(ActionCallback<TValue, TValue, Set<TValue>> callbackFn, JSObject thisArg) => JSRef.CallVoid("forEach", callbackFn, thisArg);
        /// <summary>
        /// Returns a boolean asserting whether an element is present with the given value in the Set object or not.
        /// </summary>
        public bool Has<TValue>(TValue value) => JSRef.Call<bool>("has", value);
        /// <summary>
        /// An alias for Set.prototype.values().
        /// </summary>
        public Iterator<TValue> Keys<TValue>() => JSRef.Call<Iterator<TValue>>("keys");
        /// <summary>
        /// Returns a new iterator object that yields the values for each element in the Set object in insertion order.
        /// </summary>
        public Iterator<TValue> Values<TValue>() => JSRef.Call<Iterator<TValue>>("values");
        #endregion

        #region Events
        // Existing
        // New
        #endregion
    }
    public class SetReadOnly<TValue> : JSObject
    {
        #region Constructors
        public SetReadOnly(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        public int Size => JSRef.Get<int>("size");
        #endregion

        #region Methods
        /// <summary>
        /// Returns a new iterator object that contains an array of [value, value] for each element in the Set object, in insertion order. This is similar to the Map object, so that each entry's key is the same as its value for a Set.
        /// </summary>
        /// <returns></returns>
        public Iterator<Array<TValue>> Entries() => JSRef.Call<Iterator<Array<TValue>>>("entries");
        /// <summary>
        /// Calls callbackFn once for each value present in the Set object, in insertion order. If a thisArg parameter is provided, it will be used as the this value for each invocation of callbackFn.
        /// </summary>
        /// <param name="callbackFn"></param>
        public void ForEach(ActionCallback<TValue, TValue, Set<TValue>> callbackFn) => JSRef.CallVoid("forEach", callbackFn);
        /// <summary>
        /// Calls callbackFn once for each value present in the Set object, in insertion order. If a thisArg parameter is provided, it will be used as the this value for each invocation of callbackFn.
        /// </summary>
        /// <param name="callbackFn"></param>
        /// <param name="thisArg"></param>
        public void ForEach(ActionCallback<TValue, TValue, Set<TValue>> callbackFn, JSObject thisArg) => JSRef.CallVoid("forEach", callbackFn, thisArg);
        /// <summary>
        /// Returns a boolean asserting whether an element is present with the given value in the Set object or not.
        /// </summary>
        public bool Has(TValue value) => JSRef.Call<bool>("has", value);
        /// <summary>
        /// An alias for Set.prototype.values().
        /// </summary>
        public Iterator<TValue> Keys() => JSRef.Call<Iterator<TValue>>("keys");
        /// <summary>
        /// Returns a new iterator object that yields the values for each element in the Set object in insertion order.
        /// </summary>
        public Iterator<TValue> Values() => JSRef.Call<Iterator<TValue>>("values");
        #endregion

        #region Events
        // Existing
        // New
        #endregion
    }
}
