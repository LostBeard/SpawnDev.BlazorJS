# StyleSheet

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/StyleSheet.cs`  
**MDN Reference:** [StyleSheet on MDN](https://developer.mozilla.org/en-US/docs/Web/API/StyleSheet)

> An object implementing the StyleSheet interface represents a single style sheet. CSS style sheets will further implement the more specialized CSSStyleSheet interface. https://developer.mozilla.org/en-US/docs/Web/API/StyleSheet

## Constructors

| Signature | Description |
|---|---|
| `StyleSheet(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Disabled` | `bool` | get | Returns a Boolean flag indicating whether the stylesheet is disabled or not. |
| `Href` | `string` | get | Returns the URL of the stylesheet. |
| `Media` | `MediaList` | get | Returns the media attribute of the stylesheet. |
| `OwnerNode` | `Node` | get | Returns the owner node of the stylesheet. |
| `ParentStyleSheet` | `StyleSheet?` | get | Returns the parent stylesheet, if any. |
| `Type` | `string` | get | Returns the type of the stylesheet, such as "text/css". |
| `Title` | `string` | get | Returns the title of the stylesheet. |

