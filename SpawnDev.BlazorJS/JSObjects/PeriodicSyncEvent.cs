using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PeriodicSyncEvent interface of the Web Periodic Background Synchronization API provides a way to run tasks in the service worker with network connectivity.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/PeriodicSyncEvent
    /// </summary>
    public class PeriodicSyncEvent : ExtendableEvent
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PeriodicSyncEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the developer-defined identifier for this PeriodicSyncEvent. Multiple tags can be used by the web app to run different periodic tasks at different frequencies.
        /// </summary>
        public string Tag => JSRef.Get<string>("tag");
    }
}
