# ResizeObserver

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/ResizeObserver.cs`  
**MDN Reference:** [ResizeObserver on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserver)

> The ResizeObserver interface reports changes to the dimensions of an Element's content or border box, or the bounding box of an SVGElement. https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserver

## Constructors

| Signature | Description |
|---|---|
| `ResizeObserver(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `ResizeObserver(ActionCallback<ResizeObserverEntry[]> callback)` | Creates and returns a new ResizeObserver object. |
| `ResizeObserver(ActionCallback callback)` | Creates and returns a new ResizeObserver object. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Disconnect()` | `void` | Unobserves all observed Element targets of a particular observer. |
| `Observe(ElementReference target)` | `void` | Initiates the observing of a specified Element. |
| `Observe(Element target, ObserveOptions options)` | `void` | Initiates the observing of a specified Element. |
| `Observe(ElementReference target, ObserveOptions options)` | `void` | Initiates the observing of a specified Element. |
| `Observe(Element target)` | `void` | Initiates the observing of a specified Element. |
| `Unobserve(ElementReference el)` | `void` | Ends the observing of a specified Element. |
| `Unobserve(Element el)` | `void` | Ends the observing of a specified Element. |

## Example

```csharp
// Create a ResizeObserver with a callback that receives entries
using var callback = Callback.Create<ResizeObserverEntry[]>((entries) =>
{
    foreach (var entry in entries)
    {
        using var contentRect = entry.ContentRect;
        Console.WriteLine($"Element resized to {contentRect.Width}x{contentRect.Height}");
        entry.Dispose();
    }
});
using var observer = new ResizeObserver(callback);

// Observe a Blazor ElementReference directly
observer.Observe(containerRef);

// Or observe an Element object
using var el = new HTMLElement(elementRef);
observer.Observe(el);

// Stop observing a specific element
observer.Unobserve(containerRef);

// Stop observing all elements
observer.Disconnect();
```

