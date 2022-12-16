using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://web.dev/cache-api-quick-guide/
    // https://developer.mozilla.org/en-US/docs/Web/API/Cache
    [JsonConverter(typeof(JSObjectConverter<Cache>))]
    public class Cache : JSObject
    {
        public Cache(IJSInProcessObjectReference _ref) : base(_ref) { }

        public bool IsOpen { get { return JSRef != null; } }
        public string Name { get; private set; } = "";

        public static async Task<Cache> OpenCache(string name)
        {
            var ret = await JS.CallAsync<Cache>("caches.open", name);
            return ret;
        }

        public static async Task<List<string>> CacheNames()
        {
            var ret = await JS.CallAsync<List<string>>("caches.keys");
            return ret;
        }

        public async Task<List<string>> CacheKeys()
        {
            var ret = new List<string>();
            var tmp = await JSRef.CallAsync<Request[]>("keys");
            //var cnt = tmp.GetProperty<int>("length");
            foreach (var r in tmp)
            {
                var url = r.Url;
                ret.Add(url);
                r.Dispose();
            }
            return ret;
        }

        public Task<Response> Match(string url)
        {
            var t = new TaskCompletionSource<Response>();
            Match(url, (r) => t.TrySetResult(r));
            return t.Task;
        }

        // use callbacks and promise syntax to avoid inability to catch DotNet exception when Match returns an undefined value to the promise then callback
        // retest - not tested since Blazor DotNet 3
        public void Match(string url, Action<Response> callback)
        {
            var callbackGroup = new CallbackGroup();
            var promise = JSRef.Call<IJSInProcessObjectReference>("match", url);
            promise.CallVoid("then", Callback.Create((Response response) => {
                try
                {
                    callback(response);
                }
                catch (Exception)
                {
                    callback(null);
                }
                promise.Dispose();
                callbackGroup.Dispose();
            }, callbackGroup));
            promise.CallVoid("catch", Callback.Create(() => {
                callback(null);
                promise.Dispose();
                callbackGroup.Dispose();
            }, callbackGroup));
        }

        public async Task<bool> Has(string url)
        {
            return await JSRef.InvokeAsync<bool>("has", url);
        }

        public void Put(string url, Response response)
        {
            JSRef.InvokeVoid("put", url, response);
        }

        public void Delete(string url)
        {
            JSRef.InvokeVoid("delete", url);
        }

        public async Task AddAll(IEnumerable<string> urls)
        {

        }
    }
}
