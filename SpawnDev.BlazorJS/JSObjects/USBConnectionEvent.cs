using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The USBConnectionEvent interface of the WebUSB API is the event type passed to USB connect and disconnect events when the user agent detects that a new USB device has been connected or disconnected.
    /// </summary>
    public class USBConnectionEvent : Event
    {
        public USBConnectionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a USBDevice object representing the current device.
        /// </summary>
        public USBDevice Device => JSRef.Get<USBDevice>("device");
    }
}
