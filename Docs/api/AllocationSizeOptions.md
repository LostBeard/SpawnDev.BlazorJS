# AllocationSizeOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/AllocationSizeOptions.cs`  
**MDN Reference:** [AllocationSizeOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/allocationSize#options)

> VideoFrame.AllocationSize() options https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/allocationSize#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AllocationSizeOptions` | `class` | get | VideoFrame.AllocationSize() options https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/allocationSize#options |
| `Layout` | `List<VideoFrameLayout>?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<AllocationSizeOptions>(...)` or constructor `new AllocationSizeOptions(...)`

```js
const videoRect = {
  x: 0,
  y: 0,
  width: 800,
  height: 600,
};
let size = VideoFrame.allocationSize({ rect: videoRect });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/allocationSize)*

