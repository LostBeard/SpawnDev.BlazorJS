# CloseEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/CloseEvent.cs`  
**MDN Reference:** [CloseEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CloseEvent)

> A CloseEvent is sent to clients using WebSockets when the connection is closed. This is delivered to the listener indicated by the WebSocket object's onclose attribute. https://developer.mozilla.org/en-US/docs/Web/API/CloseEvent

## Constructors

| Signature | Description |
|---|---|
| `CloseEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Code` | `ushort` | get | Returns an unsigned short containing the close code sent by the server. |
| `Reason` | `string` | get | Returns a string indicating the reason the server closed the connection. This is specific to the particular server and sub-protocol. |
| `WasClean` | `bool` | get | Returns a boolean value that Indicates whether or not the connection was cleanly closed. |

