# CustomEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** JSObject -> Event -> CustomEvent  
**MDN Reference:** [CustomEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CustomEvent)  
**Source:** `SpawnDev.BlazorJS/JSObjects/DOM/CustomEvent.cs`

> The CustomEvent interface represents events initialized by an application for any purpose. Custom events can carry arbitrary data via the Detail property. SpawnDev.BlazorJS provides both a non-generic and a generic variant for type-safe detail access.

## Constructors

```csharp
// Create with just a type name
public CustomEvent(string type)

// Create with type and options (including Detail data)
public CustomEvent(string type, CustomEventOptions options)

// From existing reference
public CustomEvent(IJSInProcessObjectReference _ref)
```

## Properties

| Property | Type | Description |
|---|---|---|
| `Detail` | `JSObject?` | The custom data passed when the event was created. Returns as JSObject. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `DetailAs<T>()` | `T` | Get the Detail property cast to a specific type. |

## Generic Variant: CustomEvent&lt;TDetail&gt;

```csharp
public class CustomEvent<TDetail> : Event
```

| Property | Type | Description |
|---|---|---|
| `Detail` | `TDetail` | The custom data, strongly typed. |

## CustomEventOptions

```csharp
public class CustomEventOptions
{
    public object? Detail { get; set; }
    public bool Bubbles { get; set; }
    public bool Cancelable { get; set; }
    public bool Composed { get; set; }
}
```

## Example - Dispatching a Custom Event

```csharp
// Create and dispatch
using var evt = new CustomEvent("userAction", new CustomEventOptions
{
    Detail = new { Action = "save", ItemId = 42 },
    Bubbles = true,
    Cancelable = true
});

element.DispatchEvent(evt);
```

## Example - Listening for Custom Events

```csharp
void HandleCustom(CustomEvent e)
{
    using var detail = e.Detail;
    if (detail != null)
    {
        var action = detail.JSRef!.Get<string>("Action");
        var itemId = detail.JSRef!.Get<int>("ItemId");
        Console.WriteLine($"Action: {action}, Item: {itemId}");
    }
}

// Using the typed variant
void HandleTypedCustom(CustomEvent<MyDetailType> e)
{
    var detail = e.Detail; // Already typed as MyDetailType
    Console.WriteLine($"Action: {detail.Action}");
}
```

## Example - Custom Event Communication Between Components

```csharp
// Component A - dispatch event
using var evt = new CustomEvent("dataReady", new CustomEventOptions
{
    Detail = "Data is loaded",
    Bubbles = true
});
JS.CallVoid("document.dispatchEvent", evt);

// Component B - listen for event
void OnDataReady(CustomEvent e)
{
    string message = e.DetailAs<string>();
    Console.WriteLine(message); // "Data is loaded"
}
// Note: Use AddEventListener on the document or a shared EventTarget
```
