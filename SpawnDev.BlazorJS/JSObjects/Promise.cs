using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class Promise<TResult> : JSObject
    {
        public static explicit operator Promise<TResult>(Task<TResult> t) => new Promise<TResult>(t);
        public static explicit operator Promise<TResult>(Func<Task<TResult>> t) => new Promise<TResult>(t);

        public Promise(Func<Task<TResult>> task) : base(default!)
        {
            FromReference(JS.New("Promise", Callback.CreateOne((Function resolveFunc, Function rejectFunc) =>
            {
                task().ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        rejectFunc.CallVoid();
                    }
                    else if (t.IsCanceled)
                    {
                        rejectFunc.CallVoid();
                    }
                    else
                    {
                        resolveFunc.CallVoid(null, t.Result);
                    }
                    resolveFunc.Dispose();
                    rejectFunc.Dispose();
                });
            })));
        }

        public Promise(Task<TResult> task) : base(default!)
        {
            FromReference(JS.New("Promise", Callback.CreateOne((Function resolveFunc, Function rejectFunc) =>
            {
                task.ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        rejectFunc.CallVoid();
                    }
                    else if (t.IsCanceled)
                    {
                        rejectFunc.CallVoid();
                    }
                    else
                    {
                        resolveFunc.CallVoid(null, t.Result);
                    }
                    resolveFunc.Dispose();
                    rejectFunc.Dispose();
                });
            })));
        }

        public Promise(Action<Function, Function> executor) : base(JS.New("Promise", Callback.CreateOne(executor))) { }
        public Promise(Action<Function> executor) : base(JS.New("Promise", Callback.CreateOne(executor))) { }

        public void Then(ActionCallback thenCallback, ActionCallback catchCallback) => JSRef!.CallVoid("then", thenCallback, catchCallback);
        public void Then(ActionCallback<TResult> thenCallback, ActionCallback catchCallback) => JSRef!.CallVoid("then", thenCallback, catchCallback);
        public void Then<TCatch>(ActionCallback<TResult> thenCallback, ActionCallback<TCatch> catchCallback) => JSRef!.CallVoid("then", thenCallback, catchCallback);

        public Promise(IJSInProcessObjectReference _ref) : base(_ref) { }

        public Task<TResult> ThenAsync(int timeoutMS = 0)
        {
            var t = new TaskCompletionSource<TResult>();
            var callbacks = new CallbackGroup();
            var cancellationTokenSource = timeoutMS > 0 ? new CancellationTokenSource() : null;
            Then(callbacks.Add(Callback.Create<TResult>((result) =>
            {
                if (t.TrySetResult(result))
                {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            })), callbacks.Add(Callback.Create((Error? error) =>
            {
                var ex = Promise.UnknownErrorToException(error);
                if (t.TrySetException(ex))
                {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            })));
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
        public Task<TResult> ThenAsync(CancellationToken cancellationToken)
        {
            var t = new TaskCompletionSource<TResult>();
            var callbacks = new CallbackGroup();
            Then(callbacks.Add(Callback.Create<TResult>((result) =>
            {
                if (t.TrySetResult(result))
                {
                    callbacks.Dispose();
                }
            })), callbacks.Add(Callback.Create((Error? error) =>
            {
                var ex = Promise.UnknownErrorToException(error);
                if (t.TrySetException(ex))
                {
                    callbacks.Dispose();
                }
            })));
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

    public class Promise : JSObject
    {
        public static explicit operator Promise(Task t) => new Promise(t);
        public static explicit operator Promise(Func<Task> t) => new Promise(t);

        public Promise(Func<Task> task) : base(default!)
        {
            FromReference(JS.New("Promise", Callback.CreateOne((Function resolveFunc, Function rejectFunc) =>
            {
                task().ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        rejectFunc.CallVoid();
                    }
                    else if (t.IsCanceled)
                    {
                        rejectFunc.CallVoid();
                    }
                    else
                    {
                        if (t.GetType().IsGenericType)
                        {
                            var result = t.GetResult();
                            resolveFunc.ApplyVoid(null, new object[] { result });
                        }
                        else
                        {
                            resolveFunc.CallVoid();
                        }
                    }
                    resolveFunc.Dispose();
                    rejectFunc.Dispose();
                });
            })));
        }

        public Promise(Task task) : base(default!)
        {
            FromReference(JS.New("Promise", Callback.CreateOne((Function resolveFunc, Function rejectFunc) =>
            {
                task.ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        rejectFunc.CallVoid();
                    }
                    else if (t.IsCanceled)
                    {
                        rejectFunc.CallVoid();
                    }
                    else
                    {
                        if (task.GetType().IsGenericType)
                        {
                            var result = task.GetResult();
                            resolveFunc.ApplyVoid(null, new object[] { result });
                        }
                        else
                        {
                            resolveFunc.CallVoid();
                        }
                    }
                    resolveFunc.Dispose();
                    rejectFunc.Dispose();
                });
            })));
        }

        public Promise(Action<Function, Function> executor) : base(JS.New("Promise", Callback.CreateOne(executor))) { }
        public Promise(Action<Function> executor) : base(JS.New("Promise", Callback.CreateOne(executor))) { }

        public Promise(IJSInProcessObjectReference _ref) : base(_ref) { }

        public void ThenCatch<TError>(ActionCallback thenCallback, ActionCallback<TError> catchCallback) => JSRef!.CallVoid("then", thenCallback, catchCallback);
        public void Then(ActionCallback thenCallback, ActionCallback catchCallback) => JSRef!.CallVoid("then", thenCallback, catchCallback);
        public void Then<TResult>(ActionCallback<TResult> thenCallback, ActionCallback catchCallback) => JSRef!.CallVoid("then", thenCallback, catchCallback);
        public void ThenCatch<TResult, TError>(ActionCallback<TResult> thenCallback, ActionCallback<TError> catchCallback) => JSRef!.CallVoid("then", thenCallback, catchCallback);


        /// <summary>
        /// Handles converting a value from a Promise catch event into an exception.<br/>
        /// These are usually of the type `Error`, but can be anything
        /// </summary>
        internal static Exception UnknownErrorToException(Error? error)
        {
            Exception? ex = null;
            if (error != null)
            {
                var typeofError = error.JSRef!.TypeOf();
                switch (typeofError)
                {
                    case "string":
                        {
                            var message = error.JSRefAs<string>();
                            ex = new Exception(message);
                            break;
                        }
                    case "object":
                        {
                            string? message = null;
                            if (error.JSRef!.TypeOf("toString") == "function")
                            {
                                message = error.ToString();
                            }
                            if (string.IsNullOrEmpty(message))
                            {
                                message = error.Message;
                            }
                            if (!string.IsNullOrEmpty(message))
                            {
                                ex = new Exception(message);
                            }
                            break;
                        }
                }

            }
            ex ??= new Exception("Unknown error");
            return ex;
        }

        public Task ThenAsync(int timeoutMS = 0)
        {
            var t = new TaskCompletionSource();
            var callbacks = new CallbackGroup();
            var cancellationTokenSource = timeoutMS > 0 ? new CancellationTokenSource() : null;
            ThenCatch(callbacks.Add(Callback.Create(() =>
            {
                if (t.TrySetResult())
                {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            })), callbacks.Add(Callback.Create((Error? error) =>
            {
                var ex = UnknownErrorToException(error);
                if (t.TrySetException(ex))
                {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            })));
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

        public Task ThenCatchAsync<TCatch>(int timeoutMS = 0)
        {
            var t = new TaskCompletionSource();
            var callbacks = new CallbackGroup();
            var cancellationTokenSource = timeoutMS > 0 ? new CancellationTokenSource() : null;
            ThenCatch(callbacks.Add(Callback.Create(() =>
            {
                if (t.TrySetResult())
                {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            })), callbacks.Add(new ActionCallback<TCatch>((catchValue) =>
            {
                if (t.TrySetException(new PromiseCatchException<TCatch>(catchValue)))
                {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            })));
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
        public Task<TResult> ThenAsync<TResult>(int timeoutMS = 0)
        {
            var t = new TaskCompletionSource<TResult>();
            var callbacks = new CallbackGroup();
            var cancellationTokenSource = timeoutMS > 0 ? new CancellationTokenSource() : null;
            ThenCatch(callbacks.Add(Callback.Create<TResult>((result) =>
            {
                if (t.TrySetResult(result))
                {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            })), callbacks.Add(Callback.Create((Error? error) =>
            {
                var ex = Promise.UnknownErrorToException(error);
                if (t.TrySetException(ex))
                {
                    cancellationTokenSource?.Dispose();
                    callbacks.Dispose();
                }
            })));
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
            ThenCatch(callbacks.Add(Callback.Create(() =>
            {
                if (t.TrySetResult())
                {
                    callbacks.Dispose();
                }
            })), callbacks.Add(Callback.Create((Error? error) =>
            {
                var ex = Promise.UnknownErrorToException(error);
                if (t.TrySetException(ex))
                {
                    callbacks.Dispose();
                }
            })));
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
        public Task<TResult> ThenAsync<TResult>(CancellationToken cancellationToken)
        {
            var t = new TaskCompletionSource<TResult>();
            var callbacks = new CallbackGroup();
            ThenCatch(callbacks.Add(Callback.Create<TResult>((result) =>
            {
                if (t.TrySetResult(result))
                {
                    callbacks.Dispose();
                }
            })), callbacks.Add(Callback.Create((Error? error) =>
            {
                var ex = Promise.UnknownErrorToException(error);
                if (t.TrySetException(ex))
                {
                    callbacks.Dispose();
                }
            })));
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
