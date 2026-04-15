# USBIsochronousOutTransferPacket

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/USB/USBIsochronousOutTransferPacket.cs`  
**MDN Reference:** [USBIsochronousOutTransferPacket on MDN](https://developer.mozilla.org/en-US/docs/Web/API/USBIsochronousOutTransferPacket)

> The USBIsochronousOutTransferPacket interface of the WebUSB API is part of the response from a call to the isochronousTransferOut() method of the USBDevice interface. It represents the status of an individual packet from a request to transfer data from the USB host to the USB device over an isochronous endpoint. https://developer.mozilla.org/en-US/docs/Web/API/USBIsochronousOutTransferPacket

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BytesWritten` | `int` | get | Returns the number of bytes from the packet that were sent to the device. |
| `Status` | `string` | get | Returns the status of the transfer request, one of: "ok" - The transfer was successful. "stall" - The device indicated an error by generating a stall condition on the endpoint. A stall on an isochronous endpoint does not need to be cleared. |

