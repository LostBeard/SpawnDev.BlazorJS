# BluetoothCharacteristicProperties

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Bluetooth/BluetoothCharacteristicProperties.cs`  
**MDN Reference:** [BluetoothCharacteristicProperties on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BluetoothCharacteristicProperties)

> The BluetoothCharacteristicProperties interface of the Web Bluetooth API provides the operations that are valid on the given BluetoothRemoteGATTCharacteristic. This interface is returned by calling BluetoothRemoteGATTCharacteristic.properties. https://developer.mozilla.org/en-US/docs/Web/API/BluetoothCharacteristicProperties

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AuthenticatedSignedWrites` | `bool` | get | Returns a boolean that is true if signed writing to the characteristic value is permitted. |
| `Broadcast` | `bool` | get | Returns a boolean that is true if the broadcast of the characteristic value is permitted using the Server Characteristic Configuration Descriptor. |
| `Indicate` | `bool` | get | Returns a boolean that is true if indications of the characteristic value with acknowledgement is permitted. |
| `Notify` | `bool` | get | Returns a boolean that is true if notifications of the characteristic value without acknowledgement is permitted. |
| `Read` | `bool` | get | Returns a boolean that is true if the reading of the characteristic value is permitted. |
| `ReliableWrite` | `bool` | get | Returns a boolean that is true if reliable writes to the characteristic is permitted. |
| `WritableAuxiliaries` | `bool` | get | Returns a boolean that is true if reliable writes to the characteristic descriptor is permitted. |
| `Write` | `bool` | get | Returns a boolean that is true if the writing to the characteristic with response is permitted. |
| `WriteWithoutResponse` | `bool` | get | Returns a boolean that is true if the writing to the characteristic without response is permitted. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<BluetoothCharacteristicProperties>(...)` or constructor `new BluetoothCharacteristicProperties(...)`

```js
let device = await navigator.bluetooth.requestDevice({
  filters: [{ services: ["heart_rate"] }],
});
let gatt = await device.gatt.connect();
let service = await gatt.getPrimaryService("heart_rate");
let characteristic = await service.getCharacteristic("heart_rate_measurement");
if (characteristic.properties.notify) {
  characteristic.addEventListener(
    "characteristicvaluechanged",
    async (event) => {
      console.log(`Received heart rate measurement: ${event.target.value}`);
    },
  );
  await characteristic.startNotifications();
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BluetoothCharacteristicProperties)*

