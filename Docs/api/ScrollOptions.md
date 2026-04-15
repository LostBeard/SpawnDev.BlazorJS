# ScrollOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/ScrollOptions.cs`  
**MDN Reference:** [ScrollOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Window/scroll#options)

> Window.Scroll() options https://developer.mozilla.org/en-US/docs/Web/API/Window/scroll#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ScrollOptions` | `class` | get | Window.Scroll() options https://developer.mozilla.org/en-US/docs/Web/API/Window/scroll#options |
| `Left` | `int?` | get |  |
| `Behavior` | `string?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ScrollOptions>(...)` or constructor `new ScrollOptions(...)`

```js
// Put the 100th vertical pixel at the top of the window
window.scroll(0, 100);
```

```js
window.scroll({
  top: 100,
  left: 100,
  behavior: "smooth",
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Window/scroll)*

