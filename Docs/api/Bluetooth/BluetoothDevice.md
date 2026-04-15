# BluetoothDevice

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Bluetooth/BluetoothDevice.cs`  
**MDN Reference:** [BluetoothDevice on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BluetoothDevice)

> The BluetoothDevice interface of the Web Bluetooth API represents a Bluetooth device inside a particular script execution environment. https://developer.mozilla.org/en-US/docs/Web/API/BluetoothDevice

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Id` | `string` | get | A string that uniquely identifies a device. |
| `Name` | `string?` | get | A string that provides a human-readable name for the device. |
| `GATT` | `BluetoothRemoteGATTServer?` | get | A reference to the device's BluetoothRemoteGATTServer. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Forget()` | `Task` | Provides a way for the page to revoke access to a device the user has granted access to. |
| `WatchAdvertisements(WatchAdvertisementsOptions? options)` | `Task` | A Promise that resolves to undefined or is rejected with an error if advertisements can't be shown for any reason. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnGATTServerDisconnected` | `ActionEvent<Event>` | Fired on a device when an active GATT connection is lost. |
| `OnAdvertisementReceived` | `ActionEvent<BluetoothAdvertisingEvent>` | https://googlechrome.github.io/samples/web-bluetooth/watch-advertisements.html |

