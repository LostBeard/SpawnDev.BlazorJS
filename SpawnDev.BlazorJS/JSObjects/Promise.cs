using Microsoft.JSInterop;
using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects {
    [JsonConverter(typeof(JSObjectConverter<Promise>))]
    public class Promise<TReturnType> : Promise {
        public Promise(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Promise(Func<Task<TReturnType>> task) : base(NullRef) {
            FromReference(JS.New("Promise", Callback.CreateOne((Function resolveFunc, Function rejectFunc) => {
                ResolveFunc = resolveFunc;
                RejectFunc = rejectFunc;
                task().ContinueWith(t => {
                    if (t.IsFaulted) {
                        Exception ex = t.Exception;
                        while (ex is AggregateException && ex.InnerException != null) ex = ex.InnerException;
                        Reject(ex.Message);
                    }
                    else if (t.IsCanceled) {
                        Reject("Cancelled");
                    }
                    else {
                        Resolve(t.Result);
                    }
                });
            })));
        }

        public static explicit operator Promise<TReturnType>(Task<TReturnType> t)=> new Promise<TReturnType>(t);

        public static explicit operator Promise<TReturnType>(Func<Task<TReturnType>> t) => new Promise<TReturnType>(t);

        public Promise(Task<TReturnType> task) : base(NullRef) {
            FromReference(JS.New("Promise", Callback.CreateOne((Function resolveFunc, Function rejectFunc) => {
                ResolveFunc = resolveFunc;
                RejectFunc = rejectFunc;
                task.ContinueWith(t => {
                    if (t.IsFaulted) {
                        Exception ex = t.Exception;
                        while (ex is AggregateException && ex.InnerException != null) ex = ex.InnerException;
                        Reject(ex.Message);
                    }
                    else if (t.IsCanceled) {
                        Reject("Cancelled");
                    }
                    else {
                        Resolve(t.Result);
                    }
                });
            })));
        }

    }
    [JsonConverter(typeof(JSObjectConverter<Promise>))]
    public class Promise : JSObject {
        public static explicit operator Promise(Task t) => new Promise(t);
        //public static explicit operator Promise(Func<Task> t) => new Promise(t);

        public static implicit operator Promise(Func<Task> t) => new Promise(t);

        public Promise(Func<Task> task) : base(NullRef) {
            FromReference(JS.New("Promise", Callback.CreateOne((Function resolveFunc, Function rejectFunc) => {
                ResolveFunc = resolveFunc;
                RejectFunc = rejectFunc;
                task().ContinueWith(t => {
                    if (t.IsFaulted) {
                        Exception ex = t.Exception;
                        while (ex is AggregateException && ex.InnerException != null) ex = ex.InnerException;
                        Reject(ex.Message);
                    }
                    else if (t.IsCanceled) {
                        Reject("Cancelled");
                    }
                    else {
                        Resolve();
                    }
                });
            })));
        }
        public Promise(Task task) : base(NullRef) {
            FromReference(JS.New("Promise", Callback.CreateOne((Function resolveFunc, Function rejectFunc) => {
                ResolveFunc = resolveFunc;
                RejectFunc = rejectFunc;
                task.ContinueWith(t => {
                    if (t.IsFaulted) {
                        Exception ex = t.Exception;
                        while (ex is AggregateException && ex.InnerException != null) ex = ex.InnerException;
                        Reject(ex.Message);
                    }
                    else if (t.IsCanceled) {
                        Reject("Cancelled");
                    }
                    else {
                        Resolve();
                    }
                });
            })));
        }
        public Promise(Action<Function, Function> executor) : base(JS.New("Promise", Callback.CreateOne(executor))) { }

        public static Promise FromTask(Func<Task> task) {
            var p = new Promise();
            task().ContinueWith(t => {
                if (t.IsFaulted) {
                    Exception ex = t.Exception;
                    while (ex is AggregateException && ex.InnerException != null) ex = ex.InnerException;
                    p.Reject(ex.Message);
                }
                else if (t.IsCanceled) {
                    p.Reject("Cancelled");
                }
                else {
                    p.Resolve();
                }
            });
            return p;
        }

        public static Promise FromTask<T>(Func<Task<T>> task) {
            var p = new Promise();
            task().ContinueWith(t => {
                if (t.IsFaulted) {
                    Exception ex = t.Exception;
                    while (ex is AggregateException && ex.InnerException != null) ex = ex.InnerException;
                    p.Reject(ex.Message);
                }
                else if (t.IsCanceled) {
                    p.Reject("Cancelled");
                }
                else {
                    p.Resolve(t.Result);
                }
            });
            return p;
        }

        public static Promise FromTask(Task task) {
            var p = new Promise();
            task.ContinueWith(t => {
                if (t.IsFaulted) {
                    Exception ex = t.Exception;
                    while (ex is AggregateException && ex.InnerException != null) ex = ex.InnerException;
                    p.Reject(ex.Message);
                }
                else if (t.IsCanceled) {
                    p.Reject("Cancelled");
                }
                else {
                    p.Resolve();
                }
            });
            return p;
        }

        public static Promise FromTask<T>(Task<T> task) {
            var p = new Promise();
            task.ContinueWith(t => {
                if (t.IsFaulted) {
                    Exception ex = t.Exception;
                    while (ex is AggregateException && ex.InnerException != null) ex = ex.InnerException;
                    p.Reject(ex.Message);
                }
                else if (t.IsCanceled) {
                    p.Reject("Cancelled");
                }
                else {
                    p.Resolve(t.Result);
                }
            });
            return p;
        }

        public Promise() : base(NullRef) {
            FromReference(JS.New("Promise", Callback.CreateOne((Function resolveFunc, Function rejectFunc) => {
                ResolveFunc = resolveFunc;
                RejectFunc = rejectFunc;
            })));
        }

        public Function? ResolveFunc { get; protected set; }
        public Function? RejectFunc { get; protected set; }

        public void Resolve() => ResolveFunc.CallVoid();
        public void Reject() => RejectFunc.CallVoid();
        public void Resolve(object? value) => ResolveFunc.CallVoid(null, value);
        public void Reject(string reason) => RejectFunc.CallVoid(null, reason);

        public Promise(IJSInProcessObjectReference _ref) : base(_ref) { }

        // Some PromiseLike types have a "then" method but not a "catch" method... the return value for the "then" method will return an object with a "catch" method
        public Task<T> ThenAsync<T>(int timeoutMS = 0) {
            var t = new TaskCompletionSource<T>();
            var callbacks = new CallbackGroup();
            var cancellationTokenSource = timeoutMS > 0 ? new CancellationTokenSource() : null;
            using var promise = JSRef.Call<IJSInProcessObjectReference>("then", Callback.Create<T>((e) => {
                if (t.TrySetResult(e)) {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            }, callbacks));
            promise.CallVoid("catch", Callback.Create(() => {
                if (t.TrySetException(new Exception("Failed"))) {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            }, callbacks));
            cancellationTokenSource?.Token.Register(() => {
                if (t.TrySetException(new Exception("Timed out"))) {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            });
            cancellationTokenSource?.CancelAfter(timeoutMS);
            return t.Task;
        }
        public Task<T> ThenAsync<T>(CancellationToken cancellationToken) {
            var t = new TaskCompletionSource<T>();
            var callbacks = new CallbackGroup();
            using var promise = JSRef.Call<IJSInProcessObjectReference>("then", Callback.Create<T>((e) => {
                if (t.TrySetResult(e)) {
                    callbacks.Dispose();
                }
            }, callbacks));
            promise.CallVoid("catch", Callback.Create(() => {
                if (t.TrySetException(new Exception("Failed"))) {
                    callbacks.Dispose();
                }
            }, callbacks));
            if (cancellationToken != CancellationToken.None) {
                cancellationToken.Register(() => {
                    if (t.TrySetException(new Exception("Timed out"))) {
                        callbacks.Dispose();
                    }
                });
            }
            return t.Task;
        }
        public Task ThenAsync(int timeoutMS = 0) {
            var t = new TaskCompletionSource();
            var callbacks = new CallbackGroup();
            var cancellationTokenSource = timeoutMS > 0 ? new CancellationTokenSource() : null;
            using var promise = JSRef.Call<IJSInProcessObjectReference>("then", Callback.Create(() => {
                if (t.TrySetResult()) {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            }, callbacks));
            promise.CallVoid("catch", Callback.Create(() => {
                if (t.TrySetException(new Exception("Failed"))) {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            }, callbacks));
            cancellationTokenSource?.Token.Register(() => {
                if (t.TrySetException(new Exception("Timed out"))) {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            });
            cancellationTokenSource?.CancelAfter(timeoutMS);
            return t.Task;
        }
        public Task ThenAsync(CancellationToken cancellationToken) {
            var t = new TaskCompletionSource();
            var callbacks = new CallbackGroup();
            using var promise = JSRef.Call<IJSInProcessObjectReference>("then", Callback.Create(() => {
                if (t.TrySetResult()) {
                    callbacks.Dispose();
                }
            }, callbacks));
            promise.CallVoid("catch", Callback.Create(() => {
                if (t.TrySetException(new Exception("Failed"))) {
                    callbacks.Dispose();
                }
            }, callbacks));
            if (cancellationToken != CancellationToken.None) {
                cancellationToken.Register(() => {
                    if (t.TrySetException(new Exception("Timed out"))) {
                        callbacks.Dispose();
                    }
                });
            }
            return t.Task;
        }
    }
}
