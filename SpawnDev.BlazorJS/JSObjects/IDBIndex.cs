using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// IDBIndex interface of the IndexedDB API provides asynchronous access to an index in a database. An index is a kind of object store for looking up records in another object store, called the referenced object store. You use this interface to retrieve data.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBIndex<br />
    /// https://w3c.github.io/IndexedDB/#index-interface
    /// </summary>
    /// <typeparam name="TIndexKey">The key type for this index</typeparam>
    /// <typeparam name="TPrimaryKey">The key path type of the object store referenced by this index</typeparam>
    /// <typeparam name="TValue">The object store value type</typeparam>
    public class IDBIndex<TIndexKey, TPrimaryKey, TValue> : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBIndex(IJSInProcessObjectReference _ref) : base(_ref) { }
        #region Properties
        /// <summary>
        /// The name of this index.
        /// </summary>
        public string Name { get => JSRef!.Get<string>("name"); set => JSRef!.Set("name", value); }
        /// <summary>
        /// The ObjectStore referenced by this index.
        /// </summary>
        /// <returns></returns>
        public IDBObjectStore<TPrimaryKey, TValue> ObjectStore => JSRef!.Get<IDBObjectStore<TPrimaryKey, TValue>>("objectStore");
        /// <summary>
        /// The key path of this index. If null, this index is not auto-populated.
        /// </summary>
        public Union<string, string[]>? KeyPath => JSRef!.Get<Union<string, string[]>?>("keyPath");
        /// <summary>
        /// Affects how the index behaves when the result of evaluating the index's key path yields an array. If true, there is one record in the index for each item in an array of keys. If false, then there is one record for each key that is an array.
        /// </summary>
        public bool MultiEntry => JSRef!.Get<bool>("multiEntry");
        /// <summary>
        /// If true, this index does not allow duplicate values for a key.
        /// </summary>
        public bool Unique => JSRef!.Get<bool>("unique");
        #endregion
        #region Methods
        /// <summary>
        /// Returns an IDBRequest object, and in a separate thread, returns the number of records within a key range.
        /// </summary>
        /// <param name="key">The key or key range that identifies the record to be counted.</param>
        /// <returns>A IDBRequest object on which subsequent events related to this operation are fired.</returns>
        public IDBRequest<int> Count(Union<IDBKeyRange<TIndexKey>, TIndexKey>? key = null) => JSRef!.Call<IDBRequest<int>>("count", key);
        /// <summary>
        /// returns the number of records within a key range.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<int> CountAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? key = null) => JSRef!.Call<IDBRequest<int>>("count", key).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, finds either the value in the referenced object store that corresponds to the given key or the first corresponding value, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="key">A key or IDBKeyRange that identifies the record to be retrieved. If this value is null or missing, the browser will use an unbound key range.</param>
        /// <returns>An IDBRequest object on which subsequent events related to this operation are fired.</returns>
        public IDBRequest Get(Union<IDBKeyRange<TIndexKey>, TIndexKey> key) => JSRef!.Call<IDBRequest>("get", key);
        /// <summary>
        /// Returns the IDBRequest result of the get request<br />
        /// throws an exception if not found
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<TValue> GetAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey> key) => JSRef!.Call<IDBRequest<TValue>>("get", key).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, finds either the given key or the primary key, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="key">A key or IDBKeyRange that identifies a record to be retrieved. If this value is null or missing, the browser will use an unbound key range.</param>
        /// <returns>An IDBRequest object on which subsequent events related to this operation are fired.</returns>
        public IDBRequest<TIndexKey> GetKey(Union<IDBKeyRange<TIndexKey>, TIndexKey>? key = null) => JSRef!.Call<IDBRequest<TIndexKey>>("getKey", key);
        /// <summary>
        /// Returns either the given key or the primary key, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<TIndexKey> GetKeyAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? key = null) => JSRef!.Call<IDBRequest<TIndexKey>>("getKey", key).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, in a separate thread, finds all matching values in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="query">A key or an IDBKeyRange identifying the records to retrieve. If this value is null or missing, the browser will use an unbound key range.</param>
        /// <param name="count">The number of records to return. If this value exceeds the number of records in the query, the browser will only retrieve the queried records. If it is lower than 0 or greater than 2^32 - 1 a TypeError exception will be thrown.</param>
        /// <returns>An IDBRequest object on which subsequent events related to this operation are fired.</returns>
        public IDBRequest<Array<TValue>> GetAll(Union<IDBKeyRange<TIndexKey>, TIndexKey>? query, int count) => JSRef!.Call<IDBRequest<Array<TValue>>>("getAll", query, count);
        /// <summary>
        /// Returns all matching values in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public Task<Array<TValue>> GetAllAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? query, int count) => JSRef!.Call<IDBRequest<Array<TValue>>>("getAll", query, count).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, in a separate thread, finds all matching values in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="query">A key or an IDBKeyRange identifying the records to retrieve. If this value is null or missing, the browser will use an unbound key range.</param>
        /// <returns></returns>
        public IDBRequest<Array<TValue>> GetAll(Union<IDBKeyRange<TIndexKey>, TIndexKey>? query = null) => JSRef!.Call<IDBRequest<Array<TValue>>>("getAll", query);
        /// <summary>
        /// Returns all matching values in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<Array<TValue>> GetAllAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? query = null) => JSRef!.Call<IDBRequest<Array<TValue>>>("getAll", query).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, in a separate thread, finds all matching keys in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="query">A key or an IDBKeyRange identifying the keys to retrieve. If this value is null or missing, the browser will use an unbound key range.</param>
        /// <param name="count">The number records to return. If this value exceeds the number of records in the query, the browser will only retrieve the first item. If it is lower than 0 or greater than 2^32 - 1 a TypeError exception will be thrown.</param>
        /// <returns>An IDBRequest object on which subsequent events related to this operation are fired.</returns>
        public IDBRequest<TIndexKey[]> GetAllKeys(Union<IDBKeyRange<TIndexKey>, TIndexKey>? query, int count) => JSRef!.Call<IDBRequest<TIndexKey[]>>("getAllKeys", query, count);
        /// <summary>
        /// Returns all matching keys in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public Task<TIndexKey[]> GetAllKeysAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? query, int count) => JSRef!.Call<IDBRequest<TIndexKey[]>>("getAllKeys", query, count).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, in a separate thread, finds all matching keys in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="query">A key or an IDBKeyRange identifying the keys to retrieve. If this value is null or missing, the browser will use an unbound key range.</param>
        /// <returns>An IDBRequest object on which subsequent events related to this operation are fired.</returns>
        public IDBRequest<TIndexKey[]> GetAllKeys(Union<IDBKeyRange<TIndexKey>, TIndexKey>? query = null) => JSRef!.Call<IDBRequest<TIndexKey[]>>("getAllKeys", query);
        /// <summary>
        /// Returns all matching keys in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<TIndexKey[]> GetAllKeysAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? query = null) => JSRef!.Call<IDBRequest<TIndexKey[]>>("getAllKeys", query).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range.
        /// </summary>
        /// <returns></returns>
        public IDBRequest<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>> OpenCursor() => JSRef!.Call<IDBRequest<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>>>("openCursor");
        /// <summary>
        /// Creates a cursor over the specified key range.
        /// </summary>
        /// <returns></returns>
        public Task<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>> OpenCursorAsync() => JSRef!.Call<IDBRequest<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>>>("openCursor").WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range.
        /// </summary>
        /// <param name="range">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <returns></returns>
        public IDBRequest<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>> OpenCursor(Union<IDBKeyRange<TIndexKey>, TIndexKey>? range) => JSRef!.Call<IDBRequest<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>>>("openCursor", range);
        /// <summary>
        /// Creates a cursor over the specified key range.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Task<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>> OpenCursorAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? range) => JSRef!.Call<IDBRequest<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>>>("openCursor", range).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range.
        /// </summary>
        /// <param name="range">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <param name="direction">
        /// A string telling the cursor which direction to travel. The default is next. Valid values are:<br />
        /// "next" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the increasing order of keys.<br />
        /// "nextunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the increasing order of keys.<br />
        /// "prev" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the decreasing order of keys.<br />
        /// "prevunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the decreasing order of keys.<br />
        /// </param>
        /// <returns></returns>
        public IDBRequest<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>> OpenCursor(Union<IDBKeyRange<TIndexKey>, TIndexKey>? range, string direction) => JSRef!.Call<IDBRequest<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>>>("openCursor", range, direction);
        /// <summary>
        /// Creates a cursor over the specified key range.
        /// </summary>
        /// <param name="range">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <param name="direction">
        /// A string telling the cursor which direction to travel. The default is next. Valid values are:<br />
        /// "next" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the increasing order of keys.<br />
        /// "nextunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the increasing order of keys.<br />
        /// "prev" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the decreasing order of keys.<br />
        /// "prevunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the decreasing order of keys.<br />
        /// </param>
        /// <returns></returns>
        public Task<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>> OpenCursorAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? range, string direction) => JSRef!.Call<IDBRequest<IDBCursorWithValue<TIndexKey, TPrimaryKey, TValue>>>("openCursor", range, direction).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <param name="range">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <param name="direction">
        /// A string telling the cursor which direction to travel. The default is next. Valid values are:<br />
        /// "next" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the increasing order of keys.<br />
        /// "nextunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the increasing order of keys.<br />
        /// "prev" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the decreasing order of keys.<br />
        /// "prevunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the decreasing order of keys.<br />
        /// </param>
        /// <returns></returns>
        public IDBRequest<IDBCursor<TIndexKey, TPrimaryKey, TValue>> OpenKeyCursor(Union<IDBKeyRange<TIndexKey>, TIndexKey>? range, string direction) => JSRef!.Call<IDBRequest<IDBCursor<TIndexKey, TPrimaryKey, TValue>>>("openKeyCursor", range, direction);
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <param name="range">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <param name="direction">
        /// A string telling the cursor which direction to travel. The default is next. Valid values are:<br />
        /// "next" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the increasing order of keys.<br />
        /// "nextunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the increasing order of keys.<br />
        /// "prev" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the decreasing order of keys.<br />
        /// "prevunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the decreasing order of keys.<br />
        /// </param>
        /// <returns></returns>
        public Task<IDBCursor<TIndexKey, TPrimaryKey, TValue>> OpenKeyCursorAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? range, string direction) => JSRef!.Call<IDBRequest<IDBCursor<TIndexKey, TPrimaryKey, TValue>>>("openKeyCursor", range, direction).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <param name="range">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <returns></returns>
        public IDBRequest<IDBCursor<TIndexKey, TPrimaryKey, TValue>> OpenKeyCursor(Union<IDBKeyRange<TIndexKey>, TIndexKey>? range) => JSRef!.Call<IDBRequest<IDBCursor<TIndexKey, TPrimaryKey, TValue>>>("openKeyCursor", range);
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <param name="range">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <returns></returns>
        public Task<IDBCursor<TIndexKey, TPrimaryKey, TValue>> OpenKeyCursorAsync(Union<IDBKeyRange<TIndexKey>, TIndexKey>? range) => JSRef!.Call<IDBRequest<IDBCursor<TIndexKey, TPrimaryKey, TValue>>>("openKeyCursor", range).WaitAsync();
        /// <summary>
        /// A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.
        /// </summary>
        /// <returns></returns>
        public IDBRequest<IDBCursor<TIndexKey, TPrimaryKey, TValue>> OpenKeyCursor() => JSRef!.Call<IDBRequest<IDBCursor<TIndexKey, TPrimaryKey, TValue>>>("openKeyCursor");
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <returns></returns>
        public Task<IDBCursor<TIndexKey, TPrimaryKey, TValue>> OpenKeyCursorAsync() => JSRef!.Call<IDBRequest<IDBCursor<TIndexKey, TPrimaryKey, TValue>>>("openKeyCursor").WaitAsync();
        #endregion
    }
}
