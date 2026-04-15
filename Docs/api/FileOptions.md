# FileOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/FileOptions.cs`  
**MDN Reference:** [FileOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/File/File)

> An options object containing optional attributes used when creating a new File https://developer.mozilla.org/en-US/docs/Web/API/File/File

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `FileOptions` | `class` | get | An options object containing optional attributes used when creating a new File https://developer.mozilla.org/en-US/docs/Web/API/File/File |
| `LastModified` | `long?` | get |  |
| `Endings` | `string?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<FileOptions>(...)` or constructor `new FileOptions(...)`

```js
const file = new File(["foo"], "foo.txt", {
  type: "text/plain",
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/File/File)*

