# Event

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/DOM/Event.cs`  
**MDN Reference:** [Event on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Event)

> The Event interface represents an event which takes place on an EventTarget. https://developer.mozilla.org/en-US/docs/Web/API/Event

## Constructors

| Signature | Description |
|---|---|
| `Event(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Event(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Bubbles` | `bool` | get | A boolean value indicating whether or not the event bubbles up through the DOM. |
| `Cancelable` | `bool` | get | A boolean value indicating whether the event is cancelable. |
| `Composed` | `bool` | get | A boolean indicating whether or not the event can bubble across the boundary between the shadow DOM and the regular DOM. |
| `CurrentTarget` | `virtual EventTarget?` | get | A reference to the currently registered target for the event. This is the object to which the event is currently slated to be sent. It's possible this has been changed along the way through retargeting. |
| `DefaultPrevented` | `bool` | get | Indicates whether or not the call to event.preventDefault() canceled the event. |
| `EventPhase` | `int` | get | Indicates which phase of the event flow is being processed. It is one of the following numbers: NONE, CAPTURING_PHASE, AT_TARGET, BUBBLING_PHASE. |
| `IsTrusted` | `bool` | get | Indicates whether or not the event was initiated by the browser (after a user click, for instance) or by a script (using an event creation method, for example). |
| `Target` | `virtual EventTarget` | get | A reference to the object to which the event was originally dispatched. |
| `TimeStamp` | `double` | get | The time at which the event was created (in milliseconds). By specification, this value is time since epoch-but in reality, browsers' definitions vary. In addition, work is underway to change this to be a DOMHighResTimeStamp instead. |
| `Type` | `string` | get | The name identifying the type of the event. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CurrentTargetAs()` | `T` | A reference to the currently registered target for the event. This is the object to which the event is currently slated to be sent. It's possible this has been changed along the way through retargeting. |
| `TargetAs()` | `T` | A reference to the object to which the event was originally dispatched. |
| `ComposedPath()` | `Array<EventTarget>` | Returns the event's path (an array of objects on which listeners will be invoked). This does not include nodes in shadow trees if the shadow root was created with its ShadowRoot.mode closed. |
| `PreventDefault()` | `void` | Cancels the event (if it is cancelable). |
| `StopImmediatePropagation()` | `void` | The stopImmediatePropagation() method of the Event interface prevents other listeners of the same event from being called. If several listeners are attached to the same element for the same event type, they are called in the order in which they were added. If stopImmediatePropagation() is invoked during one such call, no remaining listeners will be called, either on that element or any other element. |
| `StopPropagation()` | `void` | The stopPropagation() method of the Event interface prevents further propagation of the current event in the capturing and bubbling phases. It does not, however, prevent any default behaviors from occurring; for instance, clicks on links are still processed. If you want to stop those behaviors, see the preventDefault() method. It also does not prevent propagation to other event-handlers of the current element. If you want to stop those, see stopImmediatePropagation(). |

