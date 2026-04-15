# HIDCollectionInfo

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/HIDCollectionInfo.cs`  
**MDN Reference:** [HIDCollectionInfo on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HIDDevice/collections)

> The HIDCollectionInfo interface of the WebHID API represents a collection of HID reports and their associated metadata. https://developer.mozilla.org/en-US/docs/Web/API/HIDDevice/collections

## Constructors

| Signature | Description |
|---|---|
| `HIDCollectionInfo(IJSInProcessObjectReference _ref)` | Creates a new instance of `HIDCollectionInfo`. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `UsagePage` | `int` | get | An integer representing the usage page component of the HID usage associated with this collection. The usage for a top level collection is used to identify the device type. |
| `Usage` | `int` | get | An integer representing the usage ID component of the HID usage associated with this collection. |
| `Type` | `byte` | get | An 8-bit value representing the collection type, which describes a different relationship between the grouped items. It can be one of the following values: 0x00 Physical (group of axes) 0x01 Application (mouse, keyboard) 0x02 Logical (interrelated data) 0x03 Report 0x04 Named array 0x05 Usage switch 0x06 Usage modified 0x07 to 0x7F Reserved for future use 0x80 to 0xFF Vendor-defined |
| `Children` | `HIDCollectionInfo[]` | get | An array of sub-collections which takes the same format as a top-level collection. |
| `InputReports` | `HIDReportInfo[]` | get | An array of inputReport items which represent individual input reports described in this collection. |
| `OutputReports` | `HIDReportInfo[]` | get | An array of outputReport items which represent individual output reports described in this collection. |
| `FeatureReports` | `HIDReportInfo[]` | get | An array of featureReport items which represent individual feature reports described in this collection. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<HIDCollectionInfo>(...)` or constructor `new HIDCollectionInfo(...)`

```js
for (const collection of device.collections) {
  // A HID collection includes usage, usage page, reports, and subcollections.
  console.log(`Usage: ${collection.usage}`);
  console.log(`Usage page: ${collection.usagePage}`);

  for (const inputReport of collection.inputReports) {
    console.log(`Input report: ${inputReport.reportId}`);
    // Loop through inputReport.items
  }

  for (const outputReport of collection.outputReports) {
    console.log(`Output report: ${outputReport.reportId}`);
    // Loop through outputReport.items
  }

  for (const featureReport of collection.featureReports) {
    console.log(`Feature report: ${featureReport.reportId}`);
    // Loop through featureReport.items
  }

  // Loop through subcollections with collection.children
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HIDDevice/collections)*

