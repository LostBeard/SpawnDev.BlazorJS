# TouchList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/TouchList.cs`  
**MDN Reference:** [TouchList on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TouchList)

> The TouchList interface represents a list of contact points on a touch surface. For example, if the user has three fingers on the touch surface (such as a screen or trackpad), the corresponding TouchList object would have one Touch object for each finger, for a total of three entries. https://developer.mozilla.org/en-US/docs/Web/API/TouchList

## Constructors

| Signature | Description |
|---|---|
| `TouchList(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | The number of Touch objects in the TouchList. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Items(int i)` | `Touch` | Returns the Touch object at the specified index in the list. |

