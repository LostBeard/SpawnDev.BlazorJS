using Microsoft.JSInterop;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Promise>))]
    public class Promise : JSObject
    {
        public Promise(Action<Function, Function> handler) : base(JS.New("Promise", Callback.Create(handler))) { }
        public Promise(IJSInProcessObjectReference _ref) : base(_ref) { }
        //public Promise Then(Callback callback) { JSRef.CallVoid("then", callback); return this; }
        //public Promise Catch(Callback callback) { JSRef.CallVoid("catch", callback); return this; }
        //public Task<T> ThenAsync<T>()
        //{
        //    var callbacks = new CallbackGroup();
        //    var t = new TaskCompletionSource<T>();
        //    Then(Callback.Create<T>((e) =>
        //    {
        //        callbacks.Dispose();
        //        t.TrySetResult(e);
        //    }, callbacks));
        //    Catch(Callback.Create(() =>
        //    {
        //        callbacks.Dispose();
        //        t.TrySetException(new Exception("Failed"));
        //    }, callbacks));
        //    return t.Task;
        //}
        //public Task ThenAsync()
        //{
        //    var callbacks = new CallbackGroup();
        //    var t = new TaskCompletionSource();
        //    Then(Callback.Create(() =>
        //    {
        //        callbacks.Dispose();
        //        t.SetResult();
        //    }, callbacks));
        //    Catch(Callback.Create(() =>
        //    {
        //        callbacks.Dispose();
        //        t.TrySetException(new Exception("Failed"));
        //    }, callbacks));
        //    return t.Task;
        //}

        // Some PromiseLike types have a "then" method but not a "catch" method... the return value for the "then" method will return an object with a "catch" method
        public Task<T> ThenAsync<T>(int timeoutMS = 0)
        {
            var callbacks = new CallbackGroup();
            var t = new TaskCompletionSource<T>();
            // TODO - if timeoutMS > 0 use cancellation token
            using var promise = JSRef.Call<IJSInProcessObjectReference>("then", Callback.Create<T>((e) =>
            {
                callbacks.Dispose();
                t.TrySetResult(e);
            }, callbacks));
            promise.CallVoid("catch", Callback.Create(() =>
            {
                callbacks.Dispose();
                t.TrySetException(new Exception("Failed"));
            }, callbacks));
            return t.Task;
        }
        public Task ThenAsync()
        {
            var callbacks = new CallbackGroup();
            var t = new TaskCompletionSource();
            using var promise = JSRef.Call<IJSInProcessObjectReference>("then", Callback.Create(() =>
            {
                callbacks.Dispose();
                t.TrySetResult();
            }, callbacks));
            promise.CallVoid("catch", Callback.Create(() =>
            {
                callbacks.Dispose();
                t.TrySetException(new Exception("Failed"));
            }, callbacks));
            return t.Task;
        }
    }
}
