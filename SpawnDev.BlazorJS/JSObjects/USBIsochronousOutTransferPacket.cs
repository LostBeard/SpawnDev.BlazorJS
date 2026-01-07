using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The USBIsochronousOutTransferPacket interface of the WebUSB API is part of the response from a call to the isochronousTransferOut() method of the USBDevice interface. It represents the status of an individual packet from a request to transfer data from the USB host to the USB device over an isochronous endpoint.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/USBIsochronousOutTransferPacket
    /// </summary>
    public class USBIsochronousOutTransferPacket : JSObject
    {
        /// <inheritdoc/>
        public USBIsochronousOutTransferPacket(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the number of bytes from the packet that were sent to the device.
        /// </summary>
        public int BytesWritten => JSRef!.Get<int>("bytesWritten");
        /// <summary>
        /// Returns the status of the transfer request, one of:<br/>
        /// "ok" - The transfer was successful.<br/>
        /// "stall" - The device indicated an error by generating a stall condition on the endpoint. A stall on an isochronous endpoint does not need to be cleared.
        /// </summary>
        public string Status => JSRef!.Get<string>("status");
    }
}
