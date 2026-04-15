# CookieChangeEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/CookieChangeEvent.cs`  
**MDN Reference:** [CookieChangeEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CookieChangeEvent/changed)

> https://developer.mozilla.org/en-US/docs/Web/API/CookieChangeEvent/changed

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Changed` | `Cookie[]` | get | Returns an array containing the changed cookies. |
| `Deleted` | `Cookie[]` | get | Returns an array containing the deleted cookies. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<CookieChangeEvent>(...)` or constructor `new CookieChangeEvent(...)`

```js
cookieStore.addEventListener("change", (event) => {
  console.log(event.changed[0]);
});

const oneDay = 24 * 60 * 60 * 1000;
cookieStore.set({
  name: "cookie1",
  value: "cookie1-value",
  expires: Date.now() + oneDay,
  domain: "example.com",
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CookieChangeEvent/changed)*

