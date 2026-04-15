# HashChangeEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/HashChangeEvent.cs`  

> The HashChangeEvent interface represents events that fire when the fragment identifier of the URL has changed.

## Constructors

| Signature | Description |
|---|---|
| `HashChangeEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `NewURL` | `string` | get | The new URL to which the window is navigating. |
| `OldURL` | `string` | get | The previous URL from which the window is navigating. |

