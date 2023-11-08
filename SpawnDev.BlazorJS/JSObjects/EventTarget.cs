using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class AddEventListenerOptions
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool Capture { get; set; } = false;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Once { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Passive { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AbortSignal? Signal { get; set; } = null;
    }

    /// <summary>
    /// The EventTarget interface is implemented by objects that can receive events and may have listeners for them. In other words, any target of events implements the three methods associated with this interface.
    /// </summary>
    public class EventTarget : JSObject
    {
        /// <summary>
        /// The EventTarget() constructor creates a new EventTarget object instance.
        /// </summary>
        public EventTarget() : base(JS.New(nameof(EventTarget))) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public EventTarget(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The dispatchEvent() method of the EventTarget sends an Event to the object, (synchronously) invoking the affected event listeners in the appropriate order. The normal event processing rules (including the capturing and optional bubbling phase) also apply to events dispatched manually with dispatchEvent().
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public bool DispatchEvent(Event @event) => JSRef.Call<bool>("dispatchEvent", @event);
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void AddEventListener(string type, Callback listener, bool useCapture = false) => JSRef.CallVoid("addEventListener", type, listener, useCapture);
        /// <summary>
        /// Registers an event handler of a specific event type on the EventTarget.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void AddEventListener(string type, Callback listener, AddEventListenerOptions options) => JSRef.CallVoid("addEventListener", type, listener, options);
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="useCapture"></param>
        public void RemoveEventListener(string type, Callback listener, bool useCapture = false) => JSRef.CallVoid("removeEventListener", type, listener, useCapture);
        /// <summary>
        /// Removes an event listener from the EventTarget.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listener"></param>
        /// <param name="options"></param>
        public void RemoveEventListener(string type, Callback listener, AddEventListenerOptions options) => JSRef.CallVoid("removeEventListener", type, listener, options);
    }
}