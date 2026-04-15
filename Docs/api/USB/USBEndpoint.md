# USBEndpoint

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/USB/USBEndpoint.cs`  
**MDN Reference:** [USBEndpoint on MDN](https://developer.mozilla.org/en-US/docs/Web/API/USBEndpoint)

> The USBEndpoint interface of the WebUSB API provides information about an endpoint provided by the USB device. An endpoint represents a unidirectional data stream into or out of a device. https://developer.mozilla.org/en-US/docs/Web/API/USBEndpoint

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `EndpointNumber` | `int` | get | This endpoint's "endpoint number" which is a value from 1 to 15 extracted from the bEndpointAddress field of the endpoint descriptor defining this endpoint. This value is used to identify the endpoint when calling methods on USBDevice. |
| `Direction` | `string` | get | The direction in which this endpoint transfers data, one of: - "in" - Data is transferred from device to host. - "out" - Data is transferred from host to device. |
| `Type` | `string` | get | The type of this endpoint, one of: - "bulk" - Provides reliable data transfer for large payloads.Data sent through a bulk endpoint is guaranteed to be delivered or generate an error but may be preempted by other data traffic. - "interrupt" - Provides reliable data transfer for small payloads. Data sent through an interrupt endpoint is guaranteed to be delivered or generate an error and is also given dedicated bus time for transmission. - "isochronous" - Provides unreliable data transfer for payloads that must be delivered periodically. They are given dedicated bus time but if a deadline is missed the data is dropped. |
| `PacketSize` | `int` | get | The size of the packets that data sent through this endpoint will be divided into. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<USBEndpoint>(...)` or constructor `new USBEndpoint(...)`

```js
let inEndpoint = undefined;
let outEndpoint = undefined;

for (const { alternates } of device.configuration.interfaces) {
  // Only support devices with out multiple alternate interfaces.
  const alternate = alternates[0];

  // Identify the interface implementing the USB CDC class.
  const USB_CDC_CLASS = 10;
  if (alternate.interfaceClass !== USB_CDC_CLASS) {
    continue;
  }

  for (const endpoint of alternate.endpoints) {
    // Identify the bulk transfer endpoints.
    if (endpoint.type !== "bulk") {
      continue;
    }

    if (endpoint.direction === "in") {
      inEndpoint = endpoint.endpointNumber;
    } else if (endpoint.direction === "out") {
      outEndpoint = endpoint.endpointNumber;
    }
  }
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/USBEndpoint)*

