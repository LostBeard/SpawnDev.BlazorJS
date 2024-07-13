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
        public Window View => JSRef!.Get<Window>("view");
        /// <summary>
        /// Returns a long with details about the event, depending on the event type.
        /// </summary>
        public long Detail => JSRef!.Get<long>("detail");
        /// <summary>
        /// Returns an instance of the InputDeviceCapabilities interface, which provides information about the physical device responsible for generating a touch event.
        /// </summary>
        public InputDeviceCapabilities SourceCapabilities => JSRef!.Get<InputDeviceCapabilities>("sourceCapabilities");
    }
}
