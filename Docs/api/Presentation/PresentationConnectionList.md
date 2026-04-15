# PresentationConnectionList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Presentation/PresentationConnectionList.cs`  

> The PresentationConnectionList interface of the Presentation API represents a list of PresentationConnection objects that are associated with a presentation.

## Constructors

| Signature | Description |
|---|---|
| `PresentationConnectionList(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Connections` | `PresentationConnection[]` | get | Returns an array of PresentationConnection objects. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnConnectionAvailable` | `ActionEvent<PresentationConnectionAvailableEvent>` | Fired when a presentation connection is available. |

