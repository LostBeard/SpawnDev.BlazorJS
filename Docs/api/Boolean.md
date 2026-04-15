# Boolean

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Boolean.cs`  
**MDN Reference:** [Boolean on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Boolean)

> The Boolean object represents a truth value: true or false. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Boolean

## Constructors

| Signature | Description |
|---|---|
| `Boolean(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ValueOf()` | `bool` | The valueOf() method of Boolean values returns the primitive value of a Boolean object. |
| `ToString()` | `string` | The toString() method of Boolean values returns a string representing the specified boolean value. |
| `bool(Boolean booleanObj)` | `implicit operator` | Implicit conversion to a .Net bool |

