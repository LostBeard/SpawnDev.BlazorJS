# WebSocket

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WebSocket.cs`  
**MDN Reference:** [WebSocket on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebSocket)

> The WebSocket object provides the API for creating and managing a WebSocket connection to a server, as well as for sending and receiving data on the connection. https://developer.mozilla.org/en-US/docs/Web/API/WebSocket

## Constructors

| Signature | Description |
|---|---|
| `WebSocket(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `WebSocket(string url)` | The WebSocket() constructor returns a new WebSocket object. |
| `WebSocket(string url, string[] protocols)` | The WebSocket() constructor returns a new WebSocket object. |
| `WebSocket(string url, string protocols)` | The WebSocket() constructor returns a new WebSocket object. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BinaryType` | `string` | get/set | The binary data type used by the connection. "blob" - Use Blob objects for binary data. This is the default value. "arraybuffer" - Use ArrayBuffer objects for binary data. |
| `BufferedAmount` | `int` | get | The number of bytes of queued data. |
| `ReadyState` | `int` | get | The current state of the connection. 0 - CONNECTING - Socket has been created. The connection is not yet open. 1 - OPEN - The connection is open and ready to communicate. 2 - CLOSING - The connection is in the process of closing. 3 - CLOSED - The connection is closed or couldn't be opened. |
| `Protocol` | `string` | get | The sub-protocol selected by the server. The sub-protocol selected by the server. |
| `Url` | `string` | get | The absolute URL of the WebSocket as resolved by the constructor. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Close(int code, string reason)` | `void` | Closes the WebSocket connection or connection attempt, if any. If the connection is already CLOSED, this method does nothing. An integer WebSocket connection close code value indicating a reason for closure: - If unspecified, a close code for the connection is automatically set: to 1000 for a normal closure, or otherwise to another standard value in the range 1001-1015 that indicates the actual reason the connection was closed. - If specified, the value of this code parameter overrides the automatic setting of the close code for the connection, and instead sets a custom code. The value must be an integer: either 1000, or else a custom code of your choosing in the range 3000-4999. If you specify a code value, you should also specify a reason value. A string providing a custom WebSocket connection close reason (a concise human-readable prose explanation for the closure). The value must be no longer than 123 bytes (encoded in UTF-8). |
| `Close(int code)` | `void` | Closes the WebSocket connection or connection attempt, if any. If the connection is already CLOSED, this method does nothing. An integer WebSocket connection close code value indicating a reason for closure: - If unspecified, a close code for the connection is automatically set: to 1000 for a normal closure, or otherwise to another standard value in the range 1001-1015 that indicates the actual reason the connection was closed. - If specified, the value of this code parameter overrides the automatic setting of the close code for the connection, and instead sets a custom code. The value must be an integer: either 1000, or else a custom code of your choosing in the range 3000-4999. If you specify a code value, you should also specify a reason value. |
| `Close()` | `void` | Closes the WebSocket connection or connection attempt, if any. If the connection is already CLOSED, this method does nothing. |
| `Send(string data)` | `void` | Enqueues data to be transmitted. |
| `Send(ArrayBuffer data)` | `void` | Enqueues data to be transmitted. |
| `Send(TypedArray data)` | `void` | Enqueues data to be transmitted. |
| `Send(byte[] data)` | `void` | Enqueues data to be transmitted. |
| `Send(DataView data)` | `void` | Enqueues data to be transmitted. |
| `Send(Blob data)` | `void` | Enqueues data to be transmitted. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnClose` | `ActionEvent<CloseEvent>` | Fired when a connection with a WebSocket is closed. Also available via the onclose property |
| `OnError` | `ActionEvent<Event>` | Fired when a connection with a WebSocket has been closed because of an error, such as when some data couldn't be sent. Also available via the onerror property. |
| `OnMessage` | `ActionEvent<MessageEvent>` | Fired when data is received through a WebSocket. Also available via the onmessage property. |
| `OnOpen` | `ActionEvent<Event>` | Fired when a connection with a WebSocket is opened. Also available via the onopen property. |

## Example

```csharp
// Connect to a WebSocket server, send a message, receive data, and close
using var ws = new WebSocket("wss://echo.websocket.org");

// Use arraybuffer for binary data instead of the default blob
ws.BinaryType = "arraybuffer";

// Subscribe to events using named methods (required for proper cleanup)
ws.OnOpen += WS_OnOpen;
ws.OnMessage += WS_OnMessage;
ws.OnError += WS_OnError;
ws.OnClose += WS_OnClose;

// Check connection state before sending
if (ws.ReadyState == 1) // OPEN
{
    ws.Send("Another message");
}

// Unsubscribe before disposing - every += must have a matching -=
ws.OnOpen -= WS_OnOpen;
ws.OnMessage -= WS_OnMessage;
ws.OnError -= WS_OnError;
ws.OnClose -= WS_OnClose;

// Close with a code and reason
ws.Close(1000, "Done");

void WS_OnOpen(Event e)
{
    Console.WriteLine($"Connected to {ws.Url}");
    ws.Send("Hello Server!");

    // You can also send binary data
    var bytes = new byte[] { 0x01, 0x02, 0x03 };
    ws.Send(bytes);

    e.Dispose();
}

void WS_OnMessage(MessageEvent e)
{
    var data = e.DataAs<string>();
    Console.WriteLine($"Received: {data}");
    e.Dispose();
}

void WS_OnError(Event e)
{
    Console.WriteLine("WebSocket error occurred");
    e.Dispose();
}

void WS_OnClose(CloseEvent e)
{
    Console.WriteLine($"Disconnected: code={e.Code} reason={e.Reason}");
    e.Dispose();
}
```

