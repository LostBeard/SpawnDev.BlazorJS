using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HIDDevice interface of the WebHID API represents a HID Device. It provides properties for accessing information about the device, methods for opening and closing the connection, and the sending and receiving of reports.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/HIDDevice
    /// </summary>
    public class HIDDevice : EventTarget
    {
        public HIDDevice(IJSInProcessObjectReference _ref) : base(_ref) { }
        // TODO finish
    }
}
