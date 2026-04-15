# SourceBufferList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`, `IEnumerable<SourceBuffer>`  
**Source:** `JSObjects/SourceBufferList.cs`  
**MDN Reference:** [SourceBufferList on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SourceBufferList)

> The SourceBufferList interface represents a simple container list for multiple SourceBuffer objects. The source buffer list containing the SourceBuffers appended to a particular MediaSource can be retrieved using the MediaSource.sourceBuffers property. The individual source buffers can be accessed using the bracket notation []. https://developer.mozilla.org/en-US/docs/Web/API/SourceBufferList

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | Returns the number of SourceBuffer objects in the list. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetEnumerator()` | `IEnumerator<SourceBuffer>` |  |

## Events

| Event | Type | Description |
|---|---|---|
| `OnAddSourceBuffer` | `ActionEvent<Event>` | Fired when a SourceBuffer is added to the list. |
| `OnRemoveSourceBuffer` | `ActionEvent<Event>` | Fired when a SourceBuffer is removed from the list. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<SourceBufferList>(...)` or constructor `new SourceBufferList(...)`

```js
// Video is an already playing video using a MediaSource srcObject
const video = document.querySelector("video");
const mediaSource = video.srcObject;
const sourceBufferList = mediaSource.activeSourceBuffers;
for (const sourceBuffer of sourceBufferList) {
  // Do something with each SourceBuffer, such as call abort()
  sourceBuffer.abort();
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/SourceBufferList)*

