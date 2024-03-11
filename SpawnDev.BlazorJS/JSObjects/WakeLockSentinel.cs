using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WakeLockSentinel interface of the Screen Wake Lock API can be used to monitor the status of the platform screen wake lock, and manually release the lock when needed.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/WakeLockSentinel
    /// </summary>
    public class WakeLockSentinel : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WakeLockSentinel(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a boolean indicating whether the WakeLockSentinel has been released.
        /// </summary>
        public bool Released => JSRef.Get<bool>("released");
        /// <summary>
        /// Returns a string representation of the currently acquired WakeLockSentinel type. Return values are:<br />
        /// screen: A screen wake lock. Prevents devices from dimming or locking the screen.
        /// </summary>
        public string Type => JSRef.Get<string>("type");
        /// <summary>
        /// release event
        /// </summary>
        public JSEventCallback<Event> OnRelease { get => new JSEventCallback<Event>("release", AddEventListener, RemoveEventListener); set { } }
    }
}
