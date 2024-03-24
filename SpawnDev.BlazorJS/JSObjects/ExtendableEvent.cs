using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ExtendableEvent interface extends the lifetime of the install and activate events dispatched on the global scope as part of the service worker lifecycle. This ensures that any functional events (like FetchEvent) are not dispatched until it upgrades database schemas and deletes the outdated cache entries.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/ExtendableEvent
    /// </summary>
    public class ExtendableEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ExtendableEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Extends the lifetime of the event. It is intended to be called in the install event handler for the installing worker and on the activate event handler for the active worker.
        /// </summary>
        /// <param name="promise"></param>
        public void WaitUntil(Promise promise) => JSRef.CallVoid("waitUntil", promise);
        /// <summary>
        /// Extends the lifetime of the event. It is intended to be called in the install event handler for the installing worker and on the activate event handler for the active worker.
        /// </summary>
        /// <param name="promise"></param>
        public void WaitUntil(Task promise) => JSRef.CallVoid("waitUntil", (Promise)promise);
    }
}
