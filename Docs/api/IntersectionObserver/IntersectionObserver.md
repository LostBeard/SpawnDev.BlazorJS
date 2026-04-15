# IntersectionObserver

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/IntersectionObserver/IntersectionObserver.cs`  
**MDN Reference:** [IntersectionObserver on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IntersectionObserver)

> The IntersectionObserver interface of the Intersection Observer API provides a way to asynchronously observe changes in the intersection of a target element with an ancestor element or with a top-level document's viewport. https://developer.mozilla.org/en-US/docs/Web/API/IntersectionObserver

## Constructors

| Signature | Description |
|---|---|
| `IntersectionObserver(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `IntersectionObserver(Action<IntersectionObserverEntry[], IntersectionObserver> callback, IntersectionObserverInit? options)` | Creates a new IntersectionObserver object which will invoke a specified callback function when it detects that the intersection ratio of the target element vs the root exceeds one of the thresholds. A function which is called when the percentage of the target element is visible crosses a threshold. The callback receives as input two parameters: entries: An array of IntersectionObserverEntry objects, each representing one threshold which was crossed, either becoming more or less visible than the percentage specified by that threshold. observer: The IntersectionObserver object itself. An optional object which customizes the observer. If options isn't specified, the observer uses the document's viewport as the root, with no margin, and a 0% threshold (meaning that even a one-pixel change is enough to trigger a callback). |
| `IntersectionObserver(ActionCallback<IntersectionObserverEntry[], IntersectionObserver> callback, IntersectionObserverInit? options)` | Creates a new IntersectionObserver object which will invoke a specified callback function when it detects that the intersection ratio of the target element vs the root exceeds one of the thresholds. A function which is called when the percentage of the target element is visible crosses a threshold. The callback receives as input two parameters: entries: An array of IntersectionObserverEntry objects, each representing one threshold which was crossed, either becoming more or less visible than the percentage specified by that threshold. observer: The IntersectionObserver object itself. An optional object which customizes the observer. If options isn't specified, the observer uses the document's viewport as the root, with no margin, and a 0% threshold (meaning that even a one-pixel change is enough to trigger a callback). |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Root` | `Element?` | get | The Element or Document whose bounds are used as the bounding box when testing for intersection. If no root is passed to the constructor or its value is null, the top-level document's viewport is used. |
| `RootMargin` | `string` | get | A string, similar to the CSS margin property, setting the offsets to apply to the root's bounding_box when calculating intersections. |
| `Thresholds` | `double[]` | get | A list of thresholds, sorted in increasing numeric order, where each threshold is a ratio of intersection area to bounding box area of an observed target. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Disconnect()` | `void` | Stops the IntersectionObserver object from observing any target. |
| `Observe(Element target)` | `void` | Tells the IntersectionObserver a target element to observe. The Element to be observed. |
| `TakeRecords()` | `IntersectionObserverEntry[]` | Returns an array of IntersectionObserverEntry objects for all observed targets. |
| `Unobserve(Element target)` | `void` | Tells the IntersectionObserver to stop observing a particular target element. The Element to stop observing. |

## Example

```csharp
// Create an IntersectionObserver using the Action overload
using var observer = new IntersectionObserver(
    (entries, obs) =>
    {
        foreach (var entry in entries)
        {
            if (entry.IsIntersecting)
            {
                Console.WriteLine($"Element is visible ({entry.IntersectionRatio * 100:F0}%)");
                // Optionally stop observing once visible
                // obs.Unobserve(entry.Target);
            }
            entry.Dispose();
        }
    },
    new IntersectionObserverInit
    {
        Threshold = new double[] { 0, 0.25, 0.5, 0.75, 1.0 },
        RootMargin = "0px"
    }
);

// Observe an element
using var document = JS.Get<Document>("document");
using var target = document.QuerySelector<Element>(".lazy-load-section");
if (target != null)
{
    observer.Observe(target);
}

// Read observer properties
string rootMargin = observer.RootMargin;
double[] thresholds = observer.Thresholds;

// Stop observing a specific element
observer.Unobserve(target);

// Stop observing all elements
observer.Disconnect();
```

