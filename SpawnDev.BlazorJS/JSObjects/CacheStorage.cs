using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    // https://web.dev/cache-api-quick-guide/
    public class CacheStorage : JSObject {
        public CacheStorage(IJSInProcessObjectReference _ref) : base(_ref) { }

        public bool IsOpen { get { return JSRef != null; } }
        public string Name { get; private set; } = "";

        public static Task<CacheStorage> OpenCache(string name) => JS.CallAsync<CacheStorage>("caches.open", name);

        public static Task<List<string>> CacheNames() => JS.CallAsync<List<string>>("caches.keys");

        public async Task<List<string>> CacheKeys() {
            var ret = new List<string>();
            var tmp = await JSRef.CallAsync<Request[]>("keys");
            //var cnt = tmp.GetProperty<int>("length");
            foreach (var r in tmp) {
                var url = r.Url;
                ret.Add(url);
                r.Dispose();
            }
            return ret;
        }

        public Task<Response> Match(string path) {
            var t = new TaskCompletionSource<Response>();
            Match(path, (r) => t.TrySetResult(r));
            return t.Task;
        }

        // use callbacks and promise syntax to avoid inability to catch DotNet exception when Match returns an undefined value to the promise then callback
        // retest - not tested since Blazor DotNet 3
        public void Match(string path, Action<Response> callback) {
            var callbackGroup = new CallbackGroup();
            var promise = JSRef.Call<IJSInProcessObjectReference>("match", path);
            promise.CallVoid("then", Callback.Create((Response response) => {
                try {
                    callback(response);
                }
                catch (Exception) {
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

        public Task<bool> Has(string url) => JSRef.CallAsync<bool>("has", url);

        public void Put(string url, Response response) => JSRef.CallVoid("put", url, response);

        public void Delete(string url) => JSRef.CallVoid("delete", url);

        //public async Task AddAll(IEnumerable<string> urls) {

        //}
    }
}
