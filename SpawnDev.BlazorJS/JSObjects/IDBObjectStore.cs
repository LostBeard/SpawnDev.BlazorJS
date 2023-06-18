using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    // https://developer.mozilla.org/en-US/docs/Web/API/IDBObjectStore
    public class IDBObjectStore : JSObject
    {
        public IDBRequest<int> Count(string key) => JSRef.Call<IDBRequest<int>>("count", key);
        public Task<int> CountAsync(string key) => IDBRequest.ToAsync(Count(key));
        public IDBRequest<int> Count() => JSRef.Call<IDBRequest<int>>("count");
        public Task<int> CountAsync() => IDBRequest.ToAsync(Count());

        public IDBObjectStore(IJSInProcessObjectReference _ref) : base(_ref) { }
        public IDBRequest Add(object value, string key) => JSRef.Call<IDBRequest>("add", value, key);
        public Task AddAsync(object value, string key) => IDBRequest.ToVoidAsync(Add(value, key));
        public IDBRequest Put(object value, string key) => JSRef.Call<IDBRequest>("put", value, key);
        public Task PutAsync(object value, string key) => IDBRequest.ToVoidAsync(Put(value, key));

        public IDBRequest Add(object value) => JSRef.Call<IDBRequest>("add", value);
        public Task AddAsync(object value) => IDBRequest.ToVoidAsync(Add(value));
        public IDBRequest Put(object value) => JSRef.Call<IDBRequest>("put", value);
        public Task PutAsync(object value) => IDBRequest.ToVoidAsync(Put(value));

        public IDBRequest<T[]> GetAll<T>() => JSRef.Call<IDBRequest<T[]>>("getAll");
        public Task<T[]> GetAllAsync<T>() => IDBRequest.ToAsync(GetAll<T>());
        public IDBRequest<T> Get<T>(string key) => JSRef.Call<IDBRequest<T>>("get", key);
        public Task<T> GetAsync<T>(string key) => IDBRequest.ToAsync(Get<T>(key));
        public IDBRequest Delete(string key) => JSRef.Call<IDBRequest>("delete", key);
        public Task DeleteAsync(string key) => IDBRequest.ToVoidAsync(Delete(key));
        public IDBRequest Clear() => JSRef.Call<IDBRequest>("clear");
        public Task ClearAsync() => IDBRequest.ToVoidAsync(Clear());
        public IDBRequest<string[]> GetAllKeys() => JSRef.Call<IDBRequest<string[]>>("getAllKeys");
        public Task<string[]> GetAllKeysAsync() => IDBRequest.ToAsync(GetAllKeys());
    }
    public class IDBObjectStore<TKey, TValue> : JSObject
    {
        public IDBRequest<int> Count(TKey key) => JSRef.Call<IDBRequest<int>>("count", key);
        public Task<int> CountAsync(TKey key) => IDBRequest.ToAsync(Count(key));
        public IDBRequest<int> Count() => JSRef.Call<IDBRequest<int>>("count");
        public Task<int> CountAsync() => IDBRequest.ToAsync(Count());

        public IDBObjectStore(IJSInProcessObjectReference _ref) : base(_ref) { }
        public IDBRequest Add(TValue value, TKey key) => JSRef.Call<IDBRequest>("add", value, key);
        public Task AddAsync(TValue value, TKey key) => IDBRequest.ToVoidAsync(Add(value, key));
        public IDBRequest Put(TValue value, TKey key) => JSRef.Call<IDBRequest>("put", value, key);
        public Task PutAsync(TValue value, TKey key) => IDBRequest.ToVoidAsync(Put(value, key));

        public IDBRequest Add(TValue value) => JSRef.Call<IDBRequest>("add", value);
        public Task AddAsync(TValue value) => IDBRequest.ToVoidAsync(Add(value));
        public IDBRequest Put(TValue value) => JSRef.Call<IDBRequest>("put", value);
        public Task PutAsync(TValue value) => IDBRequest.ToVoidAsync(Put(value));

        public IDBRequest<TValue[]> GetAll() => JSRef.Call<IDBRequest<TValue[]>>("getAll");
        public Task<TValue[]> GetAllAsync() => IDBRequest.ToAsync(GetAll());
        public IDBRequest<TValue> Get(TKey key) => JSRef.Call<IDBRequest<TValue>>("get", key);
        public Task<TValue> GetAsync(TKey key) => IDBRequest.ToAsync(Get(key));
        public IDBRequest Delete(TKey key) => JSRef.Call<IDBRequest>("delete", key);
        public Task DeleteAsync(TKey key) => IDBRequest.ToVoidAsync(Delete(key));
        public IDBRequest Clear() => JSRef.Call<IDBRequest>("clear");
        public Task ClearAsync() => IDBRequest.ToVoidAsync(Clear());
        public IDBRequest<TKey[]> GetAllKeys() => JSRef.Call<IDBRequest<TKey[]>>("getAllKeys");
        public Task<TKey[]> GetAllKeysAsync() => IDBRequest.ToAsync(GetAllKeys());
    }
}
