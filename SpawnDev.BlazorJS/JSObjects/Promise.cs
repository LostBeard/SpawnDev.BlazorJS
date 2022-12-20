using Microsoft.JSInterop;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Promise>))]
    public class Promise : JSObject
    {
        public Promise(Action<Function, Function> handler) : base(JS.New("Promise", Callback.Create(handler))) {  }
        public Promise(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Promise Then(Callback callback) { JSRef.CallVoid("then", callback); return this; }
        public Promise Catch(Callback callback) { JSRef.CallVoid("catch", callback); return this; }
        public Task<T> ThenAsync<T>()
        {
            var callbacks = new CallbackGroup();
            var t = new TaskCompletionSource<T>();
            Then(Callback.Create<T>((e) => {
                callbacks.Dispose();
                t.SetResult(e);
            }, callbacks));
            Catch(Callback.Create(() => {
                callbacks.Dispose();
                t.TrySetException(new Exception("Failed"));
            }, callbacks));
            return t.Task;
        }
        public Task ThenAsync()
        {
            var callbacks = new CallbackGroup();
            var t = new TaskCompletionSource();
            Then(Callback.Create(() => {
                callbacks.Dispose();
                t.SetResult();
            }, callbacks));
            Catch(Callback.Create(() => {
                callbacks.Dispose();
                t.TrySetException(new Exception("Failed"));
            }, callbacks));
            return t.Task;
        }
    }
}
