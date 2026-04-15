# XRCPUDepthInformation

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `XRDepthInformation`  
**Source:** `JSObjects/WebXR/XRCPUDepthInformation.cs`  
**MDN Reference:** [XRCPUDepthInformation on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRCPUDepthInformation)

> https://developer.mozilla.org/en-US/docs/Web/API/XRCPUDepthInformation

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Data` | `ArrayBuffer` | get | An ArrayBuffer containing depth-buffer information in raw format. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetDepthInMeters(float x, float y)` | `float` | Returns the depth in meters at (x, y) in normalized view coordinates. X coordinate (origin at the left, grows to the right). Y coordinate (origin at the top, grows downward). Depth in meters |

