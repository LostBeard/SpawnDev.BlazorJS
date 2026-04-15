# WorkerNavigator

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WorkerNavigator.cs`  
**MDN Reference:** [WorkerNavigator on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WorkerNavigator)

> The WorkerNavigator interface represents a subset of the Navigator interface allowed to be accessed from a Worker https://developer.mozilla.org/en-US/docs/Web/API/WorkerNavigator

## Constructors

| Signature | Description |
|---|---|
| `WorkerNavigator()` | Returns the global navigator instance |
| `WorkerNavigator(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AppCodeName` | `string` | get | Always returns 'Mozilla', in any browser. This property is kept only for compatibility purposes. Deprecated |
| `AppName` | `string` | get | Returns the official name of the browser. Do not rely on this property to return the correct value. Deprecated |
| `AppVersion` | `string` | get | Returns the version of the browser as a string. Do not rely on this property to return the correct value. Deprecated |
| `Connection` | `NetworkInformation?` | get | Provides a NetworkInformation object containing information about the network connection of a device. |
| `Gpu` | `GPU?` | get | Returns the GPU object for the current worker context. The entry point for the WebGPU API. |
| `HardwareConcurrency` | `int` | get | Returns the number of logical processor cores available |
| `Language` | `string?` | get | Returns a string representing the preferred language of the user, usually the language of the browser UI. The null value is returned when this is unknown. |
| `Languages` | `string[]?` | get | Returns an array of strings representing the languages known to the user, by order of preference. |
| `Locks` | `LockManager?` | get | Returns a LockManager object which provides methods for requesting a new Lock object and querying for an existing Lock object. |
| `MediaCapabilities` | `MediaCapabilities?` | get | Returns a MediaCapabilities object that can expose information about the decoding and encoding capabilities for a given format and output capabilities. |
| `OnLine` | `bool` | get | Returns a boolean value indicating whether the browser is online. |
| `Permissions` | `Permissions?` | get | Returns a Permissions object that can be used to query and update permission status of APIs covered by the Permissions API. |
| `Platform` | `string?` | get | Returns a string representing the platform of the browser. Do not rely on this property to return the correct value. Deprecated |
| `Product` | `string?` | get | Always returns 'Gecko', on any browser. This property is kept only for compatibility purposes. Deprecated |
| `Serial` | `Serial?` | get | Returns a Serial object, which represents the entry point into the Web Serial API to enable the control of serial ports. |
| `Storage` | `StorageManager?` | get | Returns a StorageManager interface for managing persistence permissions and estimating available storage. |
| `Usb` | `USB?` | get | Returns a USB object for the current document, providing access to WebUSB API functionality. |
| `UserAgent` | `string` | get | Returns the user agent string for the current browser. |

