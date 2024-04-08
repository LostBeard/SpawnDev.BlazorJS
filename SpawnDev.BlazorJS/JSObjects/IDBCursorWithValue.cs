using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The IDBCursorWithValue interface of the IndexedDB API represents a cursor for traversing or iterating over multiple records in a database. It is the same as the IDBCursor, except that it includes the value property.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBCursorWithValue
    /// </summary>
    public class IDBCursorWithValue<TKey, TPrimaryKey, TValue> : IDBCursor<TKey, TPrimaryKey, TValue>
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBCursorWithValue(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the value of the current cursor.
        /// </summary>
        public TValue Value => JSRef!.Get<TValue>("value");
        /// <summary>
        /// Returns the value of the current cursor.
        /// </summary>
        public TValueAlt ValueAs<TValueAlt>() => JSRef!.Get<TValueAlt>("value");
    }
}
