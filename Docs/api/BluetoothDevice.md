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

## Events

| Event | Type | Description |
|---|---|---|
| `OnGATTServerDisconnected` | `ActionEvent<Event>` | Fired when the GATT server disconnects. |

## Example

```csharp
using var device = await bluetooth.RequestDevice(options);
Console.WriteLine($"Name: {device.Name}, ID: {device.Id}");

device.OnGATTServerDisconnected += (Event e) =>
{
    Console.WriteLine("Device disconnected");
};

using var gatt = device.Gatt;
if (gatt != null)
{
    await gatt.Connect();
    // Discover services and characteristics...
}
```
