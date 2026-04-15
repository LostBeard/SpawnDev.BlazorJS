# BeforeInstallPromptEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/BeforeInstallPromptEvent.cs`  
**MDN Reference:** [BeforeInstallPromptEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BeforeInstallPromptEvent)

> The BeforeInstallPromptEvent is the interface of the beforeinstallprompt event fired at the Window object before a user is prompted to "install" a website to a home screen on mobile. https://developer.mozilla.org/en-US/docs/Web/API/BeforeInstallPromptEvent Experimental: This is an experimental technology. Check the Browser compatibility table (MDN) carefully before using this in production.

## Constructors

| Signature | Description |
|---|---|
| `BeforeInstallPromptEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Platforms` | `string[]` | get | Returns an array of string items containing the platforms on which the event was dispatched. This is provided for user agents that want to present a choice of versions to the user such as, for example, "web" or "play" which would allow the user to choose between a web version or an Android version. |
| `UserChoice` | `Task<InstallPromptResult>` | get | Returns a Promise that resolves to an object describing the user's choice when they were prompted to install the app. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Prompt()` | `Task<InstallPromptResult>` | Show a prompt asking the user if they want to install the app. This method returns a Promise that resolves to an object describing the user's choice when they were prompted to install the app. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<BeforeInstallPromptEvent>(...)` or constructor `new BeforeInstallPromptEvent(...)`

```js
let installPrompt = null;
const installButton = document.querySelector("#install");

window.addEventListener("beforeinstallprompt", (event) => {
  event.preventDefault();
  installPrompt = event;
  installButton.removeAttribute("hidden");
});
```

```js
installButton.addEventListener("click", async () => {
  if (!installPrompt) {
    return;
  }
  const result = await installPrompt.prompt();
  console.log(`Install prompt was: ${result.outcome}`);
  installPrompt = null;
  installButton.setAttribute("hidden", "");
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BeforeInstallPromptEvent)*

