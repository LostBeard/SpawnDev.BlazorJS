using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class IDBRequest<T> : IDBRequest
    {
        public IDBRequest(IJSInProcessObjectReference _ref) : base(_ref) { }
        public T? Result => JSRef.Get<T>("result");
        public Task<T> WaitAsync()
        {
            var t = new TaskCompletionSource<T>();
            Action<string?, T?>? onComplete = null;
            var onError = new Action(() =>
            {
                onComplete?.Invoke(null, default(T));
            });
            var onSucc = new Action(() =>
            {
                var result = ResultAs<T>();
                onComplete?.Invoke(null, result);
            });
            OnError += onError;
            OnSuccess += onSucc;
            onComplete = new Action<string?, T?>((err, result) =>
            {
                onComplete = null;
                if (result == null && string.IsNullOrEmpty(err)) err = "Failed";
                OnError -= onError;
                OnSuccess -= onSucc;
                if (!string.IsNullOrEmpty(err))
                {
                    t.TrySetException(new Exception(err));
                }
                else
                {
                    t.TrySetResult(result);
                }
            });
            return t.Task;
        }
        public static Task<T> ToAsync(IDBRequest<T> request)
        {
            var t = new TaskCompletionSource<T>();
            Action<string?, T?>? onComplete = null;
            var onError = new Action(() =>
            {
                onComplete?.Invoke(null, default(T));
            });
            var onSucc = new Action(() =>
            {
                var result = request.Result;
                onComplete?.Invoke(null, result);
            });
            request.OnError += onError;
            request.OnSuccess += onSucc;
            onComplete = new Action<string?, T?>((err, result) =>
            {
                onComplete = null;
                if (result == null && string.IsNullOrEmpty(err)) err = "Failed";
                request.OnError -= onError;
                request.OnSuccess -= onSucc;
                request.Dispose();
                if (!string.IsNullOrEmpty(err))
                {
                    t.TrySetException(new Exception(err));
                }
                else
                {
                    t.TrySetResult(result);
                }
            });
            return t.Task;
        }
    }
    public class IDBRequest : EventTarget
    {
        public IDBRequest(IJSInProcessObjectReference _ref) : base(_ref) { }
        public DOMException Error => JSRef.Get<DOMException>("error");
        public T? ResultAs<T>() => JSRef.Get<T>("result");
        /// <summary>
        /// An object representing the source of the request, such as an IDBIndex, IDBObjectStore or IDBCursor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T? SourceAs<T>() => JSRef.Get<T>("source");
        public string ReadyState => JSRef.Get<string>("readyState");
        public IDBTransaction? Transaction => JSRef.Get<IDBTransaction?>("transaction");
        public JSEventCallback OnError { get => new JSEventCallback(o => AddEventListener("error", o), o => RemoveEventListener("error", o)); set { } }
        public JSEventCallback OnSuccess { get => new JSEventCallback(o => AddEventListener("success", o), o => RemoveEventListener("success", o)); set { } }
        public static Task<T> ToAsync<T>(IDBRequest<T> request)
        {
            var t = new TaskCompletionSource<T>();
            Action<string?, T?>? onComplete = null;
            var onError = new Action(() =>
            {
                onComplete?.Invoke(null, default(T));
            });
            var onSucc = new Action(() =>
            {
                var result = request.ResultAs<T>();
                onComplete?.Invoke(null, result);
            });
            request.OnError += onError;
            request.OnSuccess += onSucc;
            onComplete = new Action<string?, T?>((err, result) =>
            {
                onComplete = null;
                if (result == null && string.IsNullOrEmpty(err)) err = "Failed";
                request.OnError -= onError;
                request.OnSuccess -= onSucc;
                request.Dispose();
                if (!string.IsNullOrEmpty(err))
                {
                    t.TrySetException(new Exception(err));
                }
                else
                {
                    t.TrySetResult(result);
                }
            });
            return t.Task;
        }
        public static Task ToVoidAsync(IDBRequest request)
        {
            var t = new TaskCompletionSource();
            Action<string?>? onComplete = null;
            var onError = new Action(() =>
            {
                onComplete?.Invoke("Failed");
            });
            var onSucc = new Action(() =>
            {
                onComplete?.Invoke(null);
            });
            request.OnError += onError;
            request.OnSuccess += onSucc;
            onComplete = new Action<string?>((err) =>
            {
                onComplete = null;
                request.OnError -= onError;
                request.OnSuccess -= onSucc;
                request.Dispose();
                if (!string.IsNullOrEmpty(err))
                {
                    t.TrySetException(new Exception(err));
                }
                else
                {
                    t.TrySetResult();
                }
            });
            return t.Task;
        }
        //public Task<TValue> WaitAsync<TValue>()
        //{
        //    var t = new TaskCompletionSource<TValue>();
        //    Action<string?, TValue?>? onComplete = null;
        //    var onError = new Action(() =>
        //    {
        //        onComplete?.Invoke(null, default(TValue));
        //    });
        //    var onSucc = new Action(() =>
        //    {
        //        var result = ResultAs<TValue>();
        //        onComplete?.Invoke(null, result);
        //    });
        //    OnError += onError;
        //    OnSuccess += onSucc;
        //    onComplete = new Action<string?, TValue?>((err, result) =>
        //    {
        //        onComplete = null;
        //        if (result == null && string.IsNullOrEmpty(err)) err = "Failed";
        //        OnError -= onError;
        //        OnSuccess -= onSucc;
        //        if (!string.IsNullOrEmpty(err))
        //        {
        //            t.TrySetException(new Exception(err));
        //        }
        //        else
        //        {
        //            t.TrySetResult(result);
        //        }
        //    });
        //    return t.Task;
        //}
        public Task WaitVoidAsync()
        {
            var t = new TaskCompletionSource();
            Action<string?>? onComplete = null;
            var onError = new Action(() =>
            {
                onComplete?.Invoke("Failed");
            });
            var onSucc = new Action(() =>
            {
                onComplete?.Invoke(null);
            });
            OnError += onError;
            OnSuccess += onSucc;
            onComplete = new Action<string?>((err) =>
            {
                onComplete = null;
                OnError -= onError;
                OnSuccess -= onSucc;
                if (!string.IsNullOrEmpty(err))
                {
                    t.TrySetException(new Exception(err));
                }
                else
                {
                    t.TrySetResult();
                }
            });
            return t.Task;
        }
    }
}
