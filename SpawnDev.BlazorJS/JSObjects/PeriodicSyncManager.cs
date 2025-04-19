using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PeriodicSyncManager interface of the Web Periodic Background Synchronization API provides a way to register tasks to be run in a service worker at periodic intervals with network connectivity. These tasks are referred to as periodic background sync requests. Access PeriodicSyncManager through the ServiceWorkerRegistration.periodicSync.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PeriodicSyncManager
    /// </summary>
    public class PeriodicSyncManager : JSObject
    {
        /// <inheritdoc/>
        public PeriodicSyncManager(IJSInProcessObjectReference _ref) : base(_ref) { }
        #region Methods
        /// <summary>
        /// The register() method of the PeriodicSyncManager interface registers a periodic sync request with the browser with the specified tag and options. It returns a Promise that resolves when the registration completes.
        /// </summary>
        /// <param name="tag">A unique String identifier.</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task Register(string tag, PeriodicSyncOptions? options = null) => options == null ? JSRef!.CallVoidAsync("register", tag) : JSRef!.CallVoidAsync("register", tag, options);
        /// <summary>
        /// The unregister() method of the PeriodicSyncManager interface unregisters the periodic sync request corresponding to the specified tag and returns a Promise that resolves when unregistration completes.
        /// </summary>
        /// <param name="tag">The unique String descriptor for the specific background sync.</param>
        /// <returns></returns>
        public Task Unregister(string tag) => JSRef!.CallVoidAsync("unregister", tag);
        /// <summary>
        /// The getTags() method of the PeriodicSyncManager interface returns a Promise that resolves with a list of String objects representing the tags that are currently registered for periodic syncing.
        /// </summary>
        /// <returns></returns>
        public Task<string[]> GetTags() => JSRef!.CallAsync<string[]>("getTags");
        #endregion
    }
}
