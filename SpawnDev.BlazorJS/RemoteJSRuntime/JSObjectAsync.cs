using Microsoft.JSInterop;
using SpawnDev.BlazorJS.Internal;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime
{
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class JSObjectAsync : IAsyncDisposable
    {
        public IJSObjectReference JSRef { get; protected set; }
        protected BlazorJSInteropAsync JSI;
        protected IJSRuntime JSRuntime;
        public JSObjectAsync(IJSObjectReference jsRef)
        {
            JSRef = jsRef;
            JSRuntime = JSRef.JSRefJSRuntime();
            JSI = new BlazorJSInteropAsync(JSRuntime);
        }
        public bool IsRefDisposed { get; protected set; }
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
