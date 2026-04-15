# Event

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** JSObject -> Event  
**MDN Reference:** [Event on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Event)  
**Source:** `SpawnDev.BlazorJS/JSObjects/DOM/Event.cs`

> The Event interface represents an event which takes place on an EventTarget. It is the base class for all event types in SpawnDev.BlazorJS - MouseEvent, KeyboardEvent, TouchEvent, CustomEvent, etc. all inherit from Event. It provides common properties like type, target, and bubbling behavior, plus methods for controlling event propagation.

## Constructor

```csharp
// From existing reference (deserialization)
public Event(IJSInProcessObjectReference _ref)
```

## Properties

| Property | Type | Description |
|---|---|---|
| `Type` | `string` | The name of the event (e.g., "click", "keydown", "resize"). |
| `Target` | `EventTarget` | The original target that dispatched the event. |
| `CurrentTarget` | `EventTarget?` | The target currently processing the event (during bubbling/capture). |
| `EventPhase` | `int` | The phase of the event flow: 0=NONE, 1=CAPTURING, 2=AT_TARGET, 3=BUBBLING. |
| `Bubbles` | `bool` | Whether the event bubbles up through the DOM. |
| `Cancelable` | `bool` | Whether the event can be cancelled via preventDefault(). |
| `DefaultPrevented` | `bool` | Whether preventDefault() was called. |
| `Composed` | `bool` | Whether the event can cross shadow DOM boundaries. |
| `IsTrusted` | `bool` | True if the event was initiated by the browser (not by script). |
| `TimeStamp` | `double` | The time the event was created (milliseconds). |

## Typed Target Accessors

| Method | Return Type | Description |
|---|---|---|
| `TargetAs<T>()` | `T` | Get Target cast to a specific EventTarget subclass. |
| `CurrentTargetAs<T>()` | `T` | Get CurrentTarget cast to a specific EventTarget subclass. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `PreventDefault()` | `void` | Cancel the event's default action (if cancelable). |
| `StopPropagation()` | `void` | Stop the event from propagating to parent elements. Does not prevent other listeners on the current element. |
| `StopImmediatePropagation()` | `void` | Stop propagation AND prevent remaining listeners on the current element from being called. |
| `ComposedPath()` | `Array<EventTarget>` | Get the event's propagation path (array of EventTargets). |

## Generic Variant: Event&lt;TTarget&gt;

```csharp
public class Event<TTarget> : Event where TTarget : EventTarget
```

Overrides the `Target` property to return the specific target type directly.

| Property | Type | Description |
|---|---|---|
| `Target` | `TTarget` | The event target, strongly typed. |

## Example

```csharp
void HandleClick(Event e)
{
    Console.WriteLine($"Event type: {e.Type}");         // "click"
    Console.WriteLine($"Bubbles: {e.Bubbles}");          // true
    Console.WriteLine($"Trusted: {e.IsTrusted}");        // true (if user-initiated)
    Console.WriteLine($"Timestamp: {e.TimeStamp}ms");

    // Get target as specific type
    using var target = e.TargetAs<HTMLElement>();
    Console.WriteLine($"Target tag: {target.TagName}");

    // Cancel default behavior
    if (e.Cancelable)
    {
        e.PreventDefault();
    }

    // Stop bubbling
    e.StopPropagation();
}

element.OnClick += HandleClick;
```

## Example - Event&lt;TTarget&gt;

```csharp
// When the target type is known
void HandleInput(Event<HTMLInputElement> e)
{
    // Target is already typed - no casting needed
    string value = e.Target.Value;
    Console.WriteLine($"Input value: {value}");
}
```
