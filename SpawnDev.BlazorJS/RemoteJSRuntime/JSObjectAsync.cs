using Microsoft.JSInterop;
using SpawnDev.BlazorJS.Internal;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime
{
    /// <summary>
    /// Wraps a IJSObjectReference provinding additional functionality
    /// </summary>
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class JSObjectAsync : IAsyncDisposable
    {
        /// <summary>
        /// The wrapped IJSObjectReference
        /// </summary>
        public IJSObjectReference JSRef { get; protected set; }
        /// <summary>
        /// BlazorJSInteropAsync
        /// </summary>
        protected BlazorJSInteropAsync JSI;
        /// <summary>
        /// The JS runtime
        /// </summary>
        protected IJSRuntime JSRuntime;
        /// <summary>
        /// New instance
        /// </summary>
        /// <param name="jsRef"></param>
        public JSObjectAsync(IJSObjectReference jsRef)
        {
            JSRef = jsRef;
            JSRuntime = JSRef.JSRefJSRuntime();
            JSI = new BlazorJSInteropAsync(JSRuntime);
        }
        /// <summary>
        /// returns true if the reference has been disposed
        /// </summary>
        public bool IsRefDisposed { get; protected set; }
        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            if (IsRefDisposed) return;
            IsRefDisposed = true;
            if (JSRef != null)
            {
                await JSRef.DisposeAsync();
            }
        }
    }
}
