using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The USBInterface interface of the WebUSB API provides information about an interface provided by the USB device. An interface represents a feature of the device which implements a particular protocol and may contain endpoints for bidirectional communication.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/USBInterface
    /// </summary>
    public class USBInterface : JSObject
    {
        /// <inheritdoc/>
        public USBInterface(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
