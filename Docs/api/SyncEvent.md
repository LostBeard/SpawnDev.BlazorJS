# SyncEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ExtendableEvent`  
**Source:** `JSObjects/SyncEvent.cs`  
**MDN Reference:** [SyncEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SyncEvent)

> The SyncEvent interface of the Background Synchronization API represents a sync action that is dispatched on the ServiceWorkerGlobalScope of a ServiceWorker. https://developer.mozilla.org/en-US/docs/Web/API/SyncEvent

## Constructors

| Signature | Description |
|---|---|
| `SyncEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `LastChance` | `bool` | get | Returns true if the user agent will not make further synchronization attempts after the current attempt. |
| `Tag` | `string` | get | Returns the developer-defined identifier for this SyncEvent. |

