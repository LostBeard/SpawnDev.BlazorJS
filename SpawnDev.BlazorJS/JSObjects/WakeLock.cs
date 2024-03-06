using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WakeLock interface of the Screen Wake Lock API can be used to request a lock that prevents device screens from dimming or locking when an application needs to keep running.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/WakeLock
    /// </summary>
    public class WakeLock : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WakeLock(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a Promise that fulfills with a WakeLockSentinel object if the screen wake lock is granted.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Task<WakeLockSentinel> Request(string type = "screen") => JSRef.CallAsync<WakeLockSentinel>("request", type);
    }
}
