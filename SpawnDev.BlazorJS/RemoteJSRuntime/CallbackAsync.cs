using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime
{
    /// <summary>
    /// Base class for asynchronous callbacks
    /// </summary>
    public abstract class CallbackAsync : IAsyncDisposable
    {
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
        protected bool once { get; private set; }

        /// <summary>
        /// The unique ID for the callback
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("_callbackAsyncId")]
        public string _callbackAsyncId;

        /// <summary>
        /// The DotNetObjectReference for the callback
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("_callback")]
        public DotNetObjectReference<CallbackAsync> _callback { get; }

        IJSRuntime JSR;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="jsr"></param>
        /// <param name="once"></param>
        protected CallbackAsync(IJSRuntime jsr, bool once)
        {
            JSR = jsr;
            var JSRuntimeSerializerOptionsInfo = new JSRuntimeSerializerOptionsInfo(jsr);
            _callbackAsyncId = Guid.NewGuid().ToString();
            var callbackType = this.GetType();
            _callback = DotNetObjectReference.Create(this);
            var methodInfo = callbackType.GetMethod("InvokeAsync");
            if (methodInfo != null)
            {
                var paramInfos = methodInfo.GetParameters();
                _paramTypes = new int[paramInfos.Length];
                for (var i = 0; i < _paramTypes.Length; i++)
                {
                    var paramType = paramInfos[i].ParameterType;
                    var jsCallResultType = JSRuntimeSerializerOptionsInfo.FromGenericForCallback(paramType);
                    // _paramTypes will let JSInterop know how to prepare the parameters values for invocation
                    _paramTypes[i] = (int)jsCallResultType;
                }
                _returnVoid = methodInfo.ReturnType == typeof(void);
            }
            this.once = once;
        }
        /// <summary>
        /// Disposes of the instance
        /// </summary>
        /// <returns></returns>
        public async ValueTask DisposeAsync()
        {
            try
            {
                await JSR.CallVoidAsync("blazorJSInterop.DisposeCallbackAsync", _callbackAsyncId);
            }
            catch
            {
                // continue
            }
            _callback.Dispose();
        }
    }
}
