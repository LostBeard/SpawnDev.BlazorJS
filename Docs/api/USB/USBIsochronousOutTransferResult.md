# USBIsochronousOutTransferResult

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/USB/USBIsochronousOutTransferResult.cs`  
**MDN Reference:** [USBIsochronousOutTransferResult on MDN](https://developer.mozilla.org/en-US/docs/Web/API/USBIsochronousOutTransferResult)

> The USBIsochronousOutTransferResult interface of the WebUSB API provides the result from a call to the isochronousTransferOut() method of the USBDevice interface. It represents the result from requesting a transfer of data from the USB host to the USB device. https://developer.mozilla.org/en-US/docs/Web/API/USBIsochronousOutTransferResult

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Packets` | `Array<USBIsochronousOutTransferPacket>` | get | Returns an array of USBIsochronousOutTransferPacket objects containing the result of each request to send a packet to the device. |

