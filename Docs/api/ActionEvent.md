# ActionEvent

**Namespace:** `SpawnDev.BlazorJS`  
**Inheritance:** CallbackEvent -> ActionEvent -> ActionEvent&lt;T1&gt; -> ... -> ActionEvent&lt;T1...T7&gt;  
**Source:** `SpawnDev.BlazorJS/Events/ActionEvent.cs`

> ActionEvent provides a typed event subscription system using C# `+=` and `-=` operators. It bridges JavaScript events to .NET delegates with automatic reference counting via CallbackRef. Parameters of event handlers may be omitted if not required - you can subscribe to an event that provides arguments with a parameterless handler. This is the standard pattern for all events on JSObject wrappers in SpawnDev.BlazorJS.

## Variants

| Class | Description |
|---|---|
| `ActionEvent` | No-argument event handler. |
| `ActionEvent<T1>` | Event handler with 1 typed argument. |
| `ActionEvent<T1, T2>` | Event handler with 2 typed arguments. |
| `ActionEvent<T1, T2, T3>` | Event handler with 3 typed arguments. |
| `ActionEvent<T1, T2, T3, T4>` | Event handler with 4 typed arguments. |
| `ActionEvent<T1, T2, T3, T4, T5>` | Event handler with 5 typed arguments. |
| `ActionEvent<T1, T2, T3, T4, T5, T6>` | Event handler with 6 typed arguments. |
| `ActionEvent<T1, T2, T3, T4, T5, T6, T7>` | Event handler with 7 typed arguments. |

## Constructors

```csharp
// Using event name with addEventListener/removeEventListener delegates
new ActionEvent<T1>(string eventName, Action<string, Callback> on, Action<string, Callback>? off)

// Using direct on/off delegates
new ActionEvent<T1>(Action<Callback> on, Action<Callback>? off)
```

## Operators

| Operator | Description |
|---|---|
| `+=` Action | Subscribe a .NET delegate. Auto-creates and ref-counts the Callback. |
| `-=` Action | Unsubscribe a .NET delegate. Decrements ref count and removes the listener. |
| `+=` Callback | Subscribe a raw Callback instance. |
| `-=` Callback | Unsubscribe a raw Callback instance. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `On(Action listener)` | `void` | Add a listener (same as `+=`). |
| `Off(Action listener)` | `void` | Remove a listener (same as `-=`). |
| `On(Action<T1> listener)` | `void` | Add a typed listener (on ActionEvent&lt;T1&gt;). |
| `Off(Action<T1> listener)` | `void` | Remove a typed listener. |
| `On(Callback callback)` | `void` | Add a raw Callback listener. |
| `Off(Callback callback)` | `void` | Remove a raw Callback listener. |

## How It Works

ActionEvent properties are typically defined on JSObject subclasses like this:

```csharp
public ActionEvent<Event> OnChange
{
    get => new ActionEvent<Event>("change", AddEventListener, RemoveEventListener);
    set { }
}
```

This translates to JavaScript `addEventListener("change", callback)` and `removeEventListener("change", callback)`. The `set { }` is required for the `+=` and `-=` operators to compile - it is intentionally empty.

When you use `+=`, ActionEvent:
1. Creates a Callback wrapping your delegate (or increments its ref count if one already exists)
2. Calls AddEventListener with the event name and Callback

When you use `-=`, ActionEvent:
1. Looks up the existing Callback for your delegate
2. Calls RemoveEventListener with the event name and Callback
3. Decrements the Callback's ref count (disposing it if ref count reaches 0)

## Example - Basic Event Handling

```csharp
// Subscribe to window resize
var window = JS.Get<Window>("window");

void HandleResize(Event e)
{
    Console.WriteLine($"Resized to {window.InnerWidth}x{window.InnerHeight}");
}

window.OnResize += HandleResize;

// Later, before disposing:
window.OnResize -= HandleResize;
window.Dispose();
```

## Example - Omitting Parameters

```csharp
// You can omit parameters you don't need
// Even though OnMessage provides a MessageEvent, a parameterless handler works
void HandleMessage()
{
    Console.WriteLine("Message received");
}

worker.OnMessage += HandleMessage;
// ...
worker.OnMessage -= HandleMessage;
```

## Example - In a Blazor Component

```csharp
@inject BlazorJSRuntime JS
@implements IDisposable

@code {
    Window? _window;

    protected override void OnInitialized()
    {
        _window = JS.Get<Window>("window");
        _window.OnResize += OnWindowResize;
    }

    void OnWindowResize(Event e)
    {
        StateHasChanged();
    }

    public void Dispose()
    {
        if (_window != null)
        {
            _window.OnResize -= OnWindowResize; // MUST unsubscribe before dispose
            _window.Dispose();
        }
    }
}
```

## Critical Rules

- **Every `+=` MUST have a matching `-=` before the JSObject is disposed.** Failing to unsubscribe before disposal will cause the JavaScript callback to persist, leading to memory leaks and potential calls into disposed .NET objects that trigger Blazor error UI.
- **Never use AddEventListener directly** on EventTarget subclasses. Always use the ActionEvent properties with `+=`/`-=` operators - they handle ref counting automatically.
- **Use the same delegate instance** for `+=` and `-=`. The ref counting system tracks callbacks by delegate identity.
