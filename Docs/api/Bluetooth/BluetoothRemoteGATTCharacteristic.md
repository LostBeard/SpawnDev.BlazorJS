# BluetoothRemoteGATTCharacteristic

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Bluetooth/BluetoothRemoteGATTCharacteristic.cs`  
**MDN Reference:** [BluetoothRemoteGATTCharacteristic on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BluetoothRemoteGATTCharacteristic)

> The BluetoothRemoteGattCharacteristic interface of the Web Bluetooth API represents a GATT Characteristic, which is a basic data element that provides further information about a peripheral's service. https://developer.mozilla.org/en-US/docs/Web/API/BluetoothRemoteGATTCharacteristic

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Service` | `BluetoothRemoteGATTService` | get | Returns a reference to the BluetoothRemoteGATTService object that contains this characteristic. |
| `UUID` | `string` | get | Returns a string representing the UUID of this characteristic. |
| `Properties` | `BluetoothCharacteristicProperties` | get | Returns the properties of this characteristic. |
| `Value` | `DataView?` | get | The currently cached characteristic value. This value gets updated when the value of the characteristic is read or updated via a notification or indication. |
| `ValueBytes` | `byte[]?` | get | The currently cached characteristic value. This value gets updated when the value of the characteristic is read or updated via a notification or indication. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetDescriptor(string bluetoothDescriptorUUID)` | `Task<BluetoothRemoteGATTDescriptor>` | Returns a Promise that resolves to the first BluetoothRemoteGATTDescriptor for a given descriptor UUID. |
| `GetDescriptors()` | `Task<BluetoothRemoteGATTDescriptor[]>` | Returns a Promise that resolves to an Array of all BluetoothRemoteGATTDescriptor objects for a given descriptor UUID. |
| `ReadValue()` | `Task<DataView>` | The BluetoothRemoteGATTCharacteristic.readValue() method returns a Promise that resolves to a DataView holding a duplicate of the value property if it is available and supported. Otherwise it throws an error. |
| `ReadValueBytes()` | `Task<byte[]>` | The BluetoothRemoteGATTCharacteristic.readValue() method returns a Promise that resolves to a DataView holding a duplicate of the value property if it is available and supported. Otherwise it throws an error. |
| `WriteValueWithResponse(TypedArray value)` | `Task` | Sets the value property to the bytes contained in a given ArrayBuffer, writes the characteristic value with required response, and returns the resulting Promise. |
| `WriteValueWithResponse(DataView value)` | `Task` | Sets the value property to the bytes contained in a given ArrayBuffer, writes the characteristic value with required response, and returns the resulting Promise. |
| `WriteValueWithResponse(SharedArrayBuffer value)` | `Task` | Sets the value property to the bytes contained in a given ArrayBuffer, writes the characteristic value with required response, and returns the resulting Promise. |
| `WriteValueWithResponse(ArrayBuffer value)` | `Task` | Sets the value property to the bytes contained in a given ArrayBuffer, writes the characteristic value with required response, and returns the resulting Promise. |
| `WriteValueWithResponse(byte[] value)` | `Task` | Sets the value property to the bytes contained in a given ArrayBuffer, writes the characteristic value with required response, and returns the resulting Promise. |
| `WriteValueWithoutResponse(TypedArray value)` | `Task` | Sets the value property to the bytes contained in a given ArrayBuffer, writes the characteristic value without response, and returns the resulting Promise. |
| `WriteValueWithoutResponse(DataView value)` | `Task` | Sets the value property to the bytes contained in a given ArrayBuffer, writes the characteristic value without response, and returns the resulting Promise. |
| `WriteValueWithoutResponse(SharedArrayBuffer value)` | `Task` | Sets the value property to the bytes contained in a given ArrayBuffer, writes the characteristic value without response, and returns the resulting Promise. |
| `WriteValueWithoutResponse(ArrayBuffer value)` | `Task` | Sets the value property to the bytes contained in a given ArrayBuffer, writes the characteristic value without response, and returns the resulting Promise. |
| `WriteValueWithoutResponse(byte[] value)` | `Task` | Sets the value property to the bytes contained in a given ArrayBuffer, writes the characteristic value without response, and returns the resulting Promise. |
| `StartNotifications()` | `Task` | Returns a Promise that resolves when navigator.bluetooth is added to the active notification context. |
| `StopNotifications()` | `Task` | Returns a Promise that resolves when navigator.bluetooth is removed from the active notification context. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnCharacteristicValueChanged` | `ActionEvent<Event>` | Fired on a BluetoothRemoteGATTCharacteristic when its value changes. |

