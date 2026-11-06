# SerialPort

**Namespace:** `SpawnDev.BlazorJS.JSObjects.Serial`  
**Inheritance:** `JSObject` -> `EventTarget` -> `SerialPort`  
**MDN Reference:** [SerialPort - MDN](https://developer.mozilla.org/en-US/docs/Web/API/SerialPort)

> Represents a serial port connection. Provides readable and writable streams for serial communication.

## Constructors

| Signature | Description |
|---|---|
| `SerialPort(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|---|---|---|
| `Readable` | `ReadableStream` | A `ReadableStream` for receiving data from the serial port. |
| `Writable` | `WritableStream` | A `WritableStream` for sending data to the serial port. |
| `Connected` | `bool` | Returns a boolean value that indicates whether the port is logically connected to the device. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Open(SerialOptions options)` | `Task` | Opens the port with the specified baud rate and other settings. |
| `Close()` | `Task` | Closes the serial port. |
| `GetInfo()` | `SerialPortInfo` | Returns identification info (vendor ID, product ID). |
| `SetSignals(SerialOutputSignals signals)` | `Task` | Sets output control signals (DTR, RTS, break). |
| `GetSignals()` | `Task<SerialInputSignals>` | Gets input control signals (CTS, DSR, DCD, RI). |
| `Forget()` | `Task` | Revokes the app's permission to access the port. |
| `SetSignals()` | `Task` | The setSignals() method of the SerialPort interface sets control signals on the port and returns a Promise that resolves when they are set. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnConnect` | `ActionEvent<Event>` | Fired when the port connects to the device. |
| `OnDisconnect` | `ActionEvent<Event>` | Fired when the port disconnects from the device. |

## Example

```csharp
using var port = await serial.RequestPort();
await port.Open(new SerialOptions { BaudRate = 9600 });

// Read data
using var readable = port.Readable;
using var reader = readable.GetReader();
var result = await reader.Read();

// Write data
using var writable = port.Writable;
using var writer = writable.GetWriter();
byte[] data = System.Text.Encoding.UTF8.GetBytes("AT\r\n");
// writer.Write(data);

await port.Close();
```
