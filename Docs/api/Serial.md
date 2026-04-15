# Serial

**Namespace:** `SpawnDev.BlazorJS.JSObjects.Serial`  
**Inheritance:** `JSObject` -> `EventTarget` -> `Serial`  
**MDN Reference:** [Serial - MDN](https://developer.mozilla.org/en-US/docs/Web/API/Serial)

> The `Serial` interface of the Web Serial API provides methods for connecting to serial ports. Access via `Navigator.Serial`. Requires a secure context and user gesture for `RequestPort()`.

## Constructors

| Signature | Description |
|---|---|
| `Serial(IJSInProcessObjectReference _ref)` | Deserialization constructor. Access via `navigator.Serial`. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RequestPort()` | `Task<SerialPort>` | Prompts the user to select a serial port. |
| `RequestPort(SerialPortOptions options)` | `Task<SerialPort>` | Prompts with filter options (vendor/product ID). |
| `GetPorts()` | `Task<SerialPort[]>` | Returns previously authorized ports. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnConnect` | `ActionEvent<Event>` | Fired when a serial port becomes available. |
| `OnDisconnect` | `ActionEvent<Event>` | Fired when a serial port is removed. |

## Example

```csharp
using var navigator = new Navigator();
var serial = navigator.Serial;
if (serial != null)
{
    using var port = await serial.RequestPort();
    await port.Open(new SerialOptions { BaudRate = 115200 });
    // Use port.Readable and port.Writable for data transfer
}
```
