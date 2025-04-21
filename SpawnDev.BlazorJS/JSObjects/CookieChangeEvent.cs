using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CookieChangeEvent/changed
    /// </summary>
    public class CookieChangeEvent : Event
    {
        /// <inheritdoc/>
        public CookieChangeEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns an array containing the changed cookies.
        /// </summary>
        public Cookie[] Changed => JSRef!.Get<Cookie[]>("changed");
        /// <summary>
        /// Returns an array containing the deleted cookies.
        /// </summary>
        public Cookie[] Deleted => JSRef!.Get<Cookie[]>("deleted");
    }
}
