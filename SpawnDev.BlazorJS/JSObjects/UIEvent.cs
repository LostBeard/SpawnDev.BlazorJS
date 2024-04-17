using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The UIEvent interface represents simple user interface events.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/UIEvent
    /// </summary>
    public class UIEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public UIEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a WindowProxy that contains the view that generated the event.
        /// </summary>
        public WindowProxy View => JSRef.Get<WindowProxy>("view");
        /// <summary>
        /// Returns a long with details about the event, depending on the event type.
        /// </summary>
        public long Detail => JSRef.Get<long>("detail");
        /// <summary>
        /// Returns an instance of the InputDeviceCapabilities interface, which provides information about the physical device responsible for generating a touch event.
        /// </summary>
        public InputDeviceCapabilities SourceCapabilities => JSRef.Get<InputDeviceCapabilities>("sourceCapabilities");
        /// <summary>
        /// Returns the numeric keyCode of the key pressed, or the character code (charCode) for an alphanumeric key pressed.<br />
        /// Deprecated:<br />
        /// - This feature is no longer recommended. Though some browsers might still support it, it may have already been removed from the relevant web standards, may be in the process of being dropped, or may only be kept for compatibility purposes. Avoid using it, and update existing code if possible; see the compatibility table at the bottom of this page to guide your decision. Be aware that this feature may cease to work at any time.
        /// </summary>
        public int Which => JSRef.Get<int>("which");
    }
}
