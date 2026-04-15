# Promise<TResult>

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Promise.cs`  
**MDN Reference:** [Promise<TResult> on MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Promise)

> The Promise object represents the eventual completion (or failure) of an asynchronous operation and its resulting value. https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Promise

## Constructors

| Signature | Description |
|---|---|
| `Promise(Func<Task<TResult>> task)` | The Promise() constructor creates Promise objects. |
| `Promise(Task<TResult> task)` | The Promise() constructor creates Promise objects. |
| `Promise(Action<Function, Function> executor)` | The Promise() constructor creates Promise objects. |
| `Promise(Action<Function> executor)` | The Promise() constructor creates Promise objects. |
| `Promise(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `Promise(Func<Task> task)` | The Promise() constructor creates Promise objects. |
| `Promise(Task task)` | The Promise() constructor creates Promise objects. |
| `Promise(Action<Function, Function> executor)` | The Promise() constructor creates Promise objects. |
| `Promise(Action<Function> executor)` | The Promise() constructor creates Promise objects. |
| `Promise(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Then(ActionCallback thenCallback, ActionCallback catchCallback)` | `void` | Set the methods for the Promise onFulfilled and onRejected events |
| `Then(ActionCallback<TResult> thenCallback, ActionCallback catchCallback)` | `void` | Set the methods for the Promise onFulfilled and onRejected events |
| `ThenCatch(ActionCallback<TResult> thenCallback, ActionCallback<TCatch> catchCallback)` | `void` | Set the methods for the Promise onFulfilled and onRejected events |
| `ThenAsync(int timeoutMS)` | `Task<TResult>` | Asynchronously wait for a Promise to complete |
| `ThenAsync(CancellationToken cancellationToken)` | `Task<TResult>` | Asynchronously wait for a Promise to complete |
| `ThenCatch(ActionCallback thenCallback, ActionCallback<TCatch> catchCallback)` | `void` | Set the methods for the Promise onFulfilled and onRejected events |
| `ThenCatchAsync(int timeoutMS)` | `Task` | Asynchronously wait for a Promise to complete |

