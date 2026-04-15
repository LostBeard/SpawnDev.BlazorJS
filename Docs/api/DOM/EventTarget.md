# EventTarget

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/DOM/EventTarget.cs`  
**MDN Reference:** [EventTarget on MDN](https://developer.mozilla.org/en-US/docs/Web/API/EventTarget)

> The EventTarget interface is implemented by objects that can receive events and may have listeners for them. In other words, any target of events implements the three methods associated with this interface. https://developer.mozilla.org/en-US/docs/Web/API/EventTarget

## Constructors

| Signature | Description |
|---|---|
| `EventTarget(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `EventTarget()` | The EventTarget() constructor creates a new EventTarget object instance. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `RefCount` | `int` | get/set | AddEventListener call count - RemoveEventListener call count Callback will be disposed when RefCount == 0 |
| `Callback` | `Callback` | get | Holds a reference to the callback fo disposing when done using |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `DispatchEvent(Event @event)` | `bool` | The dispatchEvent() method of the EventTarget sends an Event to the object, (synchronously) invoking the affected event listeners in the appropriate order. The normal event processing rules (including the capturing and optional bubbling phase) also apply to events dispatched manually with dispatchEvent(). |
| `AddEventListener(string type, Callback listener)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `AddEventListener(string type, Callback listener, bool useCapture)` | `void` | Registers an event handler of a specific event type on the EventTarget. A case-sensitive string representing the event type to listen for. The object that receives a notification (an object that implements the Event interface) when an event of the specified type occurs. This must be null, an object with a handleEvent() method, or a JavaScript function. See The event listener callback for details on the callback itself. A boolean value indicating whether events of this type will be dispatched to the registered listener before being dispatched to any EventTarget beneath it in the DOM tree. Events that are bubbling upward through the tree will not trigger a listener designated to use capture. Event bubbling and capturing are two ways of propagating events that occur in an element that is nested within another element, when both elements have registered a handle for that event. The event propagation mode determines the order in which elements receive the event. See DOM Level 3 Events and JavaScript Event order for a detailed explanation. If not specified, useCapture defaults to false. |
| `AddEventListener(string type, Callback listener, AddEventListenerOptions options)` | `void` | Registers an event handler of a specific event type on the EventTarget. A case-sensitive string representing the event type to listen for. The object that receives a notification (an object that implements the Event interface) when an event of the specified type occurs. This must be null, an object with a handleEvent() method, or a JavaScript function. See The event listener callback for details on the callback itself. An object that specifies characteristics about the event listener |
| `RemoveEventListener(string type, Callback listener)` | `void` | Removes an event listener from the EventTarget. |
| `RemoveEventListener(string type, Callback listener, bool useCapture)` | `void` | Removes an event listener from the EventTarget. |
| `RemoveEventListener(string type, Callback listener, AddEventListenerOptions options)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Func<TResult> listener, bool useCapture)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Func<TResult> listener, bool useCapture)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Func<T1, TResult> listener, bool useCapture)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Func<T1, TResult> listener, bool useCapture)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Func<T1, T2, TResult> listener, bool useCapture)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Func<T1, T2, TResult> listener, bool useCapture)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Func<T1, T2, T3, TResult> listener, bool useCapture)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Func<T1, T2, T3, TResult> listener, bool useCapture)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Func<T1, T2, T3, T4, TResult> listener, bool useCapture)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Func<T1, T2, T3, T4, TResult> listener, bool useCapture)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Func<TResult> listener, AddEventListenerOptions options)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Func<TResult> listener, AddEventListenerOptions options)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Func<T1, TResult> listener, AddEventListenerOptions options)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Func<T1, TResult> listener, AddEventListenerOptions options)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Func<T1, T2, TResult> listener, AddEventListenerOptions options)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Func<T1, T2, TResult> listener, AddEventListenerOptions options)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Func<T1, T2, T3, TResult> listener, AddEventListenerOptions options)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Func<T1, T2, T3, TResult> listener, AddEventListenerOptions options)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Func<T1, T2, T3, T4, TResult> listener, AddEventListenerOptions options)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Func<T1, T2, T3, T4, TResult> listener, AddEventListenerOptions options)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Action listener, bool useCapture)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Action listener, bool useCapture)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Action<T1> listener, bool useCapture)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Action<T1> listener, bool useCapture)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Action<T1, T2> listener, bool useCapture)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Action<T1, T2> listener, bool useCapture)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Action<T1, T2, T3> listener, bool useCapture)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Action<T1, T2, T3> listener, bool useCapture)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Action<T1, T2, T3, T4> listener, bool useCapture)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Action<T1, T2, T3, T4> listener, bool useCapture)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Action listener, AddEventListenerOptions options)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Action listener, AddEventListenerOptions options)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Action<T1> listener, AddEventListenerOptions options)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Action<T1> listener, AddEventListenerOptions options)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Action<T1, T2> listener, AddEventListenerOptions options)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Action<T1, T2> listener, AddEventListenerOptions options)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Action<T1, T2, T3> listener, AddEventListenerOptions options)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Action<T1, T2, T3> listener, AddEventListenerOptions options)` | `void` | Removes an event listener from the EventTarget. |
| `AddEventListener(string type, Action<T1, T2, T3, T4> listener, AddEventListenerOptions options)` | `void` | Registers an event handler of a specific event type on the EventTarget. |
| `RemoveEventListener(string type, Action<T1, T2, T3, T4> listener, AddEventListenerOptions options)` | `void` | Removes an event listener from the EventTarget. |

## Example

```csharp
// The preferred way to handle events in SpawnDev.BlazorJS is via
// ActionEvent properties with += and -= operators on typed wrapper classes.
// Direct AddEventListener/RemoveEventListener is rarely needed.

// Preferred pattern - use ActionEvent properties on typed wrappers:
using var window = JS.Get<Window>("window");
Action<Event> resizeHandler = (e) =>
{
    Console.WriteLine("Window resized");
};
window.OnResize += resizeHandler;
// Always unsubscribe before disposal
window.OnResize -= resizeHandler;

// Direct AddEventListener/RemoveEventListener - for advanced use cases:
using var el = new HTMLElement(elementRef);
Action<Event> clickHandler = (e) =>
{
    Console.WriteLine("Clicked via AddEventListener");
};
el.AddEventListener("click", clickHandler);
// Must remove with the same handler reference
el.RemoveEventListener("click", clickHandler);

// Dispatch a custom event
using var target = new EventTarget();
using var customEvent = new CustomEvent("myevent", new CustomEventInit
{
    Detail = "payload data",
    Bubbles = true
});
bool dispatched = target.DispatchEvent(customEvent);
```

