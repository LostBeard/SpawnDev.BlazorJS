# FuncEvent

**Namespace:** `SpawnDev.BlazorJS`  
**Inheritance:** CallbackEvent -> FuncEvent&lt;TResult&gt; -> FuncEvent&lt;T1, TResult&gt; -> ... -> FuncEvent&lt;T1...T7, TResult&gt;  
**Source:** `SpawnDev.BlazorJS/Events/FuncEvent.cs`

> FuncEvent works exactly like ActionEvent but wraps Func delegates instead of Action delegates, allowing a return value to be sent back to JavaScript. This is used for events where the JavaScript caller expects a return value from the handler - for example, the `beforeunload` event where returning a string shows a confirmation dialog.

## Variants

| Class | Description |
|---|---|
| `FuncEvent<TResult>` | No-argument event handler that returns TResult. |
| `FuncEvent<T1, TResult>` | Event handler with 1 argument that returns TResult. |
| `FuncEvent<T1, T2, TResult>` | Event handler with 2 arguments that returns TResult. |
| `FuncEvent<T1, T2, T3, TResult>` | Event handler with 3 arguments that returns TResult. |
| `FuncEvent<T1, T2, T3, T4, TResult>` | Event handler with 4 arguments that returns TResult. |
| `FuncEvent<T1, T2, T3, T4, T5, TResult>` | Event handler with 5 arguments that returns TResult. |
| `FuncEvent<T1, T2, T3, T4, T5, T6, TResult>` | Event handler with 6 arguments that returns TResult. |
| `FuncEvent<T1, T2, T3, T4, T5, T6, T7, TResult>` | Event handler with 7 arguments that returns TResult. |

## Constructors

```csharp
// Using event name with addEventListener/removeEventListener delegates
new FuncEvent<TResult>(string eventName, Action<string, Callback> on, Action<string, Callback>? off)

// Using direct on/off delegates
new FuncEvent<TResult>(Action<Callback> on, Action<Callback>? off)
```

## Operators

| Operator | Description |
|---|---|
| `+=` Func | Subscribe a .NET Func delegate. Auto-creates and ref-counts the Callback. |
| `-=` Func | Unsubscribe a .NET Func delegate. Decrements ref count and removes the listener. |
| `+=` Callback | Subscribe a raw Callback instance. |
| `-=` Callback | Unsubscribe a raw Callback instance. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `On(Func<TResult> listener)` | `void` | Add a listener that returns a value. |
| `Off(Func<TResult> listener)` | `void` | Remove a listener. |
| `On(Func<T1, TResult> listener)` | `void` | Add a typed listener (on FuncEvent&lt;T1, TResult&gt;). |
| `Off(Func<T1, TResult> listener)` | `void` | Remove a typed listener. |

## Example

```csharp
// FuncEvent property on a JSObject wrapper
public FuncEvent<Event, string> OnBeforeUnload
{
    get => new FuncEvent<Event, string>("beforeunload", AddEventListener, RemoveEventListener);
    set { }
}

// Usage
string HandleBeforeUnload(Event e)
{
    return "Are you sure you want to leave?";
}

window.OnBeforeUnload += HandleBeforeUnload;
// ...
window.OnBeforeUnload -= HandleBeforeUnload;
```

## Important Notes

- Same lifecycle rules as ActionEvent: every `+=` must have a matching `-=` before disposal.
- The return value from the Func delegate is marshaled back to JavaScript as the event handler's return value.
- FuncEvent inherits from CallbackEvent just like ActionEvent - the only difference is Func vs Action delegate types.
