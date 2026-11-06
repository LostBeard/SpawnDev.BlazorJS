# ObserveOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/ObserveOptions.cs`  
**MDN Reference:** [ObserveOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserver/observe#options)

> An options object allowing you to set options for the observation. https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserver/observe#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ObserveOptions` | `class` | get | An options object allowing you to set options for the observation. https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserver/observe#options |
| `Box` | `string?` | get/set | Sets which box model the observer will observe changes to. Possible values are: "content-box" - Size of the content area as defined in CSS. (default) "border-box" - Size of the box border area as defined in CSS. "device-pixel-content-box" - The size of the content area as defined in CSS, in device pixels, before applying any CSS transforms on the element or its ancestors. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ObserveOptions>(...)` or constructor `new ObserveOptions(...)`

```js
const resizeObserver = new ResizeObserver((entries) => {
  for (const entry of entries) {
    if (entry.contentBoxSize) {
      // Checking for chrome as using a non-standard array
      if (entry.contentBoxSize[0]) {
        h1Elem.style.fontSize = `${Math.max(
          1.5,
          entry.contentBoxSize[0].inlineSize / 200,
        )}rem`;
        pElem.style.fontSize = `${Math.max(
          1,
          entry.contentBoxSize[0].inlineSize / 600,
        )}rem`;
      } else {
        h1Elem.style.fontSize = `${Math.max(
          1.5,
          entry.contentBoxSize.inlineSize / 200,
        )}rem`;
        pElem.style.fontSize = `${Math.max(
          1,
          entry.contentBoxSize.inlineSize / 600,
        )}rem`;
      }
    } else {
      h1Elem.style.fontSize = `${Math.max(
        1.5,
        entry.contentRect.width / 200,
      )}rem`;
      pElem.style.fontSize = `${Math.max(1, entry.contentRect.width / 600)}rem`;
    }
  }
  console.log("Size changed");
});

resizeObserver.observe(divElem);
```

```js
resizeObserver.observe(divElem, { box: "border-box" });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserver/observe)*

