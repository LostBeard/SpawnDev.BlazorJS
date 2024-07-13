using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Set : SetReadOnly
    {
        #region Constructors
        public Set() : base(JS.New("Map")) { }
        public Set(Array iterable) : base(JS.New("Map", iterable)) { }
        public Set(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        #endregion

        #region Methods
        /// <summary>
        /// The add() method of Set instances inserts a new element with a specified value in to this set, if there isn't an element with the same value already in this set
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Set<TValue> Add<TValue>(TValue value) => JSRef!.Call<Set<TValue>>("add", value);
        /// <summary>
        /// The clear() method of Set instances removes all elements from this set.
        /// </summary>
        public void Clear() => JSRef!.CallVoid("clear");
        /// <summary>
        /// The delete() method of Set instances removes a specified value from this set, if it is in the set.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Delete<TValue>(TValue value) => JSRef!.Call<bool>("delete", value);
        #endregion

        #region Events
        // Existing
        // New
        #endregion
    }
    public class Set<TValue> : SetReadOnly<TValue>
    {
        #region Constructors
        public Set() : base(JS.New("Map")) { }
        public Set(Array iterable) : base(JS.New("Map", iterable)) { }
        public Set(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        #endregion

        #region Methods
        /// <summary>
        /// The add() method of Set instances inserts a new element with a specified value in to this set, if there isn't an element with the same value already in this set
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Set<TValue> Add(TValue value) => JSRef!.Call<Set<TValue>>("add", value);
        /// <summary>
        /// The clear() method of Set instances removes all elements from this set.
        /// </summary>
        public void Clear() => JSRef!.CallVoid("clear");
        /// <summary>
        /// The delete() method of Set instances removes a specified value from this set, if it is in the set.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Delete(TValue value) => JSRef!.Call<bool>("delete", value);
        #endregion

        #region Events
        #endregion
    }
    
}
