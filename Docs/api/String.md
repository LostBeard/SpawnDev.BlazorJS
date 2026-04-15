# String

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/String.cs`  
**MDN Reference:** [String on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String)

> The String object is used to represent and manipulate a sequence of characters. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String

## Constructors

| Signature | Description |
|---|---|
| `String(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `String(object thing)` | The String() constructor creates String objects. Anything to be converted to a string. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `string(String strObj)` | `implicit operator` | Implicit conversion to .Net string |
| `ValueOf()` | `string` | Returns the primitive value of the specified object. Overrides the Object.prototype.valueOf() method. |
| `ToString()` | `string` | Returns the primitive string as a .Net string |

