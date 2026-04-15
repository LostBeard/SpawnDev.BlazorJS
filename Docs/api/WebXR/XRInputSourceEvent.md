# XRInputSourceEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/WebXR/XRInputSourceEvent.cs`  
**MDN Reference:** [XRInputSourceEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRInputSourceEvent)

> The WebXR Device API's XRInputSourceEvent interface describes an event which has occurred on a WebXR user input device such as a hand controller, gaze tracking system, or motion tracking system. More specifically, they represent a change in the state of an XRInputSource. https://developer.mozilla.org/en-US/docs/Web/API/XRInputSourceEvent

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Frame` | `XRFrame` | get | An XRFrame object providing the needed information about the event frame during which the event occurred. This frame may have been rendered in the past rather than being a current frame. Because this is an event frame, not an animation frame, you cannot call the XRFrame method getViewerPose() on it; instead, use getPose(). |
| `InputSource` | `XRInputSource` | get | An XRInputSource object indicating which input source generated the input event. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRInputSourceEvent>(...)` or constructor `new XRInputSourceEvent(...)`

```js
xrSession.addEventListener("select", (event) => {
  let targetRayPose = event.frame.getPose(
    event.inputSource.targetRaySpace,
    myRefSpace,
  );

  if (targetRayPose) {
    let hit = myHitTest(targetRayPose.transform);
    if (hit) {
      /* handle the hit */
    }
  }
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRInputSourceEvent)*

