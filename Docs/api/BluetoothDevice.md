# BluetoothDevice

**Namespace:** `SpawnDev.BlazorJS.JSObjects.Bluetooth`  
**Inheritance:** `JSObject` -> `EventTarget` -> `BluetoothDevice`  
**MDN Reference:** [BluetoothDevice - MDN](https://developer.mozilla.org/en-US/docs/Web/API/BluetoothDevice)

> Represents a Bluetooth device. Provides access to the device name, ID, and GATT server for communicating with services and characteristics.

## Constructors

| Signature | Description |
|---|---|
| `BluetoothDevice(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|---|---|---|
| `Id` | `string` | A unique identifier for the device. |
| `Name` | `string?` | The human-readable name of the device. |
| `Gatt` | `BluetoothRemoteGATTServer?` | The GATT server for this device. Use to connect and discover services. |
| `GATT` | `BluetoothRemoteGATTServer?` | A reference to the device's BluetoothRemoteGATTServer. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnGATTServerDisconnected` | `ActionEvent<Event>` | Fired when the GATT server disconnects. |
| `OnAdvertisementReceived` | `ActionEvent<BluetoothAdvertisingEvent>` | https://googlechrome.github.io/samples/web-bluetooth/watch-advertisements.html |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Forget()` | `Task` | Provides a way for the page to revoke access to a device the user has granted access to. |
| `WatchAdvertisements(WatchAdvertisementsOptions? options = null)` | `Task` | A Promise that resolves to undefined or is rejected with an error if advertisements can't be shown for any reason. |

## Example

```csharp
using var device = await bluetooth.RequestDevice(options);
Console.WriteLine($"Name: {device.Name}, ID: {device.Id}");

// Subscribe using a named method (required for proper cleanup)
device.OnGATTServerDisconnected += Device_OnGATTServerDisconnected;

using var gatt = device.Gatt;
if (gatt != null)
{
    await gatt.Connect();
    // Discover services and characteristics...
}

// Clean up event handler before disposal
device.OnGATTServerDisconnected -= Device_OnGATTServerDisconnected;

void Device_OnGATTServerDisconnected(Event e)
{
    Console.WriteLine("Device disconnected");
}
```
