# BarProp

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/BarProp.cs`  
**MDN Reference:** [BarProp on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BarProp)

> The BarProp interface of the Document Object Model represents the web browser user interface elements that are exposed to scripts in web pages. Each of the following interface elements are represented by a BarProp object. https://developer.mozilla.org/en-US/docs/Web/API/BarProp

## Constructors

| Signature | Description |
|---|---|
| `BarProp(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Visible` | `bool` | get | A Boolean, which is true if the bar represented by the used interface element is visible. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<BarProp>(...)` or constructor `new BarProp(...)`

```js
console.log(window.locationbar);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BarProp)*

