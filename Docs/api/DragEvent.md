# DragEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `MouseEvent`  
**Source:** `JSObjects/DragEvent.cs`  
**MDN Reference:** [DragEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DragEvent)

> The DragEvent interface is a DOM event that represents a drag and drop interaction. The user initiates a drag by placing a pointer device (such as a mouse) on the touch surface and then dragging the pointer to a new location (such as another DOM element). Applications are free to interpret a drag and drop interaction in an application-specific way. https://developer.mozilla.org/en-US/docs/Web/API/DragEvent

## Constructors

| Signature | Description |
|---|---|
| `DragEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `DataTransfer` | `DataTransfer` | get | The data that is transferred during a drag and drop interaction. |

