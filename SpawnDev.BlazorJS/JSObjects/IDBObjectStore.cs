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
            return JSRef.Call<IDBRequest>("add", value, key);
        }

        public Task AddAsync(object value, string key)
        {
            return IDBRequest.ToAsync(JSRef.Call<IDBRequest>("add", value, key));
        }

        public IDBRequest Put(object value, string key)
        {
            return JSRef.Call<IDBRequest>("put", value, key);
        }

        public Task PutAsync(object value, string key)
        {
            return IDBRequest.ToAsync(JSRef.Call<IDBRequest>("put", value, key));
        }

        public IDBRequest GetAll()
        {
            return JSRef.Call<IDBRequest>("getAll");
        }

        public Task<List<T>> GetAllAsync<T>()
        {
            var ret = new List<T>();
            var request = GetAll();
            var t = new TaskCompletionSource<List<T>>();
            request.OnError((arg0) => { t.SetException(new Exception("IDBRequest failed. Exception info TODO")); });
            request.OnSuccess<IJSInProcessObjectReference>((result) => {
                var length = result.Get<int>("length");
                for (var i = 0; i < length; i++)
                {
                    ret.Add(result.Get<T>(i));
                }
                result.Dispose();
                t.TrySetResult(ret);
            });
            return t.Task;
        }

        public IDBRequest Get(string key)
        {
            return JSRef.Call<IDBRequest>("get", key);
        }

        public Task<T> GetAsync<T>(string key)
        {
            return IDBRequest.ToAsync<T>(JSRef.Call<IDBRequest>("get", key));
        }

        public IDBRequest Delete(string key)
        {
            return JSRef.Call<IDBRequest>("delete", key);
        }

        public Task DeleteAsync(string key)
        {
            return IDBRequest.ToAsync(JSRef.Call<IDBRequest>("delete", key));
        }

        public IDBRequest Clear()
        {
            return JSRef.Call<IDBRequest>("clear");
        }

        public Task ClearAsync()
        {
            return IDBRequest.ToAsync(JSRef.Call<IDBRequest>("clear"));
        }

        public IDBRequest GetAllKeys()
        {
            return JSRef.Call<IDBRequest>("getAllKeys");
        }

        public Task<string[]> GetAllKeysAsync()
        {
            return IDBRequest.ToAsync<string[]>(JSRef.Call<IDBRequest>("getAllKeys"));
        }
    }
}
