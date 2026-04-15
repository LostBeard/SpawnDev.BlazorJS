# IntersectionObserverEntry

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/IntersectionObserver/IntersectionObserverEntry.cs`  
**MDN Reference:** [IntersectionObserverEntry on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IntersectionObserverEntry)

> The IntersectionObserverEntry interface of the Intersection Observer API describes the intersection between the target element and its root container at a specific moment of transition. https://developer.mozilla.org/en-US/docs/Web/API/IntersectionObserverEntry

## Constructors

| Signature | Description |
|---|---|
| `IntersectionObserverEntry(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BoundingClientRect` | `DOMRectReadOnly` | get | Returns the bounds of the target element as a DOMRectReadOnly. The bounds are computed as described in the documentation for Element.getBoundingClientRect(). |
| `IntersectionRatio` | `double` | get | Returns the ratio of the intersectionRect to the boundingClientRect. |
| `IntersectionRect` | `DOMRectReadOnly` | get | Returns a DOMRectReadOnly representing the target's visible area. |
| `IsIntersecting` | `bool` | get | A Boolean value which is true if the target element intersects with the intersection observer's root. If this is true, then, the IntersectionObserverEntry describes a transition into a state of intersection; if it's false, then you know the transition is from intersecting to not-intersecting. |
| `RootBounds` | `DOMRectReadOnly?` | get | Returns a DOMRectReadOnly for the intersection observer's root. |
| `Target` | `Element` | get | The Element whose intersection with the root is being observed. |
| `Time` | `double` | get | A DOMHighResTimeStamp indicating the time at which the intersection was recorded, relative to the IntersectionObserver's time origin. |

