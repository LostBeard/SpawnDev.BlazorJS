using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ToggleEvent interface represents an event notifying the user when a popover element's state toggles between showing and hidden.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/ToggleEvent
    /// </summary>
    public class ToggleEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ToggleEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string (either "open" or "closed"), representing the state the element is transitioning to.
        /// </summary>
        public string NewState => JSRef.Get<string>("newState");
        /// <summary>
        /// A string (either "open" or "closed"), representing the state the element is transitioning from.
        /// </summary>
        public string OldState => JSRef.Get<string>("oldState");

    }
}