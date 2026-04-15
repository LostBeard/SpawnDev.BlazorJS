# USBConnectionEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/USB/USBConnectionEvent.cs`  

> The USBConnectionEvent interface of the WebUSB API is the event type passed to USB connect and disconnect events when the user agent detects that a new USB device has been connected or disconnected.

## Constructors

| Signature | Description |
|---|---|
| `USBConnectionEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Device` | `USBDevice` | get | Returns a USBDevice object representing the current device. |

