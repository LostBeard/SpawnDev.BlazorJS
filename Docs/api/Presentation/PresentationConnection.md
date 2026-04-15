# PresentationConnection

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Presentation/PresentationConnection.cs`  

> The PresentationConnection interface of the Presentation API provides the methods for a presentation connection.

## Constructors

| Signature | Description |
|---|---|
| `PresentationConnection(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Id` | `string` | get | Returns the ID of the presentation connection. |
| `Url` | `string` | get | Returns the URL of the presentation connection. |
| `State` | `string` | get | Returns the state of the presentation connection. |
| `BinaryType` | `string` | get | Returns and sets the binary type of the presentation connection. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Close()` | `void` | Closes the presentation connection. |
| `Terminate()` | `void` | Terminates the presentation connection. |
| `Send(string message)` | `void` | Sends a message to the presentation connection. |
| `Send(Blob message)` | `void` | Sends a message to the presentation connection. |
| `Send(ArrayBuffer message)` | `void` | Sends a message to the presentation connection. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnClose` | `ActionEvent<PresentationConnectionCloseEvent>` | Fired when the state of the presentation connection changes to closed. |
| `OnConnect` | `ActionEvent<Event>` | Fired when the state of the presentation connection changes to connected. |
| `OnMessage` | `ActionEvent<MessageEvent>` | Fired when a message is received from the presentation connection. |
| `OnTerminate` | `ActionEvent<Event>` | Fired when the state of the presentation connection changes to terminated. |

