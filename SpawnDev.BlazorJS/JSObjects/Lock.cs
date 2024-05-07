using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Lock interface of the Web Locks API provides the name and mode of a lock. This may be a newly requested lock that is received in the callback to LockManager.request(), or a record of an active or queued lock returned by LockManager.query().<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Lock
    /// </summary>
    public class Lock : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Lock(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the access mode passed to LockManager.request() when the lock was requested. The mode is either "exclusive" (the default) or "shared".
        /// </summary>
        public string Mode => JSRef!.Get<string>("mode");
        /// <summary>
        /// Returns the name passed to LockManager.request() when the lock was requested.
        /// </summary>
        public string Name => JSRef!.Get<string>("name");
    }
}
