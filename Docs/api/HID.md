# HID

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/HID.cs`  
**MDN Reference:** [HID on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HID)

> The HID interface provides methods for connecting to HID devices, listing attached HID devices and event handlers for connected HID devices. https://developer.mozilla.org/en-US/docs/Web/API/HID

## Constructors

| Signature | Description |
|---|---|
| `HID(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetDevices()` | `Task<Array<HIDDevice>>` | Returns a Promise that resolves with an array of connected HIDDevice objects. |
| `RequestDevice(HIDDeviceRequestOptions options)` | `Task<Array<HIDDevice>>` | Returns a Promise that resolves with an array of connected HIDDevice objects. Calling this function will trigger the user agent's permission flow in order to gain permission to access one selected device from the returned list of devices. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnConnect` | `ActionEvent<HIDConnectionEvent>` | Fired when an HID device is connected. |
| `OnDisconnect` | `ActionEvent<HIDConnectionEvent>` | Fired when an HID device is disconnected. |

