# TouchEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `UIEvent`  
**Source:** `JSObjects/TouchEvent.cs`  
**MDN Reference:** [TouchEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TouchEvent)

> The TouchEvent interface represents an UIEvent which is sent when the state of contacts with a touch-sensitive surface changes. This surface can be a touch screen or trackpad, for example. The event can describe one or more points of contact with the screen and includes support for detecting movement, addition and removal of contact points, and so forth. https://developer.mozilla.org/en-US/docs/Web/API/TouchEvent

## Constructors

| Signature | Description |
|---|---|
| `TouchEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AltKey` | `bool` | get | Returns a boolean value that is true if the Alt (Option or ⌥ on macOS) key was active when the key event was generated. |
| `CtrlKey` | `bool` | get | Returns a boolean value that is true if the Ctrl key was active when the key event was generated. |
| `MetaKey` | `bool` | get | Returns a boolean value that is true if the Meta key (on Mac keyboards, the ⌘ Command key; on Windows keyboards, the Windows key (⊞)) was active when the key event was generated. |
| `ShiftKey` | `bool` | get | Returns a boolean value that is true if the Shift key was active when the key event was generated. |
| `ChangedTouches` | `TouchList` | get | A TouchList of all the Touch objects representing individual points of contact whose states changed between the previous touch event and this one. |
| `TargetTouches` | `TouchList` | get | A TouchList of all the Touch objects that are both currently in contact with the touch surface and were also started on the same element that is the target of the event. |
| `Touches` | `TouchList` | get | A TouchList of all the Touch objects representing all current points of contact with the surface, regardless of target or changed status. |

