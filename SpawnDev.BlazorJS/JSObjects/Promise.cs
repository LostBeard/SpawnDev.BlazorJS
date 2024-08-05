using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Promise object represents the eventual completion (or failure) of an asynchronous operation and its resulting value.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Promise
    /// </summary>
    public class Promise<TResult> : JSObject
    {
        /// <summary>
        /// Explicit conversion from a Task&lt;TResult> to a Promise&lt;TResult>
        /// </summary>
        public static explicit operator Promise<TResult>(Task<TResult> t) => new Promise<TResult>(t);
        /// <summary>
        /// Explicit conversion from a Func&lt;Task&lt;TResult>> to a Promise&lt;TResult>
        /// </summary>
        public static explicit operator Promise<TResult>(Func<Task<TResult>> t) => new Promise<TResult>(t);
        /// <summary>
        /// The Promise() constructor creates Promise objects.
        /// </summary>
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
        /// <summary>
        /// The Promise() constructor creates Promise objects.
        /// </summary>
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
        /// <summary>
        /// The Promise() constructor creates Promise objects.
        /// </summary>
        public Promise(Action<Function, Function> executor) : base(JS.New("Promise", Callback.CreateOne(executor))) { }
        /// <summary>
        /// The Promise() constructor creates Promise objects.
        /// </summary>
        public Promise(Action<Function> executor) : base(JS.New("Promise", Callback.CreateOne(executor))) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public Promise(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Set the methods for the Promise onFulfilled and onRejected events
        /// </summary>
        public void Then(ActionCallback thenCallback, ActionCallback catchCallback) => JSRef!.CallVoid("then", thenCallback, catchCallback);
        /// <summary>
        /// Set the methods for the Promise onFulfilled and onRejected events
        /// </summary>
        public void Then(ActionCallback<TResult> thenCallback, ActionCallback catchCallback) => JSRef!.CallVoid("then", thenCallback, catchCallback);
        /// <summary>
        /// Set the methods for the Promise onFulfilled and onRejected events
        /// </summary>
        public void ThenCatch<TCatch>(ActionCallback<TResult> thenCallback, ActionCallback<TCatch> catchCallback) => JSRef!.CallVoid("then", thenCallback, catchCallback);
        /// <summary>
        /// Asynchronously wait for a Promise to complete
        /// </summary>
        public Task<TResult> ThenAsync(int timeoutMS = 0)
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
        /// <summary>
        /// Asynchronously wait for a Promise to complete
        /// </summary>
        public Task<TResult> ThenAsync(CancellationToken cancellationToken)
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
    /// <summary>
    /// The Promise object represents the eventual completion (or failure) of an asynchronous operation and its resulting value.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Promise
    /// </summary>
    public class Promise : JSObject
    {
        /// <summary>
        /// Explicit conversion from a Task to a Promise
        /// </summary>
        public static explicit operator Promise(Task t) => new Promise(t);
        /// <summary>
        /// Explicit conversion from a Func&lt;Task> to a Promise
        /// </summary>
        public static explicit operator Promise(Func<Task> fn) => new Promise(fn);
        /// <summary>
        /// The Promise() constructor creates Promise objects.
        /// </summary>
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
        /// <summary>
        /// The Promise() constructor creates Promise objects.
        /// </summary>
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
        /// <summary>
        /// The Promise() constructor creates Promise objects.
        /// </summary>
        public Promise(Action<Function, Function> executor) : base(JS.New("Promise", Callback.CreateOne(executor))) { }
        /// <summary>
        /// The Promise() constructor creates Promise objects.
        /// </summary>
        public Promise(Action<Function> executor) : base(JS.New("Promise", Callback.CreateOne(executor))) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public Promise(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Set the methods for the Promise onFulfilled and onRejected events
        /// </summary>
        public void ThenCatch<TCatch>(ActionCallback thenCallback, ActionCallback<TCatch> catchCallback) => JSRef!.CallVoid("then", thenCallback, catchCallback);
        /// <summary>
        /// Set the methods for the Promise onFulfilled and onRejected events
        /// </summary>
        public void Then(ActionCallback thenCallback, ActionCallback catchCallback) => JSRef!.CallVoid("then", thenCallback, catchCallback);
        /// <summary>
        /// Set the methods for the Promise onFulfilled and onRejected events
        /// </summary>
        public void Then<TResult>(ActionCallback<TResult> thenCallback, ActionCallback catchCallback) => JSRef!.CallVoid("then", thenCallback, catchCallback);
        /// <summary>
        /// Set the methods for the Promise onFulfilled and onRejected events
        /// </summary>
        public void ThenCatch<TResult, TCatch>(ActionCallback<TResult> thenCallback, ActionCallback<TCatch> catchCallback) => JSRef!.CallVoid("then", thenCallback, catchCallback);
        /// <summary>
        /// Asynchronously wait for a Promise to complete
        /// </summary>
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
        /// <summary>
        /// Asynchronously wait for a Promise to complete
        /// </summary>
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
        /// <summary>
        /// Asynchronously wait for a Promise to complete
        /// </summary>
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
        /// <summary>
        /// Asynchronously wait for a Promise to complete
        /// </summary>
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
        /// <summary>
        /// Asynchronously wait for a Promise to complete
        /// </summary>
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
        /// <summary>
        /// Handles converting a value from a Promise catch event into an exception.<br/>
        /// These are usually of the type `Error`, but can be anything<br/>
        /// The error object is tested here to create JSException that can represent it in a useful manner
        /// </summary>
        internal static JSException UnknownErrorToException(Error? error)
        {
            JSException? ex = null;
            string? errorName = null;
            string? errorMessage = null;
            if (error != null)
            {
                var typeofError = error.JSRef!.TypeOf();
                switch (typeofError)
                {
                    case "string":
                        {
                            errorMessage = error.JSRefAs<string>();
                            break;
                        }
                    case "object":
                        {
                            var cNames = error.JSRef!.ConstructorNames();
                            errorName = cNames.FirstOrDefault();
                            if (cNames.Contains("Error"))
                            {
                                ex = error.ToException();
                            }
                            else
                            {
                                errorMessage = error.Message;
                            }
                            break;
                        }
                }
            }
            ex ??= new JSException(!string.IsNullOrEmpty(errorMessage) ? errorMessage : "Unknown error", errorName);
            return ex;
        }
    }
}
