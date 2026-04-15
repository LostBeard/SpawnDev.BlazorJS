# PresentationConnectionCloseEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/Presentation/PresentationConnectionCloseEvent.cs`  

> The PresentationConnectionCloseEvent interface of the Presentation API is fired on a PresentationConnection when it is closed.

## Constructors

| Signature | Description |
|---|---|
| `PresentationConnectionCloseEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Message` | `string` | get | Returns a human-readable message that explains why the connection closed. |
| `Reason` | `string` | get | Returns the reason why the connection closed. |

