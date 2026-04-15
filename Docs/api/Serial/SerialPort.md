# SerialPort

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Serial/SerialPort.cs`  
**MDN Reference:** [SerialPort on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SerialPort)

> The SerialPort interface of the Web Serial API provides access to a serial port on the host device. https://developer.mozilla.org/en-US/docs/Web/API/SerialPort

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Connected` | `bool` | get | Returns a boolean value that indicates whether the port is logically connected to the device. |
| `Readable` | `ReadableStream` | get | Returns a ReadableStream for receiving data from the device connected to the port. |
| `Writable` | `WritableStream` | get | Returns a WritableStream for sending data to the device connected to the port. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Forget()` | `Task` | The SerialPort.forget() method of the SerialPort interface returns a Promise that resolves when access to the serial port is revoked. A website can clean up permissions to access a serial port it is no longer interested in retaining by calling SerialPort.forget(). Calling this "forgets" the device, resetting any previously-set permissions so the calling site can no longer communicate with the port. For example, for an educational web application used on a shared computer with many devices, a large number of accumulated user-generated permissions creates a poor user experience. |
| `GetInfo()` | `SerialPortInfo` | The getInfo() method of the SerialPort interface returns an object containing identifying information for the device available via the port. |
| `Open(SerialOptions options)` | `Task` | The open() method of the SerialPort interface returns a Promise that resolves when the port is opened. By default the port is opened with 8 data bits, 1 stop bit and no parity checking. The baudRate parameter is required. |
| `SetSignals(SerialOutputSignals options)` | `Task` | The setSignals() method of the SerialPort interface sets control signals on the port and returns a Promise that resolves when they are set. |
| `SetSignals()` | `Task` | The setSignals() method of the SerialPort interface sets control signals on the port and returns a Promise that resolves when they are set. |
| `GetSignals()` | `Task<SerialInputSignals>` | The SerialPort.getSignals() method of the SerialPort interface returns a Promise that resolves with an object containing the current state of the port's control signals. |
| `Close()` | `Task` | The SerialPort.close() method of the SerialPort interface returns a Promise that resolves when the port closes. close() closes the serial port if previously-locked SerialPort.readable and SerialPort.writable members are unlocked, meaning the releaseLock() methods have been called for their respective reader and writer. However, when continuously reading data from a serial device using a loop, the associated readable stream will always be locked until the reader encounters an error. In this case, calling reader.cancel() will force reader.read() to resolve immediately with { value: undefined, done: true } allowing the loop to call reader.releaseLock(). |

## Events

| Event | Type | Description |
|---|---|---|
| `OnConnect` | `ActionEvent<Event>` | Fired when the port connects to the device. |
| `OnDisconnect` | `ActionEvent<Event>` | Fired when the port disconnects from the device. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<SerialPort>(...)` or constructor `new SerialPort(...)`

### Opening a port

```js
await port.open({ baudRate: 9600 /* pick your baud rate */ });
```

### Reading data from a port

```js
while (port.readable) {
  const reader = port.readable.getReader();
  try {
    while (true) {
      const { value, done } = await reader.read();
      if (done) {
        // |reader| has been canceled.
        break;
      }
      // Do something with |value|…
    }
  } catch (error) {
    // Handle |error|…
  } finally {
    reader.releaseLock();
  }
}
```

### Writing data to a port

```js
const encoder = new TextEncoder();
const writer = port.writable.getWriter();
await writer.write(encoder.encode("PING"));
writer.releaseLock();
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SerialPort)*

