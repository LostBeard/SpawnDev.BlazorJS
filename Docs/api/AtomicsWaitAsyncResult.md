# AtomicsWaitAsyncResult

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/AtomicsWaitAsyncResult.cs`  
**MDN Reference:** [AtomicsWaitAsyncResult on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Atomics/waitAsync#return_value)

> Result type returned from Atomics.WaitAsync() https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Atomics/waitAsync#return_value

## Constructors

| Signature | Description |
|---|---|
| `AtomicsWaitAsyncResult(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Async` | `bool` | get | A boolean indicating whether the value property is a Promise or not. |
| `ValueString` | `string?` | get | If async is false, it will be a string which is either "not-equal" or "timed-out" (only when the timeout parameter is 0). If async is true, it will be null. |
| `ValueTask` | `Task<string>?` | get | If async is true, it will be a Task which is fulfilled with a string value, either "ok" or "timed-out". The promise is never rejected. If async is false, it will be null. |

