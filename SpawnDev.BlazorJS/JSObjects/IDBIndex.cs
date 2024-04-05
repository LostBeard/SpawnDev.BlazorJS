using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// IDBIndex interface of the IndexedDB API provides asynchronous access to an index in a database. An index is a kind of object store for looking up records in another object store, called the referenced object store. You use this interface to retrieve data.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBIndex<br />
    /// https://w3c.github.io/IndexedDB/#index-interface
    /// </summary>
    public class IDBIndex<TKey, TValue> : EventTarget
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
        public IDBObjectStore<TValue> ObjectStore => JSRef!.Get<IDBObjectStore<TValue>>("objectStore");
        /// <summary>
        /// The ObjectStore referenced by this index.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public IDBObjectStore<TStoreKey, TValue> ObjectStoreAs<TStoreKey>() => JSRef!.Get<IDBObjectStore<TStoreKey, TValue>>("objectStore");
        /// <summary>
        /// The key path of this index. If null, this index is not auto-populated.
        /// </summary>
        public string? KeyPath => JSRef!.Get<string?>("keyPath");
        /// <summary>
        /// The key path of this index. If null, this index is not auto-populated.
        /// </summary>
        /// <typeparam name="T">The type of the keyPath</typeparam>
        /// <returns></returns>
        public T KeyPathAs<T>() => JSRef!.Get<T>("keyPath");
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
        public IDBRequest<int> Count(Union<IDBKeyRange<TKey>, TKey>? key = null) => JSRef!.Call<IDBRequest<int>>("count", key);
        /// <summary>
        /// returns the number of records within a key range.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<int> CountAsync(Union<IDBKeyRange<TKey>, TKey>? key = null) => JSRef!.Call<IDBRequest<int>>("count", key).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, finds either the value in the referenced object store that corresponds to the given key or the first corresponding value, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="key">A key or IDBKeyRange that identifies the record to be retrieved. If this value is null or missing, the browser will use an unbound key range.</param>
        /// <returns>An IDBRequest object on which subsequent events related to this operation are fired.</returns>
        public IDBRequest Get(Union<IDBKeyRange<TKey>, TKey> key) => JSRef!.Call<IDBRequest>("get", key);
        /// <summary>
        /// Returns the IDBRequest result of the get request<br />
        /// throws an exception if not found
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<TValue> GetAsync(Union<IDBKeyRange<TKey>, TKey> key) => JSRef!.Call<IDBRequest<TValue>>("get", key).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, finds either the given key or the primary key, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="key">A key or IDBKeyRange that identifies a record to be retrieved. If this value is null or missing, the browser will use an unbound key range.</param>
        /// <returns>An IDBRequest object on which subsequent events related to this operation are fired.</returns>
        public IDBRequest<TKey> GetKey(Union<IDBKeyRange<TKey>, TKey>? key = null) => JSRef!.Call<IDBRequest<TKey>>("getKey", key);
        /// <summary>
        /// Returns either the given key or the primary key, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<TKey> GetKeyAsync(Union<IDBKeyRange<TKey>, TKey>? key = null) => JSRef!.Call<IDBRequest<TKey>>("getKey", key).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, in a separate thread, finds all matching values in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="query">A key or an IDBKeyRange identifying the records to retrieve. If this value is null or missing, the browser will use an unbound key range.</param>
        /// <param name="count">The number of records to return. If this value exceeds the number of records in the query, the browser will only retrieve the queried records. If it is lower than 0 or greater than 2^32 - 1 a TypeError exception will be thrown.</param>
        /// <returns>An IDBRequest object on which subsequent events related to this operation are fired.</returns>
        public IDBRequest<Array<TValue>> GetAll(Union<IDBKeyRange<TKey>, TKey>? query, int count) => JSRef!.Call<IDBRequest<Array<TValue>>>("getAll", query, count);
        /// <summary>
        /// Returns all matching values in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public Task<Array<TValue>> GetAllAsync(Union<IDBKeyRange<TKey>, TKey>? query, int count) => JSRef!.Call<IDBRequest<Array<TValue>>>("getAll", query, count).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, in a separate thread, finds all matching values in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="query">A key or an IDBKeyRange identifying the records to retrieve. If this value is null or missing, the browser will use an unbound key range.</param>
        /// <returns></returns>
        public IDBRequest<Array<TValue>> GetAll(Union<IDBKeyRange<TKey>, TKey>? query = null) => JSRef!.Call<IDBRequest<Array<TValue>>>("getAll", query);
        /// <summary>
        /// Returns all matching values in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<Array<TValue>> GetAllAsync(Union<IDBKeyRange<TKey>, TKey>? query = null) => JSRef!.Call<IDBRequest<Array<TValue>>>("getAll", query).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, in a separate thread, finds all matching keys in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="query">A key or an IDBKeyRange identifying the keys to retrieve. If this value is null or missing, the browser will use an unbound key range.</param>
        /// <param name="count">The number records to return. If this value exceeds the number of records in the query, the browser will only retrieve the first item. If it is lower than 0 or greater than 2^32 - 1 a TypeError exception will be thrown.</param>
        /// <returns>An IDBRequest object on which subsequent events related to this operation are fired.</returns>
        public IDBRequest<TKey[]> GetAllKeys(Union<IDBKeyRange<TKey>, TKey>? query, int count) => JSRef!.Call<IDBRequest<TKey[]>>("getAllKeys", query, count);
        /// <summary>
        /// Returns all matching keys in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public Task<TKey[]> GetAllKeysAsync(Union<IDBKeyRange<TKey>, TKey>? query, int count) => JSRef!.Call<IDBRequest<TKey[]>>("getAllKeys", query, count).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, in a separate thread, finds all matching keys in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="query">A key or an IDBKeyRange identifying the keys to retrieve. If this value is null or missing, the browser will use an unbound key range.</param>
        /// <returns>An IDBRequest object on which subsequent events related to this operation are fired.</returns>
        public IDBRequest<TKey[]> GetAllKeys(Union<IDBKeyRange<TKey>, TKey>? query = null) => JSRef!.Call<IDBRequest<TKey[]>>("getAllKeys", query);
        /// <summary>
        /// Returns all matching keys in the referenced object store that correspond to the given key or are in range, if key is an IDBKeyRange.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<TKey[]> GetAllKeysAsync(Union<IDBKeyRange<TKey>, TKey>? query = null) => JSRef!.Call<IDBRequest<TKey[]>>("getAllKeys", query).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range.
        /// </summary>
        /// <returns></returns>
        public IDBRequest<IDBCursorWithValue<TKey, TValue>> OpenCursor() => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor");
        /// <summary>
        /// Creates a cursor over the specified key range.
        /// </summary>
        /// <returns></returns>
        public Task<IDBCursorWithValue<TKey, TValue>> OpenCursorAsync() => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor").WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range.
        /// </summary>
        /// <param name="range">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <returns></returns>
        public IDBRequest<IDBCursorWithValue<TKey, TValue>> OpenCursor(Union<IDBKeyRange<TKey>, TKey>? range) => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor", range);
        /// <summary>
        /// Creates a cursor over the specified key range.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Task<IDBCursorWithValue<TKey, TValue>> OpenCursorAsync(Union<IDBKeyRange<TKey>, TKey>? range) => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor", range).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range.
        /// </summary>
        /// <param name="range">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <param name="direction">The cursor's direction. See IDBCursor Constants for possible values.</param>
        /// <returns></returns>
        public IDBRequest<IDBCursorWithValue<TKey, TValue>> OpenCursor(Union<IDBKeyRange<TKey>, TKey>? range, string direction) => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor", range, direction);
        /// <summary>
        /// Creates a cursor over the specified key range.
        /// </summary>
        /// <param name="range"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Task<IDBCursorWithValue<TKey, TValue>> OpenCursorAsync(Union<IDBKeyRange<TKey>, TKey>? range, string direction) => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor", range, direction).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <param name="range">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <param name="direction">The cursor's direction. See IDBCursor Constants for possible values.</param>
        /// <returns></returns>
        public IDBRequest<IDBCursor<TKey, TValue>> OpenKeyCursor(Union<IDBKeyRange<TKey>, TKey>? range, string direction) => JSRef!.Call<IDBRequest<IDBCursor<TKey, TValue>>>("openKeyCursor", range, direction);
        /// <summary>
        /// Creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <param name="range"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Task<IDBCursor<TKey, TValue>> OpenKeyCursorAsync(Union<IDBKeyRange<TKey>, TKey>? range, string direction) => JSRef!.Call<IDBRequest<IDBCursor<TKey, TValue>>>("openKeyCursor", range, direction).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <param name="range">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <returns></returns>
        public IDBRequest<IDBCursor<TKey, TValue>> OpenKeyCursor(Union<IDBKeyRange<TKey>, TKey>? range) => JSRef!.Call<IDBRequest<IDBCursor<TKey, TValue>>>("openKeyCursor", range);
        /// <summary>
        /// Creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Task<IDBCursor<TKey, TValue>> OpenKeyCursorAsync(Union<IDBKeyRange<TKey>, TKey>? range) => JSRef!.Call<IDBRequest<IDBCursor<TKey, TValue>>>("openKeyCursor", range).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <returns></returns>
        public IDBRequest<IDBCursor<TKey, TValue>> OpenKeyCursor() => JSRef!.Call<IDBRequest<IDBCursor<TKey, TValue>>>("openKeyCursor");
        /// <summary>
        /// Creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <returns></returns>
        public Task<IDBCursor<TKey, TValue>> OpenKeyCursorAsync() => JSRef!.Call<IDBRequest<IDBCursor<TKey, TValue>>>("openKeyCursor").WaitAsync();
        #endregion
    }
}
