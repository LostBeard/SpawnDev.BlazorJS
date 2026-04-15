# ResizeObserverEntry

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/ResizeObserverEntry.cs`  
**MDN Reference:** [ResizeObserverEntry on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserverEntry)

> The ResizeObserverEntry interface represents the object passed to the ResizeObserver() constructor's callback function, which allows you to access the new dimensions of the Element or SVGElement being observed. https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserverEntry

## Constructors

| Signature | Description |
|---|---|
| `ResizeObserverEntry(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BorderBoxSize` | `List<ResizeObserverSize>` | get | An array of objects containing the new border box size of the observed element when the callback is run. |
| `ContentBoxSize` | `List<ResizeObserverSize>` | get | An array of objects containing the new content box size of the observed element when the callback is run. |
| `DevicePixelContentBoxSize` | `List<ResizeObserverSize>` | get | An array of objects containing the new content box size in device pixels of the observed element when the callback is run. |
| `ContentRect` | `DOMRectReadOnly` | get | A DOMRectReadOnly object containing the new size of the observed element when the callback is run. Note that this is now a legacy property that is retained in the spec for backward-compatibility reasons only. |
| `Target` | `Element` | get | A reference to the Element or SVGElement being observed. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ResizeObserverEntry>(...)` or constructor `new ResizeObserverEntry(...)`

```js
const resizeObserver = new ResizeObserver((entries) => {
  for (const entry of entries) {
    if (entry.contentBoxSize) {
      // The standard makes contentBoxSize an array...
      if (entry.contentBoxSize[0]) {
        h1Elem.style.fontSize = `${Math.max(1.5, entry.contentBoxSize[0].inlineSize / 200)}rem`;
        pElem.style.fontSize = `${Math.max(1, entry.contentBoxSize[0].inlineSize / 600)}rem`;
      } else {
        // … but old versions of Firefox treat it as a single item
        h1Elem.style.fontSize = `${Math.max(1.5, entry.contentBoxSize.inlineSize / 200)}rem`;
        pElem.style.fontSize = `${Math.max(1, entry.contentBoxSize.inlineSize / 600)}rem`;
      }
    } else {
      h1Elem.style.fontSize = `${Math.max(1.5, entry.contentRect.width / 200)}rem`;
      pElem.style.fontSize = `${Math.max(1, entry.contentRect.width / 600)}rem`;
    }
  }
  console.log("Size changed");
});

resizeObserver.observe(divElem);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserverEntry)*

