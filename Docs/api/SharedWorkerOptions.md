# SharedWorkerOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/SharedWorkerOptions.cs`  
**MDN Reference:** [SharedWorkerOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SharedWorker/SharedWorker#options)

> An object containing option properties that can set when creating the SharedWorker instance. https://developer.mozilla.org/en-US/docs/Web/API/SharedWorker/SharedWorker#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `SharedWorkerOptions` | `class` | get | An object containing option properties that can set when creating the SharedWorker instance. https://developer.mozilla.org/en-US/docs/Web/API/SharedWorker/SharedWorker#options |
| `Credentials` | `string?` | get |  |
| `Name` | `string?` | get |  |
| `SameSiteCookies` | `string?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<SharedWorkerOptions>(...)` or constructor `new SharedWorkerOptions(...)`

### Basic usage

```js
const myWorker = new SharedWorker("worker.js");

myWorker.port.start();

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

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SharedWorker/SharedWorker)*

