# BluetoothRemoteGATTService

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Bluetooth/BluetoothRemoteGATTService.cs`  
**MDN Reference:** [BluetoothRemoteGATTService on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BluetoothRemoteGATTService)

> The BluetoothRemoteGATTService interface of the Web Bluetooth API represents a service provided by a GATT server, including a device, a list of referenced services, and a list of the characteristics of this service. https://developer.mozilla.org/en-US/docs/Web/API/BluetoothRemoteGATTService

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Device` | `BluetoothDevice` | get | Returns information about a Bluetooth device through an instance of BluetoothDevice. |
| `IsPrimary` | `bool` | get | Returns a boolean value indicating whether this is a primary or secondary service. |
| `UUID` | `string` | get | Returns a string representing the UUID of this service. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetCharacteristic(string characteristicUUID)` | `Task<BluetoothRemoteGATTCharacteristic>` | Returns a Promise to an instance of BluetoothRemoteGATTCharacteristic for a given universally unique identifier (UUID). |
| `GetCharacteristics(string characteristicUUID)` | `Task<BluetoothRemoteGATTCharacteristic[]>` | Returns a Promise to an Array of BluetoothRemoteGATTCharacteristic instances for an optional universally unique identifier (UUID). |

## Events

| Event | Type | Description |
|---|---|---|
| `OnServiceAdded` | `ActionEvent<Event>` | Fired on a new BluetoothRemoteGATTService when it has been discovered on a remote device, just after it is added to the Bluetooth tree. |
| `OnServiceChanged` | `ActionEvent<Event>` | Fired on a BluetoothRemoteGATTService when its state changes. This involves any characteristics and/or descriptors that get added or removed from the service, as well as Service Changed indications from the remote device. |
| `OnServiceRemoved` | `ActionEvent<Event>` | Fired on a BluetoothRemoteGATTService when it has been removed from its device, just before it is removed from the Bluetooth tree. |

