using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Callback makes .Net methods callable from plain Javascript
    /// </summary>
    public abstract partial class Callback : IDisposable
    {
        static ulong CallbackIdCounter { get; set; } = 0;
        [JsonPropertyName("isDisposed")]
        public bool IsDisposed { get; private set; } = false;
        [JsonInclude]
        [JsonPropertyName("_callback")]
        private DotNetObjectReference<Callback> _callback { get; }
        [JsonInclude]
        [JsonPropertyName("_callbackId")]
        private string _callbackId { get; set; }
        [JsonInclude]
        [JsonPropertyName("_paramTypes")]
        private int[] _paramTypes { get; set; } = new int[0];
        [JsonInclude]
        [JsonPropertyName("_returnVoid")]
        private bool _returnVoid { get; set; }
        protected bool once { get; private set; } = false;
        public Callback(bool once)
        {
            CallbackIdCounter = CallbackIdCounter == ulong.MaxValue ? 1 : CallbackIdCounter + 1;
            _callbackId = $"{CallbackIdCounter}";
            var callbackType = this.GetType();
            _callback = DotNetObjectReference.Create(this);
            var methodInfo = callbackType.GetMethod("Invoke");
            if (methodInfo != null)
            {
                var paramInfos = methodInfo.GetParameters();
                _paramTypes = new int[paramInfos.Length];
                for (var i = 0; i < _paramTypes.Length; i++)
                {
                    var paramType = paramInfos[i].ParameterType;
                    var jsCallResultType = JSCallResultTypeHelperOverride.FromGenericForCallback(paramType);
                    // _paramTypes will let JSInterop know how to prepare the parameters values for invocation
                    _paramTypes[i] = (int)jsCallResultType;
                }
                _returnVoid = methodInfo.ReturnType == typeof(void);
            }
            this.once = once;
        }

        //~Callback() {
        //    Dispose(false);
        //}

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            IsDisposed = true;
            // 
            _callback.Dispose();
            BlazorJSRuntime.JS.DisposeCallback(_callbackId);
#if DEBUG  && false
            Console.WriteLine($"Disposed callbackerID: {callbackerID} {CallbackType.Name}");
#endif
        }

        public void Dispose()
        {
            if (IsDisposed) return;
            Dispose(true);
            //GC.SuppressFinalize(this);
        }

        // AsyncFuncCallback Create
        public static AsyncFuncCallback<TResult> Create<TResult>(Func<Task<TResult>> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new AsyncFuncCallback<TResult>(callback, false) : callbackGroup.Add(new AsyncFuncCallback<TResult>(callback, false));
        public static AsyncFuncCallback<T1, TResult> Create<T1, TResult>(Func<T1, Task<TResult>> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new AsyncFuncCallback<T1, TResult>(callback, false) : callbackGroup.Add(new AsyncFuncCallback<T1, TResult>(callback, false));
        public static AsyncFuncCallback<T1, T2, TResult> Create<T1, T2, TResult>(Func<T1, T2, Task<TResult>> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new AsyncFuncCallback<T1, T2, TResult>(callback, false) : callbackGroup.Add(new AsyncFuncCallback<T1, T2, TResult>(callback, false));
        public static AsyncFuncCallback<T1, T2, T3, TResult> Create<T1, T2, T3, TResult>(Func<T1, T2, T3, Task<TResult>> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new AsyncFuncCallback<T1, T2, T3, TResult>(callback, false) : callbackGroup.Add(new AsyncFuncCallback<T1, T2, T3, TResult>(callback, false));
        public static AsyncFuncCallback<T1, T2, T3, T4, TResult> Create<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, Task<TResult>> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new AsyncFuncCallback<T1, T2, T3, T4, TResult>(callback, false) : callbackGroup.Add(new AsyncFuncCallback<T1, T2, T3, T4, TResult>(callback, false));

        // AsyncFuncCallback CreateOne
        public static AsyncFuncCallback<TResult> CreateOne<TResult>(Func<Task<TResult>> callback) => new AsyncFuncCallback<TResult>(callback, true);
        public static AsyncFuncCallback<T1, TResult> CreateOne<T1, TResult>(Func<T1, Task<TResult>> callback) => new AsyncFuncCallback<T1, TResult>(callback, true);
        public static AsyncFuncCallback<T1, T2, TResult> CreateOne<T1, T2, TResult>(Func<T1, T2, Task<TResult>> callback) => new AsyncFuncCallback<T1, T2, TResult>(callback, true);
        public static AsyncFuncCallback<T1, T2, T3, TResult> CreateOne<T1, T2, T3, TResult>(Func<T1, T2, T3, Task<TResult>> callback) => new AsyncFuncCallback<T1, T2, T3, TResult>(callback, true);
        public static AsyncFuncCallback<T1, T2, T3, T4, TResult> CreateOne<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, Task<TResult>> callback) => new AsyncFuncCallback<T1, T2, T3, T4, TResult>(callback, true);

        // AsyncActionCallback Create
        public static AsyncActionCallback Create(Func<Task> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new AsyncActionCallback(callback, false) : callbackGroup.Add(new AsyncActionCallback(callback, false));
        public static AsyncActionCallback<T1> Create<T1>(Func<T1, Task> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new AsyncActionCallback<T1>(callback, false) : callbackGroup.Add(new AsyncActionCallback<T1>(callback, false));
        public static AsyncActionCallback<T1, T2> Create<T1, T2>(Func<T1, T2, Task> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new AsyncActionCallback<T1, T2>(callback, false) : callbackGroup.Add(new AsyncActionCallback<T1, T2>(callback, false));
        public static AsyncActionCallback<T1, T2, T3> Create<T1, T2, T3>(Func<T1, T2, T3, Task> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new AsyncActionCallback<T1, T2, T3>(callback, false) : callbackGroup.Add(new AsyncActionCallback<T1, T2, T3>(callback, false));
        public static AsyncActionCallback<T1, T2, T3, T4> Create<T1, T2, T3, T4>(Func<T1, T2, T3, T4, Task> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new AsyncActionCallback<T1, T2, T3, T4>(callback, false) : callbackGroup.Add(new AsyncActionCallback<T1, T2, T3, T4>(callback, false));

        // AsyncActionCallback CreateOne
        public static AsyncActionCallback CreateOne(Func<Task> callback) => new AsyncActionCallback(callback, true);
        public static AsyncActionCallback<T1> CreateOne<T1>(Func<T1, Task> callback) => new AsyncActionCallback<T1>(callback, true);
        public static AsyncActionCallback<T1, T2> CreateOne<T1, T2>(Func<T1, T2, Task> callback) => new AsyncActionCallback<T1, T2>(callback, true);
        public static AsyncActionCallback<T1, T2, T3> CreateOne<T1, T2, T3>(Func<T1, T2, T3, Task> callback) => new AsyncActionCallback<T1, T2, T3>(callback, true);
        public static AsyncActionCallback<T1, T2, T3, T4> CreateOne<T1, T2, T3, T4>(Func<T1, T2, T3, T4, Task> callback) => new AsyncActionCallback<T1, T2, T3, T4>(callback, true);

        // FuncCallback Create
        public static FuncCallback<TResult> Create<TResult>(Func<TResult> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new FuncCallback<TResult>(callback, false) : callbackGroup.Add(new FuncCallback<TResult>(callback, false));
        public static FuncCallback<T1, TResult> Create<T1, TResult>(Func<T1, TResult> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new FuncCallback<T1, TResult>(callback, false) : callbackGroup.Add(new FuncCallback<T1, TResult>(callback, false));
        public static FuncCallback<T1, T2, TResult> Create<T1, T2, TResult>(Func<T1, T2, TResult> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new FuncCallback<T1, T2, TResult>(callback, false) : callbackGroup.Add(new FuncCallback<T1, T2, TResult>(callback, false));
        public static FuncCallback<T1, T2, T3, TResult> Create<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new FuncCallback<T1, T2, T3, TResult>(callback, false) : callbackGroup.Add(new FuncCallback<T1, T2, T3, TResult>(callback, false));
        public static FuncCallback<T1, T2, T3, T4, TResult> Create<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new FuncCallback<T1, T2, T3, T4, TResult>(callback, false) : callbackGroup.Add(new FuncCallback<T1, T2, T3, T4, TResult>(callback, false));

        // FuncCallback CreateOne
        public static FuncCallback<TResult> CreateOne<TResult>(Func<TResult> callback) => new FuncCallback<TResult>(callback, true);
        public static FuncCallback<T1, TResult> CreateOne<T1, TResult>(Func<T1, TResult> callback) => new FuncCallback<T1, TResult>(callback, true);
        public static FuncCallback<T1, T2, TResult> CreateOne<T1, T2, TResult>(Func<T1, T2, TResult> callback) => new FuncCallback<T1, T2, TResult>(callback, true);
        public static FuncCallback<T1, T2, T3, TResult> CreateOne<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> callback) => new FuncCallback<T1, T2, T3, TResult>(callback, true);
        public static FuncCallback<T1, T2, T3, T4, TResult> CreateOne<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> callback) => new FuncCallback<T1, T2, T3, T4, TResult>(callback, true);

        // ActionCallback Create
        public static ActionCallback Create(Action callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new ActionCallback(callback, false) : callbackGroup.Add(new ActionCallback(callback, false));
        public static ActionCallback<T1> Create<T1>(Action<T1> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new ActionCallback<T1>(callback, false) : callbackGroup.Add(new ActionCallback<T1>(callback, false));
        public static ActionCallback<T1, T2> Create<T1, T2>(Action<T1, T2> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new ActionCallback<T1, T2>(callback, false) : callbackGroup.Add(new ActionCallback<T1, T2>(callback, false));
        public static ActionCallback<T1, T2, T3> Create<T1, T2, T3>(Action<T1, T2, T3> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new ActionCallback<T1, T2, T3>(callback, false) : callbackGroup.Add(new ActionCallback<T1, T2, T3>(callback, false));
        public static ActionCallback<T1, T2, T3, T4> Create<T1, T2, T3, T4>(Action<T1, T2, T3, T4> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new ActionCallback<T1, T2, T3, T4>(callback, false) : callbackGroup.Add(new ActionCallback<T1, T2, T3, T4>(callback, false));
        public static ActionCallback<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new ActionCallback<T1, T2, T3, T4, T5>(callback, false) : callbackGroup.Add(new ActionCallback<T1, T2, T3, T4, T5>(callback, false));
        public static ActionCallback<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new ActionCallback<T1, T2, T3, T4, T5, T6>(callback, false) : callbackGroup.Add(new ActionCallback<T1, T2, T3, T4, T5, T6>(callback, false));
        public static ActionCallback<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new ActionCallback<T1, T2, T3, T4, T5, T6, T7>(callback, false) : callbackGroup.Add(new ActionCallback<T1, T2, T3, T4, T5, T6, T7>(callback, false));

        // ActionCallback CreateOne
        public static ActionCallback CreateOne(Action callback) => new ActionCallback(callback, true);
        public static ActionCallback<T1> CreateOne<T1>(Action<T1> callback) => new ActionCallback<T1>(callback, true);
        public static ActionCallback<T1, T2> CreateOne<T1, T2>(Action<T1, T2> callback) => new ActionCallback<T1, T2>(callback, true);
        public static ActionCallback<T1, T2, T3> CreateOne<T1, T2, T3>(Action<T1, T2, T3> callback) => new ActionCallback<T1, T2, T3>(callback, true);
        public static ActionCallback<T1, T2, T3, T4> CreateOne<T1, T2, T3, T4>(Action<T1, T2, T3, T4> callback) => new ActionCallback<T1, T2, T3, T4>(callback, true);
        public static ActionCallback<T1, T2, T3, T4, T5> CreateOne<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> callback) => new ActionCallback<T1, T2, T3, T4, T5>(callback, true);
        public static ActionCallback<T1, T2, T3, T4, T5, T6> CreateOne<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> callback) => new ActionCallback<T1, T2, T3, T4, T5, T6>(callback, true);
        public static ActionCallback<T1, T2, T3, T4, T5, T6, T7> CreateOne<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> callback) => new ActionCallback<T1, T2, T3, T4, T5, T6, T7>(callback, true);
    }
}
