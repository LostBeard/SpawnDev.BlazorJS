# UIEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/UIEvent.cs`  
**MDN Reference:** [UIEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/UIEvent)

> The UIEvent interface represents simple user interface events. https://developer.mozilla.org/en-US/docs/Web/API/UIEvent

## Constructors

| Signature | Description |
|---|---|
| `UIEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `View` | `Window` | get | Returns a WindowProxy that contains the view that generated the event. |
| `Detail` | `long` | get | Returns a long with details about the event, depending on the event type. |
| `SourceCapabilities` | `InputDeviceCapabilities` | get | Returns an instance of the InputDeviceCapabilities interface, which provides information about the physical device responsible for generating a touch event. |

