# BluetoothRemoteGATTServer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Bluetooth/BluetoothRemoteGATTServer.cs`  
**MDN Reference:** [BluetoothRemoteGATTServer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BluetoothRemoteGATTServer)

> The BluetoothRemoteGATTServer interface of the Web Bluetooth API represents a GATT Server on a remote device. https://developer.mozilla.org/en-US/docs/Web/API/BluetoothRemoteGATTServer

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Connected` | `bool` | get | A boolean value that returns true while this script execution environment is connected to this.device. It can be false while the user agent is physically connected. |
| `Device` | `BluetoothDevice` | get | A reference to the BluetoothDevice running the server. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Connect()` | `Task<BluetoothRemoteGATTServer>` | Causes the script execution environment to connect to this.device. |
| `Disconnect()` | `void` | Causes the script execution environment to disconnect from this.device. |
| `GetPrimaryService(string bluetoothServiceUUID)` | `Task<BluetoothRemoteGATTService>` | The BluetoothRemoteGATTServer.getPrimaryService() method returns a promise to the primary BluetoothRemoteGATTService offered by the Bluetooth device for a specified bluetooth service UUID. A Bluetooth service universally unique identifier for a specified device, that is either a 128-bit UUID, a 16-bit or 32-bit UUID alias, or a string from the list of GATT assigned services keys. A Promise that resolves to a BluetoothRemoteGATTService object. |
| `GetPrimaryServices(string bluetoothServiceUUID)` | `Task<BluetoothRemoteGATTService[]>` | The BluetoothRemoteGATTServer.getPrimaryServices() method returns a promise to a list of primary BluetoothRemoteGATTService objects offered by the Bluetooth device for a specified BluetoothServiceUUID. A Bluetooth service universally unique identifier for a specified device. A Promise that resolves to a list of BluetoothRemoteGATTService objects. |

