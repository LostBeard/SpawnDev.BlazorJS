# HIDDevice

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/HIDDevice.cs`  
**MDN Reference:** [HIDDevice on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HIDDevice)

> The HIDDevice interface of the WebHID API represents a HID Device. It provides properties for accessing information about the device, methods for opening and closing the connection, and the sending and receiving of reports. https://developer.mozilla.org/en-US/docs/Web/API/HIDDevice

## Constructors

| Signature | Description |
|---|---|
| `HIDDevice(IJSInProcessObjectReference _ref)` | Creates a new instance of `HIDDevice`. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Opened` | `bool` | get | Returns a boolean, true if the device has an open connection. |
| `VendorId` | `int` | get | Returns the vendorId of the HID device. |
| `ProductId` | `int` | get | Returns the productId of the HID device. |
| `ProductName` | `string` | get | Returns a string containing the product name of the HID device. |
| `Collections` | `Array<HIDCollectionInfo>` | get | Returns an array of report formats for the HID device. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Open()` | `Task` | Opens a connection to this HID device, and returns a Promise which resolves once the connection has been successful. |
| `Close()` | `Task` | Closes the connection to this HID device, and returns a Promise which resolves once the connection has been closed. |
| `Forget()` | `Task` | Closes the connection to this HID device and resets access permission, and returns a Promise which resolves once the permission was reset. |
| `SendReport(byte reportId, byte[] data)` | `Task` | Sends an output report to this HID Device, and returns a Promise which resolves once the report has been sent. An 8-bit report ID. If the HID device does not use report IDs, send 0. Bytes as an ArrayBuffer, a TypedArray, or a DataView. |
| `SendFeatureReport(byte reportId, byte[] data)` | `Task` | Sends a feature report to this HID device, and returns a Promise which resolves once the report has been sent. An 8-bit report ID. If the HID device does not use report IDs, send 0. Bytes as an ArrayBuffer, a TypedArray, or a DataView. |
| `ReceiveFeatureReport(byte reportId)` | `Task<DataView>` | Receives a feature report from this HID device in the form of a Promise which resolves with a DataView. This allows typed access to the contents of this message. An 8-bit report ID. If the HID device does not use report IDs, send 0. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnInputReport` | `ActionEvent<HIDInputReportEvent>` | Fires when a report is sent from the device. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<HIDDevice>(...)` or constructor `new HIDDevice(...)`

```js
device.addEventListener("inputreport", (event) => {
  const { data, device, reportId } = event;

  // Handle only the Joy-Con Right device and a specific report ID.
  if (device.productId !== 0x2007 && reportId !== 0x3f) return;

  const value = data.getUint8(0);
  if (value === 0) return;

  const someButtons = { 1: "A", 2: "X", 4: "B", 8: "Y" };
  console.log(`User pressed button ${someButtons[value]}.`);
});
```

```js
const reportId = 1;
for (let i = 0; i < 10; i++) {
  // Turn off
  await device.sendFeatureReport(reportId, Uint32Array.from([0, 0]));
  await new Promise((resolve) => setTimeout(resolve, 100));
  // Turn on
  await device.sendFeatureReport(reportId, Uint32Array.from([512, 0]));
  await new Promise((resolve) => setTimeout(resolve, 100));
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HIDDevice)*

