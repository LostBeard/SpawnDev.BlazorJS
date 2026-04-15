# SerialPortInfo

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Serial/SerialPortInfo.cs`  
**MDN Reference:** [SerialPortInfo on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SerialPort/getInfo#return_value)

> Serial port information https://wicg.github.io/serial/#serialportinfo-dictionary https://developer.mozilla.org/en-US/docs/Web/API/SerialPort/getInfo#return_value

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `UsbVendorId` | `ushort?` | get | If the port is part of a USB device, this property is an unsigned short integer that identifies the device's vendor. If not, it is undefined. |
| `UsbProductId` | `ushort?` | get | If the port is part of a USB device, this property is an unsigned short integer that identifies the USB device. If not, it is undefined. |
| `BluetoothServiceClassId` | `string?` | get | If the port is a Bluetooth RFCOMM service, this property is an unsigned long integer or string representing the device's Bluetooth service class ID. If not, it is undefined. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<SerialPortInfo>(...)` or constructor `new SerialPortInfo(...)`

```js
const connectBtn = document.getElementById("connect");

// Filter for devices with the Arduino Uno USB Vendor/Product IDs
const filters = [
  { usbVendorId: 0x2341, usbProductId: 0x0043 },
  { usbVendorId: 0x2341, usbProductId: 0x0001 }
];

connectBtn.addEventListener("click", () => {
  try {
    // Prompt the user to select an Arduino Uno device
    const port = await navigator.serial.requestPort({ filters });

    // Return the device's identifying info
    const { usbProductId, usbVendorId } = port.getInfo();
  } catch (e) {
    // The user didn't select a device
  }
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SerialPort/getInfo)*

