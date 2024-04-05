using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The IDBCursor interface of the IndexedDB API represents a cursor for traversing or iterating over multiple records in a database.<br />
    /// The cursor has a source that indicates which index or object store it is iterating over. It has a position within the range, and moves in a direction that is increasing or decreasing in the order of record keys. The cursor enables an application to asynchronously process all the records in the cursor's range.<br />
    /// You can have an unlimited number of cursors at the same time. You always get the same IDBCursor object representing a given cursor. Operations are performed on the underlying index or object store.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBCursor
    /// </summary>
    public class IDBCursor<TKey, TValue> : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBCursor(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the IDBObjectStore or IDBIndex that the cursor is iterating. This function never returns null or throws an exception, even if the cursor is currently being iterated, has iterated past its end, or its transaction is not active.
        /// </summary>
        public Union<IDBObjectStore<TKey, TValue>, IDBIndex<TKey, TValue>> Source => JSRef!.Get<Union<IDBObjectStore<TKey, TValue>, IDBIndex<TKey, TValue>>>("source");
        /// <summary>
        /// Returns the direction of traversal of the cursor. 
        /// </summary>
        public string Direction => JSRef!.Get<string>("direction");
        /// <summary>
        /// Returns the key for the record at the cursor's position. If the cursor is outside its range, this is set to undefined. The cursor's key can be any data type.
        /// </summary>
        public TKey Key => JSRef!.Get<TKey>("key");
        /// <summary>
        /// Returns the cursor's current effective primary key. If the cursor is currently being iterated or has iterated outside its range, this is set to undefined. The cursor's primary key can be any data type.
        /// </summary>
        public TKey PrimaryKey => JSRef!.Get<TKey>("primaryKey");
        /// <summary>
        /// Returns true if done. (non-spec)
        /// </summary>
        public Task<bool> IsDone() => Request.UsingAsync(async r => r == null || await r.WaitAsync() == null);
        /// <summary>
        /// Returns the IDBRequest that was used to obtain the cursor.
        /// </summary>
        public IDBRequest<IDBCursor<TKey, TValue>> Request => JSRef!.Get<IDBRequest<IDBCursor<TKey, TValue>>>("request");
        /// <summary>
        /// Sets the number of times a cursor should move its position forward.
        /// </summary>
        /// <param name="count">The number of times to move the cursor forward.</param>
        public void Advance(int count) => JSRef!.CallVoid("advance", count);
        /// <summary>
        /// Sets the number of times a cursor should move its position forward.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<bool> AdvanceAsync(int count)
        {
            Advance(count);
            using var cursor = await Request.WaitAsync();
            return cursor != null;
        }
        /// <summary>
        /// Advances the cursor to the next position along its direction, to the item whose key matches the optional key parameter.
        /// </summary>
        /// <param name="key">The key to position the cursor at.</param>
        public void Continue(TKey key) => JSRef!.CallVoid("continue", key);
        /// <summary>
        /// Advances the cursor to the next position along its direction, to the item whose key matches the optional key parameter.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<bool> ContinueAsync(TKey key)
        {
            Continue(key);
            using var cursor = await Request.WaitAsync();
            return cursor != null;
        }
        /// <summary>
        /// Advances the cursor to the next position along its direction, to the item whose key matches the optional key parameter.
        /// </summary>
        public void Continue() => JSRef!.CallVoid("continue");
        /// <summary>
        /// Advances the cursor to the next position along its direction, to the item whose key matches the optional key parameter.<br />
        /// </summary>
        /// <returns>returns true if there is data</returns>
        public async Task<bool> ContinueAsync()
        {
            Continue();
            using var cursor = await Request.WaitAsync();
            return cursor != null;
        }
        /// <summary>
        /// Sets the cursor to the given index key and primary key given as arguments.
        /// </summary>
        /// <param name="key">The key to position the cursor at.</param>
        /// <param name="primaryKey">The primary key to position the cursor at.</param>
        public void ContinuePrimaryKey(TKey key, TKey primaryKey) => JSRef!.CallVoid("continuePrimaryKey", key, primaryKey);
        /// <summary>
        /// Sets the cursor to the given index key and primary key given as arguments.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public async Task<bool> ContinuePrimaryKeyAsync(TKey key, TKey primaryKey)
        {
            ContinuePrimaryKey(key, primaryKey);
            using var cursor = await Request.WaitAsync();
            return cursor != null;
        }
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, deletes the record at the cursor's position, without changing the cursor's position. This can be used to delete specific records.
        /// </summary>
        public void Delete() => JSRef!.CallVoid("delete");
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, updates the value at the current position of the cursor in the object store. This can be used to update specific records.
        /// </summary>
        /// <param name="value">The new value to be stored at the current position.</param>
        /// <returns>An IDBRequest object on which subsequent events related to this operation are fired.</returns>
        public IDBRequest<TKey> Update(TValue value) => JSRef!.Call<IDBRequest<TKey>>("update", value);
        /// <summary>
        /// Updates the value at the current position of the cursor in the object store. This can be used to update specific records.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<TKey> UpdateAsync(TValue value) => JSRef!.Call<IDBRequest<TKey>>("update", value).WaitAsync();
    }
}
