# BluetoothDeviceManufacturerFilter

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/Bluetooth/BluetoothDeviceManufacturerFilter.cs`  
**MDN Reference:** [BluetoothDeviceManufacturerFilter on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Bluetooth/requestDevice#manufacturerdata)

> https://developer.mozilla.org/en-US/docs/Web/API/Bluetooth/requestDevice#manufacturerdata

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BluetoothDeviceManufacturerFilter` | `class` | get | https://developer.mozilla.org/en-US/docs/Web/API/Bluetooth/requestDevice#manufacturerdata |
| `DataPrefix` | `byte[]?` | get |  |
| `Mask` | `byte[]?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<BluetoothDeviceManufacturerFilter>(...)` or constructor `new BluetoothDeviceManufacturerFilter(...)`

```js
// Discovery options match any devices advertising:
// - The standard heart rate service.
// - Both 16-bit service IDs 0x1802 and 0x1803.
// - A proprietary 128-bit UUID service c48e6067-5295-48d3-8d5c-0395f61792b1.
// - Devices with name "ExampleName".
// - Devices with name starting with "Prefix".
//
// And enables access to the battery service if devices
// include it, even if devices do not advertise that service.
let options = {
  filters: [
    { services: ["heart_rate"] },
    { services: [0x1802, 0x1803] },
    { services: ["c48e6067-5295-48d3-8d5c-0395f61792b1"] },
    { name: "ExampleName" },
    { namePrefix: "Prefix" },
  ],
  optionalServices: ["battery_service"],
};

navigator.bluetooth
  .requestDevice(options)
  .then((device) => {
    console.log(`Name: ${device.name}`);
    // Do something with the device.
  })
  .catch((error) => console.error(`Something went wrong. ${error}`));
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Bluetooth/requestDevice)*

