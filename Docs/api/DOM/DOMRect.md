# DOMRect

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `DOMRectReadOnly`  
**Source:** `JSObjects/DOM/DOMRect.cs`  
**MDN Reference:** [DOMRect on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DOMRect)

> A DOMRect describes the size and position of a rectangle. The type of box represented by the DOMRect is specified by the method or property that returned it. For example, Range.getBoundingClientRect() specifies the rectangle that bounds the content of the range using such objects. https://developer.mozilla.org/en-US/docs/Web/API/DOMRect

## Constructors

| Signature | Description |
|---|---|
| `DOMRect(float x, float y, float width, float height)` | The DOMRect() constructor creates a new DOMRect object. |
| `DOMRect(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Width` | `override float` | get | The width of the DOMRect. |
| `Height` | `override float` | get | The height of the DOMRect. |
| `Top` | `override float` | get | Returns the top coordinate value of the DOMRect (has the same value as y, or y + height if height is negative). |
| `Right` | `override float` | get | Returns the right coordinate value of the DOMRect (has the same value as x + width, or x if width is negative). |
| `Bottom` | `override float` | get | Returns the bottom coordinate value of the DOMRect (has the same value as y + height, or y if height is negative). |
| `Left` | `override float` | get | Returns the left coordinate value of the DOMRect (has the same value as x, or x + width if width is negative). |

