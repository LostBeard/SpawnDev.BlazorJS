# ServiceWorkerRegistrationOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/ServiceWorkerRegistrationOptions.cs`  
**MDN Reference:** [ServiceWorkerRegistrationOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerContainer/register#options)

> Options used when registering a ServiceWorker via ServiceWorkerContainer.Register() https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerContainer/register#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ServiceWorkerRegistrationOptions` | `class` | get | Options used when registering a ServiceWorker via ServiceWorkerContainer.Register() https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerContainer/register#options |
| `Type` | `string?` | get |  |
| `UpdateViaCache` | `string?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ServiceWorkerRegistrationOptions>(...)` or constructor `new ServiceWorkerRegistrationOptions(...)`

### Using TrustedScriptURL

```js
if (typeof trustedTypes === "undefined")
  trustedTypes = { createPolicy: (n, rules) => rules };
```

### Using TrustedScriptURL

```js
const scriptAllowList = [
  // Some list of allowed URLs
];
const policy = trustedTypes.createPolicy("script-url-policy", {
  createScriptURL(input) {
    if (scriptAllowList.includes(input)) {
      return input; // allow the script
    }
    console.log(`Script not in scriptAllowList: ${input}`);
    return ""; // Block the script
  },
});
```

### Using TrustedScriptURL

```js
// The potentially malicious string
// We won't be including untrustedScript in our scriptAllowList array
const untrustedScript = "https://evil.example.com/service_worker.js";

// Create a TrustedScriptURL instance using the policy
const trustedScriptURL = policy.createScriptURL(untrustedScript);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerContainer/register)*

