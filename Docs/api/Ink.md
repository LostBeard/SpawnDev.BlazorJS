# Ink

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Ink.cs`  
**MDN Reference:** [Ink on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Ink)

> The Ink interface of the Ink API provides access to InkPresenter objects for the application to use to render ink strokes. https://developer.mozilla.org/en-US/docs/Web/API/Ink

## Constructors

| Signature | Description |
|---|---|
| `Ink(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RequestPresenter(InkPresenterParam param)` | `Task<InkPresenter>` | The requestPresenter() method of the Ink interface returns a Promise that fulfills with an InkPresenter object. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<Ink>(...)` or constructor `new Ink(...)`

```js
async function inkInit() {
  const ink = navigator.ink;
  let presenter = await ink.requestPresenter({ presentationArea: canvas });

  // …
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Ink)*

