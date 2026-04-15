# USB

**Namespace:** `SpawnDev.BlazorJS.JSObjects.USB`  
**Inheritance:** `JSObject` -> `EventTarget` -> `USB`  
**MDN Reference:** [USB - MDN](https://developer.mozilla.org/en-US/docs/Web/API/USB)

> The `USB` interface of the WebUSB API provides access to USB devices from web pages. Access via `Navigator.Usb`. Requires a secure context and user gesture for `RequestDevice()`.

## Constructors

| Signature | Description |
|---|---|
| `USB(IJSInProcessObjectReference _ref)` | Deserialization constructor. Access via `navigator.Usb`. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RequestDevice(USBDeviceRequestOptions options)` | `Task<USBDevice>` | Requests a USB device. Shows a browser picker. Requires user gesture. |
| `GetDevices()` | `Task<USBDevice[]>` | Returns previously authorized devices. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnConnect` | `ActionEvent<USBConnectionEvent>` | Fired when a USB device is connected. |
| `OnDisconnect` | `ActionEvent<USBConnectionEvent>` | Fired when a USB device is disconnected. |

## Example

```csharp
using var navigator = new Navigator();
var usb = navigator.Usb;
if (usb != null)
{
    using var device = await usb.RequestDevice(new USBDeviceRequestOptions
    {
        Filters = new[] { new USBDeviceFilter { VendorId = 0x1234 } }
    });
    Console.WriteLine($"Device: {device.ProductName}");
}
```
