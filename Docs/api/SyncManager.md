# SyncManager

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/SyncManager.cs`  
**MDN Reference:** [SyncManager on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SyncManager)

> The SyncManager interface of the Background Synchronization API provides an interface for registering and listing sync registrations. https://developer.mozilla.org/en-US/docs/Web/API/SyncManager

## Constructors

| Signature | Description |
|---|---|
| `SyncManager(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Register(string tag)` | `Task` | The SyncManager interface of the Background Synchronization API provides an interface for registering and listing sync registrations. An identifier for this synchronization event. This will be the value of the tag property of the SyncEvent that gets passed into the service worker's sync event handler. |
| `GetTags()` | `Task<string[]>` | The getTags() method of the SyncManager interface returns a list of developer-defined identifiers for SyncManager registrations. |

