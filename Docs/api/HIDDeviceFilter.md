# HIDDeviceFilter

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/HIDDeviceFilter.cs`  
**MDN Reference:** [HIDDeviceFilter on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HID/requestDevice#parameters)

> HID Device filter options https://developer.mozilla.org/en-US/docs/Web/API/HID/requestDevice#parameters

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `HIDDeviceFilter` | `class` | get | HID Device filter options https://developer.mozilla.org/en-US/docs/Web/API/HID/requestDevice#parameters |
| `ProductId` | `int?` | get |  |
| `UsagePage` | `int?` | get |  |
| `Usage` | `int?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<HIDDeviceFilter>(...)` or constructor `new HIDDeviceFilter(...)`

### Matching a device with all four filter rules

```js
let requestButton = document.getElementById("request-hid-device");
requestButton.addEventListener("click", async () => {
  let device;
  try {
    const devices = await navigator.hid.requestDevice({
      filters: [
        {
          vendorId: 0xabcd,
          productId: 0x1234,
          usagePage: 0x0c,
          usage: 0x01,
        },
      ],
    });
    device = devices[0];
  } catch (error) {
    console.log("An error occurred.");
  }

  if (!device) {
    console.log("No device was selected.");
  } else {
    console.log(`HID: ${device.productName}`);
  }
});
```

### An example with two filters

```js
// Filter on devices with the Nintendo Switch Joy-Con USB Vendor/Product IDs.
const filters = [
  {
    vendorId: 0x057e, // Nintendo Co., Ltd
    productId: 0x2006, // Joy-Con Left
  },
  {
    vendorId: 0x057e, // Nintendo Co., Ltd
    productId: 0x2007, // Joy-Con Right
  },
];

// Prompt user to select a Joy-Con device.
const [device] = await navigator.hid.requestDevice({ filters });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HID/requestDevice)*

