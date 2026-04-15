# USBInterface

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/USB/USBInterface.cs`  
**MDN Reference:** [USBInterface on MDN](https://developer.mozilla.org/en-US/docs/Web/API/USBInterface)

> The USBInterface interface of the WebUSB API provides information about an interface provided by the USB device. An interface represents a feature of the device which implements a particular protocol and may contain endpoints for bidirectional communication. https://developer.mozilla.org/en-US/docs/Web/API/USBInterface

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `InterfaceNumber` | `int` | get | The interface number of this interface. This is equal to the bInterfaceNumber field of the interface descriptor defining this interface. |
| `Alternate` | `USBAlternateInterface` | get | The currently selected alternative configuration of this interface. By default, this is the USBAlternateInterface from alternates with alternateSetting equal to 0. It can be changed by calling USBDevice.selectAlternateInterface() with any other value found in alternates. |
| `Alternates` | `Array<USBAlternateInterface>` | get | An array containing instances of the USBAlternateInterface interface describing each of the alternative configurations possible for this interface. |
| `Claimed` | `bool` | get | Whether this interface has been claimed by the current page by calling USBDevice.claimInterface(). |

