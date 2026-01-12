using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The USBOutTransferResult interface of the WebUSB API provides the result from a call to the transferOut() and controlTransferOut() methods of the USBDevice interface. It represents the result from requesting a transfer of data from the USB host to the USB device.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/USBOutTransferResult
    /// </summary>
    public class USBOutTransferResult : JSObject
    {
        /// <inheritdoc/>
        public USBOutTransferResult(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the number of bytes from the transfer request that were sent to the device.
        /// </summary>
        public int BytesWritten => JSRef!.Get<int>("bytesWritten");
        /// <summary>
        /// Returns the status of the transfer request, one of:<br/>
        /// "ok" - The transfer was successful.<br/>
        /// "stall" - The device indicated an error by generating a stall condition on the endpoint. A stall on a bulk or interrupt endpoint must be cleared by calling clearHalt() before transferOut() can be called again.
        /// </summary>
        public string Status => JSRef!.Get<string>("status");
    }
}
