using Microsoft.JSInterop;
using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Promise>))]
    public class Promise : JSObject
    {
        public Promise(Action<Function, Function> handler) : base(JS.New("Promise", Callback.Create(handler))) { }
        public Promise(IJSInProcessObjectReference _ref) : base(_ref) { }
        //public Promise Then(Callback callback) { JSRef.CallVoid("then", callback); return this; }
        //public void Catch(Callback callback) { JSRef.CallVoid("catch", callback); }
        
        // Some PromiseLike types have a "then" method but not a "catch" method... the return value for the "then" method will return an object with a "catch" method
        public Task<T> ThenAsync<T>(int timeoutMS = 0)
        {
            var t = new TaskCompletionSource<T>();
            var callbacks = new CallbackGroup();
            var cancellationTokenSource = timeoutMS > 0 ? new CancellationTokenSource() : null;
            using var promise = JSRef.Call<IJSInProcessObjectReference>("then", Callback.Create<T>((e) =>
            {
                if (t.TrySetResult(e))
                {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            }, callbacks));
            promise.CallVoid("catch", Callback.Create(() =>
            {
                if (t.TrySetException(new Exception("Failed")))
                {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            }, callbacks));
            cancellationTokenSource?.Token.Register(() =>
            {
                if (t.TrySetException(new Exception("Timed out")))
                {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            });
            cancellationTokenSource?.CancelAfter(timeoutMS);
            return t.Task;
        }
        public Task<T> ThenAsync<T>(CancellationToken cancellationToken)
        {
            var t = new TaskCompletionSource<T>();
            var callbacks = new CallbackGroup();
            using var promise = JSRef.Call<IJSInProcessObjectReference>("then", Callback.Create<T>((e) =>
            {
                if (t.TrySetResult(e))
                {
                    callbacks.Dispose();
                }
            }, callbacks));
            promise.CallVoid("catch", Callback.Create(() =>
            {
                if (t.TrySetException(new Exception("Failed")))
                {
                    callbacks.Dispose();
                }
            }, callbacks));
            if (cancellationToken != CancellationToken.None)
            {
                cancellationToken.Register(() =>
                {
                    if (t.TrySetException(new Exception("Timed out")))
                    {
                        callbacks.Dispose();
                    }
                });
            }
            return t.Task;
        }
        public Task ThenAsync(int timeoutMS = 0)
        {
            var t = new TaskCompletionSource();
            var callbacks = new CallbackGroup();
            var cancellationTokenSource = timeoutMS > 0 ? new CancellationTokenSource() : null;
            using var promise = JSRef.Call<IJSInProcessObjectReference>("then", Callback.Create(() =>
            {
                if (t.TrySetResult())
                {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            }, callbacks));
            promise.CallVoid("catch", Callback.Create(() =>
            {
                if (t.TrySetException(new Exception("Failed")))
                {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            }, callbacks));
            cancellationTokenSource?.Token.Register(() =>
            {
                if (t.TrySetException(new Exception("Timed out")))
                {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            });
            cancellationTokenSource?.CancelAfter(timeoutMS);
            return t.Task;
        }
        public Task ThenAsync(CancellationToken cancellationToken)
        {
            var t = new TaskCompletionSource();
            var callbacks = new CallbackGroup();
            using var promise = JSRef.Call<IJSInProcessObjectReference>("then", Callback.Create(() =>
            {
                if (t.TrySetResult())
                {
                    callbacks.Dispose();
                }
            }, callbacks));
            promise.CallVoid("catch", Callback.Create(() =>
            {
                if (t.TrySetException(new Exception("Failed")))
                {
                    callbacks.Dispose();
                }
            }, callbacks));
            if (cancellationToken != CancellationToken.None)
            {
                cancellationToken.Register(() =>
                {
                    if (t.TrySetException(new Exception("Timed out")))
                    {
                        callbacks.Dispose();
                    }
                });
            }
            return t.Task;
        }
    }
}
