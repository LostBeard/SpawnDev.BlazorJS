# FocusEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `UIEvent`  
**Source:** `JSObjects/FocusEvent.cs`  
**MDN Reference:** [FocusEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FocusEvent)

> The FocusEvent interface represents focus-related events, including focus, blur, focusin, and focusout. https://developer.mozilla.org/en-US/docs/Web/API/FocusEvent

## Constructors

| Signature | Description |
|---|---|
| `FocusEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `RelatedTarget` | `EventTarget?` | get | An EventTarget representing a secondary target for this event. In some cases (such as when tabbing in or out a page), this property may be set to null for security reasons. |

