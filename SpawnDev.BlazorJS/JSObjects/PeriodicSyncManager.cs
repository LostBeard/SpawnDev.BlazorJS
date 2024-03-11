using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PeriodicSyncManager interface of the Web Periodic Background Synchronization API provides a way to register tasks to be run in a service worker at periodic intervals with network connectivity. These tasks are referred to as periodic background sync requests. Access PeriodicSyncManager through the ServiceWorkerRegistration.periodicSync.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/PeriodicSyncManager
    /// </summary>
    public class PeriodicSyncManager : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PeriodicSyncManager(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
