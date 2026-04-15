# ClipboardEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/ClipboardEvent.cs`  
**MDN Reference:** [ClipboardEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ClipboardEvent)

> The ClipboardEvent interface of the Clipboard API represents events providing information related to modification of the clipboard, that is cut, copy, and paste events. https://developer.mozilla.org/en-US/docs/Web/API/ClipboardEvent

## Constructors

| Signature | Description |
|---|---|
| `ClipboardEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ClipboardData` | `DataTransfer` | get | A DataTransfer object containing the data affected by the user-initiated cut, copy, or paste operation, along with its MIME type. |

