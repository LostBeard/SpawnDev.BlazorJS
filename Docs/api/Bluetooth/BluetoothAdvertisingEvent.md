# BluetoothAdvertisingEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/Bluetooth/BluetoothAdvertisingEvent.cs`  

> The BluetoothDeviceOptions interface of the Web Bluetooth API represents the options that can be passed to the requestDevice() method.

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Device` | `BluetoothDevice` | get | The BluetoothDevice object that is advertising. |
| `RSSI` | `float` | get | The RSSI (Received Signal Strength Indicator) of the advertisement, in dBm. This is a measure of the power level that the device is receiving the advertisement at, and can be used to determine how far away the device is from the receiver. |
| `TxPower` | `float` | get | The TxPower (Transmit Power) of the advertisement, in dBm. This is a measure of the power level that the device is transmitting the advertisement at, and can be used to determine how far away the device is from the receiver. |
| `UUIDS` | `string[]` | get | uuids |
| `ManufacturerData` | `Map<ushort, DataView>?` | get | Returns a Map containing the manufacturer specific data. |
| `ServiceData` | `Map<string, DataView>?` | get | Returns a Map containing the service specific data. |

