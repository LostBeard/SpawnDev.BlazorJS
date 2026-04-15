# ByteLengthQueuingStrategyOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/ByteLengthQueuingStrategyOptions.cs`  
**MDN Reference:** [ByteLengthQueuingStrategyOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ByteLengthQueuingStrategy/ByteLengthQueuingStrategy#options)

> https://developer.mozilla.org/en-US/docs/Web/API/ByteLengthQueuingStrategy/ByteLengthQueuingStrategy#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ByteLengthQueuingStrategyOptions` | `class` | get | https://developer.mozilla.org/en-US/docs/Web/API/ByteLengthQueuingStrategy/ByteLengthQueuingStrategy#options |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ByteLengthQueuingStrategyOptions>(...)` or constructor `new ByteLengthQueuingStrategyOptions(...)`

```js
const queuingStrategy = new ByteLengthQueuingStrategy({
  highWaterMark: 1 * 1024,
});

const readableStream = new ReadableStream(
  {
    start(controller) {
      // …
    },
    pull(controller) {
      // …
    },
    cancel(err) {
      console.log("stream error:", err);
    },
  },
  queuingStrategy,
);

const size = queuingStrategy.size(chunk);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ByteLengthQueuingStrategy/ByteLengthQueuingStrategy)*

