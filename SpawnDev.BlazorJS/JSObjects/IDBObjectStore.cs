using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    ///// <summary>
    ///// The IDBObjectStore interface of the IndexedDB API represents an object store in a database. Records within an object store are sorted according to their keys. This sorting enables fast insertion, look-up, and ordered retrieval.<br />
    ///// https://developer.mozilla.org/en-US/docs/Web/API/IDBObjectStore
    ///// </summary>
    //public class IDBObjectStore : JSObject
    //{
    //    /// <summary>
    //    /// Deserialization constructor
    //    /// </summary>
    //    /// <param name="_ref"></param>
    //    public IDBObjectStore(IJSInProcessObjectReference _ref) : base(_ref) { }
    //    /// <summary>
    //    /// Opens an index from this object store after which it can, for example, be used to return a sequence of records sorted by that index using a cursor.
    //    /// </summary>
    //    /// <param name="name">The name of the index to open.</param>
    //    /// <returns>An IDBIndex object for accessing the index.</returns>
    //    public IDBIndex Index(string name) => JSRef.Call<IDBIndex>("index", name);

    //    /// <summary>
    //    /// A list of the names of indexes on objects in this object store.
    //    /// </summary>
    //    public DOMStringList IndexNames => JSRef.Get<DOMStringList>("indexNames");
    //    /// <summary>
    //    /// The key path of this object store. If this attribute is null, the application must provide a key for each modification operation.
    //    /// </summary>
    //    public string KeyPath => JSRef.Get<string>("keyPath");
    //    /// <summary>
    //    /// The key path of this object store. If this attribute is null, the application must provide a key for each modification operation.
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <returns></returns>
    //    public T KeyPathAs<T>() => JSRef.Get<T>("keyPath");
    //    /// <summary>
    //    /// The name of this object store.
    //    /// </summary>
    //    public string Name { get => JSRef.Get<string>("name"); set => JSRef.Set("name", value); }
    //    /// <summary>
    //    /// The IDBTransaction object to which this object store belongs.
    //    /// </summary>
    //    public IDBTransaction Transaction => JSRef.Get<IDBTransaction>("transaction");
    //    /// <summary>
    //    /// The value of the auto increment flag for this object store.
    //    /// </summary>
    //    public bool AutoIncrement => JSRef.Get<bool>("autoIncrement");

    //    /// <summary>
    //    /// Creates a new index during a version upgrade, returning a new IDBIndex object in the connected database.
    //    /// </summary>
    //    /// <param name="indexName">The name of the index to create. Note that it is possible to create an index with an empty name.</param>
    //    /// <param name="keyPath">The key path for the index to use. Note that it is possible to create an index with an empty keyPath, and also to pass in a sequence (array) as a keyPath.</param>
    //    /// <returns></returns>
    //    public IDBIndex CreateIndex(string indexName, IDBKeyPath keyPath) => JSRef.Call<IDBIndex>("createIndex", indexName, keyPath);
    //    /// <summary>
    //    /// Creates a new index during a version upgrade, returning a new IDBIndex object in the connected database.
    //    /// </summary>
    //    /// <param name="indexName">The name of the index to create. Note that it is possible to create an index with an empty name.</param>
    //    /// <param name="keyPath">The key path for the index to use. Note that it is possible to create an index with an empty keyPath, and also to pass in a sequence (array) as a keyPath.</param>
    //    /// <param name="options">Additional options</param>
    //    /// <returns></returns>
    //    public IDBIndex CreateIndex(string indexName, string keyPath, IDBObjectStoreCreateIndexOptions options) => JSRef.Call<IDBIndex>("createIndex", indexName, keyPath, options);

    //    public IDBRequest<int> Count(object key) => JSRef.Call<IDBRequest<int>>("count", key);
    //    public Task<int> CountAsync(string key) => IDBRequest.ToAsync(Count(key));
    //    public IDBRequest<int> Count() => JSRef.Call<IDBRequest<int>>("count");
    //    public Task<int> CountAsync() => IDBRequest.ToAsync(Count());

    //    public IDBRequest Add(object value, string key) => JSRef.Call<IDBRequest>("add", value, key);
    //    public Task AddAsync(object value, string key) => IDBRequest.ToVoidAsync(Add(value, key));

    //    public IDBRequest Put(object value, string key) => JSRef.Call<IDBRequest>("put", value, key);
    //    public Task PutAsync(object value, string key) => IDBRequest.ToVoidAsync(Put(value, key));

    //    public IDBRequest Add(object value) => JSRef.Call<IDBRequest>("add", value);
    //    public Task AddAsync(object value) => IDBRequest.ToVoidAsync(Add(value));

    //    public IDBRequest Put(object value) => JSRef.Call<IDBRequest>("put", value);
    //    public Task PutAsync(object value) => IDBRequest.ToVoidAsync(Put(value));

    //    public IDBRequest<T[]> GetAll<T>() => JSRef.Call<IDBRequest<T[]>>("getAll");
    //    public Task<T[]> GetAllAsync<T>() => IDBRequest.ToAsync(GetAll<T>());
    //    public IDBRequest<T> Get<T>(string key) => JSRef.Call<IDBRequest<T>>("get", key);
    //    public Task<T> GetAsync<T>(string key) => IDBRequest.ToAsync(Get<T>(key));

    //    public IDBRequest Delete(string key) => JSRef.Call<IDBRequest>("delete", key);
    //    public Task DeleteAsync(string key) => IDBRequest.ToVoidAsync(Delete(key));

    //    public IDBRequest Clear() => JSRef.Call<IDBRequest>("clear");
    //    public Task ClearAsync() => IDBRequest.ToVoidAsync(Clear());

    //    public IDBRequest<string[]> GetAllKeys() => JSRef.Call<IDBRequest<string[]>>("getAllKeys");
    //    public Task<string[]> GetAllKeysAsync() => IDBRequest.ToAsync(GetAllKeys());
    //}


    public class IDBObjectStore<TValue> : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBObjectStore(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Opens an index from this object store after which it can, for example, be used to return a sequence of records sorted by that index using a cursor.
        /// </summary>
        /// <param name="name">The name of the index to open.</param>
        /// <returns>An IDBIndex object for accessing the index.</returns>
        public IDBIndex<TKey, TValue> Index<TKey>(string name) => JSRef.Call<IDBIndex<TKey, TValue>>("index", name);
        /// <summary>
        /// A list of the names of indexes on objects in this object store.
        /// </summary>
        public string[] IndexNames => JSRef.Get<DOMStringList>("indexNames").ToArray();
        /// <summary>
        /// The key path of this object store. If this attribute is null, the application must provide a key for each modification operation.
        /// </summary>
        public Union<string, string[]>? KeyPath => JSRef.Get<Union<string, string[]>?>("keyPath");
        /// <summary>
        /// The key path of this object store. If this attribute is null, the application must provide a key for each modification operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T KeyPathAs<T>() => JSRef.Get<T>("keyPath");
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

        public IDBRequest<int> Count<TKey>(TKey key) => JSRef.Call<IDBRequest<int>>("count", key);
        public Task<int> CountAsync<TKey>(TKey key) => Count(key).WaitAsync();
        public IDBRequest<int> Count() => JSRef.Call<IDBRequest<int>>("count");
        public Task<int> CountAsync() => Count().WaitAsync();

        public IDBRequest Add<TKey>(TValue value, TKey key) => JSRef.Call<IDBRequest>("add", value, key);
        public Task AddAsync<TKey>(TValue value, TKey key) => Add(value, key).WaitAsync();
        public IDBRequest Put<TKey>(TValue value, TKey key) => JSRef.Call<IDBRequest>("put", value, key);
        public Task PutAsync<TKey>(TValue value, TKey key) => Put(value, key).WaitAsync();

        public IDBRequest Add(TValue value) => JSRef.Call<IDBRequest>("add", value);
        public Task AddAsync(TValue value) => Add(value).WaitAsync();
        public IDBRequest Put(TValue value) => JSRef.Call<IDBRequest>("put", value);
        public Task PutAsync(TValue value) => Put(value).WaitAsync();

        public IDBRequest<TValue[]> GetAll() => JSRef.Call<IDBRequest<TValue[]>>("getAll");
        public Task<TValue[]> GetAllAsync() => GetAll().WaitAsync();
        public IDBRequest<TValue> Get<TKey>(TKey key) => JSRef.Call<IDBRequest<TValue>>("get", key);
        public Task<TValue> GetAsync<TKey>(TKey key) => Get(key).WaitAsync();
        public IDBRequest Delete<TKey>(TKey key) => JSRef.Call<IDBRequest>("delete", key);
        public Task DeleteAsync<TKey>(TKey key) => Delete(key).Using(o => o.WaitAsync());
        public IDBRequest Clear() => JSRef.Call<IDBRequest>("clear");
        public Task ClearAsync() => Clear().Using(o => o.WaitAsync());
        public IDBRequest<TKey[]> GetAllKeys<TKey>() => JSRef.Call<IDBRequest<TKey[]>>("getAllKeys");
        public Task<TKey[]> GetAllKeysAsync<TKey>() => GetAllKeys<TKey>().Using(o => o.WaitAsync());
    }



    public class IDBObjectStore<TKey, TValue> : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBObjectStore(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Opens an index from this object store after which it can, for example, be used to return a sequence of records sorted by that index using a cursor.
        /// </summary>
        /// <param name="name">The name of the index to open.</param>
        /// <returns>An IDBIndex object for accessing the index.</returns>
        public IDBIndex<TKey, TValue> Index(string name) => JSRef.Call<IDBIndex<TKey, TValue>>("index", name);
        /// <summary>
        /// A list of the names of indexes on objects in this object store.
        /// </summary>
        public string[] IndexNames => JSRef.Get<DOMStringList>("indexNames").ToArray();
        /// <summary>
        /// The key path of this object store. If this attribute is null, the application must provide a key for each modification operation.
        /// </summary>
        public Union<string, string[]>? KeyPath => JSRef.Get<Union<string, string[]>?>("keyPath");
        /// <summary>
        /// The key path of this object store. If this attribute is null, the application must provide a key for each modification operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T KeyPathAs<T>() => JSRef.Get<T>("keyPath");
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


        public IDBRequest<int> Count(TKey key) => JSRef.Call<IDBRequest<int>>("count", key);
        public Task<int> CountAsync(TKey key) => Count(key).WaitAsync();
        public IDBRequest<int> Count() => JSRef.Call<IDBRequest<int>>("count");
        public Task<int> CountAsync() => Count().WaitAsync();

        public IDBRequest Add(TValue value, TKey key) => JSRef.Call<IDBRequest>("add", value, key);
        public Task AddAsync(TValue value, TKey key) => Add(value, key).WaitAsync();
        public IDBRequest Put(TValue value, TKey key) => JSRef.Call<IDBRequest>("put", value, key);
        public Task PutAsync(TValue value, TKey key) => Put(value, key).WaitAsync();

        public IDBRequest Add(TValue value) => JSRef.Call<IDBRequest>("add", value);
        public Task AddAsync(TValue value) => Add(value).WaitAsync();
        public IDBRequest Put(TValue value) => JSRef.Call<IDBRequest>("put", value);
        public Task PutAsync(TValue value) => Put(value).WaitAsync();

        public IDBRequest<TValue[]> GetAll() => JSRef.Call<IDBRequest<TValue[]>>("getAll");
        public Task<TValue[]> GetAllAsync() => GetAll().WaitAsync();
        public IDBRequest<TValue> Get(TKey key) => JSRef.Call<IDBRequest<TValue>>("get", key);
        public Task<TValue> GetAsync(TKey key) => Get(key).WaitAsync();
        public IDBRequest Delete(TKey key) => JSRef.Call<IDBRequest>("delete", key);
        public Task DeleteAsync(TKey key) => Delete(key).WaitAsync();
        public IDBRequest Clear() => JSRef.Call<IDBRequest>("clear");
        public Task ClearAsync() => Clear().WaitAsync();
        public IDBRequest<TKey[]> GetAllKeys() => JSRef.Call<IDBRequest<TKey[]>>("getAllKeys");
        public Task<TKey[]> GetAllKeysAsync() => GetAllKeys().WaitAsync();
    }
}
