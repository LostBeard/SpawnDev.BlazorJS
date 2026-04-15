# WorkerOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WorkerOptions.cs`  
**MDN Reference:** [WorkerOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Worker/Worker#options)

> An object containing option properties that can be set when creating the Worker instance. https://developer.mozilla.org/en-US/docs/Web/API/Worker/Worker#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `WorkerOptions` | `class` | get | An object containing option properties that can be set when creating the Worker instance. https://developer.mozilla.org/en-US/docs/Web/API/Worker/Worker#options |
| `Credentials` | `string?` | get |  |
| `Name` | `string?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WorkerOptions>(...)` or constructor `new WorkerOptions(...)`

### Using Trusted Types

```js
if (typeof trustedTypes === "undefined")
  trustedTypes = { createPolicy: (n, rules) => rules };
```

### Using Trusted Types

```js
const workerScriptAllowList = [
  // Some list of allowed URLs
];
const policy = trustedTypes.createPolicy("worker-url-policy", {
  createScriptURL(input) {
    if (workerScriptAllowList.includes(input)) {
      return input; // allow the script
    }
    console.log(`Script not in workerScriptAllowList: ${input}`);
    return ""; // Block the script
  },
});
```

### Using Trusted Types

```js
// The potentially malicious worker URL
// We won't be including untrustedScript in our workerScriptAllowList array
const untrustedScriptURL = "https://evil.example.com/naughty.js";

// Create a TrustedScriptURL instance using the policy
const trustedScriptURL = policy.createScriptURL(untrustedScriptURL);

// Construct the worker with the trusted URL
const myWorker = new Worker(trustedScriptURL);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Worker/Worker)*

