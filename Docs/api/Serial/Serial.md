# Serial

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Serial/Serial.cs`  

> The Serial interface of the Web Serial API provides attributes and methods for finding and connecting to serial ports from a web page.

## Constructors

| Signature | Description |
|---|---|
| `Serial(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetPorts()` | `Task<Array<SerialPort>>` | Returns a Promise that resolves with an array of SerialPort objects representing serial ports connected to the host which the origin has permission to access. |
| `RequestPort(SerialPortOptions options)` | `Task<SerialPort>` | The Serial.requestPort() method of the Serial interface returns a Promise that resolves with an instance of SerialPort representing the device chosen by the user or rejects if no device was selected. |
| `RequestPort()` | `Task<SerialPort>` | The Serial.requestPort() method of the Serial interface returns a Promise that resolves with an instance of SerialPort representing the device chosen by the user or rejects if no device was selected. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnConnect` | `ActionEvent<Event>` | An event fired when a port has been connected to the device. |
| `OnDisconnect` | `ActionEvent<Event>` | An event fired when a port has been disconnected from the device. |

## Example

```csharp
// Access the Serial API from the navigator
using var navigator = JS.Get<Navigator>("navigator");
using var serial = navigator.Serial;

// Listen for serial device connect/disconnect (named methods for proper cleanup)
serial.OnConnect += Serial_OnConnect;
serial.OnDisconnect += Serial_OnDisconnect;

// Request a serial port (requires user gesture - shows browser picker)
using var port = await serial.RequestPort();

// Open the port with baud rate and optional settings
await port.Open(new SerialOptions
{
    BaudRate = 9600,
});

Console.WriteLine($"Port connected: {port.Connected}");

// Get the readable and writable streams
using var readable = port.Readable;
using var writable = port.Writable;

// Read data from the serial device
using var reader = readable.GetReader();
// var result = await reader.Read();

// Write data to the serial device
using var writer = writable.GetWriter();
// using var data = new Uint8Array(new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F });
// await writer.Write(data);

// Release locks before closing
// reader.ReleaseLock();
// writer.ReleaseLock();

// Close the port when done
await port.Close();

// List previously granted ports
using var ports = await serial.GetPorts();
Console.WriteLine($"Previously granted ports: {ports.Length}");

// Clean up event handlers before disposal
serial.OnConnect -= Serial_OnConnect;
serial.OnDisconnect -= Serial_OnDisconnect;

void Serial_OnConnect(Event e)
{
    Console.WriteLine("Serial device connected");
}

void Serial_OnDisconnect(Event e)
{
    Console.WriteLine("Serial device disconnected");
}
```

