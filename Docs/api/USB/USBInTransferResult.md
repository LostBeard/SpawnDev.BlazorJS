# USBInTransferResult

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/USB/USBInTransferResult.cs`  
**MDN Reference:** [USBInTransferResult on MDN](https://developer.mozilla.org/en-US/docs/Web/API/USBInTransferResult)

> The USBInTransferResult interface of the WebUSB API provides the result from a call to the transferIn() and controlTransferIn() methods of the USBDevice interface. It represents the result from requesting a transfer of data from the USB device to the USB host. https://developer.mozilla.org/en-US/docs/Web/API/USBInTransferResult

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Data` | `DataView?` | get | Returns a DataView object containing the data received from the USB device, if any. |
| `Status` | `string` | get | Returns the status of the transfer request, one of: "ok" - The transfer was successful. "stall" - The device indicated an error by generating a stall condition on the endpoint. A stall on the control endpoint does not need to be cleared. A stall on a bulk or interrupt endpoint must be cleared by calling clearHalt() before transferIn() can be called again. "babble" - The device responded with more data than was expected. |

