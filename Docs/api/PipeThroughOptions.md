# PipeThroughOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/PipeThroughOptions.cs`  
**MDN Reference:** [PipeThroughOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ReadableStream/pipeThrough#options)

> Options for the pipeThrough method of the ReadableStream interface. https://developer.mozilla.org/en-US/docs/Web/API/ReadableStream/pipeThrough#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `PipeThroughOptions` | `class` | get/set | Options for the pipeThrough method of the ReadableStream interface. https://developer.mozilla.org/en-US/docs/Web/API/ReadableStream/pipeThrough#options |
| `PreventAbort` | `bool?` | get/set |  |
| `PreventCancel` | `bool?` | get/set |  |
| `Signal` | `AbortSignal?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PipeThroughOptions>(...)` or constructor `new PipeThroughOptions(...)`

```js
// Fetch the original image
fetch("png-logo.png")
  // Retrieve its body as ReadableStream
  .then((response) => response.body)
  .then((rs) => logReadableStream("Fetch Response Stream", rs))
  // Create a gray-scaled PNG stream out of the original
  .then((body) => body.pipeThrough(new PNGTransformStream()))
  .then((rs) => logReadableStream("PNG Chunk Stream", rs));
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ReadableStream/pipeThrough)*

