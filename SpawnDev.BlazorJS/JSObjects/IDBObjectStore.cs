using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/IDBObjectStore
    [JsonConverter(typeof(JSObjectConverter<IDBObjectStore>))]
    public class IDBObjectStore : JSObject
    {
        public IDBObjectStore(IJSInProcessObjectReference _ref) : base(_ref) { }

        public IDBRequest Add(object value, string key)
        {
            return _ref.Call<IDBRequest>("add", value, key);
        }

        public Task AddAsync(object value, string key)
        {
            return IDBRequest.ToAsync(_ref.Call<IDBRequest>("add", value, key));
        }

        public IDBRequest Put(object value, string key)
        {
            return _ref.Call<IDBRequest>("put", value, key);
        }

        public Task PutAsync(object value, string key)
        {
            return IDBRequest.ToAsync(_ref.Call<IDBRequest>("put", value, key));
        }

        public IDBRequest GetAll()
        {
            return _ref.Call<IDBRequest>("getAll");
        }

        public Task<List<T>> GetAllAsync<T>()
        {
            var ret = new List<T>();
            var request = GetAll();
            var t = new TaskCompletionSource<List<T>>();
            request.OnError((arg0) => { t.SetException(new Exception("IDBRequest failed. Exception info TODO")); });
            request.OnSuccess<JSObject>((result) => {
                var length = result._ref.Get<int>("length");
                for (var i = 0; i < length; i++)
                {
                    ret.Add(result._ref.Get<T>(i));
                }
                result.Dispose();
                t.TrySetResult(ret);
            });
            return t.Task;
        }

        public IDBRequest Get(string key)
        {
            return _ref.Call<IDBRequest>("get", key);
        }

        public Task<T> GetAsync<T>(string key)
        {
            return IDBRequest.ToAsync<T>(_ref.Call<IDBRequest>("get", key));
        }

        public IDBRequest Delete(string key)
        {
            return _ref.Call<IDBRequest>("delete", key);
        }

        public Task DeleteAsync(string key)
        {
            return IDBRequest.ToAsync(_ref.Call<IDBRequest>("delete", key));
        }

        public IDBRequest Clear()
        {
            return _ref.Call<IDBRequest>("clear");
        }

        public Task ClearAsync()
        {
            return IDBRequest.ToAsync(_ref.Call<IDBRequest>("clear"));
        }

        public IDBRequest GetAllKeys()
        {
            return _ref.Call<IDBRequest>("getAllKeys");
        }

        public Task<string[]> GetAllKeysAsync()
        {
            return IDBRequest.ToAsync<string[]>(_ref.Call<IDBRequest>("getAllKeys"));
        }
    }
}
