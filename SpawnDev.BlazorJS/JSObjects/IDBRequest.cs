using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The IDBRequest interface of the IndexedDB API provides access to results of asynchronous requests to databases and database objects using event handler attributes. Each reading and writing operation on a database is done using a request.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBRequest
    /// </summary>
    /// <typeparam name="TResult">The type to use for the Result property</typeparam>
    public class IDBRequest<TResult> : IDBRequest
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBRequest(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the result of the request. If the request is not completed, the result is not available and an InvalidStateError exception is thrown.
        /// </summary>
        public TResult Result => JSRef!.Get<TResult>("result");
        /// <summary>
        /// if (ReadyState == "done" AND Error == null) returns Result as TResult<br/>
        /// if (ReadyState == "done" AND Error != null) throws Exception<br/>
        /// else<br/>
        /// On onsuccess returns Result as TResult<br/>
        /// On onerror throws Exception<br/>
        /// </summary>
        /// <param name="disposeRequest">If true, this IDBRequest will be disposed after when the call completes</param>
        /// <returns>Task&lt;TResult&gt;</returns>
        public override Task<TResult> WaitAsync(bool disposeRequest = true)
        {
            if (ReadyState == "done")
            {
                using var error = Error;
                var ret = error != null ? Task.FromException<TResult>(error.ToException()) : Task.FromResult<TResult>(Result);
                if (disposeRequest) Dispose();
                return ret;
            }
            var t = new TaskCompletionSource<TResult>();
            Action? onComplete = null;
            var onError = new Action(() =>
            {
                using var error = Error;
                t.TrySetException(error?.ToException() ?? new Exception("IDBRequest - unknown error"));
                onComplete?.Invoke();
            });
            var onSucc = new Action(() =>
            {
                t.TrySetResult(Result);
                onComplete?.Invoke();
            });
            OnError += onError;
            OnSuccess += onSucc;
            onComplete = new Action(() =>
            {
                onComplete = null;
                OnError -= onError;
                OnSuccess -= onSucc;
                if (disposeRequest) Dispose();
            });
            return t.Task;
        }
    }
    /// <summary>
    /// The IDBRequest interface of the IndexedDB API provides access to results of asynchronous requests to databases and database objects using event handler attributes. Each reading and writing operation on a database is done using a request.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBRequest
    /// </summary>
    public class IDBRequest : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public IDBRequest(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a DOMException in the event of an unsuccessful request, indicating what went wrong.
        /// </summary>
        public DOMException Error => JSRef!.Get<DOMException>("error");
        /// <summary>
        /// Returns the result of the request. If the request is not completed, the result is not available and an InvalidStateError exception is thrown.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ResultAs<T>() => JSRef!.Get<T>("result");
        /// <summary>
        /// An object representing the source of the request, such as an IDBIndex, IDBObjectStore or IDBCursor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T SourceAs<T>() => JSRef!.Get<T>("source");
        /// <summary>
        /// The state of the request. Every request starts in the pending state. The state changes to done when the request completes successfully or when an error occurs.
        /// </summary>
        public string ReadyState => JSRef!.Get<string>("readyState");
        /// <summary>
        /// The transaction for the request. This property can be null for certain requests, for example those returned from IDBFactory.open unless an upgrade is needed. (You're just connecting to a database, so there is no transaction to return).
        /// </summary>
        public IDBTransaction? Transaction => JSRef!.Get<IDBTransaction?>("transaction");
        #region Events
        /// <summary>
        /// Fired when an error caused a request to fail.
        /// </summary>
        public ActionEvent<Event> OnError { get => new ActionEvent<Event>("error", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when an IDBRequest succeeds.
        /// </summary>
        public ActionEvent<Event> OnSuccess { get => new ActionEvent<Event>("success", AddEventListener, RemoveEventListener); set { } }
        #endregion
        /// <summary>
        /// if (ReadyState == "done" AND Error == null) returns CompletedTask<br/>
        /// if (ReadyState == "done" AND Error != null) throws Exception<br/>
        /// else<br/>
        /// On onsuccess returns CompletedTask<br/>
        /// On onerror throws Exception<br/>
        /// </summary>
        /// <param name="disposeRequest">If true, this IDBRequest will be disposed after when the call completes</param>
        /// <returns>Task</returns>
        public virtual Task WaitAsync(bool disposeRequest = true)
        {
            if (ReadyState == "done")
            {
                using var error = Error;
                var ret = error != null ? Task.FromException(error.ToException()) : Task.CompletedTask;
                if (disposeRequest) Dispose();
                return ret;
            }
            var t = new TaskCompletionSource();
            Action? onComplete = null;
            var onError = new Action(() =>
            {
                using var error = Error;
                t.TrySetException(error?.ToException() ?? new Exception("IDBRequest - unknown error"));
                onComplete?.Invoke();
            });
            var onSucc = new Action(() =>
            {
                t.TrySetResult();
                onComplete?.Invoke();
            });
            OnError += onError;
            OnSuccess += onSucc;
            onComplete = new Action(() =>
            {
                onComplete = null;
                OnError -= onError;
                OnSuccess -= onSucc;
                if (disposeRequest) Dispose();
            });
            return t.Task;
        }
    }
}
