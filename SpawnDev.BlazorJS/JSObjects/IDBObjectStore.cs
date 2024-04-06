using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The IDBObjectStore interface of the IndexedDB API represents an object store in a database. Records within an object store are sorted according to their keys. This sorting enables fast insertion, look-up, and ordered retrieval.
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBObjectStore
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public class IDBObjectStore<TValue> : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBObjectStore(IJSInProcessObjectReference _ref) : base(_ref) { }
        #region Properties
        /// <summary>
        /// A list of the names of indexes on objects in this object store.
        /// </summary>
        public string[] IndexNames => JSRef.Get<DOMStringList>("indexNames").ToArray();
        /// <summary>
        /// The key path of this object store. If this attribute is null, the application must provide a key for each modification operation.
        /// </summary>
        public Union<string, string[]>? KeyPath => JSRef.Get<Union<string, string[]>?>("keyPath");
        /// <summary>
        /// The name of this object store.
        /// </summary>
        public string Name { get => JSRef.Get<string>("name"); set => JSRef.Set("name", value); }
        /// <summary>
        /// The IDBTransaction object to which this object store belongs.
        /// </summary>
        public IDBTransaction Transaction => JSRef.Get<IDBTransaction>("transaction");
        /// <summary>
        /// The value of the auto increment flag for this object store.
        /// </summary>
        public bool AutoIncrement => JSRef.Get<bool>("autoIncrement");
        #endregion
        /// <summary>
        /// Opens an index from this object store after which it can, for example, be used to return a sequence of records sorted by that index using a cursor.
        /// </summary>
        /// <param name="name">The name of the index to open.</param>
        /// <returns>An IDBIndex object for accessing the index.</returns>
        public IDBIndex<TKey, TValue> Index<TKey>(string name) => JSRef.Call<IDBIndex<TKey, TValue>>("index", name);
        /// <summary>
        /// Creates a new index during a version upgrade, returning a new IDBIndex object in the connected database.
        /// </summary>
        /// <param name="indexName">The name of the index to create. Note that it is possible to create an index with an empty name.</param>
        /// <param name="keyPath">The key path for the index to use. Note that it is possible to create an index with an empty keyPath, and also to pass in a sequence (array) as a keyPath.</param>
        /// <returns></returns>
        public IDBIndex<TIndexKey, TValue> CreateIndex<TIndexKey>(string indexName, Union<string, string[]> keyPath) => JSRef.Call<IDBIndex<TIndexKey, TValue>>("createIndex", indexName, keyPath);
        /// <summary>
        /// Creates a new index during a version upgrade, returning a new IDBIndex object in the connected database.
        /// </summary>
        /// <param name="indexName">The name of the index to create. Note that it is possible to create an index with an empty name.</param>
        /// <param name="keyPath">The key path for the index to use. Note that it is possible to create an index with an empty keyPath, and also to pass in a sequence (array) as a keyPath.</param>
        /// <param name="options">Additional options</param>
        /// <returns></returns>
        public IDBIndex<TIndexKey, TValue> CreateIndex<TIndexKey>(string indexName, string keyPath, IDBObjectStoreCreateIndexOptions options) => JSRef.Call<IDBIndex<TIndexKey, TValue>>("createIndex", indexName, keyPath, options);
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, returns the total number of records that match the provided key or IDBKeyRange. If no arguments are provided, it returns the total number of records in the store.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public IDBRequest<int> Count<TKey>(TKey key) => JSRef.Call<IDBRequest<int>>("count", key);
        /// <summary>
        /// Returns a Task that returns the total number of records that match the provided key or IDBKeyRange. If no arguments are provided, it returns the total number of records in the store.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<int> CountAsync<TKey>(TKey key) => Count(key).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, returns the total number of records that match the provided key or IDBKeyRange. If no arguments are provided, it returns the total number of records in the store.
        /// </summary>
        /// <returns></returns>
        public IDBRequest<int> Count() => JSRef.Call<IDBRequest<int>>("count");
        /// <summary>
        /// Returns a Task that returns the total number of records that match the provided key or IDBKeyRange. If no arguments are provided, it returns the total number of records in the store.
        /// </summary>
        /// <returns></returns>
        public Task<int> CountAsync() => Count().WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a structured clone of the value, and stores the cloned value in the object store. This is for adding new records to an object store.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public IDBRequest Add<TKey>(TValue value, TKey key) => JSRef.Call<IDBRequest>("add", value, key);
        /// <summary>
        /// Creates a structured clone of the value, and stores the cloned value in the object store. This is for adding new records to an object store.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task AddAsync<TKey>(TValue value, TKey key) => Add(value, key).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a structured clone of the value, and stores the cloned value in the object store. This is for adding new records to an object store.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IDBRequest Add(TValue value) => JSRef.Call<IDBRequest>("add", value);
        /// <summary>
        /// Creates a structured clone of the value, and stores the cloned value in the object store. This is for adding new records to an object store.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task AddAsync(TValue value) => Add(value).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a structured clone of the value, and stores the cloned value in the object store. This is for updating existing records in an object store when the transaction's mode is readwrite.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public IDBRequest Put<TKey>(TValue value, TKey key) => JSRef.Call<IDBRequest>("put", value, key);
        /// <summary>
        /// Creates a structured clone of the value, and stores the cloned value in the object store. This is for updating existing records in an object store when the transaction's mode is readwrite.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task PutAsync<TKey>(TValue value, TKey key) => Put(value, key).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a structured clone of the value, and stores the cloned value in the object store. This is for updating existing records in an object store when the transaction's mode is readwrite.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IDBRequest Put(TValue value) => JSRef.Call<IDBRequest>("put", value);
        /// <summary>
        /// Creates a structured clone of the value, and stores the cloned value in the object store. This is for updating existing records in an object store when the transaction's mode is readwrite.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task PutAsync(TValue value) => Put(value).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object retrieves all objects in the object store matching the specified parameter or all objects in the store if no parameters are given.
        /// </summary>
        /// <returns></returns>
        public IDBRequest<TValue[]> GetAll() => JSRef.Call<IDBRequest<TValue[]>>("getAll");
        /// <summary>
        /// Retrieves all objects in the object store matching the specified parameter or all objects in the store if no parameters are given.
        /// </summary>
        /// <returns></returns>
        public Task<TValue[]> GetAllAsync() => GetAll().WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, returns the store object store selected by the specified key. This is for retrieving specific records from an object store.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public IDBRequest<TValue> Get<TKey>(TKey key) => JSRef.Call<IDBRequest<TValue>>("get", key);
        /// <summary>
        /// Returns the store object store selected by the specified key. This is for retrieving specific records from an object store.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<TValue> GetAsync<TKey>(TKey key) => Get(key).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, deletes the store object selected by the specified key. This is for deleting individual records out of an object store.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public IDBRequest Delete<TKey>(TKey key) => JSRef.Call<IDBRequest>("delete", key);
        /// <summary>
        /// Deletes the store object selected by the specified key. This is for deleting individual records out of an object store.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task DeleteAsync<TKey>(TKey key) => Delete(key).WaitAsync();
        /// <summary>
        /// Creates and immediately returns an IDBRequest object, and clears this object store in a separate thread. This is for deleting all current records out of an object store.
        /// </summary>
        /// <returns></returns>
        public IDBRequest Clear() => JSRef.Call<IDBRequest>("clear");
        /// <summary>
        /// This is for deleting all current records out of an object store.
        /// </summary>
        /// <returns></returns>
        public Task ClearAsync() => Clear().WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object retrieves record keys for all objects in the object store matching the specified parameter or all objects in the store if no parameters are given.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public IDBRequest<TKey[]> GetAllKeys<TKey>() => JSRef.Call<IDBRequest<TKey[]>>("getAllKeys");
        /// <summary>
        /// Returns record keys for all objects in the object store matching the specified parameter or all objects in the store if no parameters are given.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public Task<TKey[]> GetAllKeysAsync<TKey>() => GetAllKeys<TKey>().WaitAsync();
        /// <summary>
        /// Destroys the specified index in the connected database, used during a version upgrade.
        /// </summary>
        /// <param name="indexName"></param>
        public void DeleteIndex(string indexName) => JSRef.CallVoid("deleteIndex", indexName);
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor.
        /// </summary>
        /// <returns></returns>
        public IDBRequest<IDBCursorWithValue<TKey, TValue>> OpenCursor<TKey>() => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor");
        /// <summary>
        /// Returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor.
        /// </summary>
        /// <returns></returns>
        public Task<IDBCursorWithValue<TKey, TValue>> OpenCursorAsync<TKey>() => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor").WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor.
        /// </summary>
        /// <param name="query">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <returns></returns>
        public IDBRequest<IDBCursorWithValue<TKey, TValue>> OpenCursor<TKey>(Union<IDBKeyRange<TKey>, TKey>? query) => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor", query);
        /// <summary>
        /// Returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<IDBCursorWithValue<TKey, TValue>> OpenCursorAsync<TKey>(Union<IDBKeyRange<TKey>, TKey>? query) => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor", query).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor.
        /// </summary>
        /// <param name="query">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <param name="direction">
        /// A string telling the cursor which direction to travel. The default is next. Valid values are:<br />
        /// "next" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the increasing order of keys.<br />
        /// "nextunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the increasing order of keys.<br />
        /// "prev" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the decreasing order of keys.<br />
        /// "prevunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the decreasing order of keys.<br />
        /// </param>
        /// <returns></returns>
        public IDBRequest<IDBCursorWithValue<TKey, TValue>> OpenCursor<TKey>(Union<IDBKeyRange<TKey>, TKey>? query, string direction) => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor", query, direction);
        /// <summary>
        /// Returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor.
        /// </summary>
        /// <param name="query">A key or IDBKeyRange to be queried. If a single valid key is passed, this will default to a range containing only that key. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <param name="direction">
        /// A string telling the cursor which direction to travel. The default is next. Valid values are:<br />
        /// "next" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the increasing order of keys.<br />
        /// "nextunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the increasing order of keys.<br />
        /// "prev" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the decreasing order of keys.<br />
        /// "prevunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the decreasing order of keys.<br />
        /// </param>
        /// <returns>Task&lt;IDBCursorWithValue&gt;</returns>
        public Task<IDBCursorWithValue<TKey, TValue>> OpenCursorAsync<TKey>(Union<IDBKeyRange<TKey>, TKey>? query, string direction) => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor", query, direction).WaitAsync();

        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <param name="range">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <param name="direction">The cursor's direction. See IDBCursor Constants for possible values.</param>
        /// <returns></returns>
        public IDBRequest<IDBCursor<TKey, TValue>> OpenKeyCursor<TKey>(Union<IDBKeyRange<TKey>, TKey>? range, string direction) => JSRef!.Call<IDBRequest<IDBCursor<TKey, TValue>>>("openKeyCursor", range, direction);
        /// <summary>
        /// Creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <param name="range"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Task<IDBCursor<TKey, TValue>> OpenKeyCursorAsync<TKey>(Union<IDBKeyRange<TKey>, TKey>? range, string direction) => JSRef!.Call<IDBRequest<IDBCursor<TKey, TValue>>>("openKeyCursor", range, direction).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <param name="range">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <returns></returns>
        public IDBRequest<IDBCursor<TKey, TValue>> OpenKeyCursor<TKey>(Union<IDBKeyRange<TKey>, TKey>? range) => JSRef!.Call<IDBRequest<IDBCursor<TKey, TValue>>>("openKeyCursor", range);
        /// <summary>
        /// Creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Task<IDBCursor<TKey, TValue>> OpenKeyCursorAsync<TKey>(Union<IDBKeyRange<TKey>, TKey>? range) => JSRef!.Call<IDBRequest<IDBCursor<TKey, TValue>>>("openKeyCursor", range).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <returns></returns>
        public IDBRequest<IDBCursor<TKey, TValue>> OpenKeyCursor<TKey>() => JSRef!.Call<IDBRequest<IDBCursor<TKey, TValue>>>("openKeyCursor");
        /// <summary>
        /// Creates a cursor over the specified key range, as arranged by this index.
        /// </summary>
        /// <returns></returns>
        public Task<IDBCursor<TKey, TValue>> OpenKeyCursorAsync<TKey>() => JSRef!.Call<IDBRequest<IDBCursor<TKey, TValue>>>("openKeyCursor").WaitAsync();
    }
    /// <summary>
    /// The IDBObjectStore interface of the IndexedDB API represents an object store in a database. Records within an object store are sorted according to their keys. This sorting enables fast insertion, look-up, and ordered retrieval.
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBObjectStore
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class IDBObjectStore<TKey, TValue> : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBObjectStore(IJSInProcessObjectReference _ref) : base(_ref) { }
        #region Properties
        /// <summary>
        /// A list of the names of indexes on objects in this object store.
        /// </summary>
        public string[] IndexNames => JSRef.Get<DOMStringList>("indexNames").ToArray();
        /// <summary>
        /// The key path of this object store. If this attribute is null, the application must provide a key for each modification operation.
        /// </summary>
        public Union<string, string[]>? KeyPath => JSRef.Get<Union<string, string[]>?>("keyPath");
        /// <summary>
        /// The name of this object store.
        /// </summary>
        public string Name { get => JSRef.Get<string>("name"); set => JSRef.Set("name", value); }
        /// <summary>
        /// The IDBTransaction object to which this object store belongs.
        /// </summary>
        public IDBTransaction Transaction => JSRef.Get<IDBTransaction>("transaction");
        /// <summary>
        /// The value of the auto increment flag for this object store.
        /// </summary>
        public bool AutoIncrement => JSRef.Get<bool>("autoIncrement");
        #endregion
        #region Methods
        /// <summary>
        /// Opens an index from this object store after which it can, for example, be used to return a sequence of records sorted by that index using a cursor.
        /// </summary>
        /// <param name="name">The name of the index to open.</param>
        /// <returns>An IDBIndex object for accessing the index.</returns>
        public IDBIndex<TKey, TValue> Index(string name) => JSRef.Call<IDBIndex<TKey, TValue>>("index", name);
        /// <summary>
        /// Creates a new index during a version upgrade, returning a new IDBIndex object in the connected database.
        /// </summary>
        /// <param name="indexName">The name of the index to create. Note that it is possible to create an index with an empty name.</param>
        /// <param name="keyPath">The key path for the index to use. Note that it is possible to create an index with an empty keyPath, and also to pass in a sequence (array) as a keyPath.</param>
        /// <returns></returns>
        public IDBIndex<TIndexKey, TValue> CreateIndex<TIndexKey>(string indexName, Union<string, string[]> keyPath) => JSRef.Call<IDBIndex<TIndexKey, TValue>>("createIndex", indexName, keyPath);
        /// <summary>
        /// Creates a new index during a version upgrade, returning a new IDBIndex object in the connected database.
        /// </summary>
        /// <param name="indexName">The name of the index to create. Note that it is possible to create an index with an empty name.</param>
        /// <param name="keyPath">The key path for the index to use. Note that it is possible to create an index with an empty keyPath, and also to pass in a sequence (array) as a keyPath.</param>
        /// <param name="options">Additional options</param>
        /// <returns></returns>
        public IDBIndex<TIndexKey, TValue>  CreateIndex<TIndexKey>(string indexName, string keyPath, IDBObjectStoreCreateIndexOptions options) => JSRef.Call<IDBIndex<TIndexKey, TValue>>("createIndex", indexName, keyPath, options);
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, returns the total number of records that match the provided key or IDBKeyRange. If no arguments are provided, it returns the total number of records in the store.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IDBRequest<int> Count(TKey key) => JSRef.Call<IDBRequest<int>>("count", key);
        /// <summary>
        /// Returns a Task that returns the total number of records that match the provided key or IDBKeyRange. If no arguments are provided, it returns the total number of records in the store.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<int> CountAsync(TKey key) => Count(key).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, returns the total number of records that match the provided key or IDBKeyRange. If no arguments are provided, it returns the total number of records in the store.
        /// </summary>
        /// <returns></returns>
        public IDBRequest<int> Count() => JSRef.Call<IDBRequest<int>>("count");
        /// <summary>
        /// Returns a Task that returns the total number of records that match the provided key or IDBKeyRange. If no arguments are provided, it returns the total number of records in the store.
        /// </summary>
        /// <returns></returns>
        public Task<int> CountAsync() => Count().WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a structured clone of the value, and stores the cloned value in the object store. This is for adding new records to an object store.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public IDBRequest Add(TValue value, TKey key) => JSRef.Call<IDBRequest>("add", value, key);
        /// <summary>
        /// Creates a structured clone of the value, and stores the cloned value in the object store. This is for adding new records to an object store.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task AddAsync(TValue value, TKey key) => Add(value, key).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a structured clone of the value, and stores the cloned value in the object store. This is for adding new records to an object store.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IDBRequest Add(TValue value) => JSRef.Call<IDBRequest>("add", value);
        /// <summary>
        /// Creates a structured clone of the value, and stores the cloned value in the object store. This is for adding new records to an object store.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task AddAsync(TValue value) => Add(value).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a structured clone of the value, and stores the cloned value in the object store. This is for updating existing records in an object store when the transaction's mode is readwrite.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public IDBRequest Put(TValue value, TKey key) => JSRef.Call<IDBRequest>("put", value, key);
        /// <summary>
        /// Creates a structured clone of the value, and stores the cloned value in the object store. This is for updating existing records in an object store when the transaction's mode is readwrite.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task PutAsync(TValue value, TKey key) => Put(value, key).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, creates a structured clone of the value, and stores the cloned value in the object store. This is for updating existing records in an object store when the transaction's mode is readwrite.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IDBRequest Put(TValue value) => JSRef.Call<IDBRequest>("put", value);
        /// <summary>
        /// Creates a structured clone of the value, and stores the cloned value in the object store. This is for updating existing records in an object store when the transaction's mode is readwrite.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task PutAsync(TValue value) => Put(value).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object retrieves all objects in the object store matching the specified parameter or all objects in the store if no parameters are given.
        /// </summary>
        /// <returns></returns>
        public IDBRequest<TValue[]> GetAll() => JSRef.Call<IDBRequest<TValue[]>>("getAll");
        /// <summary>
        /// Retrieves all objects in the object store matching the specified parameter or all objects in the store if no parameters are given.
        /// </summary>
        /// <returns></returns>
        public Task<TValue[]> GetAllAsync() => GetAll().WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, returns the store object store selected by the specified key. This is for retrieving specific records from an object store.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IDBRequest<TValue> Get(TKey key) => JSRef.Call<IDBRequest<TValue>>("get", key);
        /// <summary>
        /// Returns the store object store selected by the specified key. This is for retrieving specific records from an object store.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<TValue> GetAsync(TKey key) => Get(key).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, deletes the store object selected by the specified key. This is for deleting individual records out of an object store.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IDBRequest Delete(TKey key) => JSRef.Call<IDBRequest>("delete", key);
        /// <summary>
        /// Deletes the store object selected by the specified key. This is for deleting individual records out of an object store.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task DeleteAsync(TKey key) => Delete(key).WaitAsync();
        /// <summary>
        /// Creates and immediately returns an IDBRequest object, and clears this object store in a separate thread. This is for deleting all current records out of an object store.
        /// </summary>
        /// <returns></returns>
        public IDBRequest Clear() => JSRef.Call<IDBRequest>("clear");
        /// <summary>
        /// This is for deleting all current records out of an object store.
        /// </summary>
        /// <returns></returns>
        public Task ClearAsync() => Clear().WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object retrieves record keys for all objects in the object store matching the specified parameter or all objects in the store if no parameters are given.
        /// </summary>
        /// <returns></returns>
        public IDBRequest<TKey[]> GetAllKeys() => JSRef.Call<IDBRequest<TKey[]>>("getAllKeys");
        /// <summary>
        /// Returns record keys for all objects in the object store matching the specified parameter or all objects in the store if no parameters are given.
        /// </summary>
        /// <returns></returns>
        public Task<TKey[]> GetAllKeysAsync() => GetAllKeys().WaitAsync();
        /// <summary>
        /// Destroys the specified index in the connected database, used during a version upgrade.
        /// </summary>
        /// <param name="indexName"></param>
        public void DeleteIndex(string indexName) => JSRef.CallVoid("deleteIndex", indexName);

        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor.
        /// </summary>
        /// <returns></returns>
        public IDBRequest<IDBCursorWithValue<TKey, TValue>> OpenCursor() => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor");
        /// <summary>
        /// Returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor.
        /// </summary>
        /// <returns></returns>
        public Task<IDBCursorWithValue<TKey, TValue>> OpenCursorAsync() => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor").WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor.
        /// </summary>
        /// <param name="query">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <returns></returns>
        public IDBRequest<IDBCursorWithValue<TKey, TValue>> OpenCursor(Union<IDBKeyRange<TKey>, TKey>? query) => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor", query);
        /// <summary>
        /// Returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<IDBCursorWithValue<TKey, TValue>> OpenCursorAsync(Union<IDBKeyRange<TKey>, TKey>? query) => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor", query).WaitAsync();
        /// <summary>
        /// Returns an IDBRequest object, and, in a separate thread, returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor.
        /// </summary>
        /// <param name="query">A key or IDBKeyRange to use as the cursor's range. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <param name="direction">
        /// A string telling the cursor which direction to travel. The default is next. Valid values are:<br />
        /// "next" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the increasing order of keys.<br />
        /// "nextunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the increasing order of keys.<br />
        /// "prev" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the decreasing order of keys.<br />
        /// "prevunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the decreasing order of keys.<br />
        /// </param>
        /// <returns></returns>
        public IDBRequest<IDBCursorWithValue<TKey, TValue>> OpenCursor(Union<IDBKeyRange<TKey>, TKey>? query, string direction) => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor", query, direction);
        /// <summary>
        /// Returns a new IDBCursorWithValue object. Used for iterating through an object store by primary key with a cursor.
        /// </summary>
        /// <param name="query">A key or IDBKeyRange to be queried. If a single valid key is passed, this will default to a range containing only that key. If nothing is passed, this will default to a key range that selects all the records in this object store.</param>
        /// <param name="direction">
        /// A string telling the cursor which direction to travel. The default is next. Valid values are:<br />
        /// "next" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the increasing order of keys.<br />
        /// "nextunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the increasing order of keys.<br />
        /// "prev" - The cursor is opened at the start of the store; then, the cursor returns all records, even duplicates, in the decreasing order of keys.<br />
        /// "prevunique" - The cursor is opened at the start of the store; then, the cursor returns all records, that are not duplicates, in the decreasing order of keys.<br />
        /// </param>
        /// <returns>Task&lt;IDBCursorWithValue&gt;</returns>
        public Task<IDBCursorWithValue<TKey, TValue>> OpenCursorAsync(Union<IDBKeyRange<TKey>, TKey>? query, string direction) => JSRef!.Call<IDBRequest<IDBCursorWithValue<TKey, TValue>>>("openCursor", query, direction).WaitAsync();

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
