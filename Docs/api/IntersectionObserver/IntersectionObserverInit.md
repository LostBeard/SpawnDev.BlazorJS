# IntersectionObserverInit

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/IntersectionObserver/IntersectionObserverInit.cs`  
**MDN Reference:** [IntersectionObserverInit on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IntersectionObserver/IntersectionObserver#options)

> Options utilized when creating a new IntersectionObserver. https://developer.mozilla.org/en-US/docs/Web/API/IntersectionObserver/IntersectionObserver#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `IntersectionObserverInit` | `class` | get/set | Options utilized when creating a new IntersectionObserver. https://developer.mozilla.org/en-US/docs/Web/API/IntersectionObserver/IntersectionObserver#options |
| `RootMargin` | `string?` | get |  |
| `Threshold` | `Union<double, double[]>?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<IntersectionObserverInit>(...)` or constructor `new IntersectionObserverInit(...)`

```js
let observer = new IntersectionObserver(myObserverCallback, { threshold: 0.1 });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/IntersectionObserver/IntersectionObserver)*

