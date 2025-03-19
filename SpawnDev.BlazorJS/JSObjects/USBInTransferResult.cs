using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The USBInTransferResult interface of the WebUSB API provides the result from a call to the transferIn() and controlTransferIn() methods of the USBDevice interface. It represents the result from requesting a transfer of data from the USB device to the USB host.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/USBInTransferResult
    /// </summary>
    public class USBInTransferResult : JSObject
    {
        ///<inheritdoc/>
        public USBInTransferResult(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a DataView object containing the data received from the USB device, if any.
        /// </summary>
        public DataView? Data => JSRef!.Get<DataView?>("data");
        /// <summary>
        /// Returns the status of the transfer request, one of:<br/>
        /// "ok" - The transfer was successful.<br/>
        /// "stall" - The device indicated an error by generating a stall condition on the endpoint. A stall on the control endpoint does not need to be cleared. A stall on a bulk or interrupt endpoint must be cleared by calling clearHalt() before transferIn() can be called again.<br/>
        /// "babble" - The device responded with more data than was expected.
        /// </summary>
        public string Status => JSRef!.Get<string>("status");
    }
}
