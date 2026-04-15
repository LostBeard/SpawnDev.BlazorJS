# Iterator

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Iterator.cs`  
**MDN Reference:** [Iterator on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Iteration_protocols)

> Iteration protocols aren't new built-ins or syntax, but protocols. These protocols can be implemented by any object by following some conventions. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Iteration_protocols

## Constructors

| Signature | Description |
|---|---|
| `Iterator(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Iterator(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Next()` | `IteratorResult` | Returns the next IteratorResult |
| `ToList()` | `List<TValue>` | Returns all the enumerated results as a List |
| `ToArray()` | `TValue[]` | Returns all the enumerated results as a .Net Array |
| `ToEnumerable()` | `IEnumerable<TValue>` | Returns an IEnumerable&lt;TValue&gt; |

