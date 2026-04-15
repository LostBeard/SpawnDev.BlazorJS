# USBIsochronousInTransferResult

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/USB/USBIsochronousInTransferResult.cs`  
**MDN Reference:** [USBIsochronousInTransferResult on MDN](https://developer.mozilla.org/en-US/docs/Web/API/USBIsochronousInTransferResult)

> The USBIsochronousInTransferResult interface of the WebUSB API provides the result from a call to the isochronousTransferIn() method of the USBDevice interface. It represents the result from requesting a transfer of data from the USB device to the USB host. https://developer.mozilla.org/en-US/docs/Web/API/USBIsochronousInTransferResult

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Data` | `DataView` | get | Returns a DataView object containing the data received from the device. This is the combined data from all packets. See the individual DataView objects in the packets array for the portion of this buffer containing data from each packet. |
| `Packets` | `Array<USBIsochronousInTransferPacket>` | get | Returns an array of USBIsochronousInTransferPacket objects containing the result of each request to receive a packet from the device. |

