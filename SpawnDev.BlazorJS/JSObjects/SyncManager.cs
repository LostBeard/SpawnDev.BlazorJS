using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SyncManager interface of the Background Synchronization API provides an interface for registering and listing sync registrations.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/SyncManager
    /// </summary>
    public class SyncManager : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public SyncManager(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The SyncManager interface of the Background Synchronization API provides an interface for registering and listing sync registrations.
        /// </summary>
        /// <param name="tag">An identifier for this synchronization event. This will be the value of the tag property of the SyncEvent that gets passed into the service worker's sync event handler.</param>
        /// <returns></returns>
        public Task Register(string tag) =>  JSRef!.CallVoidAsync("register", tag);
        /// <summary>
        /// The getTags() method of the SyncManager interface returns a list of developer-defined identifiers for SyncManager registrations.
        /// </summary>
        /// <returns></returns>
        public Task<string[]> GetTags() => JSRef!.CallAsync<string[]>("getTags");
    }
}
