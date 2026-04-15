# EventTarget

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** JSObject -> EventTarget  
**MDN Reference:** [EventTarget on MDN](https://developer.mozilla.org/en-US/docs/Web/API/EventTarget)  
**Source:** `SpawnDev.BlazorJS/JSObjects/DOM/EventTarget.cs`

> The EventTarget interface is the base class for all objects that can receive events and have listeners attached to them. It is the foundation of the DOM event system in SpawnDev.BlazorJS. Node, Element, Window, and all other event-dispatching objects inherit from EventTarget.

**Important:** In SpawnDev.BlazorJS, you should use ActionEvent properties with `+=`/`-=` operators instead of calling AddEventListener/RemoveEventListener directly. The ActionEvent system handles Callback reference counting automatically.

## Constructor

```csharp
// From existing reference
public EventTarget(IJSInProcessObjectReference _ref)

// Create a new standalone EventTarget
public EventTarget()
```

## Methods

| Method | Return Type | Description |
|---|---|---|
| `AddEventListener(string type, Callback listener)` | `void` | Register an event handler for the specified event type. |
| `AddEventListener(string type, Callback listener, bool useCapture)` | `void` | Register with capture phase control. |
| `AddEventListener(string type, Callback listener, AddEventListenerOptions options)` | `void` | Register with detailed options (capture, once, passive, signal). |
| `RemoveEventListener(string type, Callback listener)` | `void` | Remove an event handler. |
| `RemoveEventListener(string type, Callback listener, bool useCapture)` | `void` | Remove with capture phase control. |
| `RemoveEventListener(string type, Callback listener, AddEventListenerOptions options)` | `void` | Remove with options. |
| `DispatchEvent(Event event)` | `bool` | Dispatch an event to this target. Returns false if event was cancelled. |

EventTarget also supports typed Action/Func overloads of AddEventListener and RemoveEventListener (up to 7 type parameters) with automatic Callback tracking. However, these are primarily used internally by the ActionEvent system.

## Example - Using ActionEvent (Recommended)

```csharp
// This is the correct way to handle events in SpawnDev.BlazorJS
using var element = doc.QuerySelector<Element>("#myButton");

void HandleClick(MouseEvent e)
{
    Console.WriteLine($"Clicked at {e.ClientX}, {e.ClientY}");
}

element.OnClick += HandleClick;
// ... later ...
element.OnClick -= HandleClick;
```

## Example - Dispatching Custom Events

```csharp
using var target = new EventTarget();

void HandleCustom(CustomEvent e)
{
    var detail = e.DetailAs<string>();
    Console.WriteLine($"Custom event: {detail}");
}

target.OnCustom += HandleCustom; // assuming an ActionEvent property exists

// Dispatch
using var evt = new CustomEvent("custom", new CustomEventOptions { Detail = "hello" });
target.DispatchEvent(evt);
```

## Example - Low-Level AddEventListener (Avoid if possible)

```csharp
// Only use this when ActionEvent properties are not available
using var cb = Callback.Create<Event>(e => Console.WriteLine(e.Type));
eventTarget.AddEventListener("customEvent", cb);
// ...
eventTarget.RemoveEventListener("customEvent", cb);
cb.Dispose();
```
