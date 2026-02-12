using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Set
    /// </summary>
    public class Set : JSObject
    {
        #region Constructors
        /// <inheritdoc/>
        public Set(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public Set() : base(JS.New("Set")) { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="iterable"></param>
        public Set(Array iterable) : base(JS.New("Set", iterable)) { }
        #endregion
        #region Properties
        /// <summary>
        /// The size accessor property of Set instances returns the number of (unique) elements in this set.
        /// </summary>
        public int Size => JSRef!.Get<int>("size");
        /// <summary>
        /// Returns true if the clear method is not found indicating this is a read-only Set.<br/>
        /// Read-only Set-like objects have the property size, and the methods: entries(), forEach(), has(), keys(), values(), and Symbol.iterator().<br/>
        /// Writeable Set-like objects additionally have the methods: clear(), delete(), and add().<br/>
        /// </summary>
        public bool ReadOnly => JSRef!.IsUndefined("clear");
        #endregion
        #region Methods
        /// <summary>
        /// The clear() method of Set instances removes all elements from this set.
        /// </summary>
        public void Clear() => JSRef!.CallVoid("clear");
        /// <summary>
        /// The add() method of Set instances inserts a new element with a specified value in to this set, if there isn't an element with the same value already in this set
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Set<TValue> Add<TValue>(TValue value) => JSRef!.Call<Set<TValue>>("add", value);
        /// <summary>
        /// The delete() method of Set instances removes a specified value from this set, if it is in the set.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Delete<TValue>(TValue value) => JSRef!.Call<bool>("delete", value);
        /// <summary>
        /// Returns a new iterator object that contains an array of [value, value] for each element in the Set object, in insertion order. This is similar to the Map object, so that each entry's key is the same as its value for a Set.
        /// </summary>
        /// <returns></returns>
        public Iterator<Array<TValue>> Entries<TValue>() => JSRef!.Call<Iterator<Array<TValue>>>("entries");
        /// <summary>
        /// Calls callbackFn once for each value present in the Set object, in insertion order. If a thisArg parameter is provided, it will be used as the this value for each invocation of callbackFn.
        /// </summary>
        /// <param name="callbackFn"></param>
        public void ForEach<TValue>(ActionCallback<TValue, TValue, Set<TValue>> callbackFn) => JSRef!.CallVoid("forEach", callbackFn);
        /// <summary>
        /// Calls callbackFn once for each value present in the Set object, in insertion order. If a thisArg parameter is provided, it will be used as the this value for each invocation of callbackFn.
        /// </summary>
        /// <param name="callbackFn"></param>
        /// <param name="thisArg"></param>
        public void ForEach<TValue>(ActionCallback<TValue, TValue, Set<TValue>> callbackFn, JSObject thisArg) => JSRef!.CallVoid("forEach", callbackFn, thisArg);
        /// <summary>
        /// Returns a boolean asserting whether an element is present with the given value in the Set object or not.
        /// </summary>
        public bool Has<TValue>(TValue value) => JSRef!.Call<bool>("has", value);
        /// <summary>
        /// An alias for Set.prototype.values().
        /// </summary>
        public Iterator<TValue> Keys<TValue>() => JSRef!.Call<Iterator<TValue>>("keys");
        /// <summary>
        /// Returns a new iterator object that yields the values for each element in the Set object in insertion order.
        /// </summary>
        public Iterator<TValue> Values<TValue>() => JSRef!.Call<Iterator<TValue>>("values");
        /// <summary>
        /// The difference() method of Set instances takes a set and returns a new set containing elements in this set but not in the given set.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="other"></param>
        /// <returns>A new Set object containing elements in this set but not in the other set.</returns>
        public Set<TValue> Difference<TValue>(Set other) => JSRef!.Call<Set<TValue>>("difference", other);
        /// <summary>
        /// The intersection() method of Set instances takes a set and returns a new set containing elements in both this set and the given set.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="other"></param>
        /// <returns></returns>
        public Set<TValue> Intersection<TValue>(Set other) => JSRef!.Call<Set<TValue>>("intersection", other);
        /// <summary>
        /// The symmetricDifference() method of Set instances takes a set and returns a new set containing elements which are in either this set or the given set, but not in both.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="other"></param>
        /// <returns></returns>
        public Set<TValue> SymmetricDifference<TValue>(Set other) => JSRef!.Call<Set<TValue>>("symmetricDifference", other);
        /// <summary>
        /// The union() method of Set instances takes a set and returns a new set containing elements which are in either or both of this set and the given set.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="other"></param>
        /// <returns></returns>
        public Set<TValue> Union<TValue>(Set other) => JSRef!.Call<Set<TValue>>("union", other);
        /// <summary>
        /// The isDisjointFrom() method of Set instances takes a set and returns a boolean indicating if this set has no elements in common with the given set.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsDisjointedFrom(Set other) => JSRef!.Call<bool>("isDisjointedFrom", other);
        /// <summary>
        /// The isSubsetOf() method of Set instances takes a set and returns a boolean indicating if all elements of this set are in the given set.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsSubsetOf(Set other) => JSRef!.Call<bool>("isSubsetOf", other);
        /// <summary>
        /// The isSupersetOf() method of Set instances takes a set and returns a boolean indicating if all elements of the given set are in this set.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsSupersetOf(Set other) => JSRef!.Call<bool>("isSupersetOf", other);
        #endregion
    }

    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Set
    /// </summary>
    public class Set<TValue> : Set
    {
        #region Constructors
        /// <inheritdoc/>
        public Set(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public Set() : base(JS.New("Set")) { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public Set(Array iterable) : base(JS.New("Set", iterable)) { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public Set(Array<TValue> iterable) : base(JS.New("Set", iterable)) { }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public Set(IEnumerable<TValue> iterable) : base(JS.New("Set", iterable)) { }
        #endregion

        #region Methods
        /// <summary>
        /// The add() method of Set instances inserts a new element with a specified value in to this set, if there isn't an element with the same value already in this set
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Set<TValue> Add(TValue value) => JSRef!.Call<Set<TValue>>("add", value);
        /// <summary>
        /// The delete() method of Set instances removes a specified value from this set, if it is in the set.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Delete(TValue value) => JSRef!.Call<bool>("delete", value);
        /// <summary>
        /// Returns a new iterator object that contains an array of [value, value] for each element in the Set object, in insertion order. This is similar to the Map object, so that each entry's key is the same as its value for a Set.
        /// </summary>
        /// <returns></returns>
        public Iterator<Array<TValue>> Entries() => JSRef!.Call<Iterator<Array<TValue>>>("entries");
        /// <summary>
        /// Calls callbackFn once for each value present in the Set object, in insertion order. If a thisArg parameter is provided, it will be used as the this value for each invocation of callbackFn.
        /// </summary>
        /// <param name="callbackFn"></param>
        public void ForEach(ActionCallback<TValue, TValue, Set<TValue>> callbackFn) => JSRef!.CallVoid("forEach", callbackFn);
        /// <summary>
        /// Calls callbackFn once for each value present in the Set object, in insertion order. If a thisArg parameter is provided, it will be used as the this value for each invocation of callbackFn.
        /// </summary>
        /// <param name="callbackFn"></param>
        /// <param name="thisArg"></param>
        public void ForEach(ActionCallback<TValue, TValue, Set<TValue>> callbackFn, JSObject thisArg) => JSRef!.CallVoid("forEach", callbackFn, thisArg);
        /// <summary>
        /// Returns a boolean asserting whether an element is present with the given value in the Set object or not.
        /// </summary>
        public bool Has(TValue value) => JSRef!.Call<bool>("has", value);
        /// <summary>
        /// An alias for Set.prototype.values().
        /// </summary>
        public Iterator<TValue> Keys() => JSRef!.Call<Iterator<TValue>>("keys");
        /// <summary>
        /// Returns a new iterator object that yields the values for each element in the Set object in insertion order.
        /// </summary>
        public Iterator<TValue> Values() => JSRef!.Call<Iterator<TValue>>("values");
        /// <summary>
        /// The difference() method of Set instances takes a set and returns a new set containing elements in this set but not in the given set.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>A new Set object containing elements in this set but not in the other set.</returns>
        public Set<TValue> Difference(Set other) => JSRef!.Call<Set<TValue>>("difference", other);
        /// <summary>
        /// The intersection() method of Set instances takes a set and returns a new set containing elements in both this set and the given set.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Set<TValue> Intersection(Set other) => JSRef!.Call<Set<TValue>>("intersection", other);
        /// <summary>
        /// The symmetricDifference() method of Set instances takes a set and returns a new set containing elements which are in either this set or the given set, but not in both.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Set<TValue> SymmetricDifference(Set other) => JSRef!.Call<Set<TValue>>("symmetricDifference", other);
        /// <summary>
        /// The union() method of Set instances takes a set and returns a new set containing elements which are in either or both of this set and the given set.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Set<TValue> Union(Set other) => JSRef!.Call<Set<TValue>>("union", other);
        #endregion
    }
}
