# USBDevice

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/USB/USBDevice.cs`  
**MDN Reference:** [USBDevice on MDN](https://developer.mozilla.org/en-US/docs/Web/API/USBDevice)

> The USBDevice interface of the WebUSB API provides access to metadata about a paired USB device and methods for control https://developer.mozilla.org/en-US/docs/Web/API/USBDevice

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Configuration` | `USBConfiguration?` | get | Returns the USB device's configuration. |
| `Configurations` | `Array<USBConfiguration>` | get | Returns the USB device's configurations. |
| `DeviceClass` | `int` | get | One of three properties that identify USB devices for the purpose of loading a USB driver that will work with that device. The other two properties are USBDevice.deviceSubclass and USBDevice.deviceProtocol. |
| `DeviceSubClass` | `int` | get | One of three properties that identify USB devices for the purpose of loading a USB driver that will work with that device. The other two properties are USBDevice.deviceClass and USBDevice.deviceProtocol. |
| `DeviceProtocol` | `int` | get | One of three properties that identify USB devices for the purpose of loading a USB driver that will work with that device. The other two properties are USBDevice.deviceClass and USBDevice.deviceSubclass. |
| `DeviceVersionMajor` | `int` | get | The major version number of the device in a semantic versioning scheme. |
| `DeviceVersionMinor` | `int` | get | The minor version number of the device in a semantic versioning scheme. |
| `DeviceVersionSubminor` | `int` | get | The patch version number of the device in a semantic versioning scheme. |
| `ManufacturerName` | `string` | get | Returns the USB device's manufacturer name. |
| `Opened` | `bool` | get | Indicates whether a session has been started with a paired USB device. |
| `ProductId` | `int` | get | Returns the USB device's product ID. |
| `ProductName` | `string` | get | Returns the USB device's product name. |
| `SerialNumber` | `string` | get | Returns the USB device's serial number. |
| `USBVersionMajor` | `int` | get | One of three properties that declare the USB protocol version supported by the device. The other two properties are USBDevice.usbVersionMinor and USBDevice.usbVersionSubminor. |
| `USBVersionMinor` | `int` | get | One of three properties that declare the USB protocol version supported by the device. The other two properties are USBDevice.usbVersionMajor and USBDevice.usbVersionSubminor. |
| `USBVersionSubminor` | `int` | get | One of three properties that declare the USB protocol version supported by the device. The other two properties are USBDevice.usbVersionMajor and USBDevice.usbVersionMinor. |
| `VendorId` | `int` | get | Returns the USB device's vendor ID. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ClaimInterface(int interfaceNumber)` | `Task` | Claims an interface on the USB device. The interface number to claim. |
| `ClearHalt(string direction, int endpointNumber)` | `Task` | Clears a halt condition on an endpoint. Indicates whether the devices input or output should be cleared. Valid values are 'in' or 'out'. The endpoint number to clear the halt condition on. |
| `ControlTransferIn(USBControlTransferParameters setup, int length)` | `Task<USBInTransferResult>` | Controls a transfer to the USB device. The setup packet for the control transfer. The data to transfer. A promise that resolves with the result of the transfer. |
| `ControlTransferOut(USBControlTransferParameters setup, TypedArray data)` | `Task<USBOutTransferResult>` | Controls a transfer to the USB device. The setup packet for the control transfer. The data to transfer. A promise that resolves with the result of the transfer. |
| `ControlTransferOut(USBControlTransferParameters setup)` | `Task<USBOutTransferResult>` | Controls a transfer to the USB device. The setup packet for the control transfer. A promise that resolves with the result of the transfer. |
| `ControlTransferOut(USBControlTransferParameters setup, byte[] data)` | `Task<USBOutTransferResult>` | Controls a transfer to the USB device. The setup packet for the control transfer. The data to transfer. A promise that resolves with the result of the transfer. |
| `Close()` | `Task` | Closes the connection to the USB device. |
| `Forget()` | `Task` | Returns a Promise that resolves after all open interfaces are released, the device session has ended, and the permission is reset. |
| `IsochronousTransferIn(int endpointNumber, IEnumerable<IEnumerable<int>> packetLengths)` | `Task<USBIsochronousInTransferResult>` | The isochronousTransferIn() method of the USBDevice interface returns a Promise that resolves with a USBIsochronousInTransferResult when time sensitive information has been transmitted to (received by) the USB device. The number of a device-specific endpoint (buffer). An array of lengths for the packets being received. A Promise that resolves with a USBIsochronousInTransferResult. |
| `IsochronousTransferOut(int endpointNumber, TypedArray data, IEnumerable<IEnumerable<int>> packetLengths)` | `Task<USBIsochronousOutTransferResult>` | The isochronousTransferOut() method of the USBDevice interface returns a Promise that resolves with a USBIsochronousOutTransferResult when time sensitive information has been transmitted from the USB device. The number of a device-specific endpoint (buffer). A TypedArray containing the data to send to the device. An array of lengths for the packets being transferred. A Promise that resolves with a USBIsochronousOutTransferResult. |
| `IsochronousTransferOut(int endpointNumber, byte[] data, IEnumerable<IEnumerable<int>> packetLengths)` | `Task<USBIsochronousOutTransferResult>` | The isochronousTransferOut() method of the USBDevice interface returns a Promise that resolves with a USBIsochronousOutTransferResult when time sensitive information has been transmitted from the USB device. The number of a device-specific endpoint (buffer). A TypedArray containing the data to send to the device. An array of lengths for the packets being transferred. A Promise that resolves with a USBIsochronousOutTransferResult. |
| `Open()` | `Task` | Opens a connection to the USB device. |
| `ReleaseInterface(int interfaceNumber)` | `Task` | Releases an interface on the USB device. The interface number to release. |
| `Reset()` | `Task` | Returns a Promise that resolves when the device is reset and all app operations canceled and their promises rejected. |
| `SelectAlternateInterface(int interfaceNumber, int alternateSetting)` | `Task` | Selects an alternate setting for an interface on the USB device. The interface number to select the alternate setting for. The alternate setting to select. |
| `SelectConfiguration(int configurationValue)` | `Task` | Selects a configuration for the USB device. The configuration value to select. |
| `TransferIn(int endpointNumber, int length)` | `Task<USBInTransferResult>` | Performs a transfer from the USB device. The endpoint number to transfer from. The length of the data to transfer. A promise that resolves with the result of the transfer. |
| `TransferOut(int endpointNumber, TypedArray data)` | `Task<USBOutTransferResult>` | Performs a transfer to the USB device. The endpoint number to transfer to. The data to transfer. A promise that resolves with the result of the transfer. |
| `TransferOut(int endpointNumber, byte[] data)` | `Task<USBOutTransferResult>` | Performs a transfer to the USB device. The endpoint number to transfer to. The data to transfer. A promise that resolves with the result of the transfer. |

