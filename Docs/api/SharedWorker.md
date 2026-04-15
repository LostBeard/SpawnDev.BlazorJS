# SharedWorker

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/SharedWorker.cs`  
**MDN Reference:** [SharedWorker on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SharedWorker)

> The SharedWorker interface represents a specific kind of worker that can be accessed from several browsing contexts, such as several windows, iframes or even workers. They implement an interface different than dedicated workers and have a different global scope, SharedWorkerGlobalScope. https://developer.mozilla.org/en-US/docs/Web/API/SharedWorker

## Constructors

| Signature | Description |
|---|---|
| `SharedWorker(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `SharedWorker(string url)` | The SharedWorker() constructor creates a SharedWorker object that executes the script at the specified URL. This script must obey the same-origin policy. A string representing the URL of the script the worker will execute. It must obey the same-origin policy. |
| `SharedWorker(string url, string name)` | The SharedWorker() constructor creates a SharedWorker object that executes the script at the specified URL. This script must obey the same-origin policy. A string representing the URL of the script the worker will execute. It must obey the same-origin policy. A string specifying an identifying name for the SharedWorkerGlobalScope representing the scope of the worker, which is useful for creating new instances of the same SharedWorker and debugging. |
| `SharedWorker(string url, SharedWorkerOptions options)` | A string representing the URL of the script the worker will execute. It must obey the same-origin policy. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Port` | `MessagePort` | get | Returns a MessagePort object used to communicate with and control the shared worker. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnError` | `ActionEvent<Event>` | Fires when an error occurs in the shared worker. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<SharedWorker>(...)` or constructor `new SharedWorker(...)`

```js
const myWorker = new SharedWorker("worker.js");
```

```js
myWorker.port.start();
```

```js
[first, second].forEach((input) => {
  input.onchange = () => {
    myWorker.port.postMessage([first.value, second.value]);
    console.log("Message posted to worker");
  };
});

myWorker.port.onmessage = (e) => {
  result1.textContent = e.data;
  console.log("Message received from worker");
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SharedWorker)*

