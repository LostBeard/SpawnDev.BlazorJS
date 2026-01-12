using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.RemoteJSRuntime.AsyncObjects
{
    /// <summary>
    /// EventTargetAsync provides an asynchronous interface for EventTarget.
    /// </summary>
    [JsonConverter(typeof(JSObjectAsyncConverterFactory))]
    public class EventTargetAsync : JSObjectAsync
    {
        /// <summary>
        /// Creates a new instance of <see cref="EventTargetAsync"/>.
        /// </summary>
        /// <param name="_ref"></param>
        public EventTargetAsync(IJSObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <param name="type">A string which specifies the type of event for which to add an event listener.</param>
        /// <param name="listener">The CallbackAsync that is the event listener.</param>
        /// <returns></returns>
        public Task AddEventListener(string type, CallbackAsync listener) => JSRef!.CallVoidAsync("addEventListener", type, listener);
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <param name="type">A string which specifies the type of event for which to add an event listener.</param>
        /// <param name="listener">The CallbackAsync that is the event listener.</param>
        /// <param name="useCapture">A boolean value that indicates whether events of this type will be dispatched to the registered listener before being dispatched to any EventTarget beneath it in the DOM tree.</param>
        /// <returns></returns>
        public Task AddEventListener(string type, CallbackAsync listener, bool useCapture) => JSRef!.CallVoidAsync("addEventListener", type, listener, useCapture);
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <param name="type">A string which specifies the type of event for which to remove an event listener.</param>
        /// <param name="listener">The CallbackAsync that is the event listener to remove.</param>
        /// <returns></returns>
        public Task RemoveEventListener(string type, CallbackAsync listener) => JSRef!.CallVoidAsync("removeEventListener", type, listener);
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <param name="type">A string which specifies the type of event for which to remove an event listener.</param>
        /// <param name="listener">The CallbackAsync that is the event listener to remove.</param>
        /// <param name="useCapture">A boolean value that indicates whether the EventListener should be removed during the capture phase or the bubbling phase.</param>
        /// <returns></returns>
        public Task RemoveEventListener(string type, CallbackAsync listener, bool useCapture) => JSRef!.CallVoidAsync("removeEventListener", type, listener, useCapture);
    }
}

