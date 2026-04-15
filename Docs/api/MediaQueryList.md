# MediaQueryList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/MediaQueryList.cs`  
**MDN Reference:** [MediaQueryList on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaQueryList)

> A MediaQueryList object stores information on a media query applied to a document, with support for both immediate and event-driven matching against the state of the document. https://developer.mozilla.org/en-US/docs/Web/API/MediaQueryList

## Constructors

| Signature | Description |
|---|---|
| `MediaQueryList(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Matches` | `bool` | get | A boolean value that returns true if the document currently matches the media query list, or false if not. |
| `Media` | `string` | get | A string representing a serialized media query. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnChange` | `ActionEvent<MediaQueryListEvent>` | Sent to the MediaQueryList when the result of running the media query against the document changes. For example, if the media query is (min-width: 400px), the change event is fired any time the width of the document's viewport changes such that its width moves across the 400px boundary in either direction. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<MediaQueryList>(...)` or constructor `new MediaQueryList(...)`

```js
const para = document.querySelector("p");
const mql = window.matchMedia("(width <= 600px)");

function screenTest(e) {
  if (e.matches) {
    /* the viewport is 600 pixels wide or less */
    para.textContent = "This is a narrow screen — less than 600px wide.";
    document.body.style.backgroundColor = "red";
  } else {
    /* the viewport is more than 600 pixels wide */
    para.textContent = "This is a wide screen — more than 600px wide.";
    document.body.style.backgroundColor = "blue";
  }
}

mql.addEventListener("change", screenTest);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaQueryList)*

