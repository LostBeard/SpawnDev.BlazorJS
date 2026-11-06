# USBDevice

**Namespace:** `SpawnDev.BlazorJS.JSObjects.USB`  
**Inheritance:** `JSObject` -> `USBDevice`  
**MDN Reference:** [USBDevice - MDN](https://developer.mozilla.org/en-US/docs/Web/API/USBDevice)

> Represents a USB device. Provides access to device metadata and methods for communication including control transfers, bulk transfers, and isochronous transfers.

## Constructors

| Signature | Description |
|---|---|
| `USBDevice(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|---|---|---|
| `VendorId` | `int` | The USB vendor ID. |
| `ProductId` | `int` | The USB product ID. |
| `ProductName` | `string?` | Human-readable product name. |
| `ManufacturerName` | `string?` | Human-readable manufacturer name. |
| `SerialNumber` | `string?` | Serial number string. |
| `Configuration` | `USBConfiguration?` | The currently selected configuration. |
| `Configurations` | `USBConfiguration[]` | All available configurations. |
| `Opened` | `bool` | Whether the device is currently opened. |
| `DeviceClass` | `int` | One of three properties that identify USB devices for the purpose of loading a USB driver that will work with that device. The other two properties are USBDevice.deviceSubclass and USBDevice.deviceProtocol. |
| `DeviceSubClass` | `int` | One of three properties that identify USB devices for the purpose of loading a USB driver that will work with that device. The other two properties are USBDevice.deviceClass and USBDevice.deviceProtocol. |
| `DeviceProtocol` | `int` | One of three properties that identify USB devices for the purpose of loading a USB driver that will work with that device. The other two properties are USBDevice.deviceClass and USBDevice.deviceSubclass. |
| `DeviceVersionMajor` | `int` | The major version number of the device in a semantic versioning scheme. |
| `DeviceVersionMinor` | `int` | The minor version number of the device in a semantic versioning scheme. |
| `DeviceVersionSubminor` | `int` | The patch version number of the device in a semantic versioning scheme. |
| `USBVersionMajor` | `int` | One of three properties that declare the USB protocol version supported by the device. The other two properties are USBDevice.usbVersionMinor and USBDevice.usbVersionSubminor. |
| `USBVersionMinor` | `int` | One of three properties that declare the USB protocol version supported by the device. The other two properties are USBDevice.usbVersionMajor and USBDevice.usbVersionSubminor. |
| `USBVersionSubminor` | `int` | One of three properties that declare the USB protocol version supported by the device. The other two properties are USBDevice.usbVersionMajor and USBDevice.usbVersionMinor. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Open()` | `Task` | Opens the device for communication. |
| `Close()` | `Task` | Closes the device. |
| `SelectConfiguration(int configurationValue)` | `Task` | Selects a USB configuration. |
| `ClaimInterface(int interfaceNumber)` | `Task` | Claims exclusive access to an interface. |
| `ReleaseInterface(int interfaceNumber)` | `Task` | Releases a claimed interface. |
| `SelectAlternateInterface(int interfaceNumber, int alternateSetting)` | `Task` | Selects an alternate interface setting. |
| `ControlTransferIn(USBControlTransferParameters setup, int length)` | `Task<USBInTransferResult>` | Performs a control transfer (device to host). |
| `ControlTransferOut(USBControlTransferParameters setup)` | `Task<USBOutTransferResult>` | Performs a control transfer (host to device). |
| `ControlTransferOut(USBControlTransferParameters setup, BufferSource data)` | `Task<USBOutTransferResult>` | Control transfer with data. |
| `TransferIn(int endpointNumber, int length)` | `Task<USBInTransferResult>` | Bulk/interrupt transfer in. |
| `TransferOut(int endpointNumber, BufferSource data)` | `Task<USBOutTransferResult>` | Bulk/interrupt transfer out. |
| `IsochronousTransferIn(int endpointNumber, int[] packetLengths)` | `Task<USBIsochronousInTransferResult>` | Isochronous transfer in. |
| `IsochronousTransferOut(int endpointNumber, BufferSource data, int[] packetLengths)` | `Task<USBIsochronousOutTransferResult>` | Isochronous transfer out. |
| `Reset()` | `Task` | Resets the device. |
| `ClearHalt(string direction, int endpointNumber)` | `Task` | Clears a halt condition on an endpoint. |
| `ControlTransferOut(USBControlTransferParameters setup, TypedArray data)` | `Task<USBOutTransferResult>` | Controls a transfer to the USB device. |
| `ControlTransferOut(USBControlTransferParameters setup, byte[] data)` | `Task<USBOutTransferResult>` | Controls a transfer to the USB device. |
| `Forget()` | `Task` | Returns a Promise that resolves after all open interfaces are released, the device session has ended, and the permission is reset. |
| `IsochronousTransferIn(int endpointNumber, IEnumerable<IEnumerable<int>> packetLengths)` | `Task<USBIsochronousInTransferResult>` | The isochronousTransferIn() method of the USBDevice interface returns a Promise that resolves with a USBIsochronousInTransferResult when time sensitive information has been transmitted to (received by) the USB device. |
| `IsochronousTransferOut(int endpointNumber, TypedArray data, IEnumerable<IEnumerable<int>> packetLengths)` | `Task<USBIsochronousOutTransferResult>` | The isochronousTransferOut() method of the USBDevice interface returns a Promise that resolves with a USBIsochronousOutTransferResult when time sensitive information has been transmitted from the USB device. |
| `IsochronousTransferOut(int endpointNumber, byte[] data, IEnumerable<IEnumerable<int>> packetLengths)` | `Task<USBIsochronousOutTransferResult>` | The isochronousTransferOut() method of the USBDevice interface returns a Promise that resolves with a USBIsochronousOutTransferResult when time sensitive information has been transmitted from the USB device. |
| `TransferOut(int endpointNumber, TypedArray data)` | `Task<USBOutTransferResult>` | Performs a transfer to the USB device. |
| `TransferOut(int endpointNumber, byte[] data)` | `Task<USBOutTransferResult>` | Performs a transfer to the USB device. |

## Example

```csharp
using var device = await usb.RequestDevice(options);
await device.Open();
await device.SelectConfiguration(1);
await device.ClaimInterface(0);

// Control transfer
var result = await device.ControlTransferIn(
    new USBControlTransferParameters { /* ... */ }, 64);

await device.ReleaseInterface(0);
await device.Close();
```
