# ByteLengthQueuingStrategy

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `QueueingStrategy`  
**Source:** `JSObjects/ByteLengthQueuingStrategy.cs`  
**MDN Reference:** [ByteLengthQueuingStrategy on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ByteLengthQueuingStrategy)

> https://developer.mozilla.org/en-US/docs/Web/API/ByteLengthQueuingStrategy

## Constructors

| Signature | Description |
|---|---|
| `ByteLengthQueuingStrategy(ByteLengthQueuingStrategyOptions options)` | The ByteLengthQueuingStrategy() constructor creates and returns a ByteLengthQueuingStrategy object instance. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `HighWaterMark` | `override int` | get | A non-negative integer. This defines the total number of chunks that can be contained in the internal queue before backpressure is applied. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Size(object chunk)` | `int` | The size() method of the ByteLengthQueuingStrategy interface returns the given chunk's byteLength property. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ByteLengthQueuingStrategy>(...)` or constructor `new ByteLengthQueuingStrategy(...)`

```js
const queueingStrategy = new ByteLengthQueuingStrategy({ highWaterMark: 1024 });

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
  queueingStrategy,
);

const size = queueingStrategy.size(chunk);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ByteLengthQueuingStrategy)*

