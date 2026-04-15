# USBDeviceFilter

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/USB/USBDeviceFilter.cs`  
**MDN Reference:** [USBDeviceFilter on MDN](https://developer.mozilla.org/en-US/docs/Web/API/USB/requestDevice#filters)

> USB.requestDevice() filter dictionary to filter USB devices. 5. Device Enumeration https://wicg.github.io/webusb/#enumeration https://developer.mozilla.org/en-US/docs/Web/API/USB/requestDevice#filters

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `USBDeviceFilter` | `class` | get | USB.requestDevice() filter dictionary to filter USB devices. 5. Device Enumeration https://wicg.github.io/webusb/#enumeration https://developer.mozilla.org/en-US/docs/Web/API/USB/requestDevice#filters |
| `ProductId` | `int?` | get |  |
| `ClassCode` | `int?` | get |  |
| `SubclassCode` | `int?` | get |  |
| `ProtocolCode` | `int?` | get |  |
| `SerialNumber` | `string?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<USBDeviceFilter>(...)` or constructor `new USBDeviceFilter(...)`

```js
const filters = [
  { vendorId: 0x1209, productId: 0xa800 },
  { vendorId: 0x1209, productId: 0xa850 },
];
navigator.usb
  .requestDevice({ filters })
  .then((usbDevice) => {
    console.log(`Product name: ${usbDevice.productName}`);
  })
  .catch((e) => {
    console.error(`There is no device. ${e}`);
  });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/USB/requestDevice)*

