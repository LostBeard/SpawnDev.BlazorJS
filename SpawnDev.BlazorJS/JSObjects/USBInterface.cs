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

        /// <summary>
        /// The interface number of this interface. This is equal to the bInterfaceNumber field of the interface descriptor defining this interface.
        /// </summary>
        public int InterfaceNumber => JSRef!.Get<int>("interfaceNumber");

        /// <summary>
        /// The currently selected alternative configuration of this interface. By default, this is the USBAlternateInterface from alternates with alternateSetting equal to 0. It can be changed by calling USBDevice.selectAlternateInterface() with any other value found in alternates.
        /// </summary>
        public USBAlternateInterface Alternate => JSRef!.Get<USBAlternateInterface>("interfaceNumber");

        /// <summary>
        /// An array containing instances of the USBAlternateInterface interface describing each of the alternative configurations possible for this interface.
        /// </summary>
        public Array<USBAlternateInterface> Alternates => JSRef!.Get<Array<USBAlternateInterface>>("interfaceNumber");

        /// <summary>
        /// Whether this interface has been claimed by the current page by calling USBDevice.claimInterface().
        /// </summary>
        public bool Claimed => JSRef!.Get<bool>("interfaceNumber");
    }
}
