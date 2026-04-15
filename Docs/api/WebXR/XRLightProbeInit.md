# XRLightProbeInit

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebXR/XRLightProbeInit.cs`  
**MDN Reference:** [XRLightProbeInit on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRSession/requestLightProbe#options)

> https://developer.mozilla.org/en-US/docs/Web/API/XRSession/requestLightProbe#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `XRLightProbeInit` | `class` | get | https://developer.mozilla.org/en-US/docs/Web/API/XRSession/requestLightProbe#options |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRLightProbeInit>(...)` or constructor `new XRLightProbeInit(...)`

### Requesting a light probe with the system's preferred format

```js
const lightProbe = await xrSession.requestLightProbe({
  reflectionFormat: xrSession.preferredReflectionFormat,
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRSession/requestLightProbe)*

