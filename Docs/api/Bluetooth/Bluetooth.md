# Bluetooth

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Bluetooth/Bluetooth.cs`  
**MDN Reference:** [Bluetooth on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Bluetooth)

> The Bluetooth interface of the Web Bluetooth API provides methods to query Bluetooth availability and request access to devices. https://developer.mozilla.org/en-US/docs/Web/API/Bluetooth https://webbluetoothcg.github.io/web-bluetooth/

## Constructors

| Signature | Description |
|---|---|
| `Bluetooth(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetAvailability()` | `Task<bool>` | The getAvailability() method of the Bluetooth interface returns true if the device has a Bluetooth adapter, and false otherwise (unless the user has configured the browser to not expose a real value). |
| `RequestDevice()` | `Task<BluetoothDevice>` | Returns a Promise to a BluetoothDevice object with the specified options. |
| `RequestDevice(BluetoothDeviceOptions options)` | `Task<BluetoothDevice>` | Returns a Promise to a BluetoothDevice object with the specified options. |
| `GetDevices()` | `Task<Array<BluetoothDevice>>` | Returns a Promise that resolves to an array of BluetoothDevices this origin is allowed to access. Permission is obtained via previous calls to Bluetooth.requestDevice(). |

## Example

```csharp
// Access Bluetooth from the navigator
using var navigator = JS.Get<Navigator>("navigator");
using var bluetooth = navigator.Bluetooth;

// Check if Bluetooth is available on this device
bool available = await bluetooth.GetAvailability();
Console.WriteLine($"Bluetooth available: {available}");

// Request a Bluetooth device with service filters (requires user gesture)
using var device = await bluetooth.RequestDevice(new BluetoothDeviceOptions
{
    Filters = new[]
    {
        new BluetoothDeviceFilter { Services = new[] { "heart_rate" } }
    },
    OptionalServices = new[] { "battery_service" }
});

Console.WriteLine($"Device: {device.Name} (ID: {device.Id})");

// Connect to the GATT server
using var gatt = device.GATT;
if (gatt != null)
{
    using var server = await gatt.Connect();
    Console.WriteLine($"Connected: {server.Connected}");

    // Get a GATT service and read characteristics
    // using var service = await server.GetPrimaryService("heart_rate");
    // using var characteristic = await service.GetCharacteristic("heart_rate_measurement");

    // Disconnect when done
    server.Disconnect();
}

// Listen for disconnection (named method for proper cleanup)
device.OnGATTServerDisconnected += Device_OnGATTServerDisconnected;

// List previously paired devices
using var devices = await bluetooth.GetDevices();
Console.WriteLine($"Previously paired devices: {devices.Length}");

// Clean up event handler before disposal
device.OnGATTServerDisconnected -= Device_OnGATTServerDisconnected;

void Device_OnGATTServerDisconnected(Event e)
{
    Console.WriteLine("Bluetooth device disconnected");
}
```

