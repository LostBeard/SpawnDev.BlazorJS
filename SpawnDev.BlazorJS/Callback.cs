using Microsoft.JSInterop;
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
        private int _ReferenceCount = 1;
        /// <summary>
        /// Get or set the reference count<br/>
        /// Defaults to 1 when created<br/>
        /// Calling Dispose will decrement the RefCount by 1 and the Callback will be disposed when the RefCount &lt;= 0
        /// </summary>
        [JsonIgnore]
        internal int RefCount
        {
            get => _ReferenceCount;
            set
            {
                if (IsDisposed) return;
                _ReferenceCount = value;
                if (_ReferenceCount <= 0) Dispose();
            }
        }
        /// <summary>
        /// Returns true if this object has been disposed
        /// </summary>
        [JsonPropertyName("isDisposed")]
        public bool IsDisposed { get; private set; } = false;
        /// <summary>
        /// The DotNetObjectReference for the callback
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("_callback")]
        public DotNetObjectReference<Callback> _callback { get; }
        /// <summary>
        /// The unique ID for the callback
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("_callbackId")]
        public string _callbackId { get; private set; }
        /// <summary>
        /// The parameter types for the callback
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("_paramTypes")]
        public int[] _paramTypes { get; private set; } = new int[0];
        /// <summary>
        /// If true the callback returns void
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("_returnVoid")]
        public bool _returnVoid { get; private set; }
        /// <summary>
        /// If true the Callback will be disposed after the first call
        /// </summary>
        protected bool once { get; private set; } = false;
        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="once"></param>
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
        /// <summary>
        /// Calls Dispose, if force == true the Callback will be disposed regardless of the current RefCount
        /// </summary>
        /// <param name="force"></param>
        public void Dispose(bool force)
        {
            if (IsDisposed) return;
            if (force) RefCount = 0;
            Dispose();
        }
        /// <summary>
        /// Decrements the RefCount by 1. If RefCount is &lt;= 0 the Callback is disposed.
        /// </summary>
        public void Dispose()
        {
            if (IsDisposed) return;
            if (_ReferenceCount > 0) _ReferenceCount--;
            if (_ReferenceCount > 0) return;
            IsDisposed = true;
            GC.SuppressFinalize(this);
            _callback.Dispose();
            BlazorJSRuntime.JS.DisposeCallback(_callbackId);
            OnDisposed?.Invoke();
        }
        /// <summary>
        /// Fired when the Callback is disposed
        /// </summary>
        public event Action OnDisposed = default!;
        // FuncCallback Create
        /// <summary>
        /// Creates a new Callback instance from the given .Net method
        /// </summary>
        public static FuncCallback<TResult> Create<TResult>(Func<TResult> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new FuncCallback<TResult>(callback, false) : callbackGroup.Add(new FuncCallback<TResult>(callback, false));
        /// <summary>
        /// Creates a new Callback instance from the given .Net method
        /// </summary>
        public static FuncCallback<T1, TResult> Create<T1, TResult>(Func<T1, TResult> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new FuncCallback<T1, TResult>(callback, false) : callbackGroup.Add(new FuncCallback<T1, TResult>(callback, false));
        /// <summary>
        /// Creates a new Callback instance from the given .Net method
        /// </summary>
        public static FuncCallback<T1, T2, TResult> Create<T1, T2, TResult>(Func<T1, T2, TResult> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new FuncCallback<T1, T2, TResult>(callback, false) : callbackGroup.Add(new FuncCallback<T1, T2, TResult>(callback, false));
        /// <summary>
        /// Creates a new Callback instance from the given .Net method
        /// </summary>
        public static FuncCallback<T1, T2, T3, TResult> Create<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new FuncCallback<T1, T2, T3, TResult>(callback, false) : callbackGroup.Add(new FuncCallback<T1, T2, T3, TResult>(callback, false));
        /// <summary>
        /// Creates a new Callback instance from the given .Net method
        /// </summary>
        public static FuncCallback<T1, T2, T3, T4, TResult> Create<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new FuncCallback<T1, T2, T3, T4, TResult>(callback, false) : callbackGroup.Add(new FuncCallback<T1, T2, T3, T4, TResult>(callback, false));
        /// <summary>
        /// Creates a new Callback instance from the given .Net method
        /// </summary>
        public static FuncCallback<T1, T2, T3, T4, T5, TResult> Create<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new FuncCallback<T1, T2, T3, T4, T5, TResult>(callback, false) : callbackGroup.Add(new FuncCallback<T1, T2, T3, T4, T5, TResult>(callback, false));
        /// <summary>
        /// Creates a new Callback instance from the given .Net method
        /// </summary>
        public static FuncCallback<T1, T2, T3, T4, T5, T6, TResult> Create<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new FuncCallback<T1, T2, T3, T4, T5, T6, TResult>(callback, false) : callbackGroup.Add(new FuncCallback<T1, T2, T3, T4, T5, T6, TResult>(callback, false));
        /// <summary>
        /// Creates a new Callback instance from the given .Net method
        /// </summary>
        public static FuncCallback<T1, T2, T3, T4, T5, T6, T7, TResult> Create<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new FuncCallback<T1, T2, T3, T4, T5, T6, T7, TResult>(callback, false) : callbackGroup.Add(new FuncCallback<T1, T2, T3, T4, T5, T6, T7, TResult>(callback, false));
        // FuncCallback CreateOne
        /// <summary>
        /// Creates a new Callback instance from the given .Net method that will be disposed after the first call
        /// </summary>
        public static FuncCallback<TResult> CreateOne<TResult>(Func<TResult> callback) => new FuncCallback<TResult>(callback, true);
        /// <summary>
        /// Creates a new Callback instance from the given .Net method that will be disposed after the first call
        /// </summary>
        public static FuncCallback<T1, TResult> CreateOne<T1, TResult>(Func<T1, TResult> callback) => new FuncCallback<T1, TResult>(callback, true);
        /// <summary>
        /// Creates a new Callback instance from the given .Net method that will be disposed after the first call
        /// </summary>
        public static FuncCallback<T1, T2, TResult> CreateOne<T1, T2, TResult>(Func<T1, T2, TResult> callback) => new FuncCallback<T1, T2, TResult>(callback, true);
        /// <summary>
        /// Creates a new Callback instance from the given .Net method that will be disposed after the first call
        /// </summary>
        public static FuncCallback<T1, T2, T3, TResult> CreateOne<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> callback) => new FuncCallback<T1, T2, T3, TResult>(callback, true);
        /// <summary>
        /// Creates a new Callback instance from the given .Net method that will be disposed after the first call
        /// </summary>
        public static FuncCallback<T1, T2, T3, T4, TResult> CreateOne<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> callback) => new FuncCallback<T1, T2, T3, T4, TResult>(callback, true);
        /// <summary>
        /// Creates a new Callback instance from the given .Net method that will be disposed after the first call
        /// </summary>
        public static FuncCallback<T1, T2, T3, T4, T5, TResult> CreateOne<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> callback) => new FuncCallback<T1, T2, T3, T4, T5, TResult>(callback, true);
        /// <summary>
        /// Creates a new Callback instance from the given .Net method that will be disposed after the first call
        /// </summary>
        public static FuncCallback<T1, T2, T3, T4, T5, T6, TResult> CreateOne<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> callback) => new FuncCallback<T1, T2, T3, T4, T5, T6, TResult>(callback, true);
        /// <summary>
        /// Creates a new Callback instance from the given .Net method that will be disposed after the first call
        /// </summary>
        public static FuncCallback<T1, T2, T3, T4, T5, T6, T7, TResult> CreateOne<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> callback) => new FuncCallback<T1, T2, T3, T4, T5, T6, T7, TResult>(callback, true);
        // ActionCallback Create
        /// <summary>
        /// Creates a new Callback instance from the given .Net method
        /// </summary>
        public static ActionCallback Create(Action callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new ActionCallback(callback, false) : callbackGroup.Add(new ActionCallback(callback, false));
        /// <summary>
        /// Creates a new Callback instance from the given .Net method
        /// </summary>
        public static ActionCallback<T1> Create<T1>(Action<T1> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new ActionCallback<T1>(callback, false) : callbackGroup.Add(new ActionCallback<T1>(callback, false));
        /// <summary>
        /// Creates a new Callback instance from the given .Net method
        /// </summary>
        public static ActionCallback<T1, T2> Create<T1, T2>(Action<T1, T2> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new ActionCallback<T1, T2>(callback, false) : callbackGroup.Add(new ActionCallback<T1, T2>(callback, false));
        /// <summary>
        /// Creates a new Callback instance from the given .Net method
        /// </summary>
        public static ActionCallback<T1, T2, T3> Create<T1, T2, T3>(Action<T1, T2, T3> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new ActionCallback<T1, T2, T3>(callback, false) : callbackGroup.Add(new ActionCallback<T1, T2, T3>(callback, false));
        /// <summary>
        /// Creates a new Callback instance from the given .Net method
        /// </summary>
        public static ActionCallback<T1, T2, T3, T4> Create<T1, T2, T3, T4>(Action<T1, T2, T3, T4> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new ActionCallback<T1, T2, T3, T4>(callback, false) : callbackGroup.Add(new ActionCallback<T1, T2, T3, T4>(callback, false));
        /// <summary>
        /// Creates a new Callback instance from the given .Net method
        /// </summary>
        public static ActionCallback<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new ActionCallback<T1, T2, T3, T4, T5>(callback, false) : callbackGroup.Add(new ActionCallback<T1, T2, T3, T4, T5>(callback, false));
        /// <summary>
        /// Creates a new Callback instance from the given .Net method
        /// </summary>
        public static ActionCallback<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new ActionCallback<T1, T2, T3, T4, T5, T6>(callback, false) : callbackGroup.Add(new ActionCallback<T1, T2, T3, T4, T5, T6>(callback, false));
        /// <summary>
        /// Creates a new Callback instance from the given .Net method
        /// </summary>
        public static ActionCallback<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> callback, CallbackGroup? callbackGroup = null) => callbackGroup == null ? new ActionCallback<T1, T2, T3, T4, T5, T6, T7>(callback, false) : callbackGroup.Add(new ActionCallback<T1, T2, T3, T4, T5, T6, T7>(callback, false));
        // ActionCallback CreateOne
        /// <summary>
        /// Creates a new Callback instance from the given .Net method that will be disposed after the first call
        /// </summary>
        public static ActionCallback CreateOne(Action callback) => new ActionCallback(callback, true);
        /// <summary>
        /// Creates a new Callback instance from the given .Net method that will be disposed after the first call
        /// </summary>
        public static ActionCallback<T1> CreateOne<T1>(Action<T1> callback) => new ActionCallback<T1>(callback, true);
        /// <summary>
        /// Creates a new Callback instance from the given .Net method that will be disposed after the first call
        /// </summary>
        public static ActionCallback<T1, T2> CreateOne<T1, T2>(Action<T1, T2> callback) => new ActionCallback<T1, T2>(callback, true);
        /// <summary>
        /// Creates a new Callback instance from the given .Net method that will be disposed after the first call
        /// </summary>
        public static ActionCallback<T1, T2, T3> CreateOne<T1, T2, T3>(Action<T1, T2, T3> callback) => new ActionCallback<T1, T2, T3>(callback, true);
        /// <summary>
        /// Creates a new Callback instance from the given .Net method that will be disposed after the first call
        /// </summary>
        public static ActionCallback<T1, T2, T3, T4> CreateOne<T1, T2, T3, T4>(Action<T1, T2, T3, T4> callback) => new ActionCallback<T1, T2, T3, T4>(callback, true);
        /// <summary>
        /// Creates a new Callback instance from the given .Net method that will be disposed after the first call
        /// </summary>
        public static ActionCallback<T1, T2, T3, T4, T5> CreateOne<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> callback) => new ActionCallback<T1, T2, T3, T4, T5>(callback, true);
        /// <summary>
        /// Creates a new Callback instance from the given .Net method that will be disposed after the first call
        /// </summary>
        public static ActionCallback<T1, T2, T3, T4, T5, T6> CreateOne<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> callback) => new ActionCallback<T1, T2, T3, T4, T5, T6>(callback, true);
        /// <summary>
        /// Creates a new Callback instance from the given .Net method that will be disposed after the first call
        /// </summary>
        public static ActionCallback<T1, T2, T3, T4, T5, T6, T7> CreateOne<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> callback) => new ActionCallback<T1, T2, T3, T4, T5, T6, T7>(callback, true);
    }
}
