using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The USBDevice interface of the WebUSB API provides access to metadata about a paired USB device and methods for control<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/USBDevice<br />
    /// TODO - finish interface
    /// </summary>
    public class USBDevice : JSObject
    {

        #region Constructors
        public USBDevice(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion
    }
}
