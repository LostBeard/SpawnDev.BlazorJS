# IteratorResult

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/IteratorResult.cs`  

> Returned from an Iterator or AsyncIterator Next call

## Constructors

| Signature | Description |
|---|---|
| `IteratorResult(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `IteratorResult(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Done` | `bool` | get | A boolean that's false if the iterator was able to produce the next value in the sequence. (This is equivalent to not specifying the done property altogether.) Has the value true if the iterator has completed its sequence. In this case, value optionally specifies the return value of the iterator. |
| `Value` | `TValue` | get | Any JavaScript value returned by the iterator. Can be omitted when done is true. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetValue()` | `T` | Any JavaScript value returned by the iterator. Can be omitted when done is true. |

