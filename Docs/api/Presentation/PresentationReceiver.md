# PresentationReceiver

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Presentation/PresentationReceiver.cs`  

> The PresentationReceiver interface of the Presentation API provides a way for a receiving browsing context to access the controlling browsing contexts and communicate with them.

## Constructors

| Signature | Description |
|---|---|
| `PresentationReceiver(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ConnectionList` | `Task<PresentationConnectionList>` | get | Returns a Promise that resolves with a PresentationConnectionList object containing a list of incoming presentation connections. |

