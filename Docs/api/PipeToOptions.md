# PipeToOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/PipeToOptions.cs`  
**MDN Reference:** [PipeToOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ReadableStream/pipeTo#options)

> ReadableStream pipTo options https://developer.mozilla.org/en-US/docs/Web/API/ReadableStream/pipeTo#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `PipeToOptions` | `class` | get/set | ReadableStream pipTo options https://developer.mozilla.org/en-US/docs/Web/API/ReadableStream/pipeTo#options |
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
> - Access via `JS.Get<PipeToOptions>(...)` or constructor `new PipeToOptions(...)`

```js
// Fetch the original image
fetch("png-logo.png")
  // Retrieve its body as ReadableStream
  .then((response) => response.body)
  .then((body) => body.pipeThrough(new PNGTransformStream()))
  .then((rs) => rs.pipeTo(new FinalDestinationStream()));
```

```js
(async () => {
  // Fetch the original image
  const response = await fetch("png-logo.png");
  // Retrieve its body as ReadableStream
  await response.body
    .pipeThrough(new PNGTransformStream())
    .pipeTo(new FinalDestinationStream());
})();
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ReadableStream/pipeTo)*

