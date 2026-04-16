# RTCDataChannel

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inheritance:** `JSObject` -> `EventTarget` -> `RTCDataChannel`  
**MDN Reference:** [RTCDataChannel](https://developer.mozilla.org/en-US/docs/Web/API/RTCDataChannel)

> The `RTCDataChannel` class represents a bi-directional data channel between two peers in a WebRTC connection. Data channels can carry arbitrary data (text or binary) and support ordered/unordered delivery and configurable reliability. Created via `RTCPeerConnection.CreateDataChannel()` or received via the `OnDataChannel` event.

## Constructors

| Signature | Description |
|-----------|-------------|
| `RTCDataChannel(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Label` | `string` | The name of the data channel. |
| `Ordered` | `bool` | Whether messages are delivered in order. |
| `Protocol` | `string` | The sub-protocol in use. |
| `ReadyState` | `string` | Current state: `"connecting"`, `"open"`, `"closing"`, `"closed"`. |
| `BufferedAmount` | `long` | Number of bytes queued for sending. |
| `BufferedAmountLowThreshold` | `long` | The threshold at which `OnBufferedAmountLow` fires. |
| `BinaryType` | `string` | Binary data type: `"arraybuffer"` or `"blob"`. |
| `MaxPacketLifeTime` | `int?` | Maximum time (ms) to attempt retransmission. |
| `MaxRetransmits` | `int?` | Maximum number of retransmission attempts. |
| `Negotiated` | `bool` | Whether the channel was negotiated out-of-band. |
| `Id` | `int?` | The channel's ID number. |

## Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Send(string data)` | `void` | Sends a text message. |
| `Send(ArrayBuffer data)` | `void` | Sends binary data as an `ArrayBuffer`. |
| `Send(Blob data)` | `void` | Sends binary data as a `Blob`. |
| `Send(TypedArray data)` | `void` | Sends binary data from a `TypedArray`. |
| `Send(byte[] data)` | `void` | Sends binary data from a .NET `byte[]`. |
| `Close()` | `void` | Closes the data channel. |

## Events

| Event | Type | Description |
|-------|------|-------------|
| `OnOpen` | `ActionEvent<Event>` | Fired when the channel is open and ready to send/receive data. |
| `OnClose` | `ActionEvent<Event>` | Fired when the channel is closed. |
| `OnMessage` | `ActionEvent<MessageEvent>` | Fired when a message is received. |
| `OnError` | `ActionEvent<RTCErrorEvent>` | Fired when an error occurs. |
| `OnBufferedAmountLow` | `ActionEvent<Event>` | Fired when the buffered amount drops below the threshold. |

## Example

```csharp
// Create a data channel
using var channel = pc.CreateDataChannel("file-transfer", new RTCDataChannelOptions
{
    Ordered = true,
    MaxRetransmits = 3
});

// Subscribe to events using named methods (required for proper cleanup)
channel.OnOpen += Channel_OnOpen;
channel.OnMessage += Channel_OnMessage;
channel.OnClose += Channel_OnClose;

// Monitor buffered amount for flow control
channel.BufferedAmountLowThreshold = 65536;
channel.OnBufferedAmountLow += Channel_OnBufferedAmountLow;

// Send binary data
byte[] binaryData = new byte[] { 0x01, 0x02, 0x03 };
channel.Send(binaryData);

// Send typed array data
using var float32Data = new Float32Array(new float[] { 1.0f, 2.0f, 3.0f });
channel.Send(float32Data);

// Clean up event handlers before disposal
channel.OnOpen -= Channel_OnOpen;
channel.OnMessage -= Channel_OnMessage;
channel.OnClose -= Channel_OnClose;
channel.OnBufferedAmountLow -= Channel_OnBufferedAmountLow;

void Channel_OnOpen(Event evt)
{
    Console.WriteLine($"Channel '{channel.Label}' opened");
    channel.Send("Hello from the local peer!");
    evt.Dispose();
}

void Channel_OnMessage(MessageEvent evt)
{
    var data = evt.Data;
    if (data is string textData)
    {
        Console.WriteLine($"Received text: {textData}");
    }
    evt.Dispose();
}

void Channel_OnClose(Event evt)
{
    Console.WriteLine("Channel closed");
    evt.Dispose();
}

void Channel_OnBufferedAmountLow(Event evt)
{
    // Safe to send more data
    evt.Dispose();
}
```
