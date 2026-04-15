# BroadcastChannel

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`, `IMessagePortSimple`  
**Source:** `JSObjects/BroadcastChannel.cs`  
**MDN Reference:** [BroadcastChannel on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BroadcastChannel)

> The Broadcast Channel API allows basic communication between browsing contexts (that is, windows, tabs, frames, or iframes) and workers on the same origin. https://developer.mozilla.org/en-US/docs/Web/API/BroadcastChannel

## Constructors

| Signature | Description |
|---|---|
| `BroadcastChannel(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `BroadcastChannel(string channelName)` | The BroadcastChannel() constructor creates a new BroadcastChannel and connects it to the underlying channel. A string representing the name of the channel; there is one single channel with this name for all browsing contexts with the same origin. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `string` | get | Returns a string, the name of the channel. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Close()` | `void` | The BroadcastChannel.close() terminates the connection to the underlying channel, allowing the object to be garbage collected. This is a necessary step to perform as there is no other way for a browser to know that this channel is not needed anymore. |
| `PostMessage(object message)` | `void` | The BroadcastChannel.postMessage() sends a message, which can be of any kind of Object, to each listener in any browsing context with the same origin. The message is transmitted as a 'message' event targeted at each BroadcastChannel bound to the channel. Data to be sent to the other window. The data is serialized using the structured clone algorithm. This means you can pass a broad variety of data objects safely to the destination window without having to serialize them yourself. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnMessage` | `ActionEvent<MessageEvent>` | Fired when a message arrives on the channel. Also available via the onmessage property. |
| `OnMessageError` | `ActionEvent<MessageEvent>` | Fired when a message arrives that can't be deserialized. Also available via the onmessageerror property. |

## Example

```csharp
// Create a BroadcastChannel - all tabs/workers on the same origin with
// the same channel name will receive messages sent on this channel
using var channel = new BroadcastChannel("my-app-sync");

Console.WriteLine($"Channel name: {channel.Name}");

// Listen for messages from other tabs/workers
Action<MessageEvent> onMessage = (MessageEvent e) =>
{
    var data = e.DataAs<string>();
    Console.WriteLine($"Received broadcast: {data}");
    e.Dispose();
};
channel.OnMessage += onMessage;

// Send a message to all other tabs/workers on this channel
channel.PostMessage("User logged in");

// Send structured data
channel.PostMessage(new { type = "sync", timestamp = DateTime.UtcNow.Ticks });

// Clean up the event handler before closing
channel.OnMessage -= onMessage;

// Close the channel when done
channel.Close();
```

