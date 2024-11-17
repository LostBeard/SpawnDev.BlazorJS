using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class EventTargetAsync : JSObjectAsync
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public EventTargetAsync(IJSObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        public Task AddEventListener(string type, CallbackAsync listener) => JSRef!.CallVoidAsync("addEventListener", type, listener);

        public Task AddEventListener(string type, CallbackAsync listener, bool useCapture) => JSRef!.CallVoidAsync("addEventListener", type, listener, useCapture);

        public Task RemoveEventListener(string type, CallbackAsync listener) => JSRef!.CallVoidAsync("removeEventListener", type, listener);

        public Task RemoveEventListener(string type, CallbackAsync listener, bool useCapture) => JSRef!.CallVoidAsync("removeEventListener", type, listener, useCapture);
    }
}

