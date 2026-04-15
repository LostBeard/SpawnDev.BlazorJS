# PresentationRequest

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Presentation/PresentationRequest.cs`  

> The PresentationRequest interface of the Presentation API provides methods to start a new presentation or reconnect to an existing one.

## Constructors

| Signature | Description |
|---|---|
| `PresentationRequest(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `PresentationRequest(string url)` | Creates a new PresentationRequest. |
| `PresentationRequest(IEnumerable<string> urls)` | Creates a new PresentationRequest. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Start()` | `Task<PresentationConnection>` | Starts a new presentation connection. |
| `Reconnect(string id)` | `Task<PresentationConnection>` | Reconnects to an existing presentation connection. |
| `GetAvailability()` | `Task<PresentationAvailability>` | Returns a promise that resolves with a PresentationAvailability object. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnConnectionAvailable` | `ActionEvent<PresentationConnectionAvailableEvent>` | Fired when a presentation connection is available. |

