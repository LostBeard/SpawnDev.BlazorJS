# PresentationAvailability

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Presentation/PresentationAvailability.cs`  

> The PresentationAvailability interface of the Presentation API provides a way to detect when there is a display available to start a presentation.

## Constructors

| Signature | Description |
|---|---|
| `PresentationAvailability(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Value` | `bool` | get | Returns a boolean value that is true if there is an available display to start a presentation, and false otherwise. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnChange` | `ActionEvent<Event>` | Fired when the availability of a presentation display changes. |

