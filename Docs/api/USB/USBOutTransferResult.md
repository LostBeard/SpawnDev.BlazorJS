# USBOutTransferResult

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/USB/USBOutTransferResult.cs`  
**MDN Reference:** [USBOutTransferResult on MDN](https://developer.mozilla.org/en-US/docs/Web/API/USBOutTransferResult)

> The USBOutTransferResult interface of the WebUSB API provides the result from a call to the transferOut() and controlTransferOut() methods of the USBDevice interface. It represents the result from requesting a transfer of data from the USB host to the USB device. https://developer.mozilla.org/en-US/docs/Web/API/USBOutTransferResult

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BytesWritten` | `int` | get | Returns the number of bytes from the transfer request that were sent to the device. |
| `Status` | `string` | get | Returns the status of the transfer request, one of: "ok" - The transfer was successful. "stall" - The device indicated an error by generating a stall condition on the endpoint. A stall on a bulk or interrupt endpoint must be cleared by calling clearHalt() before transferOut() can be called again. |

