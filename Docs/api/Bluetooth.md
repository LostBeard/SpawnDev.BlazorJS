# Bluetooth

**Namespace:** `SpawnDev.BlazorJS.JSObjects.Bluetooth`  
**Inheritance:** `JSObject` -> `EventTarget` -> `Bluetooth`  
**MDN Reference:** [Bluetooth - MDN](https://developer.mozilla.org/en-US/docs/Web/API/Bluetooth)

> The `Bluetooth` interface of the Web Bluetooth API provides methods to query and connect to Bluetooth Low Energy (BLE) devices. Access via `Navigator.Bluetooth`. Requires a secure context (HTTPS) and user gesture for `RequestDevice()`.

## Constructors

| Signature | Description |
|---|---|
| `Bluetooth(IJSInProcessObjectReference _ref)` | Deserialization constructor. Access via `navigator.Bluetooth`. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RequestDevice(BluetoothDeviceOptions options)` | `Task<BluetoothDevice>` | Requests a device from the user. Shows a browser picker dialog. Requires user gesture. |
| `GetDevices()` | `Task<BluetoothDevice[]>` | Returns previously paired devices (if the browser supports it). |

## Events

| Event | Type | Description |
|---|---|---|
| `OnAvailabilityChanged` | `ActionEvent<Event>` | Fired when Bluetooth adapter availability changes. |

## Example

```csharp
using var navigator = new Navigator();
var bluetooth = navigator.Bluetooth;
if (bluetooth != null)
{
    using var device = await bluetooth.RequestDevice(new BluetoothDeviceOptions
    {
        Filters = new[] { new BluetoothDeviceFilter { Services = new[] { "heart_rate" } } }
    });
    Console.WriteLine($"Device: {device.Name}");
}
```
