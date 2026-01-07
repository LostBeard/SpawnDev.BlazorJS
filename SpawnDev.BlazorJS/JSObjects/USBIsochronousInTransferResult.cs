using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The USBIsochronousInTransferResult interface of the WebUSB API provides the result from a call to the isochronousTransferIn() method of the USBDevice interface. It represents the result from requesting a transfer of data from the USB device to the USB host.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/USBIsochronousInTransferResult
    /// </summary>
    public class USBIsochronousInTransferResult : JSObject
    {
        /// <inheritdoc/>
        public USBIsochronousInTransferResult(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a DataView object containing the data received from the device. This is the combined data from all packets. See the individual DataView objects in the packets array for the portion of this buffer containing data from each packet.
        /// </summary>
        public DataView Data => JSRef!.Get<DataView>("data");
        /// <summary>
        /// Returns an array of USBIsochronousInTransferPacket objects containing the result of each request to receive a packet from the device.
        /// </summary>
        public Array<USBIsochronousInTransferPacket> Packets => JSRef!.Get<Array<USBIsochronousInTransferPacket>>("packets");
    }
}
