# CountQueuingStrategy

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `QueueingStrategy`  
**Source:** `JSObjects/CountQueuingStrategy.cs`  
**MDN Reference:** [CountQueuingStrategy on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CountQueuingStrategy)

> The CountQueuingStrategy interface of the Streams API provides a built-in chunk counting queuing strategy that can be used when constructing streams. https://developer.mozilla.org/en-US/docs/Web/API/CountQueuingStrategy

## Constructors

| Signature | Description |
|---|---|
| `CountQueuingStrategy(CountQueuingStrategyOptions options)` | The CountQueuingStrategy() constructor creates and returns a CountQueuingStrategy object instance. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `HighWaterMark` | `override int` | get | A non-negative integer. This defines the total number of chunks that can be contained in the internal queue before backpressure is applied. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Size(object chunk)` | `int` | Always returns 1. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<CountQueuingStrategy>(...)` or constructor `new CountQueuingStrategy(...)`

```js
const queueingStrategy = new CountQueuingStrategy({ highWaterMark: 1 });

const writableStream = new WritableStream(
  {
    // Implement the sink
    write(chunk) {
      // …
    },
    close() {
      // …
    },
    abort(err) {
      console.log("Sink error:", err);
    },
  },
  queueingStrategy,
);

const size = queueingStrategy.size();
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CountQueuingStrategy)*

