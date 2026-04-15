# USBConfiguration

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/USB/USBConfiguration.cs`  
**MDN Reference:** [USBConfiguration on MDN](https://developer.mozilla.org/en-US/docs/Web/API/USBConfiguration)

> The USBConfiguration interface of the WebUSB API provides information about a particular configuration of a USB device and the interfaces that it supports. https://developer.mozilla.org/en-US/docs/Web/API/USBConfiguration

## Constructors

| Signature | Description |
|---|---|
| `USBConfiguration(USBDevice device, byte configurationValue)` | The USBConfiguration() constructor creates a new USBConfiguration object which contains information about the configuration on the provided USBDevice with the given configuration value. Specifies the USBDevice you want to configure. Specifies the configuration descriptor you want to read. This is an unsigned integer in the range 0 to 255. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ConfigurationValue` | `byte` | get | Returns the value of the configuration. |
| `ConfigurationName` | `string` | get | Returns the name of the configuration. |
| `Interfaces` | `Array<USBInterface>` | get | Returns an array of USBInterface objects representing the interfaces provided by the configuration. |

