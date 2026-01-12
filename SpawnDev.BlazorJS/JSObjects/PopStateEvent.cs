using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PopStateEvent interface of the HTML 5 History API represents an event that is fired when the active history entry changes.
    /// </summary>
    public class PopStateEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PopStateEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the state object associated with the event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T StateAs<T>() => JSRef!.Get<T>("state");
    }
}
