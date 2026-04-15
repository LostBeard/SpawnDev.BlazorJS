# DOMRectReadOnly

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/DOM/DOMRectReadOnly.cs`  

> The DOMRectReadOnly interface specifies the standard properties used by DOMRect to define a rectangle whose properties are immutable.

## Constructors

| Signature | Description |
|---|---|
| `DOMRectReadOnly(IJSInProcessObjectReference _ref)` | Creates a new instance of `DOMRectReadOnly`. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Width` | `virtual float` | get | The width of the DOMRect. |
| `Height` | `virtual float` | get | The height of the DOMRect. |
| `Top` | `virtual float` | get | The top coordinate value of the DOMRect (has the same value as y, or y + height if height is negative). |
| `Right` | `virtual float` | get | The right coordinate value of the DOMRect (has the same value as x + width, or x if width is negative). |
| `Bottom` | `virtual float` | get | The bottom coordinate value of the DOMRect (has the same value as y + height, or y if height is negative). |
| `Left` | `virtual float` | get | The left coordinate value of the DOMRect (has the same value as x, or x + width if width is negative). |

