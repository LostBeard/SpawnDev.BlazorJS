# BlobOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/BlobOptions.cs`  
**MDN Reference:** [BlobOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Blob/Blob#options)

> Options used when creating a new Blob https://developer.mozilla.org/en-US/docs/Web/API/Blob/Blob#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BlobOptions` | `class` | get | Options used when creating a new Blob https://developer.mozilla.org/en-US/docs/Web/API/Blob/Blob#options |
| `Endings` | `string?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<BlobOptions>(...)` or constructor `new BlobOptions(...)`

```js
const blobParts = ['<q id="a"><span id="b">hey!</span></q>']; // an array consisting of a single string
const blob = new Blob(blobParts, { type: "text/html" }); // the blob
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Blob/Blob)*

