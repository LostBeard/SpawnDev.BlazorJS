# MessageChannel

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/MessageChannel.cs`  
**MDN Reference:** [MessageChannel on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MessageChannel)

> The MessageChannel interface of the Channel Messaging API allows us to create a new message channel and send data through it via its two MessagePort properties. https://developer.mozilla.org/en-US/docs/Web/API/MessageChannel

## Constructors

| Signature | Description |
|---|---|
| `MessageChannel(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `MessageChannel()` | The MessageChannel() constructor of the MessageChannel interface returns a new MessageChannel object with two new MessagePort objects. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Port1` | `MessagePort` | get | Returns port1 of the channel. |
| `Port2` | `MessagePort` | get | Returns port2 of the channel. |

## Example

```csharp
// Create a MessageChannel with two connected ports
using var channel = new MessageChannel();

// Get the two ports - messages sent on one arrive on the other
using var port1 = channel.Port1;
using var port2 = channel.Port2;

// Set up a message handler on port1
Action<MessageEvent> onPort1Message = (MessageEvent e) =>
{
    var data = e.DataAs<string>();
    Console.WriteLine($"Port1 received: {data}");
    e.Dispose();
};
port1.OnMessage += onPort1Message;
port1.Start(); // Required when using addEventListener (ActionEvent uses addEventListener)

// Set up a message handler on port2
Action<MessageEvent> onPort2Message = (MessageEvent e) =>
{
    var data = e.DataAs<string>();
    Console.WriteLine($"Port2 received: {data}");
    e.Dispose();
};
port2.OnMessage += onPort2Message;
port2.Start();

// Send a message from port2 to port1
port2.PostMessage("Hello from port2!");

// Send a message from port1 to port2
port1.PostMessage("Hello from port1!");

// Transfer port2 to a worker (zero-copy ownership transfer)
// worker.PostMessage(new { port = port2 }, new object[] { port2 });

// Clean up
port1.OnMessage -= onPort1Message;
port2.OnMessage -= onPort2Message;
port1.Close();
port2.Close();
```

