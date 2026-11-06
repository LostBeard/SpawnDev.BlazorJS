# IMessagePortSimple

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/MessagePort.cs`  

> MessagePort simple interface

## Methods

| Method | Return Type | Description |
|---|---|---|
| `PostMessage(object message)` | `void` | Sends a message from the port, and optionally, transfers ownership of objects to other browsing contexts. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnMessageError` | `ActionEvent<MessageEvent>` | Fired when a MessagePort object receives a message that can't be deserialized. |
| `OnMessage` | `ActionEvent<MessageEvent>` | Fired when a MessagePort object receives a message. Start() must be called to start receiving messages when using addEventListener instead of assigning onmessage. |
