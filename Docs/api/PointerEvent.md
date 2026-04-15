# PointerEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `MouseEvent`  
**Source:** `JSObjects/PointerEvent.cs`  
**MDN Reference:** [PointerEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PointerEvent)

> The PointerEvent interface represents the state of a DOM event produced by a pointer such as the geometry of the contact point, the device type that generated the event, the amount of pressure that was applied on the contact surface, etc. https://developer.mozilla.org/en-US/docs/Web/API/PointerEvent

## Constructors

| Signature | Description |
|---|---|
| `PointerEvent(string type)` | The PointerEvent() constructor creates a new synthetic and untrusted PointerEvent object instance. A string representing the name of the event (see PointerEvent event types). |
| `PointerEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AltitudeAngle` | `double` | get | Represents the angle between a transducer (a pointer or stylus) axis and the X-Y plane of a device screen. |
| `AzimuthAngle` | `double` | get | Represents the angle between the Y-Z plane and the plane containing both the transducer (a pointer or stylus) axis and the Y axis. |
| `PointerId` | `int` | get | A unique identifier for the pointer causing the event. |
| `Width` | `int` | get | The width (magnitude on the X axis), in CSS pixels, of the contact geometry of the pointer. |
| `Height` | `int` | get | The height (magnitude on the Y axis), in CSS pixels, of the contact geometry of the pointer. |
| `Pressure` | `double` | get | The normalized pressure of the pointer input in the range 0 to 1, where 0 and 1 represent the minimum and maximum pressure the hardware is capable of detecting, respectively. |
| `TangentialPressure` | `double` | get | The normalized tangential pressure of the pointer input (also known as barrel pressure or cylinder stress) in the range -1 to 1, where 0 is the neutral position of the control. |
| `TiltX` | `double` | get | The plane angle (in degrees, in the range of -90 to 90) between the Y-Z plane and the plane containing both the pointer (e.g. pen stylus) axis and the Y axis. |
| `TiltY` | `double` | get | The plane angle (in degrees, in the range of -90 to 90) between the X-Z plane and the plane containing both the pointer (e.g. pen stylus) axis and the X axis. |
| `Twist` | `double` | get | The clockwise rotation of the pointer (e.g. pen stylus) around its major axis in degrees, with a value in the range 0 to 359. |
| `PointerType` | `string` | get | Indicates the device type that caused the event (mouse, pen, touch, etc.). |
| `IsPrimary` | `bool` | get | Indicates if the pointer represents the primary pointer of this pointer type. |
| `GetCoalescedEvents` | `Array<PointerEvent>` | get | Returns a sequence of all PointerEvent instances that were coalesced into the dispatched pointermove event. |
| `GetPredictedEvents` | `Array<PointerEvent>` | get | Returns a sequence of PointerEvent instances that the browser predicts will follow the dispatched pointermove event's coalesced events. |

