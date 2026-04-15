# IconInfo

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/IconInfo.cs`  
**MDN Reference:** [IconInfo on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchUpdateUIEvent/updateUI#icons)

> https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchUpdateUIEvent/updateUI#icons https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchManager/fetch#icons

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `IconInfo` | `class` | get | https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchUpdateUIEvent/updateUI#icons https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchManager/fetch#icons |
| `Sizes` | `string?` | get |  |
| `Type` | `string?` | get |  |
| `Label` | `string?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<IconInfo>(...)` or constructor `new IconInfo(...)`

```js
addEventListener("backgroundfetchsuccess", (event) => {
  event.updateUI({
    title: "Episode 5 ready to listen!",
    icon: {
      src: "path/to/success.ico",
      sizes: "16x16 32x32 64x64",
    },
  });
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchUpdateUIEvent/updateUI)*

