# AsyncIterator

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/AsyncIterator.cs`  
**MDN Reference:** [AsyncIterator on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/AsyncIterator)

> An AsyncIterator object is an object that conforms to the async iterator protocol by providing a next() method that returns a promise fulfilling to an iterator result object. The AsyncIterator.prototype object is a hidden global object that all built-in async iterators inherit from. It provides an @@asyncIterator method that returns the async iterator object itself, making the async iterator also async iterable. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/AsyncIterator

## Constructors

| Signature | Description |
|---|---|
| `AsyncIterator(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `AsyncIterator(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Next()` | `Task<IteratorResult>` | request the next iterator result |
| `ToAsyncEnumerable()` | `IAsyncEnumerable<TValue>` | Returns an IAsyncEnumerable |
| `ToList()` | `Task<List<TValue>>` | Iterates all values and returns them as a List |
| `ToArray()` | `Task<TValue[]>` | Iterates all values and returns them as a .Net Array |

