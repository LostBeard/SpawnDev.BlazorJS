# Client

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Client.cs`  
**MDN Reference:** [Client on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Client)

> The Client interface represents an executable context such as a Worker, or a SharedWorker. Window clients are represented by the more-specific WindowClient. You can get Client/WindowClient objects from methods such as Clients.matchAll() and Clients.get(). https://developer.mozilla.org/en-US/docs/Web/API/Client

## Constructors

| Signature | Description |
|---|---|
| `Client(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Id` | `string` | get | The universally unique identifier of the client as a string. |
| `Type` | `string` | get | The client's type as a string. It can be "window", "worker", or "sharedworker". |
| `Url` | `string` | get | The URL of the client as a string. |
| `FrameType` | `string` | get | The client's frame type as a string. It can be "auxiliary", "top-level", "nested", or "none". |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `PostMessage(object message)` | `void` | Sends a message to the client. |
| `PostMessage(object message, object[] transfer)` | `void` | Sends a message to the client. |

