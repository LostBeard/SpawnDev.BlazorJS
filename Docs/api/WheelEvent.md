# WheelEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `MouseEvent`  
**Source:** `JSObjects/WheelEvent.cs`  
**MDN Reference:** [WheelEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WheelEvent)

> The WheelEvent interface represents events that occur due to the user moving a mouse wheel or similar input device. https://developer.mozilla.org/en-US/docs/Web/API/WheelEvent

## Constructors

| Signature | Description |
|---|---|
| `WheelEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `DeltaX` | `double` | get | Returns a double representing the horizontal scroll amount. |
| `DeltaY` | `double` | get | Returns a double representing the vertical scroll amount. |
| `DeltaZ` | `double` | get | Returns a double representing the scroll amount for the z-axis. |
| `DeltaMode` | `ulong` | get | Returns an unsigned long representing the unit of the delta* values' scroll amount. Permitted values are: |

