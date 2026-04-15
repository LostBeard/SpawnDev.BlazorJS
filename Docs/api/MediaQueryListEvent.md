# MediaQueryListEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/MediaQueryListEvent.cs`  

> The MediaQueryListEvent object stores information on the changes that have occurred to a MediaQueryList object.

## Constructors

| Signature | Description |
|---|---|
| `MediaQueryListEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Matches` | `bool` | get | A boolean value that returns true if the document currently matches the media query list, or false if not. |
| `Media` | `string` | get | A string representing the serialized media query. |

