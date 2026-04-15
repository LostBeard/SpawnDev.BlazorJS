# CallbackGroup

**Namespace:** `SpawnDev.BlazorJS`  
**Implements:** `IDisposable`  
**Source:** `SpawnDev.BlazorJS/CallbackGroup.cs`

> CallbackGroup is a batch disposal container for Callback instances. It collects multiple Callbacks and disposes them all at once when the group is cleared or disposed. This is useful when registering multiple event listeners or callbacks that share the same lifecycle.

## Properties

| Property | Type | Description |
|---|---|---|
| `Callbacks` | `List<Callback>` | The list of Callbacks tracked by this group. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Add<T>(T wrapper)` | `T` | Add a Callback to the group and return it. T must be a Callback subclass. |
| `Clear()` | `void` | Dispose all Callbacks in the group and clear the list. |
| `Dispose()` | `void` | Dispose all Callbacks in the group (calls Clear). |

## Example - Managing Multiple Callbacks

```csharp
using var group = new CallbackGroup();

// Create callbacks and automatically add them to the group
var onOpen = Callback.Create(() => Console.WriteLine("Connected"), group);
var onMessage = Callback.Create<MessageEvent>(msg =>
{
    Console.WriteLine($"Received: {msg.Data}");
}, group);
var onClose = Callback.Create(() => Console.WriteLine("Disconnected"), group);
var onError = Callback.Create<Event>(e => Console.WriteLine("Error!"), group);

webSocket.JSRef!.CallVoid("addEventListener", "open", onOpen);
webSocket.JSRef!.CallVoid("addEventListener", "message", onMessage);
webSocket.JSRef!.CallVoid("addEventListener", "close", onClose);
webSocket.JSRef!.CallVoid("addEventListener", "error", onError);

// When done, one Dispose() cleans up all 4 callbacks
// group.Dispose() is called automatically by the using statement
```

## Example - Inline with Callback.Create

```csharp
var group = new CallbackGroup();

// The CallbackGroup parameter on Create() auto-adds to the group
Callback.Create<string>(name => ProcessName(name), group);
Callback.Create<int, int, int>((a, b, c) => Calculate(a, b, c), group);

// Later...
group.Clear(); // Dispose all and clear, but group is still usable
// Can add more callbacks...

group.Dispose(); // Final cleanup
```
