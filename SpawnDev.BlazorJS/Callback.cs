using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS {
    // TODO - Add support for nested JSObject parameters in callbacks
    public abstract class Callback : IDisposable {
        //static IJSInProcessRuntime _js { get { return JSObject._js; } }
        static ulong IsCallbackerID = 0;
        static ulong IsCallbackerID2 = 0;
        [JsonPropertyName("isDisposed")]
        public bool IsDisposed { get; private set; } = false;
        //public object netObjRef { get; private set; } = null;
        public DotNetObjectReference<Callback> netObjRef { get; }
        [JsonPropertyName("__callbackerID")]
        public string callbackerID { get; private set; } = "";
        public string[] paramTypes { get; private set; } = new string[0];
        public string returnType { get; private set; } = "";
        protected bool once { get; private set; } = false;
        [JsonIgnore]
        public Type CallbackType { get; private set; }
        public Callback() {
            CallbackType = this.GetType();
            netObjRef = DotNetObjectReference.Create(this);
            // get callback parameter types
            // we need to make sure any callback parameters that are assignable to type JSObject are transferred as IJSInProcessObjectReference type
            // also that IJSInProcessObjectReference is passed properly
            var methodInfo = CallbackType.GetMethod("Invoke");
            if (methodInfo != null) {
                var paramInfos = methodInfo.GetParameters();
                paramTypes = new string[paramInfos.Length];
                for (var i = 0; i < paramTypes.Length; i++) {
                    var paramType = paramInfos[i].ParameterType;
                    if (typeof(JSObject).IsAssignableFrom(paramType)) {
                        paramTypes[i] = "IJSObject";
                    }
                    else if (typeof(IJSInProcessObjectReference).IsAssignableFrom(paramType)) {
                        paramTypes[i] = "IJSObject";
                    }
                    else {
                        paramTypes[i] = paramType.Name;
                    }
                }
                returnType = methodInfo.ReturnType.Name;
            }
            if (returnType == "Task") {
                if (CallbackType.Name.Contains("Task")) {
                    var nmt = true;
                }
                else {
                    throw new Exception("TASK is not a valid return type!");
                }
            }
            if (IsCallbackerID == ulong.MaxValue) {
                IsCallbackerID = 0;
                if (IsCallbackerID2 == ulong.MaxValue) IsCallbackerID2 = 0;
                IsCallbackerID2++;
            }
            callbackerID = $"callback_{IsCallbackerID++}_{IsCallbackerID2}";
#if DEBUG && false
            Console.WriteLine($"Created callbackerID: {callbackerID} {CallbackType.Name} {string.Join(", ", paramTypes)}");
#endif
        }

        //~Callback() {
        //    Dispose(false);
        //}

        void Dispose(bool disposing){
            if (IsDisposed) return;
            IsDisposed = true;
            netObjRef.Dispose();
            //if (netObjRef is IDisposable disposable) disposable.Dispose();
            //netObjRef = null;
            JS.DisposeCallback(callbackerID);
            //_js.InvokeVoid("JSInterop.DisposeCallbacker", callbackerID);
#if DEBUG  && false
            Console.WriteLine($"Disposed callbackerID: {callbackerID}");
#endif
        }

        public virtual void Dispose() {
            if (IsDisposed) return;
            Dispose(true);
            //GC.SuppressFinalize(this);
        }

        // Async Func
        public static AsyncFuncCallback<TResult> Create<TResult>(Func<Task<TResult>> callback, CallbackGroup group = null) {
            var ret = new AsyncFuncCallback<TResult>(callback);
            group?.Add(ret);
            return ret;
        }
        public static AsyncFuncCallback<T1, TResult> Create<T1, TResult>(Func<T1, Task<TResult>> callback, CallbackGroup group = null) {
            var ret = new AsyncFuncCallback<T1, TResult>(callback);
            group?.Add(ret);
            return ret;
        }
        public static AsyncFuncCallback<T1, T2, TResult> Create<T1, T2, TResult>(Func<T1, T2, Task<TResult>> callback, CallbackGroup group = null) {
            var ret = new AsyncFuncCallback<T1, T2, TResult>(callback);
            group?.Add(ret);
            return ret;
        }
        public static AsyncFuncCallback<T1, T2, T3, TResult> Create<T1, T2, T3, TResult>(Func<T1, T2, T3, Task<TResult>> callback, CallbackGroup group = null) {
            var ret = new AsyncFuncCallback<T1, T2, T3, TResult>(callback);
            group?.Add(ret);
            return ret;
        }
        public static AsyncFuncCallback<T1, T2, T3, T4, TResult> Create<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, Task<TResult>> callback, CallbackGroup group = null) {
            var ret = new AsyncFuncCallback<T1, T2, T3, T4, TResult>(callback);
            ret.once = true;
            return ret;
        }
        public static AsyncFuncCallback<TResult> CreateOne<TResult>(Func<Task<TResult>> callback) {
            var ret = new AsyncFuncCallback<TResult>(callback);
            ret.once = true;
            return ret;
        }
        public static AsyncFuncCallback<T1, TResult> CreateOne<T1, TResult>(Func<T1, Task<TResult>> callback) {
            var ret = new AsyncFuncCallback<T1, TResult>(callback);
            ret.once = true;
            return ret;
        }
        public static AsyncFuncCallback<T1, T2, TResult> CreateOne<T1, T2, TResult>(Func<T1, T2, Task<TResult>> callback) {
            var ret = new AsyncFuncCallback<T1, T2, TResult>(callback);
            ret.once = true;
            return ret;
        }
        public static AsyncFuncCallback<T1, T2, T3, TResult> CreateOne<T1, T2, T3, TResult>(Func<T1, T2, T3, Task<TResult>> callback) {
            var ret = new AsyncFuncCallback<T1, T2, T3, TResult>(callback);
            ret.once = true;
            return ret;
        }
        public static AsyncFuncCallback<T1, T2, T3, T4, TResult> CreateOne<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, Task<TResult>> callback) {
            var ret = new AsyncFuncCallback<T1, T2, T3, T4, TResult>(callback);
            ret.once = true;
            return ret;
        }

        // Sync Func
        public static FuncCallback<TResult> Create<TResult>(Func<TResult> callback, CallbackGroup group = null) {
            var ret = new FuncCallback<TResult>(callback);
            group?.Add(ret);
            return ret;
        }
        public static FuncCallback<TResult> CreateOne<TResult>(Func<TResult> callback) {
            var ret = new FuncCallback<TResult>(callback);
            ret.once = true;
            return ret;
        }
        public static FuncCallback<T1, TResult> Create<T1, TResult>(Func<T1, TResult> callback, CallbackGroup group = null) {
            var ret = new FuncCallback<T1, TResult>(callback);
            group?.Add(ret);
            return ret;
        }
        public static FuncCallback<T1, TResult> CreateOne<T1, TResult>(Func<T1, TResult> callback) {
            var ret = new FuncCallback<T1, TResult>(callback);
            ret.once = true;
            return ret;
        }
        public static FuncCallback<T1, T2, TResult> Create<T1, T2, TResult>(Func<T1, T2, TResult> callback, CallbackGroup group = null) {
            var ret = new FuncCallback<T1, T2, TResult>(callback);
            group?.Add(ret);
            return ret;
        }
        public static FuncCallback<T1, T2, TResult> CreateOne<T1, T2, TResult>(Func<T1, T2, TResult> callback) {
            var ret = new FuncCallback<T1, T2, TResult>(callback);
            ret.once = true;
            return ret;
        }
        public static FuncCallback<T1, T2, T3, TResult> Create<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> callback, CallbackGroup group = null) {
            var ret = new FuncCallback<T1, T2, T3, TResult>(callback);
            group?.Add(ret);
            return ret;
        }
        public static FuncCallback<T1, T2, T3, T4, TResult> Create<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> callback, CallbackGroup group = null) {
            var ret = new FuncCallback<T1, T2, T3, T4, TResult>(callback);
            group?.Add(ret);
            return ret;
        }
        public static FuncCallback<T1, T2, T3, T4, TResult> CreateOne<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> callback) {
            var ret = new FuncCallback<T1, T2, T3, T4, TResult>(callback);
            ret.once = true;
            return ret;
        }
        public static FuncCallback<T1, T2, T3, TResult> CreateOne<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> callback) {
            var ret = new FuncCallback<T1, T2, T3, TResult>(callback);
            ret.once = true;
            return ret;
        }
        // Async Actions
        public static AsyncActionCallback Create(Func<Task> callback, CallbackGroup group = null) {
            var ret = new AsyncActionCallback(callback);
            group?.Add(ret);
            return ret;
        }

        public static AsyncActionCallback<T1> Create<T1>(Func<T1, Task> callback, CallbackGroup group = null) {
            var ret = new AsyncActionCallback<T1>(callback);
            group?.Add(ret);
            return ret;
        }

        public static AsyncActionCallback<T1, T2> Create<T1, T2>(Func<T1, T2, Task> callback, CallbackGroup group = null) {
            var ret = new AsyncActionCallback<T1, T2>(callback);
            group?.Add(ret);
            return ret;
        }

        public static AsyncActionCallback<T1, T2, T3> Create<T1, T2, T3>(Func<T1, T2, T3, Task> callback, CallbackGroup group = null) {
            var ret = new AsyncActionCallback<T1, T2, T3>(callback);
            group?.Add(ret);
            return ret;
        }

        public static AsyncActionCallback<T1, T2, T3, T4> Create<T1, T2, T3, T4>(Func<T1, T2, T3, T4, Task> callback, CallbackGroup group = null) {
            var ret = new AsyncActionCallback<T1, T2, T3, T4>(callback);
            group?.Add(ret);
            return ret;
        }
        public static AsyncActionCallback CreateOne(Func<Task> callback) {
            var ret = new AsyncActionCallback(callback);
            ret.once = true;
            return ret;
        }

        public static AsyncActionCallback<T1> CreateOne<T1>(Func<T1, Task> callback) {
            var ret = new AsyncActionCallback<T1>(callback);
            ret.once = true;
            return ret;
        }

        public static AsyncActionCallback<T1, T2> CreateOne<T1, T2>(Func<T1, T2, Task> callback) {
            var ret = new AsyncActionCallback<T1, T2>(callback);
            ret.once = true;
            return ret;
        }

        public static AsyncActionCallback<T1, T2, T3> CreateOne<T1, T2, T3>(Func<T1, T2, T3, Task> callback) {
            var ret = new AsyncActionCallback<T1, T2, T3>(callback);
            ret.once = true;
            return ret;
        }

        public static AsyncActionCallback<T1, T2, T3, T4> CreateOne<T1, T2, T3, T4>(Func<T1, T2, T3, T4, Task> callback) {
            var ret = new AsyncActionCallback<T1, T2, T3, T4>(callback);
            ret.once = true;
            return ret;
        }

        // Sync Actions
        public static ActionCallback Create(Action callback, CallbackGroup group = null) {
            var ret = new ActionCallback(callback);
            group?.Add(ret);
            return ret;
        }
        public static ActionCallback CreateOne(Action callback) {
            var ret = new ActionCallback(callback);
            ret.once = true;
            return ret;
        }
        public static ActionCallback<T1> Create<T1>(Action<T1> callback, CallbackGroup group = null) {
            var ret = new ActionCallback<T1>(callback);
            group?.Add(ret);
            return ret;
        }
        public static ActionCallback<T1> CreateOne<T1>(Action<T1> callback) {
            var ret = new ActionCallback<T1>(callback);
            ret.once = true;
            return ret;
        }
        public static ActionCallback<T1, T2> Create<T1, T2>(Action<T1, T2> callback, CallbackGroup group = null) {
            var ret = new ActionCallback<T1, T2>(callback);
            group?.Add(ret);
            return ret;
        }
        public static ActionCallback<T1, T2> CreateOne<T1, T2>(Action<T1, T2> callback) {
            var ret = new ActionCallback<T1, T2>(callback);
            ret.once = true;
            return ret;
        }
        public static ActionCallback<T1, T2, T3> Create<T1, T2, T3>(Action<T1, T2, T3> callback, CallbackGroup group = null) {
            var ret = new ActionCallback<T1, T2, T3>(callback);
            group?.Add(ret);
            return ret;
        }
        public static ActionCallback<T1, T2, T3> CreateOne<T1, T2, T3>(Action<T1, T2, T3> callback) {
            var ret = new ActionCallback<T1, T2, T3>(callback);
            ret.once = true;
            return ret;
        }
        public static ActionCallback<T1, T2, T3, T4> Create<T1, T2, T3, T4>(Action<T1, T2, T3, T4> callback, CallbackGroup group = null) {
            var ret = new ActionCallback<T1, T2, T3, T4>(callback);
            group?.Add(ret);
            return ret;
        }
        public static ActionCallback<T1, T2, T3, T4> CreateOne<T1, T2, T3, T4>(Action<T1, T2, T3, T4> callback) {
            var ret = new ActionCallback<T1, T2, T3, T4>(callback);
            ret.once = true;
            return ret;
        }
    }
    public class CallbackGroup : IDisposable {
        public List<Callback> group = new List<Callback>();

        public Callback Add(Callback wrapper) {
            group.Add(wrapper);
            return wrapper;
        }

        public void Clear() {
            foreach (var cbw in group) {
                cbw.Dispose();
            }
            group.Clear();
        }

        public void Dispose() {
            Clear();
        }
    }

    // Async Func
    public class AsyncFuncCallback<TResult> : Callback {
        Func<Task<TResult>> _callback;
        public AsyncFuncCallback(Func<Task<TResult>> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public Promise Invoke() {
            if (once) Dispose();
            return new Promise<TResult>(_callback());
        }
    }

    public class AsyncFuncCallback<T1, TResult> : Callback {
        Func<T1, Task<TResult>> _callback;
        public AsyncFuncCallback(Func<T1, Task<TResult>> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public Promise Invoke(T1 arg0) {
            if (once) Dispose();
            return new Promise<TResult>(_callback(arg0));
        }
    }

    public class AsyncFuncCallback<T1, T2, TResult> : Callback {
        Func<T1, T2, Task<TResult>> _callback;
        public AsyncFuncCallback(Func<T1, T2, Task<TResult>> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public Promise Invoke(T1 arg0, T2 arg1) {
            if (once) Dispose();
            return new Promise<TResult>(_callback(arg0, arg1));
        }
    }

    public class AsyncFuncCallback<T1, T2, T3, TResult> : Callback {
        Func<T1, T2, T3, Task<TResult>> _callback;
        public AsyncFuncCallback(Func<T1, T2, T3, Task<TResult>> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public Promise Invoke(T1 arg0, T2 arg1, T3 arg2) {
            if (once) Dispose();
            return new Promise<TResult>(_callback(arg0, arg1, arg2));
        }
    }

    public class AsyncFuncCallback<T1, T2, T3, T4, TResult> : Callback {
        Func<T1, T2, T3, T4, Task<TResult>> _callback;
        public AsyncFuncCallback(Func<T1, T2, T3, T4, Task<TResult>> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public Promise Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3) {
            if (once) Dispose();
            return new Promise<TResult>(_callback(arg0, arg1, arg2, arg3));
        }
    }

    // Synch Func
    public class FuncCallback<TResult> : Callback {
        Func<TResult> _callback;
        public FuncCallback(Func<TResult> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public TResult Invoke() {
            if (once) Dispose();
            return _callback();
        }
    }
    public class FuncCallback<T1, TResult> : Callback {
        Func<T1, TResult> _callback;
        public FuncCallback(Func<T1, TResult> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public TResult Invoke(T1 arg0) {
            if (once) Dispose();
            return _callback(arg0);
        }
    }
    public class FuncCallback<T1, T2, TResult> : Callback {
        Func<T1, T2, TResult> _callback;
        public FuncCallback(Func<T1, T2, TResult> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public TResult Invoke(T1 arg0, T2 arg1) {
            if (once) Dispose();
            return _callback(arg0, arg1);
        }
    }
    public class FuncCallback<T1, T2, T3, TResult> : Callback {
        Func<T1, T2, T3, TResult> _callback;
        public FuncCallback(Func<T1, T2, T3, TResult> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public TResult Invoke(T1 arg0, T2 arg1, T3 arg2) {
            if (once) Dispose();
            return _callback(arg0, arg1, arg2);
        }
    }
    public class FuncCallback<T1, T2, T3, T4, TResult> : Callback {
        Func<T1, T2, T3, T4, TResult> _callback;
        public FuncCallback(Func<T1, T2, T3, T4, TResult> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public TResult Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3) {
            if (once) Dispose();
            return _callback(arg0, arg1, arg2, arg3);
        }
    }

    // Async Actions
    public class AsyncActionCallback : Callback {
        Func<Task> _callback;
        public AsyncActionCallback(Func<Task> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public Promise Invoke() {
            if (once) Dispose();
            return new Promise(_callback());
        }
    }

    public class AsyncActionCallback<T1> : Callback {
        Func<T1, Task> _callback;
        public AsyncActionCallback(Func<T1, Task> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public Promise Invoke(T1 arg0) {
            if (once) Dispose();
            return new Promise(_callback(arg0));
        }
    }

    public class AsyncActionCallback<T1, T2> : Callback {
        Func<T1, T2, Task> _callback;
        public AsyncActionCallback(Func<T1, T2, Task> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public Promise Invoke(T1 arg0, T2 arg1) {
            if (once) Dispose();
            return new Promise(_callback(arg0, arg1));
        }
    }

    public class AsyncActionCallback<T1, T2, T3> : Callback {
        Func<T1, T2, T3, Task> _callback;
        public AsyncActionCallback(Func<T1, T2, T3, Task> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public Promise Invoke(T1 arg0, T2 arg1, T3 arg2) {
            if (once) Dispose();
            return new Promise(_callback(arg0, arg1, arg2));
        }
    }

    public class AsyncActionCallback<T1, T2, T3, T4> : Callback {
        Func<T1, T2, T3, T4, Task> _callback;
        public AsyncActionCallback(Func<T1, T2, T3, T4, Task> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public Promise Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3) {
            if (once) Dispose();
            return new Promise(_callback(arg0, arg1, arg2, arg3));
        }
    }

    // Synch Actions
    public class ActionCallback : Callback {
        Action _callback;
        public ActionCallback(Action callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public void Invoke() {
            if (once) Dispose();
            _callback();
        }
    }
    public class ActionCallback<T1> : Callback {
        Action<T1> _callback;
        public ActionCallback(Action<T1> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public void Invoke(T1 arg0) {
            if (once) Dispose();
            _callback(arg0);
        }
    }
    public class ActionCallback<T1, T2> : Callback {
        Action<T1, T2> _callback;
        public ActionCallback(Action<T1, T2> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public void Invoke(T1 arg0, T2 arg1) {
            if (once) Dispose();
            _callback(arg0, arg1);
        }
    }
    public class ActionCallback<T1, T2, T3> : Callback {
        Action<T1, T2, T3> _callback;
        public ActionCallback(Action<T1, T2, T3> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public void Invoke(T1 arg0, T2 arg1, T3 arg2) {
            if (once) Dispose();
            _callback(arg0, arg1, arg2);
        }
    }
    public class ActionCallback<T1, T2, T3, T4> : Callback {
        Action<T1, T2, T3, T4> _callback;
        public ActionCallback(Action<T1, T2, T3, T4> callback) : base() {
            _callback = callback;
        }
        [JSInvokable]
        public void Invoke(T1 arg0, T2 arg1, T3 arg2, T4 arg3) {
            if (once) Dispose();
            _callback(arg0, arg1, arg2, arg3);
        }
    }
}
