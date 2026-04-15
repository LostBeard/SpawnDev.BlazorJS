# USB

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/USB/USB.cs`  
**MDN Reference:** [USB on MDN](https://developer.mozilla.org/en-US/docs/Web/API/USB)

> The USB interface of the WebUSB API provides attributes and methods for finding and connecting USB devices from a web page. https://developer.mozilla.org/en-US/docs/Web/API/USB

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetDevices()` | `Task<Array<USBDevice>>` | Returns a Promise that resolves with an array of USBDevice objects for paired attached devices. |
| `RequestDevice(USBDeviceRequestOptions options)` | `Task<USBDevice>` | Returns a Promise that resolves with an instance of USBDevice if the specified device is found. Calling this function triggers the user agent's pairing flow. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnConnect` | `ActionEvent<USBConnectionEvent>` | The connect event of the USB interface is fired whenever a paired device is connected. |
| `OnDisconnect` | `ActionEvent<USBConnectionEvent>` | The disconnect event of the USB interface is fired whenever a paired device is disconnected. |

