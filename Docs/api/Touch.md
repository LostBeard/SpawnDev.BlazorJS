# Touch

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Touch.cs`  
**MDN Reference:** [Touch on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Touch)

> The Touch interface represents a single contact point on a touch-sensitive device. The contact point is commonly a finger or stylus and the device may be a touchscreen or trackpad. https://developer.mozilla.org/en-US/docs/Web/API/Touch

## Constructors

| Signature | Description |
|---|---|
| `Touch(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Identifier` | `long` | get | A unique identifier for this Touch object. A given touch point (say, by a finger) will have the same identifier for the duration of its movement around the surface. |
| `ClientX` | `double` | get | The X coordinate of the touch point relative to the left edge of the browser viewport, not including any scroll offset. |
| `ClientY` | `double` | get | The Y coordinate of the touch point relative to the top edge of the browser viewport, not including any scroll offset. |
| `PageX` | `double` | get | The X coordinate of the touch point relative to the left edge of the document. |
| `PageY` | `double` | get | The Y coordinate of the touch point relative to the top edge of the document. |
| `ScreenX` | `double` | get | The X coordinate of the touch point relative to the left edge of the screen. |
| `ScreenY` | `double` | get | The Y coordinate of the touch point relative to the top edge of the screen. |
| `Target` | `EventTarget?` | get | The Element on which the touch point started when it was first placed on the surface. |
| `RadiusX` | `double` | get | The X radius of the ellipse that most closely circumscribes the area of contact with the screen. |
| `RadiusY` | `double` | get | The Y radius of the ellipse that most closely circumscribes the area of contact with the screen. |
| `RotationAngle` | `double` | get | The angle (in degrees) that the ellipse described by radiusX and radiusY must be rotated, clockwise, to most accurately cover the area of contact. |
| `Force` | `double` | get | The amount of pressure being applied to the surface by the user, as a float between 0.0 (no pressure) and 1.0 (maximum pressure). |

