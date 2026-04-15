# ResizeObserverSize

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/ResizeObserverSize.cs`  
**MDN Reference:** [ResizeObserverSize on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserverEntry/contentBoxSize#value)

> The content box size of the observed element https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserverEntry/contentBoxSize#value

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ResizeObserverSize` | `class` | get | The content box size of the observed element https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserverEntry/contentBoxSize#value |
| `InlineSize` | `double` | get | The length of the observed element's content box in the inline dimension. For boxes with a horizontal writing-mode, this is the horizontal dimension, or width; if the writing-mode is vertical, this is the vertical dimension, or height. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ResizeObserverSize>(...)` or constructor `new ResizeObserverSize(...)`

```js
const resizeObserver = new ResizeObserver((entries) => {
  for (const entry of entries) {
    if (entry.contentBoxSize) {
      // The standard makes contentBoxSize an array...
      if (entry.contentBoxSize[0]) {
        entry.target.style.borderRadius = `${Math.min(
          100,
          entry.contentBoxSize[0].inlineSize / 10 +
            entry.contentBoxSize[0].blockSize / 10,
        )}px`;
      } else {
        // … but old versions of Firefox treat it as a single item
        entry.target.style.borderRadius = `${Math.min(
          100,
          entry.contentBoxSize.inlineSize / 10 +
            entry.contentBoxSize.blockSize / 10,
        )}px`;
      }
    } else {
      entry.target.style.borderRadius = `${Math.min(
        100,
        entry.contentRect.width / 10 + entry.contentRect.height / 10,
      )}px`;
    }
  }
});

resizeObserver.observe(document.querySelector("div"));
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserverEntry/contentBoxSize)*

