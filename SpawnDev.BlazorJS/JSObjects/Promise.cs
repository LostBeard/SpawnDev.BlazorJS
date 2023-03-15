using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Promise<TResult> : JSObject {
        public static explicit operator Promise<TResult>(Task<TResult> t) => new Promise<TResult>(t);
        public static explicit operator Promise<TResult>(Func<Task<TResult>> t) => new Promise<TResult>(t);

        public Promise(Func<Task<TResult>> task) : base(NullRef) {
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

        public Promise(Task<TResult> task) : base(NullRef) {
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

        public Promise() : base(NullRef) {
            FromReference(JS.New("Promise", Callback.CreateOne((Function resolveFunc, Function rejectFunc) => {
                ResolveFunc = resolveFunc;
                RejectFunc = rejectFunc;
            })));
        }

        public Promise(Action<Function, Function> executor) : base(JS.New("Promise", Callback.CreateOne(executor))) {

        }

        public override void Dispose() {
            if (IsWrapperDisposed) return;
            ResolveFunc?.Dispose();
            ResolveFunc = null;
            ResolveFunc?.Dispose();
            ResolveFunc = null;
            base.Dispose();
        }

        public Function? ResolveFunc { get; protected set; }
        public Function? RejectFunc { get; protected set; }

        public void ThenCatch(ActionCallback<TResult> thenCallback, ActionCallback<string> catchCallback) {
            JSInterop.SetPromiseThenCatch(this, thenCallback, catchCallback);
        }

        public void Resolve(TResult result) => ResolveFunc.CallVoid(null, result);
        public void Reject() => RejectFunc.CallVoid();
        public void Reject(string reason) => RejectFunc.CallVoid(null, reason);

        public Promise(IJSInProcessObjectReference _ref) : base(_ref) { }

        public Task<TResult> ThenAsync(int timeoutMS = 0) {
            var t = new TaskCompletionSource<TResult>();
            var callbacks = new CallbackGroup();
            var cancellationTokenSource = timeoutMS > 0 ? new CancellationTokenSource() : null;
            ThenCatch(Callback.Create<TResult>((result) => {
                if (t.TrySetResult(result)) {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            }, callbacks), Callback.Create((string error) => {
                if (t.TrySetException(new Exception(error))) {
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
        public Task<TResult> ThenAsync(CancellationToken cancellationToken) {
            var t = new TaskCompletionSource<TResult>();
            var callbacks = new CallbackGroup();
            ThenCatch(Callback.Create<TResult>((result) => {
                if (t.TrySetResult(result)) {
                    callbacks.Dispose();
                }
            }, callbacks), Callback.Create((string error) => {
                if (t.TrySetException(new Exception(error))) {
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


    public class Promise : JSObject {
        public static explicit operator Promise(Task t) => new Promise(t);
        public static explicit operator Promise(Func<Task> t) => new Promise(t);

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

        public Promise() : base(NullRef) {
            FromReference(JS.New("Promise", Callback.CreateOne((Function resolveFunc, Function rejectFunc) => {
                ResolveFunc = resolveFunc;
                RejectFunc = rejectFunc;
            })));
        }

        public Promise(Action<Function, Function> executor) : base(JS.New("Promise", Callback.CreateOne(executor))) {

        }

        public override void Dispose() {
            if (IsWrapperDisposed) return;
            ResolveFunc?.Dispose();
            ResolveFunc = null;
            ResolveFunc?.Dispose();
            ResolveFunc = null;
            base.Dispose();
        }

        public Function? ResolveFunc { get; protected set; }
        public Function? RejectFunc { get; protected set; }

        public void ThenCatch(ActionCallback thenCallback, ActionCallback<string> catchCallback) {
            JSInterop.SetPromiseThenCatch(this, thenCallback, catchCallback);
        }
        public void ThenCatch<TResult>(ActionCallback<TResult> thenCallback, ActionCallback<string> catchCallback) {
            JSInterop.SetPromiseThenCatch(this, thenCallback, catchCallback);
        }

        public void Resolve(object? value) => ResolveFunc.CallVoid(null, value);
        public void Resolve() => ResolveFunc.CallVoid();
        public void Reject() => RejectFunc.CallVoid();
        public void Reject(string reason) => RejectFunc.CallVoid(null, reason);

        public Promise(IJSInProcessObjectReference _ref) : base(_ref) { }

        public Task ThenAsync(int timeoutMS = 0) {
            var t = new TaskCompletionSource();
            var callbacks = new CallbackGroup();
            var cancellationTokenSource = timeoutMS > 0 ? new CancellationTokenSource() : null;
            ThenCatch(Callback.Create(() => {
                if (t.TrySetResult()) {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            }, callbacks), Callback.Create((string error) => {
                if (t.TrySetException(new Exception(error))) {
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
            ThenCatch(Callback.Create(() => {
                if (t.TrySetResult()) {
                    callbacks.Dispose();
                }
            }, callbacks), Callback.Create((string error) => {
                if (t.TrySetException(new Exception(error))) {
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

        public Task<TResult> ThenAsync<TResult>(int timeoutMS = 0) {
            var t = new TaskCompletionSource<TResult>();
            var callbacks = new CallbackGroup();
            var cancellationTokenSource = timeoutMS > 0 ? new CancellationTokenSource() : null;
            ThenCatch(Callback.Create<TResult>((result) => {
                if (t.TrySetResult(result)) {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            }, callbacks), Callback.Create((string error) => {
                if (t.TrySetException(new Exception(error))) {
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

        public Task<TResult> ThenAsync<TResult>(CancellationToken cancellationToken) {
            var t = new TaskCompletionSource<TResult>();
            var callbacks = new CallbackGroup();
            ThenCatch(Callback.Create<TResult>((result) => {
                if (t.TrySetResult(result)) {
                    callbacks.Dispose();
                }
            }, callbacks), Callback.Create((string error) => {
                if (t.TrySetException(new Exception(error))) {
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
