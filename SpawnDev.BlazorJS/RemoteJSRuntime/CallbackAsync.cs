using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime
{
    public abstract class CallbackAsync : IAsyncDisposable
    {
        [JsonInclude]
        [JsonPropertyName("_paramTypes")]
        public int[] _paramTypes { get; private set; } = new int[0];

        [JsonInclude]
        [JsonPropertyName("_returnVoid")]
        public bool _returnVoid { get; private set; }
        /// <summary>
        /// If true the Callback will be disposed after the first call
        /// </summary>
        protected bool once { get; private set; }

        [JsonInclude]
        [JsonPropertyName("_callbackAsyncId")]
        public string _callbackAsyncId;

        [JsonInclude]
        [JsonPropertyName("_callback")]
        public DotNetObjectReference<CallbackAsync> _callback { get; }

        IJSRuntime JSR;
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
        public async ValueTask DisposeAsync()
        {
            try
            {
                await JSR.CallVoidAsync("blazorJSInterop.DisposeCallbackAsync", _callbackAsyncId);
            }
            catch (Exception ex)
            {
                var nmt = true;
            }
            _callback.Dispose();
        }
    }
}
