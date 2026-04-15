# ContentIndexEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ExtendableEvent`  
**Source:** `JSObjects/ContentIndexEvent.cs`  
**MDN Reference:** [ContentIndexEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerGlobalScope/contentdelete_event)

> The contentdelete event of the ServiceWorkerGlobalScope interface is fired when an item is removed from the indexed content via the user agent. This event is not cancelable and does not bubble. https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerGlobalScope/contentdelete_event

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Id` | `string` | get | A string which identifies the deleted content index via it's id. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ContentIndexEvent>(...)` or constructor `new ContentIndexEvent(...)`

```js
self.addEventListener("contentdelete", (event) => {
  const deletion = caches
    .open("cache-name")
    .then((cache) =>
      Promise.all([
        cache.delete(`/icon/${event.id}`),
        cache.delete(`/content/${event.id}`),
      ]),
    );
  event.waitUntil(deletion);
});
```

```js
self.oncontentdelete = (event) => {
  // …
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerGlobalScope/contentdelete_event)*

