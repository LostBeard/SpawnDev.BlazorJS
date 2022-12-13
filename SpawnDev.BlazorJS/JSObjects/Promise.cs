using Microsoft.JSInterop;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Promise>))]
    public class Promise : JSObject
    {
        public Promise() : base(JS.New("Promise")) { }
        public Promise(IJSInProcessObjectReference _ref) : base(_ref) { }
        public void Then(Callback callback) { JSRef.CallVoid("then", callback); }
        public void Catch(Callback callback) { JSRef.CallVoid("catch", callback); }
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
