# DOMRect

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** JSObject -> DOMRectReadOnly -> DOMRect  
**MDN Reference:** [DOMRect on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DOMRect)  
**Source:** `SpawnDev.BlazorJS/JSObjects/DOM/DOMRect.cs`

> DOMRect describes the size and position of a rectangle. Unlike its read-only parent DOMRectReadOnly, DOMRect properties can be modified. DOMRect is commonly returned by methods like Element.getBoundingClientRect() and is used throughout the DOM for geometry calculations.

## Constructor

```csharp
// Create with explicit coordinates
public DOMRect(float x, float y, float width, float height)

// From existing reference
public DOMRect(IJSInProcessObjectReference _ref)
```

## Properties

All properties are read/write on DOMRect (read-only on DOMRectReadOnly):

| Property | Type | Description |
|---|---|---|
| `X` | `float` | The x coordinate of the origin (typically top-left). |
| `Y` | `float` | The y coordinate of the origin (typically top-left). |
| `Width` | `float` | The width of the rectangle. |
| `Height` | `float` | The height of the rectangle. |
| `Top` | `float` | The top edge (y, or y + height if height is negative). |
| `Right` | `float` | The right edge (x + width, or x if width is negative). |
| `Bottom` | `float` | The bottom edge (y + height, or y if height is negative). |
| `Left` | `float` | The left edge (x, or x + width if width is negative). |

## Example

```csharp
using var element = doc.QuerySelector<Element>("#target");
using var rect = element!.GetBoundingClientRect();

Console.WriteLine($"Position: ({rect.X}, {rect.Y})");
Console.WriteLine($"Size: {rect.Width} x {rect.Height}");
Console.WriteLine($"Bounds: top={rect.Top}, right={rect.Right}, bottom={rect.Bottom}, left={rect.Left}");

// Check if a point is inside the rectangle
bool isInside = mouseX >= rect.Left && mouseX <= rect.Right
             && mouseY >= rect.Top && mouseY <= rect.Bottom;

// Create a DOMRect
using var customRect = new DOMRect(10, 20, 300, 200);
```
