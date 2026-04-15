# BluetoothRemoteGATTDescriptor

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Bluetooth/BluetoothRemoteGATTDescriptor.cs`  
**MDN Reference:** [BluetoothRemoteGATTDescriptor on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BluetoothRemoteGATTDescriptor)

> The BluetoothRemoteGATTDescriptor interface of the Web Bluetooth API provides a GATT Descriptor, which provides further information about a characteristic's value. https://developer.mozilla.org/en-US/docs/Web/API/BluetoothRemoteGATTDescriptor

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Characteristic` | `BluetoothRemoteGATTCharacteristic` | get | Returns the BluetoothRemoteGATTCharacteristic this descriptor belongs to. |
| `UUID` | `string` | get | Returns the UUID of the characteristic descriptor, for example "00002902-0000-1000-8000-00805f9b34fb" for the Client Characteristic Configuration descriptor. |
| `Value` | `DataView?` | get | Returns the currently cached descriptor value. This value gets updated when the value of the descriptor is read. |
| `ValueBytes` | `byte[]?` | get | Returns the currently cached descriptor value. This value gets updated when the value of the descriptor is read. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ReadValue()` | `Task<DataView>` | Returns a Promise that resolves to a DataView holding a duplicate of the value property if it is available and supported. Otherwise it throws an error. |
| `ReadValueBytes()` | `Task<byte[]>` | Returns a Promise that resolves to a DataView holding a duplicate of the value property if it is available and supported. Otherwise it throws an error. |
| `WriteValue(TypedArray value)` | `Task` | The BluetoothRemoteGATTDescriptor.writeValue() method sets the value property to the bytes contained in an ArrayBuffer and returns a Promise. |
| `WriteValue(DataView value)` | `Task` | The BluetoothRemoteGATTDescriptor.writeValue() method sets the value property to the bytes contained in an ArrayBuffer and returns a Promise. |
| `WriteValue(SharedArrayBuffer value)` | `Task` | The BluetoothRemoteGATTDescriptor.writeValue() method sets the value property to the bytes contained in an ArrayBuffer and returns a Promise. |
| `WriteValue(ArrayBuffer value)` | `Task` | The BluetoothRemoteGATTDescriptor.writeValue() method sets the value property to the bytes contained in an ArrayBuffer and returns a Promise. |
| `WriteValue(byte[] value)` | `Task` | The BluetoothRemoteGATTDescriptor.writeValue() method sets the value property to the bytes contained in an ArrayBuffer and returns a Promise. |

