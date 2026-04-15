# VisualViewport

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/VisualViewport.cs`  
**MDN Reference:** [VisualViewport on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VisualViewport)

> The VisualViewport interface of the Visual Viewport API represents the visual viewport for a given window. For a page containing iframes, each iframe, as well as the containing page, will have a unique window object. Each window on a page will have a unique VisualViewport representing the properties associated with that window. https://developer.mozilla.org/en-US/docs/Web/API/VisualViewport

## Constructors

| Signature | Description |
|---|---|
| `VisualViewport(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Height` | `float` | get | Returns the height of the visual viewport in CSS pixels. |
| `OffsetLeft` | `float` | get | Returns the offset of the left edge of the visual viewport from the left edge of the layout viewport in CSS pixels. |
| `OffsetTop` | `float` | get | Returns the offset of the top edge of the visual viewport from the top edge of the layout viewport in CSS pixels. |
| `PageLeft` | `float` | get | Returns the x coordinate of the visual viewport relative to the initial containing block origin of the top edge in CSS pixels. |
| `PageTop` | `float` | get | Returns the y coordinate of the visual viewport relative to the initial containing block origin of the top edge in CSS pixels. |
| `Scale` | `float` | get | Returns the pinch-zoom scaling factor applied to the visual viewport. |
| `Width` | `float` | get | Returns the width of the visual viewport in CSS pixels. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnResize` | `ActionEvent<Event>` | Fired when the visual viewport is resized. Also available via the onresize property. |
| `OnScroll` | `ActionEvent<Event>` | Fired when the visual viewport is scrolled. Also available via the onscroll property. |

