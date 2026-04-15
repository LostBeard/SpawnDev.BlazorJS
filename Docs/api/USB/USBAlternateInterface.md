# USBAlternateInterface

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/USB/USBAlternateInterface.cs`  
**MDN Reference:** [USBAlternateInterface on MDN](https://developer.mozilla.org/en-US/docs/Web/API/USBAlternateInterface)

> The USBAlternateInterface interface of the WebUSB API provides information about a particular configuration of an interface provided by the USB device. An interface includes one or more alternate settings which can configure a set of endpoints based on the operating mode of the device. https://developer.mozilla.org/en-US/docs/Web/API/USBAlternateInterface

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AlternateSetting` | `int` | get | The alternate setting number of this interface. This is equal to the bAlternateSetting field of the interface descriptor defining this interface |
| `InterfaceClass` | `int` | get | The class of this interface. This is equal to the bInterfaceClass field of the interface descriptor defining this interface. Standardized values for this field are defined by the USB Implementers Forum. A value of 0xFF indicates a vendor-defined interface. |
| `InterfaceSubclass` | `int` | get | The subclass of this interface. This is equal to the bInterfaceSubClass field of the interface descriptor defining this interface. The meaning of this value depends on the interfaceClass field. |
| `InterfaceProtocol` | `int` | get | The protocol supported by this interface. This is equal to the bInterfaceProtocol field of the interface descriptor defining this interface. The meaning of this value depends on the interfaceClass and interfaceSubclass fields. |
| `InterfaceName` | `string?` | get | The name of the interface, if one is provided by the device. This is the value of the string descriptor with the index specified by the iInterface field of the interface descriptor defining this interface. |
| `Endpoints` | `Array<USBEndpoint>` | get | An array containing instances of the USBEndpoint interface describing each of the endpoints that are part of this interface. |

