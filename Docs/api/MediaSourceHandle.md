# MediaSourceHandle

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/MediaSourceHandle.cs`  

> The MediaSourceHandle interface of the Media Source Extensions API is a proxy for a MediaSource that can be transferred from a dedicated worker back to the main thread and attached to a media element via its HTMLMediaElement.srcObject property. MediaSource objects are not transferable because they are event targets, hence the need for MediaSourceHandles. It can be accessed via the MediaSource.handle property. Each MediaSource object created inside a dedicated worker has its own distinct MediaSourceHandle. The MediaSource.handle getter will always return the MediaSourceHandle instance specific to the associated dedicated worker MediaSource instance. If the handle has already been transferred to the main thread using postMessage(), the handle instance in the worker is technically detached and can't be transferred again. MediaSourceHandle is a transferable object. https://developer.mozilla.org/en-US/docs/Web/API/MediaSourceHandle

## Constructors

| Signature | Description |
|---|---|
| `MediaSourceHandle(IJSInProcessObjectReference _ref)` | Deserialization constructor |
