# USBIsochronousInTransferPacket

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/USB/USBIsochronousInTransferPacket.cs`  
**MDN Reference:** [USBIsochronousInTransferPacket on MDN](https://developer.mozilla.org/en-US/docs/Web/API/USBIsochronousInTransferPacket)

> The USBIsochronousInTransferPacket interface of the WebUSB API is part of the response from a call to the isochronousTransferIn() method of the USBDevice interface. It represents the status of an individual packet from a request to transfer data from the USB device to the USB host over an isochronous endpoint. https://developer.mozilla.org/en-US/docs/Web/API/USBIsochronousInTransferPacket

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Data` | `DataView` | get | Returns a DataView object containing the data received from the USB device in this packet, if any. |
| `Status` | `string` | get | Returns the status of the transfer request, one of: "ok" - The transfer was successful. "stall" - The device indicated an error by generating a stall condition on the endpoint.A stall on an isochronous endpoint does not need to be cleared. "babble" - The device responded with more data than was expected. |

