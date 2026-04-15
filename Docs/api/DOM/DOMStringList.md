# DOMStringList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/DOM/DOMStringList.cs`  
**MDN Reference:** [DOMStringList on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DOMStringList)

> The DOMStringList interface is a legacy type returned by some APIs and represents a non-modifiable list of strings (DOMString). Modern APIs use Array objects (in WebIDL: sequence DOMString) instead. https://developer.mozilla.org/en-US/docs/Web/API/DOMStringList

## Constructors

| Signature | Description |
|---|---|
| `DOMStringList(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | Returns the size of the list. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Item(int index)` | `string` | Returns a string from the list with the given index. |
| `Contains(string value)` | `bool` | Returns a boolean indicating whether the given string is in the list. |
| `FirstOrDefault()` | `string?` | Returns first or default |
| `LastOrDefault()` | `string?` | Returns last or default |
| `ToArray()` | `string[]` | Returns the string list as a .Net string array |
| `ToList()` | `List<string>` | Returns the string list as a .Net string List |

