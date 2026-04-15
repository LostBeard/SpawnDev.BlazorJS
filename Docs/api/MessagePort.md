# IMessagePort

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `IMessagePortSimple`  
**Source:** `JSObjects/MessagePort.cs`  

> The MessagePort interface of the Channel Messaging API represents one of the two ports of a MessageChannel, allowing messages to be sent from one port and listening out for them arriving at the other.

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Start()` | `void` | Starts the sending of messages queued on the port (only needed when using EventTarget.addEventListener; it is implied when using onmessage). |
| `Close()` | `void` | Disconnects the port, so it is no longer active. |
| `PostMessage(object message)` | `void` | Sends a message from the port, and optionally, transfers ownership of objects to other browsing contexts. |
| `PostMessage(object message, object[] transfer)` | `void` | Sends a message from the port, and optionally, transfers ownership of objects to other browsing contexts. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnMessage` | `ActionEvent<MessageEvent>` | Fired when a MessagePort object receives a message. Start() must be called to start receiving messages when using addEventListener instead of assigning onmessage. |
| `OnMessageError` | `ActionEvent<MessageEvent>` | Fired when a MessagePort object receives a message that can't be deserialized. |

