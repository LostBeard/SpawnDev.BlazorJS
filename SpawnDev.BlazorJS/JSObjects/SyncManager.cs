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

    }
}
